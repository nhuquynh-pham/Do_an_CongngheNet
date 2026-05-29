using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Quanlysinhvien : Form
    {
        // ==================== KẾT NỐI DATABASE ====================
        // Thay tên server nếu khác với máy bạn
        private readonly string connectionString =
            @"Server=DESKTOP-8L3ULEU\SQLEXPRESS01;Database=QLKTX;Integrated Security=True;";

        private enum TrangThaiForm { XEM, THEM, SUA }
        private TrangThaiForm trangThai = TrangThaiForm.XEM;

        public Quanlysinhvien()
        {
            InitializeComponent();
            KhoiTaoForm();
        }

        // ==================== KHỞI TẠO FORM ====================
        private void KhoiTaoForm()
        {
            // Nạp ComboBox giới tính
            cboGioitinh.Items.AddRange(new string[] { "Nam", "Nữ" });

            // Nạp ComboBox đối tượng
            txtDT.Items.AddRange(new string[] {
                "Bình thường", "Hộ nghèo", "Cận nghèo",
                "Vùng sâu vùng xa", "Con thương binh/liệt sĩ"
            });

            // Nạp ComboBox trạng thái
            txtTT.Items.AddRange(new string[] {
                "Đang học", "Bảo lưu", "Thôi học", "Tốt nghiệp"
            });

            // Gán sự kiện các nút
            btnTM.Click += BtnThemMoi_Click;
            btnS.Click += BtnSua_Click;
            btnX.Click += BtnXoa_Click;
            btnG.Click += BtnGhi_Click;
            btnHG.Click += BtnHuyGhi_Click;
            btnKT.Click += BtnKetThuc_Click;

            // Tìm kiếm realtime
            txtTK.TextChanged += TxtTK_TextChanged;

            // Chọn dòng trên DataGridView
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

            // Cấu hình DataGridView
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Tải dữ liệu và đặt trạng thái ban đầu
            TaiDuLieuLenGrid("");
            DatTrangThaiNut(TrangThaiForm.XEM);
        }

        // ==================== MỞ KẾT NỐI ====================
        private SqlConnection MoKetNoi()
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        // ==================== TẢI DỮ LIỆU LÊN GRID ====================
        private void TaiDuLieuLenGrid(string tuKhoa)
        {
            try
            {
                using (SqlConnection conn = MoKetNoi())
                {
                    string sql = @"
                        SELECT
                            MaSV        AS [Mã SV],
                            HoTen       AS [Họ tên],
                            CONVERT(VARCHAR,NgaySinh,103) AS [Ngày sinh],
                            GioiTinh    AS [Giới tính],
                            Lop         AS [Lớp],
                            Khoa        AS [Khoa],
                            SDT         AS [SĐT],
                            CCCD        AS [CCCD],
                            QueQuan     AS [Quê quán],
                            DoiTuong    AS [Đối tượng],
                            TrangThai   AS [Trạng thái],
                            GhiChu      AS [Ghi chú]
                        FROM SinhVien
                        WHERE MaSV  LIKE @kw OR HoTen LIKE @kw
                        ORDER BY MaSV";

                    var da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@kw", "%" + tuKhoa + "%");
                    var dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== HIỂN THỊ DỮ LIỆU LÊN FORM ====================
        private void HienThiDuLieuLenForm(DataGridViewRow row)
        {
            if (row == null) return;

            txtMasinhvien.Text = row.Cells["Mã SV"].Value?.ToString() ?? "";
            txtHoten.Text = row.Cells["Họ tên"].Value?.ToString() ?? "";
            txtNgaysinh.Text = row.Cells["Ngày sinh"].Value?.ToString() ?? "";
            cboGioitinh.Text = row.Cells["Giới tính"].Value?.ToString() ?? "";
            txtLop.Text = row.Cells["Lớp"].Value?.ToString() ?? "";
            txtKhoa.Text = row.Cells["Khoa"].Value?.ToString() ?? "";
            txtSDT.Text = row.Cells["SĐT"].Value?.ToString() ?? "";
            txtCCCD.Text = row.Cells["CCCD"].Value?.ToString() ?? "";
            txtQQ.Text = row.Cells["Quê quán"].Value?.ToString() ?? "";
            txtDT.Text = row.Cells["Đối tượng"].Value?.ToString() ?? "";
            txtTT.Text = row.Cells["Trạng thái"].Value?.ToString() ?? "";
            txtGC.Text = row.Cells["Ghi chú"].Value?.ToString() ?? "";
        }

        // ==================== XÓA TRẮNG FORM ====================
        private void XoaTrangForm()
        {
            txtMasinhvien.Clear();
            txtHoten.Clear();
            txtNgaysinh.Clear();
            cboGioitinh.SelectedIndex = -1;
            txtLop.Clear();
            txtKhoa.Clear();
            txtSDT.Clear();
            txtCCCD.Clear();
            txtQQ.Clear();
            txtDT.SelectedIndex = -1;
            txtTT.SelectedIndex = -1;
            txtGC.Clear();
            txtMasinhvien.Focus();
        }

        // ==================== KIỂM TRA HỢP LỆ ====================
        private bool KiemTraHopLe()
        {
            if (string.IsNullOrWhiteSpace(txtMasinhvien.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasinhvien.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHoten.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoten.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtNgaysinh.Text))
            {
                if (!DateTime.TryParseExact(txtNgaysinh.Text, "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out _)
                    && !DateTime.TryParse(txtNgaysinh.Text, out _))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ! Định dạng: dd/MM/yyyy", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgaysinh.Focus();
                    return false;
                }
            }
            return true;
        }

        // ==================== ĐẶT TRẠNG THÁI NÚT & CONTROL ====================
        private void DatTrangThaiNut(TrangThaiForm tt)
        {
            trangThai = tt;
            bool dangNhap = (tt == TrangThaiForm.THEM || tt == TrangThaiForm.SUA);

            // Nút
            btnTM.Enabled = !dangNhap;
            btnS.Enabled = !dangNhap;
            btnX.Enabled = !dangNhap;
            btnG.Enabled = dangNhap;
            btnHG.Enabled = dangNhap;
            btnKT.Enabled = !dangNhap;

            // Ô nhập liệu
            txtMasinhvien.ReadOnly = (tt == TrangThaiForm.SUA); // khoá khi sửa
            txtHoten.ReadOnly = !dangNhap;
            txtNgaysinh.ReadOnly = !dangNhap;
            cboGioitinh.Enabled = dangNhap;
            txtLop.ReadOnly = !dangNhap;
            txtKhoa.ReadOnly = !dangNhap;
            txtSDT.ReadOnly = !dangNhap;
            txtCCCD.ReadOnly = !dangNhap;
            txtQQ.ReadOnly = !dangNhap;
            txtDT.Enabled = dangNhap;
            txtTT.Enabled = dangNhap;
            txtGC.ReadOnly = !dangNhap;

            // Tìm kiếm & grid
            txtTK.Enabled = !dangNhap;
            dataGridView1.Enabled = !dangNhap;
        }

        // ==================== NÚT THÊM MỚI ====================
        private void BtnThemMoi_Click(object sender, EventArgs e)
        {
            XoaTrangForm();
            DatTrangThaiNut(TrangThaiForm.THEM);
        }

        // Sự kiện gốc từ designer (btnTM.Click = button1_Click)
        private void button1_Click(object sender, EventArgs e) { }

        // ==================== NÚT SỬA ====================
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DatTrangThaiNut(TrangThaiForm.SUA);
        }

        // ==================== NÚT XÓA ====================
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSV = txtMasinhvien.Text.Trim();
            string hoTen = txtHoten.Text.Trim();

            var res = MessageBox.Show(
                $"Bạn có chắc muốn xóa sinh viên [{maSV}] - {hoTen}?\n" +
                "Các dữ liệu liên quan (Đăng ký, Xếp phòng, Hóa đơn...) cũng sẽ bị xóa!",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = MoKetNoi())
                {
                    // Xóa theo thứ tự FK
                    string[] sqls = {
                        "DELETE FROM ChiTietHoaDon WHERE MaHoaDon IN (SELECT MaHoaDon FROM HoaDon WHERE MaSV=@id)",
                        "DELETE FROM HoaDon        WHERE MaSV=@id",
                        "DELETE FROM TraPhong       WHERE MaSV=@id",
                        "DELETE FROM ChuyenPhong    WHERE MaSV=@id",
                        "DELETE FROM XepPhong       WHERE MaSV=@id",
                        "DELETE FROM DangKy         WHERE MaSV=@id",
                        "DELETE FROM SinhVien       WHERE MaSV=@id"
                    };

                    SqlTransaction trans = conn.BeginTransaction();
                    try
                    {
                        foreach (string s in sqls)
                        {
                            var cmd = new SqlCommand(s, conn, trans);
                            cmd.Parameters.AddWithValue("@id", maSV);
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                        MessageBox.Show("Xóa sinh viên thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XoaTrangForm();
                        TaiDuLieuLenGrid(txtTK.Text.Trim());
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== NÚT GHI ====================
        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;

            string maSV = txtMasinhvien.Text.Trim();
            string hoTen = txtHoten.Text.Trim();
            string lop = txtLop.Text.Trim();
            string khoa = txtKhoa.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string queQuan = txtQQ.Text.Trim();
            string doiTuong = txtDT.Text.Trim();
            string trangThaiSV = txtTT.Text.Trim();
            string ghiChu = txtGC.Text.Trim();
            string gioiTinh = cboGioitinh.Text.Trim();

            // Xử lý ngày sinh
            object ngaySinh = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(txtNgaysinh.Text))
            {
                if (DateTime.TryParseExact(txtNgaysinh.Text, "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out DateTime dt1))
                    ngaySinh = dt1.Date;
                else if (DateTime.TryParse(txtNgaysinh.Text, out DateTime dt2))
                    ngaySinh = dt2.Date;
            }

            try
            {
                using (SqlConnection conn = MoKetNoi())
                {
                    string sql;

                    if (trangThai == TrangThaiForm.THEM)
                    {
                        // Kiểm tra trùng mã
                        var cmdChk = new SqlCommand(
                            "SELECT COUNT(*) FROM SinhVien WHERE MaSV=@id", conn);
                        cmdChk.Parameters.AddWithValue("@id", maSV);
                        if ((int)cmdChk.ExecuteScalar() > 0)
                        {
                            MessageBox.Show($"Mã sinh viên [{maSV}] đã tồn tại!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMasinhvien.Focus();
                            return;
                        }

                        sql = @"INSERT INTO SinhVien
                                    (MaSV,HoTen,NgaySinh,GioiTinh,Lop,Khoa,
                                     SDT,CCCD,QueQuan,DoiTuong,TrangThai,GhiChu)
                                VALUES
                                    (@MaSV,@HoTen,@NgaySinh,@GioiTinh,@Lop,@Khoa,
                                     @SDT,@CCCD,@QueQuan,@DoiTuong,@TrangThai,@GhiChu)";
                    }
                    else // SUA
                    {
                        sql = @"UPDATE SinhVien SET
                                    HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh,
                                    Lop=@Lop, Khoa=@Khoa, SDT=@SDT, CCCD=@CCCD,
                                    QueQuan=@QueQuan, DoiTuong=@DoiTuong,
                                    TrangThai=@TrangThai, GhiChu=@GhiChu
                                WHERE MaSV=@MaSV";
                    }

                    var cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    cmd.Parameters.AddWithValue("@HoTen", hoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@Lop", lop);
                    cmd.Parameters.AddWithValue("@Khoa", khoa);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@CCCD", cccd);
                    cmd.Parameters.AddWithValue("@QueQuan", queQuan);
                    cmd.Parameters.AddWithValue("@DoiTuong", doiTuong);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThaiSV);
                    cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                    cmd.ExecuteNonQuery();

                    string tb = (trangThai == TrangThaiForm.THEM)
                        ? "Thêm sinh viên thành công!" : "Cập nhật sinh viên thành công!";
                    MessageBox.Show(tb, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TaiDuLieuLenGrid(txtTK.Text.Trim());
                    DatTrangThaiNut(TrangThaiForm.XEM);

                    // Tự động chọn lại dòng vừa ghi
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Mã SV"].Value?.ToString() == maSV)
                        {
                            dataGridView1.ClearSelection();
                            row.Selected = true;
                            dataGridView1.CurrentCell = row.Cells[0];
                            HienThiDuLieuLenForm(row);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== NÚT HỦY GHI ====================
        private void BtnHuyGhi_Click(object sender, EventArgs e)
        {
            DatTrangThaiNut(TrangThaiForm.XEM);
            if (dataGridView1.CurrentRow != null)
                HienThiDuLieuLenForm(dataGridView1.CurrentRow);
            else
                XoaTrangForm();
        }

        // ==================== NÚT KẾT THÚC ====================
        private void BtnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ==================== TÌM KIẾM REALTIME ====================
        private void TxtTK_TextChanged(object sender, EventArgs e)
        {
            TaiDuLieuLenGrid(txtTK.Text.Trim());
        }

        // ==================== CHỌN DÒNG TRÊN GRID ====================
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (trangThai != TrangThaiForm.XEM) return;
            if (dataGridView1.CurrentRow != null)
                HienThiDuLieuLenForm(dataGridView1.CurrentRow);
        }

        // Sự kiện gốc từ designer
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}