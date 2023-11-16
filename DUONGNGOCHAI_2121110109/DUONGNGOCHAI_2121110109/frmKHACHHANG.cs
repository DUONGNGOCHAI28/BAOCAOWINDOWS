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
    public partial class frmKHACHHANG : Form
    {
        public frmKHACHHANG()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        string str = @"Data Source=DESKTOP-965I83I\NOVELS;Initial Catalog=QLBH;Persist Security Info=True;User ID=sa;Password=2805";
        SqlCommand Command;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable dt = new DataTable();
        void loadDSKH()
        {
            Command = conn.CreateCommand();
            Command.CommandText = "select * from KHACHHANG";
            adt.SelectCommand = Command;
            dt.Clear();
            adt.Fill(dt);
            dgvDanhSach.DataSource = dt;
        }
        private void frmKHACHHANG_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            loadDSKH();
        }

        private void Reset()
        {
            txtMKH.Text = "";
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtDoanhSo.Text = "";
            dtgNgDK.Text = "";
            dtgNgaySinh.Text = "";
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1 || rowindex >= dgvDanhSach.Rows.Count - 1)
                {
                    throw new Exception("Chưa chọn khách hàng");
                }
                txtMKH.Text = dgvDanhSach.Rows[rowindex].Cells["MAKH"].Value.ToString();
                txtHoTen.Text = dgvDanhSach.Rows[rowindex].Cells["HOTEN"].Value.ToString();
                txtSDT.Text = dgvDanhSach.Rows[rowindex].Cells["SODT"].Value.ToString();
                txtDiaChi.Text = dgvDanhSach.Rows[rowindex].Cells["DCHI"].Value.ToString();
                txtDoanhSo.Text = dgvDanhSach.Rows[rowindex].Cells["DOANHSO"].Value.ToString();
                dtgNgDK.Text = dgvDanhSach.Rows[rowindex].Cells["NGDK"].Value.ToString();
                dtgNgaySinh.Text = dgvDanhSach.Rows[rowindex].Cells["NGSINH"].Value.ToString();
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

                cmd.CommandText = "SP_ThemKH";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = txtMKH.Text;
                cmd.Parameters.Add("@HOTEN", SqlDbType.NVarChar).Value = txtHoTen.Text;
                cmd.Parameters.Add("@SODT", SqlDbType.NVarChar).Value = txtSDT.Text;
                cmd.Parameters.Add("@DCHI", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                cmd.Parameters.Add("@DOANHSO", SqlDbType.Money).Value = txtDoanhSo.Text;
                cmd.Parameters.Add("@NGDK", SqlDbType.DateTime).Value = dtgNgDK.Value.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@NGSINH", SqlDbType.DateTime).Value = dtgNgaySinh.Value.ToString("yyyy/MM/dd");

                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                loadDSKH();
                Reset();
                MessageBox.Show("Thêm khách hàng mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMKH.Focus();
            }
            else
            {
                try
                {
                    Command = conn.CreateCommand();
                    Command.CommandText = "update KHACHHANG set HOTEN=N'" + txtHoTen.Text + "',SODT=N'" + txtSDT.Text + "',DCHI=N'" + txtDiaChi.Text + "',DOANHSO='"+ txtDoanhSo.Text + "' where MAKH='" + txtMKH.Text + "'";
                    Command.ExecuteNonQuery(); ;
                    loadDSKH();
                    Reset();
                    MessageBox.Show("Đã sửa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập khách hàng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMKH.Focus();
            }

            else
            {
                try
                {
                    Command = conn.CreateCommand();
                    Command.CommandText = "delete from KHACHHANG where MAKH='" + txtMKH.Text + "'";
                    Command.ExecuteNonQuery();
                    loadDSKH();
                    Reset();
                    MessageBox.Show("Xóa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMain.mainTabControl.TabPages.Remove(frmMain.mainTabControl.TabPages["tpKhachHang"]);

        }
    }
}
