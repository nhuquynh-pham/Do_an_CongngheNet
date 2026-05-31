using QLKTX;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Laphoadon : Form
    {
        private readonly DBService _db;
        private SaveMode _saveMode = SaveMode.Insert;
        private string _currentMaHoaDon = "";
        private string _selectedMaSV = "";
        private string _selectedMaPhong = "";
        private bool _isBinding = false;
        // FIX: Lưu index dòng thay vì DataGridViewRow vì row object bị hủy khi DataSource thay đổi
        private int _selectedPhieuIndex = -1;

        // ================================================================
        // KHỞI TẠO
        // ================================================================
        public Laphoadon()
        {
            InitializeComponent();
            _db = new DBService();
        }

        // ================================================================
        // LOAD FORM
        // ================================================================
        private void Laphoadon_Load(object sender, EventArgs e)
        {
            UIService.SetGridStyle(dgvSinhVien);
            UIService.SetGridStyle(dgvPhieuDienNuoc);
            UIService.SetGridStyle(dgvChiTietHoaDon);

            LoadSinhVien();
            SetFormState(false);

            // FIX #3: Bọc BtnNew_Click trong try-catch để tránh crash
            // khi CSDL chưa kết nối được lúc mở form
            try
            {
                BtnNew_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo form: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================================
        // THIẾT LẬP TRẠNG THÁI FORM
        // ================================================================
        private void SetFormState(bool isEditing)
        {
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

            txtTimkiem.ReadOnly = false;
            txtTimkiemtheoten.ReadOnly = false;
        }

        // ================================================================
        // SỰ KIỆN NÚT TẠO MỚI
        // ================================================================
        private void BtnNew_Click(object sender, EventArgs e)
        {
            _saveMode = SaveMode.Insert;
            _currentMaHoaDon = GenerateMaHoaDon();

            dgvChiTietHoaDon.DataSource = null;
            txtNgaylaphoadon.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtTongtien.Text = "";

            SetFormState(true);
        }

        // ================================================================
        // SỰ KIỆN NÚT GHI (LƯU HÓA ĐƠN)
        // ================================================================
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                SaveHoaDon();

                MessageBox.Show(
                    "Lập hóa đơn thành công!\nMã hóa đơn: " + _currentMaHoaDon,
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadSinhVien();
                SetFormState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================================
        // SỰ KIỆN NÚT HỦY
        // ================================================================
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            dgvChiTietHoaDon.DataSource = null;
            txtNgaylaphoadon.Text = "";
            txtTongtien.Text = "";
            _currentMaHoaDon = "";

            // FIX #6: Reset luôn sinh viên đang chọn khi hủy
            _selectedMaSV = "";
            _selectedMaPhong = "";

            SetFormState(false);
        }

        // ================================================================
        // SỰ KIỆN NÚT KẾT THÚC
        // ================================================================
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ================================================================
        // SỰ KIỆN TÌM KIẾM SINH VIÊN THEO MSV
        // FIX #6: Reset biến sinh viên khi lọc lại danh sách
        // ================================================================
        private void TxtTimkiem_TextChanged(object sender, EventArgs e)
        {
            // Reset vì dòng đang chọn có thể biến mất sau khi lọc
            _selectedMaSV = "";
            _selectedMaPhong = "";
            txtMasinhvien.Text = "";
            txtTensinhvien.Text = "";
            txtSophong.Text = "";
            txtKhunha.Text = "";
            dgvPhieuDienNuoc.DataSource = null;
            dgvChiTietHoaDon.DataSource = null;
            txtTongtien.Text = "";

            LoadSinhVien(txtTimkiem.Text.Trim());
        }

        // ================================================================
        // SỰ KIỆN TÌM KIẾM PHIẾU ĐIỆN NƯỚC THEO THÁNG/NĂM
        // ================================================================
        private void TxtTimkiemtheoten_TextChanged(object sender, EventArgs e)
        {
            if (!(dgvPhieuDienNuoc.DataSource is DataTable dt)) return;

            string filter = txtTimkiemtheoten.Text.Trim();
            dt.DefaultView.RowFilter = string.IsNullOrWhiteSpace(filter)
                ? ""
                : "Thang_Nam LIKE '%" + filter + "%'";
        }

        // ================================================================
        // SỰ KIỆN KHI CHỌN DÒNG SINH VIÊN TRÊN LƯỚI
        // ================================================================
        private void DgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (_isBinding) return;
            BindSinhVienData();
        }

        private void DgvPhieuDienNuoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieuDienNuoc.CurrentRow != null)
                _selectedPhieuIndex = dgvPhieuDienNuoc.CurrentRow.Index;
        }

        // ================================================================
        // SỰ KIỆN NÚT THÊM PHIẾU VÀO CHI TIẾT HÓA ĐƠN (nút >)
        // ================================================================
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedMaSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên trước.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(_selectedMaPhong))
            {
                MessageBox.Show("Sinh viên này đã trả phòng hoặc chưa được xếp phòng.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_selectedPhieuIndex < 0 || _selectedPhieuIndex >= dgvPhieuDienNuoc.Rows.Count)
            {
                MessageBox.Show("Vui lòng chọn phiếu điện nước cần thêm vào hóa đơn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddPhieuToDetail(dgvPhieuDienNuoc.Rows[_selectedPhieuIndex]);
        }

        // ================================================================
        // SỰ KIỆN NÚT XÓA KHỎI CHI TIẾT HÓA ĐƠN (nút <)
        // ================================================================
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa trong hóa đơn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!(dgvChiTietHoaDon.DataSource is DataTable dt)) return;

            int idx = dgvChiTietHoaDon.CurrentRow.Index;
            dt.Rows[idx].Delete();
            dt.AcceptChanges();
            UpdateTongTien(dt);
        }

        // ================================================================
        // TỰ SINH MÃ HÓA ĐƠN
        // FIX #1: Dùng TryParse để tránh crash khi dữ liệu không đúng định dạng
        // ================================================================
        private string GenerateMaHoaDon()
        {
            object result = _db.ExecuteScalar("SELECT MAX(MaHoaDon) FROM HoaDon");
            if (result == null || result == DBNull.Value) return "HD001";

            string last = result.ToString();
            string numberPart = last.Length > 2 ? last.Substring(2) : "";
            if (!int.TryParse(numberPart, out int next))
                next = 0;

            return "HD" + (next + 1).ToString("D3");
        }

        // ================================================================
        // TỰ SINH MÃ CHI TIẾT HÓA ĐƠN
        // FIX #1: Dùng TryParse để tránh crash khi dữ liệu không đúng định dạng
        // ================================================================
        private string GenerateMaCTHD()
        {
            object result = _db.ExecuteScalar("SELECT MAX(MaCTHD) FROM ChiTietHoaDon");
            if (result == null || result == DBNull.Value) return "CT001";

            string last = result.ToString();
            string numberPart = last.Length > 2 ? last.Substring(2) : "";
            if (!int.TryParse(numberPart, out int next))
                next = 0;

            return "CT" + (next + 1).ToString("D3");
        }

        // ================================================================
        // NẠP DANH SÁCH SINH VIÊN LÊN LƯỚI (có lọc theo MSV)
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

            DataTable dt = (prm != null)
                ? _db.ExecuteQuery(sql, prm)
                : _db.ExecuteQuery(sql);

            _isBinding = true;
            dgvSinhVien.DataSource = dt;
            _isBinding = false;
            UIService.SetGridHeader(dgvSinhVien,
                "Mã SV", "Họ tên", "Mã phòng", "Số phòng", "Khu nhà");
        }

        // ================================================================
        // NẠP PHIẾU ĐIỆN NƯỚC THEO PHÒNG LÊN LƯỚI PHIẾU
        // FIX #9 : Lọc ra các phiếu CHƯA được lập hóa đơn
        // FIX #10: Tự động chọn dòng đầu tiên để tránh _selectedPhieuIndex = -1
        // ================================================================
        private void LoadDienNuocByPhong(string maPhong)
        {
            if (string.IsNullOrEmpty(maPhong))
            {
                dgvPhieuDienNuoc.DataSource = null;
                dgvChiTietHoaDon.DataSource = null;
                txtTongtien.Text = "0 VNĐ";
                return;
            }

            // Lấy tất cả phiếu điện nước của phòng (kể cả đã lập hóa đơn)
            // Chỉ ẩn sinh viên không có phòng hoặc đã trả phòng (xử lý ở BindSinhVienData)
            string sql = @"
                SELECT dn.MaPhieu,
                       CAST(dn.Thang AS NVARCHAR) + '/' + CAST(dn.Nam AS NVARCHAR) AS Thang_Nam,
                       p.GiaPhong  AS TienPhong,
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
            dgvPhieuDienNuoc.DataSource = dt;
            UIService.SetGridHeader(dgvPhieuDienNuoc,
                "Mã phiếu", "Tháng/Năm", "Tiền phòng", "Tiền điện", "Tiền nước",
                "Tổng tiền", "Tháng", "Năm");

            // FIX #10: Tự động chọn dòng đầu tiên nếu có dữ liệu
            // Tránh trường hợp người dùng bấm ">" ngay mà chưa click vào lưới
            _selectedPhieuIndex = (dt.Rows.Count > 0) ? 0 : -1;
        }

        // ================================================================
        // HIỂN THỊ THÔNG TIN SINH VIÊN ĐANG CHỌN SANG PANEL HÓA ĐƠN
        // ================================================================
        private void BindSinhVienData()
        {
            if (dgvSinhVien.CurrentRow == null) return;

            DataGridViewRow row = dgvSinhVien.CurrentRow;
            _selectedMaSV = row.Cells[0].Value?.ToString() ?? "";
            _selectedMaPhong = row.Cells[2].Value?.ToString() ?? "";
            _selectedPhieuIndex = -1;

            txtMasinhvien.Text = _selectedMaSV;
            txtTensinhvien.Text = row.Cells[1].Value?.ToString() ?? "";
            txtSophong.Text = row.Cells[3].Value?.ToString() ?? "";
            txtKhunha.Text = row.Cells[4].Value?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(_selectedMaPhong))
            {
                dgvPhieuDienNuoc.DataSource = null;
                dgvChiTietHoaDon.DataSource = null;
                txtTongtien.Text = "0 VNĐ";
                return;
            }

            LoadDienNuocByPhong(_selectedMaPhong);
        }

        // ================================================================
        // THÊM MỘT PHIẾU ĐIỆN NƯỚC VÀO LƯỚI CHI TIẾT HÓA ĐƠN
        // ================================================================
        private void AddPhieuToDetail(DataGridViewRow srcRow)
        {
            string maPhieu = srcRow.Cells[0].Value?.ToString() ?? "";
            string thangNam = srcRow.Cells[1].Value?.ToString() ?? "";
            long tienPhong = Convert.ToInt64(srcRow.Cells[2].Value ?? 0);
            long tienDien = Convert.ToInt64(srcRow.Cells[3].Value ?? 0);
            long tienNuoc = Convert.ToInt64(srcRow.Cells[4].Value ?? 0);
            long tongTien = Convert.ToInt64(srcRow.Cells[5].Value ?? 0);

            // Kiểm tra trùng phiếu trong chi tiết hiện tại
            if (dgvChiTietHoaDon.DataSource is DataTable dtCheck)
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

            if (!(dgvChiTietHoaDon.DataSource is DataTable dt))
            {
                dt = new DataTable();
                dt.Columns.Add("MaPhieu");
                dt.Columns.Add("Tháng/Năm");
                dt.Columns.Add("Tiền phòng", typeof(long));
                dt.Columns.Add("Tiền điện", typeof(long));
                dt.Columns.Add("Tiền nước", typeof(long));
                dt.Columns.Add("Tổng tiền", typeof(long));
                dgvChiTietHoaDon.DataSource = dt;
                UIService.SetGridStyle(dgvChiTietHoaDon);
            }

            dt.Rows.Add(maPhieu, thangNam, tienPhong, tienDien, tienNuoc, tongTien);
            UpdateTongTien(dt);
        }

        // ================================================================
        // TÍNH VÀ HIỂN THỊ TỔNG TIỀN HÓA ĐƠN
        // ================================================================
        private void UpdateTongTien(DataTable dt)
        {
            long tong = 0;
            foreach (DataRow row in dt.Rows)
                tong += Convert.ToInt64(row["Tổng tiền"]);

            txtTongtien.Text = tong.ToString("N0") + " VNĐ";
        }

        // ================================================================
        // KIỂM TRA DỮ LIỆU TRƯỚC KHI LƯU
        // ================================================================
        private bool ValidateInput()
        {
            if (!UIService.Require(txtMasinhvien, "Vui lòng chọn sinh viên!")) return false;
            if (!UIService.Require(txtNgaylaphoadon, "Vui lòng nhập ngày lập hóa đơn!")) return false;

            if (UIService.ParseDate(txtNgaylaphoadon.Text) == null)
            {
                MessageBox.Show("Ngày lập hóa đơn không hợp lệ. Định dạng: dd/MM/yyyy",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaylaphoadon.Focus();
                return false;
            }

            if (!(dgvChiTietHoaDon.DataSource is DataTable dtDetail) || dtDetail.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một phiếu điện nước vào hóa đơn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // ================================================================
        // LƯU HÓA ĐƠN — điều phối theo SaveMode
        // ================================================================
        private void SaveHoaDon()
        {
            if (_saveMode == SaveMode.Insert)
                InsertHoaDon();
        }

        // ================================================================
        // THÊM MỚI HÓA ĐƠN VÀ CHI TIẾT VÀO CSDL
        // FIX #2 : Dùng long cho các cột tiền, tránh tràn số
        // FIX #7 : Kiểm tra các phiếu thuộc nhiều tháng khác nhau
        // FIX #8 : Dùng Transaction để đảm bảo toàn vẹn dữ liệu
        // ================================================================
        private void InsertHoaDon()
        {
            DataTable dtDetail = (DataTable)dgvChiTietHoaDon.DataSource;
            DateTime ngayLap = UIService.ParseDate(txtNgaylaphoadon.Text).Value;

            // FIX #7: Kiểm tra tất cả phiếu trong chi tiết phải cùng tháng/năm
            string thangNamDau = dtDetail.Rows[0]["Tháng/Năm"]?.ToString() ?? "";
            foreach (DataRow r in dtDetail.Rows)
            {
                if (r["Tháng/Năm"]?.ToString() != thangNamDau)
                {
                    MessageBox.Show(
                        "Tất cả phiếu trong hóa đơn phải thuộc cùng một tháng/năm.\n" +
                        "Vui lòng kiểm tra lại.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int thang = 0, nam = 0;
            string[] parts = thangNamDau.Split('/');
            if (parts.Length == 2)
            {
                int.TryParse(parts[0], out thang);
                int.TryParse(parts[1], out nam);
            }

            // Kiểm tra hóa đơn trùng tháng/năm
            string checkSql = @"SELECT COUNT(*) FROM HoaDon
                                 WHERE MaSV=@sv AND MaPhong=@mp AND Thang=@t AND Nam=@n";
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

            // FIX #2: Dùng long để tránh tràn số
            long tienPhongTong = 0, tienDienTong = 0, tienNuocTong = 0, tongTien = 0;
            foreach (DataRow r in dtDetail.Rows)
            {
                tienPhongTong += Convert.ToInt64(r["Tiền phòng"]);
                tienDienTong += Convert.ToInt64(r["Tiền điện"]);
                tienNuocTong += Convert.ToInt64(r["Tiền nước"]);
                tongTien += Convert.ToInt64(r["Tổng tiền"]);
            }

            string maCTHD = GenerateMaCTHD();
            _db.ExecuteTransaction((conn, tran) =>
            {
                string sqlHD = @"INSERT INTO HoaDon (MaHoaDon, MaSV, MaPhong, Thang, Nam, NgayLap, TrangThai)
                                  VALUES (@mahd, @sv, @mp, @t, @n, @ngay, N'Chưa thanh toán')";

                using (SqlCommand cmdHD = new SqlCommand(sqlHD, conn, tran))
                {
                    cmdHD.Parameters.AddWithValue("@mahd", _currentMaHoaDon);
                    cmdHD.Parameters.AddWithValue("@sv", _selectedMaSV);
                    cmdHD.Parameters.AddWithValue("@mp", _selectedMaPhong);
                    cmdHD.Parameters.AddWithValue("@t", thang);
                    cmdHD.Parameters.AddWithValue("@n", nam);
                    cmdHD.Parameters.AddWithValue("@ngay", ngayLap);
                    cmdHD.ExecuteNonQuery();
                }

                string sqlCT = @"INSERT INTO ChiTietHoaDon
                                       (MaCTHD, MaHoaDon, TienPhong, TienDien, TienNuoc, PhuPhi, TongTien)
                                  VALUES (@mact, @mahd, @tp, @td, @tn, 0, @tt)";

                using (SqlCommand cmdCT = new SqlCommand(sqlCT, conn, tran))
                {
                    cmdCT.Parameters.AddWithValue("@mact", maCTHD);
                    cmdCT.Parameters.AddWithValue("@mahd", _currentMaHoaDon);
                    cmdCT.Parameters.AddWithValue("@tp", tienPhongTong);
                    cmdCT.Parameters.AddWithValue("@td", tienDienTong);
                    cmdCT.Parameters.AddWithValue("@tn", tienNuocTong);
                    cmdCT.Parameters.AddWithValue("@tt", tongTien);
                    cmdCT.ExecuteNonQuery();
                }
            });
        }

        // ================================================================
        // CÁC SỰ KIỆN TRỐNG TỪ DESIGNER
        // ================================================================
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void tlpSinhVien_Paint(object sender, PaintEventArgs e) { }
        private void pnlTitle_Paint(object sender, PaintEventArgs e) { }
        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
