using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Quenmatkhau : Form
    {
        // khai báo đối tượng _db - giống thầy: private readonly DBService _db
        private readonly DBService _db;

        // lưu OTP đã sinh và tên đăng nhập tìm được
        private string _otpHienTai = "";
        private string _tenDangNhapTimDuoc = "";

        public Quenmatkhau()
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
            // ẩn mật khẩu mặc định
            txtMatkhau.PasswordChar = '*';
            txtNhaplaimk.PasswordChar = '*';

            // style cho lblGuima như nút bấm
            lblGuima.Cursor = Cursors.Hand;
            lblGuima.ForeColor = Color.Blue;
            lblGuima.Font = new Font(lblGuima.Font, FontStyle.Underline);

            // style cho lblXacnhanmk như nút bấm
            lblXacnhanmk.Cursor = Cursors.Hand;
            lblXacnhanmk.ForeColor = Color.White;
            lblXacnhanmk.BackColor = Color.SteelBlue;

            // style cho lblQuaylaidangnhap như link
            lblQuaylaidangnhap.Cursor = Cursors.Hand;
            lblQuaylaidangnhap.ForeColor = Color.Blue;
            lblQuaylaidangnhap.Font = new Font(lblQuaylaidangnhap.Font, FontStyle.Underline);

            // đăng ký sự kiện
            lblGuima.Click += new EventHandler(lblGuima_Click);
            lblXacnhanmk.Click += new EventHandler(lblXacnhanmk_Click);
            lblQuaylaidangnhap.Click += new EventHandler(lblQuaylaidangnhap_Click);
            chkMatkhau.CheckedChanged += new EventHandler(chkMatkhau_CheckedChanged);
            chkNhaplaimk.CheckedChanged += new EventHandler(chkNhaplaimk_CheckedChanged);

            // [UIService.MoveFocus] điều hướng bàn phím Enter/Down/Up
            txtTendangnhap.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtMaxacnhan.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtMatkhau.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
            txtNhaplaimk.KeyDown += (s, ke) => UIService.MoveFocus((Control)s, ke);
        }

        // ================================================================
        // GỬI MÃ OTP
        // ================================================================
        private void lblGuima_Click(object sender, EventArgs e)
        {
            // [UIService.Require] kiểm tra bắt buộc nhập
            if (!UIService.Require(txtTendangnhap,
                "Vui lòng nhập tên đăng nhập hoặc email!")) return;

            string input = txtTendangnhap.Text.Trim();

            // tìm tài khoản trong DB
            string tenDangNhap = TimTaiKhoan(input);

            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập hoặc email không tồn tại trong hệ thống!",
                    "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTendangnhap.Focus();
                return;
            }

            _tenDangNhapTimDuoc = tenDangNhap;

            // sinh OTP ngẫu nhiên 6 chữ số
            Random rnd = new Random();
            _otpHienTai = rnd.Next(100000, 999999).ToString();

            MessageBox.Show(
                $"Mã xác nhận đã được tạo!\nMã OTP của bạn là: {_otpHienTai}\n\n" +
                "(Trong thực tế mã sẽ được gửi qua email/SMS)",
                "Mã xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // TÌM TÀI KHOẢN THEO TenDangNhap HOẶC Email
        // ================================================================
        private string TimTaiKhoan(string input)
        {
            // _db.ExecuteQuery - giống thầy
            DataTable dt = _db.ExecuteQuery(
                @"SELECT TenDangNhap FROM TaiKhoan
                  WHERE TenDangNhap = @Input1 OR Email = @Input2",
                new SqlParameter("@Input1", input),
                new SqlParameter("@Input2", input));

            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0]["TenDangNhap"].ToString();

            return "";
        }

        // ================================================================
        // HIỆN/ẨN MẬT KHẨU MỚI
        // ================================================================
        private void chkMatkhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatkhau.PasswordChar = chkMatkhau.Checked ? '\0' : '*';
        }

        // ================================================================
        // HIỆN/ẨN NHẬP LẠI MẬT KHẨU
        // ================================================================
        private void chkNhaplaimk_CheckedChanged(object sender, EventArgs e)
        {
            txtNhaplaimk.PasswordChar = chkNhaplaimk.Checked ? '\0' : '*';
        }

        // ================================================================
        // XÁC NHẬN ĐỔI MẬT KHẨU
        // ================================================================
        private void lblXacnhanmk_Click(object sender, EventArgs e)
        {
            // [UIService.Require] kiểm tra bắt buộc nhập
            if (!UIService.Require(txtTendangnhap,
                "Vui lòng nhập tên đăng nhập hoặc email!")) return;

            // kiểm tra đã bấm "Gửi mã" chưa
            if (string.IsNullOrEmpty(_otpHienTai) || string.IsNullOrEmpty(_tenDangNhapTimDuoc))
            {
                MessageBox.Show("Vui lòng bấm 'Gửi mã' để nhận mã xác nhận trước!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [UIService.Require] kiểm tra bắt buộc nhập
            if (!UIService.Require(txtMaxacnhan, "Vui lòng nhập mã xác nhận!")) return;
            if (!UIService.Require(txtMatkhau, "Vui lòng nhập mật khẩu mới!")) return;

            // [UIService.MaxLength] kiểm tra độ dài tối thiểu (dùng MaxLength để kiểm tra ngược)
            if (txtMatkhau.Text.Trim().Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatkhau.Focus(); return;
            }

            // [UIService.MaxLength] kiểm tra độ dài tối đa
            if (!UIService.MaxLength(txtMatkhau, 50,
                "Mật khẩu không được quá 50 ký tự!")) return;

            if (!UIService.Require(txtNhaplaimk, "Vui lòng nhập lại mật khẩu!")) return;

            // kiểm tra 2 mật khẩu có khớp không
            if (txtMatkhau.Text.Trim() != txtNhaplaimk.Text.Trim())
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNhaplaimk.Clear();
                txtNhaplaimk.Focus(); return;
            }

            // kiểm tra OTP có khớp không
            if (txtMaxacnhan.Text.Trim() != _otpHienTai)
            {
                MessageBox.Show("Mã xác nhận không đúng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaxacnhan.Focus(); return;
            }

            // cập nhật mật khẩu mới vào DB
            bool ok = CapNhatMatKhau(_tenDangNhapTimDuoc, txtMatkhau.Text.Trim());

            if (ok)
            {
                // xóa OTP sau khi dùng để tránh dùng lại
                _otpHienTai = "";
                _tenDangNhapTimDuoc = "";

                MessageBox.Show("Đổi mật khẩu thành công!\nVui lòng đăng nhập lại.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MoDangNhap();
            }
        }

        // ================================================================
        // CẬP NHẬT MẬT KHẨU MỚI VÀO BẢNG TaiKhoan
        // ================================================================
        private bool CapNhatMatKhau(string tenDangNhap, string matKhauMoi)
        {
            // _db.ExecuteNonQuery - giống thầy
            int rows = _db.ExecuteNonQuery(
                @"UPDATE TaiKhoan SET MatKhau = @MatKhauMoi
                  WHERE TenDangNhap = @TenDangNhap",
                new SqlParameter("@MatKhauMoi", matKhauMoi),
                new SqlParameter("@TenDangNhap", tenDangNhap));

            return rows > 0;
        }

        // ================================================================
        // QUAY LẠI ĐĂNG NHẬP
        // ================================================================
        private void lblQuaylaidangnhap_Click(object sender, EventArgs e)
        {
            MoDangNhap();
        }

        // ================================================================
        // HÀM DÙNG CHUNG MỞ LẠI FORM ĐĂNG NHẬP
        // ================================================================
        private void MoDangNhap()
        {
            Dangnhap frmDN = new Dangnhap();
            frmDN.Show();
            this.Close();
        }
    }
}