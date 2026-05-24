using QLKTX;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Quanlyphong : Form //khai báo class Quanlyphong kế thừa từ Form
    {
        private readonly DBService _db; //Khai báo biến _db kiểu DBService (lớp tự viết để thao tác CSDL). readonly nghĩa là chỉ gán một lần duy nhất.
        private SaveMode _saveMode = SaveMode.Insert; //Biến lưu trạng thái đang Thêm mới hay Cập nhật. Mặc định là Insert.

        public Quanlyphong() //hàm khởi tạo lớp quản lý phòng
        {
            InitializeComponent(); // Khởi tạo các control trên form (textbox, button, grid...)
            _db = new DBService(); // Tạo đối tượng kết nối CSDL
        }

        // ================================================================
        // LOAD FORM
        // ================================================================
        private void Quanlyphong_Load(object sender, EventArgs e) //Hàm này chạy ngay khi form được mở.
        {
            UIService.SetInputsEnabled(tlplnputs, false); //Tắt tất cả ô nhập liệu khi mới mở form (người dùng chưa bấm Thêm/Sửa thì không được nhập).
            UIService.SetButtonsEnabled(this, false); //Tắt các nút Lưu/Hủy.
            UIService.SetGridStyle(dgvQuanlyphong); //Định dạng bảng danh sách (màu sắc, font...).

            // Mã phòng và số người ở luôn readonly   //Mã phòng và số người ở luôn luôn bị khóa — không cho nhập tay vì hệ thống tự tính.
            txtMaphong.Enabled = false;
            txtSonguoio.Enabled = false;

            //Nạp dữ liệu vào 5 combobox.
            LoadKhuNha();
            LoadTang();
            LoadLoaiphong();
            LoadGioitinh();
            LoadTrangthai();

            // Gán sự kiện bấm phím: khi nhấn Enter hoặc Tab trên ô đó thì tự động chuyển sang ô tiếp theo.
            txtSophong.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtSucchua.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtGiaphong.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtGhichu.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboKhunha.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboTang.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboLoaiphong.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboGioitinh.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboTrangthai.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);

            LoadData(); //Tải toàn bộ danh sách phòng lên lưới.
            UIService.SetGridHeader(dgvQuanlyphong,
                "Mã phòng", "Số phòng", "Khu nhà", "Tầng",
                "Loại phòng", "Sức chứa", "Số người ở",
                "Giá phòng", "Giới tính", "Trạng thái", "Ghi chú");
        }
        //Đặt tiêu đề cột cho bảng danh sách.

        // ================================================================
        // NẠP COMBOBOX
        // ================================================================
        private void LoadKhuNha() //Đây là hàm nạp dữ liệu cho combobox Khu nhà, không phải hàm lưu dữ liệu
        {
            DataTable dt = _db.ExecuteQuery(
                "SELECT MaKhu, TenKhu FROM KhuNha WHERE TrangThai = N'Đang sử dụng' ORDER BY TenKhu");
            //Truy vấn danh sách khu nhà đang hoạt động từ CSDL.

            DataRow blank = dt.NewRow();
            blank["MaKhu"] = "";
            blank["TenKhu"] = "-- Chọn khu nhà --";
            dt.Rows.InsertAt(blank, 0);
            //Thêm dòng trống vào đầu danh sách làm dòng mặc định.

            cboKhunha.DataSource = dt;
            cboKhunha.DisplayMember = "TenKhu"; //hiển thị tên khu
            cboKhunha.ValueMember = "MaKhu"; //nhưng giá trị thực là mã khu
            cboKhunha.SelectedIndex = 0; //chọn dòng đầu (dòng trống)
        }

        private void LoadTang() 
        {
            cboTang.Items.Clear(); //Dòng này xóa toàn bộ dữ liệu cũ trong combobox cboTang
            cboTang.Items.Add("-- Chọn tầng --"); //Dòng này thêm dòng mặc định đầu tiên vào combobox.
            for (int i = 1; i <= 10; i++) //Đây là vòng lặp chạy từ 1 đến 10. Mỗi lần lặp sẽ thêm một tầng vào combobox.
                cboTang.Items.Add("Tầng " + i); //Dòng này thêm tầng vào combobox.
            cboTang.SelectedIndex = 0; // Dòng này chọn mặc định dòng đầu tiên trong combobox.
        }

        //tương tự - thêm thủ công các giá trị cố định vào combobox
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
            cboGioitinh.SelectedIndex = 0;
        }

        private void LoadTrangthai()
        {
            cboTrangthai.Items.Clear();
            cboTrangthai.Items.Add("-- Chọn trạng thái --");
            cboTrangthai.Items.Add("Còn chỗ");
            cboTrangthai.Items.Add("Đang sử dụng");
            cboTrangthai.Items.Add("Bảo trì");
            cboTrangthai.Items.Add("Ngưng sử dụng");
            cboTrangthai.SelectedIndex = 0;
        }

        // Tự điền sức chứa khi chọn loại phòng
        private void cboLoaiphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!txtSucchua.Enabled) return;
            string loai = cboLoaiphong.Text;
            if (loai == "Phòng 4 người") txtSucchua.Text = "4"; //Khi chọn loại phòng, tự động điền sức chứa tương ứng (4 hoặc 6).
            else if (loai == "Phòng 6 người") txtSucchua.Text = "6"; //Khi chọn loại phòng, tự động điền sức chứa tương ứng (4 hoặc 6).
            else txtSucchua.Text = "";
        }

        // ================================================================
        // SỰ KIỆN BUTTON
        // ================================================================
        private void btnNew_Click(object sender, EventArgs e) //thêm mới
        {
            _saveMode = SaveMode.Insert;
            UIService.ClearInputs(tlplnputs); //xóa trắng tất cả ô nhập
            ResetCombos(); //đưa combobox về dòng đầu

            txtMaphong.Text = GenerateMaPhong(); //tự tạo mã phòng (P001, P002...)
            txtMaphong.Enabled = false;
            txtSonguoio.Enabled = false;

            UIService.SetInputsEnabled(tlplnputs, true); //mở khóa ô nhập
            UIService.SetButtonsEnabled(this, true); //hiện nút lưu/hủy

            // Giữ hai trường này luôn readonly
            txtMaphong.Enabled = false; //khóa lại mã phòng (không cho sửa)
            txtSonguoio.Enabled = false;

            txtSophong.Focus(); //con trỏ nhảy vào ô số phòng
        }

        private void btnEdit_Click(object sender, EventArgs e) //sửa
        {
            if (dgvQuanlyphong.CurrentRow == null) return; //chưa chọn dòng thì bỏ qua

            _saveMode = SaveMode.Update;
            UIService.SetInputsEnabled(tlplnputs, true);
            UIService.SetButtonsEnabled(this, true);
            //...mở khóa form , khóa lại mã phòng & số người ở

            // Giữ hai trường này luôn readonly
            txtMaphong.Enabled = false;
            txtSonguoio.Enabled = false;

            txtSophong.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvQuanlyphong.CurrentRow == null) return;
            if (UIService.ConfirmDelete() == false) return; //hỏi xác nhận trước khi xóa

            string maPhong = GetCurrentID();

            // Kiểm tra có sinh viên đang ở không
            if (IsUsed(maPhong)) 
            {
                MessageBox.Show(
                    "Không thể xóa phòng này vì hiện có sinh viên đang ở!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DeleteData(maPhong); //nếu không ai ở thì xóa
            LoadData(); // tải lại danh sách
        }

        private void btnSave_Click(object sender, EventArgs e) //lưu
        {
            if (!ValidateInput()) return; //ktra dữ liệu hợp lệ trước

            string maPhong = txtMaphong.Text.Trim();//txtMakhu.Text.Trim(), lấy mã phòng và xóa khoảng trắng thừa ở đầu/ cuối.
            string soPhong = txtSophong.Text.Trim();
            string maKhu = cboKhunha.SelectedValue?.ToString() ?? ""; 
            int tang = int.Parse(cboTang.Text.Replace("Tầng ", "").Trim()); //"Tầng 3" ->3
            string loai = cboLoaiphong.Text;
            int sucChua = int.Parse(txtSucchua.Text.Trim()); //int.Parse(txtSucchua.Text.Trim()) chuyển sức chứa từ chữ sang số nguyên
            int gia = string.IsNullOrWhiteSpace(txtGiaphong.Text) ? 0
                                   : int.Parse(txtGiaphong.Text.Trim());
            string gioiTinh = cboGioitinh.Text;
            string trangThai = cboTrangthai.Text;
            string ghiChu = txtGhichu.Text.Trim();

            if (_saveMode == SaveMode.Insert) //Nếu _saveMode là Insert thì chương trình hiểu là đang thêm mới.
            {
                
                if (SoPhongExists(soPhong, maKhu)) //ktra số phòng trùng phòng khu
                {
                    MessageBox.Show("Số phòng này đã tồn tại trong khu nhà đã chọn!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSophong.Focus();
                    return;
                }
                InsertData(maPhong, soPhong, maKhu, tang, loai, sucChua, gia, gioiTinh, trangThai, ghiChu); // thêm mới vào CSDL
            }
            else
            {
                if (dgvQuanlyphong.CurrentRow == null) return;

                // Kiểm tra trùng số phòng (trừ chính nó)
                if (SoPhongExists(soPhong, maKhu, maPhong)) //ktra trùng, bỏ qua chính nó
                {
                    MessageBox.Show("Số phòng này đã tồn tại trong khu nhà đã chọn!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSophong.Focus();
                    return;
                }
                UpdateData(maPhong, soPhong, maKhu, tang, loai, sucChua, gia, gioiTinh, trangThai, ghiChu);
            }

            LoadData(); //tải lại lưới
            UIService.SetInputsEnabled(tlplnputs, false);
            UIService.SetButtonsEnabled(this, false);
        } //Sau khi lưu xong, chương trình tải lại dữ liệu lên lưới, khóa ô nhập, đưa nút về trạng thái ban đầu

        private void btnCancel_Click(object sender, EventArgs e) //hủy
        {
            UIService.SetInputsEnabled(tlplnputs, false); //khóa form lại
            UIService.SetButtonsEnabled(this, false);
            BindData(); // Hiển thị lại dữ liệu dòng đang chọn (hoàn tác thay đổi trên form)
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        // ================================================================
        // TÌM KIẾM — TextChanged
        // ================================================================

        //PHÁT HIỆN NGƯỜI DÙNG ĐANG GÕ: TXTTIMKIEM_TEXTCHANGED
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            LoadData(); // Mỗi khi gõ một ký tự, tải lại danh sách ngay lập tức 
        } //// Mỗi khi gõ 1 ký tự → gọi LoadData() ngay lập tức
        //Sự kiện này tự động kích hoạt mỗi khi bạn gõ hoặc xóa một ký tự trong ô tìm kiếm.


        // ================================================================
        // CHỌN DÒNG TRÊN LƯỚI
        // ================================================================
        private void dgvQuanlyphong_SelectionChanged(object sender, EventArgs e)
        {
            BindData(); //// Khi click sang dòng khác, cập nhật form bên dưới
        }

        // ================================================================
        // VALIDATE INPUT
        // ================================================================
        private bool ValidateInput()
        {
            if (!UIService.Require(txtSophong, "Vui lòng nhập Số phòng!"))
                return false; // Nếu trống thì báo lỗi và dừng

            if (cboKhunha.SelectedValue == null || cboKhunha.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn Khu nhà!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhunha.Focus();
                return false; // Chưa chọn khu nhà
            }

            if (cboTang.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Tầng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTang.Focus();
                return false; // Chưa chọn tầng
            }

            if (cboLoaiphong.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Loại phòng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiphong.Focus();
                return false; // Chưa chọn loại phòng
            }

            if (!UIService.Require(txtSucchua, "Vui lòng nhập Sức chứa!"))
                return false;

            if (!UIService.IsNumber(txtSucchua, "Sức chứa phải là số nguyên!"))
                return false;

            if (cboGioitinh.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGioitinh.Focus();
                return false;
            }

            if (cboTrangthai.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Trạng thái!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangthai.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtGiaphong.Text) &&
                !UIService.IsNumber(txtGiaphong, "Giá phòng phải là số nguyên!"))
                return false;

            return true;
        }

        // ================================================================
        // KIỂM TRA CÓ SINH VIÊN ĐANG Ở KHÔNG (dùng cho xóa)
        // ================================================================
        private bool IsUsed(string maPhong)
        {
            string sql = @"SELECT COUNT(*)
                           FROM XepPhong
                           WHERE MaPhong   = @MaPhong
                             AND TrangThaiO = N'Đang ở'";
            //Đếm xem có bản ghi nào trong bảng XepPhong với phòng này và đang ở không. Nếu count > 0 thì không cho xóa.

            int count = Convert.ToInt32(_db.ExecuteScalar(
                sql,
                new SqlParameter("@MaPhong", maPhong)
            ));
            return count > 0;
        }

        // ================================================================
        // KIỂM TRA TRÙNG SỐ PHÒNG TRONG KHU
        // ================================================================
        private bool SoPhongExists(string soPhong, string maKhu, string maPhong = "") //ktra trùng số phòng
        {
            string sql = @"SELECT COUNT(*)
                           FROM Phong
                           WHERE SoPhong = @SoPhong
                             AND MaKhu   = @MaKhu
                             AND (@MaPhong = '' OR MaPhong <> @MaPhong)";
            //Điều kiện thông minh: khi Thêm thì maPhong = "" nên kiểm tra tất cả. Khi Sửa thì bỏ qua chính bản ghi đang sửa.

            int count = Convert.ToInt32(_db.ExecuteScalar(
                sql,
                new SqlParameter("@SoPhong", soPhong),
                new SqlParameter("@MaKhu", maKhu),
                new SqlParameter("@MaPhong", maPhong)
            ));
            return count > 0;
        }

        // ================================================================
        // TẢI DỮ LIỆU — theo LoadData() của frmCategory
        // ================================================================

        //GÁN DATATABLE VÀO LƯỚI LOADDATA()
        private void LoadData()
        {
            string keyword = txtTimkiem.Text.Trim(); // Lấy chữ đang gõ → "A101"
            dgvQuanlyphong.DataSource = SearchData(keyword); // Dòng quan trọng nhất — đẩy dữ liệu lên lưới
            if (dgvQuanlyphong.Columns.Count == 0) return;
            dgvQuanlyphong.Columns["GiaPhong"].DefaultCellStyle.Format = "N0"; // Format cột Giá phòng: 500000 → 500,000
        }

        // ================================================================
        // HIỂN THỊ DỮ LIỆU LÊN FORM KHI CHỌN DÒNG — theo BindData()
        // ================================================================
        private void BindData() 
        {
            if (dgvQuanlyphong.CurrentRow == null)
            {
                UIService.ClearInputs(tlplnputs);
                ResetCombos();
                return;
            }

            DataGridViewRow row = dgvQuanlyphong.CurrentRow; // Gán từng ô text từ dòng đang chọn trên lưới

            txtMaphong.Text = row.Cells["MaPhong"].Value?.ToString() ?? "";
            txtSophong.Text = row.Cells["SoPhong"].Value?.ToString() ?? "";
            txtSucchua.Text = row.Cells["SucChua"].Value?.ToString() ?? "";
            txtSonguoio.Text = row.Cells["SoNguoiHienTai"].Value?.ToString() ?? "";
            txtGiaphong.Text = row.Cells["GiaPhong"].Value?.ToString() ?? "";
            txtGhichu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";

            // Lấy chi tiết từ DB để điền combobox (cần MaKhu thực)
            string maPhong = txtMaphong.Text;
            if (string.IsNullOrEmpty(maPhong)) return;

            DataTable dt = _db.ExecuteQuery(
                "SELECT * FROM Phong WHERE MaPhong = @MaPhong", //// Vì combobox cần MaKhu (không hiển thị trên lưới), phải truy vấn lại DB
                new SqlParameter("@MaPhong", maPhong));

            if (dt.Rows.Count == 0) return;
            DataRow r = dt.Rows[0];

            try { cboKhunha.SelectedValue = r["MaKhu"].ToString(); } catch { } // Chọn đúng khu nhà

            int tang = r["Tang"] == DBNull.Value ? 0 : Convert.ToInt32(r["Tang"]);
            int idxTang = cboTang.FindStringExact("Tầng " + tang); // Tìm vị trí trong combobox
            cboTang.SelectedIndex = idxTang >= 0 ? idxTang : 0; // Chọn đúng tầng

            SetComboByText(cboLoaiphong, r["LoaiPhong"].ToString());
            SetComboByText(cboGioitinh, r["GioiTinh"].ToString());
            SetComboByText(cboTrangthai, r["TrangThai"].ToString());
        }

        // ================================================================
        // TRUY VẤN DỮ LIỆU
        // ================================================================
        
        //MUỐN ĐẨY DỮ LIỆU TỪ DATABASE SANG LƯỚI ĐỂ CHẠY HIỂN THỊ RA DỮ LIỆU THÌ TỪ DÒNG 421 ->438
        private DataTable SearchData(string keyword = "") 
        {
            string sql = @"SELECT p.MaPhong, p.SoPhong, k.TenKhu AS TenKhu, p.Tang,
                                  p.LoaiPhong, p.SucChua, p.SoNguoiHienTai,
                                  p.GiaPhong, p.GioiTinh, p.TrangThai, p.GhiChu
                           FROM Phong p
                           INNER JOIN KhuNha k ON p.MaKhu = k.MaKhu
                           WHERE (@Keyword = N'' OR p.SoPhong   LIKE @Keyword
                                                 OR k.TenKhu    LIKE @Keyword
                                                 OR p.TrangThai LIKE @Keyword)
                           ORDER BY p.MaPhong";

            return _db.ExecuteQuery(
                sql,
                new SqlParameter("@Keyword", "%" + keyword.Trim() + "%")
            );
        }
        //HÀM NÀY TRUY VẤN SQL VÀ TRẢ VỀ MỘT DATATABLE CHƯA TOÀN BỘ DỮ LIỆU PHÒNG

        // ================================================================
        // THÊM DỮ LIỆU — theo InsertData() của Quanlyphong
        // ================================================================
        private void InsertData(string maPhong, string soPhong, string maKhu,
            int tang, string loai, int sucChua, int gia,
            string gioiTinh, string trangThai, string ghiChu)
        {
            string sql = @"INSERT INTO Phong
                               (MaPhong, SoPhong, MaKhu, Tang, LoaiPhong,
                                SucChua, SoNguoiHienTai, GiaPhong, GioiTinh, TrangThai, GhiChu)
                           VALUES
                               (@MaPhong, @SoPhong, @MaKhu, @Tang, @LoaiPhong,
                                @SucChua, 0, @GiaPhong, @GioiTinh, @TrangThai, @GhiChu)";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaPhong", maPhong),
                new SqlParameter("@SoPhong", soPhong),
                new SqlParameter("@MaKhu", maKhu),
                new SqlParameter("@Tang", tang),
                new SqlParameter("@LoaiPhong", loai),
                new SqlParameter("@SucChua", sucChua),
                new SqlParameter("@GiaPhong", gia),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", ghiChu)
            );
        }

        // ================================================================
        // SỬA DỮ LIỆU — theo UpdateData() của Quanlyphong
        // ================================================================
        private void UpdateData(string maPhong, string soPhong, string maKhu,
            int tang, string loai, int sucChua, int gia,
            string gioiTinh, string trangThai, string ghiChu)
        {
            string sql = @"UPDATE Phong
                           SET SoPhong   = @SoPhong,
                               MaKhu     = @MaKhu,
                               Tang      = @Tang,
                               LoaiPhong = @LoaiPhong,
                               SucChua   = @SucChua,
                               GiaPhong  = @GiaPhong,
                               GioiTinh  = @GioiTinh,
                               TrangThai = @TrangThai,
                               GhiChu    = @GhiChu
                           WHERE MaPhong = @MaPhong";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaPhong", maPhong),
                new SqlParameter("@SoPhong", soPhong),
                new SqlParameter("@MaKhu", maKhu),
                new SqlParameter("@Tang", tang),
                new SqlParameter("@LoaiPhong", loai),
                new SqlParameter("@SucChua", sucChua),
                new SqlParameter("@GiaPhong", gia),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", ghiChu)
            );
        }

        // ================================================================
        // XÓA DỮ LIỆU — theo DeleteData() của Quanlyphong
        // ================================================================
        private void DeleteData(string maPhong)
        {
            string sql = "DELETE FROM Phong WHERE MaPhong = @MaPhong";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaPhong", maPhong)
            );
        }

        // ================================================================
        // LẤY MÃ PHÒNG ĐANG CHỌN — theo GetCurrentID() của Quanlyphong
        // ================================================================
        private string GetCurrentID()
        {
            if (dgvQuanlyphong.CurrentRow == null) return "";
            return dgvQuanlyphong.CurrentRow.Cells["MaPhong"].Value?.ToString() ?? "";
        }

        // ================================================================
        // TẠO MÃ PHÒNG TỰ ĐỘNG
        // ================================================================
        private string GenerateMaPhong()
        {
            object obj = _db.ExecuteScalar(
                @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaPhong,2,LEN(MaPhong)) AS INT)),0)+1
                  FROM Phong
                  WHERE MaPhong LIKE 'P%'
                    AND ISNUMERIC(SUBSTRING(MaPhong,2,LEN(MaPhong)))=1"); //Lấy số lớn nhất trong các mã dạng P001, P002... rồi cộng thêm 1.
           // Ví dụ: hiện có P001, P002, P003 → trả về 4 → mã mới là P004.
            int next = obj != null ? Convert.ToInt32(obj) : 1;
            return "P" + next.ToString("D3"); // D3 = định dạng 3 chữ số: 1→"001"
        }

        // ================================================================
        // HELPER: đặt combobox theo text
        // ================================================================
        private void SetComboByText(ComboBox cbo, string text)
        {
            int idx = cbo.FindStringExact(text); // Tìm vị trí của text trong combobox
            cbo.SelectedIndex = idx >= 0 ? idx : 0; // Nếu không tìm thấy thì về dòng đầu
        }

        // ================================================================
        // HELPER: reset tất cả combobox về index 0
        // ================================================================
        private void ResetCombos()
        {
            cboKhunha.SelectedIndex = 0; // Đưa tất cả combobox về dòng mặc định (-- Chọn... --)
            cboTang.SelectedIndex = 0;
            cboLoaiphong.SelectedIndex = 0;
            cboGioitinh.SelectedIndex = 0;
            cboTrangthai.SelectedIndex = 0;
        }

        private void dgvQuanlyphong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}