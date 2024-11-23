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
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace DBP_final
{
    public partial class AdminForm : Form
    {
        private Timer timer;
        private string adminId;
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public AdminForm(string adminId)
        {
            InitializeComponent();
            InitializeTimer();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panel1.Controls.Add(leftBorderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.adminId = adminId; 
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1초마다 업데이트
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString(" HH:mm:ss"); // 현재 시간을 "연-월-일 시:분:초" 형식으로 표시
            label3.Text = DateTime.Now.ToString(" yyyy년MM월dd일"); // 현재 시간을 "연-월-일 시:분:초" 형식으로 표시
        }
        private struct RGBcolors
        {
            public static Color color1 = Color.FromArgb(40, 60, 90);    // 진한 네이비 블루 계열로 조정
            public static Color color2 = Color.FromArgb(150, 160, 200); // 부드러운 회보라 톤으로 조정
            public static Color color3 = Color.FromArgb(50, 80, 120);   // 짙은 블루-그레이 계열로 변경
            public static Color color4 = Color.FromArgb(120, 170, 240); // 기존보다 파란 계열을 강조한 연한 블루
            public static Color color5 = Color.FromArgb(180, 210, 180); // 밝은 올리브 톤으로 변경
            public static Color color6 = Color.FromArgb(140, 180, 180); // 민트-그레이 계열로 밝게 조정

        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if(senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(235, 245, 251);
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

                currentBtn.BackColor = Color.FromArgb(103, 153, 255);
                currentBtn.ForeColor = Color.FromArgb(245, 247, 250);

                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.ForeColor = Color.FromArgb(245, 247, 250);

                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null) { 
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

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadAdminName();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            OpenChildForm(new FormLastCheck());
      
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            lblTitleChildForm.Text = "Home";
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

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

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color5);
            OpenChildForm(new 통계());
        }



        private void LoadAdminName()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();

                    string query = "SELECT P_NAME FROM PROFESSORS WHERE P_ID = :adminId";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("adminId", adminId));

                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            label2.Text = reader["P_NAME"].ToString(); // label2에 학생 이름 표시
                        }
                        else
                        {
                            label2.Text = "관리자 정보를 찾을 수 없습니다.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("관리자 이름 로드 중 오류가 발생했습니다: " + ex.Message);
            }
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close(); // 현재 창 닫기
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color6);
            OpenChildForm(new AdminNotice());
        }
    }
}
