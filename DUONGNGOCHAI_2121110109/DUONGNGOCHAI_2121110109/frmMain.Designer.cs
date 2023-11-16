namespace DUONGNGOCHAI_2121110109
{
    partial class frmMain
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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.HeThongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DangXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLySanPhamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLyLoaiSanPhamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLyDonHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLyHoaDonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChiTietHoaDonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLyThanhVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLyKhachHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControlMain = new System.Windows.Forms.TabControl();
            this.TroGiupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.Color.White;
            this.menuStripMain.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HeThongToolStripMenuItem,
            this.QuanLySanPhamToolStripMenuItem,
            this.QuanLyLoaiSanPhamToolStripMenuItem,
            this.QuanLyDonHangToolStripMenuItem,
            this.QuanLyThanhVienToolStripMenuItem,
            this.QuanLyKhachHangToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1176, 33);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // HeThongToolStripMenuItem
            // 
            this.HeThongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DangXuatToolStripMenuItem,
            this.TroGiupToolStripMenuItem});
            this.HeThongToolStripMenuItem.Name = "HeThongToolStripMenuItem";
            this.HeThongToolStripMenuItem.Size = new System.Drawing.Size(106, 29);
            this.HeThongToolStripMenuItem.Text = "Hệ thống";
            // 
            // DangXuatToolStripMenuItem
            // 
            this.DangXuatToolStripMenuItem.Name = "DangXuatToolStripMenuItem";
            this.DangXuatToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.DangXuatToolStripMenuItem.Text = "Đăng xuất";
            this.DangXuatToolStripMenuItem.Click += new System.EventHandler(this.DangXuatToolStripMenuItem_Click);
            // 
            // QuanLySanPhamToolStripMenuItem
            // 
            this.QuanLySanPhamToolStripMenuItem.Name = "QuanLySanPhamToolStripMenuItem";
            this.QuanLySanPhamToolStripMenuItem.Size = new System.Drawing.Size(180, 29);
            this.QuanLySanPhamToolStripMenuItem.Text = "Quản lý sản phẩm";
            this.QuanLySanPhamToolStripMenuItem.Click += new System.EventHandler(this.QuanLySanPhamToolStripMenuItem_Click);
            // 
            // QuanLyLoaiSanPhamToolStripMenuItem
            // 
            this.QuanLyLoaiSanPhamToolStripMenuItem.Name = "QuanLyLoaiSanPhamToolStripMenuItem";
            this.QuanLyLoaiSanPhamToolStripMenuItem.Size = new System.Drawing.Size(216, 29);
            this.QuanLyLoaiSanPhamToolStripMenuItem.Text = "Quản lý loại sản phẩm";
            this.QuanLyLoaiSanPhamToolStripMenuItem.Click += new System.EventHandler(this.QuanLyLoaiSanPhamToolStripMenuItem_Click);
            // 
            // QuanLyDonHangToolStripMenuItem
            // 
            this.QuanLyDonHangToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuanLyHoaDonToolStripMenuItem,
            this.ChiTietHoaDonToolStripMenuItem});
            this.QuanLyDonHangToolStripMenuItem.Name = "QuanLyDonHangToolStripMenuItem";
            this.QuanLyDonHangToolStripMenuItem.Size = new System.Drawing.Size(173, 29);
            this.QuanLyDonHangToolStripMenuItem.Text = "Quản lý hóa đơn ";
            // 
            // QuanLyHoaDonToolStripMenuItem
            // 
            this.QuanLyHoaDonToolStripMenuItem.Name = "QuanLyHoaDonToolStripMenuItem";
            this.QuanLyHoaDonToolStripMenuItem.Size = new System.Drawing.Size(249, 34);
            this.QuanLyHoaDonToolStripMenuItem.Text = "Hóa đơn";
            this.QuanLyHoaDonToolStripMenuItem.Click += new System.EventHandler(this.QuanLyHoaDonToolStripMenuItem_Click_1);
            // 
            // ChiTietHoaDonToolStripMenuItem
            // 
            this.ChiTietHoaDonToolStripMenuItem.Name = "ChiTietHoaDonToolStripMenuItem";
            this.ChiTietHoaDonToolStripMenuItem.Size = new System.Drawing.Size(249, 34);
            this.ChiTietHoaDonToolStripMenuItem.Text = "Chi tiết hóa đơn";
            this.ChiTietHoaDonToolStripMenuItem.Click += new System.EventHandler(this.ChiTietHoaDonToolStripMenuItem_Click);
            // 
            // QuanLyThanhVienToolStripMenuItem
            // 
            this.QuanLyThanhVienToolStripMenuItem.Name = "QuanLyThanhVienToolStripMenuItem";
            this.QuanLyThanhVienToolStripMenuItem.Size = new System.Drawing.Size(187, 29);
            this.QuanLyThanhVienToolStripMenuItem.Text = "Quản lý thành viên";
            this.QuanLyThanhVienToolStripMenuItem.Click += new System.EventHandler(this.QuanLyThanhVienToolStripMenuItem_Click_1);
            // 
            // QuanLyKhachHangToolStripMenuItem
            // 
            this.QuanLyKhachHangToolStripMenuItem.Name = "QuanLyKhachHangToolStripMenuItem";
            this.QuanLyKhachHangToolStripMenuItem.Size = new System.Drawing.Size(196, 29);
            this.QuanLyKhachHangToolStripMenuItem.Text = "Quản lý khách hàng";
            this.QuanLyKhachHangToolStripMenuItem.Click += new System.EventHandler(this.QuanLyKhachHangToolStripMenuItem_Click);
            // 
            // TabControlMain
            // 
            this.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlMain.Location = new System.Drawing.Point(0, 33);
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedIndex = 0;
            this.TabControlMain.Size = new System.Drawing.Size(1176, 417);
            this.TabControlMain.TabIndex = 1;
            // 
            // TroGiupToolStripMenuItem
            // 
            this.TroGiupToolStripMenuItem.Name = "TroGiupToolStripMenuItem";
            this.TroGiupToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.TroGiupToolStripMenuItem.Text = "Trợ giúp";
            this.TroGiupToolStripMenuItem.Click += new System.EventHandler(this.TroGiupToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 450);
            this.Controls.Add(this.TabControlMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem HeThongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DangXuatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuanLySanPhamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuanLyLoaiSanPhamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuanLyDonHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuanLyThanhVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuanLyKhachHangToolStripMenuItem;
        private System.Windows.Forms.TabControl TabControlMain;
        private System.Windows.Forms.ToolStripMenuItem QuanLyHoaDonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChiTietHoaDonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TroGiupToolStripMenuItem;
    }
}