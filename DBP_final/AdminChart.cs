using Oracle.ManagedDataAccess.Client;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DBP_final
{
    public partial class 통계 : Form
    {
        public 통계()
        {
            InitializeComponent();
            // ListBox 글꼴을 고정 폭 글꼴로 설정
            listBox1.Font = new Font("Courier New", 10);
            listBox2.Font = new Font("Courier New", 10);
            listBox3.Font = new Font("Courier New", 10);
            listBox4.Font = new Font("Courier New", 10);

            LoadGradeDistributionData();
            LoadProfessorCourseCountData();
            LoadStudentCountPerCourseData();
            LoadTopStudentsData();
        }

        private void 통계_Load(object sender, EventArgs e)
        {

        }

        private void LoadGradeDistributionData()
        {
            Chart chart = chart1;
            chart.Series.Clear();
            chart.ChartAreas[0].Name = "GradeDistribution";
            chart.Titles.Clear();
            chart.Titles.Add("학기별 각 과목의 성적 분포");
            listBox1.Items.Clear();
            listBox1.Items.Add("학기    과목명                  성적");
            listBox1.Items.Add("=======================================");

            string connectionString = "User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1";
            string query = "SELECT OPENDATE, C_NAME, FINAL_GRADE FROM DONG1.ENROLL E JOIN DONG1.COURSES C ON E.C_ID = C.C_ID";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        Series series = new Series("성적 분포")
                        {
                            ChartType = SeriesChartType.Point
                        };

                        while (reader.Read())
                        {
                            string semester = reader["OPENDATE"].ToString();
                            string courseName = reader["C_NAME"].ToString().PadRight(20);
                            string grade = reader["FINAL_GRADE"].ToString();
                            int gradeValue = ConvertGradeToValue(grade);

                            series.Points.AddXY($"{semester} {courseName}", gradeValue);
                            listBox1.Items.Add($"{semester,-8} {courseName} {grade}");
                        }

                        chart.Series.Add(series);
                        chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                        chart.ChartAreas[0].AxisX.Interval = 1;
                        chart.Legends[0].Docking = Docking.Top;
                    }
                }
            }
        }

        private void LoadProfessorCourseCountData()
        {
            Chart chart = chart2;
            chart.Series.Clear();
            chart.ChartAreas[0].Name = "ProfessorCourseCount";
            chart.Titles.Clear();
            chart.Titles.Add("각 교수별 강의 과목 수");
            listBox2.Items.Clear();
            listBox2.Items.Add("교수명              과목 수");
            listBox2.Items.Add("===========================");

            string connectionString = "User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1";
            string query = "SELECT P_NAME, COUNT(C_ID) AS CourseCount FROM DONG1.COURSES C JOIN DONG1.PROFESSORS P ON C.CLASS_PRO = P.P_ID GROUP BY P_NAME";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        Series series = new Series("과목 수")
                        {
                            ChartType = SeriesChartType.Pie
                        };

                        while (reader.Read())
                        {
                            string professorName = reader["P_NAME"].ToString().PadRight(18);
                            int courseCount = Convert.ToInt32(reader["CourseCount"]);

                            series.Points.AddXY(professorName.Trim(), courseCount);
                            listBox2.Items.Add($"{professorName} {courseCount}");
                        }

                        chart.Series.Add(series);
                        chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                        chart.ChartAreas[0].AxisX.Interval = 1;
                        chart.Legends[0].Docking = Docking.Top;
                    }
                }
            }
        }

        private void LoadStudentCountPerCourseData()
        {
            Chart chart = chart3;
            chart.Series.Clear();
            chart.ChartAreas[0].Name = "StudentCountPerCourse";
            chart.Titles.Clear();
            chart.Titles.Add("과목당 학생 수");
            listBox3.Items.Clear();
            listBox3.Items.Add("과목명                    학생 수");
            listBox3.Items.Add("=================================");

            string connectionString = "User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1";
            string query = "SELECT C_NAME, COUNT(S_ID) AS StudentCount FROM DONG1.ENROLL E JOIN DONG1.COURSES C ON E.C_ID = C.C_ID GROUP BY C_NAME";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        Series series = new Series("학생 수")
                        {
                            ChartType = SeriesChartType.Bubble
                        };

                        while (reader.Read())
                        {
                            string courseName = reader["C_NAME"].ToString().PadRight(20);
                            int studentCount = Convert.ToInt32(reader["StudentCount"]);

                            series.Points.AddXY(courseName.Trim(), studentCount);
                            listBox3.Items.Add($"{courseName} {studentCount}");
                        }

                        chart.Series.Add(series);
                        chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                        chart.ChartAreas[0].AxisX.Interval = 1;
                        chart.Legends[0].Docking = Docking.Top;
                    }
                }
            }
        }

        private void LoadTopStudentsData()
        {
            Chart chart = chart4;
            chart.Series.Clear();
            chart.ChartAreas[0].Name = "TopStudents";
            chart.Titles.Clear();
            chart.Titles.Add("성적 우수 학생");
            listBox4.Items.Clear();
            listBox4.Items.Add("학생명                평균 성적");
            listBox4.Items.Add("===============================");

            string connectionString = "User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1";
            string query = @"
                SELECT S_NAME, AVG(
                    CASE FINAL_GRADE
                        WHEN 'A' THEN 4.5
                        WHEN 'B' THEN 3.5
                        WHEN 'C' THEN 2.5
                        WHEN 'D' THEN 1.5
                        WHEN 'F' THEN 0.0
                        ELSE NULL
                    END
                ) AS AvgGrade
                FROM DONG1.ENROLL E
                JOIN DONG1.STUDENTS S ON E.S_ID = S.S_ID
                GROUP BY S_NAME
                ORDER BY AvgGrade DESC
                FETCH FIRST 5 ROWS ONLY";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        Series series = new Series("평균 성적")
                        {
                            ChartType = SeriesChartType.Bar
                        };

                        while (reader.Read())
                        {
                            string studentName = reader["S_NAME"].ToString().PadRight(20);
                            double avgGrade = Convert.ToDouble(reader["AvgGrade"]);

                            series.Points.AddXY(studentName.Trim(), avgGrade);
                            listBox4.Items.Add($"{studentName} {avgGrade:F2}");
                        }

                        chart.Series.Add(series);
                        chart.ChartAreas[0].AxisX.Interval = 1;
                        chart.Legends[0].Docking = Docking.Top;
                    }
                }
            }
        }

        private int ConvertGradeToValue(string grade)
        {
            switch (grade)
            {
                case "A": return 90;
                case "B": return 80;
                case "C": return 70;
                case "D": return 60;
                case "F": return 50;
                default: return 0;
            }
        }
    }
}
