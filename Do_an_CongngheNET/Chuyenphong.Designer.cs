namespace Do_an_CongngheNET
{
    partial class Chuyenphong
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
            this.tblLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeft1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMachuyenphong = new System.Windows.Forms.Label();
            this.txtMachuyenphong = new System.Windows.Forms.TextBox();
            this.lblMasinhvien = new System.Windows.Forms.Label();
            this.lblHoten = new System.Windows.Forms.Label();
            this.lblPhonghientai = new System.Windows.Forms.Label();
            this.lblKhuhientai = new System.Windows.Forms.Label();
            this.lblPhongmoi = new System.Windows.Forms.Label();
            this.lblKhumoi = new System.Windows.Forms.Label();
            this.lblNgaychuyen = new System.Windows.Forms.Label();
            this.lblLydochuyen = new System.Windows.Forms.Label();
            this.lblTrangthai = new System.Windows.Forms.Label();
            this.lblGhichu = new System.Windows.Forms.Label();
            this.txtMasinhvien = new System.Windows.Forms.TextBox();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.txtNgaychuyen = new System.Windows.Forms.TextBox();
            this.txtLydochuyen = new System.Windows.Forms.TextBox();
            this.txtGhichu = new System.Windows.Forms.TextBox();
            this.cboPhonghientai = new System.Windows.Forms.ComboBox();
            this.cboKhuhientai = new System.Windows.Forms.ComboBox();
            this.cboPhongmoi = new System.Windows.Forms.ComboBox();
            this.cboKhumoi = new System.Windows.Forms.ComboBox();
            this.cboTrangthai = new System.Windows.Forms.ComboBox();
            this.tlpLeft2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimkiem = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvChuyenphong = new System.Windows.Forms.DataGridView();
            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.tblLeft.SuspendLayout();
            this.tlpLeft1.SuspendLayout();
            this.tlpLeft2.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.tlpSearch.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenphong)).BeginInit();
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
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(1118, 540);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(6, 6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1106, 44);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1106, 44);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHUYỂN PHÒNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click_1);
            // 
            // tlpContent
            // 
            this.tlpContent.ColumnCount = 2;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.09589F));
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.90411F));
            this.tlpContent.Controls.Add(this.tblLeft, 0, 0);
            this.tlpContent.Controls.Add(this.tlpRight, 1, 0);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(6, 59);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 1;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Size = new System.Drawing.Size(1106, 475);
            this.tlpContent.TabIndex = 1;
            // 
            // tblLeft
            // 
            this.tblLeft.ColumnCount = 1;
            this.tblLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLeft.Controls.Add(this.tlpLeft1, 0, 0);
            this.tblLeft.Controls.Add(this.tlpLeft2, 0, 1);
            this.tblLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLeft.Location = new System.Drawing.Point(3, 3);
            this.tblLeft.Name = "tblLeft";
            this.tblLeft.RowCount = 2;
            this.tblLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.56266F));
            this.tblLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.43734F));
            this.tblLeft.Size = new System.Drawing.Size(448, 469);
            this.tblLeft.TabIndex = 0;
            this.tblLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.tblLeft_Paint);
            // 
            // tlpLeft1
            // 
            this.tlpLeft1.ColumnCount = 2;
            this.tlpLeft1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpLeft1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft1.Controls.Add(this.lblMachuyenphong, 0, 0);
            this.tlpLeft1.Controls.Add(this.txtMachuyenphong, 1, 0);
            this.tlpLeft1.Controls.Add(this.lblMasinhvien, 0, 1);
            this.tlpLeft1.Controls.Add(this.lblHoten, 0, 2);
            this.tlpLeft1.Controls.Add(this.lblPhonghientai, 0, 3);
            this.tlpLeft1.Controls.Add(this.lblKhuhientai, 0, 4);
            this.tlpLeft1.Controls.Add(this.lblPhongmoi, 0, 5);
            this.tlpLeft1.Controls.Add(this.lblKhumoi, 0, 6);
            this.tlpLeft1.Controls.Add(this.lblNgaychuyen, 0, 7);
            this.tlpLeft1.Controls.Add(this.lblLydochuyen, 0, 8);
            this.tlpLeft1.Controls.Add(this.lblTrangthai, 0, 9);
            this.tlpLeft1.Controls.Add(this.lblGhichu, 0, 10);
            this.tlpLeft1.Controls.Add(this.txtMasinhvien, 1, 1);
            this.tlpLeft1.Controls.Add(this.txtHoten, 1, 2);
            this.tlpLeft1.Controls.Add(this.txtNgaychuyen, 1, 7);
            this.tlpLeft1.Controls.Add(this.txtLydochuyen, 1, 8);
            this.tlpLeft1.Controls.Add(this.txtGhichu, 1, 10);
            this.tlpLeft1.Controls.Add(this.cboPhonghientai, 1, 3);
            this.tlpLeft1.Controls.Add(this.cboKhuhientai, 1, 4);
            this.tlpLeft1.Controls.Add(this.cboPhongmoi, 1, 5);
            this.tlpLeft1.Controls.Add(this.cboKhumoi, 1, 6);
            this.tlpLeft1.Controls.Add(this.cboTrangthai, 1, 9);
            this.tlpLeft1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft1.Location = new System.Drawing.Point(3, 3);
            this.tlpLeft1.Name = "tlpLeft1";
            this.tlpLeft1.RowCount = 11;
            this.tlpLeft1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpLeft1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpLeft1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpLeft1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpLeft1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpLeft1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpLeft1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpLeft1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpLeft1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpLeft1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpLeft1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpLeft1.Size = new System.Drawing.Size(442, 371);
            this.tlpLeft1.TabIndex = 0;
            // 
            // lblMachuyenphong
            // 
            this.lblMachuyenphong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMachuyenphong.Location = new System.Drawing.Point(3, 0);
            this.lblMachuyenphong.Name = "lblMachuyenphong";
            this.lblMachuyenphong.Size = new System.Drawing.Size(154, 33);
            this.lblMachuyenphong.TabIndex = 0;
            this.lblMachuyenphong.Text = "Mã chuyển phòng:";
            this.lblMachuyenphong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMachuyenphong
            // 
            this.txtMachuyenphong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMachuyenphong.Location = new System.Drawing.Point(163, 3);
            this.txtMachuyenphong.Name = "txtMachuyenphong";
            this.txtMachuyenphong.Size = new System.Drawing.Size(276, 30);
            this.txtMachuyenphong.TabIndex = 1;
            // 
            // lblMasinhvien
            // 
            this.lblMasinhvien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMasinhvien.Location = new System.Drawing.Point(3, 33);
            this.lblMasinhvien.Name = "lblMasinhvien";
            this.lblMasinhvien.Size = new System.Drawing.Size(154, 33);
            this.lblMasinhvien.TabIndex = 0;
            this.lblMasinhvien.Text = "Mã sinh viên (*):";
            this.lblMasinhvien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHoten
            // 
            this.lblHoten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHoten.Location = new System.Drawing.Point(3, 66);
            this.lblHoten.Name = "lblHoten";
            this.lblHoten.Size = new System.Drawing.Size(154, 33);
            this.lblHoten.TabIndex = 0;
            this.lblHoten.Text = "Họ tên:";
            this.lblHoten.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPhonghientai
            // 
            this.lblPhonghientai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhonghientai.Location = new System.Drawing.Point(3, 99);
            this.lblPhonghientai.Name = "lblPhonghientai";
            this.lblPhonghientai.Size = new System.Drawing.Size(154, 33);
            this.lblPhonghientai.TabIndex = 0;
            this.lblPhonghientai.Text = "Phòng hiện tại:";
            this.lblPhonghientai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKhuhientai
            // 
            this.lblKhuhientai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKhuhientai.Location = new System.Drawing.Point(3, 132);
            this.lblKhuhientai.Name = "lblKhuhientai";
            this.lblKhuhientai.Size = new System.Drawing.Size(154, 33);
            this.lblKhuhientai.TabIndex = 0;
            this.lblKhuhientai.Text = "Khu hiện tại:";
            this.lblKhuhientai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPhongmoi
            // 
            this.lblPhongmoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhongmoi.Location = new System.Drawing.Point(3, 165);
            this.lblPhongmoi.Name = "lblPhongmoi";
            this.lblPhongmoi.Size = new System.Drawing.Size(154, 33);
            this.lblPhongmoi.TabIndex = 0;
            this.lblPhongmoi.Text = "Phòng mới:";
            this.lblPhongmoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPhongmoi.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblKhumoi
            // 
            this.lblKhumoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKhumoi.Location = new System.Drawing.Point(3, 198);
            this.lblKhumoi.Name = "lblKhumoi";
            this.lblKhumoi.Size = new System.Drawing.Size(154, 33);
            this.lblKhumoi.TabIndex = 0;
            this.lblKhumoi.Text = "Khu mới:";
            this.lblKhumoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgaychuyen
            // 
            this.lblNgaychuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNgaychuyen.Location = new System.Drawing.Point(3, 231);
            this.lblNgaychuyen.Name = "lblNgaychuyen";
            this.lblNgaychuyen.Size = new System.Drawing.Size(154, 33);
            this.lblNgaychuyen.TabIndex = 0;
            this.lblNgaychuyen.Text = "Ngày chuyển:";
            this.lblNgaychuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNgaychuyen.Click += new System.EventHandler(this.label8_Click);
            // 
            // lblLydochuyen
            // 
            this.lblLydochuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLydochuyen.Location = new System.Drawing.Point(3, 264);
            this.lblLydochuyen.Name = "lblLydochuyen";
            this.lblLydochuyen.Size = new System.Drawing.Size(154, 33);
            this.lblLydochuyen.TabIndex = 0;
            this.lblLydochuyen.Text = "Lý do chuyển:";
            this.lblLydochuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrangthai
            // 
            this.lblTrangthai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrangthai.Location = new System.Drawing.Point(3, 297);
            this.lblTrangthai.Name = "lblTrangthai";
            this.lblTrangthai.Size = new System.Drawing.Size(154, 33);
            this.lblTrangthai.TabIndex = 0;
            this.lblTrangthai.Text = "Trạng thái:";
            this.lblTrangthai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGhichu
            // 
            this.lblGhichu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGhichu.Location = new System.Drawing.Point(3, 330);
            this.lblGhichu.Name = "lblGhichu";
            this.lblGhichu.Size = new System.Drawing.Size(154, 41);
            this.lblGhichu.TabIndex = 0;
            this.lblGhichu.Text = "Ghi chú:";
            this.lblGhichu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMasinhvien
            // 
            this.txtMasinhvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMasinhvien.Location = new System.Drawing.Point(163, 36);
            this.txtMasinhvien.Name = "txtMasinhvien";
            this.txtMasinhvien.Size = new System.Drawing.Size(276, 30);
            this.txtMasinhvien.TabIndex = 1;
            this.txtMasinhvien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMasinhvien_KeyDown);
            // 
            // txtHoten
            // 
            this.txtHoten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHoten.Location = new System.Drawing.Point(163, 69);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(276, 30);
            this.txtHoten.TabIndex = 1;
            // 
            // txtNgaychuyen
            // 
            this.txtNgaychuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgaychuyen.Location = new System.Drawing.Point(163, 234);
            this.txtNgaychuyen.Name = "txtNgaychuyen";
            this.txtNgaychuyen.Size = new System.Drawing.Size(276, 30);
            this.txtNgaychuyen.TabIndex = 1;
            this.txtNgaychuyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgaychuyen_KeyDown);
            // 
            // txtLydochuyen
            // 
            this.txtLydochuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLydochuyen.Location = new System.Drawing.Point(163, 267);
            this.txtLydochuyen.Name = "txtLydochuyen";
            this.txtLydochuyen.Size = new System.Drawing.Size(276, 30);
            this.txtLydochuyen.TabIndex = 1;
            this.txtLydochuyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLydochuyen_KeyDown);
            // 
            // txtGhichu
            // 
            this.txtGhichu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhichu.Location = new System.Drawing.Point(163, 333);
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Size = new System.Drawing.Size(276, 30);
            this.txtGhichu.TabIndex = 1;
            this.txtGhichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhichu_KeyDown);
            // 
            // cboPhonghientai
            // 
            this.cboPhonghientai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPhonghientai.FormattingEnabled = true;
            this.cboPhonghientai.Location = new System.Drawing.Point(163, 102);
            this.cboPhonghientai.Name = "cboPhonghientai";
            this.cboPhonghientai.Size = new System.Drawing.Size(276, 33);
            this.cboPhonghientai.TabIndex = 2;
            this.cboPhonghientai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboPhonghientai_KeyDown);
            // 
            // cboKhuhientai
            // 
            this.cboKhuhientai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKhuhientai.FormattingEnabled = true;
            this.cboKhuhientai.Location = new System.Drawing.Point(163, 135);
            this.cboKhuhientai.Name = "cboKhuhientai";
            this.cboKhuhientai.Size = new System.Drawing.Size(276, 33);
            this.cboKhuhientai.TabIndex = 2;
            this.cboKhuhientai.SelectedIndexChanged += new System.EventHandler(this.cboKhuhientai_SelectedIndexChanged);
            this.cboKhuhientai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKhuhientai_KeyDown);
            // 
            // cboPhongmoi
            // 
            this.cboPhongmoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPhongmoi.FormattingEnabled = true;
            this.cboPhongmoi.Location = new System.Drawing.Point(163, 168);
            this.cboPhongmoi.Name = "cboPhongmoi";
            this.cboPhongmoi.Size = new System.Drawing.Size(276, 33);
            this.cboPhongmoi.TabIndex = 2;
            this.cboPhongmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboPhongmoi_KeyDown);
            // 
            // cboKhumoi
            // 
            this.cboKhumoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKhumoi.FormattingEnabled = true;
            this.cboKhumoi.Location = new System.Drawing.Point(163, 201);
            this.cboKhumoi.Name = "cboKhumoi";
            this.cboKhumoi.Size = new System.Drawing.Size(276, 33);
            this.cboKhumoi.TabIndex = 2;
            this.cboKhumoi.SelectedIndexChanged += new System.EventHandler(this.cboKhumoi_SelectedIndexChanged);
            this.cboKhumoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKhumoi_KeyDown);
            // 
            // cboTrangthai
            // 
            this.cboTrangthai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTrangthai.FormattingEnabled = true;
            this.cboTrangthai.Location = new System.Drawing.Point(163, 300);
            this.cboTrangthai.Name = "cboTrangthai";
            this.cboTrangthai.Size = new System.Drawing.Size(276, 33);
            this.cboTrangthai.TabIndex = 2;
            this.cboTrangthai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboTrangthai_KeyDown);
            // 
            // tlpLeft2
            // 
            this.tlpLeft2.ColumnCount = 3;
            this.tlpLeft2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpLeft2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpLeft2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpLeft2.Controls.Add(this.btnNew, 0, 0);
            this.tlpLeft2.Controls.Add(this.btnSave, 0, 1);
            this.tlpLeft2.Controls.Add(this.btnEdit, 1, 0);
            this.tlpLeft2.Controls.Add(this.btnCancel, 1, 1);
            this.tlpLeft2.Controls.Add(this.btnDelete, 2, 0);
            this.tlpLeft2.Controls.Add(this.btnClose, 2, 1);
            this.tlpLeft2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft2.Location = new System.Drawing.Point(3, 380);
            this.tlpLeft2.Name = "tlpLeft2";
            this.tlpLeft2.RowCount = 2;
            this.tlpLeft2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLeft2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLeft2.Size = new System.Drawing.Size(442, 86);
            this.tlpLeft2.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(139, 37);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "select";
            this.btnNew.Text = "Thêm mới";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(3, 46);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 37);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "confirm";
            this.btnSave.Text = "Ghi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Location = new System.Drawing.Point(148, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(139, 37);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "select";
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(148, 46);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 37);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Tag = "confirm";
            this.btnCancel.Text = "Hủy ghi";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(293, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(146, 37);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Tag = "select";
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(293, 46);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(146, 37);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Kết thúc";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRight.Controls.Add(this.tlpSearch, 0, 0);
            this.tlpRight.Controls.Add(this.pnlGrid, 0, 1);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(457, 3);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 2;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.533074F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.46693F));
            this.tlpRight.Size = new System.Drawing.Size(646, 469);
            this.tlpRight.TabIndex = 1;
            // 
            // tlpSearch
            // 
            this.tlpSearch.ColumnCount = 2;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Controls.Add(this.lblTimkiem, 0, 0);
            this.tlpSearch.Controls.Add(this.txtSearch, 1, 0);
            this.tlpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearch.Location = new System.Drawing.Point(3, 3);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.RowCount = 1;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Size = new System.Drawing.Size(640, 38);
            this.tlpSearch.TabIndex = 0;
            // 
            // lblTimkiem
            // 
            this.lblTimkiem.AutoSize = true;
            this.lblTimkiem.Location = new System.Drawing.Point(3, 0);
            this.lblTimkiem.Name = "lblTimkiem";
            this.lblTimkiem.Size = new System.Drawing.Size(97, 25);
            this.lblTimkiem.TabIndex = 0;
            this.lblTimkiem.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(106, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(531, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvChuyenphong);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(3, 47);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(640, 419);
            this.pnlGrid.TabIndex = 1;
            // 
            // dgvChuyenphong
            // 
            this.dgvChuyenphong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChuyenphong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChuyenphong.Location = new System.Drawing.Point(0, 0);
            this.dgvChuyenphong.Name = "dgvChuyenphong";
            this.dgvChuyenphong.RowHeadersWidth = 51;
            this.dgvChuyenphong.RowTemplate.Height = 24;
            this.dgvChuyenphong.Size = new System.Drawing.Size(640, 419);
            this.dgvChuyenphong.TabIndex = 0;
            this.dgvChuyenphong.SelectionChanged += new System.EventHandler(this.dgvChuyenphong_SelectionChanged);
            // 
            // Chuyenphong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 540);
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Chuyenphong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyenphong";
            this.Load += new System.EventHandler(this.Chuyenphong_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.tlpContent.ResumeLayout(false);
            this.tblLeft.ResumeLayout(false);
            this.tlpLeft1.ResumeLayout(false);
            this.tlpLeft1.PerformLayout();
            this.tlpLeft2.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            this.tlpSearch.ResumeLayout(false);
            this.tlpSearch.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenphong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.TableLayoutPanel tblLeft;
        private System.Windows.Forms.TableLayoutPanel tlpLeft1;
        private System.Windows.Forms.Label lblMachuyenphong;
        private System.Windows.Forms.TextBox txtMachuyenphong;
        private System.Windows.Forms.Label lblMasinhvien;
        private System.Windows.Forms.Label lblHoten;
        private System.Windows.Forms.Label lblPhonghientai;
        private System.Windows.Forms.Label lblKhuhientai;
        private System.Windows.Forms.Label lblPhongmoi;
        private System.Windows.Forms.Label lblKhumoi;
        private System.Windows.Forms.Label lblNgaychuyen;
        private System.Windows.Forms.Label lblLydochuyen;
        private System.Windows.Forms.Label lblTrangthai;
        private System.Windows.Forms.Label lblGhichu;
        private System.Windows.Forms.TextBox txtMasinhvien;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.TextBox txtNgaychuyen;
        private System.Windows.Forms.TextBox txtLydochuyen;
        private System.Windows.Forms.TextBox txtGhichu;
        private System.Windows.Forms.ComboBox cboPhonghientai;
        private System.Windows.Forms.ComboBox cboKhuhientai;
        private System.Windows.Forms.ComboBox cboPhongmoi;
        private System.Windows.Forms.ComboBox cboKhumoi;
        private System.Windows.Forms.ComboBox cboTrangthai;
        private System.Windows.Forms.TableLayoutPanel tlpLeft2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.Label lblTimkiem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvChuyenphong;
    }
}