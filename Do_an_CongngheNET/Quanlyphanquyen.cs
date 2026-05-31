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
        private readonly DBService _db = new DBService();//khai báo biến _db kiểu DBService để sử dụng các phương thức truy vấn CSDL
        private string _maTKDangChon = null;//biến lưu mã tài khoản đang chọn trên lưới ban đầu là null, sẽ được gán khi người dùng chọn một tài khoản trên lưới

        // Snapshot quyền lúc vừa chọn / vừa lưu – dùng để khôi phục khi Hủy ghi
        private Dictionary<string, bool> _snapshotQuyen = new Dictionary<string, bool>();

        // ================================================================
        // KHỞI TẠO FORM
        // ================================================================
        public Quanlyphanquyen()
        {
            InitializeComponent();
        }

        // ================================================================
        // SỰ KIỆN LOAD FORM
        // ================================================================
        private void Quanlyphanquyen_Load(object sender, EventArgs e)
        {
            // Chỉ tài khoản có quyền CN011 mới được vào form này
            if (!SessionManager.CoQuyen("CN011"))
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            UIService.SetGridStyle(dgvQuanlyphanquyen);

            LoadCboVaitro();
            LoadCboTrangthai();
            LoadDanhSachTaiKhoan();

            // Chưa chọn tài khoản nào → khóa panel thông tin, TreeView, nút confirm
            UIService.SetInputsEnabled(tlpInputs, false);
            trvQuyenchucnang.Enabled = false;
            UIService.SetButtonsEnabled(this, false);

            txtSearch.Enabled = true; // ô tìm kiếm luôn khả dụng
        }

        // ================================================================
        // NẠP COMBO BOX VAI TRÒ
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
        {// Vì trạng thái chỉ có 2 giá trị cố định nên không cần truy vấn CSDL, có thể thêm trực tiếp
            cboTrangthai.Items.Clear();
            cboTrangthai.Items.Add("Đang hoạt động");
            cboTrangthai.Items.Add("Khóa");
            cboTrangthai.SelectedIndex = -1;//khởi tạo không chọn mục nào ban đầu
        }

        // ================================================================
        // NẠP DANH SÁCH TÀI KHOẢN LÊN LƯỚI
        // ================================================================
        private void LoadDanhSachTaiKhoan(string keyword = "")
        {
            string sql = @"
                SELECT tk.MaTK, tk.TenDangNhap, tk.HoTen, vt.TenVaiTro, tk.TrangThai
                FROM   tblTAIKHOAN tk
                INNER JOIN tblVAITRO vt ON tk.MaVaiTro = vt.MaVaiTro
                WHERE  tk.MaTK        LIKE @keyword
                    OR tk.TenDangNhap LIKE @keyword
                    OR tk.HoTen       LIKE @keyword
                ORDER BY tk.MaTK";

            DataTable dt = _db.ExecuteQuery(sql,
                new SqlParameter("@keyword", "%" + keyword + "%"));//thêm tham số tìm kiếm để tìm kiếm gần đúng trên mã tài khoản, tên đăng nhập và họ tên

            dgvQuanlyphanquyen.DataSource = dt;//đặt nguồn dữ liệu cho DataGridView là DataTable vừa truy vấn được

            UIService.SetGridHeader(dgvQuanlyphanquyen,
                "Mã TK", "Tên đăng nhập", "Họ tên", "Vai trò", "Trạng thái");
        }

        // ================================================================
        // GÁN DỮ LIỆU TÀI KHOẢN ĐANG CHỌN LÊN FORM
        // ================================================================
        private void BindData()
        {
            if (dgvQuanlyphanquyen.CurrentRow == null)
            {
                UIService.ClearInputs(this);
                return;
            }

            _maTKDangChon = dgvQuanlyphanquyen
                .CurrentRow.Cells["MaTK"].Value?.ToString() ?? "";

            if (string.IsNullOrEmpty(_maTKDangChon)) return;//nếu không lấy được mã tài khoản từ dòng đang chọn thì thoát khỏi phương thức

            LoadThongTinTaiKhoan(_maTKDangChon);
            LoadQuyenChuNang(_maTKDangChon, saveSnapshot: true);

            trvQuyenchucnang.Enabled = true;

            UIService.SetButtonsEnabled(this, true);
        }

        // ================================================================
        // NẠP THÔNG TIN CHI TIẾT TÀI KHOẢN
        // ================================================================
        private void LoadThongTinTaiKhoan(string maTK)
        {
            DataTable dt = _db.ExecuteQuery(
                @"SELECT MaTK, TenDangNhap, HoTen, MaVaiTro, TrangThai
                  FROM   tblTAIKHOAN
                  WHERE  MaTK = @maTK",
                new SqlParameter("@maTK", maTK));

            if (dt.Rows.Count == 0) return;

            DataRow row = dt.Rows[0];

            txtMataikhoan.Text = row["MaTK"].ToString() ?? "";
            txtTendangnhap.Text = row["TenDangNhap"].ToString() ?? "";
            txtHoten.Text = row["HoTen"].ToString() ?? "";
            cboVaitro.SelectedValue = row["MaVaiTro"].ToString() ?? "";
            cboTrangthai.SelectedItem = row["TrangThai"].ToString() ?? "";
        }

        // ================================================================
        // NẠP QUYỀN CHỨC NĂNG LÊN TREEVIEW
        // ================================================================
        private void LoadQuyenChuNang(string maTK, bool saveSnapshot = false)
        {
            DataTable dt = _db.ExecuteQuery(
                "SELECT MaCN, DuocTruyCap FROM tblPHANQUYEN WHERE MaTK = @maTK",
                new SqlParameter("@maTK", maTK));

            var quyenDict = new Dictionary<string, bool>();//tạo một từ điển để lưu trữ quyền truy cập của tài khoản, với khóa là mã chức năng và giá trị là true/false cho biết có được truy cập hay không
            foreach (DataRow row in dt.Rows)
            {
                string maCN = row["MaCN"].ToString().Trim();
                bool duocTruyCap = row["DuocTruyCap"] != DBNull.Value
                                     && Convert.ToBoolean(row["DuocTruyCap"]);//chuyển giá trị truy cập từ cơ sở dữ liệu sang kiểu bool, nếu giá trị trong CSDL là null thì mặc định là false
                quyenDict[maCN] = duocTruyCap;
            }

            trvQuyenchucnang.AfterCheck -= trvQuyenchucnang_AfterCheck;
            DanhDauNodeQuyen(trvQuyenchucnang.Nodes, quyenDict);
            trvQuyenchucnang.ExpandAll();
            trvQuyenchucnang.AfterCheck += trvQuyenchucnang_AfterCheck;//tạm thời bỏ sự kiện AfterCheck để tránh việc đánh dấu các node (tránh event bị kích hoạt liên tục gây bug), rồi gắn lại sau khi xong.

            if (saveSnapshot)
                _snapshotQuyen = LaySnapshotTuNode(trvQuyenchucnang.Nodes);//lưu snapshot quyền hiện tại vào biến _snapshotQuyen để có thể khôi phục lại khi người dùng nhấn nút Hủy ghi. Snapshot này sẽ là một từ điển với khóa là mã chức năng và giá trị là true/false cho biết có được truy cập hay không.
        }

        private void DanhDauNodeQuyen(TreeNodeCollection nodes,
            Dictionary<string, bool> quyenDict)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    string maCN = node.Tag?.ToString() ?? "";
                    node.Checked = !string.IsNullOrEmpty(maCN)
                                   && quyenDict.ContainsKey(maCN)
                                   && quyenDict[maCN];
                }//nếu node hiện tại là node lá (không có node con) thì lấy mã chức năng từ thuộc tính Tag của node, sau đó kiểm tra trong từ điển quyenDict xem tài khoản
                 //có quyền truy cập chức năng đó hay không để đánh dấu checked cho node
                else
                {
                    DanhDauNodeQuyen(node.Nodes, quyenDict);//đánh dấu các node con trước, sau đó mới đánh dấu node cha dựa trên trạng thái của các node con

                    bool allChecked = true;//giả sử tất cả các node con đều được checked, nếu có bất kỳ node con nào không được checked thì sẽ đặt allChecked thành false
                    foreach (TreeNode child in node.Nodes)
                        if (!child.Checked) { allChecked = false; break; }
                    node.Checked = allChecked;//nếu tất cả các node con đều được checked thì node cha cũng sẽ được checked, ngược lại nếu có bất kỳ node con nào không được checked thì node cha sẽ không được checked
                }
            }
        }// phương thức này sẽ duyệt qua tất cả các node trong TreeView và lấy thông tin về quyền truy cập của từng chức năng (dựa trên mã chức năng được lưu trong thuộc tính Tag của node)
         // để tạo thành một từ điển với khóa là mã chức năng và giá trị là true/false cho biết có được truy cập hay không. Phương thức này sẽ được gọi khi người dùng nhấn nút Lưu để thu
         // thập thông tin quyền hiện tại trên TreeView trước khi lưu vào cơ sở dữ liệu, cũng như khi người dùng nhấn nút Hủy ghi để lấy snapshot quyền đã lưu trước đó để khôi phục lại
         // trạng thái phân quyền ban đầu.

        private Dictionary<string, bool> LaySnapshotTuNode(TreeNodeCollection nodes)
        {
            var result = new Dictionary<string, bool>();
            LaySnapshotDeQuy(nodes, result);
            return result;
        }//phương thức này sẽ tạo một từ điển mới để lưu trữ snapshot quyền, sau đó gọi phương thức đệ quy LaySnapshotDeQuy để duyệt qua tất cả các node trong
         //TreeView và lấy thông tin về quyền truy cập của từng chức năng để lưu vào từ điển. Cuối cùng trả về từ điển chứa snapshot quyền.

        private void LaySnapshotDeQuy(TreeNodeCollection nodes,
            Dictionary<string, bool> result)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    string maCN = node.Tag?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(maCN))
                        result[maCN] = node.Checked;
                }
                else
                    LaySnapshotDeQuy(node.Nodes, result);
            }
        }//phương thức này sẽ duyệt qua tất cả các node trong TreeView một cách đệ quy, nếu node hiện tại là node lá (không có node con) thì lấy mã chức năng từ thuộc
         //tính Tag của node và trạng thái checked của node để lưu vào từ điển result. Nếu node hiện tại có node con thì tiếp tục gọi phương thức này để duyệt qua các node con.

        // ================================================================
        // SỰ KIỆN CHỌN DÒNG TRÊN LƯỚI
        // ================================================================
        private void dgvQuanlyphanquyen_SelectionChanged(object sender, EventArgs e)
        {
            BindData();
        }

        // ================================================================
        // SỰ KIỆN AfterCheck TREEVIEW
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
        // TÌM KIẾM KHI NHẤN ENTER
        // ================================================================
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDanhSachTaiKhoan(txtSearch.Text.Trim());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // ================================================================
        // NÚT GHI – LƯU PHÂN QUYỀN
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

            var danhSachQuyen = new List<(string MaCN, bool DuocTruyCap)>();
            ThuThapQuyenTuNode(trvQuyenchucnang.Nodes, danhSachQuyen);

            SaveQuyen(danhSachQuyen);

            MessageBox.Show("Lưu phân quyền thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadQuyenChuNang(_maTKDangChon, saveSnapshot: true);

            UIService.SetInputsEnabled(tlpInputs, false);
            trvQuyenchucnang.Enabled = false;
            UIService.SetButtonsEnabled(this, false);
            txtSearch.Enabled = true;
        }

        private void SaveQuyen(List<(string MaCN, bool DuocTruyCap)> danhSach)
        {
            foreach (var item in danhSach)
            {
                if (string.IsNullOrEmpty(item.MaCN)) continue;

                int count = Convert.ToInt32(_db.ExecuteScalar(
                    "SELECT COUNT(*) FROM tblPHANQUYEN WHERE MaTK=@maTK AND MaCN=@maCN",
                    new SqlParameter("@maTK", _maTKDangChon),
                    new SqlParameter("@maCN", item.MaCN)));

                if (count > 0)
                    _db.ExecuteNonQuery(
                        "UPDATE tblPHANQUYEN SET DuocTruyCap=@d WHERE MaTK=@maTK AND MaCN=@maCN",
                        new SqlParameter("@d", item.DuocTruyCap),
                        new SqlParameter("@maTK", _maTKDangChon),
                        new SqlParameter("@maCN", item.MaCN));
                else
                    _db.ExecuteNonQuery(
                        "INSERT INTO tblPHANQUYEN(MaTK,MaCN,DuocTruyCap) VALUES(@maTK,@maCN,@d)",
                        new SqlParameter("@maTK", _maTKDangChon),
                        new SqlParameter("@maCN", item.MaCN),
                        new SqlParameter("@d", item.DuocTruyCap));
            }
        }

        private void ThuThapQuyenTuNode(TreeNodeCollection nodes,
            List<(string MaCN, bool DuocTruyCap)> result)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                    result.Add((node.Tag?.ToString() ?? "", node.Checked));
                else
                    ThuThapQuyenTuNode(node.Nodes, result);
            }
        }

        // ================================================================
        // NÚT HỦY GHI – khôi phục snapshot
        // ================================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            UIService.SetInputsEnabled(tlpInputs, false);
            trvQuyenchucnang.Enabled = false;
            UIService.SetButtonsEnabled(this, false);
            txtSearch.Enabled = true;

            trvQuyenchucnang.AfterCheck -= trvQuyenchucnang_AfterCheck;
            DanhDauNodeQuyen(trvQuyenchucnang.Nodes, _snapshotQuyen);
            trvQuyenchucnang.AfterCheck += trvQuyenchucnang_AfterCheck;

            MessageBox.Show("Đã hủy thay đổi và khôi phục phân quyền ban đầu.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // NÚT KẾT THÚC
        // ================================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ================================================================
        // STUB HANDLERS
        // ================================================================
        private void lblThongtinphanquyen_Click(object sender, EventArgs e) { }
        private void trvQuyenchucnang_AfterSelect(object sender, TreeViewEventArgs e) { }
    }
}