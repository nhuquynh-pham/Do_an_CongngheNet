using QLKTX;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Chuyenphong : Form
    {
        private readonly DBService _db;
        private SaveMode _saveMode = SaveMode.Insert;

        public Chuyenphong()
        {
            InitializeComponent();
            _db = new DBService();
        }

        // ================================================================
        // SỰ KIỆN LOAD FORM
        // ================================================================
        private void Chuyenphong_Load(object sender, EventArgs e)
        {
            // Gán Tag cho nút (fallback nếu Designer chưa gán)
            btnNew.Tag = "select";
            btnEdit.Tag = "select";
            btnDelete.Tag = "select";
            btnSave.Tag = "confirm";
            btnCancel.Tag = "confirm";

            // Tắt hết input và nút mặc định
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            txtSearch.Enabled = false;

            // Kiểm tra quyền — nếu không có quyền: giữ form trống,
            // đợi render xong rồi mới hiện thông báo
            if (!SessionManager.CoQuyen("CN004"))
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
            UIService.SetGridStyle(dgvChuyenphong);
            txtSearch.Enabled = true;

            LoadComboPhongHienTai();
            LoadComboPhongMoi();
            LoadComboTrangthai();
            LoadData();

            UIService.SetGridHeader(dgvChuyenphong,
                "Mã chuyển phòng", "Mã SV", "Họ tên",
                "Phòng cũ", "Khu cũ", "Phòng mới", "Khu mới",
                "Ngày chuyển", "Lý do", "Trạng thái", "Ghi chú");
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

            txtMachuyenphong.Text = GenerateNewID();
            txtMachuyenphong.ReadOnly = true;
            txtHoten.Enabled = false;

            txtNgaychuyen.Text = DateTime.Today.ToString("dd/MM/yyyy");

            txtMasinhvien.Focus();
        }

        // ================================================================
        // NÚT SỬA
        // ================================================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvChuyenphong.CurrentRow == null) return;

            _saveMode = SaveMode.Update;
            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);

            txtMachuyenphong.ReadOnly = true;
            txtHoten.Enabled = false;

            txtMasinhvien.Focus();
        }

        // ================================================================
        // NÚT XÓA
        // ================================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvChuyenphong.CurrentRow == null) return;
            if (!UIService.ConfirmDelete()) return;

            string maChuyenPhong = GetCurrentID();
            DeleteData(maChuyenPhong);
            LoadData();
        }

        // ================================================================
        // NÚT GHI (LƯU)
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string maChuyenPhong = txtMachuyenphong.Text.Trim();
            string maSV = txtMasinhvien.Text.Trim();
            string phongCu = cboPhonghientai.SelectedValue?.ToString() ?? "";
            string phongMoi = cboPhongmoi.SelectedValue?.ToString() ?? "";
            DateTime ngayChuyen = UIService.ParseDate(txtNgaychuyen.Text.Trim()).Value;
            string lyDo = txtLydochuyen.Text.Trim();
            string trangThai = cboTrangthai.Text.Trim();
            string ghiChu = txtGhichu.Text.Trim();

            if (_saveMode == SaveMode.Insert)
            {
                if (IDExists(maChuyenPhong))
                {
                    MessageBox.Show("Mã chuyển phòng đã tồn tại trong hệ thống!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMachuyenphong.Focus();
                    return;
                }
                InsertData(maChuyenPhong, maSV, phongCu, phongMoi,
                           ngayChuyen, lyDo, trangThai, ghiChu);
            }
            else
            {
                if (dgvChuyenphong.CurrentRow == null) return;
                UpdateData(maChuyenPhong, maSV, phongCu, phongMoi,
                           ngayChuyen, lyDo, trangThai, ghiChu);
            }

            LoadData();
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            txtSearch.Enabled = true;
        }

        // ================================================================
        // NÚT HỦY GHI
        // ================================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            txtSearch.Enabled = true;
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
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
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
        private void dgvChuyenphong_SelectionChanged(object sender, EventArgs e)
        {
            BindData();
        }

        // ================================================================
        // KHI NHẬP MÃ SINH VIÊN VÀ NHẤN ENTER → TỰ ĐỘNG LẤY THÔNG TIN
        // ================================================================
        private void txtMasinhvien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AutoFillStudentInfo();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
            UIService.MoveFocus((Control)sender, e);
        }

        // ================================================================
        // KHI CHỌN KHU HIỆN TẠI → TẢI PHÒNG HIỆN TẠI TƯƠNG ỨNG
        // ================================================================
        private void cboKhuhientai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhuhientai.SelectedValue == null) return;
            LoadComboPhongTheoKhu(cboPhonghientai, cboKhuhientai.SelectedValue.ToString());
        }

        // ================================================================
        // KHI CHỌN KHU MỚI → TẢI PHÒNG MỚI TƯƠNG ỨNG
        // ================================================================
        private void cboKhumoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhumoi.SelectedValue == null) return;
            LoadComboPhongTheoKhu(cboPhongmoi, cboKhumoi.SelectedValue.ToString());
        }

        // ================================================================
        // ĐIỀU HƯỚNG BÀN PHÍM
        // ================================================================
        private void txtNgaychuyen_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtLydochuyen_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtGhichu_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void cboPhonghientai_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void cboKhuhientai_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void cboPhongmoi_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void cboKhumoi_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void cboTrangthai_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);

        // ================================================================
        // KIỂM TRA DỮ LIỆU ĐẦU VÀO
        // ================================================================
        private bool ValidateInput()
        {
            if (!UIService.Require(txtMachuyenphong, "Yêu cầu phải có mã chuyển phòng!"))
                return false;

            if (!UIService.Require(txtMasinhvien, "Yêu cầu phải nhập mã sinh viên!"))
                return false;

            if (!UIService.Require(cboPhonghientai, "Yêu cầu phải chọn phòng hiện tại!"))
                return false;

            if (!UIService.Require(cboPhongmoi, "Yêu cầu phải chọn phòng mới!"))
                return false;

            if (!UIService.Require(txtNgaychuyen, "Yêu cầu phải nhập ngày chuyển!"))
                return false;

            if (!UIService.Require(cboTrangthai, "Yêu cầu phải chọn trạng thái!"))
                return false;

            if (!UIService.MaxLength(txtMasinhvien, 10, "Mã sinh viên không dài hơn 10 ký tự!"))
                return false;

            if (!UIService.MaxLength(txtLydochuyen, 200, "Lý do chuyển không dài hơn 200 ký tự!"))
                return false;

            if (!UIService.MaxLength(txtGhichu, 200, "Ghi chú không dài hơn 200 ký tự!"))
                return false;

            if (!UIService.ParseDate(txtNgaychuyen.Text.Trim()).HasValue)
            {
                MessageBox.Show("Ngày chuyển không hợp lệ! Nhập theo định dạng dd/MM/yyyy.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaychuyen.Focus();
                return false;
            }

            string phongCu = cboPhonghientai.SelectedValue?.ToString() ?? "";
            string phongMoi = cboPhongmoi.SelectedValue?.ToString() ?? "";
            if (!string.IsNullOrEmpty(phongCu) && phongCu == phongMoi)
            {
                MessageBox.Show("Phòng mới không được trùng với phòng hiện tại!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhongmoi.Focus();
                return false;
            }

            if (!StudentExists(txtMasinhvien.Text.Trim()))
            {
                MessageBox.Show("Mã sinh viên không tồn tại trong hệ thống!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasinhvien.Focus();
                return false;
            }

            return true;
        }

        // ================================================================
        // KIỂM TRA MÃ CHUYỂN PHÒNG ĐÃ TỒN TẠI
        // ================================================================
        private bool IDExists(string maChuyenPhong)
        {
            string sql = "SELECT COUNT(*) FROM ChuyenPhong WHERE MaChuyenPhong = @Ma";
            int count = Convert.ToInt32(_db.ExecuteScalar(sql,
                new SqlParameter("@Ma", maChuyenPhong)));
            return count > 0;
        }

        // ================================================================
        // KIỂM TRA SINH VIÊN TỒN TẠI
        // ================================================================
        private bool StudentExists(string maSV)
        {
            string sql = "SELECT COUNT(*) FROM SinhVien WHERE MaSV = @MaSV";
            int count = Convert.ToInt32(_db.ExecuteScalar(sql,
                new SqlParameter("@MaSV", maSV)));
            return count > 0;
        }

        // ================================================================
        // SINH MÃ CHUYỂN PHÒNG TỰ ĐỘNG (CP001, CP002, ...)
        // ================================================================
        private string GenerateNewID()
        {
            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaChuyenPhong, 3, LEN(MaChuyenPhong)) AS INT)), 0) + 1
                           FROM ChuyenPhong
                           WHERE MaChuyenPhong LIKE 'CP%'";
            object result = _db.ExecuteScalar(sql);
            int nextNum = Convert.ToInt32(result);
            return "CP" + nextNum.ToString("D3");
        }

        // ================================================================
        // TỰ ĐỘNG ĐIỀN THÔNG TIN SINH VIÊN KHI NHẬP MÃ SV
        // ================================================================
        private void AutoFillStudentInfo()
        {
            string maSV = txtMasinhvien.Text.Trim();
            if (string.IsNullOrEmpty(maSV)) return;

            string sql = @"SELECT sv.HoTen, xp.MaPhong, p.MaKhu
                           FROM SinhVien sv
                           LEFT JOIN XepPhong xp ON sv.MaSV = xp.MaSV AND xp.TrangThaiO = N'Đang ở'
                           LEFT JOIN Phong p ON xp.MaPhong = p.MaPhong
                           WHERE sv.MaSV = @MaSV";

            DataTable dt = _db.ExecuteQuery(sql, new SqlParameter("@MaSV", maSV));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên với mã: " + maSV,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoten.Clear();
                return;
            }

            DataRow row = dt.Rows[0];
            txtHoten.Text = row["HoTen"]?.ToString() ?? "";

            string maKhu = row["MaKhu"]?.ToString() ?? "";
            string maPhong = row["MaPhong"]?.ToString() ?? "";

            if (!string.IsNullOrEmpty(maKhu))
            {
                cboKhuhientai.SelectedValue = maKhu;
                LoadComboPhongTheoKhu(cboPhonghientai, maKhu);

                if (!string.IsNullOrEmpty(maPhong))
                    cboPhonghientai.SelectedValue = maPhong;
            }

            cboTrangthai.SelectedIndex = -1;
        }

        // ================================================================
        // TẢI DỮ LIỆU THEO TỪ KHÓA TÌM KIẾM
        // ================================================================
        private void LoadData()
        {
            string keyword = txtSearch.Text.Trim();
            dgvChuyenphong.DataSource = SearchData(keyword);
        }

        private DataTable SearchData(string keyword = "")
        {
            string sql = @"
                SELECT
                    cp.MaChuyenPhong,
                    cp.MaSV,
                    sv.HoTen,
                    cp.PhongCu,
                    pcu.MaKhu   AS KhuCu,
                    cp.PhongMoi,
                    pmoi.MaKhu  AS KhuMoi,
                    cp.NgayChuyen,
                    cp.LyDo,
                    cp.TrangThai,
                    cp.GhiChu
                FROM ChuyenPhong cp
                LEFT JOIN SinhVien sv   ON cp.MaSV     = sv.MaSV
                LEFT JOIN Phong pcu     ON cp.PhongCu  = pcu.MaPhong
                LEFT JOIN Phong pmoi    ON cp.PhongMoi = pmoi.MaPhong
                WHERE (@Keyword = N''
                       OR cp.MaChuyenPhong LIKE @Keyword
                       OR cp.MaSV          LIKE @Keyword
                       OR sv.HoTen         LIKE @Keyword
                       OR cp.PhongCu       LIKE @Keyword
                       OR cp.PhongMoi      LIKE @Keyword)
                ORDER BY cp.MaChuyenPhong";

            return _db.ExecuteQuery(sql,
                new SqlParameter("@Keyword", "%" + keyword + "%"));
        }

        // ================================================================
        // GÁN DỮ LIỆU TỪ LƯỚI LÊN FORM
        // ================================================================
        private void BindData()
        {
            if (dgvChuyenphong.CurrentRow == null)
            {
                UIService.ClearInputs(this);
                return;
            }

            DataGridViewRow row = dgvChuyenphong.CurrentRow;

            txtMachuyenphong.Text = row.Cells["MaChuyenPhong"].Value?.ToString() ?? "";
            txtMasinhvien.Text = row.Cells["MaSV"].Value?.ToString() ?? "";
            txtHoten.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            txtNgaychuyen.Text = UIService.FormatDate(row.Cells["NgayChuyen"].Value);
            txtLydochuyen.Text = row.Cells["LyDo"].Value?.ToString() ?? "";
            txtGhichu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";

            string phongCu = row.Cells["PhongCu"].Value?.ToString() ?? "";
            string khuCu = row.Cells["KhuCu"].Value?.ToString() ?? "";

            if (!string.IsNullOrEmpty(khuCu))
            {
                cboKhuhientai.SelectedValue = khuCu;
                LoadComboPhongTheoKhu(cboPhonghientai, khuCu);
                cboPhonghientai.SelectedValue = phongCu;
            }
            else
            {
                cboKhuhientai.SelectedIndex = -1;
                cboPhonghientai.SelectedIndex = -1;
            }

            string phongMoi = row.Cells["PhongMoi"].Value?.ToString() ?? "";
            string khuMoi = row.Cells["KhuMoi"].Value?.ToString() ?? "";

            if (!string.IsNullOrEmpty(khuMoi))
            {
                cboKhumoi.SelectedValue = khuMoi;
                LoadComboPhongTheoKhu(cboPhongmoi, khuMoi);
                cboPhongmoi.SelectedValue = phongMoi;
            }
            else
            {
                cboKhumoi.SelectedIndex = -1;
                cboPhongmoi.SelectedIndex = -1;
            }

            cboTrangthai.Text = row.Cells["TrangThai"].Value?.ToString() ?? "";
        }

        // ================================================================
        // INSERT
        // ================================================================
        private void InsertData(string ma, string maSV,
                                string phongCu, string phongMoi,
                                DateTime ngayChuyen, string lyDo, string trangThai, string ghiChu)
        {
            string sql = @"
                INSERT INTO ChuyenPhong
                    (MaChuyenPhong, MaSV, PhongCu, PhongMoi, NgayChuyen, LyDo, TrangThai, GhiChu)
                VALUES
                    (@Ma, @MaSV, @PhongCu, @PhongMoi, @NgayChuyen, @LyDo, @TrangThai, @GhiChu)";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@Ma", ma),
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@PhongCu", string.IsNullOrWhiteSpace(phongCu) ? (object)DBNull.Value : phongCu),
                new SqlParameter("@PhongMoi", string.IsNullOrWhiteSpace(phongMoi) ? (object)DBNull.Value : phongMoi),
                new SqlParameter("@NgayChuyen", ngayChuyen),
                new SqlParameter("@LyDo", string.IsNullOrWhiteSpace(lyDo) ? (object)DBNull.Value : lyDo),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu)
            );
            MessageBox.Show("Thêm phiếu chuyển phòng thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        private void UpdateData(string ma, string maSV,
                                string phongCu, string phongMoi,
                                DateTime ngayChuyen, string lyDo, string trangThai, string ghiChu)
        {
            string sql = @"
                UPDATE ChuyenPhong
                SET MaSV        = @MaSV,
                    PhongCu     = @PhongCu,
                    PhongMoi    = @PhongMoi,
                    NgayChuyen  = @NgayChuyen,
                    LyDo        = @LyDo,
                    TrangThai   = @TrangThai,
                    GhiChu      = @GhiChu
                WHERE MaChuyenPhong = @Ma";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@Ma", ma),
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@PhongCu", string.IsNullOrWhiteSpace(phongCu) ? (object)DBNull.Value : phongCu),
                new SqlParameter("@PhongMoi", string.IsNullOrWhiteSpace(phongMoi) ? (object)DBNull.Value : phongMoi),
                new SqlParameter("@NgayChuyen", ngayChuyen),
                new SqlParameter("@LyDo", string.IsNullOrWhiteSpace(lyDo) ? (object)DBNull.Value : lyDo),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu)
            );

            MessageBox.Show("Cập nhật phiếu chuyển phòng thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // DELETE
        // ================================================================
        private void DeleteData(string ma)
        {
            string sql = "DELETE FROM ChuyenPhong WHERE MaChuyenPhong = @Ma";
            _db.ExecuteNonQuery(sql, new SqlParameter("@Ma", ma));
        }

        // ================================================================
        // LẤY MÃ CHUYỂN PHÒNG CỦA DÒNG ĐANG CHỌN
        // ================================================================
        private string GetCurrentID()
        {
            if (dgvChuyenphong.CurrentRow == null) return "";
            return dgvChuyenphong.CurrentRow.Cells["MaChuyenPhong"].Value?.ToString() ?? "";
        }

        // ================================================================
        // TẢI COMBOBOX KHU NHÀ
        // ================================================================
        private DataTable GetKhuNhaData()
        {
            string sql = "SELECT MaKhu, TenKhu FROM KhuNha WHERE TrangThai = N'Đang sử dụng' ORDER BY TenKhu";
            DataTable dt = _db.ExecuteQuery(sql);

            DataRow blank = dt.NewRow();
            blank["MaKhu"] = "";
            blank["TenKhu"] = "";
            dt.Rows.InsertAt(blank, 0);

            return dt;
        }

        private void LoadComboPhongHienTai()
        {
            DataTable dt = GetKhuNhaData();
            cboKhuhientai.DataSource = dt;
            cboKhuhientai.DisplayMember = "TenKhu";
            cboKhuhientai.ValueMember = "MaKhu";
            cboKhuhientai.SelectedIndex = 0;

            cboPhonghientai.DataSource = null;
            cboPhonghientai.DisplayMember = "SoPhong";
            cboPhonghientai.ValueMember = "MaPhong";
        }

        private void LoadComboPhongMoi()
        {
            DataTable dt = GetKhuNhaData();
            cboKhumoi.DataSource = dt;
            cboKhumoi.DisplayMember = "TenKhu";
            cboKhumoi.ValueMember = "MaKhu";
            cboKhumoi.SelectedIndex = 0;

            cboPhongmoi.DataSource = null;
            cboPhongmoi.DisplayMember = "SoPhong";
            cboPhongmoi.ValueMember = "MaPhong";
        }

        // ================================================================
        // TẢI COMBOBOX PHÒNG THEO KHU
        // ================================================================
        private void LoadComboPhongTheoKhu(ComboBox cboPhong, string maKhu)
        {
            string sql = @"SELECT MaPhong, SoPhong FROM Phong
                           WHERE MaKhu = @MaKhu
                           ORDER BY SoPhong";

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
        // TẢI COMBOBOX TRẠNG THÁI
        // ================================================================
        private void LoadComboTrangthai()
        {
            cboTrangthai.Items.Clear();
            cboTrangthai.Items.Add("Đã chuyển");
            cboTrangthai.Items.Add("Chờ xử lý");
            cboTrangthai.Items.Add("Hủy chuyển");
            cboTrangthai.SelectedIndex = -1;
        }

        // ================================================================
        // SỰ KIỆN GIỮ LẠI TỪ DESIGNER
        // ================================================================
        private void tblLeft_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void lblTitle_Click_1(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
    }
}