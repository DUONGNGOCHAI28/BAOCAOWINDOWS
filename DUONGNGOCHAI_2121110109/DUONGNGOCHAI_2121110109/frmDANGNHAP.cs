using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DUONGNGOCHAI_2121110109
{
    public partial class frmDANGNHAP : Form
    {
        public frmDANGNHAP()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-965I83I\NOVELS;Initial Catalog=QLBH;Persist Security Info=True;User ID=sa;Password=2805");
            try
            {
                conn.Open();
                string hoten = txtTenDN.Text;
                string matkhau = txtMatKhau.Text;
                if (hoten.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên!","Thông báo");
                }
                else if (matkhau.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu!", "Thông báo");
                }
                else
                {
                    string sql = "select *from THANHVIEN where HOTEN='" + hoten + "' and MATKHAU='" + matkhau + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    if (dta.Read() == true)
                    {
                        MessageBox.Show("Đăng nhập thành công", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Hide();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên hoặc mật khẩu không chính xác", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thong bao");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmDANGNHAP_Load(object sender, EventArgs e)
        {

        }
    }
}
