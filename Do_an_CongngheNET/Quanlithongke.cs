using System;
using System.Collections.Generic;
using System.Data;
using System.IO;                       
using System.Drawing;                   
using System.Drawing.Printing;         
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Do_an_CongngheNET
{
    public partial class Quanlithongke : Form
    {
        private readonly DBService _db;
        public Quanlithongke()
        {
            InitializeComponent();
            _db = new DBService();
        }

        private void Quanlithongke_Load(object sender, EventArgs e)
        {
            tbnLammoi.Tag = "select";
            tbnInketqua.Tag = "select";
            tbnXemchitiet.Tag = "select";
            tbnXuatEx.Tag = "select";
            btnKetthuc.Tag = "select";
            cboLoaithongke.Tag = "AlwaysEnable";
            cbokhunha.Tag = "AlwaysEnable";
            cboPhong.Tag = "AlwaysEnable";
            cboThang.Tag = "AlwaysEnable";

            txtnam.Tag = "AlwaysEnable";
            txtTungay.Tag = "AlwaysEnable";
            txtdenngay.Tag = "AlwaysEnable";
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            UIService.SetGridStyle(dgvThongKe);

            LoadLoaiThongKe();
            LoadKhuNha();
            LoadThang();

            cboLoaithongke.SelectedIndex = 0;
            txtnam.Text = DateTime.Today.Year.ToString();
            cboLoaithongke.SelectedIndexChanged += CboLoaithongke_Changed;
            cbokhunha.SelectedIndexChanged += Cbokhunha_Changed;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            LoadData();

            UIService.SetGridHeader(
                dgvThongKe,
                "Loại Thống Kê", "Khu Nhà", "Số Phòng", "Tháng", "Năm",
                "Từ Ngày", "Đến Ngày", "Tổng Số SV", "Tổng Phòng",
                "Phòng Còn Trống", "Tổng Doanh Thu", "Tổng Tiền Điện Nước", "Ghi Chú");
        }

        private void LoadData()
        {
            dgvThongKe.DataSource = null;
            ClearKetQua();
        }

        private void tbnThongke_Click(object sender, EventArgs e)
        {
            try
            {
                string loai = cboLoaithongke.SelectedItem?.ToString() ?? "";
                string khu = cbokhunha.SelectedItem?.ToString() ?? "";
                string phong = cboPhong.SelectedItem?.ToString() ?? "";
                string thangStr = cboThang.SelectedItem?.ToString() ?? "";
                string namStr = txtnam.Text.Trim();
                int? thang = null;
                if (thangStr != "-- Tất cả --" && !string.IsNullOrEmpty(thangStr))
                {
                    if (int.TryParse(thangStr, out int t)) thang = t;
                    else
                    {
                        MessageBox.Show("Tháng không hợp lệ.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int? nam = null;
                if (!string.IsNullOrWhiteSpace(namStr))
                {
                    if (int.TryParse(namStr, out int n)) nam = n;
                    else
                    {
                        MessageBox.Show("Năm không hợp lệ.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (khu == "-- Tất cả --") khu = "";
                if (phong == "-- Tất cả --") phong = "";

                DateTime? tuNgay = UIService.ParseDate(txtTungay.Text.Trim());
                DateTime? denNgay = UIService.ParseDate(txtdenngay.Text.Trim());

                switch (loai)
                {
                    case "Theo tổng quát":
                        ThongKeTongQuat(nam, thang);
                        break;
                    case "Theo khu nhà":
                        ThongKeTheoKhu(khu, nam, thang);
                        break;
                    case "Theo phòng":
                        ThongKeTheoPhong(phong, khu, nam, thang);
                        break;
                    case "Theo hóa đơn tháng":
                        ThongKeHoaDon(khu, phong, thang, nam, tuNgay, denNgay);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbnLammoi_Click(object sender, EventArgs e)
        {
            cboLoaithongke.SelectedIndex = 0;
            cbokhunha.SelectedIndex = 0;
            cboPhong.SelectedIndex = 0;
            cboThang.SelectedIndex = 0;
            txtnam.Text = DateTime.Today.Year.ToString();
            txtTungay.Text = "";
            txtdenngay.Text = "";
            txtSearch.Text = "";
            dgvThongKe.DataSource = null;
            ClearKetQua();
        }

        
        private void tbnInketqua_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PrintForm pf = new PrintForm();
            pf.Print(dgvThongKe);
        }

        
        private void tbnXemchitiet_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xem chi tiết.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string info = "";
            foreach (DataGridViewCell cell in dgvThongKe.CurrentRow.Cells)
            {
                string header = dgvThongKe.Columns[cell.ColumnIndex].HeaderText;
                info += $"{header}: {cell.Value}\n";
            }
            MessageBox.Show(info, "Chi tiết dòng đang chọn",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void tbnXuatEx_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV File|*.csv",
                FileName = $"ThongKe_{DateTime.Now:yyyyMMdd_HHmm}.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false,
                       System.Text.Encoding.UTF8))
                {
                    for (int i = 0; i < dgvThongKe.Columns.Count; i++)
                    {
                        sw.Write(dgvThongKe.Columns[i].HeaderText);
                        if (i < dgvThongKe.Columns.Count - 1) sw.Write(",");
                    }
                    sw.WriteLine();

                    foreach (DataGridViewRow row in dgvThongKe.Rows)
                    {
                        for (int i = 0; i < dgvThongKe.Columns.Count; i++)
                        {
                            string val = row.Cells[i].Value?.ToString() ?? "";
                            sw.Write($"\"{val}\"");
                            if (i < dgvThongKe.Columns.Count - 1) sw.Write(",");
                        }
                        sw.WriteLine();
                    }
                }
                MessageBox.Show("Xuất file CSV thành công!\n" + sfd.FileName,
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================================================================
        // LOAD DỮ LIỆU CÁC COMBOBOX
        // ================================================================
        private void LoadLoaiThongKe()
        {
            cboLoaithongke.Items.Clear();
            cboLoaithongke.Items.Add("Theo tổng quát");
            cboLoaithongke.Items.Add("Theo khu nhà");
            cboLoaithongke.Items.Add("Theo phòng");
            cboLoaithongke.Items.Add("Theo hóa đơn tháng");
            cboLoaithongke.SelectedIndex = 0;
        }

        private void LoadKhuNha()
        {
            cbokhunha.Items.Clear();
            cbokhunha.Items.Add("-- Tất cả --");

            try
            {
                string sql = @"
        SELECT DISTINCT TenKhu
        FROM KhuNha
        WHERE TenKhu IS NOT NULL
        ORDER BY TenKhu";

                DataTable dt = _db.ExecuteQuery(sql);

                MessageBox.Show("Số khu: " + dt.Rows.Count);

                foreach (DataRow row in dt.Rows)
                {
                    cbokhunha.Items.Add(
                        row["TenKhu"].ToString().Trim()
                    );
                }

                cbokhunha.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Lỗi LoadKhuNha");
            }
        }

        private void LoadPhongByKhu(string tenKhu)
        {
            cboPhong.Items.Clear();
            cboPhong.Items.Add("-- Tất cả --");

            DataTable dt;
            if (string.IsNullOrEmpty(tenKhu) || tenKhu == "-- Tất cả --")
            {
                dt = _db.ExecuteQuery("SELECT SoPhong FROM Phong ORDER BY SoPhong");
            }
            else
            {
                string sql = @"SELECT p.SoPhong FROM Phong p
                               JOIN KhuNha k ON p.MaKhu = k.MaKhu
                               WHERE k.TenKhu = @khu ORDER BY p.SoPhong";
                dt = _db.ExecuteQuery(sql, new SqlParameter("@khu", tenKhu));
            }

            foreach (DataRow row in dt.Rows)
                cboPhong.Items.Add(row["SoPhong"].ToString());
            cboPhong.SelectedIndex = 0;
        }

        private void LoadThang()
        {
            cboThang.Items.Clear();
            cboThang.Items.Add("-- Tất cả --");
            for (int i = 1; i <= 12; i++)
                cboThang.Items.Add(i.ToString("D2"));
            cboThang.SelectedIndex = 0;
        }

        // ================================================================
        // SỰ KIỆN COMBOBOX
        // ================================================================
        private void CboLoaithongke_Changed(object sender, EventArgs e)
        {
            dgvThongKe.DataSource = null;
            ClearKetQua();
        }

        private void Cbokhunha_Changed(object sender, EventArgs e)
        {
            string tenKhu = cbokhunha.SelectedItem?.ToString() ?? "";
            LoadPhongByKhu(tenKhu == "-- Tất cả --" ? "" : tenKhu);
        }

        // ================================================================
        // 1. THỐNG KÊ TỔNG QUÁT
        // ================================================================
        private void ThongKeTongQuat(int? nam, int? thang)
        {
            int tongSV = Convert.ToInt32(_db.ExecuteScalar(
                "SELECT COUNT(*) FROM XepPhong WHERE TrangThaiO = N'Đang ở'"));
            int tongPhong = Convert.ToInt32(_db.ExecuteScalar(
                "SELECT COUNT(*) FROM Phong"));
            int phongTrong = Convert.ToInt32(_db.ExecuteScalar(
                "SELECT COUNT(*) FROM Phong WHERE TrangThai = N'Còn trống'"));
            string sqlDT = BuildDoanhThuSql(null, null, nam, thang);
            object dtObj = _db.ExecuteScalar(sqlDT, BuildParams(null, null, nam, thang));
            long tongDT = dtObj == null || dtObj == DBNull.Value ? 0 : Convert.ToInt64(dtObj);

            string sqlDN = BuildDienNuocSql(null, null, nam, thang);
            object dnObj = _db.ExecuteScalar(sqlDN, BuildParams(null, null, nam, thang));
            long tongDN = dnObj == null || dnObj == DBNull.Value ? 0 : Convert.ToInt64(dnObj);

            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("Chỉ số");
            dtResult.Columns.Add("Giá trị");
            dtResult.Rows.Add("Tổng sinh viên đang ở", tongSV);
            dtResult.Rows.Add("Tổng số phòng", tongPhong);
            dtResult.Rows.Add("Phòng còn trống", phongTrong);
            dtResult.Rows.Add("Tổng doanh thu (VNĐ)", tongDT.ToString("N0"));
            dtResult.Rows.Add("Tổng tiền điện nước (VNĐ)", tongDN.ToString("N0"));

            dgvThongKe.DataSource = dtResult;

            txtTongsinhvien.Text = tongSV.ToString();
            txtTongphong.Text = tongPhong.ToString();
            txtphongtrong.Text = phongTrong.ToString();
            txtTongdoanhthu.Text = tongDT.ToString("N0") + " VNĐ";
            txtTiendiennuoc.Text = tongDN.ToString("N0") + " VNĐ";
            txtGhichu.Text = "Thống kê tổng quát"
                                 + (thang.HasValue ? $" tháng {thang}" : "")
                                 + (nam.HasValue ? $" năm {nam}" : "");
        }

        // ================================================================
        // 2. THỐNG KÊ THEO KHU NHÀ
        // ================================================================
        private void ThongKeTheoKhu(string tenKhu, int? nam, int? thang)
        {
            string whereKhu = string.IsNullOrEmpty(tenKhu) ? "" : "WHERE k.TenKhu = @khu";

            string sql = $@"
                SELECT
                    k.TenKhu                         AS [Khu nhà],
                    COUNT(DISTINCT p.MaPhong)         AS [Tổng phòng],
                    SUM(CASE WHEN p.TrangThai = N'Còn trống' THEN 1 ELSE 0 END) AS [Phòng trống],
                    COUNT(DISTINCT xp.MaSV)           AS [Số SV đang ở],
                    ISNULL(SUM(ct.TongTien), 0)       AS [Tổng doanh thu]
                FROM KhuNha k
                LEFT JOIN Phong p      ON k.MaKhu = p.MaKhu
                LEFT JOIN XepPhong xp  ON p.MaPhong = xp.MaPhong AND xp.TrangThaiO = N'Đang ở'
                LEFT JOIN HoaDon hd    ON p.MaPhong = hd.MaPhong
                    {(thang.HasValue ? "AND hd.Thang = @thang" : "")}
                    {(nam.HasValue ? "AND hd.Nam   = @nam" : "")}
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHoaDon = ct.MaHoaDon
                {whereKhu}
                GROUP BY k.MaKhu, k.TenKhu
                ORDER BY k.MaKhu";

            DataTable dt = _db.ExecuteQuery(sql, BuildParams(tenKhu, null, nam, thang));
            dgvThongKe.DataSource = dt;

            int totalSV = 0, totalPhong = 0, totalTrong = 0;
            long totalDT = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalSV += Convert.ToInt32(row["Số SV đang ở"]);
                totalPhong += Convert.ToInt32(row["Tổng phòng"]);
                totalTrong += Convert.ToInt32(row["Phòng trống"]);
                totalDT += Convert.ToInt64(row["Tổng doanh thu"]);
            }

            object dnObj = _db.ExecuteScalar(
                BuildDienNuocSql(tenKhu, null, nam, thang),
                BuildParams(tenKhu, null, nam, thang));
            long tongDN = dnObj == null || dnObj == DBNull.Value ? 0 : Convert.ToInt64(dnObj);

            txtTongsinhvien.Text = totalSV.ToString();
            txtTongphong.Text = totalPhong.ToString();
            txtphongtrong.Text = totalTrong.ToString();
            txtTongdoanhthu.Text = totalDT.ToString("N0") + " VNĐ";
            txtTiendiennuoc.Text = tongDN.ToString("N0") + " VNĐ";
            txtGhichu.Text = $"Theo khu: {(string.IsNullOrEmpty(tenKhu) ? "Tất cả" : tenKhu)}";
        }

        // ================================================================
        // 3. THỐNG KÊ THEO PHÒNG
        // ================================================================
        private void ThongKeTheoPhong(string soPhong, string tenKhu, int? nam, int? thang)
        {
            string wherePhong = "";
            if (!string.IsNullOrEmpty(soPhong)) wherePhong += " AND p.SoPhong = @phong";
            if (!string.IsNullOrEmpty(tenKhu)) wherePhong += " AND k.TenKhu  = @khu";

            string sql = $@"
                SELECT
                    p.SoPhong                        AS [Số phòng],
                    k.TenKhu                         AS [Khu nhà],
                    p.LoaiPhong                      AS [Loại phòng],
                    p.SucChua                        AS [Sức chứa],
                    p.SoNguoiHienTai                 AS [Số người hiện tại],
                    p.TrangThai                      AS [Trạng thái],
                    ISNULL(SUM(ct.TongTien), 0)      AS [Tổng doanh thu]
                FROM Phong p
                JOIN KhuNha k ON p.MaKhu = k.MaKhu
                LEFT JOIN HoaDon hd ON p.MaPhong = hd.MaPhong
                    {(thang.HasValue ? "AND hd.Thang = @thang" : "")}
                    {(nam.HasValue ? "AND hd.Nam   = @nam" : "")}
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHoaDon = ct.MaHoaDon
                WHERE 1=1 {wherePhong}
                GROUP BY p.MaPhong, p.SoPhong, k.MaKhu, k.TenKhu,
                         p.LoaiPhong, p.SucChua, p.SoNguoiHienTai, p.TrangThai
                ORDER BY k.MaKhu, p.SoPhong";

            DataTable dt = _db.ExecuteQuery(sql, BuildParams(tenKhu, soPhong, nam, thang));
            dgvThongKe.DataSource = dt;

            int totalPhong = dt.Rows.Count, totalTrong = 0, totalSV = 0;
            long totalDT = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["Trạng thái"]?.ToString() == "Còn trống") totalTrong++;
                totalSV += Convert.ToInt32(row["Số người hiện tại"]);
                totalDT += Convert.ToInt64(row["Tổng doanh thu"]);
            }

            object dnObj = _db.ExecuteScalar(
                BuildDienNuocSql(tenKhu, soPhong, nam, thang),
                BuildParams(tenKhu, soPhong, nam, thang));
            long tongDN = dnObj == null || dnObj == DBNull.Value ? 0 : Convert.ToInt64(dnObj);

            txtTongsinhvien.Text = totalSV.ToString();
            txtTongphong.Text = totalPhong.ToString();
            txtphongtrong.Text = totalTrong.ToString();
            txtTongdoanhthu.Text = totalDT.ToString("N0") + " VNĐ";
            txtTiendiennuoc.Text = tongDN.ToString("N0") + " VNĐ";
            txtGhichu.Text = $"Theo phòng: {(string.IsNullOrEmpty(soPhong) ? "Tất cả" : soPhong)}";
        }

        // ================================================================
        // 4. THỐNG KÊ HÓA ĐƠN THEO THÁNG / KHOẢNG NGÀY
        // ================================================================
        private void ThongKeHoaDon(string tenKhu, string soPhong, int? thang, int? nam,
                                   DateTime? tuNgay, DateTime? denNgay)
        {
            string whereExtra = "";
            if (!string.IsNullOrEmpty(tenKhu)) whereExtra += " AND k.TenKhu    = @khu";
            if (!string.IsNullOrEmpty(soPhong)) whereExtra += " AND p.SoPhong   = @phong";
            if (thang.HasValue) whereExtra += " AND hd.Thang    = @thang";
            if (nam.HasValue) whereExtra += " AND hd.Nam      = @nam";
            if (tuNgay.HasValue) whereExtra += " AND hd.NgayLap >= @tuNgay";
            if (denNgay.HasValue) whereExtra += " AND hd.NgayLap <= @denNgay";

            string sql = $@"
                SELECT
                    hd.MaHoaDon                        AS [Mã HĐ],
                    sv.HoTen                           AS [Sinh viên],
                    p.SoPhong                          AS [Phòng],
                    k.TenKhu                           AS [Khu nhà],
                    hd.Thang                           AS [Tháng],
                    hd.Nam                             AS [Năm],
                    CONVERT(NVARCHAR, hd.NgayLap, 103) AS [Ngày lập],
                    hd.TrangThai                       AS [Trạng thái],
                    ISNULL(ct.TienPhong, 0)            AS [Tiền phòng],
                    ISNULL(ct.TienDien,  0)            AS [Tiền điện],
                    ISNULL(ct.TienNuoc,  0)            AS [Tiền nước],
                    ISNULL(ct.PhuPhi,    0)            AS [Phụ phí],
                    ISNULL(ct.TongTien,  0)            AS [Tổng tiền]
                FROM HoaDon hd
                JOIN SinhVien sv           ON hd.MaSV    = sv.MaSV
                JOIN Phong p               ON hd.MaPhong = p.MaPhong
                JOIN KhuNha k              ON p.MaKhu    = k.MaKhu
                LEFT JOIN ChiTietHoaDon ct ON hd.MaHoaDon = ct.MaHoaDon
                WHERE 1=1 {whereExtra}
                ORDER BY hd.Nam DESC, hd.Thang DESC, hd.NgayLap DESC";

            var pList = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(tenKhu)) pList.Add(new SqlParameter("@khu", tenKhu));
            if (!string.IsNullOrEmpty(soPhong)) pList.Add(new SqlParameter("@phong", soPhong));
            if (thang.HasValue) pList.Add(new SqlParameter("@thang", thang.Value));
            if (nam.HasValue) pList.Add(new SqlParameter("@nam", nam.Value));
            if (tuNgay.HasValue) pList.Add(new SqlParameter("@tuNgay", tuNgay.Value));
            if (denNgay.HasValue) pList.Add(new SqlParameter("@denNgay", denNgay.Value));

            DataTable dt = _db.ExecuteQuery(sql, pList.ToArray());
            dgvThongKe.DataSource = dt;

            long tongDT = 0, tongDN = 0;
            int soHD = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                tongDT += Convert.ToInt64(row["Tổng tiền"]);
                tongDN += Convert.ToInt64(row["Tiền điện"]) + Convert.ToInt64(row["Tiền nước"]);
            }

            txtTongsinhvien.Text = soHD + " hóa đơn";
            txtTongphong.Text = "";
            txtphongtrong.Text = "";
            txtTongdoanhthu.Text = tongDT.ToString("N0") + " VNĐ";
            txtTiendiennuoc.Text = tongDN.ToString("N0") + " VNĐ";
            txtGhichu.Text = $"Hóa đơn tháng {thang?.ToString() ?? "tất cả"}"
                                 + $" năm {nam?.ToString() ?? "tất cả"}";
        }

        // ================================================================
        // HÀM BUILD SQL
        // ================================================================
        private string BuildDoanhThuSql(string tenKhu, string soPhong, int? nam, int? thang)
        {
            string where = "WHERE 1=1";
            if (!string.IsNullOrEmpty(tenKhu)) where += " AND k.TenKhu  = @khu";
            if (!string.IsNullOrEmpty(soPhong)) where += " AND p.SoPhong = @phong";
            if (thang.HasValue) where += " AND hd.Thang = @thang";
            if (nam.HasValue) where += " AND hd.Nam   = @nam";
            return $@"SELECT ISNULL(SUM(ct.TongTien), 0)
                      FROM ChiTietHoaDon ct
                      JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon
                      JOIN Phong p   ON hd.MaPhong  = p.MaPhong
                      JOIN KhuNha k  ON p.MaKhu     = k.MaKhu
                      {where}";
        }

        private string BuildDienNuocSql(string tenKhu, string soPhong, int? nam, int? thang)
        {
            string where = "WHERE 1=1";
            if (!string.IsNullOrEmpty(tenKhu)) where += " AND k.TenKhu  = @khu";
            if (!string.IsNullOrEmpty(soPhong)) where += " AND p.SoPhong = @phong";
            if (thang.HasValue) where += " AND dn.Thang = @thang";
            if (nam.HasValue) where += " AND dn.Nam   = @nam";
            return $@"SELECT ISNULL(SUM(dn.TienDien + dn.TienNuoc), 0)
                      FROM DienNuoc dn
                      JOIN Phong p  ON dn.MaPhong = p.MaPhong
                      JOIN KhuNha k ON p.MaKhu    = k.MaKhu
                      {where}";
        }

        private SqlParameter[] BuildParams(string tenKhu, string soPhong, int? nam, int? thang)
        {
            var list = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(tenKhu)) list.Add(new SqlParameter("@khu", tenKhu));
            if (!string.IsNullOrEmpty(soPhong)) list.Add(new SqlParameter("@phong", soPhong));
            if (thang.HasValue) list.Add(new SqlParameter("@thang", thang.Value));
            if (nam.HasValue) list.Add(new SqlParameter("@nam", nam.Value));
            return list.ToArray();
        }

        private void ClearKetQua()
        {
            txtTongsinhvien.Text = "";
            txtTongphong.Text = "";
            txtphongtrong.Text = "";
            txtTongdoanhthu.Text = "";
            txtTiendiennuoc.Text = "";
            txtGhichu.Text = "";
        }

        // ================================================================
        // TÌM KIẾM TRONG LƯỚI
        // ================================================================
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!(dgvThongKe.DataSource is DataTable dt)) return;
            string kw = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(kw))
            {
                dt.DefaultView.RowFilter = "";
                return;
            }
            string kwSafe = kw.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]");
            if (dt.Columns.Count > 0)
                dt.DefaultView.RowFilter =
                    $"CONVERT([{dt.Columns[0].ColumnName}], System.String) LIKE '%{kwSafe}%'";
        }

        private void lblTitle_Click(object sender, EventArgs e) { }

        // ================================================================
        // LỚP HỖ TRỢ IN
        // ================================================================
        internal class PrintForm
        {
            private DataGridView _dgv;

            public void Print(DataGridView dgv)
            {
                _dgv = dgv;
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += Pd_PrintPage;
                PrintPreviewDialog ppd = new PrintPreviewDialog
                {
                    Document = pd,
                    WindowState = FormWindowState.Maximized
                };
                ppd.ShowDialog();
            }

            private void Pd_PrintPage(object sender, PrintPageEventArgs e)
            {
                System.Drawing.Graphics g = e.Graphics;
                System.Drawing.Font font = new System.Drawing.Font("Arial", 9);
                float y = e.MarginBounds.Top;
                float x = e.MarginBounds.Left;
                float colW = (float)e.MarginBounds.Width / _dgv.Columns.Count;

                using (System.Drawing.Font boldFont =
                       new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold))
                {
                    for (int i = 0; i < _dgv.Columns.Count; i++)
                        g.DrawString(_dgv.Columns[i].HeaderText, boldFont,
                                     System.Drawing.Brushes.Black, x + i * colW, y);
                }
                y += font.GetHeight() + 4;

                foreach (DataGridViewRow row in _dgv.Rows)
                {
                    for (int i = 0; i < _dgv.Columns.Count; i++)
                    {
                        string val = row.Cells[i].Value?.ToString() ?? "";
                        g.DrawString(val, font, System.Drawing.Brushes.Black, x + i * colW, y);
                    }
                    y += font.GetHeight() + 2;
                    if (y > e.MarginBounds.Bottom) break;
                }
                font.Dispose();
            }
        }
    }
}