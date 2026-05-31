using QLKTX;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Quanlysinhvien : Form
    {
        private readonly DBService _db;
        private SaveMode _saveMode = SaveMode.Insert;

        public Quanlysinhvien()
        {
            InitializeComponent();
            _db = new DBService();
        }

        // ================================================================
        // SỰ KIỆN LOAD FORM
        // ================================================================
        private void Quanlysinhvien_Load(object sender, EventArgs e)
        {
            // Gán Tag cho nút (fallback nếu Designer chưa gán)
            btnTM.Tag = "select";
            btnS.Tag = "select";
            btnX.Tag = "select";
            btnG.Tag = "confirm";
            btnHG.Tag = "confirm";
            btnKT.Tag = ""; // luôn hiển thị

            // Tắt toàn bộ input và nút mặc định
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            txtTK.Enabled = false;

            // Kiểm tra quyền
            bool coQuyen = SessionManager.CoQuyen("CN001")
                        || SessionManager.CoQuyen("CN002")
                        || SessionManager.CoQuyen("CN003");

            if (!coQuyen)
            {
                this.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }));
                return;
            }

            // Nạp ComboBox
            cboGioitinh.Items.AddRange(new string[] { "Nam", "Nữ" });

            txtDT.Items.AddRange(new string[] {
                "Bình thường", "Hộ nghèo", "Cận nghèo",
                "Vùng sâu vùng xa", "Con thương binh/liệt sĩ"
            });

            txtTT.Items.AddRange(new string[] {
                "Đang học", "Bảo lưu", "Thôi học", "Tốt nghiệp"
            });

            // Cấu hình DataGridView
            UIService.SetGridStyle(dataGridView1);

            // Bật tìm kiếm và tải dữ liệu
            txtTK.Enabled = true;
            txtTK.TextChanged += TxtTK_TextChanged;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

            LoadData();

            UIService.SetGridHeader(dataGridView1,
                "Mã SV", "Họ tên", "Ngày sinh", "Giới tính",
                "Lớp", "Khoa", "SĐT", "CCCD",
                "Quê quán", "Đối tượng", "Trạng thái", "Ghi chú");

            // Bật nút "select" (Thêm, Sửa, Xóa) — chưa bật "confirm"
            UIService.SetButtonsEnabled(this, false);
            btnTM.Enabled = true;
            btnS.Enabled = true;
            btnX.Enabled = true;
            btnKT.Enabled = true;
        }

        // ================================================================
        // NÚT THÊM MỚI
        // ================================================================
        private void btnTM_Click(object sender, EventArgs e)
        {
            _saveMode = SaveMode.Insert;

            UIService.ClearInputs(this);
            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);

            txtMasinhvien.ReadOnly = false;
            txtHoten.Enabled = true;
            txtTK.Enabled = false;

            txtMasinhvien.Focus();
        }

        // ================================================================
        // NÚT SỬA
        // ================================================================
        private void btnS_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _saveMode = SaveMode.Update;

            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);

            // Khoá mã sinh viên khi sửa
            txtMasinhvien.ReadOnly = true;
            txtTK.Enabled = false;

            txtHoten.Focus();
        }

        // ================================================================
        // NÚT XÓA
        // ================================================================
        private void btnX_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                _db.ExecuteTransaction((conn, tran) =>
                {
                    string[] sqls = {
                        "DELETE FROM ChiTietHoaDon WHERE MaHoaDon IN (SELECT MaHoaDon FROM HoaDon WHERE MaSV=@id)",
                        "DELETE FROM HoaDon        WHERE MaSV=@id",
                        "DELETE FROM TraPhong       WHERE MaSV=@id",
                        "DELETE FROM ChuyenPhong    WHERE MaSV=@id",
                        "DELETE FROM XepPhong       WHERE MaSV=@id",
                        "DELETE FROM DangKy         WHERE MaSV=@id",
                        "DELETE FROM SinhVien       WHERE MaSV=@id"
                    };

                    foreach (string sql in sqls)
                    {
                        var cmd = new SqlCommand(sql, conn, tran);
                        cmd.Parameters.AddWithValue("@id", maSV);
                        cmd.ExecuteNonQuery();
                    }
                });

                MessageBox.Show("Xóa sinh viên thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UIService.ClearInputs(this);
                LoadData();
                ResetToViewMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================================
        // NÚT GHI (LƯU)
        // ================================================================
        private void btnG_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

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
                DateTime? parsed = UIService.ParseDate(txtNgaysinh.Text.Trim());
                if (parsed.HasValue)
                    ngaySinh = parsed.Value.Date;
            }

            if (_saveMode == SaveMode.Insert)
            {
                if (IDExists(maSV))
                {
                    MessageBox.Show($"Mã sinh viên [{maSV}] đã tồn tại!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMasinhvien.Focus();
                    return;
                }
                InsertData(maSV, hoTen, ngaySinh, gioiTinh, lop, khoa,
                           sdt, cccd, queQuan, doiTuong, trangThaiSV, ghiChu);
            }
            else
            {
                UpdateData(maSV, hoTen, ngaySinh, gioiTinh, lop, khoa,
                           sdt, cccd, queQuan, doiTuong, trangThaiSV, ghiChu);
            }

            LoadData();
            ResetToViewMode();

            // Tự động chọn lại dòng vừa ghi
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Mã SV"].Value?.ToString() == maSV)
                {
                    dataGridView1.ClearSelection();
                    row.Selected = true;
                    dataGridView1.CurrentCell = row.Cells[0];
                    BindData();
                    break;
                }
            }
        }

        // ================================================================
        // NÚT HỦY GHI
        // ================================================================
        private void btnHG_Click(object sender, EventArgs e)
        {
            ResetToViewMode();
            BindData();
        }

        // ================================================================
        // NÚT KẾT THÚC
        // ================================================================
        private void btnKT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================================================================
        // TÌM KIẾM REALTIME
        // ================================================================
        private void TxtTK_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        // ================================================================
        // CHỌN DÒNG TRÊN GRID → HIỂN THỊ DỮ LIỆU LÊN FORM
        // ================================================================
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Chỉ bind khi đang ở chế độ xem
            if (btnG.Enabled) return;
            BindData();
        }

        // ================================================================
        // TẢI DỮ LIỆU THEO TỪ KHÓA TÌM KIẾM
        // ================================================================
        private void LoadData()
        {
            string keyword = txtTK.Text.Trim();
            dataGridView1.DataSource = SearchData(keyword);
        }

        private DataTable SearchData(string keyword = "")
        {
            string sql = @"
                SELECT
                    MaSV        AS [Mã SV],
                    HoTen       AS [Họ tên],
                    CONVERT(VARCHAR, NgaySinh, 103) AS [Ngày sinh],
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
                WHERE (@Keyword = N''
                       OR MaSV  LIKE @Keyword
                       OR HoTen LIKE @Keyword)
                ORDER BY MaSV";

            return _db.ExecuteQuery(sql,
                new SqlParameter("@Keyword", "%" + keyword + "%"));
        }

        // ================================================================
        // GÁN DỮ LIỆU TỪ LƯỚI LÊN FORM
        // ================================================================
        private void BindData()
        {
            if (dataGridView1.CurrentRow == null)
            {
                UIService.ClearInputs(this);
                return;
            }

            DataGridViewRow row = dataGridView1.CurrentRow;

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

        // ================================================================
        // ĐƯA FORM VỀ CHẾ ĐỘ XEM (sau khi Ghi / Hủy ghi)
        // ================================================================
        private void ResetToViewMode()
        {
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);

            // Luôn bật nút "select" và Kết thúc
            btnTM.Enabled = true;
            btnS.Enabled = true;
            btnX.Enabled = true;
            btnKT.Enabled = true;

            txtMasinhvien.ReadOnly = false;
            txtTK.Enabled = true;
        }

        // ================================================================
        // KIỂM TRA DỮ LIỆU ĐẦU VÀO
        // ================================================================
        private bool ValidateInput()
        {
            if (!UIService.Require(txtMasinhvien, "Vui lòng nhập Mã sinh viên!"))
                return false;

            if (!UIService.Require(txtHoten, "Vui lòng nhập Họ tên!"))
                return false;

            if (!UIService.MaxLength(txtMasinhvien, 10, "Mã sinh viên không dài hơn 10 ký tự!"))
                return false;

            if (!UIService.MaxLength(txtHoten, 100, "Họ tên không dài hơn 100 ký tự!"))
                return false;

            if (!UIService.MaxLength(txtSDT, 15, "Số điện thoại không dài hơn 15 ký tự!"))
                return false;

            if (!UIService.MaxLength(txtCCCD, 20, "CCCD không dài hơn 20 ký tự!"))
                return false;

            if (!UIService.MaxLength(txtQQ, 200, "Quê quán không dài hơn 200 ký tự!"))
                return false;

            if (!UIService.MaxLength(txtGC, 200, "Ghi chú không dài hơn 200 ký tự!"))
                return false;

            // Kiểm tra ngày sinh nếu có nhập
            if (!string.IsNullOrWhiteSpace(txtNgaysinh.Text))
            {
                if (!UIService.ParseDate(txtNgaysinh.Text.Trim()).HasValue)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ! Nhập theo định dạng dd/MM/yyyy.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgaysinh.Focus();
                    return false;
                }
            }

            return true;
        }

        // ================================================================
        // KIỂM TRA MÃ SINH VIÊN ĐÃ TỒN TẠI
        // ================================================================
        private bool IDExists(string maSV)
        {
            string sql = "SELECT COUNT(*) FROM SinhVien WHERE MaSV = @MaSV";
            int count = Convert.ToInt32(_db.ExecuteScalar(sql,
                new SqlParameter("@MaSV", maSV)));
            return count > 0;
        }

        // ================================================================
        // INSERT
        // ================================================================
        private void InsertData(string maSV, string hoTen, object ngaySinh,
            string gioiTinh, string lop, string khoa, string sdt, string cccd,
            string queQuan, string doiTuong, string trangThai, string ghiChu)
        {
            string sql = @"
                INSERT INTO SinhVien
                    (MaSV, HoTen, NgaySinh, GioiTinh, Lop, Khoa,
                     SDT, CCCD, QueQuan, DoiTuong, TrangThai, GhiChu)
                VALUES
                    (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @Lop, @Khoa,
                     @SDT, @CCCD, @QueQuan, @DoiTuong, @TrangThai, @GhiChu)";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@GioiTinh", string.IsNullOrWhiteSpace(gioiTinh) ? (object)DBNull.Value : gioiTinh),
                new SqlParameter("@Lop", string.IsNullOrWhiteSpace(lop) ? (object)DBNull.Value : lop),
                new SqlParameter("@Khoa", string.IsNullOrWhiteSpace(khoa) ? (object)DBNull.Value : khoa),
                new SqlParameter("@SDT", string.IsNullOrWhiteSpace(sdt) ? (object)DBNull.Value : sdt),
                new SqlParameter("@CCCD", string.IsNullOrWhiteSpace(cccd) ? (object)DBNull.Value : cccd),
                new SqlParameter("@QueQuan", string.IsNullOrWhiteSpace(queQuan) ? (object)DBNull.Value : queQuan),
                new SqlParameter("@DoiTuong", string.IsNullOrWhiteSpace(doiTuong) ? (object)DBNull.Value : doiTuong),
                new SqlParameter("@TrangThai", string.IsNullOrWhiteSpace(trangThai) ? (object)DBNull.Value : trangThai),
                new SqlParameter("@GhiChu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu)
            );

            MessageBox.Show("Thêm sinh viên thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        private void UpdateData(string maSV, string hoTen, object ngaySinh,
            string gioiTinh, string lop, string khoa, string sdt, string cccd,
            string queQuan, string doiTuong, string trangThai, string ghiChu)
        {
            string sql = @"
                UPDATE SinhVien SET
                    HoTen     = @HoTen,
                    NgaySinh  = @NgaySinh,
                    GioiTinh  = @GioiTinh,
                    Lop       = @Lop,
                    Khoa      = @Khoa,
                    SDT       = @SDT,
                    CCCD      = @CCCD,
                    QueQuan   = @QueQuan,
                    DoiTuong  = @DoiTuong,
                    TrangThai = @TrangThai,
                    GhiChu    = @GhiChu
                WHERE MaSV = @MaSV";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@GioiTinh", string.IsNullOrWhiteSpace(gioiTinh) ? (object)DBNull.Value : gioiTinh),
                new SqlParameter("@Lop", string.IsNullOrWhiteSpace(lop) ? (object)DBNull.Value : lop),
                new SqlParameter("@Khoa", string.IsNullOrWhiteSpace(khoa) ? (object)DBNull.Value : khoa),
                new SqlParameter("@SDT", string.IsNullOrWhiteSpace(sdt) ? (object)DBNull.Value : sdt),
                new SqlParameter("@CCCD", string.IsNullOrWhiteSpace(cccd) ? (object)DBNull.Value : cccd),
                new SqlParameter("@QueQuan", string.IsNullOrWhiteSpace(queQuan) ? (object)DBNull.Value : queQuan),
                new SqlParameter("@DoiTuong", string.IsNullOrWhiteSpace(doiTuong) ? (object)DBNull.Value : doiTuong),
                new SqlParameter("@TrangThai", string.IsNullOrWhiteSpace(trangThai) ? (object)DBNull.Value : trangThai),
                new SqlParameter("@GhiChu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu)
            );

            MessageBox.Show("Cập nhật sinh viên thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // SỰ KIỆN GIỮ LẠI TỪ DESIGNER (không xóa)
        // ================================================================
        private void button1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}