using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
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
            listBox1.Font = new Font("Courier New", 14);
            listBox2.Font = new Font("Courier New", 14);
            listBox3.Font = new Font("Courier New", 14);
            listBox4.Font = new Font("Courier New", 14);

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
            chart.Series.Clear(); // 기존 시리즈 초기화
            chart.ChartAreas[0].Name = "GradeDistribution"; // 차트 영역 이름 설정
            chart.Titles.Clear();
            chart.Titles.Add("2024-1 학기 과목별 평균 성적");
            listBox1.Items.Clear();
            listBox1.Items.Add("과목명                  평균 성적");
            listBox1.Items.Add("================================");

            string connectionString = "User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1";
            string query = @"
    SELECT C.C_NAME, 
           AVG(
               CASE FINAL_GRADE
                   WHEN 'A' THEN 4.5
                   WHEN 'B' THEN 3.5
                   WHEN 'C' THEN 2.5
                   WHEN 'D' THEN 1.5
                   WHEN 'F' THEN 0.0
                   ELSE NULL
               END
           ) AS AVG_GRADE
    FROM DONG1.ENROLL E
    JOIN DONG1.COURSES C ON E.C_ID = C.C_ID
    WHERE C.OPENDATE = '2024-1'
    GROUP BY C.C_NAME
    ORDER BY C.C_NAME";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        Series series = new Series("2024-1")
                        {
                            ChartType = SeriesChartType.Bar // 막대형 차트
                        };
                        chart.Series.Add(series);

                        while (reader.Read())
                        {
                            string courseName = reader["C_NAME"].ToString().Trim();
                            double avgGrade = reader["AVG_GRADE"] != DBNull.Value ? Convert.ToDouble(reader["AVG_GRADE"]) : 0.0;

                            // 데이터 추가
                            series.Points.AddXY(courseName, avgGrade);
                            listBox1.Items.Add($"{courseName.PadRight(20)} {avgGrade:F2}");
                        }

                        // 차트 설정
                        chart.ChartAreas[0].AxisX.Interval = 1;
                        chart.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false;
                        chart.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont | LabelAutoFitStyles.WordWrap;
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
            chart.Titles.Add("2024-1 학기 교수별 강의 과목 수");
            listBox2.Items.Clear();
            listBox2.Items.Add("교수명              과목 수");
            listBox2.Items.Add("===========================");

            string connectionString = "User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1";
            string query = @"
    SELECT P.P_NAME, COUNT(C.C_ID) AS CourseCount
    FROM DONG1.COURSES C
    JOIN DONG1.PROFESSORS P ON C.CLASS_PRO = P.P_ID
    WHERE C.OPENDATE = '2024-1'
    GROUP BY P.P_NAME";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        Series series = new Series("2024-1 교수별 강의수")
                        {
                            ChartType = SeriesChartType.Pie
                        };

                        while (reader.Read())
                        {
                            string professorName = reader["P_NAME"].ToString().Trim();
                            int courseCount = Convert.ToInt32(reader["CourseCount"]);

                            DataPoint point = new DataPoint
                            {
                                LegendText = professorName,
                                YValues = new double[] { courseCount },
                                Label = courseCount.ToString()
                            };
                            series.Points.Add(point);

                            listBox2.Items.Add($"{professorName.PadRight(18)} {courseCount}");
                        }

                        chart.Series.Add(series);
                        chart.Legends[0].Docking = Docking.Top;
                        chart.Legends[0].Title = "교수명";
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
            chart.Titles.Add("2024-1 학기 과목당 학생 수");
            listBox3.Items.Clear();
            listBox3.Items.Add("과목명                  학생 수");
            listBox3.Items.Add("================================");

            string connectionString = "User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1";
            string query = @"
    SELECT C.C_NAME, COUNT(E.S_ID) AS StudentCount
    FROM DONG1.ENROLL E
    JOIN DONG1.COURSES C ON E.C_ID = C.C_ID
    WHERE C.OPENDATE = '2024-1'
    GROUP BY C.C_NAME";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        Series series = new Series("2024-1 학생 수")
                        {
                            ChartType = SeriesChartType.Pie
                        };

                        while (reader.Read())
                        {
                            string courseName = reader["C_NAME"].ToString().Trim();
                            int studentCount = Convert.ToInt32(reader["StudentCount"]);

                            DataPoint point = new DataPoint
                            {
                                LegendText = courseName,
                                YValues = new double[] { studentCount },
                                Label = studentCount.ToString()
                            };
                            series.Points.Add(point);

                            listBox3.Items.Add($"{courseName.PadRight(20)} {studentCount}");
                        }

                        chart.Series.Add(series);
                        chart.Legends[0].Docking = Docking.Top;
                        chart.Legends[0].Title = "과목명";
                    }
                }
            }
        }

        private void LoadTopStudentsData()
        {
            Chart chart = chart4;
            chart.Series.Clear();
            chart.Titles.Clear();
            chart.Titles.Add("2024-1 학기 성적 우수 학생");
            chart.ChartAreas[0].Name = "TopStudents";

            listBox4.Items.Clear();
            listBox4.Items.Add("학생명                평균 학점");
            listBox4.Items.Add("===============================");

            string connectionString = "User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1";
            string query = @"
    SELECT 
        S.S_NAME,
        LISTAGG(E.FINAL_GRADE, ',') WITHIN GROUP (ORDER BY E.FINAL_GRADE) AS Grades
    FROM 
        DONG1.ENROLL E
    JOIN 
        DONG1.STUDENTS S ON E.S_ID = S.S_ID
    JOIN 
        DONG1.COURSES C ON E.C_ID = C.C_ID
    WHERE 
        C.OPENDATE = '2024-1'
    GROUP BY 
        S.S_NAME";

            List<(string StudentName, double AvgGrade)> studentData = new List<(string, double)>();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string studentName = reader["S_NAME"]?.ToString() ?? "Unknown";
                            string grades = reader["Grades"]?.ToString() ?? "";

                            // 문자를 숫자로 변환하여 평균 계산
                            double avgGrade = CalculateAverageGrade(grades);
                            studentData.Add((studentName, avgGrade));
                        }
                    }
                }
            }

            // 평균 학점 기준으로 내림차순 정렬
            studentData.Sort((a, b) => b.AvgGrade.CompareTo(a.AvgGrade));

            Series series = new Series("2024-1 평균 학점")
            {
                ChartType = SeriesChartType.Bar
            };

            // 정렬된 데이터를 차트와 리스트박스에 추가
            foreach (var (StudentName, AvgGrade) in studentData)
            {
                series.Points.AddXY(StudentName.Trim(), AvgGrade);
                listBox4.Items.Add($"{StudentName,-20} {AvgGrade:F2}");
            }

            chart.Series.Add(series);

            // 차트 설정: Y축에 내림차순으로 표시
            chart.Series[0]["BarLabelStyle"] = "Center"; // 막대 내부에 레이블 표시
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.IsReversed = true; // X축(학생명) 내림차순
            chart.ChartAreas[0].AxisY.IsReversed = false; // Y축(평균 학점) 오름차순
            chart.Legends[0].Docking = Docking.Top;
        }

        /// <summary>
        /// 문자의 등급 리스트를 숫자로 변환하여 평균 계산
        /// </summary>
        /// <param name="grades">콤마로 구분된 등급 문자열 (예: "A,B,C")</param>
        /// <returns>평균 학점</returns>
        private double CalculateAverageGrade(string grades)
        {
            if (string.IsNullOrWhiteSpace(grades)) return 0.0;

            string[] gradeArray = grades.Split(','); // 등급을 배열로 분리
            double total = 0.0;
            int count = 0;

            foreach (string grade in gradeArray)
            {
                total += GradeToNumeric(grade.Trim()); // 등급을 숫자로 변환하여 합산
                count++;
            }

            return count > 0 ? total / count : 0.0; // 평균 계산
        }

        /// <summary>
        /// 개별 등급(A, B, C 등)을 숫자 값으로 변환
        /// </summary>
        /// <param name="grade">문자 등급 (예: "A")</param>
        /// <returns>숫자 값</returns>
        private double GradeToNumeric(string grade)
        {
            switch (grade)
            {
                case "A":
                    return 4.5;
                case "B":
                    return 3.5;
                case "C":
                    return 2.5;
                case "D":
                    return 1.5;
                case "F":
                    return 0.0;
                default:
                    return 0.0; // 알 수 없는 등급은 0.0으로 처리
            }
        }


    }
}