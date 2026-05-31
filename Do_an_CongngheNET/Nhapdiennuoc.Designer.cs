namespace Do_an_CongngheNET
{
    partial class Nhapdiennuoc
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
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInputs = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaphieu = new System.Windows.Forms.Label();
            this.txtMaphieu = new System.Windows.Forms.TextBox();
            this.lblKhunha = new System.Windows.Forms.Label();
            this.cboKhuNha = new System.Windows.Forms.ComboBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblThang = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.lblChisodiencu = new System.Windows.Forms.Label();
            this.txtChisodiencu = new System.Windows.Forms.TextBox();
            this.lblChisodienmoi = new System.Windows.Forms.Label();
            this.txtChisodienmoi = new System.Windows.Forms.TextBox();
            this.lblDientieuthu = new System.Windows.Forms.Label();
            this.txtDientieuthu = new System.Windows.Forms.TextBox();
            this.lblChisonuoccu = new System.Windows.Forms.Label();
            this.txtChisonuoccu = new System.Windows.Forms.TextBox();
            this.lblChisonuocmoi = new System.Windows.Forms.Label();
            this.txtChisonuocmoi = new System.Windows.Forms.TextBox();
            this.lblNuoctieuthu = new System.Windows.Forms.Label();
            this.txtNuoctieuthu = new System.Windows.Forms.TextBox();
            this.lblTiendien = new System.Windows.Forms.Label();
            this.txtTiendien = new System.Windows.Forms.TextBox();
            this.lblTiennuoc = new System.Windows.Forms.Label();
            this.txtTiennuoc = new System.Windows.Forms.TextBox();
            this.lblTongtien = new System.Windows.Forms.Label();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch1 = new System.Windows.Forms.TextBox();
            this.pnlGird = new System.Windows.Forms.Panel();
            this.dgvNhapdiennuoc = new System.Windows.Forms.DataGridView();
            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.tlpInputs.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.tlpSearch.SuspendLayout();
            this.pnlGird.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapdiennuoc)).BeginInit();
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
            this.tlpRoot.Size = new System.Drawing.Size(1118, 640);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(6, 6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1106, 54);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1106, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "NHẬP ĐIỆN NƯỜC";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpContent
            // 
            this.tlpContent.ColumnCount = 2;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpContent.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpContent.Controls.Add(this.tlpRight, 1, 0);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(6, 69);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 1;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Size = new System.Drawing.Size(1106, 565);
            this.tlpContent.TabIndex = 1;
            // 
            // tlpLeft
            // 
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.tlpInputs, 0, 0);
            this.tlpLeft.Controls.Add(this.tlpButtons, 0, 1);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(3, 3);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 2;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpLeft.Size = new System.Drawing.Size(436, 559);
            this.tlpLeft.TabIndex = 0;
            // 
            // tlpInputs
            // 
            this.tlpInputs.ColumnCount = 2;
            this.tlpInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInputs.Controls.Add(this.lblMaphieu, 0, 0);
            this.tlpInputs.Controls.Add(this.txtMaphieu, 1, 0);
            this.tlpInputs.Controls.Add(this.lblKhunha, 0, 1);
            this.tlpInputs.Controls.Add(this.cboKhuNha, 1, 1);
            this.tlpInputs.Controls.Add(this.lblPhong, 0, 2);
            this.tlpInputs.Controls.Add(this.cboPhong, 1, 2);
            this.tlpInputs.Controls.Add(this.lblThang, 0, 3);
            this.tlpInputs.Controls.Add(this.cboThang, 1, 3);
            this.tlpInputs.Controls.Add(this.lblNam, 0, 4);
            this.tlpInputs.Controls.Add(this.txtNam, 1, 4);
            this.tlpInputs.Controls.Add(this.lblChisodiencu, 0, 5);
            this.tlpInputs.Controls.Add(this.txtChisodiencu, 1, 5);
            this.tlpInputs.Controls.Add(this.lblChisodienmoi, 0, 6);
            this.tlpInputs.Controls.Add(this.txtChisodienmoi, 1, 6);
            this.tlpInputs.Controls.Add(this.lblDientieuthu, 0, 7);
            this.tlpInputs.Controls.Add(this.txtDientieuthu, 1, 7);
            this.tlpInputs.Controls.Add(this.lblChisonuoccu, 0, 8);
            this.tlpInputs.Controls.Add(this.txtChisonuoccu, 1, 8);
            this.tlpInputs.Controls.Add(this.lblChisonuocmoi, 0, 9);
            this.tlpInputs.Controls.Add(this.txtChisonuocmoi, 1, 9);
            this.tlpInputs.Controls.Add(this.lblNuoctieuthu, 0, 10);
            this.tlpInputs.Controls.Add(this.txtNuoctieuthu, 1, 10);
            this.tlpInputs.Controls.Add(this.lblTiendien, 0, 11);
            this.tlpInputs.Controls.Add(this.txtTiendien, 1, 11);
            this.tlpInputs.Controls.Add(this.lblTiennuoc, 0, 12);
            this.tlpInputs.Controls.Add(this.txtTiennuoc, 1, 12);
            this.tlpInputs.Controls.Add(this.lblTongtien, 0, 13);
            this.tlpInputs.Controls.Add(this.txtTongtien, 1, 13);
            this.tlpInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInputs.Location = new System.Drawing.Point(3, 3);
            this.tlpInputs.Name = "tlpInputs";
            this.tlpInputs.RowCount = 14;
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tlpInputs.Size = new System.Drawing.Size(430, 452);
            this.tlpInputs.TabIndex = 0;
            // 
            // lblMaphieu
            // 
            this.lblMaphieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaphieu.Location = new System.Drawing.Point(3, 0);
            this.lblMaphieu.Name = "lblMaphieu";
            this.lblMaphieu.Size = new System.Drawing.Size(154, 32);
            this.lblMaphieu.TabIndex = 0;
            this.lblMaphieu.Text = "Mã phiếu (*):";
            this.lblMaphieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaphieu
            // 
            this.txtMaphieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaphieu.Location = new System.Drawing.Point(163, 3);
            this.txtMaphieu.Name = "txtMaphieu";
            this.txtMaphieu.Size = new System.Drawing.Size(264, 30);
            this.txtMaphieu.TabIndex = 1;
            // 
            // lblKhunha
            // 
            this.lblKhunha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKhunha.Location = new System.Drawing.Point(3, 32);
            this.lblKhunha.Name = "lblKhunha";
            this.lblKhunha.Size = new System.Drawing.Size(154, 32);
            this.lblKhunha.TabIndex = 0;
            this.lblKhunha.Text = "Khu nhà:";
            this.lblKhunha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboKhuNha
            // 
            this.cboKhuNha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKhuNha.FormattingEnabled = true;
            this.cboKhuNha.Location = new System.Drawing.Point(163, 35);
            this.cboKhuNha.Name = "cboKhuNha";
            this.cboKhuNha.Size = new System.Drawing.Size(264, 33);
            this.cboKhuNha.TabIndex = 2;
            this.cboKhuNha.SelectedIndexChanged += new System.EventHandler(this.cboKhuNha_SelectedIndexChanged);
            this.cboKhuNha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKhuNha_KeyDown);
            // 
            // lblPhong
            // 
            this.lblPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhong.Location = new System.Drawing.Point(3, 64);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(154, 32);
            this.lblPhong.TabIndex = 0;
            this.lblPhong.Text = "Phòng (*):";
            this.lblPhong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPhong
            // 
            this.cboPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPhong.FormattingEnabled = true;
            this.cboPhong.Location = new System.Drawing.Point(163, 67);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(264, 33);
            this.cboPhong.TabIndex = 3;
            this.cboPhong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboPhong_KeyDown);
            // 
            // lblThang
            // 
            this.lblThang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThang.Location = new System.Drawing.Point(3, 96);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(154, 32);
            this.lblThang.TabIndex = 0;
            this.lblThang.Text = "Tháng (*):";
            this.lblThang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboThang
            // 
            this.cboThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(163, 99);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(264, 33);
            this.cboThang.TabIndex = 4;
            this.cboThang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboThang_KeyDown);
            // 
            // lblNam
            // 
            this.lblNam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNam.Location = new System.Drawing.Point(3, 128);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(154, 32);
            this.lblNam.TabIndex = 0;
            this.lblNam.Text = "Năm (*):";
            this.lblNam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNam
            // 
            this.txtNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNam.Location = new System.Drawing.Point(163, 131);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(264, 30);
            this.txtNam.TabIndex = 4;
            this.txtNam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNam_KeyDown);
            // 
            // lblChisodiencu
            // 
            this.lblChisodiencu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChisodiencu.Location = new System.Drawing.Point(3, 160);
            this.lblChisodiencu.Name = "lblChisodiencu";
            this.lblChisodiencu.Size = new System.Drawing.Size(154, 32);
            this.lblChisodiencu.TabIndex = 0;
            this.lblChisodiencu.Text = "CS điện cũ (*):";
            this.lblChisodiencu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChisodiencu
            // 
            this.txtChisodiencu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChisodiencu.Location = new System.Drawing.Point(163, 163);
            this.txtChisodiencu.Name = "txtChisodiencu";
            this.txtChisodiencu.Size = new System.Drawing.Size(264, 30);
            this.txtChisodiencu.TabIndex = 5;
            this.txtChisodiencu.TextChanged += new System.EventHandler(this.txtChisodiencu_TextChanged);
            this.txtChisodiencu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChisodiencu_KeyDown);
            // 
            // lblChisodienmoi
            // 
            this.lblChisodienmoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChisodienmoi.Location = new System.Drawing.Point(3, 192);
            this.lblChisodienmoi.Name = "lblChisodienmoi";
            this.lblChisodienmoi.Size = new System.Drawing.Size(154, 32);
            this.lblChisodienmoi.TabIndex = 0;
            this.lblChisodienmoi.Text = "CS điện mới (*):";
            this.lblChisodienmoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChisodienmoi
            // 
            this.txtChisodienmoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChisodienmoi.Location = new System.Drawing.Point(163, 195);
            this.txtChisodienmoi.Name = "txtChisodienmoi";
            this.txtChisodienmoi.Size = new System.Drawing.Size(264, 30);
            this.txtChisodienmoi.TabIndex = 6;
            this.txtChisodienmoi.TextChanged += new System.EventHandler(this.txtChisodienmoi_TextChanged);
            this.txtChisodienmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChisodienmoi_KeyDown);
            // 
            // lblDientieuthu
            // 
            this.lblDientieuthu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDientieuthu.Location = new System.Drawing.Point(3, 224);
            this.lblDientieuthu.Name = "lblDientieuthu";
            this.lblDientieuthu.Size = new System.Drawing.Size(154, 32);
            this.lblDientieuthu.TabIndex = 0;
            this.lblDientieuthu.Text = "Điện tiêu thụ:";
            this.lblDientieuthu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDientieuthu
            // 
            this.txtDientieuthu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDientieuthu.Location = new System.Drawing.Point(163, 227);
            this.txtDientieuthu.Name = "txtDientieuthu";
            this.txtDientieuthu.Size = new System.Drawing.Size(264, 30);
            this.txtDientieuthu.TabIndex = 7;
            // 
            // lblChisonuoccu
            // 
            this.lblChisonuoccu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChisonuoccu.Location = new System.Drawing.Point(3, 256);
            this.lblChisonuoccu.Name = "lblChisonuoccu";
            this.lblChisonuoccu.Size = new System.Drawing.Size(154, 32);
            this.lblChisonuoccu.TabIndex = 0;
            this.lblChisonuoccu.Text = "CS nước cũ (*):";
            this.lblChisonuoccu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChisonuoccu
            // 
            this.txtChisonuoccu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChisonuoccu.Location = new System.Drawing.Point(163, 259);
            this.txtChisonuoccu.Name = "txtChisonuoccu";
            this.txtChisonuoccu.Size = new System.Drawing.Size(264, 30);
            this.txtChisonuoccu.TabIndex = 8;
            this.txtChisonuoccu.TextChanged += new System.EventHandler(this.txtChisonuoccu_TextChanged);
            this.txtChisonuoccu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChisonuoccu_KeyDown);
            // 
            // lblChisonuocmoi
            // 
            this.lblChisonuocmoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChisonuocmoi.Location = new System.Drawing.Point(3, 288);
            this.lblChisonuocmoi.Name = "lblChisonuocmoi";
            this.lblChisonuocmoi.Size = new System.Drawing.Size(154, 32);
            this.lblChisonuocmoi.TabIndex = 0;
            this.lblChisonuocmoi.Text = "CS nước mới (*):";
            this.lblChisonuocmoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChisonuocmoi
            // 
            this.txtChisonuocmoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChisonuocmoi.Location = new System.Drawing.Point(163, 291);
            this.txtChisonuocmoi.Name = "txtChisonuocmoi";
            this.txtChisonuocmoi.Size = new System.Drawing.Size(264, 30);
            this.txtChisonuocmoi.TabIndex = 9;
            this.txtChisonuocmoi.TextChanged += new System.EventHandler(this.txtChisonuocmoi_TextChanged);
            this.txtChisonuocmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChisonuocmoi_KeyDown);
            // 
            // lblNuoctieuthu
            // 
            this.lblNuoctieuthu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNuoctieuthu.Location = new System.Drawing.Point(3, 320);
            this.lblNuoctieuthu.Name = "lblNuoctieuthu";
            this.lblNuoctieuthu.Size = new System.Drawing.Size(154, 32);
            this.lblNuoctieuthu.TabIndex = 0;
            this.lblNuoctieuthu.Text = "Nước tiêu thụ:";
            this.lblNuoctieuthu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNuoctieuthu
            // 
            this.txtNuoctieuthu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNuoctieuthu.Location = new System.Drawing.Point(163, 323);
            this.txtNuoctieuthu.Name = "txtNuoctieuthu";
            this.txtNuoctieuthu.Size = new System.Drawing.Size(264, 30);
            this.txtNuoctieuthu.TabIndex = 10;
            // 
            // lblTiendien
            // 
            this.lblTiendien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiendien.Location = new System.Drawing.Point(3, 352);
            this.lblTiendien.Name = "lblTiendien";
            this.lblTiendien.Size = new System.Drawing.Size(154, 32);
            this.lblTiendien.TabIndex = 0;
            this.lblTiendien.Text = "Tiền điện (*):";
            this.lblTiendien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTiendien
            // 
            this.txtTiendien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTiendien.Location = new System.Drawing.Point(163, 355);
            this.txtTiendien.Name = "txtTiendien";
            this.txtTiendien.Size = new System.Drawing.Size(264, 30);
            this.txtTiendien.TabIndex = 11;
            this.txtTiendien.TextChanged += new System.EventHandler(this.txtTiendien_TextChanged);
            this.txtTiendien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTiendien_KeyDown);
            // 
            // lblTiennuoc
            // 
            this.lblTiennuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiennuoc.Location = new System.Drawing.Point(3, 384);
            this.lblTiennuoc.Name = "lblTiennuoc";
            this.lblTiennuoc.Size = new System.Drawing.Size(154, 32);
            this.lblTiennuoc.TabIndex = 0;
            this.lblTiennuoc.Text = "Tiền nước (*):";
            this.lblTiennuoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTiennuoc
            // 
            this.txtTiennuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTiennuoc.Location = new System.Drawing.Point(163, 387);
            this.txtTiennuoc.Name = "txtTiennuoc";
            this.txtTiennuoc.Size = new System.Drawing.Size(264, 30);
            this.txtTiennuoc.TabIndex = 12;
            this.txtTiennuoc.TextChanged += new System.EventHandler(this.txtTiennuoc_TextChanged);
            this.txtTiennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTiennuoc_KeyDown);
            // 
            // lblTongtien
            // 
            this.lblTongtien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongtien.Location = new System.Drawing.Point(3, 416);
            this.lblTongtien.Name = "lblTongtien";
            this.lblTongtien.Size = new System.Drawing.Size(154, 36);
            this.lblTongtien.TabIndex = 0;
            this.lblTongtien.Text = "Tổng tiền:";
            this.lblTongtien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTongtien
            // 
            this.txtTongtien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTongtien.Location = new System.Drawing.Point(163, 419);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.Size = new System.Drawing.Size(264, 30);
            this.txtTongtien.TabIndex = 13;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 3;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpButtons.Controls.Add(this.btnNew, 0, 0);
            this.tlpButtons.Controls.Add(this.btnEdit, 1, 0);
            this.tlpButtons.Controls.Add(this.btnDelete, 2, 0);
            this.tlpButtons.Controls.Add(this.btnSave, 0, 1);
            this.tlpButtons.Controls.Add(this.btnCancel, 1, 1);
            this.tlpButtons.Controls.Add(this.btnClose, 2, 1);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(3, 461);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 2;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Size = new System.Drawing.Size(430, 95);
            this.tlpButtons.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(137, 41);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "select";
            this.btnNew.Text = "Thêm mới";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEdit.Location = new System.Drawing.Point(146, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(137, 41);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "select";
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDelete.Location = new System.Drawing.Point(289, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(138, 41);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "select";
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(3, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 42);
            this.btnSave.TabIndex = 3;
            this.btnSave.Tag = "confirm";
            this.btnSave.Text = "Ghi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancel.Location = new System.Drawing.Point(146, 50);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(137, 42);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Tag = "confirm";
            this.btnCancel.Text = "Hủy ghi";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnClose.Location = new System.Drawing.Point(289, 50);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 42);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Kết thúc";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.tlpSearch, 0, 0);
            this.tlpRight.Controls.Add(this.pnlGird, 0, 1);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(445, 3);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 2;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Size = new System.Drawing.Size(658, 559);
            this.tlpRight.TabIndex = 1;
            // 
            // tlpSearch
            // 
            this.tlpSearch.ColumnCount = 2;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Controls.Add(this.lblSearch, 0, 0);
            this.tlpSearch.Controls.Add(this.txtSearch1, 1, 0);
            this.tlpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tlpSearch.Location = new System.Drawing.Point(3, 3);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.RowCount = 1;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Size = new System.Drawing.Size(652, 44);
            this.tlpSearch.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearch.Location = new System.Drawing.Point(3, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(97, 44);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm:";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch1
            // 
            this.txtSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch1.Location = new System.Drawing.Point(106, 3);
            this.txtSearch1.Name = "txtSearch1";
            this.txtSearch1.Size = new System.Drawing.Size(543, 30);
            this.txtSearch1.TabIndex = 1;
            this.txtSearch1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch1_KeyDown);
            // 
            // pnlGird
            // 
            this.pnlGird.Controls.Add(this.dgvNhapdiennuoc);
            this.pnlGird.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGird.Location = new System.Drawing.Point(3, 53);
            this.pnlGird.Name = "pnlGird";
            this.pnlGird.Size = new System.Drawing.Size(652, 503);
            this.pnlGird.TabIndex = 1;
            // 
            // dgvNhapdiennuoc
            // 
            this.dgvNhapdiennuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhapdiennuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhapdiennuoc.Location = new System.Drawing.Point(0, 0);
            this.dgvNhapdiennuoc.Name = "dgvNhapdiennuoc";
            this.dgvNhapdiennuoc.RowHeadersWidth = 51;
            this.dgvNhapdiennuoc.RowTemplate.Height = 24;
            this.dgvNhapdiennuoc.Size = new System.Drawing.Size(652, 503);
            this.dgvNhapdiennuoc.TabIndex = 0;
            this.dgvNhapdiennuoc.SelectionChanged += new System.EventHandler(this.dgvNhapdiennuoc_SelectionChanged);
            // 
            // Nhapdiennuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 640);
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Nhapdiennuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhapdiennuoc";
            this.Load += new System.EventHandler(this.Nhapdiennuoc_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.tlpContent.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.tlpInputs.ResumeLayout(false);
            this.tlpInputs.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            this.tlpSearch.ResumeLayout(false);
            this.tlpSearch.PerformLayout();
            this.pnlGird.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapdiennuoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.TableLayoutPanel tlpInputs;
        private System.Windows.Forms.Label lblMaphieu;
        private System.Windows.Forms.Label lblKhunha;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Label lblChisodiencu;
        private System.Windows.Forms.Label lblChisodienmoi;
        private System.Windows.Forms.Label lblDientieuthu;
        private System.Windows.Forms.Label lblChisonuoccu;
        private System.Windows.Forms.Label lblChisonuocmoi;
        private System.Windows.Forms.Label lblNuoctieuthu;
        private System.Windows.Forms.Label lblTiendien;
        private System.Windows.Forms.Label lblTiennuoc;
        private System.Windows.Forms.Label lblTongtien;
        private System.Windows.Forms.TextBox txtMaphieu;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.TextBox txtChisodiencu;
        private System.Windows.Forms.TextBox txtChisodienmoi;
        private System.Windows.Forms.TextBox txtDientieuthu;
        private System.Windows.Forms.TextBox txtChisonuoccu;
        private System.Windows.Forms.TextBox txtChisonuocmoi;
        private System.Windows.Forms.TextBox txtNuoctieuthu;
        private System.Windows.Forms.TextBox txtTiendien;
        private System.Windows.Forms.TextBox txtTiennuoc;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.ComboBox cboKhuNha;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch1;
        private System.Windows.Forms.Panel pnlGird;
        private System.Windows.Forms.DataGridView dgvNhapdiennuoc;
    }
}