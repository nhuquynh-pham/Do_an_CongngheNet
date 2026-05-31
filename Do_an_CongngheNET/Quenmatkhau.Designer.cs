namespace Do_an_CongngheNET
{
    partial class Quenmatkhau
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
            // Row 0 — Tên đăng nhập
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.lblTendangnhap = new System.Windows.Forms.Label();
            this.txtTendangnhap = new System.Windows.Forms.TextBox();
            // Row 1 — Mã xác nhận / OTP
            this.tlpTop2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaxacnhan = new System.Windows.Forms.Label();
            this.txtMaxacnhan = new System.Windows.Forms.TextBox();
            this.lblGuima = new System.Windows.Forms.Label();
            // Row 2 — Mật khẩu mới
            this.tlpTop3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMatkhau = new System.Windows.Forms.Label();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.chkMatkhau = new System.Windows.Forms.CheckBox();
            // Row 3 — Nhập lại mật khẩu
            this.tlpTop4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNhaplaimk = new System.Windows.Forms.Label();
            this.txtNhaplaimk = new System.Windows.Forms.TextBox();
            this.chkNhaplaimk = new System.Windows.Forms.CheckBox();
            // Row 4 — Xác nhận / Quay lại
            this.tlpTop5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblXacnhanmk = new System.Windows.Forms.Label();
            this.lblQuaylaidangnhap = new System.Windows.Forms.Label();

            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.tlpTop2.SuspendLayout();
            this.tlpTop3.SuspendLayout();
            this.tlpTop4.SuspendLayout();
            this.tlpTop5.SuspendLayout();
            this.SuspendLayout();

            // ──────────────────────────────────────────────────────────
            // tlpRoot — header cố định 80px | content fill
            // ──────────────────────────────────────────────────────────
            this.tlpRoot.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpRoot.Controls.Add(this.tlpContent, 0, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 2;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.TabIndex = 0;

            // ──────────────────────────────────────────────────────────
            // pnlHeader — tiêu đề form, căn giữa
            // ──────────────────────────────────────────────────────────
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.TabIndex = 0;

            // lblTitle — Anchor.None → tự căn giữa theo panel
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "QUÊN MẬT KHẨU HỆ THỐNG QUẢN LÝ KÝ TÚC XÁ";
            this.lblTitle.TabIndex = 0;
            // Căn giữa theo chiều ngang — tính lại khi form resize
            this.pnlHeader.Layout += (s, e) => {
                this.lblTitle.Left = (this.pnlHeader.ClientSize.Width - this.lblTitle.Width) / 2;
                this.lblTitle.Top = (this.pnlHeader.ClientSize.Height - this.lblTitle.Height) / 2;
            };

            // ──────────────────────────────────────────────────────────
            // tlpContent — 5 hàng đều nhau (20% mỗi hàng)
            // ──────────────────────────────────────────────────────────
            this.tlpContent.ColumnCount = 1;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Controls.Add(this.tlpTop, 0, 0);
            this.tlpContent.Controls.Add(this.tlpTop2, 0, 1);
            this.tlpContent.Controls.Add(this.tlpTop3, 0, 2);
            this.tlpContent.Controls.Add(this.tlpTop4, 0, 3);
            this.tlpContent.Controls.Add(this.tlpTop5, 0, 4);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 5;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpContent.TabIndex = 1;

            // ── Row 0: Tên đăng nhập / email ─────────────────────────
            this.tlpTop.ColumnCount = 2;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());                                            // label autosize
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); // textbox fill
            this.tlpTop.Controls.Add(this.lblTendangnhap, 0, 0);
            this.tlpTop.Controls.Add(this.txtTendangnhap, 1, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.tlpTop.TabIndex = 0;

            this.lblTendangnhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTendangnhap.AutoSize = true;
            this.lblTendangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTendangnhap.Name = "lblTendangnhap";
            this.lblTendangnhap.Text = "Tên đăng nhập hoặc email:";
            this.lblTendangnhap.TabIndex = 0;
            this.lblTendangnhap.Margin = new System.Windows.Forms.Padding(4, 0, 12, 0);

            this.txtTendangnhap.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtTendangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtTendangnhap.Name = "txtTendangnhap";
            this.txtTendangnhap.TabIndex = 1;

            // ── Row 1: Mã xác nhận / OTP ─────────────────────────────
            this.tlpTop2.ColumnCount = 3;
            this.tlpTop2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());                                            // label autosize
            this.tlpTop2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); // textbox fill
            this.tlpTop2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());                                            // "Gửi mã" autosize
            this.tlpTop2.Controls.Add(this.lblMaxacnhan, 0, 0);
            this.tlpTop2.Controls.Add(this.txtMaxacnhan, 1, 0);
            this.tlpTop2.Controls.Add(this.lblGuima, 2, 0);
            this.tlpTop2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop2.Name = "tlpTop2";
            this.tlpTop2.RowCount = 1;
            this.tlpTop2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.tlpTop2.TabIndex = 1;

            this.lblMaxacnhan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMaxacnhan.AutoSize = true;
            this.lblMaxacnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMaxacnhan.Name = "lblMaxacnhan";
            this.lblMaxacnhan.Text = "Mã xác nhận / OTP:";
            this.lblMaxacnhan.TabIndex = 0;
            this.lblMaxacnhan.Margin = new System.Windows.Forms.Padding(4, 0, 12, 0);

            this.txtMaxacnhan.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtMaxacnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtMaxacnhan.Name = "txtMaxacnhan";
            this.txtMaxacnhan.TabIndex = 2;

            this.lblGuima.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGuima.AutoSize = true;
            this.lblGuima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGuima.Name = "lblGuima";
            this.lblGuima.Text = "Gửi mã";
            this.lblGuima.TabIndex = 3;
            this.lblGuima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGuima.Margin = new System.Windows.Forms.Padding(12, 0, 4, 0);

            // ── Row 2: Mật khẩu mới ───────────────────────────────────
            this.tlpTop3.ColumnCount = 3;
            this.tlpTop3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());                                            // label autosize
            this.tlpTop3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); // textbox fill
            this.tlpTop3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());                                            // checkbox autosize
            this.tlpTop3.Controls.Add(this.lblMatkhau, 0, 0);
            this.tlpTop3.Controls.Add(this.txtMatkhau, 1, 0);
            this.tlpTop3.Controls.Add(this.chkMatkhau, 2, 0);
            this.tlpTop3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop3.Name = "tlpTop3";
            this.tlpTop3.RowCount = 1;
            this.tlpTop3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop3.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.tlpTop3.TabIndex = 2;

            this.lblMatkhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMatkhau.AutoSize = true;
            this.lblMatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMatkhau.Name = "lblMatkhau";
            this.lblMatkhau.Text = "Mật khẩu mới:";
            this.lblMatkhau.TabIndex = 0;
            this.lblMatkhau.Margin = new System.Windows.Forms.Padding(4, 0, 12, 0);

            this.txtMatkhau.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtMatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.PasswordChar = '*';
            this.txtMatkhau.TabIndex = 4;

            this.chkMatkhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkMatkhau.AutoSize = true;
            this.chkMatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.chkMatkhau.Name = "chkMatkhau";
            this.chkMatkhau.Text = "Hiển thị mật khẩu";
            this.chkMatkhau.TabIndex = 5;
            this.chkMatkhau.UseVisualStyleBackColor = true;
            this.chkMatkhau.Margin = new System.Windows.Forms.Padding(12, 0, 4, 0);

            // ── Row 3: Nhập lại mật khẩu ─────────────────────────────
            this.tlpTop4.ColumnCount = 3;
            this.tlpTop4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());                                            // label autosize
            this.tlpTop4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); // textbox fill
            this.tlpTop4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());                                            // checkbox autosize
            this.tlpTop4.Controls.Add(this.lblNhaplaimk, 0, 0);
            this.tlpTop4.Controls.Add(this.txtNhaplaimk, 1, 0);
            this.tlpTop4.Controls.Add(this.chkNhaplaimk, 2, 0);
            this.tlpTop4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop4.Name = "tlpTop4";
            this.tlpTop4.RowCount = 1;
            this.tlpTop4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop4.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.tlpTop4.TabIndex = 3;

            this.lblNhaplaimk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNhaplaimk.AutoSize = true;
            this.lblNhaplaimk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNhaplaimk.Name = "lblNhaplaimk";
            this.lblNhaplaimk.Text = "Nhập lại mật khẩu:";
            this.lblNhaplaimk.TabIndex = 0;
            this.lblNhaplaimk.Margin = new System.Windows.Forms.Padding(4, 0, 12, 0);

            this.txtNhaplaimk.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtNhaplaimk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtNhaplaimk.Name = "txtNhaplaimk";
            this.txtNhaplaimk.PasswordChar = '*';
            this.txtNhaplaimk.TabIndex = 6;

            this.chkNhaplaimk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkNhaplaimk.AutoSize = true;
            this.chkNhaplaimk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.chkNhaplaimk.Name = "chkNhaplaimk";
            this.chkNhaplaimk.Text = "Hiển thị mật khẩu";
            this.chkNhaplaimk.TabIndex = 7;
            this.chkNhaplaimk.UseVisualStyleBackColor = true;
            this.chkNhaplaimk.Margin = new System.Windows.Forms.Padding(12, 0, 4, 0);

            // ── Row 4: Xác nhận đổi mật khẩu | Quay lại đăng nhập ───
            this.tlpTop5.ColumnCount = 2;
            this.tlpTop5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTop5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTop5.Controls.Add(this.lblXacnhanmk, 0, 0);
            this.tlpTop5.Controls.Add(this.lblQuaylaidangnhap, 1, 0);
            this.tlpTop5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop5.Name = "tlpTop5";
            this.tlpTop5.RowCount = 1;
            this.tlpTop5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop5.TabIndex = 4;

            this.lblXacnhanmk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblXacnhanmk.AutoSize = true;
            this.lblXacnhanmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblXacnhanmk.Name = "lblXacnhanmk";
            this.lblXacnhanmk.Text = "Xác nhận đổi mật khẩu";
            this.lblXacnhanmk.TabIndex = 8;
            this.lblXacnhanmk.Cursor = System.Windows.Forms.Cursors.Hand;

            this.lblQuaylaidangnhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQuaylaidangnhap.AutoSize = true;
            this.lblQuaylaidangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblQuaylaidangnhap.Name = "lblQuaylaidangnhap";
            this.lblQuaylaidangnhap.Text = "Quay lại đăng nhập";
            this.lblQuaylaidangnhap.TabIndex = 9;
            this.lblQuaylaidangnhap.Cursor = System.Windows.Forms.Cursors.Hand;

            // ──────────────────────────────────────────────────────────
            // Form
            // ──────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.MinimumSize = new System.Drawing.Size(560, 380);   // không vỡ dưới ngưỡng này
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Quenmatkhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quenmatkhau";

            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpContent.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.tlpTop.PerformLayout();
            this.tlpTop2.ResumeLayout(false);
            this.tlpTop2.PerformLayout();
            this.tlpTop3.ResumeLayout(false);
            this.tlpTop3.PerformLayout();
            this.tlpTop4.ResumeLayout(false);
            this.tlpTop4.PerformLayout();
            this.tlpTop5.ResumeLayout(false);
            this.tlpTop5.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private System.Windows.Forms.Label lblTendangnhap;
        private System.Windows.Forms.TextBox txtTendangnhap;
        private System.Windows.Forms.TableLayoutPanel tlpTop2;
        private System.Windows.Forms.Label lblMaxacnhan;
        private System.Windows.Forms.TextBox txtMaxacnhan;
        private System.Windows.Forms.Label lblGuima;
        private System.Windows.Forms.TableLayoutPanel tlpTop3;
        private System.Windows.Forms.Label lblMatkhau;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.CheckBox chkMatkhau;
        private System.Windows.Forms.TableLayoutPanel tlpTop4;
        private System.Windows.Forms.Label lblNhaplaimk;
        private System.Windows.Forms.TextBox txtNhaplaimk;
        private System.Windows.Forms.CheckBox chkNhaplaimk;
        private System.Windows.Forms.TableLayoutPanel tlpTop5;
        private System.Windows.Forms.Label lblXacnhanmk;
        private System.Windows.Forms.Label lblQuaylaidangnhap;
    }
}