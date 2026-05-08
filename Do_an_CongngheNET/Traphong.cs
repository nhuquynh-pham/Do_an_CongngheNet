using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Traphong : Form
    {
        // ================================================================
        // KHAI BÁO BIẾN DÙNG CHUNG
        // ================================================================
        private readonly DBService _db = new DBService();

        // Trạng thái form: true = đang thêm/sửa, false = chỉ xem
        private bool _dangChinhSua = false;

        // Lưu MaTraPhong đang chọn trên lưới
        private string _maTraPhongDangChon = null;

        // ================================================================
        // KHỞI TẠO FORM
        // ================================================================
        public Traphong()
        {
            InitializeComponent();

            this.btnNew.Click += btnNew_Click;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.btnEdit.Click += btnEdit_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnClose.Click += btnClose_Click;
            this.dgvTraphong.SelectionChanged += dgvTraphong_SelectionChanged;
            this.txtSearch.TextChanged += txtSearch_TextChanged;
            this.txtMsv.Leave += txtMsv_Leave;
            this.cboKhunha.SelectedIndexChanged += cboKhunha_SelectedIndexChanged;
        }
        private void lblTitle_Click(object sender, EventArgs e)
        {
           
        }

        private void tlpRoot_Paint(object sender, PaintEventArgs e)
        {
         
        }
        private void tlpContent_Paint(object sender, PaintEventArgs e)
        {
           
        }
        private void txtGhichu_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void dgvTraphong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        // ================================================================
        // SỰ KIỆN LOAD FORM
        // ================================================================
        private void Traphong_Load(object sender, EventArgs e)
        {
            UIService.SetGridStyle(dgvTraphong);

            // Nạp dữ liệu ban đầu
            LoadCboKhunha();
            LoadCboTrangthai();
            LoadDanhSachTraphong();

            // Mặc định trạng thái CHỈ XEM
            SetTrangThaiForm(false);
        }

        // ================================================================
        // THIẾT LẬP TRẠNG THÁI FORM
        // edit = false : chỉ xem (Thêm/Sửa/Xóa enabled, Ghi/Hủy disabled)
        // edit = true  : đang nhập liệu (Ghi/Hủy enabled, còn lại disabled)
        // ================================================================
        private void SetTrangThaiForm(bool edit)
        {
            _dangChinhSua = edit;

            // Điều khiển ô nhập liệu
            UIService.SetInputsEnabled(tlpInputs, edit);
            UIService.SetInputsReadOnly(tlpInputs, !edit);

            // Mã trả phòng và họ tên luôn readonly (tự sinh / tự điền)
            txtmatraphong.ReadOnly = true;
            txtHoten.ReadOnly = true;
            txtNgayvaoo.ReadOnly = true;

            // Nút lệnh theo trạng thái
            btnNew.Enabled = !edit;
            btnEdit.Enabled = !edit && _maTraPhongDangChon != null;
            btnDelete.Enabled = !edit && _maTraPhongDangChon != null;
            btnSave.Enabled = edit;
            btnCancel.Enabled = edit;

            // Lưới chỉ được chọn khi không chỉnh sửa
            dgvTraphong.Enabled = !edit;
            txtSearch.Enabled = !edit;
        }

        // ================================================================
        // NẠP COMBO BOX KHU NHÀ
        // ================================================================
        private void LoadCboKhunha()
        {
            DataTable dt = _db.ExecuteQuery(
                "SELECT MaKhu, TenKhu FROM KhuNha WHERE TrangThai = N'Đang sử dụng' ORDER BY TenKhu");

            cboKhunha.DataSource = dt;
            cboKhunha.DisplayMember = "TenKhu";
            cboKhunha.ValueMember = "MaKhu";
            cboKhunha.SelectedIndex = -1;
        }

        // ================================================================
        // NẠP COMBO BOX PHÒNG THEO KHU NHÀ
        // ================================================================
        private void LoadCboPhong(string maKhu)
        {
            cboPhongdango.DataSource = null;
            cboGiuong.DataSource = null;

            if (string.IsNullOrEmpty(maKhu)) return;

            DataTable dt = _db.ExecuteQuery(
                "SELECT MaPhong, SoPhong FROM Phong WHERE MaKhu = @maKhu ORDER BY SoPhong",
                new SqlParameter("@maKhu", maKhu));

            cboPhongdango.DataSource = dt;
            cboPhongdango.DisplayMember = "SoPhong";
            cboPhongdango.ValueMember = "MaPhong";
            cboPhongdango.SelectedIndex = -1;
        }

        // ================================================================
        // NẠP COMBO BOX GIƯỜNG (tĩnh)
        // ================================================================
        private void LoadCboGiuong()
        {
            cboGiuong.Items.Clear();
            for (int i = 1; i <= 8; i++)
                cboGiuong.Items.Add("Giường " + i);
            cboGiuong.SelectedIndex = -1;
        }

        // ================================================================
        // NẠP COMBO BOX TRẠNG THÁI
        // ================================================================
        private void LoadCboTrangthai()
        {
            cboTrangthai.Items.Clear();
            cboTrangthai.Items.Add("Đã trả");
            cboTrangthai.Items.Add("Chờ xác nhận");
            cboTrangthai.SelectedIndex = -1;
        }

        // ================================================================
        // NẠP DANH SÁCH TRẢ PHÒNG LÊN LƯỚI
        // ================================================================
        private void LoadDanhSachTraphong(string keyword = "")
        {
            string sql = @"
                SELECT tp.MaTraPhong, tp.MaSV, sv.HoTen,
                       tp.MaPhong, tp.Giuong,
                       tp.NgayVaoO, tp.NgayTraPhong,
                       tp.LyDoTra, tp.TrangThai, tp.GhiChu
                FROM TraPhong tp
                INNER JOIN SinhVien sv ON tp.MaSV = sv.MaSV
                WHERE tp.MaSV  LIKE @keyword
                   OR sv.HoTen LIKE @keyword
                   OR tp.MaPhong LIKE @keyword
                ORDER BY tp.MaTraPhong DESC";

            DataTable dt = _db.ExecuteQuery(sql,
                new SqlParameter("@keyword", "%" + keyword + "%"));

            dgvTraphong.DataSource = dt;

            UIService.SetGridHeader(dgvTraphong,
                "Mã trả phòng", "Mã SV", "Họ tên",
                "Phòng", "Giường",
                "Ngày vào ở", "Ngày trả phòng",
                "Lý do trả", "Trạng thái", "Ghi chú");
        }

        // ================================================================
        // SINH MÃ TRẢ PHÒNG TỰ ĐỘNG
        // Dạng: TP001, TP002, ...
        // ================================================================
        private string SinhMaTraPhong()
        {
            object result = _db.ExecuteScalar(
                "SELECT MAX(MaTraPhong) FROM TraPhong");

            if (result == null || result == DBNull.Value)
                return "TP001";

            string maMax = result.ToString(); // VD: TP005
            int soThuTu = int.Parse(maMax.Substring(2)) + 1;
            return "TP" + soThuTu.ToString("D3");
        }

        // ================================================================
        // NẠP THÔNG TIN SINH VIÊN KHI NHẬP MÃ SV (sự kiện Leave)
        // Tự động điền họ tên, khu nhà, phòng, giường, ngày vào ở
        // ================================================================
        private void txtMsv_Leave(object sender, EventArgs e)
        {
            string maSV = txtMsv.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(maSV)) return;

            // Lấy thông tin sinh viên và phòng đang ở từ XepPhong
            string sql = @"
                SELECT sv.HoTen,
                       kn.MaKhu, kn.TenKhu,
                       p.MaPhong, p.SoPhong,
                       xp.Giuong, xp.NgayVaoO
                FROM SinhVien sv
                INNER JOIN XepPhong xp ON sv.MaSV = xp.MaSV
                INNER JOIN Phong p     ON xp.MaPhong = p.MaPhong
                INNER JOIN KhuNha kn   ON p.MaKhu = kn.MaKhu
                WHERE sv.MaSV = @maSV
                  AND xp.TrangThaiO = N'Đang ở'";

            DataTable dt = _db.ExecuteQuery(sql,
                new SqlParameter("@maSV", maSV));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy sinh viên đang ở phòng với mã: " + maSV,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMsv.Clear();
                txtHoten.Clear();
                cboKhunha.SelectedIndex = -1;
                cboPhongdango.SelectedIndex = -1;
                cboGiuong.SelectedIndex = -1;
                txtNgayvaoo.Clear();
                return;
            }

            DataRow row = dt.Rows[0];

            // Điền thông tin
            txtHoten.Text = row["HoTen"].ToString();
            txtNgayvaoo.Text = UIService.FormatDate(row["NgayVaoO"]);

            // Set khu nhà → sẽ trigger cboKhunha_SelectedIndexChanged nạp phòng
            cboKhunha.SelectedValue = row["MaKhu"].ToString();

            // Sau khi nạp phòng, chọn phòng và giường tương ứng
            cboPhongdango.SelectedValue = row["MaPhong"].ToString();

            string giuong = row["Giuong"].ToString();
            cboGiuong.SelectedItem = giuong;
        }

        // ================================================================
        // SỰ KIỆN CHỌN KHU NHÀ → NẠP LẠI DANH SÁCH PHÒNG
        // ================================================================
        private void cboKhunha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhunha.SelectedValue == null) return;
            LoadCboPhong(cboKhunha.SelectedValue.ToString());
        }

        // ================================================================
        // SỰ KIỆN CHỌN DÒNG TRÊN LƯỚI → ĐỔ DỮ LIỆU LÊN FORM
        // ================================================================
        private void dgvTraphong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTraphong.CurrentRow == null) return;

            _maTraPhongDangChon = dgvTraphong
                .CurrentRow.Cells["MaTraPhong"].Value?.ToString();

            if (string.IsNullOrEmpty(_maTraPhongDangChon)) return;

            LoadThongTinTraphong(_maTraPhongDangChon);

            // Cập nhật trạng thái nút Sửa/Xóa
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        // ================================================================
        // NẠP THÔNG TIN TRẢ PHÒNG LÊN FORM KHI CHỌN DÒNG
        // ================================================================
        private void LoadThongTinTraphong(string maTraPhong)
        {
            string sql = @"
                SELECT tp.MaTraPhong, tp.MaSV, sv.HoTen,
                       p.MaKhu, tp.MaPhong, tp.Giuong,
                       tp.NgayVaoO, tp.NgayTraPhong,
                       tp.LyDoTra, tp.TrangThai, tp.GhiChu
                FROM TraPhong tp
                INNER JOIN SinhVien sv ON tp.MaSV = sv.MaSV
                INNER JOIN Phong p     ON tp.MaPhong = p.MaPhong
                WHERE tp.MaTraPhong = @maTraPhong";

            DataTable dt = _db.ExecuteQuery(sql,
                new SqlParameter("@maTraPhong", maTraPhong));

            if (dt.Rows.Count == 0) return;

            DataRow row = dt.Rows[0];

            txtmatraphong.Text = row["MaTraPhong"].ToString();
            txtMsv.Text = row["MaSV"].ToString();
            txtHoten.Text = row["HoTen"].ToString();
            txtNgayvaoo.Text = UIService.FormatDate(row["NgayVaoO"]);
            txtNgaytraphong.Text = UIService.FormatDate(row["NgayTraPhong"]);
            txtLydotra.Text = row["LyDoTra"].ToString();
            txtGhichu.Text = row["GhiChu"].ToString();

            // Nạp khu nhà trước để có danh sách phòng
            cboKhunha.SelectedValue = row["MaKhu"].ToString();
            cboPhongdango.SelectedValue = row["MaPhong"].ToString();
            cboGiuong.SelectedItem = row["Giuong"].ToString();
            cboTrangthai.SelectedItem = row["TrangThai"].ToString();
        }

        // ================================================================
        // XÓA TRẮNG FORM
        // ================================================================
        private void XoaTrangForm()
        {
            txtmatraphong.Clear();
            txtMsv.Clear();
            txtHoten.Clear();
            txtNgayvaoo.Clear();
            txtNgaytraphong.Clear();
            txtLydotra.Clear();
            txtGhichu.Clear();
            cboKhunha.SelectedIndex = -1;
            cboPhongdango.SelectedIndex = -1;
            cboGiuong.SelectedIndex = -1;
            cboTrangthai.SelectedIndex = -1;
        }

        // ================================================================
        // KIỂM TRA DỮ LIỆU BẮT BUỘC TRƯỚC KHI GHI
        // ================================================================
        private bool KiemTraDuLieu()
        {
            if (!UIService.Require(txtMsv, "Vui lòng nhập mã sinh viên!"))
                return false;
            if (!UIService.Require(txtNgaytraphong, "Vui lòng nhập ngày trả phòng!"))
                return false;
            if (!UIService.Require(cboTrangthai, "Vui lòng chọn trạng thái!"))
                return false;

            // Kiểm tra định dạng ngày
            if (UIService.ParseDate(txtNgaytraphong.Text) == null)
            {
                MessageBox.Show("Ngày trả phòng không đúng định dạng dd/MM/yyyy!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaytraphong.Focus();
                return false;
            }

            return true;
        }

        // ================================================================
        // NÚT THÊM MỚI
        // ================================================================
        private void btnNew_Click(object sender, EventArgs e)
        {
            XoaTrangForm();
            _maTraPhongDangChon = null;

            // Sinh mã tự động
            txtmatraphong.Text = SinhMaTraPhong();

            // Mặc định ngày trả phòng là hôm nay
            txtNgaytraphong.Text = DateTime.Today.ToString("dd/MM/yyyy");

            SetTrangThaiForm(true);
            txtMsv.Focus();
        }

        // ================================================================
        // NÚT GHI – LƯU DỮ LIỆU (THÊM MỚI HOẶC CẬP NHẬT)
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            string maTraPhong = txtmatraphong.Text.Trim();
            string maSV = txtMsv.Text.Trim().ToUpper();
            string maPhong = cboPhongdango.SelectedValue?.ToString() ?? "";
            string giuong = cboGiuong.SelectedItem?.ToString() ?? "";
            DateTime? ngayVaoO = UIService.ParseDate(txtNgayvaoo.Text);
            DateTime? ngayTraPhong = UIService.ParseDate(txtNgaytraphong.Text);
            string lyDoTra = txtLydotra.Text.Trim();
            string trangThai = cboTrangthai.SelectedItem?.ToString() ?? "";
            string ghiChu = txtGhichu.Text.Trim();

            // Kiểm tra đã tồn tại bản ghi chưa
            int count = Convert.ToInt32(_db.ExecuteScalar(
                "SELECT COUNT(*) FROM TraPhong WHERE MaTraPhong = @ma",
                new SqlParameter("@ma", maTraPhong)));

            if (count == 0)
            {
                // INSERT mới
                string sql = @"
                    INSERT INTO TraPhong
                        (MaTraPhong, MaSV, MaPhong, Giuong, NgayVaoO, NgayTraPhong, LyDoTra, TrangThai, GhiChu)
                    VALUES
                        (@maTP, @maSV, @maPhong, @giuong, @ngayVao, @ngayTra, @lyDo, @trangThai, @ghiChu)";

                _db.ExecuteNonQuery(sql,
                    new SqlParameter("@maTP", maTraPhong),
                    new SqlParameter("@maSV", maSV),
                    new SqlParameter("@maPhong", maPhong),
                    new SqlParameter("@giuong", giuong),
                    new SqlParameter("@ngayVao", (object)ngayVaoO ?? DBNull.Value),
                    new SqlParameter("@ngayTra", (object)ngayTraPhong ?? DBNull.Value),
                    new SqlParameter("@lyDo", lyDoTra),
                    new SqlParameter("@trangThai", trangThai),
                    new SqlParameter("@ghiChu", ghiChu));

                // Cập nhật trạng thái XepPhong → "Đã trả"
                if (!string.IsNullOrEmpty(maPhong))
                {
                    _db.ExecuteNonQuery(@"
                        UPDATE XepPhong
                        SET TrangThaiO = N'Đã trả'
                        WHERE MaSV = @maSV AND MaPhong = @maPhong AND TrangThaiO = N'Đang ở'",
                        new SqlParameter("@maSV", maSV),
                        new SqlParameter("@maPhong", maPhong));
                }

                MessageBox.Show("Thêm mới trả phòng thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // UPDATE
                string sql = @"
                    UPDATE TraPhong SET
                        MaSV         = @maSV,
                        MaPhong      = @maPhong,
                        Giuong       = @giuong,
                        NgayVaoO     = @ngayVao,
                        NgayTraPhong = @ngayTra,
                        LyDoTra      = @lyDo,
                        TrangThai    = @trangThai,
                        GhiChu       = @ghiChu
                    WHERE MaTraPhong = @maTP";

                _db.ExecuteNonQuery(sql,
                    new SqlParameter("@maSV", maSV),
                    new SqlParameter("@maPhong", maPhong),
                    new SqlParameter("@giuong", giuong),
                    new SqlParameter("@ngayVao", (object)ngayVaoO ?? DBNull.Value),
                    new SqlParameter("@ngayTra", (object)ngayTraPhong ?? DBNull.Value),
                    new SqlParameter("@lyDo", lyDoTra),
                    new SqlParameter("@trangThai", trangThai),
                    new SqlParameter("@ghiChu", ghiChu),
                    new SqlParameter("@maTP", maTraPhong));

                MessageBox.Show("Cập nhật trả phòng thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadDanhSachTraphong();
            SetTrangThaiForm(false);
        }

        // ================================================================
        // NÚT SỬA
        // ================================================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maTraPhongDangChon))
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SetTrangThaiForm(true);

            // Khóa mã trả phòng và mã sinh viên khi sửa
            txtmatraphong.ReadOnly = true;
            txtMsv.ReadOnly = true;

            txtNgaytraphong.Focus();
        }

        // ================================================================
        // NÚT HỦY GHI – Quay về trạng thái xem
        // ================================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_maTraPhongDangChon != null)
                LoadThongTinTraphong(_maTraPhongDangChon);
            else
                XoaTrangForm();

            SetTrangThaiForm(false);
        }

        // ================================================================
        // NÚT XÓA
        // ================================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maTraPhongDangChon))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!UIService.ConfirmDelete()) return;

            _db.ExecuteNonQuery(
                "DELETE FROM TraPhong WHERE MaTraPhong = @ma",
                new SqlParameter("@ma", _maTraPhongDangChon));

            MessageBox.Show("Xóa thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _maTraPhongDangChon = null;
            XoaTrangForm();
            LoadDanhSachTraphong();
            SetTrangThaiForm(false);
        }

        // ================================================================
        // SỰ KIỆN TÌM KIẾM REALTIME
        // ================================================================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachTraphong(txtSearch.Text.Trim());
        }

        // ================================================================
        // NÚT KẾT THÚC – Đóng form
        // ================================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}