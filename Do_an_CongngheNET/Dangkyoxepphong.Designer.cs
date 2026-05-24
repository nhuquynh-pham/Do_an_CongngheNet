namespace Do_an_CongngheNET
{
    partial class Dangkyoxepphong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();

            // --- Cột TRÁI: thông tin SV ---
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.lblThongtinSV = new System.Windows.Forms.Label();
            this.tlpLeft1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblHoten = new System.Windows.Forms.Label();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.lblGioitinh = new System.Windows.Forms.Label();
            this.cboGioitinh = new System.Windows.Forms.ComboBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();

            // --- Cột GIỮA: thông tin đăng ký ---
            this.tlpLeft2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblThongtindangky = new System.Windows.Forms.Label();
            this.tlpLeft3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMadangky = new System.Windows.Forms.Label();
            this.txtMadangky = new System.Windows.Forms.TextBox();
            this.lblNgaydangky = new System.Windows.Forms.Label();
            this.txtNgaydangky = new System.Windows.Forms.TextBox();
            this.lblHocky = new System.Windows.Forms.Label();
            this.cboHocky = new System.Windows.Forms.ComboBox();
            this.lblNamhoc = new System.Windows.Forms.Label();
            this.txtNamhoc = new System.Windows.Forms.TextBox();
            this.lblLoaiphong = new System.Windows.Forms.Label();
            this.cboLoaiphong = new System.Windows.Forms.ComboBox();
            this.lblTrangthai = new System.Windows.Forms.Label();
            this.cboTrangthai = new System.Windows.Forms.ComboBox();
            this.lblKhunha = new System.Windows.Forms.Label();
            this.cboKhunha = new System.Windows.Forms.ComboBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblGiuong = new System.Windows.Forms.Label();
            this.cboGiuong = new System.Windows.Forms.ComboBox();
            this.lblNgayvaoo = new System.Windows.Forms.Label();
            this.txtNgayvaoo = new System.Windows.Forms.TextBox();
            this.lblGhichu = new System.Windows.Forms.Label();
            this.txtGhichu = new System.Windows.Forms.TextBox();

            // --- Cột PHẢI: tìm kiếm + lưới ---
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimkiem = new System.Windows.Forms.Label();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.dgvDangkyoxepphong = new System.Windows.Forms.DataGridView();

            // --- Thanh nút ---
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.tlpLeft1.SuspendLayout();
            this.tlpLeft2.SuspendLayout();
            this.tlpLeft3.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.tlpSearch.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangkyoxepphong)).BeginInit();
            this.SuspendLayout();

            // ── tlpRoot ──────────────────────────────────────────────
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.RowCount = 3;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpRoot.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpRoot.Controls.Add(this.tlpContent, 0, 1);
            this.tlpRoot.Controls.Add(this.tlpButtons, 0, 2);
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.Size = new System.Drawing.Size(1280, 650);
            this.tlpRoot.TabIndex = 0;

            // ── pnlHeader ────────────────────────────────────────────
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Name = "pnlHeader";

            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Text = "ĐĂNG KÝ Ở / XẾP PHÒNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Name = "lblTitle";

            // ── tlpContent ───────────────────────────────────────────
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.ColumnCount = 1;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.RowCount = 1;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Controls.Add(this.tlpTop, 0, 0);
            this.tlpContent.Name = "tlpContent";

            // ── tlpTop (3 cột) ───────────────────────────────────────
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.ColumnCount = 3;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpTop.Controls.Add(this.tlpLeft2, 1, 0);
            this.tlpTop.Controls.Add(this.tlpRight, 2, 0);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpTop_Paint);

            // ══════════════════════════════════════════════════════════
            // CỘT TRÁI — Thông tin SV
            // ══════════════════════════════════════════════════════════
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.RowCount = 2;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.lblThongtinSV, 0, 0);
            this.tlpLeft.Controls.Add(this.tlpLeft1, 0, 1);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.Padding = new System.Windows.Forms.Padding(4);

            this.lblThongtinSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThongtinSV.Text = "THÔNG TIN SINH VIÊN";
            this.lblThongtinSV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThongtinSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblThongtinSV.Name = "lblThongtinSV";

            // tlpLeft1 (6 hàng: MaSV, HoTen, GioiTinh, Lop, Khoa, SDT)
            this.tlpLeft1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft1.ColumnCount = 2;
            this.tlpLeft1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tlpLeft1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.tlpLeft1.RowCount = 6;
            for (int i = 0; i < 6; i++)
                this.tlpLeft1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.67F));
            this.tlpLeft1.Controls.Add(this.lblMaSV, 0, 0); this.tlpLeft1.Controls.Add(this.txtMaSV, 1, 0);
            this.tlpLeft1.Controls.Add(this.lblHoten, 0, 1); this.tlpLeft1.Controls.Add(this.txtHoten, 1, 1);
            this.tlpLeft1.Controls.Add(this.lblGioitinh, 0, 2); this.tlpLeft1.Controls.Add(this.cboGioitinh, 1, 2);
            this.tlpLeft1.Controls.Add(this.lblLop, 0, 3); this.tlpLeft1.Controls.Add(this.txtLop, 1, 3);
            this.tlpLeft1.Controls.Add(this.lblKhoa, 0, 4); this.tlpLeft1.Controls.Add(this.txtKhoa, 1, 4);
            this.tlpLeft1.Controls.Add(this.lblSDT, 0, 5); this.tlpLeft1.Controls.Add(this.txtSDT, 1, 5);
            this.tlpLeft1.Name = "tlpLeft1";

            SetLabelStyle(this.lblMaSV, "Mã SV (*):"); SetInputStyle(this.txtMaSV);
            SetLabelStyle(this.lblHoten, "Họ tên:"); SetInputStyle(this.txtHoten);
            SetLabelStyle(this.lblGioitinh, "Giới tính:"); SetCboStyle(this.cboGioitinh, new[] { "Nam", "Nữ" });
            SetLabelStyle(this.lblLop, "Lớp:"); SetInputStyle(this.txtLop);
            SetLabelStyle(this.lblKhoa, "Khoa / Viện:"); SetInputStyle(this.txtKhoa);
            SetLabelStyle(this.lblSDT, "Số điện thoại:"); SetInputStyle(this.txtSDT);
            this.lblMaSV.Name = "lblMaSV"; this.txtMaSV.Name = "txtMaSV";
            this.lblHoten.Name = "lblHoten"; this.txtHoten.Name = "txtHoten";
            this.lblGioitinh.Name = "lblGioitinh"; this.cboGioitinh.Name = "cboGioitinh";
            this.lblLop.Name = "lblLop"; this.txtLop.Name = "txtLop";
            this.lblKhoa.Name = "lblKhoa"; this.txtKhoa.Name = "txtKhoa";
            this.lblSDT.Name = "lblSDT"; this.txtSDT.Name = "txtSDT";

            // ══════════════════════════════════════════════════════════
            // CỘT GIỮA — Thông tin đăng ký / phòng
            // ══════════════════════════════════════════════════════════
            this.tlpLeft2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft2.ColumnCount = 1;
            this.tlpLeft2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft2.RowCount = 2;
            this.tlpLeft2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpLeft2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft2.Controls.Add(this.lblThongtindangky, 0, 0);
            this.tlpLeft2.Controls.Add(this.tlpLeft3, 0, 1);
            this.tlpLeft2.Name = "tlpLeft2";
            this.tlpLeft2.Padding = new System.Windows.Forms.Padding(4);

            this.lblThongtindangky.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThongtindangky.Text = "THÔNG TIN ĐĂNG KÝ / PHÒNG";
            this.lblThongtindangky.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThongtindangky.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblThongtindangky.Name = "lblThongtindangky";

            // tlpLeft3 (11 hàng)
            this.tlpLeft3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft3.ColumnCount = 2;
            this.tlpLeft3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.tlpLeft3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.tlpLeft3.RowCount = 11;
            for (int i = 0; i < 11; i++)
                this.tlpLeft3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09F));
            this.tlpLeft3.Controls.Add(this.lblMadangky, 0, 0); this.tlpLeft3.Controls.Add(this.txtMadangky, 1, 0);
            this.tlpLeft3.Controls.Add(this.lblNgaydangky, 0, 1); this.tlpLeft3.Controls.Add(this.txtNgaydangky, 1, 1);
            this.tlpLeft3.Controls.Add(this.lblHocky, 0, 2); this.tlpLeft3.Controls.Add(this.cboHocky, 1, 2);
            this.tlpLeft3.Controls.Add(this.lblNamhoc, 0, 3); this.tlpLeft3.Controls.Add(this.txtNamhoc, 1, 3);
            this.tlpLeft3.Controls.Add(this.lblLoaiphong, 0, 4); this.tlpLeft3.Controls.Add(this.cboLoaiphong, 1, 4);
            this.tlpLeft3.Controls.Add(this.lblTrangthai, 0, 5); this.tlpLeft3.Controls.Add(this.cboTrangthai, 1, 5);
            this.tlpLeft3.Controls.Add(this.lblKhunha, 0, 6); this.tlpLeft3.Controls.Add(this.cboKhunha, 1, 6);
            this.tlpLeft3.Controls.Add(this.lblPhong, 0, 7); this.tlpLeft3.Controls.Add(this.cboPhong, 1, 7);
            this.tlpLeft3.Controls.Add(this.lblGiuong, 0, 8); this.tlpLeft3.Controls.Add(this.cboGiuong, 1, 8);
            this.tlpLeft3.Controls.Add(this.lblNgayvaoo, 0, 9); this.tlpLeft3.Controls.Add(this.txtNgayvaoo, 1, 9);
            this.tlpLeft3.Controls.Add(this.lblGhichu, 0, 10); this.tlpLeft3.Controls.Add(this.txtGhichu, 1, 10);
            this.tlpLeft3.Name = "tlpLeft3";

            SetLabelStyle(this.lblMadangky, "Mã đăng ký:"); SetInputStyle(this.txtMadangky);
            SetLabelStyle(this.lblNgaydangky, "Ngày đăng ký:"); SetInputStyle(this.txtNgaydangky);
            SetLabelStyle(this.lblHocky, "Học kỳ:"); SetCboStyle(this.cboHocky, new string[0]);
            SetLabelStyle(this.lblNamhoc, "Năm học:"); SetInputStyle(this.txtNamhoc);
            SetLabelStyle(this.lblLoaiphong, "Loại phòng:"); SetCboStyle(this.cboLoaiphong, new string[0]);
            SetLabelStyle(this.lblTrangthai, "Trạng thái:"); SetCboStyle(this.cboTrangthai, new string[0]);
            SetLabelStyle(this.lblKhunha, "Khu nhà:"); SetCboStyle(this.cboKhunha, new string[0]);
            SetLabelStyle(this.lblPhong, "Phòng:"); SetCboStyle(this.cboPhong, new string[0]);
            SetLabelStyle(this.lblGiuong, "Giường:"); SetCboStyle(this.cboGiuong, new string[0]);
            SetLabelStyle(this.lblNgayvaoo, "Ngày vào ở:"); SetInputStyle(this.txtNgayvaoo);
            SetLabelStyle(this.lblGhichu, "Ghi chú:"); SetInputStyle(this.txtGhichu);

            this.lblMadangky.Name = "lblMadangky"; this.txtMadangky.Name = "txtMadangky";
            this.lblNgaydangky.Name = "lblNgaydangky"; this.txtNgaydangky.Name = "txtNgaydangky";
            this.lblHocky.Name = "lblHocky"; this.cboHocky.Name = "cboHocky";
            this.lblNamhoc.Name = "lblNamhoc"; this.txtNamhoc.Name = "txtNamhoc";
            this.lblLoaiphong.Name = "lblLoaiphong"; this.cboLoaiphong.Name = "cboLoaiphong";
            this.lblTrangthai.Name = "lblTrangthai"; this.cboTrangthai.Name = "cboTrangthai";
            this.lblKhunha.Name = "lblKhunha"; this.cboKhunha.Name = "cboKhunha";
            this.lblPhong.Name = "lblPhong"; this.cboPhong.Name = "cboPhong";
            this.lblGiuong.Name = "lblGiuong"; this.cboGiuong.Name = "cboGiuong";
            this.lblNgayvaoo.Name = "lblNgayvaoo"; this.txtNgayvaoo.Name = "txtNgayvaoo";
            this.lblGhichu.Name = "lblGhichu"; this.txtGhichu.Name = "txtGhichu";

            // ══════════════════════════════════════════════════════════
            // CỘT PHẢI — Tìm kiếm + DataGridView
            // ══════════════════════════════════════════════════════════
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.RowCount = 2;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.tlpSearch, 0, 0);
            this.tlpRight.Controls.Add(this.dgvDangkyoxepphong, 0, 1);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.Padding = new System.Windows.Forms.Padding(4);

            // tlpSearch
            this.tlpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearch.ColumnCount = 2;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.RowCount = 1;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Controls.Add(this.lblTimkiem, 0, 0);
            this.tlpSearch.Controls.Add(this.txtTimkiem, 1, 0);
            this.tlpSearch.Name = "tlpSearch";

            SetLabelStyle(this.lblTimkiem, "Tìm kiếm:");
            this.lblTimkiem.Name = "lblTimkiem";
            this.txtTimkiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // DataGridView — Dock Fill trực tiếp trong tlpRight (KHÔNG dùng FlowLayoutPanel)
            this.dgvDangkyoxepphong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDangkyoxepphong.Name = "dgvDangkyoxepphong";
            this.dgvDangkyoxepphong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangkyoxepphong.RowTemplate.Height = 24;

            // ══════════════════════════════════════════════════════════
            // THANH NÚT — tlpButtons
            // Tag = "select"  → hiện khi KHÔNG ở chế độ edit (Thêm/Sửa/Xóa/Làm mới/Kết thúc)
            // Tag = "confirm" → hiện khi Ở chế độ edit (Ghi/Hủy ghi)
            // ══════════════════════════════════════════════════════════
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.ColumnCount = 7;
            for (int i = 0; i < 7; i++)
                this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Controls.Add(this.btnNew, 0, 0);
            this.tlpButtons.Controls.Add(this.btnEdit, 1, 0);
            this.tlpButtons.Controls.Add(this.btnDelete, 2, 0);
            this.tlpButtons.Controls.Add(this.btnSave, 3, 0);
            this.tlpButtons.Controls.Add(this.btnCancel, 4, 0);
            this.tlpButtons.Controls.Add(this.btnRefresh, 5, 0);
            this.tlpButtons.Controls.Add(this.btnClose, 6, 0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);

            SetBtnStyle(this.btnNew, "Thêm mới", "select");
            SetBtnStyle(this.btnEdit, "Sửa", "select");
            SetBtnStyle(this.btnDelete, "Xóa", "select");
            SetBtnStyle(this.btnSave, "Ghi", "confirm");
            SetBtnStyle(this.btnCancel, "Hủy ghi", "confirm");
            SetBtnStyle(this.btnRefresh, "Làm mới", "select");
            SetBtnStyle(this.btnClose, "Kết thúc", "select");
            this.btnNew.Name = "btnNew"; this.btnEdit.Name = "btnEdit"; this.btnDelete.Name = "btnDelete";
            this.btnSave.Name = "btnSave"; this.btnCancel.Name = "btnCancel";
            this.btnRefresh.Name = "btnRefresh"; this.btnClose.Name = "btnClose";

            // ── Kết thúc Resume ──────────────────────────────────────
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.tlpContent.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.tlpLeft1.ResumeLayout(false);
            this.tlpLeft2.ResumeLayout(false);
            this.tlpLeft3.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            this.tlpSearch.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangkyoxepphong)).EndInit();
            this.ResumeLayout(false);

            // ── Form ─────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1280, 650);
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dangkyoxepphong";
            this.Text = "Đăng ký ở / Xếp phòng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        // ── Helper cài style nhanh ────────────────────────────────────
        private static void SetLabelStyle(System.Windows.Forms.Label lbl, string text)
        {
            lbl.Text = text;
            lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            lbl.AutoSize = true;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }
        private static void SetInputStyle(System.Windows.Forms.TextBox txt)
        {
            txt.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txt.Size = new System.Drawing.Size(180, 28);
        }
        private static void SetCboStyle(System.Windows.Forms.ComboBox cbo, string[] items)
        {
            cbo.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbo.FormattingEnabled = true;
            if (items.Length > 0) cbo.Items.AddRange(items);
            cbo.Size = new System.Drawing.Size(180, 28);
        }
        private static void SetBtnStyle(System.Windows.Forms.Button btn, string text, string tag)
        {
            btn.Text = text;
            btn.Tag = tag;
            btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            btn.Size = new System.Drawing.Size(130, 36);
        }
        #endregion

        // ── Khai báo field ───────────────────────────────────────────
        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.Label lblThongtinSV;
        private System.Windows.Forms.TableLayoutPanel tlpLeft1;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblHoten;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.Label lblGioitinh;
        private System.Windows.Forms.ComboBox cboGioitinh;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TableLayoutPanel tlpLeft2;
        private System.Windows.Forms.Label lblThongtindangky;
        private System.Windows.Forms.TableLayoutPanel tlpLeft3;
        private System.Windows.Forms.Label lblMadangky;
        private System.Windows.Forms.TextBox txtMadangky;
        private System.Windows.Forms.Label lblNgaydangky;
        private System.Windows.Forms.TextBox txtNgaydangky;
        private System.Windows.Forms.Label lblHocky;
        private System.Windows.Forms.ComboBox cboHocky;
        private System.Windows.Forms.Label lblNamhoc;
        private System.Windows.Forms.TextBox txtNamhoc;
        private System.Windows.Forms.Label lblLoaiphong;
        private System.Windows.Forms.ComboBox cboLoaiphong;
        private System.Windows.Forms.Label lblTrangthai;
        private System.Windows.Forms.ComboBox cboTrangthai;
        private System.Windows.Forms.Label lblKhunha;
        private System.Windows.Forms.ComboBox cboKhunha;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblGiuong;
        private System.Windows.Forms.ComboBox cboGiuong;
        private System.Windows.Forms.Label lblNgayvaoo;
        private System.Windows.Forms.TextBox txtNgayvaoo;
        private System.Windows.Forms.Label lblGhichu;
        private System.Windows.Forms.TextBox txtGhichu;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.Label lblTimkiem;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.DataGridView dgvDangkyoxepphong;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}