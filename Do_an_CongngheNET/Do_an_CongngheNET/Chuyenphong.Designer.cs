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
            this.tlpRoot.Size = new System.Drawing.Size(1043, 612);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(6, 6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1031, 44);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(388, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHUYỂN PHÒNG";
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
            this.tlpContent.Size = new System.Drawing.Size(1031, 547);
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
            this.tblLeft.Size = new System.Drawing.Size(417, 541);
            this.tblLeft.TabIndex = 0;
            this.tblLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.tblLeft_Paint);
            // 
            // tlpLeft1
            // 
            this.tlpLeft1.ColumnCount = 2;
            this.tlpLeft1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLeft1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
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
            this.tlpLeft1.Size = new System.Drawing.Size(411, 429);
            this.tlpLeft1.TabIndex = 0;
            // 
            // lblMachuyenphong
            // 
            this.lblMachuyenphong.AutoSize = true;
            this.lblMachuyenphong.Location = new System.Drawing.Point(3, 0);
            this.lblMachuyenphong.Name = "lblMachuyenphong";
            this.lblMachuyenphong.Size = new System.Drawing.Size(175, 25);
            this.lblMachuyenphong.TabIndex = 0;
            this.lblMachuyenphong.Text = "Mã chuyển phòng:";
            // 
            // txtMachuyenphong
            // 
            this.txtMachuyenphong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMachuyenphong.Location = new System.Drawing.Point(208, 3);
            this.txtMachuyenphong.Name = "txtMachuyenphong";
            this.txtMachuyenphong.Size = new System.Drawing.Size(200, 30);
            this.txtMachuyenphong.TabIndex = 1;
            // 
            // lblMasinhvien
            // 
            this.lblMasinhvien.AutoSize = true;
            this.lblMasinhvien.Location = new System.Drawing.Point(3, 38);
            this.lblMasinhvien.Name = "lblMasinhvien";
            this.lblMasinhvien.Size = new System.Drawing.Size(155, 25);
            this.lblMasinhvien.TabIndex = 0;
            this.lblMasinhvien.Text = "Mã sinh viên (*):";
            // 
            // lblHoten
            // 
            this.lblHoten.AutoSize = true;
            this.lblHoten.Location = new System.Drawing.Point(3, 76);
            this.lblHoten.Name = "lblHoten";
            this.lblHoten.Size = new System.Drawing.Size(75, 25);
            this.lblHoten.TabIndex = 0;
            this.lblHoten.Text = "Họ tên:";
            // 
            // lblPhonghientai
            // 
            this.lblPhonghientai.AutoSize = true;
            this.lblPhonghientai.Location = new System.Drawing.Point(3, 114);
            this.lblPhonghientai.Name = "lblPhonghientai";
            this.lblPhonghientai.Size = new System.Drawing.Size(142, 25);
            this.lblPhonghientai.TabIndex = 0;
            this.lblPhonghientai.Text = "Phòng hiện tại:";
            // 
            // lblKhuhientai
            // 
            this.lblKhuhientai.AutoSize = true;
            this.lblKhuhientai.Location = new System.Drawing.Point(3, 152);
            this.lblKhuhientai.Name = "lblKhuhientai";
            this.lblKhuhientai.Size = new System.Drawing.Size(121, 25);
            this.lblKhuhientai.TabIndex = 0;
            this.lblKhuhientai.Text = "Khu hiện tại:";
            // 
            // lblPhongmoi
            // 
            this.lblPhongmoi.AutoSize = true;
            this.lblPhongmoi.Location = new System.Drawing.Point(3, 190);
            this.lblPhongmoi.Name = "lblPhongmoi";
            this.lblPhongmoi.Size = new System.Drawing.Size(111, 25);
            this.lblPhongmoi.TabIndex = 0;
            this.lblPhongmoi.Text = "Phòng mới:";
            this.lblPhongmoi.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblKhumoi
            // 
            this.lblKhumoi.AutoSize = true;
            this.lblKhumoi.Location = new System.Drawing.Point(3, 228);
            this.lblKhumoi.Name = "lblKhumoi";
            this.lblKhumoi.Size = new System.Drawing.Size(90, 25);
            this.lblKhumoi.TabIndex = 0;
            this.lblKhumoi.Text = "Khu mới:";
            // 
            // lblNgaychuyen
            // 
            this.lblNgaychuyen.AutoSize = true;
            this.lblNgaychuyen.Location = new System.Drawing.Point(3, 266);
            this.lblNgaychuyen.Name = "lblNgaychuyen";
            this.lblNgaychuyen.Size = new System.Drawing.Size(133, 25);
            this.lblNgaychuyen.TabIndex = 0;
            this.lblNgaychuyen.Text = "Ngày chuyển:";
            this.lblNgaychuyen.Click += new System.EventHandler(this.label8_Click);
            // 
            // lblLydochuyen
            // 
            this.lblLydochuyen.AutoSize = true;
            this.lblLydochuyen.Location = new System.Drawing.Point(3, 304);
            this.lblLydochuyen.Name = "lblLydochuyen";
            this.lblLydochuyen.Size = new System.Drawing.Size(135, 25);
            this.lblLydochuyen.TabIndex = 0;
            this.lblLydochuyen.Text = "Lý do chuyển:";
            // 
            // lblTrangthai
            // 
            this.lblTrangthai.AutoSize = true;
            this.lblTrangthai.Location = new System.Drawing.Point(3, 342);
            this.lblTrangthai.Name = "lblTrangthai";
            this.lblTrangthai.Size = new System.Drawing.Size(106, 25);
            this.lblTrangthai.TabIndex = 0;
            this.lblTrangthai.Text = "Trạng thái:";
            // 
            // lblGhichu
            // 
            this.lblGhichu.AutoSize = true;
            this.lblGhichu.Location = new System.Drawing.Point(3, 380);
            this.lblGhichu.Name = "lblGhichu";
            this.lblGhichu.Size = new System.Drawing.Size(85, 25);
            this.lblGhichu.TabIndex = 0;
            this.lblGhichu.Text = "Ghi chú:";
            // 
            // txtMasinhvien
            // 
            this.txtMasinhvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMasinhvien.Location = new System.Drawing.Point(208, 41);
            this.txtMasinhvien.Name = "txtMasinhvien";
            this.txtMasinhvien.Size = new System.Drawing.Size(200, 30);
            this.txtMasinhvien.TabIndex = 1;
            // 
            // txtHoten
            // 
            this.txtHoten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHoten.Location = new System.Drawing.Point(208, 79);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(200, 30);
            this.txtHoten.TabIndex = 1;
            // 
            // txtNgaychuyen
            // 
            this.txtNgaychuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgaychuyen.Location = new System.Drawing.Point(208, 269);
            this.txtNgaychuyen.Name = "txtNgaychuyen";
            this.txtNgaychuyen.Size = new System.Drawing.Size(200, 30);
            this.txtNgaychuyen.TabIndex = 1;
            // 
            // txtLydochuyen
            // 
            this.txtLydochuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLydochuyen.Location = new System.Drawing.Point(208, 307);
            this.txtLydochuyen.Name = "txtLydochuyen";
            this.txtLydochuyen.Size = new System.Drawing.Size(200, 30);
            this.txtLydochuyen.TabIndex = 1;
            // 
            // txtGhichu
            // 
            this.txtGhichu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhichu.Location = new System.Drawing.Point(208, 383);
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Size = new System.Drawing.Size(200, 30);
            this.txtGhichu.TabIndex = 1;
            // 
            // cboPhonghientai
            // 
            this.cboPhonghientai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPhonghientai.FormattingEnabled = true;
            this.cboPhonghientai.Location = new System.Drawing.Point(208, 117);
            this.cboPhonghientai.Name = "cboPhonghientai";
            this.cboPhonghientai.Size = new System.Drawing.Size(200, 33);
            this.cboPhonghientai.TabIndex = 2;
            // 
            // cboKhuhientai
            // 
            this.cboKhuhientai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKhuhientai.FormattingEnabled = true;
            this.cboKhuhientai.Location = new System.Drawing.Point(208, 155);
            this.cboKhuhientai.Name = "cboKhuhientai";
            this.cboKhuhientai.Size = new System.Drawing.Size(200, 33);
            this.cboKhuhientai.TabIndex = 2;
            // 
            // cboPhongmoi
            // 
            this.cboPhongmoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPhongmoi.FormattingEnabled = true;
            this.cboPhongmoi.Location = new System.Drawing.Point(208, 193);
            this.cboPhongmoi.Name = "cboPhongmoi";
            this.cboPhongmoi.Size = new System.Drawing.Size(200, 33);
            this.cboPhongmoi.TabIndex = 2;
            // 
            // cboKhumoi
            // 
            this.cboKhumoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKhumoi.FormattingEnabled = true;
            this.cboKhumoi.Location = new System.Drawing.Point(208, 231);
            this.cboKhumoi.Name = "cboKhumoi";
            this.cboKhumoi.Size = new System.Drawing.Size(200, 33);
            this.cboKhumoi.TabIndex = 2;
            // 
            // cboTrangthai
            // 
            this.cboTrangthai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTrangthai.FormattingEnabled = true;
            this.cboTrangthai.Location = new System.Drawing.Point(208, 345);
            this.cboTrangthai.Name = "cboTrangthai";
            this.cboTrangthai.Size = new System.Drawing.Size(200, 33);
            this.cboTrangthai.TabIndex = 2;
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
            this.tlpLeft2.Location = new System.Drawing.Point(3, 438);
            this.tlpLeft2.Name = "tlpLeft2";
            this.tlpLeft2.RowCount = 2;
            this.tlpLeft2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLeft2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLeft2.Size = new System.Drawing.Size(411, 100);
            this.tlpLeft2.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(129, 44);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Thêm mới";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(3, 53);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 44);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Ghi";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Location = new System.Drawing.Point(138, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(129, 44);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(138, 53);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 44);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy ghi";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(273, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 44);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(273, 53);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 44);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Kết thúc";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRight.Controls.Add(this.tlpSearch, 0, 0);
            this.tlpRight.Controls.Add(this.pnlGrid, 0, 1);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(426, 3);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 2;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.533074F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.46693F));
            this.tlpRight.Size = new System.Drawing.Size(602, 541);
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
            this.tlpSearch.Size = new System.Drawing.Size(596, 45);
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
            this.txtSearch.Size = new System.Drawing.Size(487, 30);
            this.txtSearch.TabIndex = 1;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvChuyenphong);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(3, 54);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(596, 484);
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
            this.dgvChuyenphong.Size = new System.Drawing.Size(596, 484);
            this.dgvChuyenphong.TabIndex = 0;
            this.dgvChuyenphong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChuyenphong_CellContentClick);
            // 
            // Chuyenphong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1043, 612);
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Chuyenphong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyenphong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
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