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
        private List<string> notices = new List<string>(); // 공지사항 목록
        private int currentNoticeIndex = 0; // 현재 표시 중인 공지사항 인덱스
        private bool isLabelVisible = true; // 라벨 깜빡거림 상태

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
   
     


        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadStudentName();
            LoadNoticesForLabel(); // 공지사항 목록 로드
            timer1.Interval = 3000; // 3초 간격으로 변경
            timer1.Start(); // 타이머 시작
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

        private void LoadNoticesForLabel()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();
                    string query = "SELECT TITLE, CONTENT FROM NOTICES ORDER BY CREATED_AT DESC";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            notices.Clear(); // 기존 공지사항 목록 초기화
                            while (reader.Read())
                            {
                                string title = reader["TITLE"].ToString();
                                string content = reader["CONTENT"].ToString();
                                notices.Add($"[공지] {title}: {content}"); // 제목과 내용을 조합하여 저장
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"공지사항 로드 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (notices.Count == 0)
            {
                label4.Text = "등록된 공지사항이 없습니다."; // 공지사항이 없을 경우
                label4.Visible = isLabelVisible;
                isLabelVisible = !isLabelVisible; // 깜빡거리게 하기
                return;
            }

            // 현재 공지사항 표시
            string noticeText = notices[currentNoticeIndex];

            // 보이는 길이를 픽스하고 넘어가면 다음 줄로 넘어가도록 처리
            int maxWidth = 300; // 라벨의 최대 가로 길이 (픽셀 단위로 설정)
            int fontHeight = label4.Font.Height; // 한 줄의 높이 계산
            List<string> wrappedText = WrapText(noticeText, label4.Font, maxWidth);

            // 라벨에 텍스트 추가
            label4.Text = string.Join("\n", wrappedText);
            label4.Height = wrappedText.Count * fontHeight; // 라벨의 높이를 텍스트 줄 수에 맞춤

            label4.Visible = true;

            // 다음 공지사항으로 이동 (순환)
            currentNoticeIndex = (currentNoticeIndex + 1) % notices.Count;
            isLabelVisible = false; // 다음 단계에서 숨기도록 설정
        }

        // 텍스트 줄 바꿈 처리 함수
        private List<string> WrapText(string text, Font font, int maxWidth)
        {
            List<string> lines = new List<string>();
            string[] words = text.Split(' ');
            string currentLine = "";

            foreach (string word in words)
            {
                string testLine = string.IsNullOrEmpty(currentLine) ? word : $"{currentLine} {word}";
                Size textSize = TextRenderer.MeasureText(testLine, font);

                if (textSize.Width > maxWidth)
                {
                    if (!string.IsNullOrEmpty(currentLine))
                    {
                        lines.Add(currentLine);
                        currentLine = word;
                    }
                    else
                    {
                        // 단어 자체가 너무 길 경우
                        lines.Add(word);
                        currentLine = "";
                    }
                }
                else
                {
                    currentLine = testLine;
                }
            }

            if (!string.IsNullOrEmpty(currentLine))
            {
                lines.Add(currentLine);
            }

            return lines;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }
    }
}
