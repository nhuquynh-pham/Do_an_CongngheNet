namespace Do_an_CongngheNET
{
    partial class Dangnhap
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
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.piclogo = new System.Windows.Forms.PictureBox();
            this.tlpHethong = new System.Windows.Forms.TableLayoutPanel();
            this.lblTruongDHV = new System.Windows.Forms.Label();
            this.lblHethongdangnhap = new System.Windows.Forms.Label();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            // username row
            this.tlpRowUser = new System.Windows.Forms.TableLayoutPanel();
            this.lbluser = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            // password row
            this.tlpRowPass = new System.Windows.Forms.TableLayoutPanel();
            this.lblkey = new System.Windows.Forms.Label();
            this.textkey = new System.Windows.Forms.TextBox();
            this.chkHienthimk = new System.Windows.Forms.CheckBox();
            // options row
            this.tlpRowOptions = new System.Windows.Forms.TableLayoutPanel();
            this.chkGhinhodn = new System.Windows.Forms.CheckBox();
            this.lblQuenmk = new System.Windows.Forms.Label();
            // login button row
            this.tlpRowBtn = new System.Windows.Forms.TableLayoutPanel();
            this.lblDangnhap = new System.Windows.Forms.Label();

            this.tlpRoot.SuspendLayout();
            this.tlpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).BeginInit();
            this.tlpHethong.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.tlpRowUser.SuspendLayout();
            this.tlpRowPass.SuspendLayout();
            this.tlpRowOptions.SuspendLayout();
            this.tlpRowBtn.SuspendLayout();
            this.SuspendLayout();

            // ──────────────────────────────────────────────────────────
            // tlpRoot  — 2 rows: header (30%) | content (70%)
            // ──────────────────────────────────────────────────────────
            this.tlpRoot.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.tlpHeader, 0, 0);
            this.tlpRoot.Controls.Add(this.tlpContent, 0, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 2;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpRoot.TabIndex = 0;

            // ──────────────────────────────────────────────────────────
            // tlpHeader  — logo | tên trường + tên hệ thống
            // ──────────────────────────────────────────────────────────
            this.tlpHeader.ColumnCount = 2;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.Controls.Add(this.piclogo, 0, 0);
            this.tlpHeader.Controls.Add(this.tlpHethong, 1, 0);
            this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.TabIndex = 0;
            this.tlpHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpHeader_Paint);

            // piclogo
            this.piclogo.BackColor = System.Drawing.Color.White;
            this.piclogo.Image = global::Do_an_CongngheNET.Properties.Resources.logo_truong_dai_hoc_vinh;
            this.piclogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.piclogo.Name = "piclogo";
            this.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.piclogo.TabStop = false;

            // tlpHethong — 2 rows: tên trường / tên hệ thống
            this.tlpHethong.ColumnCount = 1;
            this.tlpHethong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHethong.Controls.Add(this.lblTruongDHV, 0, 0);
            this.tlpHethong.Controls.Add(this.lblHethongdangnhap, 0, 1);
            this.tlpHethong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHethong.Name = "tlpHethong";
            this.tlpHethong.RowCount = 2;
            this.tlpHethong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHethong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHethong.TabIndex = 3;

            this.lblTruongDHV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTruongDHV.AutoSize = true;
            this.lblTruongDHV.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.lblTruongDHV.Name = "lblTruongDHV";
            this.lblTruongDHV.Text = "TRƯỜNG ĐẠI HỌC VINH";
            this.lblTruongDHV.TabIndex = 0;

            this.lblHethongdangnhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHethongdangnhap.AutoSize = true;
            this.lblHethongdangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.lblHethongdangnhap.Name = "lblHethongdangnhap";
            this.lblHethongdangnhap.Text = "HỆ THỐNG ĐĂNG NHẬP KÝ TÚC XÁ";
            this.lblHethongdangnhap.TabIndex = 1;

            // ──────────────────────────────────────────────────────────
            // tlpContent — 4 rows: user | pass | options | button
            // ──────────────────────────────────────────────────────────
            this.tlpContent.ColumnCount = 1;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Controls.Add(this.tlpRowUser, 0, 0);
            this.tlpContent.Controls.Add(this.tlpRowPass, 0, 1);
            this.tlpContent.Controls.Add(this.tlpRowOptions, 0, 2);
            this.tlpContent.Controls.Add(this.tlpRowBtn, 0, 3);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 4;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpContent.TabIndex = 1;

            // ── Row 0: Username ───────────────────────────────────────
            this.tlpRowUser.ColumnCount = 2;
            this.tlpRowUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());                                           // label — autosize
            this.tlpRowUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); // textbox — fill
            this.tlpRowUser.Controls.Add(this.lbluser, 0, 0);
            this.tlpRowUser.Controls.Add(this.txtuser, 1, 0);
            this.tlpRowUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRowUser.Name = "tlpRowUser";
            this.tlpRowUser.RowCount = 1;
            this.tlpRowUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRowUser.TabIndex = 0;
            this.tlpRowUser.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);

            this.lbluser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbluser.AutoSize = true;
            this.lbluser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbluser.Name = "lbluser";
            this.lbluser.Text = "Tên đăng nhập hoặc email:";
            this.lbluser.TabIndex = 0;
            this.lbluser.Margin = new System.Windows.Forms.Padding(4, 0, 12, 0);

            this.txtuser.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtuser.Name = "txtuser";
            this.txtuser.TabIndex = 1;

            // ── Row 1: Password ───────────────────────────────────────
            this.tlpRowPass.ColumnCount = 3;
            this.tlpRowPass.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());                                            // label
            this.tlpRowPass.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); // textbox
            this.tlpRowPass.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());                                            // checkbox
            this.tlpRowPass.Controls.Add(this.lblkey, 0, 0);
            this.tlpRowPass.Controls.Add(this.textkey, 1, 0);
            this.tlpRowPass.Controls.Add(this.chkHienthimk, 2, 0);
            this.tlpRowPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRowPass.Name = "tlpRowPass";
            this.tlpRowPass.RowCount = 1;
            this.tlpRowPass.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRowPass.TabIndex = 1;
            this.tlpRowPass.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);

            this.lblkey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblkey.AutoSize = true;
            this.lblkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblkey.Name = "lblkey";
            this.lblkey.Text = "Mật khẩu:";
            this.lblkey.TabIndex = 0;
            this.lblkey.Margin = new System.Windows.Forms.Padding(4, 0, 12, 0);

            this.textkey.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.textkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textkey.Name = "textkey";
            this.textkey.PasswordChar = '*';
            this.textkey.TabIndex = 2;

            this.chkHienthimk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkHienthimk.AutoSize = true;
            this.chkHienthimk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.chkHienthimk.Name = "chkHienthimk";
            this.chkHienthimk.Text = "Hiển thị mật khẩu";
            this.chkHienthimk.TabIndex = 3;
            this.chkHienthimk.UseVisualStyleBackColor = true;
            this.chkHienthimk.Margin = new System.Windows.Forms.Padding(12, 0, 4, 0);
            this.chkHienthimk.CheckedChanged += new System.EventHandler(this.chkHienthimk_CheckedChanged);

            // ── Row 2: Options (ghi nhớ + quên mật khẩu) ─────────────
            this.tlpRowOptions.ColumnCount = 2;
            this.tlpRowOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRowOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRowOptions.Controls.Add(this.chkGhinhodn, 0, 0);
            this.tlpRowOptions.Controls.Add(this.lblQuenmk, 1, 0);
            this.tlpRowOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRowOptions.Name = "tlpRowOptions";
            this.tlpRowOptions.RowCount = 1;
            this.tlpRowOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRowOptions.TabIndex = 2;

            this.chkGhinhodn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkGhinhodn.AutoSize = true;
            this.chkGhinhodn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkGhinhodn.Name = "chkGhinhodn";
            this.chkGhinhodn.Text = "Ghi nhớ đăng nhập";
            this.chkGhinhodn.TabIndex = 4;
            this.chkGhinhodn.UseVisualStyleBackColor = true;
            this.chkGhinhodn.CheckedChanged += new System.EventHandler(this.chkGhinhodn_CheckedChanged);

            this.lblQuenmk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQuenmk.AutoSize = true;
            this.lblQuenmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblQuenmk.Name = "lblQuenmk";
            this.lblQuenmk.Text = "Quên mật khẩu?";
            this.lblQuenmk.TabIndex = 5;
            this.lblQuenmk.Click += new System.EventHandler(this.lblQuenmk_Click);

            // ── Row 3: Đăng nhập button ───────────────────────────────
            this.tlpRowBtn.ColumnCount = 1;
            this.tlpRowBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRowBtn.Controls.Add(this.lblDangnhap, 0, 0);
            this.tlpRowBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRowBtn.Name = "tlpRowBtn";
            this.tlpRowBtn.RowCount = 1;
            this.tlpRowBtn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRowBtn.TabIndex = 3;

            this.lblDangnhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDangnhap.AutoSize = true;
            this.lblDangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.lblDangnhap.Name = "lblDangnhap";
            this.lblDangnhap.Text = "Đăng nhập";
            this.lblDangnhap.TabIndex = 6;
            this.lblDangnhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDangnhap.Click += new System.EventHandler(this.lblDangnhap_Click);

            // ──────────────────────────────────────────────────────────
            // Form
            // ──────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(773, 419);
            this.MinimumSize = new System.Drawing.Size(560, 340);   // <-- không vỡ dưới ngưỡng này
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dangnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dangnhap";

            this.tlpRoot.ResumeLayout(false);
            this.tlpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).EndInit();
            this.tlpHethong.ResumeLayout(false);
            this.tlpHethong.PerformLayout();
            this.tlpContent.ResumeLayout(false);
            this.tlpRowUser.ResumeLayout(false);
            this.tlpRowUser.PerformLayout();
            this.tlpRowPass.ResumeLayout(false);
            this.tlpRowPass.PerformLayout();
            this.tlpRowOptions.ResumeLayout(false);
            this.tlpRowOptions.PerformLayout();
            this.tlpRowBtn.ResumeLayout(false);
            this.tlpRowBtn.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.PictureBox piclogo;
        private System.Windows.Forms.TableLayoutPanel tlpHethong;
        private System.Windows.Forms.Label lblTruongDHV;
        private System.Windows.Forms.Label lblHethongdangnhap;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.TableLayoutPanel tlpRowUser;
        private System.Windows.Forms.Label lbluser;
        protected internal System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TableLayoutPanel tlpRowPass;
        private System.Windows.Forms.Label lblkey;
        private System.Windows.Forms.TextBox textkey;
        private System.Windows.Forms.CheckBox chkHienthimk;
        private System.Windows.Forms.TableLayoutPanel tlpRowOptions;
        private System.Windows.Forms.CheckBox chkGhinhodn;
        private System.Windows.Forms.Label lblQuenmk;
        private System.Windows.Forms.TableLayoutPanel tlpRowBtn;
        private System.Windows.Forms.Label lblDangnhap;
    }
}