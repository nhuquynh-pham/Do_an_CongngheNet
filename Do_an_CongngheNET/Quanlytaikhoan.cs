using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Quanlytaikhoan : Form
    {
        private readonly DBService _db = new DBService();
        private SaveMode _saveMode = SaveMode.Insert;

        public Quanlytaikhoan()
        {
            InitializeComponent();
        }

        //===================== LOAD =====================

        private void Quanlytaikhoan_Load(object sender, EventArgs e)
        {
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
                UIService.SetGridStyle(dgvCategory);

                LoadVaiTro();
                LoadData();

                UIService.SetGridHeader(
                    dgvCategory,
                    "Ma TK",
                    "Ten Dang Nhap",
                    "Ho Ten",
                    "Chuc Vu",
                    "Vai Tro",
                    "So DT",
                    "Email",
                    "Trang Thai",
                    "Ghi Chu");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Loi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Nap danh sach vai tro vao ComboBox cboquyenhan
        // Dung BindingSource rieng biet de tranh WinForms tu dong
        // dong bo DataSource sang cac ComboBox khac cung form
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

        //===================== THEM =====================

        private void btnNew_Click(object sender, EventArgs e)
        {
            _saveMode = SaveMode.Insert;

            UIService.ClearInputs(this);
            LoadVaiTro();
            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);

            txtTendangnhap.Enabled = true;
            txtmatkhau.Enabled = true;

            txtTendangnhap.Focus();
        }

        //===================== SUA =====================

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategory.CurrentRow == null)
            {
                MessageBox.Show("Chon du lieu can sua");
                return;
            }

            _saveMode = SaveMode.Update;

            UIService.SetInputsEnabled(this, true);
            UIService.SetButtonsEnabled(this, true);

            txtTendangnhap.Enabled = false;
            txtmatkhau.Clear();
            txthoten.Focus();
        }

        //===================== XOA =====================

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategory.CurrentRow == null)
            {
                MessageBox.Show("Chon du lieu can xoa");
                return;
            }

            if (!UIService.ConfirmDelete())
                return;

            DeleteData(GetCurrentMaTK());
            LoadData();
            UIService.ClearInputs(this);
            LoadVaiTro();

            MessageBox.Show("Xoa thanh cong");
        }

        //===================== LUU =====================

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

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
                        MessageBox.Show("Ten dang nhap da ton tai");
                        return;
                    }

                    string maTK = GenerateMaTK();

                    InsertData(maTK, tenDN, matKhau, hoTen,
                               maVaiTro, chucVu, sdt, email, trangThai, ghiChu);

                    MessageBox.Show("Them thanh cong");
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

                    MessageBox.Show("Cap nhat thanh cong");
                }

                LoadData();
                LoadVaiTro();

                UIService.SetInputsEnabled(this, false);
                UIService.SetButtonsEnabled(this, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //===================== HUY =====================

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UIService.SetInputsEnabled(this, false);
            UIService.SetButtonsEnabled(this, false);
            BindData();
        }

        //===================== DONG =====================

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //===================== TIM KIEM =====================

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
                e.SuppressKeyPress = true;
            }
        }

        //===================== LOAD DATA =====================

        private void LoadData()
        {
            dgvCategory.DataSource = SearchData(txtSearch.Text.Trim());
        }

        private DataTable SearchData(string keyword)
        {
            string sql = @"
            SELECT
                tk.MaTK         AS [Ma TK],
                tk.TenDangNhap  AS [Ten Dang Nhap],
                tk.HoTen        AS [Ho Ten],
                tk.ChucVu       AS [Chuc Vu],
                vt.TenVaiTro    AS [Vai Tro],
                tk.SDT          AS [So DT],
                tk.Email        AS [Email],
                tk.TrangThai    AS [Trang Thai],
                tk.GhiChu       AS [Ghi Chu]
            FROM tblTAIKHOAN tk
            INNER JOIN tblVAITRO vt ON tk.MaVaiTro = vt.MaVaiTro
            WHERE
                tk.TenDangNhap  LIKE @Keyword
                OR tk.HoTen     LIKE @Keyword
                OR tk.ChucVu    LIKE @Keyword
                OR vt.TenVaiTro LIKE @Keyword
            ORDER BY tk.MaTK";

            return _db.ExecuteQuery(
                sql,
                new SqlParameter("@Keyword", "%" + keyword + "%"));
        }

        //===================== HIEN THI =====================

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            if (dgvCategory.CurrentRow == null)
                return;

            txtTendangnhap.Text = GetCellValue("Ten Dang Nhap");
            txthoten.Text = GetCellValue("Ho Ten");
            cbochucvu.Text = GetCellValue("Chuc Vu");
            txtsodienthoai.Text = GetCellValue("So DT");
            txtmail.Text = GetCellValue("Email");
            cboTrangthai.Text = GetCellValue("Trang Thai");
            txtghichu.Text = GetCellValue("Ghi Chu");
            txtmatkhau.Text = "";

            // Chon dung vai tro trong ComboBox theo TenVaiTro hien thi
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
            return dgvCategory
                .CurrentRow
                .Cells[col]
                .Value?.ToString() ?? "";
        }

        //===================== KIEM TRA =====================

        private bool ValidateInput()
        {
            if (!UIService.Require(txtTendangnhap, "Nhap ten dang nhap"))
                return false;

            if (_saveMode == SaveMode.Insert)
            {
                if (!UIService.Require(txtmatkhau, "Nhap mat khau"))
                    return false;
            }

            if (!UIService.Require(cboquyenhan, "Chon vai tro"))
                return false;

            return true;
        }

        private bool TenDangNhapExists(string tenDN)
        {
            string sql =
                "SELECT COUNT(*) FROM tblTAIKHOAN WHERE TenDangNhap = @TenDN";

            int count = Convert.ToInt32(
                _db.ExecuteScalar(sql,
                    new SqlParameter("@TenDN", tenDN)));

            return count > 0;
        }

        // Tu sinh MaTK theo dang TK001, TK002, ...
        private string GenerateMaTK()
        {
            string sql = @"
            SELECT ISNULL(MAX(CAST(SUBSTRING(MaTK, 3, LEN(MaTK)) AS INT)), 0) + 1
            FROM tblTAIKHOAN
            WHERE MaTK LIKE 'TK%'
              AND ISNUMERIC(SUBSTRING(MaTK, 3, LEN(MaTK))) = 1";

            int nextNum = Convert.ToInt32(_db.ExecuteScalar(sql));
            return "TK" + nextNum.ToString("D3");
        }

        //===================== INSERT =====================

        private void InsertData(
            string maTK, string tenDN, string matKhau,
            string hoTen, string maVaiTro, string chucVu,
            string sdt, string email, string trangThai,
            string ghiChu)
        {
            string sql = @"
            INSERT INTO tblTAIKHOAN
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

        //===================== UPDATE (co doi mat khau) =====================

        private void UpdateData(
            string maTK, string matKhau, string hoTen,
            string maVaiTro, string chucVu, string sdt,
            string email, string trangThai, string ghiChu)
        {
            string sql = @"
            UPDATE tblTAIKHOAN
            SET
                MatKhau   = @MatKhau,
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

        //===================== UPDATE (giu nguyen mat khau) =====================

        private void UpdateDataNoPassword(
            string maTK, string hoTen,
            string maVaiTro, string chucVu, string sdt,
            string email, string trangThai, string ghiChu)
        {
            string sql = @"
            UPDATE tblTAIKHOAN
            SET
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
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@MaVaiTro", maVaiTro),
                new SqlParameter("@ChucVu", chucVu),
                new SqlParameter("@SDT", sdt),
                new SqlParameter("@Email", email),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", ghiChu));
        }

        //===================== DELETE =====================

        private void DeleteData(string maTK)
        {
            _db.ExecuteNonQuery(
                "DELETE FROM tblTAIKHOAN WHERE MaTK = @MaTK",
                new SqlParameter("@MaTK", maTK));
        }

        private string GetCurrentMaTK()
        {
            return dgvCategory
                .CurrentRow
                .Cells["Ma TK"]
                .Value.ToString();
        }

        //===================== EVENT RONG =====================

        private void pnlHeader_Paint(object sender, PaintEventArgs e) { }

        private void lblTitle_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void label6_Click(object sender, EventArgs e) { }

        private void tlpSearch_Paint(object sender, PaintEventArgs e) { }

        private void dgvCategory_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        { }
    }
}