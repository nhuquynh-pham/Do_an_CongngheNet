using QLKTX;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Traphong : Form
    {
        private readonly DBService _db;
        private SaveMode _saveMode = SaveMode.Insert;

        public Traphong()
        {
            InitializeComponent();
            _db = new DBService();
        }

        // ================================================================
        // SỰ KIỆN LOAD FORM
        // ================================================================
        private void Traphong_Load(object sender, EventArgs e)
        {
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
            UIService.SetGridStyle(dgvTraphong);
            txtSearch.Enabled = true;

            LoadComboKhunha();
            LoadComboTrangthai();
            LoadData();

            UIService.SetGridHeader(dgvTraphong,
                "Mã trả phòng", "Mã SV", "Họ tên", "Mã phòng",
                "Giường", "Ngày vào ở", "Ngày trả phòng", "Lý do trả", "Trạng thái", "Ghi chú");
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

            txtmatraphong.Text = GenerateNewID();
            txtmatraphong.ReadOnly = true;
            txtHoten.Enabled = false;
            txtNgayvaoo.ReadOnly = true;

            txtNgaytraphong.Text = DateTime.Today.ToString("dd/MM/yyyy");

            txtMsv.Focus();
        }

        // ================================================================
        // NÚT SỬA
        // ================================================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTraphong.CurrentRow == null) return;

            _saveMode = SaveMode.Update;
            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);

            txtmatraphong.ReadOnly = true;
            txtHoten.Enabled = false;
            txtNgayvaoo.ReadOnly = true;

            txtMsv.Focus();
        }

        // ================================================================
        // NÚT XÓA
        // ================================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTraphong.CurrentRow == null) return;
            if (!UIService.ConfirmDelete()) return;

            string maTraPhong = GetCurrentID();
            DeleteData(maTraPhong);
            LoadData();
        }

        // ================================================================
        // NÚT GHI (LƯU)
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string maTraPhong = txtmatraphong.Text.Trim();
            string maSV = txtMsv.Text.Trim();
            string maPhong = cboPhongdango.SelectedValue?.ToString() ?? "";
            string giuong = cboGiuong.Text.Trim();
            DateTime? ngayVaoO = UIService.ParseDate(txtNgayvaoo.Text.Trim());
            DateTime ngayTra = UIService.ParseDate(txtNgaytraphong.Text.Trim()).Value;
            string lyDoTra = txtLydotra.Text.Trim();
            string trangThai = cboTrangthai.Text.Trim();
            string ghiChu = txtGhichu.Text.Trim();

            if (_saveMode == SaveMode.Insert)
            {
                if (IDExists(maTraPhong))
                {
                    MessageBox.Show("Mã trả phòng đã tồn tại trong hệ thống!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmatraphong.Focus();
                    return;
                }
                InsertData(maTraPhong, maSV, maPhong, giuong, ngayVaoO, ngayTra, lyDoTra, trangThai, ghiChu);
            }
            else
            {
                if (dgvTraphong.CurrentRow == null) return;
                UpdateData(maTraPhong, maSV, maPhong, giuong, ngayVaoO, ngayTra, lyDoTra, trangThai, ghiChu);
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
        private void dgvTraphong_SelectionChanged(object sender, EventArgs e)
        {
            BindData();
        }

        // ================================================================
        // KHI NHẬP MÃ SINH VIÊN VÀ NHẤN ENTER → TỰ ĐỘNG LẤY THÔNG TIN
        // ================================================================
        private void txtMsv_KeyDown(object sender, KeyEventArgs e)
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
        // KHI CHỌN KHU NHÀ → TẢI DANH SÁCH PHÒNG TƯƠNG ỨNG
        // ================================================================
        private void cboKhunha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhunha.SelectedValue == null) return;
            LoadComboPhong(cboKhunha.SelectedValue.ToString());
        }

        // ================================================================
        // KHI CHỌN PHÒNG → TẢI DANH SÁCH GIƯỜNG
        // ================================================================
        private void cboPhongdango_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhongdango.SelectedValue == null) return;
            LoadComboGiuong(cboPhongdango.SelectedValue.ToString(), txtMsv.Text.Trim());
        }

        // ================================================================
        // ĐIỀU HƯỚNG BÀN PHÍM
        // ================================================================
        private void txtNgaytraphong_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtLydotra_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void txtGhichu_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void cboKhunha_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void cboPhongdango_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void cboGiuong_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);
        private void cboTrangthai_KeyDown(object sender, KeyEventArgs e) => UIService.MoveFocus((Control)sender, e);

        // ================================================================
        // KIỂM TRA DỮ LIỆU ĐẦU VÀO
        // ================================================================
        private bool ValidateInput()
        {
            if (!UIService.Require(txtmatraphong, "Yêu cầu phải có mã trả phòng!"))
                return false;

            if (!UIService.Require(txtMsv, "Yêu cầu phải nhập mã sinh viên!"))
                return false;

            if (!UIService.Require(cboPhongdango, "Yêu cầu phải chọn phòng!"))
                return false;

            if (!UIService.Require(txtNgaytraphong, "Yêu cầu phải nhập ngày trả phòng!"))
                return false;

            if (!UIService.Require(cboTrangthai, "Yêu cầu phải chọn trạng thái!"))
                return false;

            if (!UIService.MaxLength(txtMsv, 10, "Mã sinh viên không dài hơn 10 ký tự!"))
                return false;

            if (!UIService.MaxLength(txtLydotra, 200, "Lý do trả không dài hơn 200 ký tự!"))
                return false;

            if (!UIService.MaxLength(txtGhichu, 200, "Ghi chú không dài hơn 200 ký tự!"))
                return false;

            if (!UIService.ParseDate(txtNgaytraphong.Text.Trim()).HasValue)
            {
                MessageBox.Show("Ngày trả phòng không hợp lệ! Nhập theo định dạng dd/MM/yyyy.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaytraphong.Focus();
                return false;
            }

            DateTime? ngayVaoO = UIService.ParseDate(txtNgayvaoo.Text.Trim());
            DateTime ngayTra = UIService.ParseDate(txtNgaytraphong.Text.Trim()).Value;

            if (ngayVaoO.HasValue && ngayTra < ngayVaoO.Value)
            {
                MessageBox.Show("Ngày trả phòng không được nhỏ hơn ngày vào ở!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaytraphong.Focus();
                return false;
            }

            if (!StudentExists(txtMsv.Text.Trim()))
            {
                MessageBox.Show("Mã sinh viên không tồn tại trong hệ thống!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMsv.Focus();
                return false;
            }

            return true;
        }

        // ================================================================
        // KIỂM TRA MÃ TRẢ PHÒNG ĐÃ TỒN TẠI
        // ================================================================
        private bool IDExists(string maTraPhong)
        {
            string sql = "SELECT COUNT(*) FROM TraPhong WHERE MaTraPhong = @MaTraPhong";
            int count = Convert.ToInt32(_db.ExecuteScalar(sql,
                new SqlParameter("@MaTraPhong", maTraPhong)));
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
        // SINH MÃ TRẢ PHÒNG TỰ ĐỘNG (TP001, TP002, ...)
        // ================================================================
        private string GenerateNewID()
        {
            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaTraPhong, 3, LEN(MaTraPhong)) AS INT)), 0) + 1
                           FROM TraPhong
                           WHERE MaTraPhong LIKE 'TP%'";
            object result = _db.ExecuteScalar(sql);
            int nextNum = Convert.ToInt32(result);
            return "TP" + nextNum.ToString("D3");
        }

        // ================================================================
        // TỰ ĐỘNG ĐIỀN THÔNG TIN SINH VIÊN KHI NHẬP MÃ SV + ENTER
        // ================================================================
        private void AutoFillStudentInfo()
        {
            string maSV = txtMsv.Text.Trim();
            if (string.IsNullOrEmpty(maSV)) return;

            string sql = @"SELECT sv.HoTen, xp.MaPhong, p.MaKhu, xp.Giuong, xp.NgayVaoO
                           FROM SinhVien sv
                           LEFT JOIN XepPhong xp ON sv.MaSV = xp.MaSV AND xp.TrangThaiO = N'Đang ở'
                           LEFT JOIN Phong p ON xp.MaPhong = p.MaPhong
                           WHERE sv.MaSV = @MaSV";

            DataTable dt = _db.ExecuteQuery(sql, new SqlParameter("@MaSV", maSV));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên với mã: " + maSV,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoten.Text = "";
                return;
            }

            DataRow row = dt.Rows[0];
            txtHoten.Text = row["HoTen"]?.ToString() ?? "";
            txtNgayvaoo.Text = UIService.FormatDate(row["NgayVaoO"]);

            string maKhu = row["MaKhu"]?.ToString() ?? "";
            string maPhong = row["MaPhong"]?.ToString() ?? "";
            string giuong = row["Giuong"]?.ToString() ?? "";

            if (!string.IsNullOrEmpty(maKhu))
            {
                cboKhunha.SelectedValue = maKhu;
                LoadComboPhong(maKhu);

                if (!string.IsNullOrEmpty(maPhong))
                    cboPhongdango.SelectedValue = maPhong;

                if (!string.IsNullOrEmpty(giuong))
                    cboGiuong.Text = giuong;
            }

            cboTrangthai.SelectedIndex = -1;
        }

        // ================================================================
        // TẢI DỮ LIỆU
        // ================================================================
        private void LoadData()
        {
            string keyword = txtSearch.Text.Trim();
            dgvTraphong.DataSource = SearchData(keyword);
        }

        private DataTable SearchData(string keyword = "")
        {
            string sql = @"SELECT tp.MaTraPhong, tp.MaSV, sv.HoTen,
                                  tp.MaPhong, tp.Giuong,
                                  tp.NgayVaoO, tp.NgayTraPhong,
                                  tp.LyDoTra, tp.TrangThai, tp.GhiChu
                           FROM TraPhong tp
                           LEFT JOIN SinhVien sv ON tp.MaSV = sv.MaSV
                           WHERE (@Keyword = N''
                                  OR tp.MaTraPhong LIKE @Keyword
                                  OR tp.MaSV        LIKE @Keyword
                                  OR sv.HoTen       LIKE @Keyword
                                  OR tp.MaPhong     LIKE @Keyword)
                           ORDER BY tp.MaTraPhong";

            return _db.ExecuteQuery(sql,
                new SqlParameter("@Keyword", "%" + keyword + "%"));
        }

        // ================================================================
        // GÁN DỮ LIỆU TỪ LƯỚI LÊN FORM
        // ================================================================
        private void BindData()
        {
            if (dgvTraphong.CurrentRow == null)
            {
                UIService.ClearInputs(this);
                return;
            }

            DataGridViewRow row = dgvTraphong.CurrentRow;

            txtmatraphong.Text = row.Cells["MaTraPhong"].Value?.ToString() ?? "";
            txtMsv.Text = row.Cells["MaSV"].Value?.ToString() ?? "";
            txtHoten.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            txtNgayvaoo.Text = UIService.FormatDate(row.Cells["NgayVaoO"].Value);
            txtNgaytraphong.Text = UIService.FormatDate(row.Cells["NgayTraPhong"].Value);
            txtLydotra.Text = row.Cells["LyDoTra"].Value?.ToString() ?? "";
            txtGhichu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";

            string maPhong = row.Cells["MaPhong"].Value?.ToString() ?? "";
            string giuong = row.Cells["Giuong"].Value?.ToString() ?? "";

            if (!string.IsNullOrEmpty(maPhong))
            {
                string sqlKhu = "SELECT MaKhu FROM Phong WHERE MaPhong = @MaPhong";
                object maKhuObj = _db.ExecuteScalar(sqlKhu,
                    new SqlParameter("@MaPhong", maPhong));
                string maKhu = maKhuObj?.ToString() ?? "";

                cboKhunha.SelectedValue = maKhu;
                LoadComboPhong(maKhu);
                cboPhongdango.SelectedValue = maPhong;
                LoadComboGiuong(maPhong, txtMsv.Text.Trim());
                cboGiuong.Text = giuong;
            }
            else
            {
                cboKhunha.SelectedIndex = -1;
                cboPhongdango.SelectedIndex = -1;
                cboGiuong.SelectedIndex = -1;
            }

            cboTrangthai.Text = row.Cells["TrangThai"].Value?.ToString() ?? "";
        }

        // ================================================================
        // INSERT
        // ================================================================
        private void InsertData(string maTraPhong, string maSV, string maPhong, string giuong,
                                DateTime? ngayVaoO, DateTime ngayTra,
                                string lyDoTra, string trangThai, string ghiChu)
        {
            string sql = @"INSERT INTO TraPhong
                               (MaTraPhong, MaSV, MaPhong, Giuong, NgayVaoO, NgayTraPhong, LyDoTra, TrangThai, GhiChu)
                           VALUES
                               (@MaTraPhong, @MaSV, @MaPhong, @Giuong, @NgayVaoO, @NgayTraPhong, @LyDoTra, @TrangThai, @GhiChu)";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaTraPhong", maTraPhong),
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@MaPhong", maPhong),
                new SqlParameter("@Giuong", string.IsNullOrWhiteSpace(giuong) ? (object)DBNull.Value : giuong),
                new SqlParameter("@NgayVaoO", ngayVaoO.HasValue ? (object)ngayVaoO.Value : DBNull.Value),
                new SqlParameter("@NgayTraPhong", ngayTra),
                new SqlParameter("@LyDoTra", string.IsNullOrWhiteSpace(lyDoTra) ? (object)DBNull.Value : lyDoTra),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu)
            );

            MessageBox.Show("Thêm phiếu trả phòng thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        private void UpdateData(string maTraPhong, string maSV, string maPhong, string giuong,
                                DateTime? ngayVaoO, DateTime ngayTra,
                                string lyDoTra, string trangThai, string ghiChu)
        {
            string sql = @"UPDATE TraPhong
                           SET MaSV          = @MaSV,
                               MaPhong       = @MaPhong,
                               Giuong        = @Giuong,
                               NgayVaoO      = @NgayVaoO,
                               NgayTraPhong  = @NgayTraPhong,
                               LyDoTra       = @LyDoTra,
                               TrangThai     = @TrangThai,
                               GhiChu        = @GhiChu
                           WHERE MaTraPhong = @MaTraPhong";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaTraPhong", maTraPhong),
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@MaPhong", maPhong),
                new SqlParameter("@Giuong", string.IsNullOrWhiteSpace(giuong) ? (object)DBNull.Value : giuong),
                new SqlParameter("@NgayVaoO", ngayVaoO.HasValue ? (object)ngayVaoO.Value : DBNull.Value),
                new SqlParameter("@NgayTraPhong", ngayTra),
                new SqlParameter("@LyDoTra", string.IsNullOrWhiteSpace(lyDoTra) ? (object)DBNull.Value : lyDoTra),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu)
            );

            MessageBox.Show("Cập nhật phiếu trả phòng thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // DELETE
        // ================================================================
        private void DeleteData(string maTraPhong)
        {
            string sql = "DELETE FROM TraPhong WHERE MaTraPhong = @MaTraPhong";
            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaTraPhong", maTraPhong));
        }

        // ================================================================
        // LẤY MÃ TRẢ PHÒNG CỦA DÒNG ĐANG CHỌN
        // ================================================================
        private string GetCurrentID()
        {
            if (dgvTraphong.CurrentRow == null) return "";
            return dgvTraphong.CurrentRow.Cells["MaTraPhong"].Value?.ToString() ?? "";
        }

        // ================================================================
        // TẢI COMBOBOX KHU NHÀ
        // ================================================================
        private void LoadComboKhunha()
        {
            string sql = "SELECT MaKhu, TenKhu FROM KhuNha WHERE TrangThai = N'Đang sử dụng' ORDER BY TenKhu";
            DataTable dt = _db.ExecuteQuery(sql);

            DataRow blank = dt.NewRow();
            blank["MaKhu"] = "";
            blank["TenKhu"] = "";
            dt.Rows.InsertAt(blank, 0);

            cboKhunha.DataSource = dt;
            cboKhunha.DisplayMember = "TenKhu";
            cboKhunha.ValueMember = "MaKhu";
            cboKhunha.SelectedIndex = 0;
        }

        // ================================================================
        // TẢI COMBOBOX PHÒNG THEO KHU
        // ================================================================
        private void LoadComboPhong(string maKhu)
        {
            string sql = @"SELECT MaPhong, SoPhong FROM Phong
                           WHERE MaKhu = @MaKhu
                           ORDER BY SoPhong";

            DataTable dt = _db.ExecuteQuery(sql,
                new SqlParameter("@MaKhu", maKhu));

            DataRow blank = dt.NewRow();
            blank["MaPhong"] = "";
            blank["SoPhong"] = "";
            dt.Rows.InsertAt(blank, 0);

            cboPhongdango.DataSource = dt;
            cboPhongdango.DisplayMember = "SoPhong";
            cboPhongdango.ValueMember = "MaPhong";
            cboPhongdango.SelectedIndex = 0;
        }

        // ================================================================
        // TẢI COMBOBOX GIƯỜNG THEO PHÒNG
        // ================================================================
        private void LoadComboGiuong(string maPhong, string maSV)
        {
            string sql = @"SELECT DISTINCT Giuong FROM XepPhong
                           WHERE MaPhong = @MaPhong
                             AND MaSV    = @MaSV
                             AND TrangThaiO = N'Đang ở'
                           ORDER BY Giuong";

            DataTable dt = _db.ExecuteQuery(sql,
                new SqlParameter("@MaPhong", maPhong),
                new SqlParameter("@MaSV", maSV));

            if (dt.Rows.Count == 0)
            {
                sql = @"SELECT DISTINCT Giuong FROM XepPhong
                        WHERE MaPhong = @MaPhong
                        ORDER BY Giuong";
                dt = _db.ExecuteQuery(sql,
                    new SqlParameter("@MaPhong", maPhong));
            }

            DataRow blank = dt.NewRow();
            blank["Giuong"] = "";
            dt.Rows.InsertAt(blank, 0);

            cboGiuong.DataSource = dt;
            cboGiuong.DisplayMember = "Giuong";
            cboGiuong.ValueMember = "Giuong";
            cboGiuong.SelectedIndex = 0;
        }

        // ================================================================
        // TẢI COMBOBOX TRẠNG THÁI
        // ================================================================
        private void LoadComboTrangthai()
        {
            cboTrangthai.Items.Clear();
            cboTrangthai.Items.Add("Đã trả phòng");
            cboTrangthai.Items.Add("Chờ trả phòng");
            cboTrangthai.SelectedIndex = -1;
        }

        // ================================================================
        // SỰ KIỆN GIỮ LẠI TỪ DESIGNER
        // ================================================================
        private void tlpRoot_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void tlpContent_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void txtGhichu_TextChanged(object sender, EventArgs e) { }
    }
}