using QLKTX;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class frmMain : Form
    {
        // ----------------------------------------------------------------
        // CONSTRUCTOR
        // ----------------------------------------------------------------
        public frmMain()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Start();

            GanSuKien();
        }

        // ----------------------------------------------------------------
        // LOAD
        // ----------------------------------------------------------------
        private void frmMain_Load(object sender, EventArgs e)
        {
            CapNhatThoiGian();
        }

        // ----------------------------------------------------------------
        // GÁN SỰ KIỆN (tập trung, không trùng lặp với Designer)
        // ----------------------------------------------------------------
        private void GanSuKien()
        {
            // HỆ THỐNG
            mnuQuanlytaikhoan.Click += mnuQuanlytaikhoan_Click;
            mnuPhanquyen.Click += mnuPhanquyen_Click;
            mnuDangnhap.Click += mnuDangnhap_Click;
            mnuQuenmatkhau.Click += mnuQuenmatkhau_Click;
            mnuKetthuc.Click += mnuKetthuc_Click;

            // QUẢN LÝ
            mnuQuanlysinhvien.Click += mnuQuanlysinhvien_Click;
            mnuQuanlykhunha.Click += mnuQuanlykhunha_Click;
            mnuQuanlyphong.Click += mnuQuanlyphong_Click;

            // NGHIỆP VỤ
            mnuDangkyoxepphong.Click += mnuDangkyoxepphong_Click;
            mnuChuyenphong.Click += mnuChuyenphong_Click;
            mnuTraphong.Click += mnuTraphong_Click;
            mnuNhapdiennuoc.Click += mnuNhapdiennuoc_Click;
            mnuHoadonthanhtoan.Click += mnuHoadonthanhtoan_Click;

            // BÁO CÁO
            mnuThongkebaocao.Click += mnuThongkebaocao_Click;

            // TOOLSTRIP
            tlsQuanlysinhvien.Click += tlsQuanlysinhvien_Click;
            tlsQuanlyphong.Click += tlsQuanlyphong_Click;
            tlsDangkyoxepphong.Click += tlsDangkyoxepphong_Click;
            tlsLaphoadonthanhtoan.Click += tlsLaphoadonthanhtoan_Click;
            tlsThongkebaocao.Click += tlsThongkebaocao_Click;

            // PANEL RESIZE → giữ form Center ở giữa
            pnlMain.Resize += pnlMain_Resize;
        }

        // ================================================================
        // MỞ FORM CON TRONG PANEL CHÍNH
        // ================================================================

        /// <summary>
        /// Nhúng form con vào pnlMain với chế độ Fill hoặc Center.
        /// </summary>
        private void OpenChildForm(Form child, ChildFormMode mode)
        {
            pnlMain.Controls.Clear();
            pnlMain.BackColor = Color.WhiteSmoke;

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.AutoScaleMode = AutoScaleMode.Dpi;
            child.BackColor = Color.White;

            pnlMain.Controls.Add(child);

            if (mode == ChildFormMode.Fill)
            {
                child.Dock = DockStyle.Fill;
            }
            else // Center
            {
                child.Dock = DockStyle.None;
                child.Left = (pnlMain.Width - child.Width) / 2;
                child.Top = (pnlMain.Height - child.Height) / 2;
            }

            child.Show();
        }

        /// <summary>
        /// Tìm kiếm form theo nhiều tên class khác nhau rồi mở.
        /// Cho phép nhóm dự án dùng tên class khác nhau mà không bị lỗi biên dịch.
        /// </summary>
        private void OpenFormByName(ChildFormMode mode, params string[] formNames)
        {
            foreach (string name in formNames)
            {
                Type t = Assembly.GetExecutingAssembly()
                                 .GetType("Do_an_CongngheNET." + name);

                if (t != null && typeof(Form).IsAssignableFrom(t))
                {
                    Form frm = (Form)Activator.CreateInstance(t);
                    OpenChildForm(frm, mode);
                    return;
                }
            }

            MessageBox.Show(
                "Không tìm thấy form cần mở.\n\n" +
                "Vui lòng kiểm tra lại tên class của form.\n" +
                "Tên class nằm ở dòng: public partial class TenForm : Form",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        // ================================================================
        // HỆ THỐNG
        // ================================================================

        private void mnuQuanlytaikhoan_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Center,
                "frmQuanlytaikhoan", "frmQuanLyTaiKhoan",
                "Quanlytaikhoan", "QuanLyTaiKhoan",
                "frmUser", "User");
        }

        private void mnuPhanquyen_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Center,
                "frmPhanquyen", "frmPhanQuyen",
                "Phanquyen", "PhanQuyen",
                "frmRolePermission", "RolePermission");
        }

        private void mnuDangnhap_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Center,
                "frmDangnhap", "frmDangNhap",
                "Dangnhap", "DangNhap",
                "frmLogin", "Login");
        }

        private void mnuQuenmatkhau_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Center,
                "frmQuenmatkhau", "frmQuenMatKhau",
                "Quenmatkhau", "QuenMatKhau",
                "frmForgotPassword", "ForgotPassword");
        }

        private void mnuKetthuc_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        // ================================================================
        // QUẢN LÝ
        // ================================================================

        private void mnuQuanlysinhvien_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Fill,
                "frmQuanlysinhvien", "frmQuanLySinhVien",
                "Quanlysinhvien", "QuanLySinhVien",
                "frmSinhVien", "SinhVien");
        }

        private void mnuQuanlykhunha_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Fill,
                "frmQuanlykhunha", "frmQuanLyKhuNha",
                "Quanlykhunha", "QuanLyKhuNha");
        }

        private void mnuQuanlyphong_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Fill,
                "frmQuanlyphong", "frmQuanLyPhong",
                "Quanlyphong", "QuanLyPhong");
        }

        // ================================================================
        // NGHIỆP VỤ
        // ================================================================

        private void mnuDangkyoxepphong_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Fill,
                "frmDangkyoxepphong", "frmDangKyOXepPhong",
                "Dangkyoxepphong", "DangKyOXepPhong",
                "frmDangKyOPhong", "DangKyOPhong");
        }

        private void mnuChuyenphong_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Fill,
                "frmChuyenphong", "frmChuyenPhong",
                "Chuyenphong", "ChuyenPhong");
        }

        private void mnuTraphong_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Fill,
                "frmTraphong", "frmTraPhong",
                "Traphong", "TraPhong");
        }

        private void mnuNhapdiennuoc_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Fill,
                "frmNhapdiennuoc", "frmNhapDienNuoc",
                "Nhapdiennuoc", "NhapDienNuoc");
        }

        private void mnuHoadonthanhtoan_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Fill,
                "frmHoadonthanhtoan", "frmHoaDonThanhToan",
                "Hoadonthanhtoan", "HoaDonThanhToan",
                "frmHoaDon", "HoaDon");
        }

        // ================================================================
        // BÁO CÁO
        // ================================================================

        private void mnuThongkebaocao_Click(object sender, EventArgs e)
        {
            OpenFormByName(ChildFormMode.Fill,
                "frmThongkebaocao", "frmThongKeBaoCao",
                "Thongkebaocao", "ThongKeBaoCao",
                "frmBaoCao", "BaoCao");
        }

        // ================================================================
        // TOOLSTRIP → gọi lại menu tương ứng
        // ================================================================

        private void tspTrangchu_Click(object sender, EventArgs e)
        {
            mnuQuanlytaikhoan.PerformClick();
        }

        private void tlsQuanlysinhvien_Click(object sender, EventArgs e)
        {
            mnuQuanlysinhvien.PerformClick();
        }

        private void tlsQuanlyphong_Click(object sender, EventArgs e)
        {
            mnuQuanlyphong.PerformClick();
        }

        private void tlsDangkyoxepphong_Click(object sender, EventArgs e)
        {
            mnuDangkyoxepphong.PerformClick();
        }

        private void tlsLaphoadonthanhtoan_Click(object sender, EventArgs e)
        {
            mnuHoadonthanhtoan.PerformClick();
        }

        private void tlsThongkebaocao_Click(object sender, EventArgs e)
        {
            mnuThongkebaocao.PerformClick();
        }

        // ================================================================
        // TIMER – cập nhật giờ mỗi giây
        // ================================================================

        private void timer1_Tick(object sender, EventArgs e)
        {
            CapNhatThoiGian();
        }

        private void CapNhatThoiGian()
        {
            lblTime.Text = "Admin   Time: " + DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
        }

        // ================================================================
        // PANEL RESIZE – giữ form Center ở giữa khi thay đổi kích thước
        // ================================================================

        private void pnlMain_Resize(object sender, EventArgs e)
        {
            if (pnlMain.Controls.Count == 0) return;

            Control child = pnlMain.Controls[0];
            if (child.Dock == DockStyle.None)
            {
                child.Left = (pnlMain.Width - child.Width) / 2;
                child.Top = (pnlMain.Height - child.Height) / 2;
            }
        }
    }
}