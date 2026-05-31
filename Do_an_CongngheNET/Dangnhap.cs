using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Dangnhap : Form
    {
        // ----------------------------------------------------------------
        // 1. KHAI BÁO BIẾN
        // ----------------------------------------------------------------
        private readonly DBService _db;

        // ----------------------------------------------------------------
        // 2. CONSTRUCTOR
        // ----------------------------------------------------------------
        public Dangnhap()
        {
            InitializeComponent();
            _db = new DBService();
            InitForm();
        }

        // ================================================================
        // PHẦN A – KHỞI TẠO FORM
        // ================================================================

        private void InitForm()
        {
            // Style cho lblDangnhap như nút bấm
            lblDangnhap.Cursor = Cursors.Hand;
            lblDangnhap.ForeColor = Color.White;
            lblDangnhap.BackColor = Color.SteelBlue;

            // Style cho lblQuenmk như hyperlink
            lblQuenmk.Cursor = Cursors.Hand;
            lblQuenmk.ForeColor = Color.Blue;
            lblQuenmk.Font = new Font(lblQuenmk.Font, FontStyle.Underline);

            // Đăng ký sự kiện
            lblDangnhap.Click += lblDangnhap_Click;
            lblQuenmk.Click += lblQuenmk_Click;

            txtuser.KeyDown += txtuser_KeyDown;
            textkey.KeyDown += textkey_KeyDown;

            chkHienthimk.CheckedChanged += chkHienthimk_CheckedChanged;
            chkGhinhodn.CheckedChanged += chkGhinhodn_CheckedChanged;

            // Mặc định: ẩn mật khẩu
            textkey.PasswordChar = '*';

            // Focus vào ô tên đăng nhập
            txtuser.Focus();
        }

        // ================================================================
        // PHẦN B – XỬ LÝ ĐĂNG NHẬP
        // ================================================================

        private void lblDangnhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra bắt buộc nhập
            if (!UIService.Require(txtuser, "Vui lòng nhập tên đăng nhập!")) return;
            if (!UIService.Require(textkey, "Vui lòng nhập mật khẩu!")) return;

            // Kiểm tra độ dài tối đa
            if (!UIService.MaxLength(txtuser, 50, "Tên đăng nhập không được quá 50 ký tự!")) return;
            if (!UIService.MaxLength(textkey, 50, "Mật khẩu không được quá 50 ký tự!")) return;

            // Truy vấn tài khoản
            DataTable dt = GetAccount(txtuser.Text.Trim(), textkey.Text.Trim());

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textkey.Clear();
                textkey.Focus();
                return;
            }

            // ── Lưu thông tin vào Session ──────────────────────────────
            DataRow row = dt.Rows[0];
            SessionManager.MaTK = row["MaTK"].ToString().Trim();
            SessionManager.TenDangNhap = row["TenDangNhap"].ToString();
            SessionManager.HoTen = row["HoTen"].ToString();
            SessionManager.TenVaiTro = row["TenVaiTro"].ToString();

            // ── Load quyền theo tài khoản ──────────────────────────────
            SessionManager.Quyen.Clear();
            DataTable dtQuyen = _db.ExecuteQuery(
                @"SELECT MaCN, DuocTruyCap
                  FROM   tblPHANQUYEN
                  WHERE  MaTK = @MaTK",
                new SqlParameter("@MaTK", SessionManager.MaTK));

            foreach (DataRow r in dtQuyen.Rows)
            {
                string maCN = r["MaCN"].ToString().Trim();
                bool duocTruyCap = r["DuocTruyCap"] != DBNull.Value
                                     && Convert.ToBoolean(r["DuocTruyCap"]);
                SessionManager.Quyen[maCN] = duocTruyCap;
            }
            // ───────────────────────────────────────────────────────────

            MessageBox.Show("Đăng nhập hệ thống thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Mở form chính
            frmMain frm = new frmMain();
            this.Hide();
            frm.Show();
        }

        // ================================================================
        // PHẦN C – HÀM HELPER
        // ================================================================

        /// <summary>Truy vấn tài khoản theo tên đăng nhập và mật khẩu, kèm TenVaiTro</summary>
        private DataTable GetAccount(string tenDangNhap, string matKhau)
        {
            string sql = @"SELECT tk.*, vt.TenVaiTro
                           FROM   tblTAIKHOAN tk
                           INNER JOIN tblVAITRO vt ON tk.MaVaiTro = vt.MaVaiTro
                           WHERE  tk.TenDangNhap = @TenDangNhap
                             AND  tk.MatKhau     = @MatKhau
                             AND  tk.TrangThai   = N'Hoạt động'";

            return _db.ExecuteQuery(sql,
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@MatKhau", matKhau));
        }

        // ================================================================
        // PHẦN D – XỬ LÝ SỰ KIỆN CONTROL
        // ================================================================

        private void txtuser_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter / mũi tên xuống -> chuyển sang ô mật khẩu
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                textkey.Focus();
                e.Handled = true;
            }
        }

        private void textkey_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter -> đăng nhập luôn
            if (e.KeyCode == Keys.Enter)
            {
                lblDangnhap_Click(sender, e);
                e.Handled = true;
            }
            // Mũi tên lên -> quay lại ô tên đăng nhập
            else if (e.KeyCode == Keys.Up)
            {
                txtuser.Focus();
                e.Handled = true;
            }
        }

        private void chkHienthimk_CheckedChanged(object sender, EventArgs e)
        {
            textkey.PasswordChar = chkHienthimk.Checked ? '\0' : '*';
        }

        private void chkGhinhodn_CheckedChanged(object sender, EventArgs e) { }

        private void lblQuenmk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng quên mật khẩu chưa được cài đặt.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // PHẦN E – STUB HANDLER DO DESIGNER YÊU CẦU
        // ================================================================

        private void tlpHeader_Paint(object sender, PaintEventArgs e) { }
        private void tlpContent4_Paint(object sender, PaintEventArgs e) { }
        private void lblHethong_Click(object sender, EventArgs e) { }
    }
}