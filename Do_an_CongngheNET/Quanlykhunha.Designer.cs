namespace Do_an_CongngheNET
{
    partial class Quanlykhunha
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
            this.components = new System.ComponentModel.Container();
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tlplnputs = new System.Windows.Forms.TableLayoutPanel();
            this.lblMakhu = new System.Windows.Forms.Label();
            this.txtMakhu = new System.Windows.Forms.TextBox();
            this.lblTenkhu = new System.Windows.Forms.Label();
            this.txtTenkhu = new System.Windows.Forms.TextBox();
            this.lblLoaikhu = new System.Windows.Forms.Label();
            this.cboLoaikhu = new System.Windows.Forms.ComboBox();
            this.lblSotang = new System.Windows.Forms.Label();
            this.txtSotang = new System.Windows.Forms.TextBox();
            this.lblTongsophong = new System.Windows.Forms.Label();
            this.txtTongsophong = new System.Windows.Forms.TextBox();
            this.lblTrangthai = new System.Windows.Forms.Label();
            this.cboTrangthai = new System.Windows.Forms.ComboBox();
            this.lblGhichu = new System.Windows.Forms.Label();
            this.txtGhichu = new System.Windows.Forms.TextBox();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlpRinght = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimkiem = new System.Windows.Forms.Label();
            this.txtTimkiemkhu = new System.Windows.Forms.TextBox();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvQuanlykhunha = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.tlplnputs.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tlpRinght.SuspendLayout();
            this.tlpSearch.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanlykhunha)).BeginInit();
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
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(1064, 583);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(6, 6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1052, 51);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(410, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(284, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ KHU NHÀ";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // tlpContent
            // 
            this.tlpContent.ColumnCount = 2;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpContent.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpContent.Controls.Add(this.tlpRinght, 1, 0);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(6, 66);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 1;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Size = new System.Drawing.Size(1052, 511);
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
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.57F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.43F));
            this.tlpLeft.Size = new System.Drawing.Size(414, 505);
            this.tlpLeft.TabIndex = 0;
            // 
            // tlplnputs
            // 
            this.tlplnputs.ColumnCount = 2;
            this.tlplnputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlplnputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlplnputs.Controls.Add(this.lblMakhu, 0, 0);
            this.tlplnputs.Controls.Add(this.txtMakhu, 1, 0);
            this.tlplnputs.Controls.Add(this.lblTenkhu, 0, 1);
            this.tlplnputs.Controls.Add(this.txtTenkhu, 1, 1);
            this.tlplnputs.Controls.Add(this.lblLoaikhu, 0, 2);
            this.tlplnputs.Controls.Add(this.cboLoaikhu, 1, 2);
            this.tlplnputs.Controls.Add(this.lblSotang, 0, 3);
            this.tlplnputs.Controls.Add(this.txtSotang, 1, 3);
            this.tlplnputs.Controls.Add(this.lblTongsophong, 0, 4);
            this.tlplnputs.Controls.Add(this.txtTongsophong, 1, 4);
            this.tlplnputs.Controls.Add(this.lblTrangthai, 0, 5);
            this.tlplnputs.Controls.Add(this.cboTrangthai, 1, 5);
            this.tlplnputs.Controls.Add(this.lblGhichu, 0, 6);
            this.tlplnputs.Controls.Add(this.txtGhichu, 1, 6);
            this.tlplnputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlplnputs.Location = new System.Drawing.Point(3, 3);
            this.tlplnputs.Name = "tlplnputs";
            this.tlplnputs.RowCount = 7;
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.29F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.29F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.29F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.29F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.29F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.29F));
            this.tlplnputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.29F));
            this.tlplnputs.Size = new System.Drawing.Size(408, 400);
            this.tlplnputs.TabIndex = 0;
            // 
            // lblMakhu
            // 
            this.lblMakhu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMakhu.AutoSize = true;
            this.lblMakhu.Location = new System.Drawing.Point(23, 16);
            this.lblMakhu.Name = "lblMakhu";
            this.lblMakhu.Size = new System.Drawing.Size(110, 25);
            this.lblMakhu.TabIndex = 0;
            this.lblMakhu.Text = "Mã khu (*):";
            this.lblMakhu.Click += new System.EventHandler(this.lblMakhu_Click);
            // 
            // txtMakhu
            // 
            this.txtMakhu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMakhu.Location = new System.Drawing.Point(159, 13);
            this.txtMakhu.Name = "txtMakhu";
            this.txtMakhu.Size = new System.Drawing.Size(246, 30);
            this.txtMakhu.TabIndex = 1;
            this.txtMakhu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMakhu_KeyDown);
            // 
            // lblTenkhu
            // 
            this.lblTenkhu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTenkhu.AutoSize = true;
            this.lblTenkhu.Location = new System.Drawing.Point(33, 73);
            this.lblTenkhu.Name = "lblTenkhu";
            this.lblTenkhu.Size = new System.Drawing.Size(90, 25);
            this.lblTenkhu.TabIndex = 0;
            this.lblTenkhu.Text = "Tên khu:";
            // 
            // txtTenkhu
            // 
            this.txtTenkhu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenkhu.Location = new System.Drawing.Point(159, 70);
            this.txtTenkhu.Name = "txtTenkhu";
            this.txtTenkhu.Size = new System.Drawing.Size(246, 30);
            this.txtTenkhu.TabIndex = 2;
            this.txtTenkhu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenkhu_KeyDown);
            // 
            // lblLoaikhu
            // 
            this.lblLoaikhu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoaikhu.AutoSize = true;
            this.lblLoaikhu.Location = new System.Drawing.Point(32, 130);
            this.lblLoaikhu.Name = "lblLoaikhu";
            this.lblLoaikhu.Size = new System.Drawing.Size(92, 25);
            this.lblLoaikhu.TabIndex = 0;
            this.lblLoaikhu.Text = "Loại khu:";
            // 
            // cboLoaikhu
            // 
            this.cboLoaikhu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLoaikhu.FormattingEnabled = true;
            this.cboLoaikhu.Location = new System.Drawing.Point(159, 126);
            this.cboLoaikhu.Name = "cboLoaikhu";
            this.cboLoaikhu.Size = new System.Drawing.Size(246, 33);
            this.cboLoaikhu.TabIndex = 3;
            this.cboLoaikhu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboLoaikhu_KeyDown);
            // 
            // lblSotang
            // 
            this.lblSotang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSotang.AutoSize = true;
            this.lblSotang.Location = new System.Drawing.Point(35, 187);
            this.lblSotang.Name = "lblSotang";
            this.lblSotang.Size = new System.Drawing.Size(86, 25);
            this.lblSotang.TabIndex = 0;
            this.lblSotang.Text = "Số tầng:";
            // 
            // txtSotang
            // 
            this.txtSotang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSotang.Location = new System.Drawing.Point(159, 184);
            this.txtSotang.Name = "txtSotang";
            this.txtSotang.Size = new System.Drawing.Size(246, 30);
            this.txtSotang.TabIndex = 4;
            this.txtSotang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSotang_KeyDown);
            // 
            // lblTongsophong
            // 
            this.lblTongsophong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTongsophong.AutoSize = true;
            this.lblTongsophong.Location = new System.Drawing.Point(3, 244);
            this.lblTongsophong.Name = "lblTongsophong";
            this.lblTongsophong.Size = new System.Drawing.Size(150, 25);
            this.lblTongsophong.TabIndex = 0;
            this.lblTongsophong.Text = "Tổng số phòng:";
            // 
            // txtTongsophong
            // 
            this.txtTongsophong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongsophong.BackColor = System.Drawing.SystemColors.Window;
            this.txtTongsophong.Location = new System.Drawing.Point(159, 241);
            this.txtTongsophong.Name = "txtTongsophong";
            this.txtTongsophong.ReadOnly = true;
            this.txtTongsophong.Size = new System.Drawing.Size(246, 30);
            this.txtTongsophong.TabIndex = 5;
            // 
            // lblTrangthai
            // 
            this.lblTrangthai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTrangthai.AutoSize = true;
            this.lblTrangthai.Location = new System.Drawing.Point(25, 301);
            this.lblTrangthai.Name = "lblTrangthai";
            this.lblTrangthai.Size = new System.Drawing.Size(106, 25);
            this.lblTrangthai.TabIndex = 0;
            this.lblTrangthai.Text = "Trạng thái:";
            // 
            // cboTrangthai
            // 
            this.cboTrangthai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTrangthai.FormattingEnabled = true;
            this.cboTrangthai.Location = new System.Drawing.Point(159, 297);
            this.cboTrangthai.Name = "cboTrangthai";
            this.cboTrangthai.Size = new System.Drawing.Size(246, 33);
            this.cboTrangthai.TabIndex = 6;
            this.cboTrangthai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboTrangthai_KeyDown);
            // 
            // lblGhichu
            // 
            this.lblGhichu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGhichu.AutoSize = true;
            this.lblGhichu.Location = new System.Drawing.Point(35, 358);
            this.lblGhichu.Name = "lblGhichu";
            this.lblGhichu.Size = new System.Drawing.Size(85, 25);
            this.lblGhichu.TabIndex = 0;
            this.lblGhichu.Text = "Ghi chú:";
            // 
            // txtGhichu
            // 
            this.txtGhichu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhichu.Location = new System.Drawing.Point(159, 349);
            this.txtGhichu.Multiline = true;
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Size = new System.Drawing.Size(246, 44);
            this.txtGhichu.TabIndex = 7;
            this.txtGhichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhichu_KeyDown);
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
            this.tlpButtons.Location = new System.Drawing.Point(3, 409);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 2;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Size = new System.Drawing.Size(408, 93);
            this.tlpButtons.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(129, 40);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "select";
            this.btnNew.Text = "Thêm mới";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(138, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(129, 40);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Tag = "select";
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(273, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(132, 40);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Tag = "select";
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(3, 49);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 41);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "confirm";
            this.btnSave.Text = "Ghi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(138, 49);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 41);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Tag = "confirm";
            this.btnCancel.Text = "Hủy ghi";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(273, 49);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 41);
            this.btnClose.TabIndex = 0;
            this.btnClose.Tag = "select";
            this.btnClose.Text = "Kết thúc";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tlpRinght
            // 
            this.tlpRinght.ColumnCount = 1;
            this.tlpRinght.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRinght.Controls.Add(this.tlpSearch, 0, 0);
            this.tlpRinght.Controls.Add(this.pnlGrid, 0, 1);
            this.tlpRinght.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRinght.Location = new System.Drawing.Point(423, 3);
            this.tlpRinght.Name = "tlpRinght";
            this.tlpRinght.RowCount = 2;
            this.tlpRinght.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlpRinght.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRinght.Size = new System.Drawing.Size(626, 505);
            this.tlpRinght.TabIndex = 1;
            // 
            // tlpSearch
            // 
            this.tlpSearch.ColumnCount = 2;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Controls.Add(this.lblTimkiem, 0, 0);
            this.tlpSearch.Controls.Add(this.txtTimkiemkhu, 1, 0);
            this.tlpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearch.Location = new System.Drawing.Point(3, 3);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.RowCount = 1;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Size = new System.Drawing.Size(620, 53);
            this.tlpSearch.TabIndex = 0;
            // 
            // lblTimkiem
            // 
            this.lblTimkiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTimkiem.AutoSize = true;
            this.lblTimkiem.Location = new System.Drawing.Point(3, 14);
            this.lblTimkiem.Name = "lblTimkiem";
            this.lblTimkiem.Size = new System.Drawing.Size(198, 25);
            this.lblTimkiem.TabIndex = 0;
            this.lblTimkiem.Text = "Tìm kiếm tên khu nhà";
            // 
            // txtTimkiemkhu
            // 
            this.txtTimkiemkhu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimkiemkhu.Location = new System.Drawing.Point(207, 11);
            this.txtTimkiemkhu.Name = "txtTimkiemkhu";
            this.txtTimkiemkhu.Size = new System.Drawing.Size(410, 30);
            this.txtTimkiemkhu.TabIndex = 1;
            this.txtTimkiemkhu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimkiemkhu_KeyDown);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvQuanlykhunha);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(3, 62);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(620, 440);
            this.pnlGrid.TabIndex = 1;
            // 
            // dgvQuanlykhunha
            // 
            this.dgvQuanlykhunha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanlykhunha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuanlykhunha.Location = new System.Drawing.Point(0, 0);
            this.dgvQuanlykhunha.Name = "dgvQuanlykhunha";
            this.dgvQuanlykhunha.RowHeadersWidth = 51;
            this.dgvQuanlykhunha.RowTemplate.Height = 24;
            this.dgvQuanlykhunha.Size = new System.Drawing.Size(620, 440);
            this.dgvQuanlykhunha.TabIndex = 0;
            this.dgvQuanlykhunha.SelectionChanged += new System.EventHandler(this.dgvQuanlykhunha_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Quanlykhunha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1064, 583);
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Quanlykhunha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quanlykhunha";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Quanlykhunha_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpContent.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.tlplnputs.ResumeLayout(false);
            this.tlplnputs.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.tlpRinght.ResumeLayout(false);
            this.tlpSearch.ResumeLayout(false);
            this.tlpSearch.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanlykhunha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.TableLayoutPanel tlplnputs;
        private System.Windows.Forms.Label lblMakhu;
        private System.Windows.Forms.TextBox txtMakhu;
        private System.Windows.Forms.Label lblTenkhu;
        private System.Windows.Forms.TextBox txtTenkhu;
        private System.Windows.Forms.Label lblLoaikhu;
        private System.Windows.Forms.ComboBox cboLoaikhu;
        private System.Windows.Forms.Label lblSotang;
        private System.Windows.Forms.TextBox txtSotang;
        private System.Windows.Forms.Label lblTongsophong;
        private System.Windows.Forms.TextBox txtTongsophong;
        private System.Windows.Forms.Label lblTrangthai;
        private System.Windows.Forms.ComboBox cboTrangthai;
        private System.Windows.Forms.Label lblGhichu;
        private System.Windows.Forms.TextBox txtGhichu;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tlpRinght;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.Label lblTimkiem;
        private System.Windows.Forms.TextBox txtTimkiemkhu;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvQuanlykhunha;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}