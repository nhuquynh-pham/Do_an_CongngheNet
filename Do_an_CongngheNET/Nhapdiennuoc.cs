using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Do_an_CongngheNET
{
    public partial class Nhapdiennuoc : Form //Khai báo form nhapdiennuoc kế thừa từ form
    {
        private readonly DBService _db; //Biến toàn cục dùng để kết nối db
        private SaveMode _saveMode = SaveMode.Insert; //biến xác định đang thêm mới hay sửa dữ liệu

        // Đơn giá điện và nước (có thể điều chỉnh theo thực tế)
        private const int GIA_DIEN = 3500;  // VNĐ/kWh
        private const int GIA_NUOC = 15000; // VNĐ/m³

        public Nhapdiennuoc() //Khởi tạo form, đăng ký sự kiện
        {
            InitializeComponent(); //tạo giao diện form
            _db = new DBService(); //tạo object để kết nối db

            // Đăng ký sự kiện Load
            this.Load += Nhapdiennuoc_Load;

            // Đăng ký sự kiện nút bấm
            btnNew.Click += btnNew_Click; //khi click button new sẽ chạy hàm btn new click
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnClose.Click += btnClose_Click;

            // ComboBox khu nhà → nạp phòng
            cboKhuNha.SelectedIndexChanged += cboKhuNha_SelectedIndexChanged;

            // Grid chọn dòng → hiển thị lên ô nhập
            dgvNhapdiennuoc.SelectionChanged += dgvNhapdiennuoc_SelectionChanged;

            // Tìm kiếm khi nhấn Enter
            txtSearch1.KeyDown += txtSearch1_KeyDown;

            // Tự động tính tiêu thụ / tổng tiền
            txtChisodiencu.TextChanged += txtChisodiencu_TextChanged;
            txtChisodienmoi.TextChanged += txtChisodienmoi_TextChanged;
            txtChisonuoccu.TextChanged += txtChisonuoccu_TextChanged;
            txtChisonuocmoi.TextChanged += txtChisonuocmoi_TextChanged;

            // Chỉ cho nhập số ở các ô số
            txtNam.KeyPress += txtSo_KeyPress;
            txtChisodiencu.KeyPress += txtSo_KeyPress;
            txtChisodienmoi.KeyPress += txtSo_KeyPress;
            txtChisonuoccu.KeyPress += txtSo_KeyPress;
            txtChisonuocmoi.KeyPress += txtSo_KeyPress;

            // Di chuyển focus bằng Enter / mũi tên
            foreach (Control ctrl in this.Controls)
                RegisterKeyDown(ctrl);
        }

        // Đăng ký sự kiện KeyDown đệ quy cho tất cả TextBox
        private void RegisterKeyDown(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox tb)
                    tb.KeyDown += txt_KeyDown;
                RegisterKeyDown(ctrl);
            }
        }

        // ===== KHỞI TẠO FORM =====

        private void Nhapdiennuoc_Load(object sender, EventArgs e)
        {
            // Gán Tag cho các nút (theo logic UIService)
            btnNew.Tag = "select";   // luôn sáng
            btnEdit.Tag = "select";
            btnDelete.Tag = "select";
            btnClose.Tag = "select";
            btnSave.Tag = "confirm";  // chỉ sáng khi đang thao tác
            btnCancel.Tag = "confirm";
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            UIService.SetGridStyle(dgvNhapdiennuoc);

            // 5 ô tự tính luôn ReadOnly
            txtDientieuthu.ReadOnly = true;
            txtNuoctieuthu.ReadOnly = true;
            txtTiendien.ReadOnly = true;
            txtTiennuoc.ReadOnly = true;
            txtTongtien.ReadOnly = true;

            LoadKhuNha();
            LoadThang();
            LoadData();

            UIService.SetGridHeader(dgvNhapdiennuoc,
                "Mã phiếu", "Khu nhà", "Phòng", "Tháng", "Năm",
                "CS điện cũ", "CS điện mới", "Điện tiêu thụ",
                "CS nước cũ", "CS nước mới", "Nước tiêu thụ",
                "Tiền điện", "Tiền nước", "Tổng tiền");
        }

        // ===== NẠP COMBOBOX =====

        private void LoadKhuNha()
        {
            // Bảng KhuNha có cột MaKhu và TenKhu
            string sql = "SELECT MaKhu, TenKhu FROM KhuNha ORDER BY TenKhu";
            DataTable dt = _db.ExecuteQuery(sql);
            cboKhuNha.DataSource = dt;
            cboKhuNha.DisplayMember = "TenKhu";
            cboKhuNha.ValueMember = "MaKhu";
            cboKhuNha.SelectedIndex = -1;
        }

        private void LoadPhong(string maKhu)
        {
            // Bảng Phong có cột MaPhong, SoPhong, MaKhu
            string sql = @"SELECT MaPhong, SoPhong FROM Phong
                           WHERE MaKhu = @MaKhu ORDER BY SoPhong";
            DataTable dt = _db.ExecuteQuery(sql,
                new SqlParameter("@MaKhu", maKhu));
            cboPhong.DataSource = dt;
            cboPhong.DisplayMember = "SoPhong";
            cboPhong.ValueMember = "MaPhong";
            cboPhong.SelectedIndex = -1;
        }

        private void LoadThang()
        {
            cboThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
                cboThang.Items.Add(i);
            cboThang.SelectedIndex = -1;
        }

        // ===== SỰ KIỆN NÚT =====

        private void btnNew_Click(object sender, EventArgs e)
        {
            _saveMode = SaveMode.Insert;
            UIService.ClearInputs(this);
            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);

            txtDientieuthu.ReadOnly = true;
            txtNuoctieuthu.ReadOnly = true;
            txtTiendien.ReadOnly = true;
            txtTiennuoc.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtMaphieu.ReadOnly = false;

            // Mặc định tháng/năm hiện tại
            cboThang.SelectedItem = DateTime.Now.Month;
            txtNam.Text = DateTime.Now.Year.ToString();

            txtMaphieu.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNhapdiennuoc.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _saveMode = SaveMode.Update;
            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);

            txtDientieuthu.ReadOnly = true;
            txtNuoctieuthu.ReadOnly = true;
            txtTiendien.ReadOnly = true;
            txtTiennuoc.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtMaphieu.ReadOnly = true; // Không cho sửa mã phiếu

            txtChisodiencu.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNhapdiennuoc.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!UIService.ConfirmDelete()) return;

            try
            {
                DeleteData(GetCurrentMaPhieu());
                LoadData();
                MessageBox.Show("Xóa phiếu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string maPhieu = txtMaphieu.Text.Trim();
                string maPhong = cboPhong.SelectedValue?.ToString();
                int thang = Convert.ToInt32(cboThang.SelectedItem);
                int nam = Convert.ToInt32(txtNam.Text.Trim());
                int csDienCu = Convert.ToInt32(txtChisodiencu.Text.Trim());
                int csDienMoi = Convert.ToInt32(txtChisodienmoi.Text.Trim());
                int csNuocCu = Convert.ToInt32(txtChisonuoccu.Text.Trim());
                int csNuocMoi = Convert.ToInt32(txtChisonuocmoi.Text.Trim());
                int tienDien = Convert.ToInt32(txtTiendien.Text.Trim());
                int tienNuoc = Convert.ToInt32(txtTiennuoc.Text.Trim());

                // Tính tiêu thụ và tổng tiền
                int dienTieuThu = csDienMoi - csDienCu;
                int nuocTieuThu = csNuocMoi - csNuocCu;
                int tongTien = tienDien + tienNuoc;

                if (_saveMode == SaveMode.Insert)
                {
                    if (MaPhieuExists(maPhieu))
                    {
                        MessageBox.Show("Mã phiếu đã tồn tại!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaphieu.Focus();
                        return;
                    }
                    InsertData(maPhieu, maPhong, thang, nam,
csDienCu, csDienMoi, dienTieuThu,
                               csNuocCu, csNuocMoi, nuocTieuThu,
                               tienDien, tienNuoc, tongTien);
                    MessageBox.Show("Thêm phiếu thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UpdateData(maPhieu, maPhong, thang, nam,
                               csDienCu, csDienMoi, dienTieuThu,
                               csNuocCu, csNuocMoi, nuocTieuThu,
                               tienDien, tienNuoc, tongTien);
                    MessageBox.Show("Cập nhật phiếu thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadData();
                UIService.SetInputsEnabled(this, false);
                UIService.SetButtonsEnabled(this, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            BindData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ===== SỰ KIỆN COMBOBOX / GRID / TEXTBOX =====

        // Chọn khu nhà → nạp lại phòng
        private void cboKhuNha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhuNha.SelectedValue == null) return;
            LoadPhong(cboKhuNha.SelectedValue.ToString());
        }

        // Chọn dòng lưới → hiển thị lên ô nhập
        private void dgvNhapdiennuoc_SelectionChanged(object sender, EventArgs e)
        {
            BindData();
        }

        // Tìm kiếm khi nhấn Enter
        private void txtSearch1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Di chuyển focus khi nhấn Enter / mũi tên
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            UIService.MoveFocus((Control)sender, e);
        }

        // Chỉ cho nhập số
        private void txtSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // ===== TỰ ĐỘNG TÍNH =====

        private void txtChisodiencu_TextChanged(object sender, EventArgs e) => TinhDienTieuthu();
        private void txtChisodienmoi_TextChanged(object sender, EventArgs e) => TinhDienTieuthu();
        private void txtChisonuoccu_TextChanged(object sender, EventArgs e) => TinhNuocTieuthu();
        private void txtChisonuocmoi_TextChanged(object sender, EventArgs e) => TinhNuocTieuthu();

        private void TinhDienTieuthu()
        {
            int cu, moi;
            if (int.TryParse(txtChisodiencu.Text, out cu) &&
                int.TryParse(txtChisodienmoi.Text, out moi))
            {
                int tieuThu = moi - cu;
                txtDientieuthu.Text = tieuThu.ToString();
                txtTiendien.Text = (tieuThu * GIA_DIEN).ToString();
            }
            else
            {
                txtDientieuthu.Text = "";
                txtTiendien.Text = "";
            }
            TinhTongTien();
        }

        private void TinhNuocTieuthu()
        {
            int cu, moi;
            if (int.TryParse(txtChisonuoccu.Text, out cu) &&
                int.TryParse(txtChisonuocmoi.Text, out moi))
            {
                int tieuThu = moi - cu;
                txtNuoctieuthu.Text = tieuThu.ToString();
                txtTiennuoc.Text = (tieuThu * GIA_NUOC).ToString();
            }
            else
            {
                txtNuoctieuthu.Text = "";
                txtTiennuoc.Text = "";
            }
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            int d = 0, n = 0;
            int.TryParse(txtTiendien.Text, out d);
            int.TryParse(txtTiennuoc.Text, out n);
            txtTongtien.Text = (d + n).ToString();
        }

        // ===== VALIDATE =====

        private bool ValidateInput()
        {
            if (!UIService.Require(txtMaphieu, "Yêu cầu phải nhập mã phiếu!"))
                return false;
            if (!UIService.Require(cboKhuNha, "Yêu cầu phải chọn khu nhà!"))
                return false;
            if (!UIService.Require(cboPhong, "Yêu cầu phải chọn phòng!"))
                return false;
            if (!UIService.Require(cboThang, "Yêu cầu phải chọn tháng!"))
                return false;

            // (Tiền điện và tiền nước được tính tự động, không cần validate thủ công)

            int nam;
            if (!int.TryParse(txtNam.Text.Trim(), out nam) || nam < 2000)
            {
                MessageBox.Show("Năm không hợp lệ (phải >= 2000)!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNam.Focus();
                return false;
            }

            int csDienCu;
            if (!int.TryParse(txtChisodiencu.Text.Trim(), out csDienCu))
            {
                MessageBox.Show("Chỉ số điện cũ không hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChisodiencu.Focus();
                return false;
            }

            int csDienMoi;
            if (!int.TryParse(txtChisodienmoi.Text.Trim(), out csDienMoi) || csDienMoi < csDienCu)
            {
                MessageBox.Show("Chỉ số điện mới phải lớn hơn hoặc bằng chỉ số cũ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChisodienmoi.Focus();
                return false;
            }

            int csNuocCu;
            if (!int.TryParse(txtChisonuoccu.Text.Trim(), out csNuocCu))
            {
                MessageBox.Show("Chỉ số nước cũ không hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChisonuoccu.Focus();
                return false;
            }

            int csNuocMoi;
            if (!int.TryParse(txtChisonuocmoi.Text.Trim(), out csNuocMoi) || csNuocMoi < csNuocCu)
            {
                MessageBox.Show("Chỉ số nước mới phải lớn hơn hoặc bằng chỉ số cũ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChisonuocmoi.Focus();
                return false;
            }

            return true;
        }

        // ===== TẢI & HIỂN THỊ DỮ LIỆU =====

        private void LoadData()
        {
            string keyword = txtSearch1.Text.Trim();

            // Tạm tắt sự kiện SelectionChanged để tránh BindData chạy liên tục khi load
            dgvNhapdiennuoc.SelectionChanged -= dgvNhapdiennuoc_SelectionChanged;
            dgvNhapdiennuoc.DataSource = SearchData(keyword);
            dgvNhapdiennuoc.SelectionChanged += dgvNhapdiennuoc_SelectionChanged;

            // Hiển thị dòng đầu tiên nếu có
            if (dgvNhapdiennuoc.Rows.Count > 0)
                dgvNhapdiennuoc.Rows[0].Selected = true;

            BindData();
        }

        private void BindData()
        {
            if (dgvNhapdiennuoc.CurrentRow == null)
            {
                UIService.ClearInputs(this);
                return;
            }

            var row = dgvNhapdiennuoc.CurrentRow;

            // Tắt sự kiện TextChanged khi gán để tránh tính toán sai
            txtChisodiencu.TextChanged -= txtChisodiencu_TextChanged;
            txtChisodienmoi.TextChanged -= txtChisodienmoi_TextChanged;
            txtChisonuoccu.TextChanged -= txtChisonuoccu_TextChanged;
            txtChisonuocmoi.TextChanged -= txtChisonuocmoi_TextChanged;

            txtMaphieu.Text = GetCellValue(row, "MaPhieu");
            txtNam.Text = GetCellValue(row, "Nam");
            txtChisodiencu.Text = GetCellValue(row, "ChiSoDienCu");
            txtChisodienmoi.Text = GetCellValue(row, "ChiSoDienMoi");
            txtDientieuthu.Text = GetCellValue(row, "DienTieuThu");
            txtChisonuoccu.Text = GetCellValue(row, "ChiSoNuocCu");
            txtChisonuocmoi.Text = GetCellValue(row, "ChiSoNuocMoi");
            txtNuoctieuthu.Text = GetCellValue(row, "NuocTieuThu");
            txtTiendien.Text = GetCellValue(row, "TienDien");
            txtTiennuoc.Text = GetCellValue(row, "TienNuoc");
            txtTongtien.Text = GetCellValue(row, "TongTien");

            // Bật lại sự kiện
            txtChisodiencu.TextChanged += txtChisodiencu_TextChanged;
            txtChisodienmoi.TextChanged += txtChisodienmoi_TextChanged;
            txtChisonuoccu.TextChanged += txtChisonuoccu_TextChanged;
            txtChisonuocmoi.TextChanged += txtChisonuocmoi_TextChanged;

            // Gán ComboBox khu nhà và phòng
            string maKhu = GetCellValue(row, "MaKhu");
            string maPhong = GetCellValue(row, "MaPhong");

            // Tắt sự kiện SelectedIndexChanged khi gán để tránh LoadPhong bị gọi 2 lần
            cboKhuNha.SelectedIndexChanged -= cboKhuNha_SelectedIndexChanged;
            cboKhuNha.SelectedValue = maKhu;
            cboKhuNha.SelectedIndexChanged += cboKhuNha_SelectedIndexChanged;

            LoadPhong(maKhu);
            cboPhong.SelectedValue = maPhong;

            // Gán tháng
            int thang;
            if (int.TryParse(GetCellValue(row, "Thang"), out thang))
                cboThang.SelectedItem = thang;
        }

        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            try
            {
                return row.Cells[columnName].Value?.ToString() ?? "";
            }
            catch
            {
                return "";
            }
        }

        private DataTable SearchData(string keyword = "")
        {
            // Bảng DienNuoc, join Phong → KhuNha để lấy TenKhu, SoPhong
            string sql = @"
                SELECT d.MaPhieu,
                       k.TenKhu,
                       p.SoPhong,
                       d.Thang,
                       d.Nam,
                       d.ChiSoDienCu,
                       d.ChiSoDienMoi,
                       d.DienTieuThu,
                       d.ChiSoNuocCu,
                       d.ChiSoNuocMoi,
                       d.NuocTieuThu,
                       d.TienDien,
                       d.TienNuoc,
                       d.TongTien,
                       p.MaKhu,
                       d.MaPhong
                FROM   DienNuoc d
                JOIN   Phong    p ON p.MaPhong = d.MaPhong
                JOIN   KhuNha   k ON k.MaKhu   = p.MaKhu
                WHERE  (@Keyword = N''
                        OR d.MaPhieu LIKE @Keyword
                        OR k.TenKhu  LIKE @Keyword
                        OR p.SoPhong LIKE @Keyword
                        OR CAST(d.Thang AS NVARCHAR) LIKE @Keyword
                        OR CAST(d.Nam   AS NVARCHAR) LIKE @Keyword)
                ORDER  BY d.Nam DESC, d.Thang DESC, d.MaPhieu";

            return _db.ExecuteQuery(sql,
                new SqlParameter("@Keyword", "%" + keyword + "%"));
        }

        // ===== THAO TÁC CSDL =====

        private bool MaPhieuExists(string maPhieu)
        {
            string sql = "SELECT COUNT(*) FROM DienNuoc WHERE MaPhieu = @MaPhieu";
            return Convert.ToInt32(_db.ExecuteScalar(sql,
                            new SqlParameter("@MaPhieu", maPhieu))) > 0;
        }

        private void InsertData(string maPhieu, string maPhong,
                                int thang, int nam,
                                int csDienCu, int csDienMoi, int dienTieuThu,
                                int csNuocCu, int csNuocMoi, int nuocTieuThu,
                                int tienDien, int tienNuoc, int tongTien)
        {
            string sql = @"
                INSERT INTO DienNuoc
                    (MaPhieu, MaPhong, Thang, Nam,
                     ChiSoDienCu, ChiSoDienMoi, DienTieuThu,
                     ChiSoNuocCu, ChiSoNuocMoi, NuocTieuThu,
                     TienDien, TienNuoc, TongTien)
                VALUES
                    (@MaPhieu, @MaPhong, @Thang, @Nam,
                     @ChiSoDienCu, @ChiSoDienMoi, @DienTieuThu,
                     @ChiSoNuocCu, @ChiSoNuocMoi, @NuocTieuThu,
                     @TienDien, @TienNuoc, @TongTien)";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaPhieu", maPhieu),
                new SqlParameter("@MaPhong", maPhong),
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam),
                new SqlParameter("@ChiSoDienCu", csDienCu),
                new SqlParameter("@ChiSoDienMoi", csDienMoi),
                new SqlParameter("@DienTieuThu", dienTieuThu),
                new SqlParameter("@ChiSoNuocCu", csNuocCu),
                new SqlParameter("@ChiSoNuocMoi", csNuocMoi),
                new SqlParameter("@NuocTieuThu", nuocTieuThu),
                new SqlParameter("@TienDien", tienDien),
                new SqlParameter("@TienNuoc", tienNuoc),
                new SqlParameter("@TongTien", tongTien));
        }

        private void UpdateData(string maPhieu, string maPhong,
                                int thang, int nam,
                                int csDienCu, int csDienMoi, int dienTieuThu,
                                int csNuocCu, int csNuocMoi, int nuocTieuThu,
                                int tienDien, int tienNuoc, int tongTien)
        {
            string sql = @"
                UPDATE DienNuoc
                SET    MaPhong      = @MaPhong,
                       Thang        = @Thang,
                       Nam          = @Nam,
                       ChiSoDienCu  = @ChiSoDienCu,
                       ChiSoDienMoi = @ChiSoDienMoi,
                       DienTieuThu  = @DienTieuThu,
                       ChiSoNuocCu  = @ChiSoNuocCu,
                       ChiSoNuocMoi = @ChiSoNuocMoi,
                       NuocTieuThu  = @NuocTieuThu,
                       TienDien     = @TienDien,
                       TienNuoc     = @TienNuoc,
                       TongTien     = @TongTien
                WHERE  MaPhieu = @MaPhieu";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaPhieu", maPhieu),
new SqlParameter("@MaPhong", maPhong),
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam),
                new SqlParameter("@ChiSoDienCu", csDienCu),
                new SqlParameter("@ChiSoDienMoi", csDienMoi),
                new SqlParameter("@DienTieuThu", dienTieuThu),
                new SqlParameter("@ChiSoNuocCu", csNuocCu),
                new SqlParameter("@ChiSoNuocMoi", csNuocMoi),
                new SqlParameter("@NuocTieuThu", nuocTieuThu),
                new SqlParameter("@TienDien", tienDien),
                new SqlParameter("@TienNuoc", tienNuoc),
                new SqlParameter("@TongTien", tongTien));
        }

        private void DeleteData(string maPhieu)
        {
            string sql = "DELETE FROM DienNuoc WHERE MaPhieu = @MaPhieu";
            _db.ExecuteNonQuery(sql, new SqlParameter("@MaPhieu", maPhieu));
        }

        private string GetCurrentMaPhieu()
        {
            if (dgvNhapdiennuoc.CurrentRow == null) return "";
            return GetCellValue(dgvNhapdiennuoc.CurrentRow, "MaPhieu");
        }

        private void cboKhuNha_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}