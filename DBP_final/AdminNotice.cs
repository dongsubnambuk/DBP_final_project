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
    public partial class AdminNotice : Form
    {
        public AdminNotice()
        {
            InitializeComponent();
        }

        private void AdminNotice_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'dataSet8.NOTICES' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.nOTICESTableAdapter.Fill(this.dataSet8.NOTICES);
            LoadNotices(); // 공지사항 로드

        }

        // 공지사항 저장 메서드
        private void SaveNotice()
        {
            string title = textBoxTitle.Text.Trim();
            string content = textBoxContent.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("공지 제목과 내용을 입력하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();
                    string query = "INSERT INTO NOTICES (TITLE, CONTENT) VALUES (:title, :content)";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("title", title));
                        cmd.Parameters.Add(new OracleParameter("content", content));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("공지사항이 저장되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 입력 필드 초기화
                            textBoxTitle.Clear();
                            textBoxContent.Clear();

                            LoadNotices(); // 공지사항 목록 새로고침
                        }
                        else
                        {
                            MessageBox.Show("공지사항 저장에 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"공지사항 저장 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 공지사항 로드 메서드
        private void LoadNotices()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=DONG1; Password=sds@258079; Data Source=localhost:1521/xepdb1"))
                {
                    conn.Open();
                    string query = "SELECT NOTICE_ID, TITLE, CONTENT, CREATED_AT FROM NOTICES ORDER BY CREATED_AT DESC";

                    using (OracleDataAdapter adapter = new OracleDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                  
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"공지사항 로드 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveNotice();
        }
    }
}
