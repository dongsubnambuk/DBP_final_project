using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DBP_final
{
    public partial class StudentGradeView : Form
    {
        private string studentId;
        private System.Windows.Forms.CheckBox checkBoxDetailed;


        public StudentGradeView(string studentId)
        {
            InitializeComponent();
            this.studentId = studentId;

            // studentId 값 확인을 위해 콘솔 또는 메시지 박스에 출력
            Console.WriteLine("전달받은 학번: " + studentId);
            MessageBox.Show("전달받은 학번: " + studentId);
        }

        private void StudentGradeView_Load(object sender, EventArgs e)
        {
            // 학기 선택 콤보 박스 설정
            comboBox1.Items.AddRange(new string[] { "전체", "1학기", "2학기" });
            comboBox1.SelectedIndex = 0; // 기본값을 전체로 설정

            // 학번이 제대로 넘어오는지 확인
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("학번이 전달되지 않았습니다. 프로그램을 다시 시작해 주세요.");
                return;
            }

        

        }

      
        private void LoadStudentGrades(string semester)
        {
            listBox1.Items.Clear(); // 기존 데이터 초기화

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();

                    string semesterCondition = semester == "1학기" ? "2024-1" : semester == "2학기" ? "2024-2" : "전체";

                    // 쿼리 작성
                    string query =
                        "SELECT C.C_NAME, E.EXAM_SCORE, E.ATT_SCORE, E.ASS_SCORE1, E.ASS_SCORE2, E.FINAL_GRADE, C.OPENDATE " +
                        "FROM DONG1.ENROLL E JOIN DONG1.COURSES C ON E.C_ID = C.C_ID WHERE E.S_ID = :studentId";

                    if (semester != "전체")
                    {
                        query += " AND C.OPENDATE = :semester";
                    }

                    query += " ORDER BY C.OPENDATE";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("studentId", studentId));

                        if (semester != "전체")
                        {
                            cmd.Parameters.Add(new OracleParameter("semester", semesterCondition));
                        }

                        OracleDataReader reader = cmd.ExecuteReader();

                        // 성적표 출력 형식 설정
                        listBox1.Items.Add("=============================================================");
                        listBox1.Items.Add("                     성 적 표                     ");
                        listBox1.Items.Add("=============================================================");
                        listBox1.Items.Add($"학번: {studentId}   학기: {semester}");
                        listBox1.Items.Add("=============================================================");
                        listBox1.Items.Add("과목 | 시험 | 출석 | 과제1 | 과제2 | 성적");

                        bool hasResults = false;
                        while (reader.Read())
                        {
                            hasResults = true;
                            listBox1.Items.Add($"{reader["C_NAME"]} | {reader["EXAM_SCORE"]} | {reader["ATT_SCORE"]} | {reader["ASS_SCORE1"]} | {reader["ASS_SCORE2"]} | {reader["FINAL_GRADE"]}");
                        }

                        if (!hasResults)
                        {
                            listBox1.Items.Add("해당 학기에 성적 데이터가 없습니다.");
                        }

                        listBox1.Items.Add("=============================================================");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("성적 조회 실패: " + ex.Message);
            }
        }
    

    private void button1_Click_1(object sender, EventArgs e)
        {
            // 콤보박스와 체크박스 값 확인
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("학기를 선택하세요.");
                return;
            }

            string selectedSemester = comboBox1.SelectedItem.ToString();
            LoadStudentGrades(selectedSemester);
        }
    }
    }
