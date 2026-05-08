using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Quanlykhunha : Form
    {
        // khai báo đối tượng _db
        private readonly DBService _db; // đối tượng kết nối CSDL

        private bool dangThemMoi = false; //đang ở chế độ thêm mới
        private bool dangSua = false; // đang ở chế độ sửa

    // _db là cầu nối giữa biểu mẫu và CSDL. mọi thao tác đọc ghi dữ liệu đều thông qua nó
    // bool được sử dụng để phân biệt nhấn lưu sẽ thêm mới hoặc cập nhật
        public Quanlykhunha()
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
            cboLoaikhu.Items.AddRange(new string[] { "Nam", "Nữ" });
            cboTrangthai.Items.AddRange(new string[] { "Đang sử dụng", "Bảo trì", "Ngưng sử dụng" });

            // gán Tag cho nút - để UIService.SetButtonsEnabled hoạt động
            btnNew.Tag = "select";
            btnEdit.Tag = "select";
            btnDelete.Tag = "select";
            btnSave.Tag = "confirm";
            btnCancel.Tag = "confirm";
            btnClose.Tag = "select";

            btnNew.Click += new EventHandler(btnNew_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnClose.Click += new EventHandler(btnClose_Click);

            dgvQuanlykhunha.SelectionChanged += new EventHandler(dgvQuanlykhunha_SelectionChanged);
            txtTimkiemkhu.TextChanged += new EventHandler(txtTimkiemkhu_TextChanged);

            // [UIService.SetGridStyle] thiết lập DataGridView dùng chung
            UIService.SetGridStyle(dgvQuanlykhunha);

            // [UIService.MoveFocus] điều hướng bàn phím Enter/Down/Up
            txtMakhu.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtTenkhu.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtSotang.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtGhichu.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboLoaikhu.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            cboTrangthai.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);

            // đặt txtTongsophong luôn readonly - hệ thống tự tính
            txtTongsophong.Tag = "no-clear";

            // [UIService.SetButtonsEnabled] trạng thái ban đầu: chỉ xem
            SetTrangThaiForm(false);
        }

        // ================================================================
        // TẢI DỮ LIỆU LÊN LƯỚI
        // ================================================================
        private void TaiDuLieu(string tuKhoa = "")
        {
            string sql = @"SELECT MaKhu, TenKhu, LoaiKhu, SoTang, 
                                  TongSoPhong, TrangThai, GhiChu 
                           FROM KhuNha";

            if (!string.IsNullOrEmpty(tuKhoa))
                sql += " WHERE TenKhu LIKE @TuKhoa OR MaKhu LIKE @TuKhoa";

            sql += " ORDER BY MaKhu";

            // _db.ExecuteQuery - giống thầy
            DataTable dt = string.IsNullOrEmpty(tuKhoa)
                ? _db.ExecuteQuery(sql)
                : _db.ExecuteQuery(sql, new SqlParameter("@TuKhoa", "%" + tuKhoa + "%"));

            dgvQuanlykhunha.DataSource = dt;

            if (dgvQuanlykhunha.Columns.Count > 0)
            {
                // [UIService.SetGridHeader] thiết lập tiêu đề cột
                UIService.SetGridHeader(dgvQuanlykhunha,
                    "Mã khu", "Tên khu", "Loại khu", "Số tầng",
                    "Tổng số phòng", "Trạng thái", "Ghi chú");

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
        private void HienThiLenForm(DataGridViewRow row)
        {
            if (row == null) return;
            txtMakhu.Text = row.Cells["MaKhu"].Value?.ToString();
            txtTenkhu.Text = row.Cells["TenKhu"].Value?.ToString();
            cboLoaikhu.Text = row.Cells["LoaiKhu"].Value?.ToString();
            txtSotang.Text = row.Cells["SoTang"].Value?.ToString();
            txtTongsophong.Text = row.Cells["TongSoPhong"].Value?.ToString();
            cboTrangthai.Text = row.Cells["TrangThai"].Value?.ToString();
            txtGhichu.Text = row.Cells["GhiChu"].Value?.ToString();
        }

        // ================================================================
        // XÓA TRẮNG FORM
        // ================================================================
        private void XoaForm()
        {
            // [UIService.ClearInputs] xóa trắng toàn bộ ô nhập trong tlplnputs
            UIService.ClearInputs(tlplnputs);
        }

        // ================================================================
        // KIỂM TRA DỮ LIỆU
        // ================================================================
        private bool KiemTraDuLieu()
        {
            // [UIService.Require] kiểm tra bắt buộc nhập
            if (!UIService.Require(txtMakhu, "Vui lòng nhập Mã khu!")) return false;
            if (!UIService.Require(txtTenkhu, "Vui lòng nhập Tên khu!")) return false;

            // [UIService.MaxLength] kiểm tra độ dài tối đa
            if (!UIService.MaxLength(txtMakhu, 20, "Mã khu không được quá 20 ký tự!")) return false;
            if (!UIService.MaxLength(txtTenkhu, 100, "Tên khu không được quá 100 ký tự!")) return false;

            // [UIService.IsNumber] kiểm tra số tầng
            if (!UIService.IsNumber(txtSotang, "Số tầng phải là số nguyên!")) return false;

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

            // txtTongsophong luôn readonly - hệ thống tự tính
            txtTongsophong.Enabled = false;
            txtTongsophong.ReadOnly = true;
        }

        // ================================================================
        // THÊM MỚI
        // ================================================================
        private void btnNew_Click(object sender, EventArgs e)
        {
            dangThemMoi = true; dangSua = false;
            XoaForm();
            SetTrangThaiForm(true);
            txtMakhu.Focus();
        }

        // ================================================================
        // SỬA
        // ================================================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvQuanlykhunha.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khu nhà cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dangSua = true; dangThemMoi = false;
            SetTrangThaiForm(true);
            txtMakhu.Enabled = false;
            txtTenkhu.Focus();
        }

        // ================================================================
        // XÓA
        // ================================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvQuanlykhunha.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khu nhà cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [UIService.ConfirmDelete] hộp thoại xác nhận xóa
            if (!UIService.ConfirmDelete()) return;

            string maKhu = dgvQuanlykhunha.CurrentRow.Cells["MaKhu"].Value?.ToString();

            // _db.ExecuteNonQuery - giống thầy
            int rows = _db.ExecuteNonQuery(
                "DELETE FROM KhuNha WHERE MaKhu = @MaKhu",
                new SqlParameter("@MaKhu", maKhu));

            if (rows > 0)
            {
                MessageBox.Show("Xóa thành công!", "Thông báo",
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

            string maKhu = txtMakhu.Text.Trim();
            string tenKhu = txtTenkhu.Text.Trim();
            string loai = cboLoaikhu.Text;
            int soTang = int.Parse(txtSotang.Text.Trim());
            string tthai = cboTrangthai.Text;
            string ghichu = txtGhichu.Text.Trim();

            if (dangThemMoi)
            {
                string sql = @"INSERT INTO KhuNha (MaKhu, TenKhu, LoaiKhu, SoTang, TongSoPhong, TrangThai, GhiChu)
                               VALUES (@MaKhu, @TenKhu, @LoaiKhu, @SoTang, 0, @TrangThai, @GhiChu)";

                // _db.ExecuteNonQuery - giống thầy
                int r = _db.ExecuteNonQuery(sql,
                    new SqlParameter("@MaKhu", maKhu),
                    new SqlParameter("@TenKhu", tenKhu),
                    new SqlParameter("@LoaiKhu", loai),
                    new SqlParameter("@SoTang", soTang),
                    new SqlParameter("@TrangThai", tthai),
                    new SqlParameter("@GhiChu", ghichu));

                if (r > 0)
                    MessageBox.Show("Thêm mới thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dangSua)
            {
                string sql = @"UPDATE KhuNha SET TenKhu=@TenKhu, LoaiKhu=@LoaiKhu,
                               SoTang=@SoTang, TrangThai=@TrangThai, GhiChu=@GhiChu
                               WHERE MaKhu=@MaKhu";

                // _db.ExecuteNonQuery - giống thầy
                int r = _db.ExecuteNonQuery(sql,
                    new SqlParameter("@MaKhu", maKhu),
                    new SqlParameter("@TenKhu", tenKhu),
                    new SqlParameter("@LoaiKhu", loai),
                    new SqlParameter("@SoTang", soTang),
                    new SqlParameter("@TrangThai", tthai),
                    new SqlParameter("@GhiChu", ghichu));

                if (r > 0)
                    MessageBox.Show("Cập nhật thành công!", "Thông báo",
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
            if (dgvQuanlykhunha.CurrentRow != null)
                HienThiLenForm(dgvQuanlykhunha.CurrentRow);
        }

        // ================================================================
        // KẾT THÚC
        // ================================================================
        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        // ================================================================
        // CHỌN DÒNG TRÊN LƯỚI
        // ================================================================
        private void dgvQuanlykhunha_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQuanlykhunha.CurrentRow != null)
                HienThiLenForm(dgvQuanlykhunha.CurrentRow);
        }

        // ================================================================
        // TÌM KIẾM
        // ================================================================
        private void txtTimkiemkhu_TextChanged(object sender, EventArgs e)
        {
            TaiDuLieu(txtTimkiemkhu.Text.Trim());
        }

        private void txtLoaikhu_TextChanged(object sender, EventArgs e) { }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblMakhu_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {

        }
    }
}