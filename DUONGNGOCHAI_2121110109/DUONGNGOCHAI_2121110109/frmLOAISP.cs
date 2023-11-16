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
    public partial class frmLOAISP : Form
    {
        public frmLOAISP()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        string str = @"Data Source=DESKTOP-965I83I\NOVELS;Initial Catalog=QLBH;Persist Security Info=True;User ID=sa;Password=2805";
        SqlCommand Command;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable dt = new DataTable();
        void loadDSLOAISP()
        {
            Command = conn.CreateCommand();
            Command.CommandText = "select * from LOAISP";
            adt.SelectCommand = Command;
            dt.Clear();
            adt.Fill(dt);
            dgvDanhSach.DataSource = dt;
        }
        private void frmLOAISP_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            loadDSLOAISP();
        }
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1 || rowindex >= dgvDanhSach.Rows.Count - 1)
                {
                    throw new Exception("Chưa chọn loại sản phẩm");
                }
                txtMaLoai.Text = dgvDanhSach.Rows[rowindex].Cells["MALOAI"].Value.ToString();
                txtTenLoai.Text = dgvDanhSach.Rows[rowindex].Cells["TENLOAI"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ChuoiKN"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SP_ThemLSP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MALOAI", SqlDbType.NVarChar).Value = txtMaLoai.Text;
                cmd.Parameters.Add("@TENLOAI", SqlDbType.NVarChar).Value = txtTenLoai.Text;
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                loadDSLOAISP();
                Reset();
                MessageBox.Show("Thêm loại sản phẩm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoai.Focus();
            }

            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ChuoiKN"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_SuaLSP";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MALOAI", SqlDbType.NVarChar).Value = txtMaLoai.Text;
                    cmd.Parameters.Add("@TENLOAI", SqlDbType.NVarChar).Value = txtTenLoai.Text;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    loadDSLOAISP();
                    Reset();
                    MessageBox.Show("Sửa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoai.Focus();
            }
            else
            {
                try
                {
                    Command = conn.CreateCommand();
                    Command.CommandText = "delete from LOAISP where MALOAI='" + txtMaLoai.Text + "'";
                    Command.ExecuteNonQuery();
                    Reset();
                    loadDSLOAISP();
                    MessageBox.Show("Xóa loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMain.mainTabControl.TabPages.Remove(frmMain.mainTabControl.TabPages["tpLoaiSP"]);
        }
    }
}
