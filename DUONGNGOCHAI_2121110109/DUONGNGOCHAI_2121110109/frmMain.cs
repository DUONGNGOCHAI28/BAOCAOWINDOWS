using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUONGNGOCHAI_2121110109
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public static THANHVIEN thanhvien = null;
        ImageList iconsList = null;
        public static TabControl mainTabControl = null;
        DataTable dt=new DataTable();

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (thanhvien == null)
            {
                Form frm = new frmDANGNHAP();
                frm.ShowDialog();
            }
            iconsList = IconsImageListTabControl();
            mainTabControl = TabControlMain;
            TabControlMain.ImageList = iconsList;
        }
        private Boolean ExistTabPage(TabControl tabControl,string tabName)
        {
            Boolean check = false;
            for(int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == tabName)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void QuanLySanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ExistTabPage(TabControlMain, "tpSanPham"))
            {
                TabPage tabPage = new TabPage();
                tabPage.Text = "Quản lý sản phẩm";
                tabPage.Name = "tpSanPham";
                tabPage.ImageIndex = 0;
                Form frm = new frmSANPHAM();
                frm.TopLevel = false;
                frm.Parent = tabPage;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle= FormBorderStyle.None;
                frm.Show();
                tabPage.Controls.Add(frm);
                TabControlMain.TabPages.Add(tabPage);
            }
            else
            {
                TabControlMain.SelectedTab = TabControlMain.TabPages["tpSanPham"];
            }
        }

        private void QuanLyLoaiSanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ExistTabPage(TabControlMain, "tpLoaiSP"))
            {
                TabPage tabPage = new TabPage();
                tabPage.Text = "Quản lý loại sản phẩm";
                tabPage.Name = "tpLoaiSP";
                tabPage.ImageIndex = 1;
                Form frm = new frmLOAISP();
                frm.TopLevel = false;
                frm.Parent = tabPage;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
                tabPage.Controls.Add(frm);
                TabControlMain.TabPages.Add(tabPage);
                TabControlMain.SelectedTab = tabPage;
            }
            else
            {
                TabControlMain.SelectedTab = TabControlMain.TabPages["tpLoaiSP"];
            }
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmMain();
            frmMain.thanhvien = null;
            frmMain.ActiveForm.Hide();
            frm.ShowDialog();
        }
        private ImageList IconsImageListTabControl()
        {
            ImageList iconsList = new ImageList();
            iconsList.ColorDepth = ColorDepth.Depth32Bit;
            iconsList.TransparentColor = Color.Green;
            iconsList.ImageSize = new Size(25, 25);
            return iconsList;
        }

        private void ChiTietHoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ExistTabPage(TabControlMain, "tpChiTietHoaDon"))
            {
                TabPage tabPage = new TabPage();
                tabPage.Text = "Chi tiết hóa đơn";
                tabPage.Name = "tpChiTietHoaDon";
                tabPage.ImageIndex = 5;
                Form frm = new frmCTHD();
                frm.TopLevel = false;
                frm.Parent = tabPage;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
                tabPage.Controls.Add(frm);
                TabControlMain.TabPages.Add(tabPage);
                TabControlMain.SelectedTab = tabPage;
            }
            else
            {
                TabControlMain.SelectedTab = TabControlMain.TabPages["tpChiTietHoaDon"];
            }
        }

        private void QuanLyHoaDonToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            if (!ExistTabPage(TabControlMain, "tpDonHang"))
            {
                TabPage tabPage = new TabPage();
                tabPage.Text = "Quản lý hóa đơn";
                tabPage.Name = "tpDonHang";
                tabPage.ImageIndex = 2;
                Form frm = new frmHOADON();
                frm.TopLevel = false;
                frm.Parent = tabPage;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
                tabPage.Controls.Add(frm);
                TabControlMain.TabPages.Add(tabPage);
                TabControlMain.SelectedTab = tabPage;
            }
            else
            {
                TabControlMain.SelectedTab = TabControlMain.TabPages["tpDonHang"];
            }
        }

        private void QuanLyThanhVienToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!ExistTabPage(TabControlMain, "tpThanhVien"))
            {
                TabPage tabPage = new TabPage();
                tabPage.Text = "Quản lý thành viên";
                tabPage.Name = "tpThanhVien";
                tabPage.ImageIndex = 3;
                Form frm = new frmTHANHVIEN();
                frm.TopLevel = false;
                frm.Parent = tabPage;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
                tabPage.Controls.Add(frm);
                TabControlMain.TabPages.Add(tabPage);
                TabControlMain.SelectedTab = tabPage;
            }
            else
            {
                TabControlMain.SelectedTab = TabControlMain.TabPages["tpThanhVien"];
            }
        }

        private void TroGiupToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

           
        }

        private void QuanLyKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!ExistTabPage(TabControlMain, "tpKhachHang"))
            {
                TabControlMain.TabPages.Clear();
                TabPage tabPage = new TabPage();
                tabPage.Text = "Quản lý khách hàng";
                tabPage.Name = "tpKhachHang";
                tabPage.ImageIndex = 4;
                Form frm = new frmKHACHHANG();
                frm.TopLevel = false;
                frm.Parent = tabPage;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
                tabPage.Controls.Add(frm);
                TabControlMain.TabPages.Add(tabPage);
                TabControlMain.SelectedTab = tabPage;
            }
            else
            {
                TabControlMain.SelectedTab = TabControlMain.TabPages["tpKhachHang"];
            }
        }

        private void TroGiupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ExistTabPage(TabControlMain, "tpTroGiup"))
            {
                TabControlMain.TabPages.Clear();
                TabPage tabPage = new TabPage();
                tabPage.Text = "Trợ giúp";
                tabPage.Name = "tpTroGiup";
                tabPage.ImageIndex = 4;
                Form frm = new frmTROGIUP();
                frm.TopLevel = false;
                frm.Parent = tabPage;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
                tabPage.Controls.Add(frm);
                TabControlMain.TabPages.Add(tabPage);
                TabControlMain.SelectedTab = tabPage;
            }
            else
            {
                TabControlMain.SelectedTab = TabControlMain.TabPages["tpTroGiup"];
            }
        }
    }
}
