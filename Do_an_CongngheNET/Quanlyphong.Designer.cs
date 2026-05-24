namespace Do_an_CongngheNET
{
    partial class Quanlyphong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tlplnputs = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaphong = new System.Windows.Forms.Label();
            this.txtMaphong = new System.Windows.Forms.TextBox();
            this.lblSophong = new System.Windows.Forms.Label();
            this.txtSophong = new System.Windows.Forms.TextBox();
            this.cboKhunha = new System.Windows.Forms.ComboBox();
            this.lblKhunha = new System.Windows.Forms.Label();
            this.lblTang = new System.Windows.Forms.Label();
            this.lblLoaiphong = new System.Windows.Forms.Label();
            this.cboTang = new System.Windows.Forms.ComboBox();
            this.cboLoaiphong = new System.Windows.Forms.ComboBox();
            this.lblGhichu = new System.Windows.Forms.Label();
            this.txtGhichu = new System.Windows.Forms.TextBox();
            this.lblTrangthai = new System.Windows.Forms.Label();
            this.cboTrangthai = new System.Windows.Forms.ComboBox();
            this.lblGioitinh = new System.Windows.Forms.Label();
            this.cboGioitinh = new System.Windows.Forms.ComboBox();
            this.lblGiaphong = new System.Windows.Forms.Label();
            this.txtGiaphong = new System.Windows.Forms.TextBox();
            this.lblSonguoio = new System.Windows.Forms.Label();
            this.txtSonguoio = new System.Windows.Forms.TextBox();
            this.txtSucchua = new System.Windows.Forms.TextBox();
            this.lblSucchua = new System.Windows.Forms.Label();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimkiem = new System.Windows.Forms.Label();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvQuanlyphong = new System.Windows.Forms.DataGridView();
            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.tlplnputs.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.tlpSearch.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanlyphong)).BeginInit();
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
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(1001, 610);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(6, 6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(989, 53);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(383, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(247, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ PHÒNG";
            // 
            // tlpContent
            // 
            this.tlpContent.ColumnCount = 2;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpContent.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpContent.Controls.Add(this.tlpRight, 1, 0);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(6, 68);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 1;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Size = new System.Drawing.Size(989, 536);
            this.tlpContent.TabIndex = 1;
            // 
            // tlpLeft
            // 
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.tlplnputs, 0, 0);
            this.tlpLeft.Controls.Add(this.tlpButtons, 0, 1);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(3, 3);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 2;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tlpLeft.Size = new System.Drawing.Size(389, 530);
            this.tlpLeft.TabIndex = 0;
            // 
            // tlplnputs
            // 
            this.tlplnputs.ColumnCount = 2;
            this.tlplnputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlplnputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlplnputs.Controls.Add(this.lblMaphong, 0, 0);
            this.tlplnputs.Controls.Add(this.txtMaphong, 1, 0);
            this.tlplnputs.Controls.Add(this.lblSophong, 0, 1);
            this.tlplnputs.Controls.Add(this.txtSophong, 1, 1);
            this.tlplnputs.Controls.Add(this.cboKhunha, 1, 2);
            this.tlplnputs.Controls.Add(this.lblKhunha, 0, 2);
            this.tlplnputs.Controls.Add(this.lblTang, 0, 3);
            this.tlplnputs.Controls.Add(this.lblLoaiphong, 0, 4);
            this.tlplnputs.Controls.Add(this.cboTang, 1, 3);
            this.tlplnputs.Controls.Add(this.cboLoaiphong, 1, 4);
            this.tlplnputs.Controls.Add(this.lblGhichu, 0, 10);
            this.tlplnputs.Controls.Add(this.txtGhichu, 1, 10);
            this.tlplnputs.Controls.Add(this.lblTrangthai, 0, 9);
            this.tlplnputs.Controls.Add(this.cboTrangthai, 1, 9);
            this.tlplnputs.Controls.Add(this.lblGioitinh, 0, 8);
            this.tlplnputs.Controls.Add(this.cboGioitinh, 1, 8);
            this.tlplnputs.Controls.Add(this.lblGiaphong, 0, 7);
            this.tlplnputs.Controls.Add(this.txtGiaphong, 1, 7);
            this.tlplnputs.Controls.Add(this.lblSonguoio, 0, 6);
            this.tlplnputs.Controls.Add(this.txtSonguoio, 1, 6);
            this.tlplnputs.Controls.Add(this.txtSucchua, 1, 5);
            this.tlplnputs.Controls.Add(this.lblSucchua, 0, 5);
            this.tlplnputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlplnputs.Location = new System.Drawing.Point(3, 3);
            this.tlplnputs.Name = "tlplnputs";
            this.tlplnputs.RowCount = 11;
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlplnputs.Size = new System.Drawing.Size(383, 427);
            this.tlplnputs.TabIndex = 0;
            // 
            // lblMaphong
            // 
            this.lblMaphong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMaphong.AutoSize = true;
            this.lblMaphong.Location = new System.Drawing.Point(7, 6);
            this.lblMaphong.Name = "lblMaphong";
            this.lblMaphong.Size = new System.Drawing.Size(106, 25);
            this.lblMaphong.TabIndex = 0;
            this.lblMaphong.Text = "Mã phòng:";
            // 
            // txtMaphong
            // 
            this.txtMaphong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaphong.Location = new System.Drawing.Point(124, 4);
            this.txtMaphong.Name = "txtMaphong";
            this.txtMaphong.Size = new System.Drawing.Size(256, 30);
            this.txtMaphong.TabIndex = 1;
            // 
            // lblSophong
            // 
            this.lblSophong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSophong.AutoSize = true;
            this.lblSophong.Location = new System.Drawing.Point(9, 44);
            this.lblSophong.Name = "lblSophong";
            this.lblSophong.Size = new System.Drawing.Size(103, 25);
            this.lblSophong.TabIndex = 2;
            this.lblSophong.Text = "Số phòng:";
            // 
            // txtSophong
            // 
            this.txtSophong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSophong.Location = new System.Drawing.Point(124, 42);
            this.txtSophong.Name = "txtSophong";
            this.txtSophong.Size = new System.Drawing.Size(256, 30);
            this.txtSophong.TabIndex = 3;
            // 
            // cboKhunha
            // 
            this.cboKhunha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKhunha.FormattingEnabled = true;
            this.cboKhunha.Location = new System.Drawing.Point(124, 79);
            this.cboKhunha.Name = "cboKhunha";
            this.cboKhunha.Size = new System.Drawing.Size(256, 33);
            this.cboKhunha.TabIndex = 4;
            // 
            // lblKhunha
            // 
            this.lblKhunha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKhunha.AutoSize = true;
            this.lblKhunha.Location = new System.Drawing.Point(14, 82);
            this.lblKhunha.Name = "lblKhunha";
            this.lblKhunha.Size = new System.Drawing.Size(92, 25);
            this.lblKhunha.TabIndex = 2;
            this.lblKhunha.Text = "Khu nhà:";
            // 
            // lblTang
            // 
            this.lblTang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTang.AutoSize = true;
            this.lblTang.Location = new System.Drawing.Point(28, 120);
            this.lblTang.Name = "lblTang";
            this.lblTang.Size = new System.Drawing.Size(64, 25);
            this.lblTang.TabIndex = 2;
            this.lblTang.Text = "Tầng:";
            // 
            // lblLoaiphong
            // 
            this.lblLoaiphong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoaiphong.AutoSize = true;
            this.lblLoaiphong.Location = new System.Drawing.Point(3, 158);
            this.lblLoaiphong.Name = "lblLoaiphong";
            this.lblLoaiphong.Size = new System.Drawing.Size(115, 25);
            this.lblLoaiphong.TabIndex = 2;
            this.lblLoaiphong.Text = "Loại phòng:";
            // 
            // cboTang
            // 
            this.cboTang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTang.FormattingEnabled = true;
            this.cboTang.Location = new System.Drawing.Point(124, 121);
            this.cboTang.Name = "cboTang";
            this.cboTang.Size = new System.Drawing.Size(256, 33);
            this.cboTang.TabIndex = 4;
            // 
            // cboLoaiphong
            // 
            this.cboLoaiphong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLoaiphong.FormattingEnabled = true;
            this.cboLoaiphong.Items.AddRange(new object[] {
            "Phòng 4 người",
            "Phòng 6 người"});
            this.cboLoaiphong.Location = new System.Drawing.Point(124, 159);
            this.cboLoaiphong.Name = "cboLoaiphong";
            this.cboLoaiphong.Size = new System.Drawing.Size(256, 33);
            this.cboLoaiphong.TabIndex = 4;
            // 
            // lblGhichu
            // 
            this.lblGhichu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGhichu.AutoSize = true;
            this.lblGhichu.Location = new System.Drawing.Point(18, 391);
            this.lblGhichu.Name = "lblGhichu";
            this.lblGhichu.Size = new System.Drawing.Size(85, 25);
            this.lblGhichu.TabIndex = 2;
            this.lblGhichu.Text = "Ghi chú:";
            // 
            // txtGhichu
            // 
            this.txtGhichu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhichu.Location = new System.Drawing.Point(124, 388);
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Size = new System.Drawing.Size(256, 30);
            this.txtGhichu.TabIndex = 3;
            // 
            // lblTrangthai
            // 
            this.lblTrangthai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTrangthai.AutoSize = true;
            this.lblTrangthai.Location = new System.Drawing.Point(7, 348);
            this.lblTrangthai.Name = "lblTrangthai";
            this.lblTrangthai.Size = new System.Drawing.Size(106, 25);
            this.lblTrangthai.TabIndex = 2;
            this.lblTrangthai.Text = "Trạng thái:";
            // 
            // cboTrangthai
            // 
            this.cboTrangthai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTrangthai.FormattingEnabled = true;
            this.cboTrangthai.Items.AddRange(new object[] {
            "Còn chỗ",
            "Bảo trì",
            "Ngưng sử dụng",
            "Đang sử dụng"});
            this.cboTrangthai.Location = new System.Drawing.Point(124, 349);
            this.cboTrangthai.Name = "cboTrangthai";
            this.cboTrangthai.Size = new System.Drawing.Size(256, 33);
            this.cboTrangthai.TabIndex = 4;
            // 
            // lblGioitinh
            // 
            this.lblGioitinh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGioitinh.AutoSize = true;
            this.lblGioitinh.Location = new System.Drawing.Point(16, 310);
            this.lblGioitinh.Name = "lblGioitinh";
            this.lblGioitinh.Size = new System.Drawing.Size(88, 25);
            this.lblGioitinh.TabIndex = 2;
            this.lblGioitinh.Text = "Giới tính:";
            // 
            // cboGioitinh
            // 
            this.cboGioitinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGioitinh.FormattingEnabled = true;
            this.cboGioitinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGioitinh.Location = new System.Drawing.Point(124, 311);
            this.cboGioitinh.Name = "cboGioitinh";
            this.cboGioitinh.Size = new System.Drawing.Size(256, 33);
            this.cboGioitinh.TabIndex = 4;
            // 
            // lblGiaphong
            // 
            this.lblGiaphong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGiaphong.AutoSize = true;
            this.lblGiaphong.Location = new System.Drawing.Point(6, 272);
            this.lblGiaphong.Name = "lblGiaphong";
            this.lblGiaphong.Size = new System.Drawing.Size(108, 25);
            this.lblGiaphong.TabIndex = 2;
            this.lblGiaphong.Text = "Giá phòng:";
            // 
            // txtGiaphong
            // 
            this.txtGiaphong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGiaphong.Location = new System.Drawing.Point(124, 270);
            this.txtGiaphong.Name = "txtGiaphong";
            this.txtGiaphong.Size = new System.Drawing.Size(256, 30);
            this.txtGiaphong.TabIndex = 3;
            // 
            // lblSonguoio
            // 
            this.lblSonguoio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSonguoio.AutoSize = true;
            this.lblSonguoio.Location = new System.Drawing.Point(4, 234);
            this.lblSonguoio.Name = "lblSonguoio";
            this.lblSonguoio.Size = new System.Drawing.Size(112, 25);
            this.lblSonguoio.TabIndex = 2;
            this.lblSonguoio.Text = "Số người ở:";
            // 
            // txtSonguoio
            // 
            this.txtSonguoio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSonguoio.Location = new System.Drawing.Point(124, 232);
            this.txtSonguoio.Name = "txtSonguoio";
            this.txtSonguoio.Size = new System.Drawing.Size(256, 30);
            this.txtSonguoio.TabIndex = 3;
            // 
            // txtSucchua
            // 
            this.txtSucchua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSucchua.Location = new System.Drawing.Point(124, 194);
            this.txtSucchua.Name = "txtSucchua";
            this.txtSucchua.Size = new System.Drawing.Size(256, 30);
            this.txtSucchua.TabIndex = 5;
            // 
            // lblSucchua
            // 
            this.lblSucchua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSucchua.AutoSize = true;
            this.lblSucchua.Location = new System.Drawing.Point(10, 196);
            this.lblSucchua.Name = "lblSucchua";
            this.lblSucchua.Size = new System.Drawing.Size(101, 25);
            this.lblSucchua.TabIndex = 6;
            this.lblSucchua.Text = "Sức chứa:";
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 3;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtons.Controls.Add(this.btnNew, 0, 0);
            this.tlpButtons.Controls.Add(this.btnEdit, 1, 0);
            this.tlpButtons.Controls.Add(this.btnDelete, 2, 0);
            this.tlpButtons.Controls.Add(this.btnClose, 2, 1);
            this.tlpButtons.Controls.Add(this.btnCancel, 1, 1);
            this.tlpButtons.Controls.Add(this.btnSave, 0, 1);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(3, 436);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 2;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Size = new System.Drawing.Size(383, 91);
            this.tlpButtons.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.SystemColors.Window;
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(121, 39);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Thêm mới";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.SystemColors.Window;
            this.btnEdit.Location = new System.Drawing.Point(130, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(121, 39);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.SystemColors.Window;
            this.btnDelete.Location = new System.Drawing.Point(257, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(123, 39);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.Window;
            this.btnClose.Location = new System.Drawing.Point(257, 48);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Kết thúc";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.Location = new System.Drawing.Point(130, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 40);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy ghi";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Window;
            this.btnSave.Location = new System.Drawing.Point(3, 48);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Ghi";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.tlpSearch, 0, 0);
            this.tlpRight.Controls.Add(this.pnlGrid, 0, 1);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(398, 3);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 2;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Size = new System.Drawing.Size(588, 530);
            this.tlpRight.TabIndex = 1;
            // 
            // tlpSearch
            // 
            this.tlpSearch.ColumnCount = 2;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Controls.Add(this.lblTimkiem, 0, 0);
            this.tlpSearch.Controls.Add(this.txtTimkiem, 1, 0);
            this.tlpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearch.Location = new System.Drawing.Point(3, 3);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.RowCount = 1;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Size = new System.Drawing.Size(582, 50);
            this.tlpSearch.TabIndex = 0;
            // 
            // lblTimkiem
            // 
            this.lblTimkiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTimkiem.AutoSize = true;
            this.lblTimkiem.Location = new System.Drawing.Point(3, 12);
            this.lblTimkiem.Name = "lblTimkiem";
            this.lblTimkiem.Size = new System.Drawing.Size(226, 25);
            this.lblTimkiem.TabIndex = 0;
            this.lblTimkiem.Text = "Tìm kiếm số / tên phòng:";
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimkiem.Location = new System.Drawing.Point(235, 10);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(344, 30);
            this.txtTimkiem.TabIndex = 1;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvQuanlyphong);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(3, 59);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(582, 468);
            this.pnlGrid.TabIndex = 1;
            // 
            // dgvQuanlyphong
            // 
            this.dgvQuanlyphong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanlyphong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuanlyphong.Location = new System.Drawing.Point(0, 0);
            this.dgvQuanlyphong.Name = "dgvQuanlyphong";
            this.dgvQuanlyphong.RowHeadersWidth = 51;
            this.dgvQuanlyphong.RowTemplate.Height = 24;
            this.dgvQuanlyphong.Size = new System.Drawing.Size(582, 468);
            this.dgvQuanlyphong.TabIndex = 0;
            // 
            // Quanlyphong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1001, 610);
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Quanlyphong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quanlyphong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpContent.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.tlplnputs.ResumeLayout(false);
            this.tlplnputs.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            this.tlpSearch.ResumeLayout(false);
            this.tlpSearch.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanlyphong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.TableLayoutPanel tlplnputs;
        private System.Windows.Forms.Label lblMaphong;
        private System.Windows.Forms.TextBox txtMaphong;
        private System.Windows.Forms.Label lblSophong;
        private System.Windows.Forms.TextBox txtSophong;
        private System.Windows.Forms.ComboBox cboKhunha;
        private System.Windows.Forms.Label lblKhunha;
        private System.Windows.Forms.Label lblTang;
        private System.Windows.Forms.Label lblLoaiphong;
        private System.Windows.Forms.Label lblSonguoio;
        private System.Windows.Forms.Label lblGiaphong;
        private System.Windows.Forms.Label lblGioitinh;
        private System.Windows.Forms.Label lblTrangthai;
        private System.Windows.Forms.Label lblGhichu;
        private System.Windows.Forms.ComboBox cboTang;
        private System.Windows.Forms.ComboBox cboLoaiphong;
        private System.Windows.Forms.TextBox txtSonguoio;
        private System.Windows.Forms.TextBox txtGiaphong;
        private System.Windows.Forms.ComboBox cboGioitinh;
        private System.Windows.Forms.ComboBox cboTrangthai;
        private System.Windows.Forms.TextBox txtGhichu;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.Label lblTimkiem;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvQuanlyphong;
        private System.Windows.Forms.TextBox txtSucchua;
        private System.Windows.Forms.Label lblSucchua;
    }
}