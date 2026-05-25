using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Laphoadon : Form
    {
        // ================================================================
        private readonly DBService _db = new DBService();
        private SaveMode _saveMode = SaveMode.Insert;

        // Mã hóa đơn hiện tại đang làm việc
        private string _currentMaHoaDon = "";
        // Mã sinh viên được chọn từ lưới
        private string _selectedMaSV = "";
        // Mã phòng của sinh viên
        private string _selectedMaPhong = "";

        // ================================================================
        // KHỞI TẠO
        // ================================================================
        public Laphoadon()
        {
            InitializeComponent();
            SetupEvents();
        }

        private void SetupEvents()
        {
            // Thiết lập sự kiện tìm kiếm
            txtTimkiem.TextChanged += TxtTimkiem_TextChanged;
            txtTimkiemtheoten.TextChanged += TxtTimkiemtheoten_TextChanged;

            // Khi chọn sinh viên trên lưới
            dgvSupperlier.SelectionChanged += DgvSupperlier_SelectionChanged;

            // Khi click nút
            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnClose.Click += BtnClose_Click;
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;

            // Load form
            this.Load += Laphoadon_Load;
        }

        // ================================================================
        // LOAD FORM
        // ================================================================
        private void Laphoadon_Load(object sender, EventArgs e)
        {
            // Thiết lập style lưới
            UIService.SetGridStyle(dgvSupperlier);
            UIService.SetGridStyle(dgvProduct);
            UIService.SetGridStyle(dgvPurchaseDetail);

            // Load danh sách sinh viên
            LoadSinhVien();

            // Trạng thái ban đầu: chỉ xem, chưa tạo hóa đơn
            SetFormState(false);

            // Tạo mới hóa đơn ngay khi mở
            BtnNew_Click(null, null);
        }

        // ================================================================
        // THIẾT LẬP TRẠNG THÁI FORM
        // ================================================================
        private void SetFormState(bool isEditing)
        {
            // Các trường thông tin hóa đơn chỉ đọc (tự động lấy từ SV)
            txtTensinhvien.ReadOnly = true;
            txtMasinhvien.ReadOnly = true;
            txtSophong.ReadOnly = true;
            txtKhunha.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtNgaylaphoadon.ReadOnly = !isEditing;

            btnSave.Enabled = isEditing;
            btnCancel.Enabled = isEditing;
            btnAdd.Enabled = isEditing;
            btnRemove.Enabled = isEditing;
            btnNew.Enabled = !isEditing;
        }

        // ================================================================
        // TẠO MÃ HÓA ĐƠN MỚI TỰ ĐỘNG
        // ================================================================
        private string GenerateMaHoaDon()
        {
            string sql = "SELECT MAX(MaHoaDon) FROM HoaDon";
            object result = _db.ExecuteScalar(sql);
            if (result == null || result == DBNull.Value)
                return "HD001";

            string last = result.ToString(); // HD001
            string num = last.Substring(2);
            int next = int.Parse(num) + 1;
            return "HD" + next.ToString("D3");
        }

        private string GenerateMaCTHD()
        {
            string sql = "SELECT MAX(MaCTHD) FROM ChiTietHoaDon";
            object result = _db.ExecuteScalar(sql);
            if (result == null || result == DBNull.Value)
                return "CT001";

            string last = result.ToString();
            string num = last.Substring(2);
            int next = int.Parse(num) + 1;
            return "CT" + next.ToString("D3");
        }

        // ================================================================
        // LOAD SINH VIÊN LÊN LƯỚI (Tìm theo MSV)
        // ================================================================
        private void LoadSinhVien(string filterMSV = "")
        {
            string sql = @"
                SELECT sv.MaSV, sv.HoTen, xp.MaPhong, p.SoPhong, k.TenKhu
                FROM SinhVien sv
                LEFT JOIN XepPhong xp ON sv.MaSV = xp.MaSV AND xp.TrangThaiO = N'Đang ở'
                LEFT JOIN Phong p ON xp.MaPhong = p.MaPhong
                LEFT JOIN KhuNha k ON p.MaKhu = k.MaKhu
                WHERE sv.TrangThai = N'Đang học'";

            SqlParameter[] prm = null;

            if (!string.IsNullOrWhiteSpace(filterMSV))
            {
                sql += " AND sv.MaSV LIKE @msv";
                prm = new[] { new SqlParameter("@msv", "%" + filterMSV + "%") };
            }

            sql += " ORDER BY sv.MaSV";

            DataTable dt = prm != null ? _db.ExecuteQuery(sql, prm) : _db.ExecuteQuery(sql);
            dgvSupperlier.DataSource = dt;
            UIService.SetGridHeader(dgvSupperlier, "Mã SV", "Họ tên", "Mã phòng", "Số phòng", "Khu nhà");
        }

        // ================================================================
        // LOAD DỊCH VỤ / TIỀN PHÒNG (Phiếu điện nước của phòng SV)
        // hiển thị lên dgvProduct (bên dưới bên trái)
        // ================================================================
        private void LoadDienNuocByPhong(string maPhong)
        {
            if (string.IsNullOrEmpty(maPhong))
            {
                dgvProduct.DataSource = null;
                return;
            }
            string sql = @"
                SELECT dn.MaPhieu,
                       CAST(dn.Thang AS NVARCHAR) + '/' + CAST(dn.Nam AS NVARCHAR) AS [Thang_Nam],
                       p.GiaPhong AS TienPhong,
                       dn.TienDien,
                       dn.TienNuoc,
                       (p.GiaPhong + dn.TienDien + dn.TienNuoc) AS TongTien,
                       dn.Thang,
                       dn.Nam
                FROM DienNuoc dn
                JOIN Phong p ON dn.MaPhong = p.MaPhong
                WHERE dn.MaPhong = @maPhong
                ORDER BY dn.Nam DESC, dn.Thang DESC";

            DataTable dt = _db.ExecuteQuery(sql, new SqlParameter("@maPhong", maPhong));
            dgvProduct.DataSource = dt;
            UIService.SetGridHeader(dgvProduct, 
                "Mã phiếu", "Tháng/Năm", "Tiền phòng", "Tiền điện", "Tiền nước", "Tổng tiền", "Tháng", "Năm");
        }

        // ================================================================
        // KHI CHỌN SINH VIÊN TRÊN LƯỚI
        // ================================================================
        private void DgvSupperlier_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSupperlier.CurrentRow == null) return;

            DataGridViewRow row = dgvSupperlier.CurrentRow;
            _selectedMaSV = row.Cells[0].Value?.ToString() ?? "";
            _selectedMaPhong = row.Cells[2].Value?.ToString() ?? "";

            // Điền thông tin sang panel hóa đơn
            txtMasinhvien.Text = _selectedMaSV;
            txtTensinhvien.Text = row.Cells[1].Value?.ToString() ?? "";
            txtSophong.Text = row.Cells[3].Value?.ToString() ?? "";
            txtKhunha.Text = row.Cells[4].Value?.ToString() ?? "";

            // Load điện nước của phòng sinh viên mới chọn
            LoadDienNuocByPhong(_selectedMaPhong);

            // KHÔNG xóa dgvPurchaseDetail ở đây
            // Chi tiết hóa đơn chỉ bị xóa khi nhấn "Tạo mới" hoặc "Hủy"
        }

        // ================================================================
        // TÌM KIẾM THEO MSV
        // ================================================================
        private void TxtTimkiem_TextChanged(object sender, EventArgs e)
        {
            LoadSinhVien(txtTimkiem.Text.Trim());
        }

        // ================================================================
        // TÌM KIẾM THEO TÊN (lọc dgvProduct theo tên phiếu/tháng)
        // ================================================================
        private void TxtTimkiemtheoten_TextChanged(object sender, EventArgs e)
        {
            if (dgvProduct.DataSource == null) return;
            string filter = txtTimkiemtheoten.Text.Trim();

            if (dgvProduct.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.IsNullOrWhiteSpace(filter)
                    ? ""
                    : $"Thang_Nam LIKE '%{filter}%'";
            }
        }

        // ================================================================
        // NÚT TẠO MỚI HÓA ĐƠN
        // ================================================================
        private void BtnNew_Click(object sender, EventArgs e)
        {
            _saveMode = SaveMode.Insert;
            _currentMaHoaDon = GenerateMaHoaDon();

            // Xóa chi tiết hóa đơn
            dgvPurchaseDetail.DataSource = null;

            // Ngày lập mặc định hôm nay
            txtNgaylaphoadon.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtTongtien.Text = "";

            // Cho phép chỉnh sửa
            SetFormState(true);
        }

        // ================================================================
        // NÚT THÊM PHIẾU ĐIỆN NƯỚC VÀO CHI TIẾT HÓA ĐƠN (nút >)
        // ================================================================
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu điện nước cần thêm vào hóa đơn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(_selectedMaSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên trước.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow srcRow = dgvProduct.CurrentRow;
            string maPhieu = srcRow.Cells[0].Value?.ToString() ?? "";
            string thangNam = srcRow.Cells[1].Value?.ToString() ?? "";
            int tienPhong = Convert.ToInt32(srcRow.Cells[2].Value ?? 0);
            int tienDien = Convert.ToInt32(srcRow.Cells[3].Value ?? 0);
            int tienNuoc = Convert.ToInt32(srcRow.Cells[4].Value ?? 0);
            int tongTien = Convert.ToInt32(srcRow.Cells[5].Value ?? 0);

            // Kiểm tra đã thêm chưa
            if (dgvPurchaseDetail.DataSource is DataTable dtCheck)
            {
                foreach (DataRow r in dtCheck.Rows)
                {
                    if (r["MaPhieu"]?.ToString() == maPhieu)
                    {
                        MessageBox.Show("Phiếu này đã có trong hóa đơn.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // Tạo DataTable cho chi tiết nếu chưa có
            if (!(dgvPurchaseDetail.DataSource is DataTable dt))
            {
                dt = new DataTable();
                dt.Columns.Add("MaPhieu");
                dt.Columns.Add("Tháng/Năm");
                dt.Columns.Add("Tiền phòng", typeof(int));
                dt.Columns.Add("Tiền điện", typeof(int));
                dt.Columns.Add("Tiền nước", typeof(int));
                dt.Columns.Add("Tổng tiền", typeof(int));
                dgvPurchaseDetail.DataSource = dt;
                UIService.SetGridStyle(dgvPurchaseDetail);
            }

            dt.Rows.Add(maPhieu, thangNam, tienPhong, tienDien, tienNuoc, tongTien);
            TinhTongTien(dt);
        }

        // ================================================================
        // NÚT XÓA KHỎI CHI TIẾT HÓA ĐƠN (nút <)
        // ================================================================
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseDetail.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa trong hóa đơn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!(dgvPurchaseDetail.DataSource is DataTable dt)) return;

            int idx = dgvPurchaseDetail.CurrentRow.Index;
            dt.Rows[idx].Delete();
            dt.AcceptChanges();
            TinhTongTien(dt);
        }

        // ================================================================
        // TÍNH TỔNG TIỀN
        // ================================================================
        private void TinhTongTien(DataTable dt)
        {
            long tong = 0;
            foreach (DataRow row in dt.Rows)
            {
                tong += Convert.ToInt64(row["Tổng tiền"]);
            }
            txtTongtien.Text = tong.ToString("N0") + " VNĐ";
        }

        // ================================================================
        // NÚT GHI (LƯU HÓA ĐƠN)
        // ================================================================
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (!UIService.Require(txtMasinhvien, "Vui lòng chọn sinh viên!")) return;
            if (!UIService.Require(txtNgaylaphoadon, "Vui lòng nhập ngày lập hóa đơn!")) return;

            DateTime? ngayLap = UIService.ParseDate(txtNgaylaphoadon.Text);
            if (ngayLap == null)
            {
                MessageBox.Show("Ngày lập hóa đơn không hợp lệ. Định dạng: dd/MM/yyyy",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaylaphoadon.Focus();
                return;
            }

            if (!(dgvPurchaseDetail.DataSource is DataTable dtDetail) || dtDetail.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một phiếu điện nước vào hóa đơn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính tổng tiền
            long tongTien = 0;
            foreach (DataRow r in dtDetail.Rows)
                tongTien += Convert.ToInt64(r["Tổng tiền"]);

            // Lấy tháng/năm từ dòng đầu tiên
            string thangNam = dtDetail.Rows[0]["Tháng/Năm"]?.ToString() ?? "";
            int thang = 0, nam = 0;
            if (!string.IsNullOrEmpty(thangNam))
            {
                var parts = thangNam.Split('/');
                if (parts.Length == 2)
                {
                    int.TryParse(parts[0], out thang);
                    int.TryParse(parts[1], out nam);
                }
            }

            try
            {
                if (_saveMode == SaveMode.Insert)
                {
                    // Kiểm tra hóa đơn đã tồn tại chưa
                    string checkSql = "SELECT COUNT(*) FROM HoaDon WHERE MaSV=@sv AND MaPhong=@mp AND Thang=@t AND Nam=@n";
                    int existing = Convert.ToInt32(_db.ExecuteScalar(checkSql,
                        new SqlParameter("@sv", _selectedMaSV),
                        new SqlParameter("@mp", _selectedMaPhong),
                        new SqlParameter("@t", thang),
                        new SqlParameter("@n", nam)));

                    if (existing > 0)
                    {
                        MessageBox.Show("Đã tồn tại hóa đơn cho sinh viên này trong tháng/năm đã chọn.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Thêm HoaDon
                    string sqlHD = @"INSERT INTO HoaDon (MaHoaDon, MaSV, MaPhong, Thang, Nam, NgayLap, TrangThai)
                                     VALUES (@mahd, @sv, @mp, @t, @n, @ngay, N'Chưa thanh toán')";
                    _db.ExecuteNonQuery(sqlHD,
                        new SqlParameter("@mahd", _currentMaHoaDon),
                        new SqlParameter("@sv", _selectedMaSV),
                        new SqlParameter("@mp", _selectedMaPhong),
                        new SqlParameter("@t", thang),
                        new SqlParameter("@n", nam),
                        new SqlParameter("@ngay", ngayLap.Value));

                    // Thêm ChiTietHoaDon
                    string maCTHD = GenerateMaCTHD();
                    long tienPhongTong = 0, tienDienTong = 0, tienNuocTong = 0;
                    foreach (DataRow r in dtDetail.Rows)
                    {
                        tienPhongTong += Convert.ToInt64(r["Tiền phòng"]);
                        tienDienTong += Convert.ToInt64(r["Tiền điện"]);
                        tienNuocTong += Convert.ToInt64(r["Tiền nước"]);
                    }

                    string sqlCT = @"INSERT INTO ChiTietHoaDon (MaCTHD, MaHoaDon, TienPhong, TienDien, TienNuoc, PhuPhi, TongTien)
                                     VALUES (@mact, @mahd, @tp, @td, @tn, 0, @tt)";
                    _db.ExecuteNonQuery(sqlCT,
                        new SqlParameter("@mact", maCTHD),
                        new SqlParameter("@mahd", _currentMaHoaDon),
                        new SqlParameter("@tp", (int)tienPhongTong),
                        new SqlParameter("@td", (int)tienDienTong),
                        new SqlParameter("@tn", (int)tienNuocTong),
                        new SqlParameter("@tt", (int)tongTien));

                    MessageBox.Show($"Lập hóa đơn thành công!\nMã hóa đơn: {_currentMaHoaDon}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                SetFormState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================================
        // NÚT HỦY
        // ================================================================
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Hủy việc tạo hóa đơn, quay về trạng thái xem
            dgvPurchaseDetail.DataSource = null;
            txtNgaylaphoadon.Text = "";
            txtTongtien.Text = "";
            _currentMaHoaDon = "";
            SetFormState(false);
        }

        // ================================================================
        // NÚT KẾT THÚC
        // ================================================================
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================================================================
        // CÁC SỰ KIỆN TRỐNG TỪ DESIGNER
        // ================================================================
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void tlpSupperlier_Paint(object sender, PaintEventArgs e) { }
        private void pnlTitle_Paint(object sender, PaintEventArgs e) { }

        private void dgvSupperlier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}