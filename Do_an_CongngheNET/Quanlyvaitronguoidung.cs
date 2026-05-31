using QLKTX;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an_CongngheNET
{
    public partial class Quanlyvaitronguoidung : Form
    {
        // ================================================================
        // KHAI BÁO BIẾN DÙNG CHUNG
        // ================================================================
        private readonly DBService _db = new DBService();
        private SaveMode _saveMode = SaveMode.Insert;
        private string _maVaiTroDangChon = null;

        public Quanlyvaitronguoidung()
        {
            InitializeComponent();
            // Tất cả sự kiện đã wire trong Designer — không gắn thủ công ở đây
        }

        // ================================================================
        // SỰ KIỆN LOAD FORM
        // ================================================================
        private void Quanlyvaitronguoidung_Load(object sender, EventArgs e)
        {
            txtMota.ReadOnly = true;
            UIService.SetButtonsEnabled(this, false);

            if (!SessionManager.CoQuyen("CN011"))
            {
                this.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }));
                return;
            }

            UIService.SetGridStyle(dgvDanhsach);
            UIService.SetGridStyle(dgvPhanquyen);

            LoadComboVaitro();
        }

        // ================================================================
        // NẠP COMBO VAI TRÒ
        // ================================================================
        private void LoadComboVaitro()
        {
            string sql = "SELECT MaVaiTro, TenVaiTro FROM tblVAITRO ORDER BY MaVaiTro";
            DataTable dt = _db.ExecuteQuery(sql);

            DataRow blank = dt.NewRow();
            blank["MaVaiTro"] = "";
            blank["TenVaiTro"] = "-- Chọn vai trò --";
            dt.Rows.InsertAt(blank, 0);

            cboVaitrohethong.DataSource = dt;
            cboVaitrohethong.DisplayMember = "TenVaiTro";
            cboVaitrohethong.ValueMember = "MaVaiTro";
            cboVaitrohethong.SelectedIndex = 0;
        }

        // ================================================================
        // KHI CHỌN VAI TRÒ TRÊN COMBO
        // ================================================================
        private void cboVaitrohethong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVaitrohethong.SelectedValue == null) return;

            string maVaiTro = cboVaitrohethong.SelectedValue.ToString().Trim();

            if (string.IsNullOrEmpty(maVaiTro))
            {
                _maVaiTroDangChon = null;
                txtMota.Text = "";
                dgvDanhsach.DataSource = null;
                dgvPhanquyen.DataSource = null;
                UIService.SetButtonsEnabled(this, false);
                return;
            }

            _maVaiTroDangChon = maVaiTro;

            DataTable dtCombo = (DataTable)cboVaitrohethong.DataSource;
            DataRow[] rows = dtCombo.Select("MaVaiTro = '" + maVaiTro + "'");

            if (rows.Length > 0 && dtCombo.Columns.Contains("MoTa"))
                txtMota.Text = rows[0]["MoTa"]?.ToString() ?? "";
            else
            {
                DataTable dtVt = _db.ExecuteQuery(
                    "SELECT MoTa FROM tblVAITRO WHERE MaVaiTro = @mv",
                    new SqlParameter("@mv", maVaiTro));
                txtMota.Text = dtVt.Rows.Count > 0
                    ? dtVt.Rows[0]["MoTa"]?.ToString() ?? "" : "";
            }

            LoadDanhSachTaiKhoan(maVaiTro);
            dgvPhanquyen.DataSource = null;
            UIService.SetButtonsEnabled(this, false);
        }

        // ================================================================
        // NẠP DANH SÁCH TÀI KHOẢN THUỘC VAI TRÒ (LƯỚI TRÁI)
        // ================================================================
        private void LoadDanhSachTaiKhoan(string maVaiTro)
        {
            string sql = @"
                SELECT tk.MaTK, tk.TenDangNhap, tk.HoTen, tk.ChucVu, tk.TrangThai
                FROM tblTAIKHOAN tk
                WHERE tk.MaVaiTro = @mv
                ORDER BY tk.MaTK";

            DataTable dt = _db.ExecuteQuery(sql, new SqlParameter("@mv", maVaiTro));

            dgvDanhsach.DataSource = dt;
            UIService.SetGridHeader(dgvDanhsach,
                "Mã TK", "Tên đăng nhập", "Họ tên", "Chức vụ", "Trạng thái");
        }

        // ================================================================
        // KHI CHỌN DÒNG TRÊN LƯỚI DANH SÁCH TÀI KHOẢN (TRÁI)
        // ================================================================
        private void dgvDanhsach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhsach.CurrentRow == null) return;

            string maTK = dgvDanhsach.CurrentRow.Cells["MaTK"].Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(maTK)) return;

            LoadPhanQuyenCuaTaiKhoan(maTK);
        }

        // ================================================================
        // NẠP PHÂN QUYỀN CỦA MỘT TÀI KHOẢN CỤ THỂ (LƯỚI PHẢI)
        // ================================================================
        private void LoadPhanQuyenCuaTaiKhoan(string maTK)
        {
            string sql = @"
                SELECT
                    cn.MaCN,
                    cn.TenChucNang,
                    cn.NhomChucNang,
                    CASE WHEN ISNULL(pq.DuocTruyCap, 0) = 1
                         THEN N'✔ Có quyền'
                         ELSE N'✘ Không có'
                    END AS [Trạng thái quyền]
                FROM tblCHUCNANG cn
                LEFT JOIN tblPHANQUYEN pq
                    ON cn.MaCN = pq.MaCN AND pq.MaTK = @maTK
                ORDER BY cn.MaCN";

            DataTable dt = _db.ExecuteQuery(sql, new SqlParameter("@maTK", maTK));

            dgvPhanquyen.DataSource = dt;
            UIService.SetGridHeader(dgvPhanquyen,
                "Mã CN", "Tên chức năng", "Nhóm chức năng", "Trạng thái quyền");
        }

        // ================================================================
        // NÚT THÊM MỚI
        // ================================================================
        private void btnNew_Click(object sender, EventArgs e)
        {
            _saveMode = SaveMode.Insert;
            _maVaiTroDangChon = null;

            cboVaitrohethong.SelectedIndex = 0;
            txtMota.Text = "";
            dgvDanhsach.DataSource = null;
            dgvPhanquyen.DataSource = null;

            cboVaitrohethong.Enabled = true;
            cboVaitrohethong.DropDownStyle = ComboBoxStyle.DropDown;
            txtMota.ReadOnly = false;

            UIService.SetButtonsEnabled(this, true);
            cboVaitrohethong.Focus();
        }

        // ================================================================
        // NÚT SỬA
        // ================================================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maVaiTroDangChon))
            {
                MessageBox.Show("Vui lòng chọn một vai trò để sửa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _saveMode = SaveMode.Update;

            cboVaitrohethong.Enabled = false;
            cboVaitrohethong.DropDownStyle = ComboBoxStyle.DropDownList;
            txtMota.ReadOnly = false;

            UIService.SetButtonsEnabled(this, true);
            txtMota.Focus();
        }

        // ================================================================
        // NÚT GHI
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_saveMode == SaveMode.Insert)
            {
                string tenVaiTro = cboVaitrohethong.Text.Trim();

                if (string.IsNullOrWhiteSpace(tenVaiTro) || tenVaiTro == "-- Chọn vai trò --")
                {
                    MessageBox.Show("Vui lòng nhập tên vai trò mới!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboVaitrohethong.Focus();
                    return;
                }

                int count = Convert.ToInt32(_db.ExecuteScalar(
                    "SELECT COUNT(*) FROM tblVAITRO WHERE TenVaiTro = @ten",
                    new SqlParameter("@ten", tenVaiTro)));

                if (count > 0)
                {
                    MessageBox.Show("Tên vai trò \"" + tenVaiTro + "\" đã tồn tại!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboVaitrohethong.Focus();
                    return;
                }

                string maVaiTro = GenerateNewID();
                string moTa = txtMota.Text.Trim();

                _db.ExecuteNonQuery(
                    "INSERT INTO tblVAITRO (MaVaiTro, TenVaiTro, MoTa) VALUES (@ma, @ten, @mota)",
                    new SqlParameter("@ma", maVaiTro),
                    new SqlParameter("@ten", tenVaiTro),
                    new SqlParameter("@mota", string.IsNullOrWhiteSpace(moTa)
                                              ? (object)DBNull.Value : moTa));

                _maVaiTroDangChon = maVaiTro;
                MessageBox.Show("Thêm vai trò thành công! Mã: " + maVaiTro,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string moTa = txtMota.Text.Trim();
                _db.ExecuteNonQuery(
                    "UPDATE tblVAITRO SET MoTa = @mota WHERE MaVaiTro = @ma",
                    new SqlParameter("@mota", string.IsNullOrWhiteSpace(moTa)
                                              ? (object)DBNull.Value : moTa),
                    new SqlParameter("@ma", _maVaiTroDangChon));

                MessageBox.Show("Cập nhật vai trò thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ResetToViewMode();
            LoadComboVaitro();

            if (!string.IsNullOrEmpty(_maVaiTroDangChon))
                cboVaitrohethong.SelectedValue = _maVaiTroDangChon;
        }

        // ================================================================
        // NÚT HỦY GHI
        // ================================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetToViewMode();

            if (!string.IsNullOrEmpty(_maVaiTroDangChon))
                cboVaitrohethong.SelectedValue = _maVaiTroDangChon;
            else
            {
                txtMota.Text = "";
                dgvDanhsach.DataSource = null;
                dgvPhanquyen.DataSource = null;
            }
        }

        // ================================================================
        // HELPER: Đặt lại giao diện về chế độ CHỈ XEM
        // ================================================================
        private void ResetToViewMode()
        {
            cboVaitrohethong.Enabled = true;
            cboVaitrohethong.DropDownStyle = ComboBoxStyle.DropDownList;
            txtMota.ReadOnly = true;
            UIService.SetButtonsEnabled(this, false);
        }

        // ================================================================
        // NÚT KẾT THÚC
        // ================================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ================================================================
        // SINH MÃ VAI TRÒ TỰ ĐỘNG (VT001, VT002, ...)
        // ================================================================
        private string GenerateNewID()
        {
            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaVaiTro, 3, LEN(MaVaiTro)) AS INT)), 0) + 1
                           FROM tblVAITRO
                           WHERE MaVaiTro LIKE 'VT%'";
            int nextNum = Convert.ToInt32(_db.ExecuteScalar(sql));
            return "VT" + nextNum.ToString("D3");
        }

        // ================================================================
        // GIỮ LẠI SỰ KIỆN DESIGNER
        // ================================================================
        private void tlpButton_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }

        private void dgvPhanquyen_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}