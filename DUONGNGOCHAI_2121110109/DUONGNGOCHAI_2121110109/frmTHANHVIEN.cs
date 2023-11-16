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
using System.Windows.Forms.VisualStyles;

namespace DUONGNGOCHAI_2121110109
{
    public partial class frmTHANHVIEN : Form
    {
        SqlConnection conn;
        string str = @"Data Source=DESKTOP-965I83I\NOVELS;Initial Catalog=QLBH;Persist Security Info=True;User ID=sa;Password=2805";
        SqlCommand Command;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable dt = new DataTable();
        void loadDSTHANHVIEN()
        {
            Command = conn.CreateCommand();
            Command.CommandText = "select * from THANHVIEN";
            adt.SelectCommand = Command;
            dt.Clear();
            adt.Fill(dt);
            dgvDanhSach.DataSource = dt;
        }
        public frmTHANHVIEN()
        {
            InitializeComponent();
        }

        private void frmTHANHVIEN_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            loadDSTHANHVIEN();
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1 || rowindex >= dgvDanhSach.Rows.Count - 1)
                {
                    throw new Exception("Chưa chọn thành viên");
                }
                mtxtMaNV.Text = dgvDanhSach.Rows[rowindex].Cells["MaNV"].Value.ToString();
                txtMatKhau.Text = dgvDanhSach.Rows[rowindex].Cells["MatKhau"].Value.ToString();
                txtHoTen.Text = dgvDanhSach.Rows[rowindex].Cells["HoTen"].Value.ToString();
                mtxtSoDienThoai.Text = dgvDanhSach.Rows[rowindex].Cells["Sodt"].Value.ToString();
                dtgNgayVaoLam.Text = dgvDanhSach.Rows[rowindex].Cells["Ngvl"].Value.ToString();
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

                cmd.CommandText = "SP_ThemTV";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = mtxtMaNV.Text;
                cmd.Parameters.Add("@MATKHAU", SqlDbType.Int).Value = int.Parse(txtMatKhau.Text);
                cmd.Parameters.Add("@HOTEN", SqlDbType.NVarChar).Value = txtHoTen.Text;
                cmd.Parameters.Add("@SODT", SqlDbType.NVarChar).Value = mtxtSoDienThoai.Text;
                cmd.Parameters.Add("@NGVL", SqlDbType.Date).Value = dtgNgayVaoLam.Value.ToString("yyyy/MM/dd");

                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                loadDSTHANHVIEN();
                Reset();
                MessageBox.Show("Thêm thành viên mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMain.mainTabControl.TabPages.Remove(frmMain.mainTabControl.TabPages["tpThanhVien"]);
        }

        private void Reset()
        {
            mtxtMaNV.Text = "";
            txtHoTen.Text = "";
            txtMatKhau.Text = "";
            mtxtSoDienThoai.Text = "";
            dtgNgayVaoLam.Text = "";
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (mtxtMaNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã thành viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtxtMaNV.Focus();
            }
            else
            {
                try
                {
                    Command=conn.CreateCommand();
                    Command.CommandText="delete from THANHVIEN where MaNV='"+mtxtMaNV.Text+"'";
                    Command.ExecuteNonQuery();
                    Reset();
                    loadDSTHANHVIEN();
                    MessageBox.Show("Xóa thành viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (mtxtMaNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtxtMaNV.Focus();
            }
            else if (KTThongTin())
            {
                try
                {
                    Command = conn.CreateCommand();
                    Command.CommandText = "update THANHVIEN set HOTEN=N'" + txtHoTen.Text + "',MATKHAU=N'" + txtMatKhau.Text + "',SODT=N'" + txtMatKhau.Text + "' where MaNV='" + mtxtMaNV.Text + "'";
                    Command.ExecuteNonQuery(); ;
                    loadDSTHANHVIEN();
                    Reset();
                    MessageBox.Show("Đã sửa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public bool KTThongTin()
        {
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return false;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Focus();
                return false;
            }
            if (mtxtSoDienThoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập SĐT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtxtSoDienThoai.Focus();
                return false;
            }
            return true;
        }
    }
}
