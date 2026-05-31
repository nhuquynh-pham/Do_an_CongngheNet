namespace Do_an_CongngheNET
{
    partial class Quanlyphanquyen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Xem thông tin sinh viên");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Thêm hồ sơ sinh viên");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Sửa hồ sơ sinh viên");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Quản lý sinh viên", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Quản lý phòng");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Quản lý khu nhà");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Quản lý phòng", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Quản lý phòng và khu nhà", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Lập hóa đơn");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Thanh toán hóa đơn");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Quản lý thu/chi và hóa đơn", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Quản lý cơ sở vật chất");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Quản lý cơ sở vật chất", new System.Windows.Forms.TreeNode[] {
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Quản lý vi phạm");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Quản lý vi phạm và kỉ luật", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Xem báo cáo và thống kê");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Báo cáo và thống kê", new System.Windows.Forms.TreeNode[] {
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Phân quyền hệ thống");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Cài đặt hệ thống", new System.Windows.Forms.TreeNode[] {
            treeNode18});
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblQuanlyphanquyen = new System.Windows.Forms.Label();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.lblDanhsachtaikhoan = new System.Windows.Forms.Label();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSearch1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimkiem = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlGird = new System.Windows.Forms.Panel();
            this.dgvQuanlyphanquyen = new System.Windows.Forms.DataGridView();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.lblThongtinphanquyen = new System.Windows.Forms.Label();
            this.tlpRight4 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInputs = new System.Windows.Forms.TableLayoutPanel();
            this.lblMataikhoan = new System.Windows.Forms.Label();
            this.txtMataikhoan = new System.Windows.Forms.TextBox();
            this.lblTendangnhap = new System.Windows.Forms.Label();
            this.txtTendangnhap = new System.Windows.Forms.TextBox();
            this.lblHoten = new System.Windows.Forms.Label();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.lblVaitro = new System.Windows.Forms.Label();
            this.cboVaitro = new System.Windows.Forms.ComboBox();
            this.lblTrangthai = new System.Windows.Forms.Label();
            this.cboTrangthai = new System.Windows.Forms.ComboBox();
            this.grbQuanlyquyen = new System.Windows.Forms.GroupBox();
            this.trvQuyenchucnang = new System.Windows.Forms.TreeView();
            this.tlpButton1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.tlpSearch.SuspendLayout();
            this.tlpSearch1.SuspendLayout();
            this.pnlGird.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanlyphanquyen)).BeginInit();
            this.tlpRight.SuspendLayout();
            this.tlpRight4.SuspendLayout();
            this.tlpInputs.SuspendLayout();
            this.grbQuanlyquyen.SuspendLayout();
            this.tlpButton1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpRoot.Controls.Add(this.tlpContent, 0, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 2;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(1118, 540);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblQuanlyphanquyen);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(6, 6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1106, 54);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblQuanlyphanquyen
            // 
            this.lblQuanlyphanquyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuanlyphanquyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblQuanlyphanquyen.Location = new System.Drawing.Point(0, 0);
            this.lblQuanlyphanquyen.Name = "lblQuanlyphanquyen";
            this.lblQuanlyphanquyen.Size = new System.Drawing.Size(1106, 54);
            this.lblQuanlyphanquyen.TabIndex = 0;
            this.lblQuanlyphanquyen.Text = "QUẢN LÝ PHÂN QUYỀN HỆ THỐNG";
            this.lblQuanlyphanquyen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpContent
            // 
            this.tlpContent.ColumnCount = 2;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContent.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpContent.Controls.Add(this.tlpRight, 1, 0);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(6, 69);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 1;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Size = new System.Drawing.Size(1106, 465);
            this.tlpContent.TabIndex = 1;
            // 
            // tlpLeft
            // 
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.lblDanhsachtaikhoan, 0, 0);
            this.tlpLeft.Controls.Add(this.tlpSearch, 0, 1);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(3, 3);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 2;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Size = new System.Drawing.Size(547, 459);
            this.tlpLeft.TabIndex = 0;
            // 
            // lblDanhsachtaikhoan
            // 
            this.lblDanhsachtaikhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDanhsachtaikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDanhsachtaikhoan.Location = new System.Drawing.Point(3, 0);
            this.lblDanhsachtaikhoan.Name = "lblDanhsachtaikhoan";
            this.lblDanhsachtaikhoan.Size = new System.Drawing.Size(541, 40);
            this.lblDanhsachtaikhoan.TabIndex = 2;
            this.lblDanhsachtaikhoan.Text = "DANH SÁCH TÀI KHOẢN";
            this.lblDanhsachtaikhoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpSearch
            // 
            this.tlpSearch.ColumnCount = 1;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Controls.Add(this.tlpSearch1, 0, 0);
            this.tlpSearch.Controls.Add(this.pnlGird, 0, 1);
            this.tlpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearch.Location = new System.Drawing.Point(3, 43);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.RowCount = 2;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Size = new System.Drawing.Size(541, 413);
            this.tlpSearch.TabIndex = 3;
            // 
            // tlpSearch1
            // 
            this.tlpSearch1.ColumnCount = 2;
            this.tlpSearch1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSearch1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch1.Controls.Add(this.lblTimkiem, 0, 0);
            this.tlpSearch1.Controls.Add(this.txtSearch, 1, 0);
            this.tlpSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearch1.Location = new System.Drawing.Point(3, 3);
            this.tlpSearch1.Name = "tlpSearch1";
            this.tlpSearch1.RowCount = 1;
            this.tlpSearch1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch1.Size = new System.Drawing.Size(535, 44);
            this.tlpSearch1.TabIndex = 0;
            // 
            // lblTimkiem
            // 
            this.lblTimkiem.AutoSize = true;
            this.lblTimkiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTimkiem.Location = new System.Drawing.Point(3, 0);
            this.lblTimkiem.Name = "lblTimkiem";
            this.lblTimkiem.Size = new System.Drawing.Size(91, 44);
            this.lblTimkiem.TabIndex = 0;
            this.lblTimkiem.Text = "Tìm kiếm";
            this.lblTimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(100, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(432, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // pnlGird
            // 
            this.pnlGird.Controls.Add(this.dgvQuanlyphanquyen);
            this.pnlGird.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGird.Location = new System.Drawing.Point(3, 53);
            this.pnlGird.Name = "pnlGird";
            this.pnlGird.Size = new System.Drawing.Size(535, 357);
            this.pnlGird.TabIndex = 1;
            // 
            // dgvQuanlyphanquyen
            // 
            this.dgvQuanlyphanquyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanlyphanquyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuanlyphanquyen.Location = new System.Drawing.Point(0, 0);
            this.dgvQuanlyphanquyen.Name = "dgvQuanlyphanquyen";
            this.dgvQuanlyphanquyen.RowHeadersWidth = 51;
            this.dgvQuanlyphanquyen.RowTemplate.Height = 24;
            this.dgvQuanlyphanquyen.Size = new System.Drawing.Size(535, 357);
            this.dgvQuanlyphanquyen.TabIndex = 0;
            this.dgvQuanlyphanquyen.SelectionChanged += new System.EventHandler(this.dgvQuanlyphanquyen_SelectionChanged);
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.lblThongtinphanquyen, 0, 0);
            this.tlpRight.Controls.Add(this.tlpRight4, 0, 1);
            this.tlpRight.Controls.Add(this.tlpButton1, 0, 2);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(556, 3);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 3;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpRight.Size = new System.Drawing.Size(547, 459);
            this.tlpRight.TabIndex = 1;
            // 
            // lblThongtinphanquyen
            // 
            this.lblThongtinphanquyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThongtinphanquyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblThongtinphanquyen.Location = new System.Drawing.Point(3, 0);
            this.lblThongtinphanquyen.Name = "lblThongtinphanquyen";
            this.lblThongtinphanquyen.Size = new System.Drawing.Size(541, 40);
            this.lblThongtinphanquyen.TabIndex = 2;
            this.lblThongtinphanquyen.Text = "THÔNG TIN PHÂN QUYỀN";
            this.lblThongtinphanquyen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThongtinphanquyen.Click += new System.EventHandler(this.lblThongtinphanquyen_Click);
            // 
            // tlpRight4
            // 
            this.tlpRight4.ColumnCount = 1;
            this.tlpRight4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight4.Controls.Add(this.tlpInputs, 0, 0);
            this.tlpRight4.Controls.Add(this.grbQuanlyquyen, 0, 1);
            this.tlpRight4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight4.Location = new System.Drawing.Point(3, 43);
            this.tlpRight4.Name = "tlpRight4";
            this.tlpRight4.RowCount = 2;
            this.tlpRight4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tlpRight4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tlpRight4.Size = new System.Drawing.Size(541, 358);
            this.tlpRight4.TabIndex = 3;
            // 
            // tlpInputs
            // 
            this.tlpInputs.ColumnCount = 2;
            this.tlpInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInputs.Controls.Add(this.lblMataikhoan, 0, 0);
            this.tlpInputs.Controls.Add(this.txtMataikhoan, 1, 0);
            this.tlpInputs.Controls.Add(this.lblTendangnhap, 0, 1);
            this.tlpInputs.Controls.Add(this.txtTendangnhap, 1, 1);
            this.tlpInputs.Controls.Add(this.lblHoten, 0, 2);
            this.tlpInputs.Controls.Add(this.txtHoten, 1, 2);
            this.tlpInputs.Controls.Add(this.lblVaitro, 0, 3);
            this.tlpInputs.Controls.Add(this.cboVaitro, 1, 3);
            this.tlpInputs.Controls.Add(this.lblTrangthai, 0, 4);
            this.tlpInputs.Controls.Add(this.cboTrangthai, 1, 4);
            this.tlpInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInputs.Location = new System.Drawing.Point(3, 3);
            this.tlpInputs.Name = "tlpInputs";
            this.tlpInputs.RowCount = 5;
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpInputs.Size = new System.Drawing.Size(535, 144);
            this.tlpInputs.TabIndex = 0;
            // 
            // lblMataikhoan
            // 
            this.lblMataikhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMataikhoan.Location = new System.Drawing.Point(3, 0);
            this.lblMataikhoan.Name = "lblMataikhoan";
            this.lblMataikhoan.Size = new System.Drawing.Size(154, 28);
            this.lblMataikhoan.TabIndex = 0;
            this.lblMataikhoan.Text = "Mã tài khoản:";
            this.lblMataikhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMataikhoan
            // 
            this.txtMataikhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMataikhoan.Location = new System.Drawing.Point(163, 3);
            this.txtMataikhoan.Name = "txtMataikhoan";
            this.txtMataikhoan.ReadOnly = true;
            this.txtMataikhoan.Size = new System.Drawing.Size(369, 30);
            this.txtMataikhoan.TabIndex = 5;
            // 
            // lblTendangnhap
            // 
            this.lblTendangnhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTendangnhap.Location = new System.Drawing.Point(3, 28);
            this.lblTendangnhap.Name = "lblTendangnhap";
            this.lblTendangnhap.Size = new System.Drawing.Size(154, 28);
            this.lblTendangnhap.TabIndex = 1;
            this.lblTendangnhap.Text = "Tên đăng nhập:";
            this.lblTendangnhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTendangnhap
            // 
            this.txtTendangnhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTendangnhap.Location = new System.Drawing.Point(163, 31);
            this.txtTendangnhap.Name = "txtTendangnhap";
            this.txtTendangnhap.ReadOnly = true;
            this.txtTendangnhap.Size = new System.Drawing.Size(369, 30);
            this.txtTendangnhap.TabIndex = 6;
            // 
            // lblHoten
            // 
            this.lblHoten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHoten.Location = new System.Drawing.Point(3, 56);
            this.lblHoten.Name = "lblHoten";
            this.lblHoten.Size = new System.Drawing.Size(154, 28);
            this.lblHoten.TabIndex = 2;
            this.lblHoten.Text = "Họ tên:";
            this.lblHoten.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHoten
            // 
            this.txtHoten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHoten.Location = new System.Drawing.Point(163, 59);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.ReadOnly = true;
            this.txtHoten.Size = new System.Drawing.Size(369, 30);
            this.txtHoten.TabIndex = 7;
            // 
            // lblVaitro
            // 
            this.lblVaitro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVaitro.Location = new System.Drawing.Point(3, 84);
            this.lblVaitro.Name = "lblVaitro";
            this.lblVaitro.Size = new System.Drawing.Size(154, 28);
            this.lblVaitro.TabIndex = 3;
            this.lblVaitro.Text = "Vai trò:";
            this.lblVaitro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboVaitro
            // 
            this.cboVaitro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboVaitro.Enabled = false;
            this.cboVaitro.FormattingEnabled = true;
            this.cboVaitro.Location = new System.Drawing.Point(163, 87);
            this.cboVaitro.Name = "cboVaitro";
            this.cboVaitro.Size = new System.Drawing.Size(369, 33);
            this.cboVaitro.TabIndex = 8;
            // 
            // lblTrangthai
            // 
            this.lblTrangthai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrangthai.Location = new System.Drawing.Point(3, 112);
            this.lblTrangthai.Name = "lblTrangthai";
            this.lblTrangthai.Size = new System.Drawing.Size(154, 32);
            this.lblTrangthai.TabIndex = 4;
            this.lblTrangthai.Text = "Trạng thái:";
            this.lblTrangthai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTrangthai
            // 
            this.cboTrangthai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTrangthai.Enabled = false;
            this.cboTrangthai.FormattingEnabled = true;
            this.cboTrangthai.Location = new System.Drawing.Point(163, 115);
            this.cboTrangthai.Name = "cboTrangthai";
            this.cboTrangthai.Size = new System.Drawing.Size(369, 33);
            this.cboTrangthai.TabIndex = 9;
            // 
            // grbQuanlyquyen
            // 
            this.grbQuanlyquyen.Controls.Add(this.trvQuyenchucnang);
            this.grbQuanlyquyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbQuanlyquyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.grbQuanlyquyen.Location = new System.Drawing.Point(3, 153);
            this.grbQuanlyquyen.Name = "grbQuanlyquyen";
            this.grbQuanlyquyen.Size = new System.Drawing.Size(535, 202);
            this.grbQuanlyquyen.TabIndex = 1;
            this.grbQuanlyquyen.TabStop = false;
            this.grbQuanlyquyen.Text = "QUYỀN CHỨC NĂNG";
            // 
            // trvQuyenchucnang
            // 
            this.trvQuyenchucnang.CheckBoxes = true;
            this.trvQuyenchucnang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvQuyenchucnang.FullRowSelect = true;
            this.trvQuyenchucnang.Location = new System.Drawing.Point(3, 26);
            this.trvQuyenchucnang.Name = "trvQuyenchucnang";
            treeNode1.Name = "NodeXemthongtin";
            treeNode1.Tag = "CN001";
            treeNode1.Text = "Xem thông tin sinh viên";
            treeNode2.Name = "NodeThemhoso";
            treeNode2.Tag = "CN002";
            treeNode2.Text = "Thêm hồ sơ sinh viên";
            treeNode3.Name = "NodeSuahoso";
            treeNode3.Tag = "CN003";
            treeNode3.Text = "Sửa hồ sơ sinh viên";
            treeNode4.Name = "NodeQuanlysinhvien";
            treeNode4.Text = "Quản lý sinh viên";
            treeNode5.Name = "NodeQuanlyphong2";
            treeNode5.Tag = "CN004";
            treeNode5.Text = "Quản lý phòng";
            treeNode6.Name = "NodeQuanlykhunha";
            treeNode6.Tag = "CN005";
            treeNode6.Text = "Quản lý khu nhà";
            treeNode7.Name = "NodeQuanlyphong";
            treeNode7.Text = "Quản lý phòng";
            treeNode8.Name = "NodeQuanlyphongvakhunha";
            treeNode8.Text = "Quản lý phòng và khu nhà";
            treeNode9.Name = "NodeLaphoadon";
            treeNode9.Tag = "CN006";
            treeNode9.Text = "Lập hóa đơn";
            treeNode10.Name = "NodeThanhtoan";
            treeNode10.Tag = "CN007";
            treeNode10.Text = "Thanh toán hóa đơn";
            treeNode11.Name = "NodeQuanlythuchi";
            treeNode11.Text = "Quản lý thu/chi và hóa đơn";
            treeNode12.Name = "NodeCSVC";
            treeNode12.Tag = "CN008";
            treeNode12.Text = "Quản lý cơ sở vật chất";
            treeNode13.Name = "NodeQuanlycs";
            treeNode13.Text = "Quản lý cơ sở vật chất";
            treeNode14.Name = "NodeVipham";
            treeNode14.Tag = "CN009";
            treeNode14.Text = "Quản lý vi phạm";
            treeNode15.Name = "NodeQlyviphamkl";
            treeNode15.Text = "Quản lý vi phạm và kỉ luật";
            treeNode16.Name = "NodeXembaocao";
            treeNode16.Tag = "CN010";
            treeNode16.Text = "Xem báo cáo và thống kê";
            treeNode17.Name = "NodeBaocaothongke";
            treeNode17.Text = "Báo cáo và thống kê";
            treeNode18.Name = "NodePhanquyen";
            treeNode18.Tag = "CN011";
            treeNode18.Text = "Phân quyền hệ thống";
            treeNode19.Name = "NodeCaidat";
            treeNode19.Text = "Cài đặt hệ thống";
            this.trvQuyenchucnang.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode8,
            treeNode11,
            treeNode13,
            treeNode15,
            treeNode17,
            treeNode19});
            this.trvQuyenchucnang.Size = new System.Drawing.Size(529, 173);
            this.trvQuyenchucnang.TabIndex = 0;
            this.trvQuyenchucnang.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvQuyenchucnang_AfterSelect);
            // 
            // tlpButton1
            // 
            this.tlpButton1.ColumnCount = 3;
            this.tlpButton1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpButton1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpButton1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpButton1.Controls.Add(this.btnSave, 0, 0);
            this.tlpButton1.Controls.Add(this.btnCancel, 1, 0);
            this.tlpButton1.Controls.Add(this.btnClose, 2, 0);
            this.tlpButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButton1.Location = new System.Drawing.Point(3, 407);
            this.tlpButton1.Name = "tlpButton1";
            this.tlpButton1.RowCount = 1;
            this.tlpButton1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton1.Size = new System.Drawing.Size(541, 49);
            this.tlpButton1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(174, 43);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "confirm";
            this.btnSave.Text = "Ghi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(183, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(174, 43);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Tag = "confirm";
            this.btnCancel.Text = "Hủy ghi";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(363, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(175, 43);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Kết thúc";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Quanlyphanquyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 540);
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Quanlyphanquyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quanlyphanquyen";
            this.Load += new System.EventHandler(this.Quanlyphanquyen_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.tlpContent.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.tlpSearch.ResumeLayout(false);
            this.tlpSearch1.ResumeLayout(false);
            this.tlpSearch1.PerformLayout();
            this.pnlGird.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanlyphanquyen)).EndInit();
            this.tlpRight.ResumeLayout(false);
            this.tlpRight4.ResumeLayout(false);
            this.tlpInputs.ResumeLayout(false);
            this.tlpInputs.PerformLayout();
            this.grbQuanlyquyen.ResumeLayout(false);
            this.tlpButton1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblQuanlyphanquyen;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.Label lblDanhsachtaikhoan;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.TableLayoutPanel tlpSearch1;
        private System.Windows.Forms.Label lblTimkiem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlGird;
        private System.Windows.Forms.DataGridView dgvQuanlyphanquyen;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.Label lblThongtinphanquyen;
        private System.Windows.Forms.TableLayoutPanel tlpRight4;
        private System.Windows.Forms.TableLayoutPanel tlpInputs;
        private System.Windows.Forms.Label lblMataikhoan;
        private System.Windows.Forms.TextBox txtMataikhoan;
        private System.Windows.Forms.Label lblTendangnhap;
        private System.Windows.Forms.TextBox txtTendangnhap;
        private System.Windows.Forms.Label lblHoten;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.Label lblVaitro;
        private System.Windows.Forms.ComboBox cboVaitro;
        private System.Windows.Forms.Label lblTrangthai;
        private System.Windows.Forms.ComboBox cboTrangthai;
        private System.Windows.Forms.GroupBox grbQuanlyquyen;
        private System.Windows.Forms.TreeView trvQuyenchucnang;
        private System.Windows.Forms.TableLayoutPanel tlpButton1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
    }
}