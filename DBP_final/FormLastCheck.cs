using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace DBP_final
{
    public partial class FormLastCheck : Form
    {
        public FormLastCheck()
        {
            InitializeComponent();
        }

        private void FormLastCheck_Load(object sender, EventArgs e)
        {
            // 데이터 로드
            this.cOURSEENROLLMENTCOUNTTableAdapter.Fill(this.dataSet11.COURSEENROLLMENTCOUNT);
            this.lASTSEMESTERCOURSESTableAdapter.Fill(this.dataSet11.LASTSEMESTERCOURSES);
            this.coursesTableAdapter1.Fill(this.dataSet11.COURSES);

            // Oracle 연결 설정
            string conString = "USER ID=DONG1; PASSWORD=sds@258079; Data Source=localhost:1521/xepdb1";
            oracleConnection1.ConnectionString = conString;
            oracleConnection1.Open(); // 폼 로드 시 한번만 연결을 엽니다.

            // 기본 OracleCommand 설정
            oracleCommand1.Connection = oracleConnection1;

            // OPEN_DATE 필터링 SQL 쿼리
            string query = @"
        SELECT 
            c.C_NAME AS 과목명,
            COUNT(e.S_ID) AS 신청인원수
        FROM 
            Courses c
        JOIN 
            Enroll e ON c.C_ID = e.C_ID
        WHERE 
            c.OPENDATE = '2024-1'
        GROUP BY 
            c.C_NAME";

            // OracleDataAdapter로 데이터 가져오기
            OracleDataAdapter adapter = new OracleDataAdapter(query, oracleConnection1);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // DataGridView에 바인딩
            dataGridView2.DataSource = dataTable;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // 열 이름 대신 헤더 텍스트를 확인하여 특정 열을 선택
                if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].HeaderText == "과목명")
                {
                    string courseName = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    ShowCourseDetails(courseName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다: " + ex.Message);
            }
        }

        private void ShowCourseDetails(string courseName)
        {
            // ListBox 초기화
            listBox1.Items.Clear();

            try
            {
                // 연결 상태 확인
                if (oracleConnection1.State == ConnectionState.Closed)
                {
                    oracleConnection1.Open();
                }

                // 과목명에 해당하는 상세 정보를 조회하는 쿼리 설정
                oracleCommand1.CommandText = @"
                    SELECT C.C_NAME AS 과목명, C.OPENDATE AS 개설학기, P.P_NAME AS 교수명, CL.CLASS_PLACE AS 강의실
                    FROM Courses C
                    JOIN Professors P ON C.CLASS_PRO = P.P_ID
                    JOIN CLASSES CL ON C.C_ID = CL.C_ID
                    WHERE C.C_NAME = :courseName";

                oracleCommand1.Parameters.Clear(); // 기존 파라미터 초기화
                oracleCommand1.Parameters.Add(new OracleParameter("courseName", courseName)); // 과목명 파라미터 설정

                // 쿼리 실행 및 결과 처리
                using (OracleDataReader reader = oracleCommand1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // 가져온 데이터를 ListBox에 추가
                        listBox1.Items.Add($"과목명: {reader["과목명"]}");
                        listBox1.Items.Add($"개설학기: {reader["개설학기"]}");
                        listBox1.Items.Add($"교수명: {reader["교수명"]}");
                        listBox1.Items.Add($"강의실: {reader["강의실"]}");
                    }
                    else
                    {
                        listBox1.Items.Add("해당 과목의 상세 정보를 찾을 수 없습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터를 불러오는 중 오류가 발생했습니다: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
