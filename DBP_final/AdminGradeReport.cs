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
    public partial class AdminGradeReport : Form
    {
        public AdminGradeReport()
        {
            InitializeComponent();
        }

        private void AdminGradeReport_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'dataSet1.COURSES' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.cOURSESTableAdapter.Fill(this.dataSet1.COURSES);
            // TODO: 이 코드는 데이터를 'dataSet3.ENROLL' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.eNROLLTableAdapter.Fill(this.dataSet3.ENROLL);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 학번과 학기 필터 입력값 가져오기
            string studentId = textBox1.Text;
            string semesterFilter = comboBox1.SelectedItem?.ToString() ?? "전체";

            // 리스트박스 초기화
            listBox1.Items.Clear();

            // 학생 정보 조회 및 출력 준비
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("학번을 입력하세요.");
                return;
            }

            // 학생 이름 가져오기
            string studentName = "";
            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT S_NAME FROM DONG1.STUDENTS WHERE S_ID = :studentId", conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("studentId", studentId));
                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            studentName = reader["S_NAME"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("해당 학번의 학생 정보가 없습니다.");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("학생 정보 조회 실패: " + ex.Message);
                return;
            }

            // 학기 필터 변환
            string opendateFilter = "";
            if (semesterFilter == "1학기")
            {
                opendateFilter = "2024-1";
            }
            else if (semesterFilter == "2학기")
            {
                opendateFilter = "2024-2";
            }

            // 성적 조회 및 평점 계산
            double totalScore = 0.0;
            double totalCredits = 0.0;
            int serialNo = 1;

            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT C.C_ID, C.C_NAME, E.EXAM_SCORE, E.ATT_SCORE, E.ASS_SCORE1, E.ASS_SCORE2, E.FINAL_GRADE, C.OPENDATE, P.P_NAME " +
                               "FROM DONG1.ENROLL E " +
                               "JOIN DONG1.COURSES C ON E.C_ID = C.C_ID " +
                               "JOIN DONG1.PROFESSORS P ON C.CLASS_PRO = P.P_ID " +
                               "WHERE E.S_ID = :studentId";

                if (!string.IsNullOrEmpty(opendateFilter))
                {
                    query += " AND C.OPENDATE = :opendateFilter";
                }

                query += " ORDER BY C.OPENDATE";

                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("studentId", studentId));

                        if (!string.IsNullOrEmpty(opendateFilter))
                        {
                            cmd.Parameters.Add(new OracleParameter("opendateFilter", opendateFilter));
                        }

                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }

                // 성적표 형식 출력
                string semesterDisplay = (semesterFilter == "전체") ? "전체 학기" : semesterFilter;
                listBox1.Items.Add("=============================================================");
                listBox1.Items.Add("                     성 적 표                     ");
                listBox1.Items.Add("=============================================================");
                listBox1.Items.Add($"학번: {studentId}   이름: {studentName}   학기: {semesterDisplay}");
                listBox1.Items.Add("=============================================================");
                listBox1.Items.Add("일련번호 | 과목번호 | 교과목명                | 담당교수      | 등급");
                listBox1.Items.Add("-------------------------------------------------------------");

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string courseId = row["C_ID"].ToString();
                        string courseName = row["C_NAME"].ToString();
                        string professorName = row["P_NAME"].ToString();
                        string finalGrade = row["FINAL_GRADE"].ToString();
                        double credit = 3.0; // 학점을 고정값으로 설정했으나 필요에 따라 DB에서 불러올 수 있음

                        // 등급에 따른 평점 점수 계산
                        double gradePoint = GetGradePoint(finalGrade);
                        totalScore += gradePoint * credit;
                        totalCredits += credit;

                        // 성적표 포맷 설정
                        listBox1.Items.Add($"{serialNo,4}      | {courseId,-8} | {courseName,-15} | {professorName,-8} | {finalGrade,2}   | {credit,3}");
                        serialNo++;
                    }

                    // 총 평점 계산 및 출력
                    double gpa = (totalCredits > 0) ? totalScore / totalCredits : 0.0;
                    listBox1.Items.Add("-------------------------------------------------------------");
                    listBox1.Items.Add($"총 평점(GPA): {gpa:F2} / 4.5");
                }
                else
                {
                    listBox1.Items.Add("해당 학기에 성적 데이터가 없습니다.");
                }

                listBox1.Items.Add("=============================================================");
            }
            catch (Exception ex)
            {
                MessageBox.Show("성적 조회 실패: " + ex.Message);
            }
        }


        // 등급에 따른 평점 계산 함수

        private double GetGradePoint(string grade)
        {
            switch (grade)
            {
                case "A": return 4.0;
                case "B": return 3.0;
                case "C": return 2.0;
                case "D": return 1.0;
                case "F": return 0.0;
                default: return 0.0;
            }
        }




    }
}
