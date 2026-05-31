using QLKTX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Start();

            GanSuKien();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string ten = SessionManager.HoTen ?? "Khách";
            string vt = SessionManager.TenVaiTro ?? "";
            lblTime.Text = $"{ten} ({vt})   Time: {DateTime.Now:HH:mm:ss - dd/MM/yyyy}";

            ApDungPhanQuyen();
        }

        // =====================================================
        // ẨN / HIỆN MENU THEO QUYỀN
        // =====================================================
        private void ApDungPhanQuyen()
        {
            bool coQuyenSV = SessionManager.CoQuyen("CN001")
                          || SessionManager.CoQuyen("CN002")
                          || SessionManager.CoQuyen("CN003");
            mnuQuanlysinhvien.Visible = coQuyenSV;
            tlsQuanlysinhvien.Visible = coQuyenSV;

            mnuQuanlyphong.Visible = SessionManager.CoQuyen("CN004");
            tlsQuanlyphong.Visible = SessionManager.CoQuyen("CN004");

            mnuQuanlykhunha.Visible = SessionManager.CoQuyen("CN005");

            mnuDangkyoxepphong.Visible = SessionManager.CoQuyen("CN004");
            tlsDangkyoxepphong.Visible = SessionManager.CoQuyen("CN004");
            mnuChuyenphong.Visible = SessionManager.CoQuyen("CN004");
            mnuTraphong.Visible = SessionManager.CoQuyen("CN004");

            bool coQuyenHoaDon = SessionManager.CoQuyen("CN006")
                              || SessionManager.CoQuyen("CN007");
            mnuNhapdiennuoc.Visible = coQuyenHoaDon;
            mnuHoadonthanhtoan.Visible = coQuyenHoaDon;
            tlsLaphoadonthanhtoan.Visible = coQuyenHoaDon;

            mnuThongkebaocao.Visible = SessionManager.CoQuyen("CN010");
            tlsThongkebaocao.Visible = SessionManager.CoQuyen("CN010");

            mnuQuanlyphanquyen.Visible = SessionManager.CoQuyen("CN011");
            mnuQuanlyvaitronguoidung.Visible = SessionManager.CoQuyen("CN011");
            mnuQuanlytaikhoan.Visible = SessionManager.CoQuyen("CN011");
        }

        // =====================================================
        // GÁN SỰ KIỆN CLICK CHO MENU VÀ TOOLSTRIP
        // =====================================================
        private void GanSuKien()
        {
            // HỆ THỐNG
            // mnuQuanlytaikhoan và mnuQuanlyvaitronguoidung đã wire Click trong Designer
            mnuQuanlyphanquyen.Click += mnuQuanlyphanquyen_Click;
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

            pnlMain.Resize += pnlMain_Resize;
        }

        // =====================================================
        // HÀM MỞ FORM CON TRONG PANEL
        // =====================================================
        private void OpenChildForm(Form child, ChildFormMode mode)
        {
            pnlMain.Controls.Clear();
            pnlMain.BackColor = Color.WhiteSmoke;

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.BackColor = Color.White;

            pnlMain.Controls.Add(child);

            if (mode == ChildFormMode.Fill)
            {
                child.Dock = DockStyle.Fill;
            }
            else
            {
                child.Dock = DockStyle.None;
                child.Left = (pnlMain.Width - child.Width) / 2;
                child.Top = (pnlMain.Height - child.Height) / 2;
            }

            child.Show();
        }

        // =====================================================
        // HÀM TỰ TÌM FORM THEO TÊN CLASS RỒI MỞ
        // =====================================================
        private void OpenFormByName(ChildFormMode mode, params string[] formNames)
        {
            foreach (string formName in formNames)
            {
                Type formType = Assembly.GetExecutingAssembly()
                    .GetType("Do_an_CongngheNET." + formName);

                if (formType != null && typeof(Form).IsAssignableFrom(formType))
                {
                    Form frm = (Form)Activator.CreateInstance(formType);
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
                MessageBoxIcon.Warning
            );
        }

        // =====================================================
        // HỆ THỐNG
        // =====================================================
        private void mnuQuanlytaikhoan_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Fill,
                "Quanlytaikhoan", "QuanLyTaiKhoan",
                "frmQuanlytaikhoan", "frmQuanLyTaiKhoan",
                "frmUser", "User"
            );
        }

        private void mnuQuanlyphanquyen_Click(object sender, EventArgs e)
        {
            // ✅ Chỉ mở form phân quyền — bỏ fallback sang Quanlyvaitronguoidung
            //    để tránh mở trùng khi mnuQuanlyvaitronguoidung_Click cũng được gọi
            OpenFormByName(
                ChildFormMode.Fill,
                "Quanlyphanquyen", "QuanLyPhanQuyen",
                "frmQuanlyphanquyen", "frmQuanLyPhanQuyen"
            );
        }

        private void mnuQuanlyvaitronguoidung_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Fill,
                "Quanlyvaitronguoidung", "QuanLyVaiTroNguoiDung",
                "frmQuanlyvaitronguoidung", "frmQuanLyVaiTroNguoiDung"
            );
        }

        private void mnuDangnhap_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Center,
                "Dangnhap", "DangNhap",
                "frmDangnhap", "frmDangNhap",
                "frmLogin", "Login"
            );
        }

        private void mnuQuenmatkhau_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Center,
                "Quenmatkhau", "QuenMatKhau",
                "frmQuenmatkhau", "frmQuenMatKhau",
                "ForgotPassword", "frmForgotPassword"
            );
        }

        private void mnuKetthuc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
                Application.Exit();
        }

        // =====================================================
        // QUẢN LÝ
        // =====================================================
        private void mnuQuanlysinhvien_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Fill,
                "Quanlysinhvien", "QuanLySinhVien",
                "frmQuanlysinhvien", "frmQuanLySinhVien",
                "Sinhvien", "SinhVien", "frmSinhVien"
            );
        }

        private void mnuQuanlykhunha_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Fill,
                "Quanlykhunha", "QuanLyKhuNha",
                "frmQuanlykhunha", "frmQuanLyKhuNha"
            );
        }

        private void mnuQuanlyphong_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Fill,
                "Quanlyphong", "QuanLyPhong",
                "frmQuanlyphong", "frmQuanLyPhong"
            );
        }

        // =====================================================
        // NGHIỆP VỤ
        // =====================================================
        private void mnuDangkyoxepphong_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Fill,
                "Dangkyoxepphong", "DangKyOXepPhong",
                "frmDangkyoxepphong", "frmDangKyOXepPhong",
                "Dangkyophong", "DangKyOPhong", "frmDangKyOPhong"
            );
        }

        private void mnuChuyenphong_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Fill,
                "Chuyenphong", "ChuyenPhong",
                "frmChuyenphong", "frmChuyenPhong"
            );
        }

        private void mnuTraphong_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Fill,
                "Traphong", "TraPhong",
                "frmTraphong", "frmTraPhong"
            );
        }

        private void mnuNhapdiennuoc_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Fill,
                "Nhapdiennuoc", "NhapDienNuoc",
                "frmNhapdiennuoc", "frmNhapDienNuoc"
            );
        }

        private void mnuHoadonthanhtoan_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Fill,
                "Laphoadon",
                "Hoadonthanhtoan", "HoaDonThanhToan",
                "frmHoadonthanhtoan", "frmHoaDonThanhToan",
                "Hoadon", "HoaDon", "frmHoaDon"
            );
        }

        // =====================================================
        // BÁO CÁO
        // =====================================================
        private void mnuThongkebaocao_Click(object sender, EventArgs e)
        {
            OpenFormByName(
                ChildFormMode.Fill,
                "Quanlithongke", "QuanLiThongKe",
                "Quanlythongke", "QuanLyThongKe",
                "frmQuanlithongke", "frmQuanLiThongKe",
                "Thongkebaocao", "ThongKeBaoCao",
                "frmThongkebaocao", "frmThongKeBaoCao"
            );
        }

        // =====================================================
        // TOOLSTRIP GỌI LẠI MENU TƯƠNG ỨNG
        // =====================================================
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

        // =====================================================
        // TIMER
        // =====================================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            string ten = SessionManager.HoTen ?? "Khách";
            string vt = SessionManager.TenVaiTro ?? "";
            lblTime.Text = $"{ten} ({vt})   Time: {DateTime.Now:HH:mm:ss - dd/MM/yyyy}";
        }

        // =====================================================
        // KHI PANEL RESIZE THÌ FORM CENTER VẪN Ở GIỮA
        // =====================================================
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