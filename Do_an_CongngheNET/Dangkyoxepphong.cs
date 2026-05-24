using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using QLKTX;

namespace Do_an_CongngheNET
{
    public partial class Dangkyoxepphong : Form
    {
        // ----------------------------------------------------------------
        // KHAI BÁO BIẾN
        // ----------------------------------------------------------------
        private readonly DBService _db;
        private SaveMode _saveMode = SaveMode.Insert;

        // ----------------------------------------------------------------
        // CONSTRUCTOR
        // ----------------------------------------------------------------
        public Dangkyoxepphong()
        {
            InitializeComponent();
            _db = new DBService();
            //gắn dự kiện load cho form
            this.Load += Dangkyoxepphong_Load;
        }

        // ================================================================
        // LOAD FORM
        // ================================================================
        private void Dangkyoxepphong_Load(object sender, EventArgs e)
        {
            // [SỬA LỖI 1] Thiết lập grid TRƯỚC khi nạp dữ liệu
            UIService.SetGridStyle(dgvDangkyoxepphong);

            // Trạng thái ban đầu: input tắt, nút confirm (Ghi/Hủy) tắt
            UIService.SetInputsEnabled(tlpLeft1, false);
            UIService.SetInputsEnabled(tlpLeft3, false);
            // [SỬA LỖI 2] Chỉ tắt/bật button trên tlpButtons thay vì toàn form
            SetPageButtons(false);

            // Nạp combobox tĩnh
            LoadCboHocky();
            LoadCboLoaiphong();
            LoadCboTrangthai();
            LoadCboKhunha();

            // Điều hướng bàn phím
            txtMaSV.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtNamhoc.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtNgayvaoo.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtGhichu.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboHocky.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboLoaiphong.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboTrangthai.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboKhunha.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboPhong.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboGiuong.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);

            // Sự kiện nghiệp vụ
            txtMaSV.Leave += txtMaSV_Leave;
            cboKhunha.SelectedIndexChanged += cboKhunha_SelectedIndexChanged;
            cboPhong.SelectedIndexChanged += cboPhong_SelectedIndexChanged;
            txtTimkiem.TextChanged += txtTimkiem_TextChanged;
            dgvDangkyoxepphong.SelectionChanged += dgvDangkyoxepphong_SelectionChanged;

            // Sự kiện nút
            btnNew.Click += btnNew_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;

            // [SỬA LỖI 3] Tắt SelectionChanged khi nạp dữ liệu để tránh bind rỗng
            dgvDangkyoxepphong.SelectionChanged -= dgvDangkyoxepphong_SelectionChanged;
            LoadData();
            dgvDangkyoxepphong.SelectionChanged += dgvDangkyoxepphong_SelectionChanged;

            // [SỬA LỖI 4] SetGridHeader SAU LoadData() để chắc chắn cột đã sinh
            UIService.SetGridHeader(dgvDangkyoxepphong,
                "Mã ĐK", "Mã SV", "Họ tên", "Ngày ĐK",
                "Học kỳ", "Năm học", "Loại phòng", "Trạng thái", "Ghi chú");

            // Bind dòng đầu tiên nếu có
            if (dgvDangkyoxepphong.Rows.Count > 0)
                dgvDangkyoxepphong.CurrentCell = dgvDangkyoxepphong.Rows[0].Cells[0];
            BindData();
        }

        // ================================================================
        // [SỬA LỖI 2] HELPER ĐIỀU KHIỂN NÚT — chỉ tác động tlpButtons
        // Thay thế UIService.SetButtonsEnabled(this, ...) tránh duyệt toàn form
        // ================================================================
        private void SetPageButtons(bool editMode)
        {
            // select buttons: bật khi KHÔNG edit
            btnNew.Enabled = !editMode;
            btnEdit.Enabled = !editMode;
            btnDelete.Enabled = !editMode;
            btnRefresh.Enabled = !editMode;
            btnClose.Enabled = !editMode;

            // confirm buttons: bật khi ĐANG edit
            btnSave.Enabled = editMode;
            btnCancel.Enabled = editMode;
        }

        // ================================================================
        // NẠP COMBOBOX
        // ================================================================
        private void LoadCboKhunha()
        {
            cboKhunha.SelectedIndexChanged -= cboKhunha_SelectedIndexChanged;

            DataTable dt = _db.ExecuteQuery(
                "SELECT MaKhu, TenKhu FROM KhuNha WHERE TrangThai = N'Đang sử dụng' ORDER BY TenKhu");

            DataRow blank = dt.NewRow();
            blank["MaKhu"] = DBNull.Value;
            blank["TenKhu"] = "-- Chọn khu nhà --";
            dt.Rows.InsertAt(blank, 0);

            cboKhunha.DataSource = dt;
            cboKhunha.DisplayMember = "TenKhu";
            cboKhunha.ValueMember = "MaKhu";
            cboKhunha.SelectedIndex = 0;

            cboKhunha.SelectedIndexChanged += cboKhunha_SelectedIndexChanged;
        }

        private void LoadCboHocky()
        {
            cboHocky.Items.Clear();
            cboHocky.Items.Add("-- Chọn học kỳ --");
            cboHocky.Items.Add("Học kỳ 1");
            cboHocky.Items.Add("Học kỳ 2");
            cboHocky.Items.Add("Học kỳ hè");
            cboHocky.SelectedIndex = 0;
        }

        private void LoadCboLoaiphong()
        {
            cboLoaiphong.Items.Clear();
            cboLoaiphong.Items.Add("-- Chọn loại phòng --");
            cboLoaiphong.Items.Add("Phòng 4 người");
            cboLoaiphong.Items.Add("Phòng 6 người");
            cboLoaiphong.SelectedIndex = 0;
        }

        private void LoadCboTrangthai()
        {
            cboTrangthai.Items.Clear();
            cboTrangthai.Items.Add("-- Chọn trạng thái --");
            cboTrangthai.Items.Add("Chờ duyệt");
            cboTrangthai.Items.Add("Đã duyệt");
            cboTrangthai.Items.Add("Từ chối");
            cboTrangthai.SelectedIndex = 0;
        }

        // ================================================================
        // SỰ KIỆN BUTTON
        // ================================================================
        private void btnNew_Click(object sender, EventArgs e)
        {
            _saveMode = SaveMode.Insert;

            UIService.ClearInputs(tlpLeft1);
            UIService.ClearInputs(tlpLeft3);
            ResetCombos();

            txtMadangky.Text = GenerateMaDangKy();
            txtNgaydangky.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtMadangky.Enabled = false;
            txtNgaydangky.ReadOnly = true;

            UIService.SetInputsEnabled(tlpLeft1, true);
            UIService.SetInputsEnabled(tlpLeft3, true);
            SetPageButtons(true);

            LockStudentFields();
            txtMaSV.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDangkyoxepphong.CurrentRow == null) return;

            _saveMode = SaveMode.Update;

            UIService.SetInputsEnabled(tlpLeft1, true);
            UIService.SetInputsEnabled(tlpLeft3, true);
            SetPageButtons(true);

            // Không cho sửa mã SV và mã đăng ký
            LockStudentFields();
            txtMaSV.Enabled = false;
            txtMadangky.Enabled = false;
            txtNgaydangky.ReadOnly = true;

            cboHocky.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDangkyoxepphong.CurrentRow == null) return;
            if (!UIService.ConfirmDelete()) return;

            string maDK = GetCurrentID();

            if (IsUsed(maDK))
            {
                MessageBox.Show(
                    "Không thể xóa vì sinh viên đang ở phòng thuộc đăng ký này!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DeleteData(maDK);
            LoadData();
            BindData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string maDK = txtMadangky.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string hocKy = cboHocky.Text;
            string namHoc = txtNamhoc.Text.Trim();
            string loaiPhong = cboLoaiphong.Text;
            string trangThai = cboTrangthai.Text;
            string ghiChu = txtGhichu.Text.Trim();

            if (_saveMode == SaveMode.Insert)
            {
                DataTable dtSV = _db.ExecuteQuery(
                    "SELECT MaSV FROM SinhVien WHERE MaSV = @MaSV",
                    new SqlParameter("@MaSV", maSV));

                if (dtSV.Rows.Count == 0)
                {
                    MessageBox.Show("Mã SV không tồn tại trong hệ thống!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSV.Focus();
                    return;
                }

                if (HasActiveRegistration(maSV))
                {
                    MessageBox.Show(
                        "Sinh viên này đã có đăng ký đang chờ duyệt hoặc đã được duyệt!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                InsertData(maDK, maSV, hocKy, namHoc, loaiPhong, trangThai, ghiChu);
                InsertXepPhong(maDK, maSV);
            }
            else
            {
                if (dgvDangkyoxepphong.CurrentRow == null) return;
                UpdateData(maDK, hocKy, namHoc, loaiPhong, trangThai, ghiChu);
            }

            // [SỬA LỖI 5] Tắt SelectionChanged khi reload để tránh bind nháy
            dgvDangkyoxepphong.SelectionChanged -= dgvDangkyoxepphong_SelectionChanged;
            LoadData();
            dgvDangkyoxepphong.SelectionChanged += dgvDangkyoxepphong_SelectionChanged;

            UIService.SetInputsEnabled(tlpLeft1, false);
            UIService.SetInputsEnabled(tlpLeft3, false);
            SetPageButtons(false);

            // Bind lại dòng đang chọn sau khi lưu
            BindData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UIService.SetInputsEnabled(tlpLeft1, false);
            UIService.SetInputsEnabled(tlpLeft3, false);
            SetPageButtons(false);
            BindData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtTimkiem.Clear();
            UIService.ClearInputs(tlpLeft1);
            UIService.ClearInputs(tlpLeft3);
            ResetCombos();

            dgvDangkyoxepphong.SelectionChanged -= dgvDangkyoxepphong_SelectionChanged;
            LoadData();
            dgvDangkyoxepphong.SelectionChanged += dgvDangkyoxepphong_SelectionChanged;

            if (dgvDangkyoxepphong.Rows.Count > 0)
                dgvDangkyoxepphong.CurrentCell = dgvDangkyoxepphong.Rows[0].Cells[0];
            BindData();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        // ================================================================
        // TÌM KIẾM
        // ================================================================
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            dgvDangkyoxepphong.SelectionChanged -= dgvDangkyoxepphong_SelectionChanged;
            LoadData();
            dgvDangkyoxepphong.SelectionChanged += dgvDangkyoxepphong_SelectionChanged;
            BindData();
        }

        // ================================================================
        // CHỌN DÒNG TRÊN LƯỚI
        // ================================================================
        private void dgvDangkyoxepphong_SelectionChanged(object sender, EventArgs e)
        {
            BindData();
        }

        // ================================================================
        // SỰ KIỆN CONTROL
        // ================================================================
        private void txtMaSV_Leave(object sender, EventArgs e)
        {
            if (_saveMode == SaveMode.Insert)
                FillStudentInfo(txtMaSV.Text.Trim(), showWarning: true);
        }

        private void cboKhunha_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPhong.SelectedIndexChanged -= cboPhong_SelectedIndexChanged;

            cboPhong.DataSource = null;
            cboPhong.Items.Clear();
            cboGiuong.Items.Clear();

            object val = cboKhunha.SelectedValue;
            if (val == null || val == DBNull.Value || string.IsNullOrEmpty(val.ToString()))
            {
                cboPhong.SelectedIndexChanged += cboPhong_SelectedIndexChanged;
                return;
            }

            string maKhu = val.ToString();

            DataTable dt = _db.ExecuteQuery(
                @"SELECT MaPhong, SoPhong FROM Phong
                  WHERE MaKhu = @MaKhu AND TrangThai IN (N'Còn chỗ', N'Trống')
                  ORDER BY SoPhong",
                new SqlParameter("@MaKhu", maKhu));

            cboPhong.DataSource = dt;
            cboPhong.DisplayMember = "SoPhong";
            cboPhong.ValueMember = "MaPhong";
            cboPhong.SelectedIndex = -1;

            cboPhong.SelectedIndexChanged += cboPhong_SelectedIndexChanged;
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboGiuong.Items.Clear();

            object val = cboPhong.SelectedValue;
            if (val == null || val == DBNull.Value || string.IsNullOrEmpty(val.ToString())) return;

            string maPhong = val.ToString();

            DataTable dtDaO = _db.ExecuteQuery(
                @"SELECT Giuong FROM XepPhong
                  WHERE MaPhong = @MaPhong AND TrangThaiO = N'Đang ở'",
                new SqlParameter("@MaPhong", maPhong));

            DataTable dtPhong = _db.ExecuteQuery(
                "SELECT SucChua FROM Phong WHERE MaPhong = @MaPhong",
                new SqlParameter("@MaPhong", maPhong));

            int sucChua = (dtPhong.Rows.Count > 0)
                ? Convert.ToInt32(dtPhong.Rows[0]["SucChua"])
                : 4;

            List<string> daDung = dtDaO.AsEnumerable()
                .Select(r => r["Giuong"].ToString()).ToList();

            for (int i = 1; i <= sucChua; i++)
            {
                string giuong = $"Giường {i}";
                if (!daDung.Contains(giuong))
                    cboGiuong.Items.Add(giuong);
            }

            if (cboGiuong.Items.Count > 0)
                cboGiuong.SelectedIndex = 0;
        }

        // ================================================================
        // VALIDATE INPUT
        // ================================================================
        private bool ValidateInput()
        {
            if (!UIService.Require(txtMaSV, "Vui lòng nhập Mã SV!")) return false;
            if (!UIService.MaxLength(txtMaSV, 20, "Mã SV không được quá 20 ký tự!")) return false;

            if (cboHocky.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Học kỳ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboHocky.Focus();
                return false;
            }

            if (!UIService.Require(txtNamhoc, "Vui lòng nhập Năm học!")) return false;
            if (!UIService.MaxLength(txtNamhoc, 20, "Năm học không được quá 20 ký tự!")) return false;

            if (cboLoaiphong.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Loại phòng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiphong.Focus();
                return false;
            }

            if (cboTrangthai.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Trạng thái!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangthai.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtNgayvaoo.Text))
            {
                if (!DateTime.TryParseExact(txtNgayvaoo.Text, "dd/MM/yyyy",
                    null, System.Globalization.DateTimeStyles.None, out _))
                {
                    MessageBox.Show("Ngày vào ở không đúng định dạng dd/MM/yyyy!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayvaoo.Focus();
                    return false;
                }
            }

            return true;
        }

        // ================================================================
        // KIỂM TRA SV ĐANG Ở PHÒNG THUỘC ĐĂNG KÝ (dùng khi xóa)
        // ================================================================
        private bool IsUsed(string maDangKy)
        {
            int count = Convert.ToInt32(_db.ExecuteScalar(
                @"SELECT COUNT(*) FROM XepPhong
                  WHERE MaDangKy = @MaDangKy AND TrangThaiO = N'Đang ở'",
                new SqlParameter("@MaDangKy", maDangKy)));
            return count > 0;
        }

        // ================================================================
        // KIỂM TRA SV ĐÃ CÓ ĐĂNG KÝ CÒN HIỆU LỰC (dùng khi thêm mới)
        // ================================================================
        private bool HasActiveRegistration(string maSV)
        {
            int count = Convert.ToInt32(_db.ExecuteScalar(
                @"SELECT COUNT(*) FROM DangKy
                  WHERE MaSV = @MaSV
                    AND TrangThaiHoSo IN (N'Chờ duyệt', N'Đã duyệt')",
                new SqlParameter("@MaSV", maSV)));
            return count > 0;
        }

        // ================================================================
        // TẢI DỮ LIỆU LÊN LƯỚI
        // [SỬA LỖI 6] Dùng BeginEdit/EndEdit để tránh mất selection
        // ================================================================
        private void LoadData()
        {
            string keyword = txtTimkiem.Text.Trim();
            DataTable dt = SearchData(keyword);

            // [SỬA LỖI 7] Gán AutoGenerateColumns = true trước khi set DataSource
            dgvDangkyoxepphong.AutoGenerateColumns = true;
            dgvDangkyoxepphong.DataSource = dt;

            // Format cột ngày sau khi DataSource đã được gán
            if (dgvDangkyoxepphong.Columns.Contains("NgayDangKy"))
                dgvDangkyoxepphong.Columns["NgayDangKy"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // [SỬA LỖI 8] Cập nhật lại header mỗi lần load (cột tự sinh lại)
            UIService.SetGridHeader(dgvDangkyoxepphong,
                "Mã ĐK", "Mã SV", "Họ tên", "Ngày ĐK",
                "Học kỳ", "Năm học", "Loại phòng", "Trạng thái", "Ghi chú");
        }

        // ================================================================
        // HIỂN THỊ DỮ LIỆU LÊN FORM KHI CHỌN DÒNG
        // ================================================================
        private void BindData()
        {
            if (dgvDangkyoxepphong.CurrentRow == null)
            {
                UIService.ClearInputs(tlpLeft1);
                UIService.ClearInputs(tlpLeft3);
                ResetCombos();
                return;
            }

            var row = dgvDangkyoxepphong.CurrentRow;

            txtMadangky.Text = row.Cells["MaDangKy"].Value?.ToString() ?? "";
            txtMaSV.Text = row.Cells["MaSV"].Value?.ToString() ?? "";
            txtHoten.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            txtNamhoc.Text = row.Cells["NamHoc"].Value?.ToString() ?? "";
            txtGhichu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";

            object ngayDK = row.Cells["NgayDangKy"].Value;
            txtNgaydangky.Text = (ngayDK != null && ngayDK != DBNull.Value)
                ? Convert.ToDateTime(ngayDK).ToString("dd/MM/yyyy")
                : "";

            SetComboByText(cboHocky, row.Cells["HocKy"].Value?.ToString() ?? "");
            SetComboByText(cboLoaiphong, row.Cells["LoaiPhongMuon"].Value?.ToString() ?? "");
            SetComboByText(cboTrangthai, row.Cells["TrangThaiHoSo"].Value?.ToString() ?? "");

            FillStudentInfo(txtMaSV.Text.Trim(), showWarning: false);
            FillRoomInfo(txtMadangky.Text.Trim());
        }

        // ================================================================
        // TRUY VẤN DỮ LIỆU
        // ================================================================
        private DataTable SearchData(string keyword = "")
        {
            return _db.ExecuteQuery(
                @"SELECT dk.MaDangKy, dk.MaSV, sv.HoTen, dk.NgayDangKy,
                         dk.HocKy, dk.NamHoc, dk.LoaiPhongMuon,
                         dk.TrangThaiHoSo, dk.GhiChu
                  FROM DangKy dk
                  INNER JOIN SinhVien sv ON dk.MaSV = sv.MaSV
                  WHERE (@Keyword = N'' OR dk.MaDangKy LIKE @Keyword
                                       OR dk.MaSV     LIKE @Keyword
                                       OR sv.HoTen    LIKE @Keyword)
                  ORDER BY dk.MaDangKy",
                new SqlParameter("@Keyword", "%" + keyword.Trim() + "%"));
        }

        // ================================================================
        // THÊM ĐĂNG KÝ
        // ================================================================
        private void InsertData(string maDK, string maSV, string hocKy,
            string namHoc, string loaiPhong, string trangThai, string ghiChu)
        {
            _db.ExecuteNonQuery(
                @"INSERT INTO DangKy
                      (MaDangKy, MaSV, NgayDangKy, HocKy, NamHoc,
                       LoaiPhongMuon, DoiTuongUuTien, TrangThaiHoSo, GhiChu)
                  VALUES
                      (@MaDK, @MaSV, @NgayDK, @HocKy, @NamHoc,
                       @LoaiPhong, N'Bình thường', @TrangThai, @GhiChu)",
                new SqlParameter("@MaDK", maDK),
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@NgayDK", DateTime.Now),
                new SqlParameter("@HocKy", hocKy),
                new SqlParameter("@NamHoc", namHoc),
                new SqlParameter("@LoaiPhong", loaiPhong),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", ghiChu));
        }

        private void InsertXepPhong(string maDK, string maSV)
        {
            if (cboPhong.SelectedValue == null || cboPhong.SelectedValue == DBNull.Value) return;
            if (cboGiuong.SelectedIndex < 0) return;

            string maPhong = cboPhong.SelectedValue.ToString();
            string giuong = cboGiuong.Text;

            DateTime ngayVaoO = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(txtNgayvaoo.Text))
                DateTime.TryParseExact(txtNgayvaoo.Text, "dd/MM/yyyy",
                    null, System.Globalization.DateTimeStyles.None, out ngayVaoO);

            string maXP = GenerateMaXepPhong();

            _db.ExecuteNonQuery(
                @"INSERT INTO XepPhong
                      (MaXepPhong, MaDangKy, MaSV, MaPhong, Giuong, NgayVaoO, TrangThaiO, GhiChu)
                  VALUES
                      (@MaXP, @MaDK, @MaSV, @MaPhong, @Giuong, @NgayVaoO, N'Đang ở', N'')",
                new SqlParameter("@MaXP", maXP),
                new SqlParameter("@MaDK", maDK),
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@MaPhong", maPhong),
                new SqlParameter("@Giuong", giuong),
                new SqlParameter("@NgayVaoO", ngayVaoO));
        }

        // ================================================================
        // SỬA ĐĂNG KÝ
        // ================================================================
        private void UpdateData(string maDK, string hocKy, string namHoc,
            string loaiPhong, string trangThai, string ghiChu)
        {
            _db.ExecuteNonQuery(
                @"UPDATE DangKy
                  SET HocKy         = @HocKy,
                      NamHoc        = @NamHoc,
                      LoaiPhongMuon = @LoaiPhong,
                      TrangThaiHoSo = @TrangThai,
                      GhiChu        = @GhiChu
                  WHERE MaDangKy = @MaDK",
                new SqlParameter("@MaDK", maDK),
                new SqlParameter("@HocKy", hocKy),
                new SqlParameter("@NamHoc", namHoc),
                new SqlParameter("@LoaiPhong", loaiPhong),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", ghiChu));
        }

        // ================================================================
        // XÓA ĐĂNG KÝ
        // ================================================================
        private void DeleteData(string maDK)
        {
            _db.ExecuteNonQuery(
                "DELETE FROM XepPhong WHERE MaDangKy = @MaDK",
                new SqlParameter("@MaDK", maDK));

            _db.ExecuteNonQuery(
                "DELETE FROM DangKy WHERE MaDangKy = @MaDK",
                new SqlParameter("@MaDK", maDK));
        }

        // ================================================================
        // LẤY MÃ ĐĂNG KÝ ĐANG CHỌN
        // ================================================================
        private string GetCurrentID()
        {
            if (dgvDangkyoxepphong.CurrentRow == null) return "";
            return dgvDangkyoxepphong.CurrentRow.Cells["MaDangKy"].Value?.ToString() ?? "";
        }

        // ================================================================
        // SINH MÃ TỰ ĐỘNG
        // ================================================================
        private string GenerateMaDangKy()
        {
            object obj = _db.ExecuteScalar(
                @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaDangKy,3,LEN(MaDangKy)) AS INT)),0)+1
                  FROM DangKy
                  WHERE MaDangKy LIKE 'DK%'
                    AND ISNUMERIC(SUBSTRING(MaDangKy,3,LEN(MaDangKy)))=1");
            int next = (obj != null) ? Convert.ToInt32(obj) : 1;
            return "DK" + next.ToString("D3");
        }

        private string GenerateMaXepPhong()
        {
            object obj = _db.ExecuteScalar(
                @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaXepPhong,3,LEN(MaXepPhong)) AS INT)),0)+1
                  FROM XepPhong
                  WHERE MaXepPhong LIKE 'XP%'
                    AND ISNUMERIC(SUBSTRING(MaXepPhong,3,LEN(MaXepPhong)))=1");
            int next = (obj != null) ? Convert.ToInt32(obj) : 1;
            return "XP" + next.ToString("D3");
        }

        // ================================================================
        // HELPER: điền thông tin SV theo mã
        // ================================================================
        private void FillStudentInfo(string maSV, bool showWarning)
        {
            if (string.IsNullOrEmpty(maSV)) return;

            DataTable dt = _db.ExecuteQuery(
                "SELECT HoTen, GioiTinh, Lop, Khoa, SDT FROM SinhVien WHERE MaSV = @MaSV",
                new SqlParameter("@MaSV", maSV));

            if (dt.Rows.Count > 0)
            {
                txtHoten.Text = dt.Rows[0]["HoTen"].ToString();
                cboGioitinh.Text = dt.Rows[0]["GioiTinh"].ToString();
                txtLop.Text = dt.Rows[0]["Lop"].ToString();
                txtKhoa.Text = dt.Rows[0]["Khoa"].ToString();
                txtSDT.Text = dt.Rows[0]["SDT"].ToString();
            }
            else if (showWarning)
            {
                MessageBox.Show("Không tìm thấy sinh viên với mã này!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
            }
        }

        // ================================================================
        // HELPER: điền thông tin xếp phòng của đăng ký
        // ================================================================
        private void FillRoomInfo(string maDangKy)
        {
            if (string.IsNullOrEmpty(maDangKy)) return;

            DataTable dtXP = _db.ExecuteQuery(
                @"SELECT xp.MaPhong, p.MaKhu, xp.Giuong, xp.NgayVaoO
                  FROM XepPhong xp
                  INNER JOIN Phong p ON xp.MaPhong = p.MaPhong
                  WHERE xp.MaDangKy = @MaDangKy",
                new SqlParameter("@MaDangKy", maDangKy));

            if (dtXP.Rows.Count > 0)
            {
                cboPhong.SelectedIndexChanged -= cboPhong_SelectedIndexChanged;

                try { cboKhunha.SelectedValue = dtXP.Rows[0]["MaKhu"]; } catch { }
                try { cboPhong.SelectedValue = dtXP.Rows[0]["MaPhong"]; } catch { }

                cboPhong.SelectedIndexChanged += cboPhong_SelectedIndexChanged;

                SetComboByText(cboGiuong, dtXP.Rows[0]["Giuong"].ToString());

                object ngayVao = dtXP.Rows[0]["NgayVaoO"];
                txtNgayvaoo.Text = (ngayVao != null && ngayVao != DBNull.Value)
                    ? Convert.ToDateTime(ngayVao).ToString("dd/MM/yyyy")
                    : "";
            }
            else
            {
                cboKhunha.SelectedIndex = 0;
                cboPhong.Items.Clear();
                cboGiuong.Items.Clear();
                txtNgayvaoo.Text = "";
            }
        }

        // ================================================================
        // HELPER: khoá các trường thông tin SV (hệ thống tự điền)
        // ================================================================
        private void LockStudentFields()
        {
            txtHoten.ReadOnly = true;
            txtLop.ReadOnly = true;
            txtKhoa.ReadOnly = true;
            txtSDT.ReadOnly = true;
            cboGioitinh.Enabled = false;
        }

        // ================================================================
        // HELPER: đặt ComboBox theo text
        // ================================================================
        private void SetComboByText(ComboBox cbo, string text)
        {
            int idx = cbo.FindStringExact(text);
            cbo.SelectedIndex = (idx >= 0) ? idx : -1;
        }

        // ================================================================
        // HELPER: reset tất cả ComboBox về mặc định
        // ================================================================
        private void ResetCombos()
        {
            cboHocky.SelectedIndex = 0;
            cboLoaiphong.SelectedIndex = 0;
            cboTrangthai.SelectedIndex = 0;

            cboKhunha.SelectedIndexChanged -= cboKhunha_SelectedIndexChanged;
            cboKhunha.SelectedIndex = 0;
            cboKhunha.SelectedIndexChanged += cboKhunha_SelectedIndexChanged;

            cboGioitinh.SelectedIndex = -1;
            cboPhong.Items.Clear();
            cboGiuong.Items.Clear();
        }

        // ================================================================
        // STUB HANDLERS DO DESIGNER YÊU CẦU
        // ================================================================
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void tlpTop_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
    }
}