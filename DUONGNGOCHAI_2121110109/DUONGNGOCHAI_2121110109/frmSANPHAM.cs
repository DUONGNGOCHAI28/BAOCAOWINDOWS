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
    public partial class frmSANPHAM : Form
    {
        public frmSANPHAM()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        string str = @"Data Source=DESKTOP-965I83I\NOVELS;Initial Catalog=QLBH;Persist Security Info=True;User ID=sa;Password=2805";
        SqlCommand Command;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable dt = new DataTable();
        void loadDSSP()
        {
            Command = conn.CreateCommand();
            Command.CommandText = "select * from SANPHAM";
            adt.SelectCommand = Command;
            dt.Clear();
            adt.Fill(dt);
            dgvDanhSach.DataSource = dt;
        }
        private void frmSANPHAM_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            loadDSSP();
        }

        private void dgvDanhSach_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1 || rowindex >= dgvDanhSach.Rows.Count - 1)
                {
                    throw new Exception("Chưa chọn sản phẩm");
                }
                mtxtMaSP.Text = dgvDanhSach.Rows[rowindex].Cells["MaSP"].Value.ToString();
                txtML.Text = dgvDanhSach.Rows[rowindex].Cells["MaLoai"].Value.ToString();
                txtTenSP.Text = dgvDanhSach.Rows[rowindex].Cells["Tensp"].Value.ToString();
                txtTacGia.Text = dgvDanhSach.Rows[rowindex].Cells["Tacgia"].Value.ToString();
                txtGia.Text = dgvDanhSach.Rows[rowindex].Cells["Gia"].Value.ToString();
                mtxtNamXB.Text = dgvDanhSach.Rows[rowindex].Cells["NamXB"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            mtxtMaSP.Text = "";
            txtML.Text = "";
            txtTenSP.Text = "";
            txtTacGia.Text = "";
            txtGia.Text = "";
            mtxtNamXB.Text = "";
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ChuoiKN"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SP_ThemSP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = mtxtMaSP.Text;
                cmd.Parameters.Add("@MALOAI", SqlDbType.NVarChar).Value = txtML.Text;
                cmd.Parameters.Add("@TENSP", SqlDbType.NVarChar).Value = txtTenSP.Text;
                cmd.Parameters.Add("@TACGIA", SqlDbType.NVarChar).Value = txtTacGia.Text;
                cmd.Parameters.Add("@GIA", SqlDbType.Money).Value = txtGia.Text;
                cmd.Parameters.Add("@NAMXB", SqlDbType.Int).Value = int.Parse(mtxtNamXB.Text);

                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                loadDSSP();
                Reset();
                MessageBox.Show("Thêm sản phẩm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (mtxtMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtxtMaSP.Focus();
            }
            else
            {
                try
                {
                    Command = conn.CreateCommand();
                    Command.CommandText = "update SANPHAM set MALOAI=N'" + txtML.Text + "',TENSP=N'" + txtTenSP.Text + "',TACGIA=N'" + txtTacGia.Text + "',GIA='"+ txtGia.Text + "',NAMXB='"+ mtxtNamXB .Text+ "' where MALOAI='" + mtxtMaSP.Text + "'";
                    Command.ExecuteNonQuery(); ;
                    loadDSSP();
                    Reset();
                    MessageBox.Show("Đã sửa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (mtxtMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã thành viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtxtMaSP.Focus();
            }
            else
            {
                try
                {
                    Command = conn.CreateCommand();
                    Command.CommandText = "delete from SANPHAM where MASP='" + mtxtMaSP.Text + "'";
                    Command.ExecuteNonQuery();
                    Reset();
                    loadDSSP();
                    MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMain.mainTabControl.TabPages.Remove(frmMain.mainTabControl.TabPages["tpSanPham"]);
            
        }

        

    }
}
