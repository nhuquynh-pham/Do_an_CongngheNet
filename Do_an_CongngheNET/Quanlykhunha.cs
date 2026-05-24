using QLKTX;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Quanlykhunha : Form 
    {
        private readonly DBService _db; 
        private SaveMode _saveMode = SaveMode.Insert; 

        public Quanlykhunha()
        {
            InitializeComponent(); // Khởi tạo các control trên form (textbox, button, grid...)
            _db = new DBService(); // Tạo đối tượng kết nối database
        }

        // ================================================================
        // FORM LOAD
        // ================================================================
        private void Quanlykhunha_Load(object sender, EventArgs e) 
        {
            // Khởi tạo ComboBox
            cboLoaikhu.Items.AddRange(new string[] { "Nam", "Nữ" }); 
            cboTrangthai.Items.AddRange(new string[] { "Đang sử dụng", "Bảo trì", "Ngưng sử dụng" }); 

            // txtTongsophong luôn readonly
            txtTongsophong.Enabled = false;
            txtTongsophong.ReadOnly = true;
           

            // Trạng thái ban đầu: chỉ xem
            UIService.SetInputsEnabled(tlplnputs, false); 
            UIService.SetButtonsEnabled(this, false); 

            // Thiết lập style lưới
            UIService.SetGridStyle(dgvQuanlykhunha); 

            // Tải dữ liệu & đặt header cột
            LoadData(); 
            UIService.SetGridHeader(dgvQuanlykhunha,
                "Mã khu", "Tên khu", "Loại khu", "Số tầng",
                "Tổng số phòng", "Trạng thái", "Ghi chú"); 
        }

        // ================================================================
        // THÊM MỚI
        // ================================================================
        private void btnNew_Click(object sender, EventArgs e) 
        {
            _saveMode = SaveMode.Insert; 
            UIService.ClearInputs(tlplnputs); 
            UIService.SetInputsEnabled(tlplnputs, true); 
            UIService.SetButtonsEnabled(this, true); 

            // Tổng số phòng luôn readonly
            txtTongsophong.Enabled = false;
            txtTongsophong.ReadOnly = true;

            txtMakhu.Focus();
        }

        // ================================================================
        // SỬA
        // ================================================================
        private void btnEdit_Click(object sender, EventArgs e) 
        {
            if (dgvQuanlykhunha.CurrentRow == null) return; 
            _saveMode = SaveMode.Update; 
            UIService.SetInputsEnabled(tlplnputs, true); 

            
            txtMakhu.Enabled = false;
            txtMakhu.ReadOnly = true;

            // Tổng số phòng luôn readonly
            txtTongsophong.Enabled = false;
            txtTongsophong.ReadOnly = true;

            txtTenkhu.Focus(); //Đưa con trỏ vào ô Tên khu để bắt đầu sửa thông tin.
        }

        // ================================================================
        // XÓA
        // ================================================================
        private void btnDelete_Click(object sender, EventArgs e) 
        {
            if (dgvQuanlykhunha.CurrentRow == null) return; 
            if (!UIService.ConfirmDelete()) return; 

            string maKhu = GetCurrentMaKhu();  

            // Kiểm tra nếu đã có phòng thuộc khu này thì không được xóa
            if (IsUsed(maKhu)) 
            {
                MessageBox.Show(
                    "Không thể xóa khu nhà này vì đã có phòng thuộc khu nhà này!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            DeleteData(maKhu); 
            LoadData(); 
        }

        // ================================================================
        // GHI (LƯU)
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e) 
        {
            if (!ValidateInput()) return; 

            string maKhu = txtMakhu.Text.Trim();
            string tenKhu = txtTenkhu.Text.Trim();
            string loai = cboLoaikhu.Text;
            int soTang = int.Parse(txtSotang.Text.Trim()); 
            string tthai = cboTrangthai.Text;
            string ghichu = txtGhichu.Text.Trim();

            if (_saveMode == SaveMode.Insert) 
            {
                // Kiểm tra trùng mã khu
                if (MaExists(maKhu)) 
                {
                    MessageBox.Show("Mã khu đã tồn tại!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMakhu.Focus();
                    return;
                }
                InsertData(maKhu, tenKhu, loai, soTang, tthai, ghichu); 
            }
            else
            {
                if (dgvQuanlykhunha.CurrentRow == null) return;
                UpdateData(maKhu, tenKhu, loai, soTang, tthai, ghichu); 
            }

            LoadData();
            UIService.SetInputsEnabled(tlplnputs, false);
            UIService.SetButtonsEnabled(this, false);
        } 

        // ================================================================
        // HỦY GHI
        // ================================================================
        private void btnCancel_Click(object sender, EventArgs e) 
        {
            UIService.SetInputsEnabled(tlplnputs, false);
            UIService.SetButtonsEnabled(this, false);
           // Khóa lại ô nhập và đưa nút về trạng thái ban đầu.
            txtTongsophong.Enabled = false;
            txtTongsophong.ReadOnly = true;

            BindData(); 
        }

        // ================================================================
        // KẾT THÚC
        // ================================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================================================================
        // CHỌN DÒNG TRÊN LƯỚI
        // ================================================================
        private void dgvQuanlykhunha_SelectionChanged(object sender, EventArgs e)
        { 
            BindData();
        } 

        // ================================================================
        // TÌM KIẾM (nhấn Enter trên ô tìm kiếm)
        // ================================================================
        private void txtTimkiemkhu_KeyDown(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Enter) 
            {
                LoadData();
                e.Handled = true;
                e.SuppressKeyPress = true;
            } 
        }

        // ================================================================
        // ĐIỀU HƯỚNG BÀN PHÍM TRÊN CÁC Ô NHẬP
        // ================================================================
        private void txtMakhu_KeyDown(object sender, KeyEventArgs e)
        { 
            UIService.MoveFocus((Control)sender, e);
        }

        private void txtTenkhu_KeyDown(object sender, KeyEventArgs e)
        {
            UIService.MoveFocus((Control)sender, e);
        }

        private void txtSotang_KeyDown(object sender, KeyEventArgs e)
        {
            UIService.MoveFocus((Control)sender, e);
        }

        private void txtGhichu_KeyDown(object sender, KeyEventArgs e)
        {
            UIService.MoveFocus((Control)sender, e);
        }

        private void cboLoaikhu_KeyDown(object sender, KeyEventArgs e)
        {
            UIService.MoveFocus((Control)sender, e);
        }

        private void cboTrangthai_KeyDown(object sender, KeyEventArgs e)
        {
            UIService.MoveFocus((Control)sender, e);
        }

        // ================================================================
        // TẢI DỮ LIỆU LÊN LƯỚI
        // ================================================================
        private void LoadData() 
        {
            string keyword = txtTimkiemkhu.Text.Trim();
            dgvQuanlykhunha.DataSource = SearchData(keyword); 
            
            if (dgvQuanlykhunha.Columns.Count > 0)
            {
                dgvQuanlykhunha.Columns["MaKhu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvQuanlykhunha.Columns["TenKhu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvQuanlykhunha.Columns["LoaiKhu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvQuanlykhunha.Columns["SoTang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvQuanlykhunha.Columns["TongSoPhong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvQuanlykhunha.Columns["TrangThai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvQuanlykhunha.Columns["GhiChu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            } 
        }

        // ================================================================
        // HIỂN THỊ DỮ LIỆU LÊN FORM KHI CHỌN DÒNG
        // ================================================================
        private void BindData() 
        {
            if (dgvQuanlykhunha.CurrentRow == null)
            {
                UIService.ClearInputs(tlplnputs);
                return;
            } 

            txtMakhu.Text = dgvQuanlykhunha.CurrentRow.Cells["MaKhu"].Value?.ToString() ?? "";
            txtTenkhu.Text = dgvQuanlykhunha.CurrentRow.Cells["TenKhu"].Value?.ToString() ?? "";
            cboLoaikhu.Text = dgvQuanlykhunha.CurrentRow.Cells["LoaiKhu"].Value?.ToString() ?? "";
            txtSotang.Text = dgvQuanlykhunha.CurrentRow.Cells["SoTang"].Value?.ToString() ?? "";
            txtTongsophong.Text = dgvQuanlykhunha.CurrentRow.Cells["TongSoPhong"].Value?.ToString() ?? "";
            cboTrangthai.Text = dgvQuanlykhunha.CurrentRow.Cells["TrangThai"].Value?.ToString() ?? "";
            txtGhichu.Text = dgvQuanlykhunha.CurrentRow.Cells["GhiChu"].Value?.ToString() ?? "";
        } 
          
          // ================================================================
          // KIỂM TRA DỮ LIỆU ĐẦU VÀO
          // ================================================================
        private bool ValidateInput() //Hàm này kiểm tra dữ liệu trước khi lưu
        {
            if (!UIService.Require(txtMakhu, "Vui lòng nhập Mã khu!")) return false; 
            if (!UIService.Require(txtTenkhu, "Vui lòng nhập Tên khu!")) return false; 

            if (!UIService.MaxLength(txtMakhu, 20, "Mã khu không được quá 20 ký tự!")) return false; 
            if (!UIService.MaxLength(txtTenkhu, 100, "Tên khu không được quá 100 ký tự!")) return false;  

            if (!UIService.IsNumber(txtSotang, "Số tầng phải là số nguyên!")) return false; 

            return true; //Nếu qua hết các kiểm tra thì trả về true, cho phép lưu.
        }

        // ================================================================
        // KIỂM TRA KHU NHÀ ĐÃ CÓ PHÒNG CHƯA (dùng khi xóa)
        // ================================================================
        private bool IsUsed(string maKhu) //Hàm này kiểm tra khu nhà có đang được dùng ở bảng Phong không.
        {
            string sql = "SELECT COUNT(*) FROM Phong WHERE MaKhu = @MaKhu"; //Nó đếm xem có bao nhiêu phòng đang thuộc mã khu này
            int count = Convert.ToInt32(_db.ExecuteScalar(sql,
                new SqlParameter("@MaKhu", maKhu))); //ExecuteScalar dùng để lấy một giá trị duy nhất. Ở đây là số lượng phòng
            return count > 0; //Nếu count > 0 nghĩa là khu này đã có phòng, không nên xóa
        } //Hàm này được dùng trong nút Xóa để tránh xóa khu nhà đang có phòng.

        // ================================================================
        // KIỂM TRA MÃ KHU ĐÃ TỒN TẠI CHƯA (dùng khi thêm mới)
        // ================================================================
        private bool MaExists(string maKhu) //Hàm này kiểm tra mã khu đã tồn tại chưa
        {
            string sql = "SELECT COUNT(*) FROM KhuNha WHERE MaKhu = @MaKhu"; //Nó kiểm tra trong bảng KhuNha đã có mã khu này chưa
            int count = Convert.ToInt32(_db.ExecuteScalar(sql,
                new SqlParameter("@MaKhu", maKhu)));
            return count > 0; //Nếu kết quả lớn hơn 0 thì mã khu đã tồn tại
        }  //Hàm này dùng khi Thêm mới, để tránh thêm trùng mã khu.

        // ================================================================
        // TRUY VẤN DỮ LIỆU (có hỗ trợ tìm kiếm)
        // ================================================================
        private DataTable SearchData(string keyword = "") //Hàm này lấy dữ liệu từ bảng KhuNha
        {
            string sql = @"SELECT MaKhu, TenKhu, LoaiKhu, SoTang,
                                  TongSoPhong, TrangThai, GhiChu
                           FROM KhuNha
                           WHERE (@Keyword = N'' OR TenKhu LIKE @Keyword OR MaKhu LIKE @Keyword)
                           ORDER BY MaKhu";
            //đây là câu SQL rất quan trọng :
            //lấy các cột MaKhu, TenKhu, LoaiKhu, SoTang, TongSoPhong, TrangThai, GhiChu từ bảng KhuNha nếu không nhập từ khóa thì hiện tất cả nếu có nhập từ khóa thì tìm theo TenKhu hoặc MaKhu sắp xếp theo MaKhu 

            return _db.ExecuteQuery(sql,
                new SqlParameter("@Keyword", "%" + keyword + "%"));
        } //Dòng này chạy câu SQL và trả về DataTable , Dấu % trong SQL nghĩa là tìm gần đúng

        // ================================================================
        // THÊM DỮ LIỆU
        // ================================================================
        private void InsertData(string maKhu, string tenKhu, string loai,
                                int soTang, string tthai, string ghichu) //Hàm này thêm khu nhà mới vào database
        {
            string sql = @"INSERT INTO KhuNha (MaKhu, TenKhu, LoaiKhu, SoTang, TongSoPhong, TrangThai, GhiChu)
                           VALUES (@MaKhu, @TenKhu, @LoaiKhu, @SoTang, 0, @TrangThai, @GhiChu)"; 
            //nó thêm vào bảng KhuNha các thông tin: MaKhu, TenKhu, LoaiKhu, SoTang, TongSoPhong (mặc định là 0 khi thêm mới), TrangThai, GhiChu
            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaKhu", maKhu),
                new SqlParameter("@TenKhu", tenKhu),
                new SqlParameter("@LoaiKhu", loai),
                new SqlParameter("@SoTang", soTang),
                new SqlParameter("@TrangThai", tthai),
                new SqlParameter("@GhiChu", ghichu));
        } //Các dòng SqlParameter dùng để truyền dữ liệu vào SQL. Cách này tốt hơn ghép chuỗi trực tiếp vì tránh lỗi ký tự đặc biệt và an toàn hơn.

        // ================================================================
        // SỬA DỮ LIỆU
        // ================================================================
        private void UpdateData(string maKhu, string tenKhu, string loai,
                                int soTang, string tthai, string ghichu) //Hàm này sửa dữ liệu khu nhà
        {
            string sql = @"UPDATE KhuNha
                           SET TenKhu    = @TenKhu,
                               LoaiKhu   = @LoaiKhu,
                               SoTang    = @SoTang,
                               TrangThai = @TrangThai,
                               GhiChu    = @GhiChu
                           WHERE MaKhu = @MaKhu";
            //nó sửa các cột: TenKhu, LoaiKhu, SoTang, TrangThai, GhiChu trong bảng KhuNha dựa vào MaKhu để xác định dòng cần sửa
            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaKhu", maKhu),
                new SqlParameter("@TenKhu", tenKhu),
                new SqlParameter("@LoaiKhu", loai),
                new SqlParameter("@SoTang", soTang),
                new SqlParameter("@TrangThai", tthai),
                new SqlParameter("@GhiChu", ghichu));
        }

        // ================================================================
        // XÓA DỮ LIỆU
        // ================================================================
        private void DeleteData(string maKhu) //Hàm này xóa khu nhà khỏi database.
        {
            string sql = "DELETE FROM KhuNha WHERE MaKhu = @MaKhu"; //Nó xóa khu nhà theo mã khu , WHERE MaKhu=@MaKhu rất quan trọng, nếu không có Where, SQL có thể xóa toàn bộ bảng KhuNha
            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaKhu", maKhu));
        }

        // ================================================================
        // LẤY MÃ KHU ĐANG CHỌN TRÊN LƯỚI
        // ================================================================
        private string GetCurrentMaKhu() //Hàm này lấy mã khu của dòng đang chọn trên lưới
        {
            if (dgvQuanlykhunha.CurrentRow == null) return ""; //Nếu chưa chọn dòng thì trả về rỗng
            return dgvQuanlykhunha.CurrentRow.Cells["MaKhu"].Value?.ToString() ?? ""; //Nó lấy giá trị cột MaKhu của dòng hiện tại. Hàm này thường dùng khi xóa hoặc kiểm tra dữ liệu 
        }

        // ================================================================
        // STUB — bắt buộc có để Designer.cs biên dịch được
        // ================================================================
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void lblMakhu_Click(object sender, EventArgs e) { }
    }
}