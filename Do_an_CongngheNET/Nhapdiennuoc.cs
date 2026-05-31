using QLKTX;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Nhapdiennuoc : Form
    {
        private readonly DBService _db;
        private SaveMode _saveMode = SaveMode.Insert;

        public Nhapdiennuoc()
        {
            InitializeComponent();
            _db = new DBService();
        }

        // ================================================================
        // SỰ KIỆN LOAD FORM
        // ================================================================
        private void Nhapdiennuoc_Load(object sender, EventArgs e)
        {
            // Kiểm tra quyền — không có quyền: giữ form trống,
            // đợi render xong rồi mới hiện thông báo
            if (!SessionManager.CoQuyen("CN006") && !SessionManager.CoQuyen("CN007"))
            {
                this.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }));
                return; // dừng lại, không load dữ liệu gì cả
            }

            // Có quyền → load bình thường
            btnNew.Tag = "select";
            btnEdit.Tag = "select";
            btnDelete.Tag = "select";
            btnSave.Tag = "confirm";
            btnCancel.Tag = "confirm";

            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            txtSearch1.Enabled = true;

            UIService.SetGridStyle(dgvNhapdiennuoc);

            LoadComboKhuNha();
            LoadComboThang();
            LoadData();

            UIService.SetGridHeader(dgvNhapdiennuoc,
                "Mã phiếu", "Mã phòng", "Số phòng", "Khu nhà",
                "Tháng", "Năm",
                "CS Điện cũ", "CS Điện mới", "Điện TT",
                "CS Nước cũ", "CS Nước mới", "Nước TT",
                "Tiền điện", "Tiền nước", "Tổng tiền", "Ghi chú");
        }

        // ================================================================
        // NÚT THÊM MỚI
        // ================================================================
        private void btnNew_Click(object sender, EventArgs e)
        {
            _saveMode = SaveMode.Insert;

            UIService.ClearInputs(this);
            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);

            txtMaphieu.Text = GenerateNewID();
            txtMaphieu.ReadOnly = true;

            txtDientieuthu.ReadOnly = true;
            txtNuoctieuthu.ReadOnly = true;
            txtTongtien.ReadOnly = true;

            txtNam.Text = DateTime.Today.Year.ToString();
            txtSearch1.Enabled = true;
            cboKhuNha.Focus();
        }

        // ================================================================
        // NÚT SỬA
        // ================================================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNhapdiennuoc.CurrentRow == null) return;

            _saveMode = SaveMode.Update;
            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);

            txtMaphieu.ReadOnly = true;
            txtDientieuthu.ReadOnly = true;
            txtNuoctieuthu.ReadOnly = true;
            txtTongtien.ReadOnly = true;

            txtSearch1.Enabled = true;
            cboKhuNha.Focus();
        }

        // ================================================================
        // NÚT XÓA
        // ================================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNhapdiennuoc.CurrentRow == null) return;
            if (!UIService.ConfirmDelete()) return;

            string maPhieu = GetCurrentID();
            DeleteData(maPhieu);
            LoadData();
        }

        // ================================================================
        // NÚT GHI (LƯU)
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string maPhieu = txtMaphieu.Text.Trim();
            string maPhong = cboPhong.SelectedValue?.ToString() ?? "";
            int thang = Convert.ToInt32(cboThang.SelectedItem);
            int nam = Convert.ToInt32(txtNam.Text.Trim());
            int csDienCu = Convert.ToInt32(txtChisodiencu.Text.Trim());
            int csDienMoi = Convert.ToInt32(txtChisodienmoi.Text.Trim());
            int csNuocCu = Convert.ToInt32(txtChisonuoccu.Text.Trim());
            int csNuocMoi = Convert.ToInt32(txtChisonuocmoi.Text.Trim());
            long tienDien = Convert.ToInt64(txtTiendien.Text.Trim());
            long tienNuoc = Convert.ToInt64(txtTiennuoc.Text.Trim());

            if (_saveMode == SaveMode.Insert)
            {
                if (IDExists(maPhieu))
                {
                    MessageBox.Show("Mã phiếu đã tồn tại trong hệ thống!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaphieu.Focus();
                    return;
                }
                InsertData(maPhieu, maPhong, thang, nam,
                           csDienCu, csDienMoi, csNuocCu, csNuocMoi,
                           tienDien, tienNuoc);
            }
            else
            {
                if (dgvNhapdiennuoc.CurrentRow == null) return;
                UpdateData(maPhieu, maPhong, thang, nam,
                           csDienCu, csDienMoi, csNuocCu, csNuocMoi,
                           tienDien, tienNuoc);
            }

            LoadData();
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            txtSearch1.Enabled = true;
        }

        // ================================================================
        // NÚT HỦY GHI
        // ================================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            txtSearch1.Enabled = true;
            BindData();
        }

        // ================================================================
        // NÚT KẾT THÚC
        // ================================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ================================================================
        // TÌM KIẾM KHI NHẤN ENTER
        // ================================================================
        private void txtSearch1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // ================================================================
        // KHI CHỌN DÒNG TRÊN LƯỚI → HIỂN THỊ DỮ LIỆU LÊN FORM
        // ================================================================
        private void dgvNhapdiennuoc_SelectionChanged(object sender, EventArgs e)
        {
            BindData();
        }

        // ================================================================
        // KHI CHỌN KHU NHÀ → TẢI DANH SÁCH PHÒNG TƯƠNG ỨNG
        // ================================================================
        private void cboKhuNha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhuNha.SelectedValue == null) return;
            LoadComboPhong(cboKhuNha.SelectedValue.ToString());
        }

        // ================================================================
        // TỰ TÍNH KHI NHẬP CHỈ SỐ / TIỀN
        // ================================================================
        private void txtChisodienmoi_TextChanged(object sender, EventArgs e) => RecalcDien();
        private void txtChisodiencu_TextChanged(object sender, EventArgs e) => RecalcDien();
        private void txtChisonuocmoi_TextChanged(object sender, EventArgs e) => RecalcNuoc();
        private void txtChisonuoccu_TextChanged(object sender, EventArgs e) => RecalcNuoc();
        private void txtTiendien_TextChanged(object sender, EventArgs e) => RecalcTong();
        private void txtTiennuoc_TextChanged(object sender, EventArgs e) => RecalcTong();

        // ================================================================
        // ĐIỀU HƯỚNG BÀN PHÍM
        // ================================================================
        private void txtNam_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtChisodiencu_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtChisodienmoi_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtChisonuoccu_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtChisonuocmoi_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtTiendien_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtTiennuoc_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void cboKhuNha_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void cboPhong_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void cboThang_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);

        // ================================================================
        // TÍNH TOÁN TỰ ĐỘNG
        // ================================================================
        private void RecalcDien()
        {
            int cu = 0, moi = 0;
            int.TryParse(txtChisodiencu.Text.Trim(), out cu);
            int.TryParse(txtChisodienmoi.Text.Trim(), out moi);
            txtDientieuthu.Text = (moi - cu >= 0) ? (moi - cu).ToString() : "0";
            RecalcTong();
        }

        private void RecalcNuoc()
        {
            int cu = 0, moi = 0;
            int.TryParse(txtChisonuoccu.Text.Trim(), out cu);
            int.TryParse(txtChisonuocmoi.Text.Trim(), out moi);
            txtNuoctieuthu.Text = (moi - cu >= 0) ? (moi - cu).ToString() : "0";
            RecalcTong();
        }

        private void RecalcTong()
        {
            long dien = 0, nuoc = 0;
            long.TryParse(txtTiendien.Text.Trim(), out dien);
            long.TryParse(txtTiennuoc.Text.Trim(), out nuoc);
            txtTongtien.Text = (dien + nuoc).ToString();
        }

        // ================================================================
        // KIỂM TRA DỮ LIỆU ĐẦU VÀO
        // ================================================================
        private bool ValidateInput()
        {
            if (!UIService.Require(txtMaphieu, "Yêu cầu phải có mã phiếu!")) return false;
            if (!UIService.Require(cboPhong, "Yêu cầu phải chọn phòng!")) return false;
            if (!UIService.Require(cboThang, "Yêu cầu phải chọn tháng!")) return false;
            if (!UIService.Require(txtNam, "Yêu cầu phải nhập năm!")) return false;
            if (!UIService.IsNumber(txtNam, "Năm phải là số nguyên hợp lệ!")) return false;

            if (!UIService.Require(txtChisodiencu, "Yêu cầu phải nhập chỉ số điện cũ!")) return false;
            if (!UIService.Require(txtChisodienmoi, "Yêu cầu phải nhập chỉ số điện mới!")) return false;
            if (!UIService.IsNumber(txtChisodiencu, "Chỉ số điện cũ phải là số!")) return false;
            if (!UIService.IsNumber(txtChisodienmoi, "Chỉ số điện mới phải là số!")) return false;

            if (Convert.ToInt32(txtChisodienmoi.Text.Trim()) < Convert.ToInt32(txtChisodiencu.Text.Trim()))
            {
                MessageBox.Show("Chỉ số điện mới không được nhỏ hơn chỉ số điện cũ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChisodienmoi.Focus();
                return false;
            }

            if (!UIService.Require(txtChisonuoccu, "Yêu cầu phải nhập chỉ số nước cũ!")) return false;
            if (!UIService.Require(txtChisonuocmoi, "Yêu cầu phải nhập chỉ số nước mới!")) return false;
            if (!UIService.IsNumber(txtChisonuoccu, "Chỉ số nước cũ phải là số!")) return false;
            if (!UIService.IsNumber(txtChisonuocmoi, "Chỉ số nước mới phải là số!")) return false;

            if (Convert.ToInt32(txtChisonuocmoi.Text.Trim()) < Convert.ToInt32(txtChisonuoccu.Text.Trim()))
            {
                MessageBox.Show("Chỉ số nước mới không được nhỏ hơn chỉ số nước cũ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChisonuocmoi.Focus();
                return false;
            }

            if (!UIService.Require(txtTiendien, "Yêu cầu phải nhập tiền điện!")) return false;
            if (!UIService.Require(txtTiennuoc, "Yêu cầu phải nhập tiền nước!")) return false;
            if (!UIService.IsNumber(txtTiendien, "Tiền điện phải là số!")) return false;
            if (!UIService.IsNumber(txtTiennuoc, "Tiền nước phải là số!")) return false;

            if (_saveMode == SaveMode.Insert)
            {
                string maPhong = cboPhong.SelectedValue?.ToString() ?? "";
                int thang = Convert.ToInt32(cboThang.SelectedItem);
                int nam = Convert.ToInt32(txtNam.Text.Trim());

                if (RecordExists(maPhong, thang, nam))
                {
                    MessageBox.Show($"Phòng này đã có phiếu điện nước tháng {thang}/{nam}!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboPhong.Focus();
                    return false;
                }
            }

            return true;
        }

        // ================================================================
        // KIỂM TRA MÃ PHIẾU ĐÃ TỒN TẠI
        // ================================================================
        private bool IDExists(string maPhieu)
        {
            string sql = "SELECT COUNT(*) FROM DienNuoc WHERE MaPhieu = @MaPhieu";
            return Convert.ToInt32(_db.ExecuteScalar(sql,
                new SqlParameter("@MaPhieu", maPhieu))) > 0;
        }

        // ================================================================
        // KIỂM TRA PHÒNG ĐÃ CÓ PHIẾU TRONG THÁNG/NĂM ĐÓ
        // ================================================================
        private bool RecordExists(string maPhong, int thang, int nam)
        {
            string sql = @"SELECT COUNT(*) FROM DienNuoc
                           WHERE MaPhong = @MaPhong AND Thang = @Thang AND Nam = @Nam";
            return Convert.ToInt32(_db.ExecuteScalar(sql,
                new SqlParameter("@MaPhong", maPhong),
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam))) > 0;
        }

        // ================================================================
        // SINH MÃ PHIẾU TỰ ĐỘNG (DN001, DN002, ...)
        // ================================================================
        private string GenerateNewID()
        {
            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaPhieu, 3, LEN(MaPhieu)) AS INT)), 0) + 1
                           FROM DienNuoc WHERE MaPhieu LIKE 'DN%'";
            return "DN" + Convert.ToInt32(_db.ExecuteScalar(sql)).ToString("D3");
        }

        // ================================================================
        // TẢI DỮ LIỆU
        // ================================================================
        private void LoadData()
        {
            dgvNhapdiennuoc.DataSource = SearchData(txtSearch1.Text.Trim());
        }

        private DataTable SearchData(string keyword = "")
        {
            string sql = @"SELECT dn.MaPhieu, dn.MaPhong, p.SoPhong, k.TenKhu,
                                  dn.Thang, dn.Nam,
                                  dn.ChiSoDienCu, dn.ChiSoDienMoi, dn.DienTieuThu,
                                  dn.ChiSoNuocCu, dn.ChiSoNuocMoi, dn.NuocTieuThu,
                                  dn.TienDien, dn.TienNuoc, dn.TongTien, dn.GhiChu
                           FROM DienNuoc dn
                           LEFT JOIN Phong  p ON dn.MaPhong = p.MaPhong
                           LEFT JOIN KhuNha k ON p.MaKhu    = k.MaKhu
                           WHERE (@Keyword = N''
                                  OR dn.MaPhieu LIKE @Keyword
                                  OR dn.MaPhong LIKE @Keyword
                                  OR p.SoPhong  LIKE @Keyword
                                  OR k.TenKhu   LIKE @Keyword
                                  OR CAST(dn.Thang AS NVARCHAR) LIKE @Keyword
                                  OR CAST(dn.Nam   AS NVARCHAR) LIKE @Keyword)
                           ORDER BY dn.MaPhieu";

            return _db.ExecuteQuery(sql,
                new SqlParameter("@Keyword", "%" + keyword + "%"));
        }

        // ================================================================
        // GÁN DỮ LIỆU TỪ LƯỚI LÊN FORM
        // ================================================================
        private void BindData()
        {
            if (dgvNhapdiennuoc.CurrentRow == null)
            {
                UIService.ClearInputs(this);
                return;
            }

            DataGridViewRow row = dgvNhapdiennuoc.CurrentRow;

            txtMaphieu.Text = row.Cells["MaPhieu"].Value?.ToString() ?? "";
            txtNam.Text = row.Cells["Nam"].Value?.ToString() ?? "";
            txtChisodiencu.Text = row.Cells["ChiSoDienCu"].Value?.ToString() ?? "";
            txtChisodienmoi.Text = row.Cells["ChiSoDienMoi"].Value?.ToString() ?? "";
            txtDientieuthu.Text = row.Cells["DienTieuThu"].Value?.ToString() ?? "";
            txtChisonuoccu.Text = row.Cells["ChiSoNuocCu"].Value?.ToString() ?? "";
            txtChisonuocmoi.Text = row.Cells["ChiSoNuocMoi"].Value?.ToString() ?? "";
            txtNuoctieuthu.Text = row.Cells["NuocTieuThu"].Value?.ToString() ?? "";
            txtTiendien.Text = row.Cells["TienDien"].Value?.ToString() ?? "";
            txtTiennuoc.Text = row.Cells["TienNuoc"].Value?.ToString() ?? "";
            txtTongtien.Text = row.Cells["TongTien"].Value?.ToString() ?? "";

            object thangVal = row.Cells["Thang"].Value;
            if (thangVal != null && thangVal != DBNull.Value)
                cboThang.SelectedItem = Convert.ToInt32(thangVal);
            else
                cboThang.SelectedIndex = -1;

            string maPhong = row.Cells["MaPhong"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(maPhong))
            {
                object maKhuObj = _db.ExecuteScalar(
                    "SELECT MaKhu FROM Phong WHERE MaPhong = @MaPhong",
                    new SqlParameter("@MaPhong", maPhong));
                string maKhu = maKhuObj?.ToString() ?? "";

                cboKhuNha.SelectedValue = maKhu;
                LoadComboPhong(maKhu);
                cboPhong.SelectedValue = maPhong;
            }
            else
            {
                cboKhuNha.SelectedIndex = -1;
                cboPhong.SelectedIndex = -1;
            }
        }

        // ================================================================
        // INSERT
        // ================================================================
        private void InsertData(string maPhieu, string maPhong,
                                int thang, int nam,
                                int csDienCu, int csDienMoi,
                                int csNuocCu, int csNuocMoi,
                                long tienDien, long tienNuoc)
        {
            string sql = @"INSERT INTO DienNuoc
                               (MaPhieu, MaPhong, Thang, Nam,
                                ChiSoDienCu, ChiSoDienMoi,
                                ChiSoNuocCu, ChiSoNuocMoi,
                                TienDien, TienNuoc, GhiChu)
                           VALUES
                               (@MaPhieu, @MaPhong, @Thang, @Nam,
                                @ChiSoDienCu, @ChiSoDienMoi,
                                @ChiSoNuocCu, @ChiSoNuocMoi,
                                @TienDien, @TienNuoc, N'')";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaPhieu", maPhieu),
                new SqlParameter("@MaPhong", maPhong),
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam),
                new SqlParameter("@ChiSoDienCu", csDienCu),
                new SqlParameter("@ChiSoDienMoi", csDienMoi),
                new SqlParameter("@ChiSoNuocCu", csNuocCu),
                new SqlParameter("@ChiSoNuocMoi", csNuocMoi),
                new SqlParameter("@TienDien", tienDien),
                new SqlParameter("@TienNuoc", tienNuoc));

            MessageBox.Show("Thêm phiếu điện nước thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        private void UpdateData(string maPhieu, string maPhong,
                                int thang, int nam,
                                int csDienCu, int csDienMoi,
                                int csNuocCu, int csNuocMoi,
                                long tienDien, long tienNuoc)
        {
            string sql = @"UPDATE DienNuoc
                           SET MaPhong       = @MaPhong,
                               Thang         = @Thang,
                               Nam           = @Nam,
                               ChiSoDienCu   = @ChiSoDienCu,
                               ChiSoDienMoi  = @ChiSoDienMoi,
                               ChiSoNuocCu   = @ChiSoNuocCu,
                               ChiSoNuocMoi  = @ChiSoNuocMoi,
                               TienDien      = @TienDien,
                               TienNuoc      = @TienNuoc
                           WHERE MaPhieu = @MaPhieu";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaPhieu", maPhieu),
                new SqlParameter("@MaPhong", maPhong),
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam),
                new SqlParameter("@ChiSoDienCu", csDienCu),
                new SqlParameter("@ChiSoDienMoi", csDienMoi),
                new SqlParameter("@ChiSoNuocCu", csNuocCu),
                new SqlParameter("@ChiSoNuocMoi", csNuocMoi),
                new SqlParameter("@TienDien", tienDien),
                new SqlParameter("@TienNuoc", tienNuoc));

            MessageBox.Show("Cập nhật phiếu điện nước thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // DELETE
        // ================================================================
        private void DeleteData(string maPhieu)
        {
            _db.ExecuteNonQuery("DELETE FROM DienNuoc WHERE MaPhieu = @MaPhieu",
                new SqlParameter("@MaPhieu", maPhieu));
        }

        // ================================================================
        // LẤY MÃ PHIẾU CỦA DÒNG ĐANG CHỌN
        // ================================================================
        private string GetCurrentID()
        {
            if (dgvNhapdiennuoc.CurrentRow == null) return "";
            return dgvNhapdiennuoc.CurrentRow.Cells["MaPhieu"].Value?.ToString() ?? "";
        }

        // ================================================================
        // TẢI COMBOBOX KHU NHÀ
        // ================================================================
        private void LoadComboKhuNha()
        {
            string sql = "SELECT MaKhu, TenKhu FROM KhuNha WHERE TrangThai = N'Đang sử dụng' ORDER BY TenKhu";
            DataTable dt = _db.ExecuteQuery(sql);

            DataRow blank = dt.NewRow();
            blank["MaKhu"] = "";
            blank["TenKhu"] = "";
            dt.Rows.InsertAt(blank, 0);

            cboKhuNha.DataSource = dt;
            cboKhuNha.DisplayMember = "TenKhu";
            cboKhuNha.ValueMember = "MaKhu";
            cboKhuNha.SelectedIndex = 0;
        }

        // ================================================================
        // TẢI COMBOBOX PHÒNG THEO KHU
        // ================================================================
        private void LoadComboPhong(string maKhu)
        {
            string sql = @"SELECT MaPhong, SoPhong FROM Phong
                           WHERE MaKhu = @MaKhu ORDER BY SoPhong";
            DataTable dt = _db.ExecuteQuery(sql, new SqlParameter("@MaKhu", maKhu));

            DataRow blank = dt.NewRow();
            blank["MaPhong"] = "";
            blank["SoPhong"] = "";
            dt.Rows.InsertAt(blank, 0);

            cboPhong.DataSource = dt;
            cboPhong.DisplayMember = "SoPhong";
            cboPhong.ValueMember = "MaPhong";
            cboPhong.SelectedIndex = 0;
        }

        // ================================================================
        // TẢI COMBOBOX THÁNG (1–12)
        // ================================================================
        private void LoadComboThang()
        {
            cboThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
                cboThang.Items.Add(i);
            cboThang.SelectedIndex = -1;
        }

        // ================================================================
        // SỰ KIỆN GIỮ LẠI TỪ DESIGNER
        // ================================================================
        private void tlpRoot_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void tlpContent_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
    }
}