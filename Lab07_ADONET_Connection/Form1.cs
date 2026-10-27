
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab07_ADONET_Connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            // Giữ nguyên hàm này theo cấu trúc ban đầu
            KiemTraKetNoi();
        }

        private void btnKiemTra_Click_1(object sender, EventArgs e)
        {
            KiemTraKetNoi();
        }

        private void KiemTraKetNoi()
        {
            DateTime batDau = DateTime.Now;

            try
            {
                using (SqlConnection conn = DbConnectionFactory.Create())
                {
                    conn.Open();

                    DateTime ketThuc = DateTime.Now;
                    double thoiGian = (ketThuc - batDau).TotalMilliseconds;

                    // Hiển thị thông tin kết nối
                    lblDataSource.Text = "Server: " + conn.DataSource;
                    lblDatabase.Text = "Database: " + conn.Database;
                    lblServerVersion.Text = "Phiên bản SQL Server: "
                        + conn.ServerVersion;
                    lblState.Text = "Trạng thái: " + conn.State;
                    lblThoiGian.Text = "Thời gian kết nối: "
                        + thoiGian.ToString("N2") + " ms";

                    MessageBox.Show(
                        "Kết nối thành công!\n" +
                        "Server: " + conn.DataSource + "\n" +
                        "Database: " + conn.Database,
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                lblState.Text = "Trạng thái: Kết nối thất bại";
                lblThoiGian.Text = "Thời gian kết nối: "
                    + (DateTime.Now - batDau).TotalMilliseconds
                        .ToString("N2") + " ms";

                MessageBox.Show(
                    "Kết nối thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hiển thị trạng thái ban đầu
            lblDataSource.Text = "Server: Chưa kết nối";
            lblDatabase.Text = "Database: Chưa kết nối";
            lblServerVersion.Text = "Phiên bản SQL Server: Chưa có";
            lblState.Text = "Trạng thái: Chưa kiểm tra";
            lblThoiGian.Text = "Thời gian kết nối: Chưa có";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Kiểm tra lại kết nối khi nhấn Làm mới
            KiemTraKetNoi();
        }
    }
}
