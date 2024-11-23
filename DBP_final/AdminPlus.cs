using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace DBP_final
{
    public partial class AdminPlus : Form
    {
        private const int STEP_SLIDING = 5;
        private const int MIN_SLIDING_WIDTH = 50;
        private const int MAX_SLIDING_WIDTH = 200;
        private int _posSliding = MIN_SLIDING_WIDTH;

        public AdminPlus()
        {
            InitializeComponent();
            panelSideMenu.Width = MIN_SLIDING_WIDTH;

            // 초기 로드 시 메뉴 숨기기
            foreach (Control ctrl in panelSideMenu.Controls)
            {
                if (ctrl != checkBoxHide)
                {
                    ctrl.Visible = false;
                }
            }
            checkBoxHide.Checked = true; // 기본 상태 설정
        }

        private void AdminPlus_Load(object sender, EventArgs e)
        {
            try
            {
                // PROFESSORS 테이블 데이터 로드
                this.pROFESSORSTableAdapter.Fill(this.dataSet7.PROFESSORS);

                // COURSES 테이블 데이터 로드
                this.cOURSESTableAdapter.Fill(this.dataSet1.COURSES);

                // COURSES2 테이블 데이터 로드
                this.cOURSES2TableAdapter.Fill(this.dataSet5.COURSES2);

                // COURSESWITHPROFESSORNAME 테이블 데이터 로드
                this.cOURSESWITHPROFESSORNAMETableAdapter.Fill(this.dataSet2.COURSESWITHPROFESSORNAME);

                // DataTable에서 OPENDATE = '2024-2' 데이터 필터링
                DataTable coursesTable = this.dataSet1.COURSES;
                DataView filteredView = new DataView(coursesTable)
                {
                    RowFilter = "OPENDATE = '2024-2'",
                    Sort = "C_ID " // C_ID 기준 내림차순 정렬
                };

                // DataGridView3에 필터링된 데이터 바인딩
                dataGridView3.AutoGenerateColumns = true;
                dataGridView3.DataSource = filteredView;


            }
            catch (Exception ex)
            {
                // 오류 처리
                MessageBox.Show("데이터 로드 중 오류가 발생했습니다: " + ex.Message);
            }
        }


        //강의 생성
        private void button1_Click(object sender, EventArgs e)
        {
            // 강의 개설
            DataTable mytable = dataSet1.Tables["COURSES"];
            DataRow mynewDataRow = mytable.NewRow();
            mynewDataRow["C_ID"] = textBox1.Text;
            mynewDataRow["C_NAME"] = textBox2.Text;
            mynewDataRow["OPENDATE"] = textBox3.Text;
            mynewDataRow["CLASS_PRO"] = textBox4.Text;
            mytable.Rows.Add(mynewDataRow);
            cOURSESTableAdapter.Update(dataSet1.COURSES);
            MessageBox.Show("강의 개설과 교수님 배정이 완료되었습니다. 강의실 배정해주세요.");
        }

        //강의실 배정 버튼

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 강의실 배정
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();

                    // 데이터 삽입 쿼리
                    string insertQuery = @"
                INSERT INTO CLASSES (CLASS_ID, C_ID, CLASS_DATE, CLASS_PLACE)
                VALUES (:classId, :courseId, :classDate, :classPlace)";

                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("classId", textBox8.Text.Trim()));
                        cmd.Parameters.Add(new OracleParameter("courseId", textBox7.Text.Trim()));
                        cmd.Parameters.Add(new OracleParameter("classDate", textBox6.Text.Trim()));
                        cmd.Parameters.Add(new OracleParameter("classPlace", textBox5.Text.Trim()));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("강의실 배정이 완료되었습니다.");
                        }
                        else
                        {
                            MessageBox.Show("강의실 배정에 실패했습니다.");
                            return;
                        }
                    }
                }

                // 데이터 업데이트 및 DataGridView 새로 고침
                this.cOURSESWITHPROFESSORNAMETableAdapter.Fill(this.dataSet2.COURSESWITHPROFESSORNAME);
                this.cOURSES2TableAdapter.Fill(this.dataSet5.COURSES2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }


        private void checkBoxHide_CheckedChanged_1(object sender, EventArgs e)
        {
            // 메뉴 토글
            if (checkBoxHide.Checked)
            {
                foreach (Control ctrl in panelSideMenu.Controls)
                {
                    if (ctrl != checkBoxHide)
                    {
                        ctrl.Visible = false;
                    }
                }
                checkBoxHide.Text = "+";
            }
            else
            {
                foreach (Control ctrl in panelSideMenu.Controls)
                {
                    ctrl.Visible = true;
                }
                checkBoxHide.Text = "X";
            }
            timerSliding.Start();
        }

        private void timerSliding_Tick_1(object sender, EventArgs e)
        {
            timerSliding.Interval = 10;

            // 메뉴 애니메이션
            if (checkBoxHide.Checked)
            {
                _posSliding -= STEP_SLIDING;
                if (_posSliding <= MIN_SLIDING_WIDTH)
                {
                    panelSideMenu.Width = MIN_SLIDING_WIDTH;
                    timerSliding.Stop();
                }
            }
            else
            {
                _posSliding += STEP_SLIDING;
                if (_posSliding >= MAX_SLIDING_WIDTH)
                {
                    panelSideMenu.Width = MAX_SLIDING_WIDTH;
                    timerSliding.Stop();
                }
            }
            panelSideMenu.Width = _posSliding;
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 유효한 행인지 확인
            if (e.RowIndex >= 0)
            {
                // 열의 헤더 텍스트를 기반으로 "과목명" 열인지 확인
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "과목명")
                {
                    // 선택된 셀의 값을 가져옴
                    string courseName = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                    if (!string.IsNullOrEmpty(courseName))
                    {
                        ShowCourseDetails(courseName); // 과목 상세 정보 표시
                    }
                    else
                    {
                        MessageBox.Show("선택한 셀에 유효한 과목명이 없습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("해당 열은 '과목명' 열이 아닙니다.");
                }
            }
        }


        private void ShowCourseDetails(string courseName)
        {
            try
            {
                // 데이터베이스 연결
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();

                    // 과목명을 기준으로 상세 정보 조회
                    string query = "SELECT * FROM COURSES WHERE C_NAME = :courseName";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("courseName", courseName));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 각 텍스트 박스에 데이터 채우기
                                textBox10.Text = reader["C_ID"].ToString();       // 과목코드
                                textBox12.Text = reader["C_NAME"].ToString();     // 과목명
                                textBox11.Text = reader["OPENDATE"].ToString();   // 개설학기
                                textBox9.Text = reader["CLASS_PRO"].ToString();   // 강의 교수
                            }
                            else
                            {
                                MessageBox.Show("해당 과목의 정보를 찾을 수 없습니다.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("과목 정보 로드 중 오류 발생: " + ex.Message);
            }
        }


        //과목 수정
        private void button3_Click(object sender, EventArgs e)
        {
            string courseId = textBox10.Text.Trim(); // 과목코드
            string courseName = textBox12.Text.Trim(); // 과목명
            string openDate = textBox11.Text.Trim(); // 개설학기
            string professorId = textBox9.Text.Trim(); // 강의 교수 ID

            // 필수 입력값 체크
            if (string.IsNullOrEmpty(courseId) || string.IsNullOrEmpty(courseName) ||
                string.IsNullOrEmpty(openDate) || string.IsNullOrEmpty(professorId))
            {
                MessageBox.Show("모든 필드를 입력해야 수정할 수 있습니다.");
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();

                    // 강의실 배정 여부 확인
                    string checkQuery = "SELECT COUNT(*) FROM CLASSES WHERE C_ID = :courseId";
                    using (OracleCommand checkCmd = new OracleCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add(new OracleParameter("courseId", courseId));
                        int assignedRooms = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (assignedRooms > 0)
                        {
                            MessageBox.Show("해당 과목은 이미 강의실이 배정되어 수정이 불가능합니다.");
                            return;
                        }
                    }

                    // 강의실 배정이 없는 경우 과목 테이블(COURSES) 업데이트
                    string updateCoursesQuery = @"
                        UPDATE COURSES
                        SET C_NAME = :courseName,
                        OPENDATE = :openDate,
                        CLASS_PRO = :professorId
                        WHERE C_ID = :courseId";

                    using (OracleCommand updateCoursesCmd = new OracleCommand(updateCoursesQuery, conn))
                    {
                        updateCoursesCmd.Parameters.Add(new OracleParameter("courseName", courseName));
                        updateCoursesCmd.Parameters.Add(new OracleParameter("openDate", openDate));
                        updateCoursesCmd.Parameters.Add(new OracleParameter("professorId", professorId));
                        updateCoursesCmd.Parameters.Add(new OracleParameter("courseId", courseId));

                        int rowsUpdated = updateCoursesCmd.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("과목 정보가 성공적으로 수정되었습니다.");
                            RefreshCourseDataGrid(); // 데이터 그리드 뷰 새로 고침

                            textBox10.Text = string.Empty; // 과목코드
                            textBox12.Text = string.Empty; // 과목명
                            textBox11.Text = string.Empty; // 개설학기
                            textBox9.Text = string.Empty; // 강의 교수 ID
                        }
                        else
                        {
                            MessageBox.Show("수정된 정보가 없습니다.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("과목 정보 수정 중 오류가 발생했습니다: " + ex.Message);
            }
        }


        // 데이터 그리드 뷰 새로 고침 메서드
        private void RefreshCourseDataGrid()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();

                    // 과목 정보를 가져오는 SQL 쿼리
                    string query = @"
                                SELECT 
                                C.C_ID, 
                                C.C_NAME, 
                                C.OPENDATE, 
                                C.CLASS_PRO 
                                FROM COURSES C";

                    using (OracleDataAdapter adapter = new OracleDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable(); // 데이터를 저장할 테이블 생성
                        adapter.Fill(dt);

                        // 기존 DataGridView 컬럼 유지하며 데이터만 새로고침
                        var currentDataSource = dataGridView3.DataSource as DataTable;

                        if (currentDataSource != null)
                        {
                            // 데이터만 갱신
                            currentDataSource.Clear();
                            foreach (DataRow row in dt.Rows)
                            {
                                currentDataSource.ImportRow(row);
                            }
                        }
                        else
                        {
                            // 처음 로드할 때
                            dataGridView3.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 새로고침 중 오류가 발생했습니다: " + ex.Message);
            }
        }





        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 유효한 행인지 확인
            if (e.RowIndex >= 0)
            {
                // 열의 헤더 텍스트를 기반으로 "과목명" 열인지 확인
                if (dataGridView3.Columns[e.ColumnIndex].HeaderText == "과목명")
                {
                    // 선택된 셀의 값을 가져옴
                    string courseName = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                    if (!string.IsNullOrEmpty(courseName))
                    {
                        ShowCourseDetails(courseName); // 과목 상세 정보 표시
                    }
                    else
                    {
                        MessageBox.Show("선택한 셀에 유효한 과목명이 없습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("해당 열은 '과목명' 열이 아닙니다.");
                }
            }
        }

        private void dataGridView3_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // 유효한 행인지 확인
            if (e.RowIndex >= 0)
            {
                // 열의 헤더 텍스트를 기반으로 "과목명" 열인지 확인
                if (dataGridView3.Columns[e.ColumnIndex].HeaderText == "과목명")
                {
                    // 선택된 셀의 값을 가져옴
                    string courseName = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                    if (!string.IsNullOrEmpty(courseName))
                    {
                        ShowCourseDetails(courseName); // 과목 상세 정보 표시
                    }
                    else
                    {
                        MessageBox.Show("선택한 셀에 유효한 과목명이 없습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("해당 열은 '과목명' 열이 아닙니다.");
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string courseId = textBox10.Text.Trim(); // 과목코드
            string courseName = textBox12.Text.Trim(); // 과목명
            string openDate = textBox11.Text.Trim(); // 개설학기
            string professorId = textBox9.Text.Trim(); // 강의 교수 ID

            // 필수 입력값 체크
            if (string.IsNullOrEmpty(courseId) || string.IsNullOrEmpty(courseName) ||
                string.IsNullOrEmpty(openDate) || string.IsNullOrEmpty(professorId))
            {
                MessageBox.Show("모든 필드를 입력해야 수정할 수 있습니다.");
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();

                    // 강의실 배정 여부 확인
                    string checkQuery = "SELECT COUNT(*) FROM CLASSES WHERE C_ID = :courseId";
                    using (OracleCommand checkCmd = new OracleCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add(new OracleParameter("courseId", courseId));
                        int assignedRooms = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (assignedRooms > 0)
                        {
                            MessageBox.Show("해당 과목은 이미 강의실이 배정되어 수정이 불가능합니다.");
                            return;
                        }
                    }

                    // 강의실 배정이 없는 경우 과목 테이블(COURSES) 업데이트
                    string updateCoursesQuery = @"
                        UPDATE COURSES
                        SET C_NAME = :courseName,
                        OPENDATE = :openDate,
                        CLASS_PRO = :professorId
                        WHERE C_ID = :courseId";

                    using (OracleCommand updateCoursesCmd = new OracleCommand(updateCoursesQuery, conn))
                    {
                        updateCoursesCmd.Parameters.Add(new OracleParameter("courseName", courseName));
                        updateCoursesCmd.Parameters.Add(new OracleParameter("openDate", openDate));
                        updateCoursesCmd.Parameters.Add(new OracleParameter("professorId", professorId));
                        updateCoursesCmd.Parameters.Add(new OracleParameter("courseId", courseId));

                        int rowsUpdated = updateCoursesCmd.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("과목 정보가 성공적으로 수정되었습니다.");
                            RefreshCourseDataGrid(); // 데이터 그리드 뷰 새로 고침

                            textBox10.Text = string.Empty; // 과목코드
                            textBox12.Text = string.Empty; // 과목명
                            textBox11.Text = string.Empty; // 개설학기
                            textBox9.Text = string.Empty; // 강의 교수 ID
                        }
                        else
                        {
                            MessageBox.Show("수정된 정보가 없습니다.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("과목 정보 수정 중 오류가 발생했습니다: " + ex.Message);
            }
        }
    }
}
