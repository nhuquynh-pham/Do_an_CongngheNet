using QLKTX;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Quanlytaikhoan : Form
    {
        private readonly DBService _db;
        private SaveMode _saveMode = SaveMode.Insert;

        public Quanlytaikhoan()
        {
            InitializeComponent();
            _db = new DBService();
        }

        // ================================================================
        // SỰ KIỆN LOAD FORM
        // ================================================================
        private void Quanlytaikhoan_Load(object sender, EventArgs e)
        {
            // Kiểm tra quyền — không có quyền: giữ form trống,
            // đợi render xong rồi mới hiện thông báo
            if (!SessionManager.CoQuyen("CN011"))
            {
                this.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }));
                return; // dừng lại, không load dữ liệu gì cả
            }

            // Có quyền → load bình thường
            try
            {
                btnNew.Tag = "select";
                btnEdit.Tag = "select";
                btnDelete.Tag = "select";
                btnClose.Tag = "select";
                btnSave.Tag = "confirm";
                btnCancel.Tag = "confirm";

                UIService.SetInputsEnabled(this, false);
                UIService.SetButtonsEnabled(this, false);
                txtSearch.Enabled = true;

                UIService.SetGridStyle(dgvCategory);

                LoadVaiTro();
                LoadData();

                UIService.SetGridHeader(dgvCategory,
                    "Ma TK", "Ten Dang Nhap", "Ho Ten",
                    "Chuc Vu", "Vai Tro", "So DT",
                    "Email", "Trang Thai", "Ghi Chu");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================================
        // NẠP DANH SÁCH VAI TRÒ VÀO COMBOBOX
        // ================================================================
        private void LoadVaiTro()
        {
            string sql = "SELECT MaVaiTro, TenVaiTro FROM tblVAITRO ORDER BY MaVaiTro";
            DataTable dt = _db.ExecuteQuery(sql);

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;

            cboquyenhan.DataSource = null;
            cboquyenhan.DisplayMember = "";
            cboquyenhan.ValueMember = "";
            cboquyenhan.DataSource = bs;
            cboquyenhan.DisplayMember = "TenVaiTro";
            cboquyenhan.ValueMember = "MaVaiTro";
            cboquyenhan.SelectedIndex = -1;
        }

        // ================================================================
        // NÚT THÊM MỚI
        // ================================================================
        private void btnNew_Click(object sender, EventArgs e)
        {
            _saveMode = SaveMode.Insert;

            UIService.ClearInputs(this);
            LoadVaiTro();
            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);

            txtTendangnhap.Enabled = true;
            txtmatkhau.Enabled = true;
            txtSearch.Enabled = true;

            txtTendangnhap.Focus();
        }

        // ================================================================
        // NÚT SỬA
        // ================================================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategory.CurrentRow == null)
            {
                MessageBox.Show("Chon du lieu can sua",
                    "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _saveMode = SaveMode.Update;

            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);

            txtTendangnhap.Enabled = false;
            txtmatkhau.Clear();
            txtSearch.Enabled = true;
            txthoten.Focus();
        }

        // ================================================================
        // NÚT XÓA
        // ================================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategory.CurrentRow == null)
            {
                MessageBox.Show("Chon du lieu can xoa",
                    "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!UIService.ConfirmDelete()) return;

            DeleteData(GetCurrentMaTK());
            LoadData();
            UIService.ClearInputs(this);
            LoadVaiTro();
        }

        // ================================================================
        // NÚT GHI (LƯU)
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string tenDN = txtTendangnhap.Text.Trim();
            string matKhau = txtmatkhau.Text.Trim();
            string hoTen = txthoten.Text.Trim();
            string chucVu = cbochucvu.Text.Trim();
            string maVaiTro = cboquyenhan.SelectedValue?.ToString() ?? "";
            string sdt = txtsodienthoai.Text.Trim();
            string email = txtmail.Text.Trim();
            string trangThai = cboTrangthai.Text;
            string ghiChu = txtghichu.Text.Trim();

            try
            {
                if (_saveMode == SaveMode.Insert)
                {
                    if (TenDangNhapExists(tenDN))
                    {
                        MessageBox.Show("Ten dang nhap da ton tai",
                            "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTendangnhap.Focus();
                        return;
                    }

                    string maTK = GenerateMaTK();
                    InsertData(maTK, tenDN, matKhau, hoTen,
                               maVaiTro, chucVu, sdt, email, trangThai, ghiChu);

                    MessageBox.Show("Them thanh cong",
                        "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string maTK = GetCurrentMaTK();

                    if (string.IsNullOrWhiteSpace(matKhau))
                        UpdateDataNoPassword(maTK, hoTen, maVaiTro,
                                             chucVu, sdt, email, trangThai, ghiChu);
                    else
                        UpdateData(maTK, matKhau, hoTen, maVaiTro,
                                   chucVu, sdt, email, trangThai, ghiChu);

                    MessageBox.Show("Cap nhat thanh cong",
                        "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadData();
                LoadVaiTro();

                UIService.SetInputsEnabled(this, false);
                UIService.SetButtonsEnabled(this, false);
                txtSearch.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================================
        // NÚT HỦY GHI
        // ================================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            txtSearch.Enabled = true;
            BindData();
        }

        // ================================================================
        // NÚT KẾT THÚC
        // ================================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ================================================================
        // TÌM KIẾM KHI NHẤN ENTER
        // ================================================================
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // ================================================================
        // KHI CHỌN DÒNG TRÊN LƯỚI → HIỂN THỊ DỮ LIỆU LÊN FORM
        // ================================================================
        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            BindData();
        }

        // ================================================================
        // TẢI DỮ LIỆU LÊN LƯỚI
        // ================================================================
        private void LoadData()
        {
            dgvCategory.DataSource = SearchData(txtSearch.Text.Trim());
        }

        private DataTable SearchData(string keyword = "")
        {
            string sql = @"
                SELECT
                    tk.MaTK        AS [Ma TK],
                    tk.TenDangNhap AS [Ten Dang Nhap],
                    tk.HoTen       AS [Ho Ten],
                    tk.ChucVu      AS [Chuc Vu],
                    vt.TenVaiTro   AS [Vai Tro],
                    tk.SDT         AS [So DT],
                    tk.Email       AS [Email],
                    tk.TrangThai   AS [Trang Thai],
                    tk.GhiChu      AS [Ghi Chu]
                FROM tblTAIKHOAN tk
                INNER JOIN tblVAITRO vt ON tk.MaVaiTro = vt.MaVaiTro
                WHERE
                    tk.TenDangNhap LIKE @Keyword
                    OR tk.HoTen    LIKE @Keyword
                    OR tk.ChucVu   LIKE @Keyword
                    OR vt.TenVaiTro LIKE @Keyword
                ORDER BY tk.MaTK";

            return _db.ExecuteQuery(sql,
                new SqlParameter("@Keyword", "%" + keyword + "%"));
        }

        // ================================================================
        // GÁN DỮ LIỆU TỪ LƯỚI LÊN FORM
        // ================================================================
        private void BindData()
        {
            if (dgvCategory.CurrentRow == null)
            {
                UIService.ClearInputs(this);
                return;
            }

            txtTendangnhap.Text = GetCellValue("Ten Dang Nhap");
            txthoten.Text = GetCellValue("Ho Ten");
            cbochucvu.Text = GetCellValue("Chuc Vu");
            txtsodienthoai.Text = GetCellValue("So DT");
            txtmail.Text = GetCellValue("Email");
            cboTrangthai.Text = GetCellValue("Trang Thai");
            txtghichu.Text = GetCellValue("Ghi Chu");
            txtmatkhau.Text = "";

            string tenVaiTro = GetCellValue("Vai Tro");
            DataTable dtVaiTro = null;

            if (cboquyenhan.DataSource is BindingSource bsCheck)
                dtVaiTro = bsCheck.DataSource as DataTable;
            else if (cboquyenhan.DataSource is DataTable dtDirect)
                dtVaiTro = dtDirect;

            if (dtVaiTro != null)
            {
                foreach (DataRow row in dtVaiTro.Rows)
                {
                    if (row["TenVaiTro"].ToString() == tenVaiTro)
                    {
                        cboquyenhan.SelectedValue = row["MaVaiTro"].ToString();
                        break;
                    }
                }
            }
        }

        private string GetCellValue(string col)
        {
            return dgvCategory.CurrentRow.Cells[col].Value?.ToString() ?? "";
        }

        // ================================================================
        // KIỂM TRA DỮ LIỆU ĐẦU VÀO
        // ================================================================
        private bool ValidateInput()
        {
            if (!UIService.Require(txtTendangnhap, "Nhap ten dang nhap")) return false;

            if (_saveMode == SaveMode.Insert)
                if (!UIService.Require(txtmatkhau, "Nhap mat khau")) return false;

            if (!UIService.Require(cboquyenhan, "Chon vai tro")) return false;

            return true;
        }

        // ================================================================
        // KIỂM TRA TÊN ĐĂNG NHẬP ĐÃ TỒN TẠI
        // ================================================================
        private bool TenDangNhapExists(string tenDN)
        {
            string sql = "SELECT COUNT(*) FROM tblTAIKHOAN WHERE TenDangNhap = @TenDN";
            return Convert.ToInt32(_db.ExecuteScalar(sql,
                new SqlParameter("@TenDN", tenDN))) > 0;
        }

        // ================================================================
        // SINH MÃ TÀI KHOẢN TỰ ĐỘNG (TK001, TK002, ...)
        // ================================================================
        private string GenerateMaTK()
        {
            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaTK, 3, LEN(MaTK)) AS INT)), 0) + 1
                           FROM tblTAIKHOAN
                           WHERE MaTK LIKE 'TK%'
                             AND ISNUMERIC(SUBSTRING(MaTK, 3, LEN(MaTK))) = 1";
            return "TK" + Convert.ToInt32(_db.ExecuteScalar(sql)).ToString("D3");
        }

        // ================================================================
        // INSERT
        // ================================================================
        private void InsertData(string maTK, string tenDN, string matKhau,
                                string hoTen, string maVaiTro, string chucVu,
                                string sdt, string email, string trangThai, string ghiChu)
        {
            string sql = @"INSERT INTO tblTAIKHOAN
                               (MaTK, TenDangNhap, MatKhau, HoTen,
                                MaVaiTro, ChucVu, SDT, Email, TrangThai, GhiChu)
                           VALUES
                               (@MaTK, @TenDN, @MatKhau, @HoTen,
                                @MaVaiTro, @ChucVu, @SDT, @Email, @TrangThai, @GhiChu)";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaTK", maTK),
                new SqlParameter("@TenDN", tenDN),
                new SqlParameter("@MatKhau", matKhau),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@MaVaiTro", maVaiTro),
                new SqlParameter("@ChucVu", chucVu),
                new SqlParameter("@SDT", sdt),
                new SqlParameter("@Email", email),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", ghiChu));
        }

        // ================================================================
        // UPDATE (có đổi mật khẩu)
        // ================================================================
        private void UpdateData(string maTK, string matKhau, string hoTen,
                                string maVaiTro, string chucVu, string sdt,
                                string email, string trangThai, string ghiChu)
        {
            string sql = @"UPDATE tblTAIKHOAN
                           SET MatKhau   = @MatKhau,
                               HoTen     = @HoTen,
                               MaVaiTro  = @MaVaiTro,
                               ChucVu    = @ChucVu,
                               SDT       = @SDT,
                               Email     = @Email,
                               TrangThai = @TrangThai,
                               GhiChu    = @GhiChu
                           WHERE MaTK = @MaTK";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaTK", maTK),
                new SqlParameter("@MatKhau", matKhau),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@MaVaiTro", maVaiTro),
                new SqlParameter("@ChucVu", chucVu),
                new SqlParameter("@SDT", sdt),
                new SqlParameter("@Email", email),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", ghiChu));
        }

        // ================================================================
        // UPDATE (giữ nguyên mật khẩu)
        // ================================================================
        private void UpdateDataNoPassword(string maTK, string hoTen,
                                          string maVaiTro, string chucVu, string sdt,
                                          string email, string trangThai, string ghiChu)
        {
            string sql = @"UPDATE tblTAIKHOAN
                           SET HoTen     = @HoTen,
                               MaVaiTro  = @MaVaiTro,
                               ChucVu    = @ChucVu,
                               SDT       = @SDT,
                               Email     = @Email,
                               TrangThai = @TrangThai,
                               GhiChu    = @GhiChu
                           WHERE MaTK = @MaTK";

            _db.ExecuteNonQuery(sql,
                new SqlParameter("@MaTK", maTK),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@MaVaiTro", maVaiTro),
                new SqlParameter("@ChucVu", chucVu),
                new SqlParameter("@SDT", sdt),
                new SqlParameter("@Email", email),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", ghiChu));
        }

        // ================================================================
        // DELETE
        // ================================================================
        private void DeleteData(string maTK)
        {
            _db.ExecuteNonQuery("DELETE FROM tblTAIKHOAN WHERE MaTK = @MaTK",
                new SqlParameter("@MaTK", maTK));
        }

        private string GetCurrentMaTK()
        {
            return dgvCategory.CurrentRow.Cells["Ma TK"].Value?.ToString() ?? "";
        }

        // ================================================================
        // SỰ KIỆN GIỮ LẠI TỪ DESIGNER
        // ================================================================
        private void pnlHeader_Paint(object sender, PaintEventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void tlpSearch_Paint(object sender, PaintEventArgs e) { }
        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}