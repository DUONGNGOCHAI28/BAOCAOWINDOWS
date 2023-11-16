using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUONGNGOCHAI_2121110109
{
    public partial class frmHOADON : Form
    {
        public frmHOADON()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        string str = @"Data Source=DESKTOP-965I83I\NOVELS;Initial Catalog=QLBH;Persist Security Info=True;User ID=sa;Password=2805";
        SqlCommand Command;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable dt = new DataTable();
        void loadDSHD()
        {
            Command = conn.CreateCommand();
            Command.CommandText = "select * from CTHD";
            adt.SelectCommand = Command;
            dt.Clear();
            adt.Fill(dt);
            dgvDanhSach.DataSource = dt;
        }
        private void frmHOADON_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            loadDSHD();
        }
        private void Reset()
        {
            txtSoHD.Text = "";
            txtMaSanPham.Text = "";
            mtxtSoLuong.Text = "";
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1 || rowindex >= dgvDanhSach.Rows.Count - 1)
                {
                    throw new Exception("Chưa chọn hóa đơn");
                }
                txtSoHD.Text = dgvDanhSach.Rows[rowindex].Cells["SoHD"].Value.ToString();
                txtMaSanPham.Text = dgvDanhSach.Rows[rowindex].Cells["MaSP"].Value.ToString();
                mtxtSoLuong.Text = dgvDanhSach.Rows[rowindex].Cells["SL"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ChuoiKN"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SP_ThemHOADON";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SOHD", SqlDbType.Int).Value = int.Parse(txtSoHD.Text);
                cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = txtMaSanPham.Text;
                cmd.Parameters.Add("@SL", SqlDbType.Int).Value = int.Parse(mtxtSoLuong.Text);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                loadDSHD();
                Reset();
                MessageBox.Show("Thêm hóa đơn mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã thành viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHD.Focus();
            }

            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ChuoiKN"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_SuaHOADON";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SOHD", SqlDbType.Int).Value = int.Parse(txtSoHD.Text);
                    cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = txtMaSanPham.Text;
                    cmd.Parameters.Add("@SL", SqlDbType.Int).Value = int.Parse(mtxtSoLuong.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    loadDSHD();
                    Reset();
                    MessageBox.Show("Sửa hóa đơn mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSoHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập hóa  cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHD.Focus();
            }

            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ChuoiKN"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_XoaHOADON";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SOHD", SqlDbType.Int).Value = Convert.ToInt32(txtSoHD.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    loadDSHD();
                    Reset();
                    MessageBox.Show("Xóa hóa đơn mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMain.mainTabControl.TabPages.Remove(frmMain.mainTabControl.TabPages["tpDonHang"]);

        }
    }
}
