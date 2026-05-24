using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Quanlyphanquyen : Form
    {
        // ================================================================
        // KHAI BÁO BIẾN DÙNG CHUNG
        // ================================================================
        private readonly DBService _db = new DBService();
        private string _maTKDangChon = null;

        // ================================================================
        // KHỞI TẠO FORM
        // ================================================================
        public Quanlyphanquyen()
        {
            InitializeComponent();

            // Wire thủ công các event mà Designer KHÔNG tự đăng ký
            this.Load += Quanlyphanquyen_Load;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.btnClose.Click += btnClose_Click;
            this.dgvQuanlyphanquyen.SelectionChanged += dgvQuanlyphanquyen_SelectionChanged;
            this.trvQuyenchucnang.AfterCheck += trvQuyenchucnang_AfterCheck;
        }

        // ================================================================
        // [Handler bắt buộc] - Designer dòng 440 đăng ký cho lblQuanlyphanquyen
        // ================================================================
        private void label1_Click(object sender, EventArgs e)
        {
            // Không cần xử lý - khai báo để tránh lỗi build
        }

        // ================================================================
        // [Handler bắt buộc] - Designer dòng 281 đăng ký cho lblThongtinphanquyen
        // ================================================================
        private void lblThongtinphanquyen_Click(object sender, EventArgs e)
        {
            // Không cần xử lý - khai báo để tránh lỗi build
        }

        // ================================================================
        // SỰ KIỆN LOAD FORM
        // ================================================================
        private void Quanlyphanquyen_Load(object sender, EventArgs e)
        {
            UIService.SetGridStyle(dgvQuanlyphanquyen);

            LoadCboVaitro();
            LoadCboTrangthai();
            LoadDanhSachTaiKhoan();

            // Vô hiệu hóa panel nhập liệu và TreeView khi chưa chọn tài khoản
            UIService.SetInputsEnabled(tlpRight2, false);
            trvQuyenchucnang.Enabled = false;
        }

        // ================================================================
        // NẠP COMBO BOX VAI TRÒ TỪ CSDL
        // ================================================================
        private void LoadCboVaitro()
        {
            DataTable dt = _db.ExecuteQuery(
                "SELECT MaVaiTro, TenVaiTro FROM tblVAITRO ORDER BY TenVaiTro");

            cboVaitro.DataSource = dt;
            cboVaitro.DisplayMember = "TenVaiTro";
            cboVaitro.ValueMember = "MaVaiTro";
            cboVaitro.SelectedIndex = -1;
        }

        // ================================================================
        // NẠP COMBO BOX TRẠNG THÁI
        // ================================================================
        private void LoadCboTrangthai()
        {
            cboTrangthai.Items.Clear();
            cboTrangthai.Items.Add("Đang hoạt động");
            cboTrangthai.Items.Add("Khóa");
            cboTrangthai.SelectedIndex = -1;
        }

        // ================================================================
        // NẠP DANH SÁCH TÀI KHOẢN LÊN LƯỚI (CÓ LỌC TÌM KIẾM)
        // ================================================================
        private void LoadDanhSachTaiKhoan(string keyword = "")
        {
            string sql = @"
                SELECT tk.MaTK, tk.TenDangNhap, tk.HoTen, vt.TenVaiTro, tk.TrangThai
                FROM tblTAIKHOAN tk
                INNER JOIN tblVAITRO vt ON tk.MaVaiTro = vt.MaVaiTro
                WHERE tk.TenDangNhap LIKE @keyword
                   OR tk.HoTen      LIKE @keyword
                ORDER BY tk.MaTK";

            DataTable dt = _db.ExecuteQuery(sql,
                new SqlParameter("@keyword", "%" + keyword + "%"));

            dgvQuanlyphanquyen.DataSource = dt;

            UIService.SetGridHeader(dgvQuanlyphanquyen,
                "Mã TK", "Tên đăng nhập", "Họ tên", "Vai trò", "Trạng thái");
        }

        // ================================================================
        // NẠP THÔNG TIN TÀI KHOẢN LÊN FORM KHI CHỌN DÒNG
        // ================================================================
        private void LoadThongTinTaiKhoan(string maTK)
        {
            DataTable dt = _db.ExecuteQuery(
                "SELECT MaTK, TenDangNhap, HoTen, MaVaiTro, TrangThai FROM tblTAIKHOAN WHERE MaTK = @maTK",
                new SqlParameter("@maTK", maTK));

            if (dt.Rows.Count == 0) return;

            DataRow row = dt.Rows[0];
            txtMataikhoan.Text = row["MaTK"].ToString();
            txtTendangnhap.Text = row["TenDangNhap"].ToString();
            txtHoten.Text = row["HoTen"].ToString();
            cboVaitro.SelectedValue = row["MaVaiTro"].ToString();
            cboTrangthai.SelectedItem = row["TrangThai"].ToString();
        }

        // ================================================================
        // NẠP QUYỀN CHỨC NĂNG LÊN TREEVIEW
        // ================================================================
        private void LoadQuyenChuNang(string maTK)
        {
            string sql = @"
                SELECT cn.TenChucNang, pq.DuocTruyCap
                FROM tblCHUCNANG cn
                LEFT JOIN tblPHANQUYEN pq
                    ON cn.MaCN = pq.MaCN AND pq.MaTK = @maTK";

            DataTable dt = _db.ExecuteQuery(sql,
                new SqlParameter("@maTK", maTK));

            // Build dictionary TenChucNang → DuocTruyCap
            var quyenDict = new Dictionary<string, bool>();
            foreach (DataRow row in dt.Rows)
            {
                string tenCN = row["TenChucNang"].ToString();
                bool duocTruyCap = row["DuocTruyCap"] != DBNull.Value
                                   && Convert.ToBoolean(row["DuocTruyCap"]);
                quyenDict[tenCN] = duocTruyCap;
            }

            // Gỡ AfterCheck tạm để tránh trigger khi set checked
            trvQuyenchucnang.AfterCheck -= trvQuyenchucnang_AfterCheck;

            DanhDauNodeQuyen(trvQuyenchucnang.Nodes, quyenDict);
            trvQuyenchucnang.ExpandAll();

            trvQuyenchucnang.AfterCheck += trvQuyenchucnang_AfterCheck;
        }

        // Đệ quy đánh dấu checked cho từng node
        private void DanhDauNodeQuyen(TreeNodeCollection nodes,
            Dictionary<string, bool> quyenDict)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0) // node lá = chức năng thực sự
                {
                    node.Checked = quyenDict.ContainsKey(node.Text)
                                   && quyenDict[node.Text];
                }
                else
                {
                    DanhDauNodeQuyen(node.Nodes, quyenDict);

                    // Node cha checked nếu tất cả con đều checked
                    bool allChecked = true;
                    foreach (TreeNode child in node.Nodes)
                        if (!child.Checked) { allChecked = false; break; }
                    node.Checked = allChecked;
                }
            }
        }

        // ================================================================
        // SỰ KIỆN CHỌN DÒNG TRÊN LƯỚI
        // ================================================================
        private void dgvQuanlyphanquyen_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQuanlyphanquyen.CurrentRow == null) return;

            _maTKDangChon = dgvQuanlyphanquyen
                .CurrentRow.Cells["MaTK"].Value?.ToString();

            if (string.IsNullOrEmpty(_maTKDangChon)) return;

            LoadThongTinTaiKhoan(_maTKDangChon);
            LoadQuyenChuNang(_maTKDangChon);
            trvQuyenchucnang.Enabled = true;
        }

        // ================================================================
        // [Handler bắt buộc] - Designer dòng 509 đăng ký cho trvQuyenchucnang
        // ================================================================
        private void trvQuyenchucnang_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Không cần xử lý – AfterCheck đảm nhận logic chính
        }

        // ================================================================
        // SỰ KIỆN AfterCheck TREEVIEW
        // Check node cha → check toàn bộ node con
        // ================================================================
        private void trvQuyenchucnang_AfterCheck(object sender, TreeViewEventArgs e)
        {
            trvQuyenchucnang.AfterCheck -= trvQuyenchucnang_AfterCheck;
            SetCheckedAllChildren(e.Node, e.Node.Checked);
            trvQuyenchucnang.AfterCheck += trvQuyenchucnang_AfterCheck;
        }

        private void SetCheckedAllChildren(TreeNode node, bool isChecked)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = isChecked;
                SetCheckedAllChildren(child, isChecked);
            }
        }

        // ================================================================
        // [Handler bắt buộc] - Designer dòng 233 đăng ký cho txtSearch
        // ================================================================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachTaiKhoan(txtSearch.Text.Trim());
        }

        // ================================================================
        // NÚT GHI – LƯU PHÂN QUYỀN VÀO CSDL
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maTKDangChon))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để phân quyền.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Xác nhận lưu phân quyền cho tài khoản này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            // Thu thập tất cả node lá (chức năng thực sự)
            var danhSachQuyen = new List<(string TenCN, bool DuocTruyCap)>();
            ThuThapQuyenTuNode(trvQuyenchucnang.Nodes, danhSachQuyen);

            foreach (var item in danhSachQuyen)
            {
                object maCNObj = _db.ExecuteScalar(
                    "SELECT MaCN FROM tblCHUCNANG WHERE TenChucNang = @tenCN",
                    new SqlParameter("@tenCN", item.TenCN));

                if (maCNObj == null || maCNObj == DBNull.Value) continue;
                string maCN = maCNObj.ToString();

                int count = Convert.ToInt32(_db.ExecuteScalar(
                    "SELECT COUNT(*) FROM tblPHANQUYEN WHERE MaTK=@maTK AND MaCN=@maCN",
                    new SqlParameter("@maTK", _maTKDangChon),
                    new SqlParameter("@maCN", maCN)));

                if (count > 0)
                {
                    _db.ExecuteNonQuery(
                        "UPDATE tblPHANQUYEN SET DuocTruyCap=@d WHERE MaTK=@maTK AND MaCN=@maCN",
                        new SqlParameter("@d", item.DuocTruyCap),
                        new SqlParameter("@maTK", _maTKDangChon),
                        new SqlParameter("@maCN", maCN));
                }
                else
                {
                    _db.ExecuteNonQuery(
                        "INSERT INTO tblPHANQUYEN(MaTK,MaCN,DuocTruyCap) VALUES(@maTK,@maCN,@d)",
                        new SqlParameter("@maTK", _maTKDangChon),
                        new SqlParameter("@maCN", maCN),
                        new SqlParameter("@d", item.DuocTruyCap));
                }
            }

            MessageBox.Show("Lưu phân quyền thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Đệ quy chỉ thu thập node lá
        private void ThuThapQuyenTuNode(TreeNodeCollection nodes,
            List<(string TenCN, bool DuocTruyCap)> result)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                    result.Add((node.Text, node.Checked));
                else
                    ThuThapQuyenTuNode(node.Nodes, result);
            }
        }

        // ================================================================
        // NÚT HỦY GHI – Tải lại quyền gốc từ CSDL
        // ================================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maTKDangChon)) return;

            LoadQuyenChuNang(_maTKDangChon);

            MessageBox.Show("Đã hủy thay đổi và khôi phục phân quyền ban đầu.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // NÚT KẾT THÚC – Đóng form
        // ================================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}