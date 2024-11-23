using FontAwesome.Sharp;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBP_final
{
    public partial class StudentEnroll : Form
    {
        private string studentId;
        private int timeLeft = 50; // 50초
        public StudentEnroll(string studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            // 폼 로드 시 등록된 과목 목록을 표시
            LoadEnrolledCourses();
        }

        private void StudentEnroll_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'dataSet5.COURSES2' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.cOURSES2TableAdapter.Fill(this.dataSet5.COURSES2);
            timer1.Interval = 1000; // 1초마다 호출
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            // 남은 시간 표시
            UpdateTimerLabel();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--; // 1초 감소
                UpdateTimerLabel(); // Label에 남은 시간 갱신
            }
            else
            {
                timer1.Stop(); // 타이머 중지

                // 메시지 박스 표시
                DialogResult result = MessageBox.Show(
                    "50초가 경과하였습니다. 재접속 해주세요.",
                    "시간 초과",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Reset() 호출
                Reset();

            }
        }

        private void Reset()
        {
            // 현재 폼 숨기기
            this.Hide();
        }



        private void UpdateTimerLabel()
        {
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            label4.Text = $"{minutes:D2}:{seconds:D2}"; // MM:SS 형식으로 표시
        }


        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            string courseCode = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(courseCode))
            {
                MessageBox.Show("과목 코드를 입력하세요.");
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();

                    // 이미 등록된 과목인지 확인
                    string checkQuery = "SELECT FINAL_GRADE FROM ENROLL WHERE S_ID = :studentId AND C_ID = :courseCode";
                    using (OracleCommand checkCmd = new OracleCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add(new OracleParameter("studentId", studentId));
                        checkCmd.Parameters.Add(new OracleParameter("courseCode", courseCode));

                        var result = checkCmd.ExecuteScalar();
                        if (result != null)
                        {
                            if (!string.IsNullOrEmpty(result.ToString()))
                            {
                                MessageBox.Show("이미 학점을 받은 과목이므로 재등록할 수 없습니다.");
                            }
                            else
                            {
                                MessageBox.Show("이미 등록된 과목입니다.");
                            }
                            return;
                        }
                    }

                    // 신청 가능 학기인지 확인
                    string semesterCheckQuery = "SELECT OPENDATE FROM COURSES WHERE C_ID = :courseCode";
                    using (OracleCommand semesterCheckCmd = new OracleCommand(semesterCheckQuery, conn))
                    {
                        semesterCheckCmd.Parameters.Add(new OracleParameter("courseCode", courseCode));

                        var opendate = semesterCheckCmd.ExecuteScalar()?.ToString();
                        if (opendate == "2024-1") // 특정 학기(2024-1)에 대해 신청 제한
                        {
                            MessageBox.Show("2024-1 학기의 과목은 현재 신청할 수 없습니다.");
                            return;
                        }
                    }

                    // 수강 등록 쿼리
                    string insertQuery = "INSERT INTO ENROLL (S_ID, C_ID) VALUES (:studentId, :courseCode)";
                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("studentId", studentId));
                        cmd.Parameters.Add(new OracleParameter("courseCode", courseCode));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("수강 신청이 완료되었습니다.");
                            LoadEnrolledCourses(); // 수강 신청 후 과목 목록 갱신
                        }
                        else
                        {
                            MessageBox.Show("수강 신청에 실패하였습니다.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("수강 신청 중 오류가 발생했습니다: " + ex.Message);
            }
        }




        private void EnrollmentForm_Load(object sender, EventArgs e)
        {
            LoadEnrolledCourses();
        }

        private void LoadEnrolledCourses()
        {
            listBox1.Items.Clear(); // 기존 데이터 초기화

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();

                    string query = @"SELECT C.C_NAME, C.OPENDATE, CL.CLASS_PLACE, P.P_NAME 
                             FROM ENROLL E 
                             JOIN COURSES C ON E.C_ID = C.C_ID 
                             JOIN CLASSES CL ON C.C_ID = CL.C_ID
                             JOIN PROFESSORS P ON C.CLASS_PRO = P.P_ID
                             WHERE E.S_ID = :studentId AND C.OPENDATE='2024-2'
                             ORDER BY C.C_ID";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("studentId", studentId));
                        OracleDataReader reader = cmd.ExecuteReader();

                        // 헤더 및 구분선 출력
                        listBox1.Items.Add("=========================================");
                        listBox1.Items.Add("           수강 신청한 과목 상세           ");
                        listBox1.Items.Add("=========================================");
                        listBox1.Items.Add(string.Format("{0,-20} | {1,-8} | {2,-6} | {3,-10}", "과목명", "개설학기", "강의실", "교수명"));

                        while (reader.Read())
                        {
                            string courseName = reader["C_NAME"].ToString();
                            string openDate = reader["OPENDATE"].ToString();
                            string classPlace = reader["CLASS_PLACE"].ToString();
                            string professorName = reader["P_NAME"].ToString();

                            // 텍스트를 잘라서 지정된 칸 너비로 맞춤
                            listBox1.Items.Add(string.Format("{0,-20} | {1,-8} | {2,-6} | {3,-10}",
                                Truncate(courseName, 20),
                                Truncate(openDate, 8),
                                Truncate(classPlace, 6),
                                Truncate(professorName, 10)));
                        }

                        listBox1.Items.Add("=========================================");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("수강 목록 조회 중 오류가 발생했습니다: " + ex.Message);
            }
        }

        // 문자열을 최대 길이로 잘라내는 헬퍼 메소드
        private string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            string courseCode = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(courseCode))
            {
                MessageBox.Show("과목 코드를 입력하세요.");
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();

                    // 이미 등록한 과목인지 확인
                    string checkQuery = "SELECT FINAL_GRADE FROM ENROLL WHERE S_ID = :studentId AND C_ID = :courseCode";
                    using (OracleCommand checkCmd = new OracleCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add(new OracleParameter("studentId", studentId));
                        checkCmd.Parameters.Add(new OracleParameter("courseCode", courseCode));

                        var result = checkCmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("해당 과목은 수강 신청되지 않았습니다.");
                            return;
                        }
                    }

                    // 수강 취소(삭제) 쿼리
                    string deleteQuery = "DELETE FROM ENROLL WHERE S_ID = :studentId AND C_ID = :courseCode";
                    using (OracleCommand cmd = new OracleCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("studentId", studentId));
                        cmd.Parameters.Add(new OracleParameter("courseCode", courseCode));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("수강 취소가 완료되었습니다.");
                            LoadEnrolledCourses(); // 취소 후 과목 목록 갱신
                        }
                        else
                        {
                            MessageBox.Show("수강 취소에 실패하였습니다.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("수강 취소 중 오류가 발생했습니다: " + ex.Message);
            }
        }
    }
}
    