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
    public partial class frmCTHD : Form
    {
        public frmCTHD()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        string str = @"Data Source=DESKTOP-965I83I\NOVELS;Initial Catalog=QLBH;Persist Security Info=True;User ID=sa;Password=2805";
        SqlCommand Command;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable dt = new DataTable();
        void loadDSCTHD()
        {
            Command = conn.CreateCommand();
            Command.CommandText = "select * from HOADON";
            adt.SelectCommand = Command;
            dt.Clear();
            adt.Fill(dt);
            dgvDanhSach.DataSource = dt;
        }
        private void frmCTHD_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            loadDSCTHD();
        }

        private void Reset()
        {
            txtSoHD.Text = "";
            txtMaKhachHang.Text = "";
            txtMaTV.Text = "";
            mtxtGia.Text = "";
            dtgNgayHD.Text = "";
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
                txtMaKhachHang.Text = dgvDanhSach.Rows[rowindex].Cells["MaKH"].Value.ToString();
                txtMaTV.Text = dgvDanhSach.Rows[rowindex].Cells["MaNV"].Value.ToString();
                mtxtGia.Text = dgvDanhSach.Rows[rowindex].Cells["TriGia"].Value.ToString();
                dtgNgayHD.Text = dgvDanhSach.Rows[rowindex].Cells["NgHD"].Value.ToString();
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

                cmd.CommandText = "SP_ThemCTHD";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SOHD", SqlDbType.Int).Value = int.Parse(txtSoHD.Text);
                cmd.Parameters.Add("@NGHD", SqlDbType.DateTime).Value = dtgNgayHD.Value.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = txtMaKhachHang.Text;
                cmd.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = txtMaTV.Text;
                cmd.Parameters.Add("@TRIGIA", SqlDbType.Money).Value =mtxtGia.Text;

                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                loadDSCTHD();
                Reset();
                MessageBox.Show("Thêm thành viên mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng nhập hóa đơn cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHD.Focus();
            }
            else
            {
                try
                {
                    Command = conn.CreateCommand();
                    Command.CommandText = "update HOADON set NGHD='" + dtgNgayHD.Text + "',MAKH='" + txtMaKhachHang.Text + "',MANV='" + txtMaTV.Text + "',TRIGIA='" + mtxtGia.Text + "' where SOHD='" + txtSoHD.Text + "'";
                    Command.ExecuteNonQuery(); ;
                    loadDSCTHD();
                    Reset();
                    MessageBox.Show("Đã sửa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng nhập hóa đơn cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHD.Focus();
            }
            else
            {
                try
                {
                    Command = conn.CreateCommand();
                    Command.CommandText = "delete from HOADON where SOHD='" + txtSoHD.Text + "'";
                    Command.ExecuteNonQuery();
                    Reset();
                    loadDSCTHD();
                    MessageBox.Show("Xóa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMain.mainTabControl.TabPages.Remove(frmMain.mainTabControl.TabPages["tpChiTietHoaDon"]);
        }
    }
}
