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
    public partial class StudentClassView : Form
    {
        public StudentClassView()
        {
            InitializeComponent();
        }

        private void StudentClassView_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'dataSet5.COURSES2' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.cOURSES2TableAdapter.Fill(this.dataSet5.COURSES2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 텍스트 박스 값 가져오기
            string professorName = textBox1.Text.Trim();
            string courseCode = textBox2.Text.Trim();
            string courseName = textBox3.Text.Trim();

            // 데이터 그리드 초기화
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();

                    // 동적 쿼리 생성
                    string query = @"SELECT C.C_ID, C.C_NAME, C.OPENDATE, P.P_NAME AS CLASS_PRO_NAME, CL.CLASS_PLACE AS CLASSROOM
                                     FROM COURSES C
                                     JOIN PROFESSORS P ON C.CLASS_PRO = P.P_ID
                                     JOIN CLASSES CL ON C.C_ID = CL.C_ID
                                     WHERE C.OPENDATE = '2024-2'";


                    // 조건 추가
                    if (!string.IsNullOrEmpty(professorName))
                    {
                        query += " AND P.P_NAME LIKE :professorName";
                    }
                    if (!string.IsNullOrEmpty(courseCode))
                    {
                        query += " AND C.C_ID = :courseCode";
                    }
                    if (!string.IsNullOrEmpty(courseName))
                    {
                        query += " AND C.C_NAME LIKE :courseName";
                    }

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // 파라미터 추가
                        if (!string.IsNullOrEmpty(professorName))
                        {
                            cmd.Parameters.Add(new OracleParameter("professorName", "%" + professorName + "%"));
                        }
                        if (!string.IsNullOrEmpty(courseCode))
                        {
                            cmd.Parameters.Add(new OracleParameter("courseCode", courseCode));
                        }
                        if (!string.IsNullOrEmpty(courseName))
                        {
                            cmd.Parameters.Add(new OracleParameter("courseName", "%" + courseName + "%"));
                        }

                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt; // 검색 결과 표시
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("조회 중 오류가 발생했습니다: " + ex.Message);
            }
        }
    }
}

