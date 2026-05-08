using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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

            // Wire up events thủ công vì Designer không tự kết nối button
            this.Load += Chuyenphong_Load;
            btnNew.Click += btnNew_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnClose.Click += btnClose_Click;
            txtSearch.KeyDown += txtSearch_KeyDown;
            dgvChuyenphong.SelectionChanged += dgvChuyenphong_SelectionChanged;
            cboKhuhientai.SelectedIndexChanged += cboKhuhientai_SelectedIndexChanged;
            cboKhumoi.SelectedIndexChanged += cboKhumoi_SelectedIndexChanged;
            txtMasinhvien.Leave += txtMasinhvien_Leave;
            txtMasinhvien.KeyDown += txtMasinhvien_KeyDown;
            txtNgaychuyen.KeyDown += txtNgaychuyen_KeyDown;
            txtLydochuyen.KeyDown += txtLydochuyen_KeyDown;
            txtGhichu.KeyDown += txtGhichu_KeyDown;

            // Tag các button để UIService.SetButtonsEnabled hoạt động đúng
            btnNew.Tag = "select";
            btnEdit.Tag = "select";
            btnDelete.Tag = "select";
            btnSave.Tag = "confirm";
            btnCancel.Tag = "confirm";
        }

        // ================================================================
        // SỰ KIỆN LOAD FORM
        // ================================================================
        private void Chuyenphong_Load(object sender, EventArgs e)
        {
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            UIService.SetGridStyle(dgvChuyenphong);

            LoadComboBoxes();
            LoadData();

            UIService.SetGridHeader(dgvChuyenphong,
                "Mã CP", "Mã SV", "Họ tên", "Phòng cũ", "Khu cũ",
                "Phòng mới", "Khu mới", "Ngày chuyển", "Lý do", "Trạng thái", "Ghi chú");
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
            txtHoten.ReadOnly = true;

            txtMasinhvien.Focus();
        }

        // ================================================================
        // NÚT SỬA
        // ================================================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvChuyenphong.CurrentRow == null) return;

            string trangThai = dgvChuyenphong.CurrentRow.Cells["TrangThai"].Value?.ToString() ?? "";
            if (trangThai == "Đã chuyển")
            {
                MessageBox.Show("Không thể sửa phiếu chuyển phòng đã hoàn tất!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _saveMode = SaveMode.Update;
            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);
            txtMachuyenphong.ReadOnly = true;
            txtHoten.ReadOnly = true;
            txtMasinhvien.Focus();
        }

        // ================================================================
        // NÚT XÓA
        // ================================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvChuyenphong.CurrentRow == null) return;
            if (!UIService.ConfirmDelete()) return;

            string trangThai = dgvChuyenphong.CurrentRow.Cells["TrangThai"].Value?.ToString() ?? "";
            if (trangThai == "Đã chuyển")
            {
                MessageBox.Show("Không thể xóa phiếu chuyển phòng đã hoàn tất!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DeleteData(GetCurrentID());
            LoadData();
        }

        // ================================================================
        // NÚT LƯU
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string maCP = txtMachuyenphong.Text.Trim();
            string maSV = txtMasinhvien.Text.Trim();
            string phongCu = cboPhonghientai.SelectedValue?.ToString() ?? "";
            string phongMoi = cboPhongmoi.SelectedValue?.ToString() ?? "";
            DateTime ngayChuyen = UIService.ParseDate(txtNgaychuyen.Text.Trim()).Value;
            string lyDo = txtLydochuyen.Text.Trim();
            string trangThai = cboTrangthai.SelectedItem?.ToString() ?? "";
            string ghiChu = txtGhichu.Text.Trim();

            if (_saveMode == SaveMode.Insert)
            {
                if (IDExists(maCP))
                {
                    MessageBox.Show("Mã chuyển phòng đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (phongCu == phongMoi)
                {
                    MessageBox.Show("Phòng mới phải khác phòng hiện tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboPhongmoi.Focus();
                    return;
                }
                if (!PhongConCho(phongMoi))
                {
                    MessageBox.Show("Phòng mới không còn chỗ trống!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboPhongmoi.Focus();
                    return;
                }
                InsertData(maCP, maSV, phongCu, phongMoi, ngayChuyen, lyDo, trangThai, ghiChu);
            }
            else
            {
                if (dgvChuyenphong.CurrentRow == null) return;

                string phongMoiCu = dgvChuyenphong.CurrentRow.Cells["PhongMoi"].Value?.ToString() ?? "";
                if (phongCu == phongMoi)
                {
                    MessageBox.Show("Phòng mới phải khác phòng hiện tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboPhongmoi.Focus();
                    return;
                }
                if (phongMoi != phongMoiCu && !PhongConCho(phongMoi))
                {
                    MessageBox.Show("Phòng mới không còn chỗ trống!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboPhongmoi.Focus();
                    return;
                }
                UpdateData(maCP, maSV, phongCu, phongMoi, ngayChuyen, lyDo, trangThai, ghiChu);
            }

            LoadData();
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
        }

        // ================================================================
        // NÚT HỦY
        // ================================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            BindData();
        }

        // ================================================================
        // NÚT ĐÓNG
        // ================================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ================================================================
        // TÌM KIẾM KHI ẤN ENTER
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
        // CHỌN DÒNG TRÊN LƯỚI
        // ================================================================
        private void dgvChuyenphong_SelectionChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void dgvChuyenphong_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // ================================================================
        // KHI CHỌN KHU HIỆN TẠI -> NẠP DANH SÁCH PHÒNG
        // ================================================================
        private void cboKhuhientai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhuhientai.SelectedValue == null) return;
            LoadPhong(cboPhonghientai, cboKhuhientai.SelectedValue.ToString());
        }

        // ================================================================
        // KHI CHỌN KHU MỚI -> NẠP DANH SÁCH PHÒNG
        // ================================================================
        private void cboKhumoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhumoi.SelectedValue == null) return;
            LoadPhong(cboPhongmoi, cboKhumoi.SelectedValue.ToString());
        }

        // ================================================================
        // KHI NHẬP MÃ SV XONG -> TỰ ĐIỀN HỌ TÊN VÀ PHÒNG ĐANG Ở
        // ================================================================
        private void txtMasinhvien_Leave(object sender, EventArgs e)
        {
            string maSV = txtMasinhvien.Text.Trim();
            if (string.IsNullOrEmpty(maSV)) return;

            object hoTen = _db.ExecuteScalar(
                "SELECT HoTen FROM SinhVien WHERE MaSV = @MaSV",
                new SqlParameter("@MaSV", maSV));

            if (hoTen == null || hoTen == DBNull.Value)
            {
                MessageBox.Show("Mã sinh viên không tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoten.Clear();
                return;
            }
            txtHoten.Text = hoTen.ToString();

            string sqlPhong = @"SELECT xp.MaPhong, p.MaKhu
                                FROM XepPhong xp
                                INNER JOIN Phong p ON xp.MaPhong = p.MaPhong
                                WHERE xp.MaSV = @MaSV AND xp.TrangThaiO = N'Đang ở'";
            DataTable dt = _db.ExecuteQuery(sqlPhong, new SqlParameter("@MaSV", maSV));
            if (dt.Rows.Count > 0)
            {
                string maKhu = dt.Rows[0]["MaKhu"].ToString();
                string maPhong = dt.Rows[0]["MaPhong"].ToString();

                cboKhuhientai.SelectedIndexChanged -= cboKhuhientai_SelectedIndexChanged;
                cboKhuhientai.SelectedValue = maKhu;
                cboKhuhientai.SelectedIndexChanged += cboKhuhientai_SelectedIndexChanged;

                LoadPhong(cboPhonghientai, maKhu);
                cboPhonghientai.SelectedValue = maPhong;
            }
        }

        // ================================================================
        // ĐIỀU HƯỚNG BÀN PHÍM
        // ================================================================
        private void txtMasinhvien_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtNgaychuyen_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtLydochuyen_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtGhichu_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);

        // Các event rỗng do Designer tự thêm (bắt buộc phải có)
        private void lblTitle_Click_1(object sender, EventArgs e) { }
        private void tblLeft_Paint(object sender, PaintEventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }

        // ================================================================
        // VALIDATE DỮ LIỆU ĐẦU VÀO
        // ================================================================
        private bool ValidateInput()
        {
            if (!UIService.Require(txtMachuyenphong, "Yêu cầu phải có mã chuyển phòng!")) return false;
            if (!UIService.Require(txtMasinhvien, "Yêu cầu phải nhập mã sinh viên!")) return false;
            if (!UIService.Require(cboKhuhientai, "Yêu cầu phải chọn khu hiện tại!")) return false;
            if (!UIService.Require(cboPhonghientai, "Yêu cầu phải chọn phòng hiện tại!")) return false;
            if (!UIService.Require(cboKhumoi, "Yêu cầu phải chọn khu mới!")) return false;
            if (!UIService.Require(cboPhongmoi, "Yêu cầu phải chọn phòng mới!")) return false;
            if (!UIService.Require(txtNgaychuyen, "Yêu cầu phải nhập ngày chuyển!")) return false;
            if (!UIService.Require(cboTrangthai, "Yêu cầu phải chọn trạng thái!")) return false;

            if (UIService.ParseDate(txtNgaychuyen.Text.Trim()) == null)
            {
                MessageBox.Show("Ngày chuyển không đúng định dạng dd/MM/yyyy!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaychuyen.Focus();
                return false;
            }
            return true;
        }

        // ================================================================
        // NẠP COMBOBOX KHU VÀ TRẠNG THÁI
        // ================================================================
        private void LoadComboBoxes()
        {
            string sqlKhu = "SELECT MaKhu, TenKhu FROM KhuNha WHERE TrangThai = N'Đang sử dụng' ORDER BY TenKhu";
            DataTable dtKhu = _db.ExecuteQuery(sqlKhu);

            cboKhuhientai.DataSource = dtKhu;
            cboKhuhientai.DisplayMember = "TenKhu";
            cboKhuhientai.ValueMember = "MaKhu";
            cboKhuhientai.SelectedIndex = -1;

            cboKhumoi.DataSource = dtKhu.Copy();
            cboKhumoi.DisplayMember = "TenKhu";
            cboKhumoi.ValueMember = "MaKhu";
            cboKhumoi.SelectedIndex = -1;

            cboTrangthai.Items.Clear();
            cboTrangthai.Items.AddRange(new object[] { "Chờ xử lý", "Đã chuyển", "Từ chối" });
            cboTrangthai.SelectedIndex = -1;
        }

        // ================================================================
        // NẠP PHÒNG THEO KHU
        // ================================================================
        private void LoadPhong(ComboBox cbo, string maKhu)
        {
            string sql = @"SELECT MaPhong, SoPhong + ' (' + TrangThai + ')' AS TenPhong
                           FROM Phong WHERE MaKhu = @MaKhu ORDER BY SoPhong";
            DataTable dt = _db.ExecuteQuery(sql, new SqlParameter("@MaKhu", maKhu));
            cbo.DataSource = dt;
            cbo.DisplayMember = "TenPhong";
            cbo.ValueMember = "MaPhong";
            cbo.SelectedIndex = -1;
        }

        // ================================================================
        // TẢI DỮ LIỆU LÊN LƯỚI
        // ================================================================
        private void LoadData()
        {
            dgvChuyenphong.DataSource = SearchData(txtSearch.Text.Trim());
        }

        private DataTable SearchData(string keyword = "")
        {
            string sql = @"SELECT
                               cp.MaChuyenPhong,
                               cp.MaSV,
                               sv.HoTen,
                               cp.PhongCu,
                               khu_cu.TenKhu  AS KhuCu,
                               cp.PhongMoi,
                               khu_moi.TenKhu AS KhuMoi,
                               cp.NgayChuyen,
                               cp.LyDo,
                               cp.TrangThai,
                               cp.GhiChu
                           FROM ChuyenPhong cp
                           INNER JOIN SinhVien sv     ON cp.MaSV     = sv.MaSV
                           LEFT  JOIN Phong   p_cu    ON cp.PhongCu  = p_cu.MaPhong
                           LEFT  JOIN KhuNha  khu_cu  ON p_cu.MaKhu  = khu_cu.MaKhu
                           LEFT  JOIN Phong   p_moi   ON cp.PhongMoi = p_moi.MaPhong
                           LEFT  JOIN KhuNha  khu_moi ON p_moi.MaKhu = khu_moi.MaKhu
                           WHERE (@Keyword = ''
                               OR cp.MaChuyenPhong LIKE @Keyword
                               OR sv.HoTen         LIKE @Keyword
                               OR cp.MaSV          LIKE @Keyword)
                           ORDER BY cp.NgayChuyen DESC";

            return _db.ExecuteQuery(sql, new SqlParameter("@Keyword", "%" + keyword + "%"));
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

            var row = dgvChuyenphong.CurrentRow;
            txtMachuyenphong.Text = row.Cells["MaChuyenPhong"].Value?.ToString() ?? "";
            txtMasinhvien.Text = row.Cells["MaSV"].Value?.ToString() ?? "";
            txtHoten.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            txtNgaychuyen.Text = UIService.FormatDate(row.Cells["NgayChuyen"].Value);
            txtLydochuyen.Text = row.Cells["LyDo"].Value?.ToString() ?? "";
            txtGhichu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";

            // Khu + phòng cũ
            string maPhongCu = row.Cells["PhongCu"].Value?.ToString() ?? "";
            string maKhuCu = GetMaKhuByPhong(maPhongCu);
            if (!string.IsNullOrEmpty(maKhuCu))
            {
                cboKhuhientai.SelectedIndexChanged -= cboKhuhientai_SelectedIndexChanged;
                cboKhuhientai.SelectedValue = maKhuCu;
                cboKhuhientai.SelectedIndexChanged += cboKhuhientai_SelectedIndexChanged;
                LoadPhong(cboPhonghientai, maKhuCu);
                cboPhonghientai.SelectedValue = maPhongCu;
            }

            // Khu + phòng mới
            string maPhongMoi = row.Cells["PhongMoi"].Value?.ToString() ?? "";
            string maKhuMoi = GetMaKhuByPhong(maPhongMoi);
            if (!string.IsNullOrEmpty(maKhuMoi))
            {
                cboKhumoi.SelectedIndexChanged -= cboKhumoi_SelectedIndexChanged;
                cboKhumoi.SelectedValue = maKhuMoi;
                cboKhumoi.SelectedIndexChanged += cboKhumoi_SelectedIndexChanged;
                LoadPhong(cboPhongmoi, maKhuMoi);
                cboPhongmoi.SelectedValue = maPhongMoi;
            }

            // Trạng thái
            string tt = row.Cells["TrangThai"].Value?.ToString() ?? "";
            cboTrangthai.SelectedIndex = cboTrangthai.Items.IndexOf(tt);
        }

        // ================================================================
        // CÁC HÀM THAO TÁC CSDL
        // ================================================================
        private void InsertData(string maCP, string maSV, string phongCu, string phongMoi,
                                DateTime ngayChuyen, string lyDo, string trangThai, string ghiChu)
        {
            string sql = @"INSERT INTO ChuyenPhong
                               (MaChuyenPhong, MaSV, PhongCu, PhongMoi, NgayChuyen, LyDo, TrangThai, GhiChu)
                           VALUES
                               (@MaCP, @MaSV, @PhongCu, @PhongMoi, @NgayChuyen, @LyDo, @TrangThai, @GhiChu)";
            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaCP", maCP),
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@PhongCu", phongCu),
                new SqlParameter("@PhongMoi", phongMoi),
                new SqlParameter("@NgayChuyen", ngayChuyen),
                new SqlParameter("@LyDo", lyDo),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", ghiChu));
        }

        private void UpdateData(string maCP, string maSV, string phongCu, string phongMoi,
                                DateTime ngayChuyen, string lyDo, string trangThai, string ghiChu)
        {
            string sql = @"UPDATE ChuyenPhong
                           SET MaSV       = @MaSV,
                               PhongCu    = @PhongCu,
                               PhongMoi   = @PhongMoi,
                               NgayChuyen = @NgayChuyen,
                               LyDo       = @LyDo,
                               TrangThai  = @TrangThai,
                               GhiChu     = @GhiChu
                           WHERE MaChuyenPhong = @MaCP";
            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaCP", maCP),
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@PhongCu", phongCu),
                new SqlParameter("@PhongMoi", phongMoi),
                new SqlParameter("@NgayChuyen", ngayChuyen),
                new SqlParameter("@LyDo", lyDo),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", ghiChu));
        }

        private void DeleteData(string maCP)
        {
            _db.ExecuteNonQuery(
                "DELETE FROM ChuyenPhong WHERE MaChuyenPhong = @MaCP",
                new SqlParameter("@MaCP", maCP));
        }

        // ================================================================
        // CÁC HÀM HỖ TRỢ
        // ================================================================
        private string GetCurrentID()
        {
            if (dgvChuyenphong.CurrentRow == null) return "";
            return dgvChuyenphong.CurrentRow.Cells["MaChuyenPhong"].Value?.ToString() ?? "";
        }

        private bool IDExists(string maCP)
        {
            int count = Convert.ToInt32(_db.ExecuteScalar(
                "SELECT COUNT(*) FROM ChuyenPhong WHERE MaChuyenPhong = @MaCP",
                new SqlParameter("@MaCP", maCP)));
            return count > 0;
        }

        private bool PhongConCho(string maPhong)
        {
            object result = _db.ExecuteScalar(
                @"SELECT (SucChua - SoNguoiHienTai) FROM Phong
                  WHERE MaPhong = @MaPhong AND TrangThai = N'Còn chỗ'",
                new SqlParameter("@MaPhong", maPhong));
            if (result == null || result == DBNull.Value) return false;
            return Convert.ToInt32(result) > 0;
        }

        private string GetMaKhuByPhong(string maPhong)
        {
            if (string.IsNullOrEmpty(maPhong)) return "";
            object result = _db.ExecuteScalar(
                "SELECT MaKhu FROM Phong WHERE MaPhong = @MaPhong",
                new SqlParameter("@MaPhong", maPhong));
            return result?.ToString() ?? "";
        }

        private string GenerateNewID()
        {
            object result = _db.ExecuteScalar("SELECT MAX(MaChuyenPhong) FROM ChuyenPhong");
            if (result == null || result == DBNull.Value) return "CP001";

            string lastID = result.ToString();
            string prefix = new string(lastID.TakeWhile(c => !char.IsDigit(c)).ToArray());
            string numStr = new string(lastID.SkipWhile(c => !char.IsDigit(c)).ToArray());
            int num = int.Parse(numStr) + 1;
            return prefix + num.ToString("D" + numStr.Length);
        }
    }
}