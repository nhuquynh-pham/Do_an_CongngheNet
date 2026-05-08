using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Dangnhap : Form
    {
        // khai báo đối tượng _db - giống thầy: private readonly DBService _db
        private readonly DBService _db;

        public Dangnhap()
        {
            InitializeComponent();
            // tạo đối tượng _db trong constructor - giống thầy
            _db = new DBService();

            KhoiTaoForm();
        }

        // ================================================================
        // KHỞI TẠO FORM
        // ================================================================
        private void KhoiTaoForm()
        {
            // style cho lblDangnhap như nút bấm
            lblDangnhap.Cursor = Cursors.Hand;
            lblDangnhap.ForeColor = Color.White;
            lblDangnhap.BackColor = Color.SteelBlue;

            // style cho lblQuenmk như link
            lblQuenmk.Cursor = Cursors.Hand;
            lblQuenmk.ForeColor = Color.Blue;
            lblQuenmk.Font = new Font(lblQuenmk.Font, FontStyle.Underline);

            // đăng ký sự kiện
            lblDangnhap.Click += new EventHandler(lblDangnhap_Click);
            lblQuenmk.Click += new EventHandler(lblQuenmk_Click);

            txtuser.KeyDown += new KeyEventHandler(txtuser_KeyDown);
            textkey.KeyDown += new KeyEventHandler(textkey_KeyDown);

            // [UIService.MoveFocus] điều hướng bàn phím Enter/Down/Up
            txtuser.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
        }

        // ================================================================
        // NÚT ĐĂNG NHẬP
        // ================================================================
        private void lblDangnhap_Click(object sender, EventArgs e)
        {
            // [UIService.Require] kiểm tra bắt buộc nhập
            if (!UIService.Require(txtuser, "Vui lòng nhập tên đăng nhập!")) return;
            if (!UIService.Require(textkey, "Vui lòng nhập mật khẩu!")) return;

            // [UIService.MaxLength] kiểm tra độ dài tối đa
            if (!UIService.MaxLength(txtuser, 50, "Tên đăng nhập không được quá 50 ký tự!")) return;
            if (!UIService.MaxLength(textkey, 50, "Mật khẩu không được quá 50 ký tự!")) return;

            string sql = @"SELECT * FROM TaiKhoan
               WHERE TenDangNhap = @TenDangNhap
               AND MatKhau = @MatKhau
               AND TrangThai = N'Hoạt động'";

            // _db.ExecuteQuery - giống thầy
            DataTable dt = _db.ExecuteQuery(sql,
                new SqlParameter("@TenDangNhap", txtuser.Text.Trim()),
                new SqlParameter("@MatKhau", textkey.Text.Trim()));

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textkey.Clear();
                textkey.Focus();
            }
            else
            {
                MessageBox.Show("Đăng nhập hệ thống thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // lấy tên đăng nhập của tài khoản
                string tenDangNhap = dt.Rows[0]["TenDangNhap"].ToString();

                // Mở form chính sau khi đăng nhập thành công
                frmMain frm = new frmMain();
                this.Hide();
                frm.Show();
            }
        }

        // ================================================================
        // ĐIỀU HƯỚNG BÀN PHÍM
        // ================================================================
        private void txtuser_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter -> chuyển xuống ô mật khẩu
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
            // mũi tên lên -> quay lại ô tên đăng nhập
            else if (e.KeyCode == Keys.Up)
            {
                txtuser.Focus();
                e.Handled = true;
            }
        }

        // ================================================================
        // HIỆN / ẨN MẬT KHẨU
        // ================================================================
        private void chkHienthimk_CheckedChanged(object sender, EventArgs e)
        {
            textkey.PasswordChar = chkHienthimk.Checked ? '\0' : '*';
        }

        private void chkGhinhodn_CheckedChanged(object sender, EventArgs e) { }

        // ================================================================
        // QUÊN MẬT KHẨU
        // ================================================================
        private void lblQuenmk_Click(object sender, EventArgs e)
        {
            Quenmatkhau frmQMK = new Quenmatkhau();
            frmQMK.Show();
            this.Hide();
        }

        private void tlpHeader_Paint(object sender, PaintEventArgs e) { }
        private void tlpContent4_Paint(object sender, PaintEventArgs e) { }
        private void lblHethong_Click(object sender, EventArgs e) { }
    }
}