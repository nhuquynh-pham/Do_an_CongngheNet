namespace Do_an_CongngheNET
{
    partial class Traphong
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
            this.tlpInputs = new System.Windows.Forms.TableLayoutPanel();
            this.lblMatraphong = new System.Windows.Forms.Label();
            this.lblMasinhvien = new System.Windows.Forms.Label();
            this.lblHoten = new System.Windows.Forms.Label();
            this.lblKhunha = new System.Windows.Forms.Label();
            this.lblPhongdango = new System.Windows.Forms.Label();
            this.lblGiuong = new System.Windows.Forms.Label();
            this.lblNgayvaoo = new System.Windows.Forms.Label();
            this.lblNgaytraphong = new System.Windows.Forms.Label();
            this.lblLydotra = new System.Windows.Forms.Label();
            this.lblTrangthai = new System.Windows.Forms.Label();
            this.lblGhichu = new System.Windows.Forms.Label();
            this.txtmatraphong = new System.Windows.Forms.TextBox();
            this.txtMsv = new System.Windows.Forms.TextBox();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.txtGhichu = new System.Windows.Forms.TextBox();
            this.txtLydotra = new System.Windows.Forms.TextBox();
            this.txtNgaytraphong = new System.Windows.Forms.TextBox();
            this.txtNgayvaoo = new System.Windows.Forms.TextBox();
            this.cboKhunha = new System.Windows.Forms.ComboBox();
            this.cboPhongdango = new System.Windows.Forms.ComboBox();
            this.cboGiuong = new System.Windows.Forms.ComboBox();
            this.cboTrangthai = new System.Windows.Forms.ComboBox();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlGird = new System.Windows.Forms.Panel();
            this.dgvTraphong = new System.Windows.Forms.DataGridView();
            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.tlpInputs.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.tlpSearch.SuspendLayout();
            this.pnlGird.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraphong)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpRoot.Controls.Add(this.tlpContent, 0, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 2;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.603896F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.3961F));
            this.tlpRoot.Size = new System.Drawing.Size(1016, 619);
            this.tlpRoot.TabIndex = 0;
            this.tlpRoot.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpRoot_Paint);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(6, 6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(15, 10, 0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1004, 46);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(403, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(164, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TRẢ PHÒNG";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // tlpContent
            // 
            this.tlpContent.ColumnCount = 2;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.22843F));
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.77157F));
            this.tlpContent.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpContent.Controls.Add(this.tlpRight, 1, 0);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(6, 61);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 1;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContent.Size = new System.Drawing.Size(1004, 552);
            this.tlpContent.TabIndex = 1;
            this.tlpContent.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpContent_Paint);
            // 
            // tlpLeft
            // 
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLeft.Controls.Add(this.tlpInputs, 0, 0);
            this.tlpLeft.Controls.Add(this.tlpButtons, 0, 1);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(3, 3);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 2;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.61855F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.38144F));
            this.tlpLeft.Size = new System.Drawing.Size(397, 546);
            this.tlpLeft.TabIndex = 0;
            // 
            // tlpInputs
            // 
            this.tlpInputs.ColumnCount = 2;
            this.tlpInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInputs.Controls.Add(this.lblMatraphong, 0, 0);
            this.tlpInputs.Controls.Add(this.lblMasinhvien, 0, 1);
            this.tlpInputs.Controls.Add(this.lblHoten, 0, 2);
            this.tlpInputs.Controls.Add(this.lblKhunha, 0, 3);
            this.tlpInputs.Controls.Add(this.lblPhongdango, 0, 4);
            this.tlpInputs.Controls.Add(this.lblGiuong, 0, 5);
            this.tlpInputs.Controls.Add(this.lblNgayvaoo, 0, 6);
            this.tlpInputs.Controls.Add(this.lblNgaytraphong, 0, 7);
            this.tlpInputs.Controls.Add(this.lblLydotra, 0, 8);
            this.tlpInputs.Controls.Add(this.lblTrangthai, 0, 9);
            this.tlpInputs.Controls.Add(this.lblGhichu, 0, 10);
            this.tlpInputs.Controls.Add(this.txtmatraphong, 1, 0);
            this.tlpInputs.Controls.Add(this.txtMsv, 1, 1);
            this.tlpInputs.Controls.Add(this.txtHoten, 1, 2);
            this.tlpInputs.Controls.Add(this.txtGhichu, 1, 10);
            this.tlpInputs.Controls.Add(this.txtLydotra, 1, 8);
            this.tlpInputs.Controls.Add(this.txtNgaytraphong, 1, 7);
            this.tlpInputs.Controls.Add(this.txtNgayvaoo, 1, 6);
            this.tlpInputs.Controls.Add(this.cboKhunha, 1, 3);
            this.tlpInputs.Controls.Add(this.cboPhongdango, 1, 4);
            this.tlpInputs.Controls.Add(this.cboGiuong, 1, 5);
            this.tlpInputs.Controls.Add(this.cboTrangthai, 1, 9);
            this.tlpInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInputs.Location = new System.Drawing.Point(3, 3);
            this.tlpInputs.Name = "tlpInputs";
            this.tlpInputs.RowCount = 11;
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpInputs.Size = new System.Drawing.Size(391, 434);
            this.tlpInputs.TabIndex = 0;
            // 
            // lblMatraphong
            // 
            this.lblMatraphong.AutoSize = true;
            this.lblMatraphong.Location = new System.Drawing.Point(3, 0);
            this.lblMatraphong.Name = "lblMatraphong";
            this.lblMatraphong.Size = new System.Drawing.Size(133, 25);
            this.lblMatraphong.TabIndex = 0;
            this.lblMatraphong.Text = "Mã trả phòng:";
            // 
            // lblMasinhvien
            // 
            this.lblMasinhvien.AutoSize = true;
            this.lblMasinhvien.Location = new System.Drawing.Point(3, 39);
            this.lblMasinhvien.Name = "lblMasinhvien";
            this.lblMasinhvien.Size = new System.Drawing.Size(155, 25);
            this.lblMasinhvien.TabIndex = 0;
            this.lblMasinhvien.Text = "Mã sinh viên (*):";
            // 
            // lblHoten
            // 
            this.lblHoten.AutoSize = true;
            this.lblHoten.Location = new System.Drawing.Point(3, 78);
            this.lblHoten.Name = "lblHoten";
            this.lblHoten.Size = new System.Drawing.Size(75, 25);
            this.lblHoten.TabIndex = 0;
            this.lblHoten.Text = "Họ tên:";
            // 
            // lblKhunha
            // 
            this.lblKhunha.AutoSize = true;
            this.lblKhunha.Location = new System.Drawing.Point(3, 117);
            this.lblKhunha.Name = "lblKhunha";
            this.lblKhunha.Size = new System.Drawing.Size(92, 25);
            this.lblKhunha.TabIndex = 0;
            this.lblKhunha.Text = "Khu nhà:";
            // 
            // lblPhongdango
            // 
            this.lblPhongdango.AutoSize = true;
            this.lblPhongdango.Location = new System.Drawing.Point(3, 156);
            this.lblPhongdango.Name = "lblPhongdango";
            this.lblPhongdango.Size = new System.Drawing.Size(140, 25);
            this.lblPhongdango.TabIndex = 0;
            this.lblPhongdango.Text = "Phòng đang ở:";
            // 
            // lblGiuong
            // 
            this.lblGiuong.AutoSize = true;
            this.lblGiuong.Location = new System.Drawing.Point(3, 195);
            this.lblGiuong.Name = "lblGiuong";
            this.lblGiuong.Size = new System.Drawing.Size(81, 25);
            this.lblGiuong.TabIndex = 0;
            this.lblGiuong.Text = "Giường:";
            // 
            // lblNgayvaoo
            // 
            this.lblNgayvaoo.AutoSize = true;
            this.lblNgayvaoo.Location = new System.Drawing.Point(3, 234);
            this.lblNgayvaoo.Name = "lblNgayvaoo";
            this.lblNgayvaoo.Size = new System.Drawing.Size(117, 25);
            this.lblNgayvaoo.TabIndex = 0;
            this.lblNgayvaoo.Text = "Ngày vào ở:";
            // 
            // lblNgaytraphong
            // 
            this.lblNgaytraphong.AutoSize = true;
            this.lblNgaytraphong.Location = new System.Drawing.Point(3, 273);
            this.lblNgaytraphong.Name = "lblNgaytraphong";
            this.lblNgaytraphong.Size = new System.Drawing.Size(151, 25);
            this.lblNgaytraphong.TabIndex = 0;
            this.lblNgaytraphong.Text = "Ngày trả phòng:";
            // 
            // lblLydotra
            // 
            this.lblLydotra.AutoSize = true;
            this.lblLydotra.Location = new System.Drawing.Point(3, 312);
            this.lblLydotra.Name = "lblLydotra";
            this.lblLydotra.Size = new System.Drawing.Size(93, 25);
            this.lblLydotra.TabIndex = 0;
            this.lblLydotra.Text = "Lý do trả:";
            // 
            // lblTrangthai
            // 
            this.lblTrangthai.AutoSize = true;
            this.lblTrangthai.Location = new System.Drawing.Point(3, 351);
            this.lblTrangthai.Name = "lblTrangthai";
            this.lblTrangthai.Size = new System.Drawing.Size(106, 25);
            this.lblTrangthai.TabIndex = 0;
            this.lblTrangthai.Text = "Trạng thái:";
            // 
            // lblGhichu
            // 
            this.lblGhichu.AutoSize = true;
            this.lblGhichu.Location = new System.Drawing.Point(3, 390);
            this.lblGhichu.Name = "lblGhichu";
            this.lblGhichu.Size = new System.Drawing.Size(85, 25);
            this.lblGhichu.TabIndex = 0;
            this.lblGhichu.Text = "Ghi chú:";
            // 
            // txtmatraphong
            // 
            this.txtmatraphong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtmatraphong.Location = new System.Drawing.Point(198, 3);
            this.txtmatraphong.Name = "txtmatraphong";
            this.txtmatraphong.Size = new System.Drawing.Size(190, 30);
            this.txtmatraphong.TabIndex = 1;
            // 
            // txtMsv
            // 
            this.txtMsv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsv.Location = new System.Drawing.Point(198, 42);
            this.txtMsv.Name = "txtMsv";
            this.txtMsv.Size = new System.Drawing.Size(190, 30);
            this.txtMsv.TabIndex = 1;
            // 
            // txtHoten
            // 
            this.txtHoten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHoten.Location = new System.Drawing.Point(198, 81);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(190, 30);
            this.txtHoten.TabIndex = 1;
            // 
            // txtGhichu
            // 
            this.txtGhichu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhichu.Location = new System.Drawing.Point(198, 393);
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Size = new System.Drawing.Size(190, 30);
            this.txtGhichu.TabIndex = 1;
            this.txtGhichu.TextChanged += new System.EventHandler(this.txtGhichu_TextChanged);
            // 
            // txtLydotra
            // 
            this.txtLydotra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLydotra.Location = new System.Drawing.Point(198, 315);
            this.txtLydotra.Name = "txtLydotra";
            this.txtLydotra.Size = new System.Drawing.Size(190, 30);
            this.txtLydotra.TabIndex = 1;
            // 
            // txtNgaytraphong
            // 
            this.txtNgaytraphong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgaytraphong.Location = new System.Drawing.Point(198, 276);
            this.txtNgaytraphong.Name = "txtNgaytraphong";
            this.txtNgaytraphong.Size = new System.Drawing.Size(190, 30);
            this.txtNgaytraphong.TabIndex = 1;
            // 
            // txtNgayvaoo
            // 
            this.txtNgayvaoo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgayvaoo.Location = new System.Drawing.Point(198, 237);
            this.txtNgayvaoo.Name = "txtNgayvaoo";
            this.txtNgayvaoo.Size = new System.Drawing.Size(190, 30);
            this.txtNgayvaoo.TabIndex = 1;
            // 
            // cboKhunha
            // 
            this.cboKhunha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKhunha.FormattingEnabled = true;
            this.cboKhunha.Location = new System.Drawing.Point(198, 120);
            this.cboKhunha.Name = "cboKhunha";
            this.cboKhunha.Size = new System.Drawing.Size(190, 33);
            this.cboKhunha.TabIndex = 2;
            // 
            // cboPhongdango
            // 
            this.cboPhongdango.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPhongdango.FormattingEnabled = true;
            this.cboPhongdango.Location = new System.Drawing.Point(198, 159);
            this.cboPhongdango.Name = "cboPhongdango";
            this.cboPhongdango.Size = new System.Drawing.Size(190, 33);
            this.cboPhongdango.TabIndex = 2;
            // 
            // cboGiuong
            // 
            this.cboGiuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboGiuong.FormattingEnabled = true;
            this.cboGiuong.Location = new System.Drawing.Point(198, 198);
            this.cboGiuong.Name = "cboGiuong";
            this.cboGiuong.Size = new System.Drawing.Size(190, 33);
            this.cboGiuong.TabIndex = 2;
            // 
            // cboTrangthai
            // 
            this.cboTrangthai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTrangthai.FormattingEnabled = true;
            this.cboTrangthai.Location = new System.Drawing.Point(198, 354);
            this.cboTrangthai.Name = "cboTrangthai";
            this.cboTrangthai.Size = new System.Drawing.Size(190, 33);
            this.cboTrangthai.TabIndex = 2;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 3;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtons.Controls.Add(this.btnNew, 0, 0);
            this.tlpButtons.Controls.Add(this.btnSave, 0, 1);
            this.tlpButtons.Controls.Add(this.btnCancel, 1, 1);
            this.tlpButtons.Controls.Add(this.btnEdit, 1, 0);
            this.tlpButtons.Controls.Add(this.btnDelete, 2, 0);
            this.tlpButtons.Controls.Add(this.btnClose, 2, 1);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(3, 443);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 2;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Size = new System.Drawing.Size(391, 100);
            this.tlpButtons.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(124, 44);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Thêm mới";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(3, 53);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 44);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Ghi";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(133, 53);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 44);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy ghi";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Location = new System.Drawing.Point(133, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(124, 44);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(263, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 44);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(263, 53);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 44);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Kết thúc:";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRight.Controls.Add(this.tlpSearch, 0, 0);
            this.tlpRight.Controls.Add(this.pnlGird, 0, 1);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(406, 3);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 2;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.213052F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.78695F));
            this.tlpRight.Size = new System.Drawing.Size(595, 546);
            this.tlpRight.TabIndex = 1;
            // 
            // tlpSearch
            // 
            this.tlpSearch.ColumnCount = 2;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Controls.Add(this.lblSearch, 0, 0);
            this.tlpSearch.Controls.Add(this.txtSearch, 1, 0);
            this.tlpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearch.Location = new System.Drawing.Point(3, 3);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.RowCount = 1;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Size = new System.Drawing.Size(589, 44);
            this.tlpSearch.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(97, 25);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(106, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(480, 30);
            this.txtSearch.TabIndex = 1;
            // 
            // pnlGird
            // 
            this.pnlGird.Controls.Add(this.dgvTraphong);
            this.pnlGird.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGird.Location = new System.Drawing.Point(3, 53);
            this.pnlGird.Name = "pnlGird";
            this.pnlGird.Size = new System.Drawing.Size(589, 490);
            this.pnlGird.TabIndex = 1;
            // 
            // dgvTraphong
            // 
            this.dgvTraphong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraphong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTraphong.Location = new System.Drawing.Point(0, 0);
            this.dgvTraphong.Name = "dgvTraphong";
            this.dgvTraphong.RowHeadersWidth = 51;
            this.dgvTraphong.RowTemplate.Height = 24;
            this.dgvTraphong.Size = new System.Drawing.Size(589, 490);
            this.dgvTraphong.TabIndex = 0;
            this.dgvTraphong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraphong_CellContentClick);
            // 
            // Traphong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1016, 619);
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Traphong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traphong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Traphong_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpContent.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.tlpInputs.ResumeLayout(false);
            this.tlpInputs.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            this.tlpSearch.ResumeLayout(false);
            this.tlpSearch.PerformLayout();
            this.pnlGird.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraphong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.TableLayoutPanel tlpInputs;
        private System.Windows.Forms.Label lblMatraphong;
        private System.Windows.Forms.Label lblMasinhvien;
        private System.Windows.Forms.Label lblHoten;
        private System.Windows.Forms.Label lblKhunha;
        private System.Windows.Forms.Label lblPhongdango;
        private System.Windows.Forms.Label lblGiuong;
        private System.Windows.Forms.Label lblNgayvaoo;
        private System.Windows.Forms.Label lblNgaytraphong;
        private System.Windows.Forms.Label lblLydotra;
        private System.Windows.Forms.Label lblTrangthai;
        private System.Windows.Forms.Label lblGhichu;
        private System.Windows.Forms.TextBox txtmatraphong;
        private System.Windows.Forms.TextBox txtMsv;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.TextBox txtGhichu;
        private System.Windows.Forms.TextBox txtLydotra;
        private System.Windows.Forms.TextBox txtNgaytraphong;
        private System.Windows.Forms.TextBox txtNgayvaoo;
        private System.Windows.Forms.ComboBox cboKhunha;
        private System.Windows.Forms.ComboBox cboPhongdango;
        private System.Windows.Forms.ComboBox cboGiuong;
        private System.Windows.Forms.ComboBox cboTrangthai;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlGird;
        private System.Windows.Forms.DataGridView dgvTraphong;
    }
}