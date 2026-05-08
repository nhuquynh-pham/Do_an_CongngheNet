using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Quanlyphong : Form
    {
        // khai báo đối tượng _db - giống thầy: private readonly DBService _db
        private readonly DBService _db;

        private bool dangThemMoi = false;
        private bool dangSua = false;

        public Quanlyphong()
        {
            InitializeComponent();
            // tạo đối tượng _db trong constructor - giống thầy
            _db = new DBService();

            KhoiTaoForm();
            TaiDuLieu();
        }

        // ================================================================
        // KHỞI TẠO FORM
        // ================================================================
        private void KhoiTaoForm()
        {
            // nạp combobox
            LoadKhuNha();
            LoadTang();
            LoadLoaiphong();
            LoadGioitinh();
            LoadTrangthai();

            // gán Tag cho nút - để UIService.SetButtonsEnabled hoạt động
            btnNew.Tag = "select";
            btnEdit.Tag = "select";
            btnDelete.Tag = "select";
            btnClose.Tag = "select";
            btnSave.Tag = "confirm";
            btnCancel.Tag = "confirm";

            btnNew.Click += new EventHandler(btnNew_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnClose.Click += new EventHandler(btnClose_Click);

            txtTimkiem.TextChanged += new EventHandler(txtTimkiem_TextChanged);
            dgvQuanlyphong.SelectionChanged += new EventHandler(dgvQuanlyphong_SelectionChanged);
            cboLoaiphong.SelectedIndexChanged += new EventHandler(cboLoaiphong_SelectedIndexChanged);

            // [UIService.SetGridStyle] thiết lập DataGridView dùng chung
            UIService.SetGridStyle(dgvQuanlyphong);

            // [UIService.MoveFocus] điều hướng bàn phím Enter/Down/Up
            txtSophong.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtSucchua.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtSonguoio.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtGiaphong.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtGhichu.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboKhunha.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboTang.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboLoaiphong.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboGioitinh.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboTrangthai.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);

            // txtMaphong và txtSonguoio luôn readonly
            txtMaphong.Tag = "no-clear";
            txtSonguoio.Tag = "no-clear";

            // [UIService.SetButtonsEnabled] trạng thái ban đầu: chỉ xem
            SetTrangThaiForm(false);
        }

        // ================================================================
        // NẠP COMBOBOX KHU NHÀ TỪ DATABASE
        // ================================================================
        private void LoadKhuNha()
        {
            // _db.ExecuteQuery - giống thầy
            DataTable dt = _db.ExecuteQuery(
                "SELECT MaKhu, TenKhu FROM KhuNha WHERE TrangThai = N'Đang sử dụng' ORDER BY TenKhu");

            DataRow blank = dt.NewRow();
            blank["MaKhu"] = "";
            blank["TenKhu"] = "-- Chọn khu nhà --";
            dt.Rows.InsertAt(blank, 0);

            cboKhunha.DataSource = dt;
            cboKhunha.DisplayMember = "TenKhu";
            cboKhunha.ValueMember = "MaKhu";
            cboKhunha.SelectedIndex = 0;
        }

        private void LoadTang()
        {
            cboTang.Items.Clear();
            cboTang.Items.Add("-- Chọn tầng --");
            for (int i = 1; i <= 10; i++)
                cboTang.Items.Add("Tầng " + i);
            cboTang.SelectedIndex = 0;
        }

        private void LoadLoaiphong()
        {
            cboLoaiphong.Items.Clear();
            cboLoaiphong.Items.Add("-- Chọn loại phòng --");
            cboLoaiphong.Items.Add("Phòng 4 người");
            cboLoaiphong.Items.Add("Phòng 6 người");
            cboLoaiphong.SelectedIndex = 0;
        }

        private void LoadGioitinh()
        {
            cboGioitinh.Items.Clear();
            cboGioitinh.Items.Add("-- Chọn giới tính --");
            cboGioitinh.Items.Add("Nam");
            cboGioitinh.Items.Add("Nữ");
            cboGioitinh.Items.Add("Khác");
            cboGioitinh.SelectedIndex = 0;
        }

        private void LoadTrangthai()
        {
            cboTrangthai.Items.Clear();
            cboTrangthai.Items.Add("-- Chọn trạng thái --");
            cboTrangthai.Items.Add("Còn chỗ");
            cboTrangthai.Items.Add("Bảo trì");
            cboTrangthai.Items.Add("Ngưng sử dụng");
            cboTrangthai.Items.Add("Đang sử dụng");
            cboTrangthai.SelectedIndex = 0;
        }

        // ================================================================
        // TỰ ĐIỀN SỨC CHỨA KHI CHỌN LOẠI PHÒNG
        // ================================================================
        private void cboLoaiphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!txtSucchua.Enabled) return;
            string loai = cboLoaiphong.Text;
            if (loai == "Phòng 4 người") txtSucchua.Text = "4";
            else if (loai == "Phòng 6 người") txtSucchua.Text = "6";
            else txtSucchua.Text = "";
        }

        // ================================================================
        // TẢI DỮ LIỆU LÊN LƯỚI
        // ================================================================
        private void TaiDuLieu(string tuKhoa = "")
        {
            string sql = @"SELECT p.MaPhong, p.SoPhong, k.TenKhu, p.Tang,
                                  p.LoaiPhong, p.SucChua, p.SoNguoiHienTai,
                                  p.GiaPhong, p.GioiTinh, p.TrangThai, p.GhiChu
                           FROM Phong p
                           LEFT JOIN KhuNha k ON p.MaKhu = k.MaKhu";

            if (!string.IsNullOrEmpty(tuKhoa))
                sql += @" WHERE p.SoPhong LIKE @TuKhoa OR k.TenKhu LIKE @TuKhoa
                          OR p.MaPhong LIKE @TuKhoa OR p.TrangThai LIKE @TuKhoa";

            sql += " ORDER BY p.MaPhong";

            // _db.ExecuteQuery - giống thầy
            DataTable dt = string.IsNullOrEmpty(tuKhoa)
                ? _db.ExecuteQuery(sql)
                : _db.ExecuteQuery(sql, new SqlParameter("@TuKhoa", "%" + tuKhoa + "%"));

            dgvQuanlyphong.DataSource = dt;

            if (dgvQuanlyphong.Columns.Count > 0)
            {
                // [UIService.SetGridHeader] thiết lập tiêu đề cột
                UIService.SetGridHeader(dgvQuanlyphong,
                    "Mã phòng", "Số phòng", "Khu nhà", "Tầng",
                    "Loại phòng", "Sức chứa", "Số người ở",
                    "Giá phòng", "Giới tính", "Trạng thái", "Ghi chú");

                dgvQuanlyphong.Columns["GiaPhong"].DefaultCellStyle.Format = "N0";

                // tô màu theo trạng thái
                foreach (DataGridViewRow row in dgvQuanlyphong.Rows)
                {
                    string tt = row.Cells["TrangThai"].Value?.ToString() ?? "";
                    switch (tt)
                    {
                        case "Còn chỗ":
                            row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                            row.DefaultCellStyle.Font = new Font(dgvQuanlyphong.Font, FontStyle.Bold);
                            break;
                        case "Đang sử dụng":
                            row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                            break;
                        case "Bảo trì":
                            row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                            break;
                        case "Ngưng sử dụng":
                            row.DefaultCellStyle.ForeColor = Color.Red;
                            break;
                    }
                }
            }
        }

        // ================================================================
        // HIỂN THỊ DỮ LIỆU LÊN FORM KHI CHỌN DÒNG
        // ================================================================
        private void HienThiLenForm(DataGridViewRow row)
        {
            if (row == null) return;

            txtMaphong.Text = row.Cells["MaPhong"].Value?.ToString();
            txtSophong.Text = row.Cells["SoPhong"].Value?.ToString();
            txtSucchua.Text = row.Cells["SucChua"].Value?.ToString();
            txtSonguoio.Text = row.Cells["SoNguoiHienTai"].Value?.ToString();
            txtGiaphong.Text = row.Cells["GiaPhong"].Value?.ToString();
            txtGhichu.Text = row.Cells["GhiChu"].Value?.ToString();

            // load lại chi tiết từ DB để lấy MaKhu cho combobox
            string maPhong = txtMaphong.Text;
            if (string.IsNullOrEmpty(maPhong)) return;

            DataTable dt = _db.ExecuteQuery(
                "SELECT * FROM Phong WHERE MaPhong = @MaPhong",
                new SqlParameter("@MaPhong", maPhong));

            if (dt.Rows.Count == 0) return;
            DataRow r = dt.Rows[0];

            // set combobox khu nhà theo value
            try { cboKhunha.SelectedValue = r["MaKhu"].ToString(); } catch { }

            // set tầng
            int tang = r["Tang"] == DBNull.Value ? 0 : Convert.ToInt32(r["Tang"]);
            int idxTang = cboTang.FindStringExact("Tầng " + tang);
            cboTang.SelectedIndex = idxTang >= 0 ? idxTang : 0;

            // set các combobox còn lại
            SetComboByText(cboLoaiphong, r["LoaiPhong"].ToString());
            SetComboByText(cboGioitinh, r["GioiTinh"].ToString());
            SetComboByText(cboTrangthai, r["TrangThai"].ToString());
        }

        private void SetComboByText(ComboBox cbo, string text)
        {
            int idx = cbo.FindStringExact(text);
            cbo.SelectedIndex = idx >= 0 ? idx : 0;
        }

        // ================================================================
        // XÓA TRẮNG FORM
        // ================================================================
        private void XoaForm()
        {
            // [UIService.ClearInputs] xóa trắng toàn bộ ô nhập trong tlplnputs
            UIService.ClearInputs(tlplnputs);
            cboKhunha.SelectedIndex = 0;
            cboTang.SelectedIndex = 0;
            cboLoaiphong.SelectedIndex = 0;
            cboGioitinh.SelectedIndex = 0;
            cboTrangthai.SelectedIndex = 0;
        }

        // ================================================================
        // TẠO MÃ PHÒNG TỰ ĐỘNG
        // ================================================================
        private string TaoMaPhong()
        {
            // _db.ExecuteScalar - giống thầy
            object obj = _db.ExecuteScalar(
                @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaPhong,2,LEN(MaPhong)) AS INT)),0)+1
                  FROM Phong WHERE MaPhong LIKE 'P%'
                  AND ISNUMERIC(SUBSTRING(MaPhong,2,LEN(MaPhong)))=1");
            int next = obj != null ? Convert.ToInt32(obj) : 1;
            return "P" + next.ToString("D3");
        }

        // ================================================================
        // KIỂM TRA DỮ LIỆU
        // ================================================================
        private bool KiemTraDuLieu()
        {
            // [UIService.Require] kiểm tra bắt buộc nhập
            if (!UIService.Require(txtSophong, "Vui lòng nhập Số phòng!")) return false;

            if (cboKhunha.SelectedValue == null || cboKhunha.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn Khu nhà!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboKhunha.Focus(); return false;
            }
            if (cboTang.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Tầng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTang.Focus(); return false;
            }
            if (cboLoaiphong.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Loại phòng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboLoaiphong.Focus(); return false;
            }

            if (!UIService.Require(txtSucchua, "Vui lòng nhập Sức chứa!")) return false;

            if (cboGioitinh.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboGioitinh.Focus(); return false;
            }
            if (cboTrangthai.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Trạng thái!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTrangthai.Focus(); return false;
            }

            // [UIService.IsNumber] kiểm tra số
            if (!UIService.IsNumber(txtSucchua, "Sức chứa phải là số nguyên!")) return false;
            if (!string.IsNullOrWhiteSpace(txtGiaphong.Text) &&
                !UIService.IsNumber(txtGiaphong, "Giá phòng phải là số nguyên!")) return false;

            return true;
        }

        // ================================================================
        // THIẾT LẬP TRẠNG THÁI FORM
        // ================================================================
        private void SetTrangThaiForm(bool choPhepNhap)
        {
            // [UIService.SetInputsEnabled] bật/tắt toàn bộ ô nhập trong tlplnputs
            UIService.SetInputsEnabled(tlplnputs, choPhepNhap);

            // [UIService.SetButtonsEnabled] bật/tắt nút theo Tag "select"/"confirm"
            UIService.SetButtonsEnabled(this, choPhepNhap);

            // txtMaphong và txtSonguoio luôn readonly
            txtMaphong.Enabled = false;
            txtSonguoio.Enabled = false;
        }

        // ================================================================
        // THÊM MỚI
        // ================================================================
        private void btnNew_Click(object sender, EventArgs e)
        {
            dangThemMoi = true; dangSua = false;
            XoaForm();
            txtMaphong.Text = TaoMaPhong();
            SetTrangThaiForm(true);
            txtSophong.Focus();
        }

        // ================================================================
        // SỬA
        // ================================================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvQuanlyphong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dangSua = true; dangThemMoi = false;
            SetTrangThaiForm(true);
            txtMaphong.Enabled = false;
            txtSophong.Focus();
        }

        // ================================================================
        // XÓA
        // ================================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvQuanlyphong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhong = txtMaphong.Text.Trim();

            // kiểm tra còn sinh viên đang ở không
            object obj = _db.ExecuteScalar(
                "SELECT COUNT(*) FROM XepPhong WHERE MaPhong = @mp AND TrangThaiO = N'Đang ở'",
                new SqlParameter("@mp", maPhong));
            int soSV = obj != null ? Convert.ToInt32(obj) : 0;
            if (soSV > 0)
            {
                MessageBox.Show($"Không thể xóa! Phòng {txtSophong.Text} hiện có {soSV} sinh viên đang ở.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [UIService.ConfirmDelete] hộp thoại xác nhận xóa
            if (!UIService.ConfirmDelete()) return;

            // _db.ExecuteNonQuery - giống thầy
            int rows = _db.ExecuteNonQuery(
                "DELETE FROM Phong WHERE MaPhong = @MaPhong",
                new SqlParameter("@MaPhong", maPhong));

            if (rows > 0)
            {
                MessageBox.Show("Xóa phòng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                XoaForm();
                TaiDuLieu();
            }
        }

        // ================================================================
        // GHI (LƯU)
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            string maPhong = txtMaphong.Text.Trim();
            string soPhong = txtSophong.Text.Trim();
            string maKhu = cboKhunha.SelectedValue?.ToString() ?? "";
            int tang = int.Parse(cboTang.Text.Replace("Tầng ", "").Trim());
            string loai = cboLoaiphong.Text;
            int sucChua = int.Parse(txtSucchua.Text.Trim());
            int gia = string.IsNullOrWhiteSpace(txtGiaphong.Text) ? 0 : int.Parse(txtGiaphong.Text.Trim());
            string gioiTinh = cboGioitinh.Text;
            string trangThai = cboTrangthai.Text;
            string ghiChu = txtGhichu.Text.Trim();

            if (dangThemMoi)
            {
                // kiểm tra trùng số phòng trong khu
                object chk = _db.ExecuteScalar(
                    "SELECT COUNT(*) FROM Phong WHERE SoPhong = @sp AND MaKhu = @mk",
                    new SqlParameter("@sp", soPhong),
                    new SqlParameter("@mk", maKhu));
                if (Convert.ToInt32(chk) > 0)
                {
                    MessageBox.Show("Số phòng này đã tồn tại trong khu nhà đã chọn!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSophong.Focus(); return;
                }

                // _db.ExecuteNonQuery - giống thầy
                int r = _db.ExecuteNonQuery(
                    @"INSERT INTO Phong (MaPhong, SoPhong, MaKhu, Tang, LoaiPhong, SucChua,
                      SoNguoiHienTai, GiaPhong, GioiTinh, TrangThai, GhiChu)
                      VALUES (@MaPhong, @SoPhong, @MaKhu, @Tang, @LoaiPhong, @SucChua,
                      0, @GiaPhong, @GioiTinh, @TrangThai, @GhiChu)",
                    new SqlParameter("@MaPhong", maPhong),
                    new SqlParameter("@SoPhong", soPhong),
                    new SqlParameter("@MaKhu", maKhu),
                    new SqlParameter("@Tang", tang),
                    new SqlParameter("@LoaiPhong", loai),
                    new SqlParameter("@SucChua", sucChua),
                    new SqlParameter("@GiaPhong", gia),
                    new SqlParameter("@GioiTinh", gioiTinh),
                    new SqlParameter("@TrangThai", trangThai),
                    new SqlParameter("@GhiChu", ghiChu));

                if (r > 0)
                    MessageBox.Show("Thêm phòng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dangSua)
            {
                // kiểm tra trùng số phòng (trừ chính nó)
                object chk = _db.ExecuteScalar(
                    "SELECT COUNT(*) FROM Phong WHERE SoPhong=@sp AND MaKhu=@mk AND MaPhong<>@mp",
                    new SqlParameter("@sp", soPhong),
                    new SqlParameter("@mk", maKhu),
                    new SqlParameter("@mp", maPhong));
                if (Convert.ToInt32(chk) > 0)
                {
                    MessageBox.Show("Số phòng này đã tồn tại trong khu nhà đã chọn!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSophong.Focus(); return;
                }

                // _db.ExecuteNonQuery - giống thầy
                int r = _db.ExecuteNonQuery(
                    @"UPDATE Phong SET SoPhong=@SoPhong, MaKhu=@MaKhu, Tang=@Tang,
                      LoaiPhong=@LoaiPhong, SucChua=@SucChua, GiaPhong=@GiaPhong,
                      GioiTinh=@GioiTinh, TrangThai=@TrangThai, GhiChu=@GhiChu
                      WHERE MaPhong=@MaPhong",
                    new SqlParameter("@MaPhong", maPhong),
                    new SqlParameter("@SoPhong", soPhong),
                    new SqlParameter("@MaKhu", maKhu),
                    new SqlParameter("@Tang", tang),
                    new SqlParameter("@LoaiPhong", loai),
                    new SqlParameter("@SucChua", sucChua),
                    new SqlParameter("@GiaPhong", gia),
                    new SqlParameter("@GioiTinh", gioiTinh),
                    new SqlParameter("@TrangThai", trangThai),
                    new SqlParameter("@GhiChu", ghiChu));

                if (r > 0)
                    MessageBox.Show("Cập nhật phòng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dangThemMoi = false; dangSua = false;
            SetTrangThaiForm(false);
            TaiDuLieu();
        }

        // ================================================================
        // HỦY GHI
        // ================================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            dangThemMoi = false; dangSua = false;
            XoaForm();
            SetTrangThaiForm(false);
            if (dgvQuanlyphong.CurrentRow != null)
                HienThiLenForm(dgvQuanlyphong.CurrentRow);
        }

        // ================================================================
        // KẾT THÚC
        // ================================================================
        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        // ================================================================
        // CHỌN DÒNG TRÊN LƯỚI
        // ================================================================
        private void dgvQuanlyphong_SelectionChanged(object sender, EventArgs e)
        {
            if (dangThemMoi || dangSua) return;
            if (dgvQuanlyphong.CurrentRow != null)
                HienThiLenForm(dgvQuanlyphong.CurrentRow);
        }

        // ================================================================
        // TÌM KIẾM
        // ================================================================
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            TaiDuLieu(txtTimkiem.Text.Trim());
        }
    }
}