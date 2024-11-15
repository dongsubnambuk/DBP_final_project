using FontAwesome.Sharp;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace DBP_final
{
    public partial class StudentForm : Form
    {
        private string studentId;
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public StudentForm(string studentId)
        {
            InitializeComponent();
            this.studentId = studentId;

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panel1.Controls.Add(leftBorderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private struct RGBcolors
        {

            public static Color color1 = Color.FromArgb(44, 62, 80);
            public static Color color2 = Color.FromArgb(142, 140, 167);
            public static Color color3 = Color.FromArgb(52, 73, 94);
            public static Color color4 = Color.FromArgb(133, 173, 205);
            public static Color color5 = Color.FromArgb(171, 196, 171);
            public static Color color6 = Color.FromArgb(130, 158, 158);
        }


        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(255, 150, 150);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;


            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {

                currentBtn.BackColor = Color.FromArgb(255, 127, 127);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }
        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            OpenChildForm(new StudentGradeView(studentId));

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color2);
            OpenChildForm(new AdminPlus());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color3);
            OpenChildForm(new AdminGradeInput());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color4);
            OpenChildForm(new AdminGradeReport());
        }


        private void StudentForm_Load(object sender, EventArgs e)
        {
          
            LoadStudentName();
            timer1.Interval = 1000; //1초마다 깜빡임
            timer1.Start();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;

            iconCurrentChildForm.IconChar = IconChar.House;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Students";
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParm);


        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }




        //지난학기 조회
        private void iconButton6_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            OpenChildForm(new StudentGradeView(studentId));
        }


        //강의 시간표조회
        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color3);
            OpenChildForm(new StudentClassView());
        }


        //수강신청
        private void iconButton3_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color2);
            OpenChildForm(new StudentEnroll(studentId));
        }


        private void iconButton4_Click_1(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            // Form1으로 이동
            Form1 form1 = new Form1();
            form1.Show();
            this.Close(); // 현재 창 닫기
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadStudentName()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();

                    string query = "SELECT S_NAME FROM STUDENTS WHERE S_ID = :studentId";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("studentId", studentId));

                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            label2.Text = reader["S_NAME"].ToString(); // label2에 학생 이름 표시
                        }
                        else
                        {
                            label2.Text = "학생 정보를 찾을 수 없습니다.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("학생 이름 로드 중 오류가 발생했습니다: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Visible=!label3.Visible;
        }
    }
}
