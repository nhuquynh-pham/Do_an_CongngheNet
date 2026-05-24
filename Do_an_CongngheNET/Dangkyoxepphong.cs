using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Dangkyoxepphong : Form
    {
        // khai báo đối tượng _db - giống thầy: private readonly DBService _db
        private readonly DBService _db;

        private bool dangThemMoi = false;
        private bool dangSua = false;

        public Dangkyoxepphong()
        {
            InitializeComponent();
            // tạo đối tượng _db trong constructor - giống thầy
            _db = new DBService();

            KhoiTaoForm();
            TaiDuLieu();

            dgvDangkyoxepphong.Dock = DockStyle.None;
            dgvDangkyoxepphong.Location = new Point(0, 0);
            dgvDangkyoxepphong.Size = new Size(pnlGrid.Width, pnlGrid.Height);
            pnlGrid.SizeChanged += (s, e) =>
            {
                dgvDangkyoxepphong.Size = new Size(pnlGrid.Width, pnlGrid.Height);
            };
        }

        private void KhoiTaoForm()
        {
            cboHocky.Items.AddRange(new string[] { "Học kỳ 1", "Học kỳ 2", "Học kỳ hè" });

            TaiCboKhunha();

            // gán Tag cho nút - để UIService.SetButtonsEnabled hoạt động
            btnNew.Tag = "select";
            btnEdit.Tag = "select";
            btnDelete.Tag = "select";
            btnRefresh.Tag = "select";
            btnClose.Tag = "select";
            btnSave.Tag = "confirm";
            btnCancel.Tag = "confirm";

            btnNew.Click += new EventHandler(btnNew_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            btnClose.Click += new EventHandler(btnClose_Click);

            txtMaSV.Leave += new EventHandler(txtMaSV_Leave);
            cboKhunha.SelectedIndexChanged += new EventHandler(cboKhunha_SelectedIndexChanged);
            cboPhong.SelectedIndexChanged += new EventHandler(cboPhong_SelectedIndexChanged);
            txtTimkiem.TextChanged += new EventHandler(txtTimkiem_TextChanged);
            dgvDangkyoxepphong.SelectionChanged += new EventHandler(dgvDangkyoxepphong_SelectionChanged);

            // [UIService.SetGridStyle] thiết lập DataGridView dùng chung
            UIService.SetGridStyle(dgvDangkyoxepphong);

            // [UIService.MoveFocus] điều hướng bàn phím Enter/Down/Up
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

            // [UIService.SetButtonsEnabled] trạng thái ban đầu: chỉ xem
            SetTrangThaiForm(false);
            txtNgaydangky.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void TaiCboKhunha()
        {
            // _db.ExecuteQuery - giống thầy
            DataTable dt = _db.ExecuteQuery("SELECT MaKhu, TenKhu FROM KhuNha ORDER BY MaKhu");
            cboKhunha.DataSource = dt;
            cboKhunha.DisplayMember = "TenKhu";
            cboKhunha.ValueMember = "MaKhu";
            cboKhunha.SelectedIndex = -1;
        }

        private void cboKhunha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhunha.SelectedValue == null) return;

            string maKhu = cboKhunha.SelectedValue.ToString();
            string sql = @"SELECT MaPhong, SoPhong FROM Phong 
                           WHERE MaKhu = @MaKhu AND TrangThai = N'Còn chỗ'
                           ORDER BY SoPhong";

            DataTable dt = _db.ExecuteQuery(sql, new SqlParameter("@MaKhu", maKhu));
            cboPhong.DataSource = dt;
            cboPhong.DisplayMember = "SoPhong";
            cboPhong.ValueMember = "MaPhong";
            cboPhong.SelectedIndex = -1;
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhong.SelectedValue == null) return;

            string maPhong = cboPhong.SelectedValue.ToString();

            DataTable dtDaO = _db.ExecuteQuery(
                @"SELECT Giuong FROM XepPhong 
                  WHERE MaPhong = @MaPhong AND TrangThaiO = N'Đang ở'",
                new SqlParameter("@MaPhong", maPhong));

            DataTable dtPhong = _db.ExecuteQuery(
                "SELECT SucChua FROM Phong WHERE MaPhong = @MaPhong",
                new SqlParameter("@MaPhong", maPhong));

            int sucChua = 4;
            if (dtPhong.Rows.Count > 0)
                sucChua = Convert.ToInt32(dtPhong.Rows[0]["SucChua"]);

            List<string> daDung = dtDaO.AsEnumerable()
                .Select(r => r["Giuong"].ToString()).ToList();

            cboGiuong.Items.Clear();
            for (int i = 1; i <= sucChua; i++)
            {
                string giuong = $"Giường {i}";
                if (!daDung.Contains(giuong))
                    cboGiuong.Items.Add(giuong);
            }

            if (cboGiuong.Items.Count > 0)
                cboGiuong.SelectedIndex = 0;
        }

        private void txtMaSV_Leave(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
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
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên với mã này!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
            }
        }

        private void TaiDuLieu(string tuKhoa = "")
        {
            string sql = @"SELECT dk.MaDangKy, dk.MaSV, sv.HoTen, dk.NgayDangKy,
                                  dk.HocKy, dk.NamHoc, dk.LoaiPhongMuon,
                                  dk.TrangThaiHoSo, dk.GhiChu
                           FROM DangKy dk
                           INNER JOIN SinhVien sv ON dk.MaSV = sv.MaSV";

            if (!string.IsNullOrEmpty(tuKhoa))
                sql += " WHERE dk.MaSV LIKE @TuKhoa OR sv.HoTen LIKE @TuKhoa OR dk.MaDangKy LIKE @TuKhoa";

            sql += " ORDER BY dk.MaDangKy";

            DataTable dt = string.IsNullOrEmpty(tuKhoa)
                ? _db.ExecuteQuery(sql)
                : _db.ExecuteQuery(sql, new SqlParameter("@TuKhoa", "%" + tuKhoa + "%"));

            dgvDangkyoxepphong.DataSource = dt;

            if (dgvDangkyoxepphong.Columns.Count > 0)
            {
                // [UIService.SetGridHeader] thiết lập tiêu đề cột
                UIService.SetGridHeader(dgvDangkyoxepphong,
                    "Mã ĐK", "Mã SV", "Họ tên", "Ngày ĐK",
                    "Học kỳ", "Năm học", "Loại phòng", "Trạng thái", "Ghi chú");

                dgvDangkyoxepphong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDangkyoxepphong.Columns["MaDangKy"].FillWeight = 8;
                dgvDangkyoxepphong.Columns["MaSV"].FillWeight = 8;
                dgvDangkyoxepphong.Columns["HoTen"].FillWeight = 18;
                dgvDangkyoxepphong.Columns["NgayDangKy"].FillWeight = 10;
                dgvDangkyoxepphong.Columns["HocKy"].FillWeight = 10;
                dgvDangkyoxepphong.Columns["NamHoc"].FillWeight = 10;
                dgvDangkyoxepphong.Columns["LoaiPhongMuon"].FillWeight = 14;
                dgvDangkyoxepphong.Columns["TrangThaiHoSo"].FillWeight = 12;
                dgvDangkyoxepphong.Columns["GhiChu"].FillWeight = 10;

                // [UIService.FormatDate] định dạng ngày tháng trên lưới
                dgvDangkyoxepphong.Columns["NgayDangKy"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void HienThiLenForm(DataGridViewRow row)
        {
            if (row == null) return;

            txtMadangky.Text = row.Cells["MaDangKy"].Value?.ToString();
            txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
            txtHoten.Text = row.Cells["HoTen"].Value?.ToString();

            // [UIService.FormatDate] định dạng ngày hiển thị lên TextBox
            txtNgaydangky.Text = UIService.FormatDate(row.Cells["NgayDangKy"].Value);

            cboHocky.Text = row.Cells["HocKy"].Value?.ToString();
            txtNamhoc.Text = row.Cells["NamHoc"].Value?.ToString();
            cboLoaiphong.Text = row.Cells["LoaiPhongMuon"].Value?.ToString();
            cboTrangthai.Text = row.Cells["TrangThaiHoSo"].Value?.ToString();
            txtGhichu.Text = row.Cells["GhiChu"].Value?.ToString();

            txtMaSV_Leave(null, null);

            DataTable dtXP = _db.ExecuteQuery(
                @"SELECT xp.MaPhong, p.MaKhu, xp.Giuong, xp.NgayVaoO
                  FROM XepPhong xp
                  INNER JOIN Phong p ON xp.MaPhong = p.MaPhong
                  WHERE xp.MaDangKy = @MaDangKy",
                new SqlParameter("@MaDangKy", txtMadangky.Text));

            if (dtXP.Rows.Count > 0)
            {
                cboKhunha.Text = dtXP.Rows[0]["MaKhu"].ToString();
                cboPhong.Text = dtXP.Rows[0]["MaPhong"].ToString();
                cboGiuong.Text = dtXP.Rows[0]["Giuong"].ToString();
                // [UIService.FormatDate] định dạng ngày vào ở
                txtNgayvaoo.Text = UIService.FormatDate(dtXP.Rows[0]["NgayVaoO"]);
            }
        }

        private void XoaForm()
        {
            // [UIService.ClearInputs] xóa trắng toàn bộ ô nhập
            // Form dùng TableLayoutPanel nên clear từng panel chứa control nhập liệu
            UIService.ClearInputs(tlpLeft1);
            UIService.ClearInputs(tlpLeft3);
            txtNgaydangky.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboPhong.Items.Clear();
            cboGiuong.Items.Clear();
        }

        private bool KiemTraDuLieu()
        {
            // [UIService.Require] kiểm tra bắt buộc nhập
            if (!UIService.Require(txtMaSV, "Vui lòng nhập Mã SV!")) return false;
            if (!UIService.Require(txtNamhoc, "Vui lòng nhập Năm học!")) return false;
            if (!UIService.Require(cboHocky, "Vui lòng chọn Học kỳ!")) return false;
            if (!UIService.Require(cboLoaiphong, "Vui lòng chọn Loại phòng!")) return false;

            // [UIService.MaxLength] kiểm tra độ dài tối đa
            if (!UIService.MaxLength(txtMaSV, 20, "Mã SV không được quá 20 ký tự!")) return false;
            if (!UIService.MaxLength(txtNamhoc, 20, "Năm học không được quá 20 ký tự!")) return false;

            // [UIService.ParseDate] kiểm tra định dạng ngày đăng ký
            if (!string.IsNullOrWhiteSpace(txtNgaydangky.Text) &&
                UIService.ParseDate(txtNgaydangky.Text) == null)
            {
                MessageBox.Show("Ngày đăng ký không đúng định dạng dd/MM/yyyy!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgaydangky.Focus();
                return false;
            }
            return true;
        }

        private void SetTrangThaiForm(bool choPhepNhap)
        {
            // [UIService.SetInputsEnabled] bật/tắt toàn bộ ô nhập
            // Form dùng TableLayoutPanel nên set từng panel chứa control nhập liệu
            UIService.SetInputsEnabled(tlpLeft1, choPhepNhap);
            UIService.SetInputsEnabled(tlpLeft3, choPhepNhap);

            // [UIService.SetButtonsEnabled] bật/tắt nút theo Tag "select"/"confirm"
            UIService.SetButtonsEnabled(this, choPhepNhap);

            // Các trường thông tin SV chỉ đọc (hệ thống tự điền)
            txtHoten.ReadOnly = true;
            txtLop.ReadOnly = true;
            txtKhoa.ReadOnly = true;
            txtSDT.ReadOnly = true;
            cboGioitinh.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dangThemMoi = true; dangSua = false;
            XoaForm();
            txtMadangky.Text = TaoMaDangKy();
            SetTrangThaiForm(true);
            txtMaSV.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDangkyoxepphong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đăng ký cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dangSua = true; dangThemMoi = false;
            SetTrangThaiForm(true);
            txtMaSV.Enabled = false;
            txtMadangky.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDangkyoxepphong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đăng ký cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [UIService.ConfirmDelete] hộp thoại xác nhận xóa
            if (!UIService.ConfirmDelete()) return;

            string maDK = dgvDangkyoxepphong.CurrentRow.Cells["MaDangKy"].Value?.ToString();

            _db.ExecuteNonQuery("DELETE FROM XepPhong WHERE MaDangKy = @MaDK",
                new SqlParameter("@MaDK", maDK));

            int rows = _db.ExecuteNonQuery("DELETE FROM DangKy WHERE MaDangKy = @MaDK",
                new SqlParameter("@MaDK", maDK));

            if (rows > 0)
            {
                MessageBox.Show("Xóa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                XoaForm();
                TaiDuLieu();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            string maDK = txtMadangky.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string namHoc = txtNamhoc.Text.Trim();
            string hocKy = cboHocky.Text;
            string loaiPhong = cboLoaiphong.Text;
            string trangThai = cboTrangthai.Text;
            string ghiChu = txtGhichu.Text.Trim();
            DateTime ngayDK = DateTime.Now;

            if (dangThemMoi)
            {
                string sqlDK = @"INSERT INTO DangKy (MaDangKy, MaSV, NgayDangKy, HocKy, NamHoc, 
                                 LoaiPhongMuon, DoiTuongUuTien, TrangThaiHoSo, GhiChu)
                                 VALUES (@MaDK, @MaSV, @NgayDK, @HocKy, @NamHoc,
                                 @LoaiPhong, N'Bình thường', @TrangThai, @GhiChu)";

                int r = _db.ExecuteNonQuery(sqlDK,
                    new SqlParameter("@MaDK", maDK),
                    new SqlParameter("@MaSV", maSV),
                    new SqlParameter("@NgayDK", ngayDK),
                    new SqlParameter("@HocKy", hocKy),
                    new SqlParameter("@NamHoc", namHoc),
                    new SqlParameter("@LoaiPhong", loaiPhong),
                    new SqlParameter("@TrangThai", string.IsNullOrEmpty(trangThai) ? "Chờ duyệt" : trangThai),
                    new SqlParameter("@GhiChu", ghiChu));

                if (r <= 0) return;

                if (cboPhong.SelectedValue != null && cboGiuong.SelectedIndex >= 0)
                {
                    string maXP = TaoMaXepPhong();
                    string maPhong = cboPhong.SelectedValue.ToString();
                    string giuong = cboGiuong.Text;
                    // [UIService.ParseDate] phân tích ngày vào ở
                    DateTime ngayVaoO = UIService.ParseDate(txtNgayvaoo.Text) ?? DateTime.Now;

                    _db.ExecuteNonQuery(
                        @"INSERT INTO XepPhong (MaXepPhong, MaDangKy, MaSV, MaPhong, 
                          Giuong, NgayVaoO, TrangThaiO, GhiChu)
                          VALUES (@MaXP, @MaDK, @MaSV, @MaPhong, @Giuong, @NgayVaoO, N'Đang ở', N'')",
                        new SqlParameter("@MaXP", maXP),
                        new SqlParameter("@MaDK", maDK),
                        new SqlParameter("@MaSV", maSV),
                        new SqlParameter("@MaPhong", maPhong),
                        new SqlParameter("@Giuong", giuong),
                        new SqlParameter("@NgayVaoO", ngayVaoO));
                }

                MessageBox.Show("Thêm đăng ký thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dangSua)
            {
                int r = _db.ExecuteNonQuery(
                    @"UPDATE DangKy SET HocKy=@HocKy, NamHoc=@NamHoc,
                      LoaiPhongMuon=@LoaiPhong, TrangThaiHoSo=@TrangThai, GhiChu=@GhiChu
                      WHERE MaDangKy=@MaDK",
                    new SqlParameter("@MaDK", maDK),
                    new SqlParameter("@HocKy", hocKy),
                    new SqlParameter("@NamHoc", namHoc),
                    new SqlParameter("@LoaiPhong", loaiPhong),
                    new SqlParameter("@TrangThai", trangThai),
                    new SqlParameter("@GhiChu", ghiChu));

                if (r > 0)
                    MessageBox.Show("Cập nhật thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dangThemMoi = false; dangSua = false;
            SetTrangThaiForm(false);
            TaiDuLieu();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dangThemMoi = false; dangSua = false;
            XoaForm();
            SetTrangThaiForm(false);
            if (dgvDangkyoxepphong.CurrentRow != null)
                HienThiLenForm(dgvDangkyoxepphong.CurrentRow);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            XoaForm(); TaiDuLieu(); txtTimkiem.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void dgvDangkyoxepphong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDangkyoxepphong.CurrentRow != null)
                HienThiLenForm(dgvDangkyoxepphong.CurrentRow);
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            TaiDuLieu(txtTimkiem.Text.Trim());
        }

        private string TaoMaDangKy()
        {
            DataTable dt = _db.ExecuteQuery(
                "SELECT TOP 1 MaDangKy FROM DangKy ORDER BY MaDangKy DESC");
            if (dt.Rows.Count == 0) return "DK001";
            string maCu = dt.Rows[0]["MaDangKy"].ToString();
            int soThu = int.Parse(maCu.Substring(2)) + 1;
            return "DK" + soThu.ToString("D3");
        }

        private string TaoMaXepPhong()
        {
            DataTable dt = _db.ExecuteQuery(
                "SELECT TOP 1 MaXepPhong FROM XepPhong ORDER BY MaXepPhong DESC");
            if (dt.Rows.Count == 0) return "XP001";
            string maCu = dt.Rows[0]["MaXepPhong"].ToString();
            int soThu = int.Parse(maCu.Substring(2)) + 1;
            return "XP" + soThu.ToString("D3");
        }

        private void lblTitle_Click(object sender, EventArgs e) { }
        private void tlpTop_Paint(object sender, PaintEventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
    }
}