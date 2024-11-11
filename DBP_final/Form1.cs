using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBP_final
{
    public partial class Form1 : Form
    {

    
        public Form1()
        {
            InitializeComponent();
       
        }

  
        private void Form1_Load(object sender, EventArgs e)
        {
            string conString = "USER ID =DONG1; PASSWORD=sds@258079;" +
                "Data source = localhost:1521/xepdb1";
            oracleConnection1.ConnectionString = conString;
            oracleConnection1.Open();

            oracleCommand1.CommandText = oracleConnection1.ConnectionString;
            oracleCommand1.Connection = oracleConnection1;
            //textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userID = textBox1.Text;
            string password = textBox2.Text;

            // 패스워드 고정
            if (password == "qwer1234")
            {
                // 관리자인 경우 (교수 인사번호)
                oracleCommand1.CommandText = $"SELECT * FROM PROFESSORS WHERE P_ID = {userID}";
                OracleDataReader reader = oracleCommand1.ExecuteReader();
                if (reader.Read())
                {
                    string isAdmin = reader["IS_ADMIN"].ToString();

                    if (isAdmin == "Y")
                    {
                        // 관리자 폼 열기
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        // 권한이 없는 경우
                        MessageBox.Show("권한이 없습니다.");
                    }
                }
                else
                {
                    // 학생인 경우 (학번)
                    oracleCommand1.CommandText = $"SELECT * FROM STUDENTS WHERE S_ID = {userID}";
                    reader = oracleCommand1.ExecuteReader();
                    if (reader.Read())
                    {
                        // 학생 폼 열기
                        StudentForm studentForm = new StudentForm();
                        studentForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("로그인 정보가 올바르지 않습니다.");
                    }
                }
            }
            else
            {
                MessageBox.Show("패스워드가 올바르지 않습니다.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
