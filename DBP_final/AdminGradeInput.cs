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
    public partial class AdminGradeInput : Form
    {
        public AdminGradeInput()
        {
            InitializeComponent();
        }

        private void AdminGradeInput_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'dataSet4.ENROLLWITHNAMES' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.eNROLLWITHNAMESTableAdapter.Fill(this.dataSet4.ENROLLWITHNAMES);
            // TODO: 이 코드는 데이터를 'dataSet3.ENROLL' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.eNROLLTableAdapter.Fill(this.dataSet3.ENROLL);
            // TODO: 이 코드는 데이터를 'dataSet3.ENROLLWITHNAMES' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
       

        }


        //저장하기
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.eNROLLBindingSource.EndEdit();
                int ret = this.eNROLLTableAdapter.Update(this.dataSet3.ENROLL);

           
                this.eNROLLWITHNAMESTableAdapter.Fill(this.dataSet4.ENROLLWITHNAMES);

              
                dataGridView2.Refresh();


                if (ret > 0)
                    MessageBox.Show("데이터베이스에 저장 성공");
                else
                    MessageBox.Show("변경된 내용이 없습니다.");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("저장 실패: " + ex.Message);
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.eNROLLTableAdapter.FillBy(this.dataSet3.ENROLL);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        //최종 평가
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터셋의 각 행 중 변경된 행만 처리
                foreach (DataRow row in dataSet3.ENROLL.Rows)
                {
                    // 변경된 행인지 확인
                    if (row.RowState == DataRowState.Modified)
                    {
                        // 각 점수를 읽기 전에 DBNull 여부 확인
                        int examScore = row["EXAM_SCORE"] != DBNull.Value ? Convert.ToInt32(row["EXAM_SCORE"]) : 0;
                        int attScore = row["ATT_SCORE"] != DBNull.Value ? Convert.ToInt32(row["ATT_SCORE"]) : 0;
                        int assScore1 = row["ASS_SCORE1"] != DBNull.Value ? Convert.ToInt32(row["ASS_SCORE1"]) : 0;
                        int assScore2 = row["ASS_SCORE2"] != DBNull.Value ? Convert.ToInt32(row["ASS_SCORE2"]) : 0;

                        // 최대 점수 제한 체크
                        if (examScore > 50)
                        {
                            MessageBox.Show("시험 점수는 50점 이하로 입력해야 합니다.");
                            return;
                        }
                        if (attScore > 40)
                        {
                            MessageBox.Show("출석 점수는 40점 이하로 입력해야 합니다.");
                            return;
                        }
                        if (assScore1 > 5 || assScore2 > 5)
                        {
                            MessageBox.Show("각 과제 점수는 5점 이하로 입력해야 합니다.");
                            return;
                        }

                        // 과제 점수 합산 (과제당 5점으로 10점 만점)
                        int totalAssScore = assScore1 + assScore2;

                        // 총점 계산 (시험 점수 + 출석 점수 + 과제 점수 합)
                        int totalScore = examScore + attScore + totalAssScore;

                        // 등급 계산
                        string finalGrade;
                        if (totalScore >= 90)
                            finalGrade = "A";
                        else if (totalScore >= 80)
                            finalGrade = "B";
                        else if (totalScore >= 70)
                            finalGrade = "C";
                        else if (totalScore >= 60)
                            finalGrade = "D";
                        else
                            finalGrade = "F";

                        // FINAL_GRADE 필드 업데이트
                        row["FINAL_GRADE"] = finalGrade;
                    }
                }

                MessageBox.Show("변경된 행에 대한 최종 평가 완료. 저장하려면 '저장하기' 버튼을 눌러주세요.");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("최종 평가 실패: " + ex.Message);
            }
        }


    }
}
