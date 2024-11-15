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
    public partial class AdminPlus : Form
    {
        private const int STEP_SLIDING = 5; // 매 프레임 이동량을 줄여 부드럽게
        private const int MIN_SLIDING_WIDTH = 50; // 메뉴 닫힘 시 너비
        private const int MAX_SLIDING_WIDTH = 200; // 메뉴 열림 시 너비
        private int _posSliding = MIN_SLIDING_WIDTH; // 현재 메뉴 위치 (최초 너비 50으로 설정)

        public AdminPlus()
        {
            InitializeComponent();
            panelSideMenu.Width = MIN_SLIDING_WIDTH; // 폼 로드시 메뉴 너비를 50으로 설정
            foreach (Control ctrl in panelSideMenu.Controls)
            {
                // checkBoxHide는 그대로 남기고 나머지 컨트롤은 숨김
                if (ctrl != checkBoxHide)
                {
                    ctrl.Visible = false;
                }
            }
            checkBoxHide.Checked = true; // 체크박스 기본 상태를 false로 설정

        }

   

        private void timerSliding_Tick(object sender, EventArgs e)
        {
            if (checkBoxHide.Checked == true)
            {
                //슬라이딩 메뉴를 숨기는 동작
                _posSliding -= STEP_SLIDING;
                if (_posSliding <= MIN_SLIDING_WIDTH)
                    timerSliding.Stop();
            }
            else
            {
                //슬라이딩 메뉴를 보이는 동작
                _posSliding += STEP_SLIDING;
                if (_posSliding >= MAX_SLIDING_WIDTH)
                    timerSliding.Stop();
            }

            panelSideMenu.Width = _posSliding;
        }


        private void AdminPlus_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'dataSet5.COURSES2' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.cOURSES2TableAdapter.Fill(this.dataSet5.COURSES2);
            // TODO: 이 코드는 데이터를 'dataSet2.COURSESWITHPROFESSORNAME' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.cOURSESWITHPROFESSORNAMETableAdapter.Fill(this.dataSet2.COURSESWITHPROFESSORNAME);
            // TODO: 이 코드는 데이터를 'dataSet1.COURSES' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.cOURSESTableAdapter.Fill(this.dataSet1.COURSES);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable mytable = dataSet1.Tables["COURSES"];
            DataRow mynewDataRow = mytable.NewRow();
            mynewDataRow["C_ID"] = textBox1.Text;
            mynewDataRow["C_NAME"] = textBox2.Text;
            mynewDataRow["OPENDATE"] = textBox3.Text;
            mynewDataRow["CLASS_PRO"] = textBox4.Text;
            mytable.Rows.Add(mynewDataRow);
            cOURSESTableAdapter.Update(dataSet1.COURSES);
            MessageBox.Show("강의 개설과 교수님 배정이 완료되었습니다. 옆으로 이동해서 강의실 배정해주세요.");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.cOURSESTableAdapter.FillBy(this.dataSet1.COURSES);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.cOURSESTableAdapter.FillBy1(this.dataSet1.COURSES);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.cOURSESWITHPROFESSORNAMETableAdapter.FillBy(this.dataSet2.COURSESWITHPROFESSORNAME);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DataTable mytable1 = dataSet61.Tables["CLASSES"];
            DataRow mynewDataRow = mytable1.NewRow();
            mynewDataRow["CLASS_ID"] = textBox8.Text;
            mynewDataRow["C_ID"] = textBox7.Text;
            mynewDataRow["CLASS_DATE"] = textBox6.Text;
            mynewDataRow["CLASS_PLACE"] = textBox5.Text;
            mytable1.Rows.Add(mynewDataRow);
            classesTableAdapter1.Update(dataSet61.CLASSES);
            MessageBox.Show("강의실 배정을 했습니다.");
        }

    

        private void checkBoxHide_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxHide.Checked == true)
            {
                foreach (Control ctrl in panelSideMenu.Controls)
                {
                    // checkBoxHide는 그대로 남기고 나머지 컨트롤은 숨김
                    if (ctrl != checkBoxHide)
                    {
                        ctrl.Visible = false;
                    }
                }
                checkBoxHide.Text = "+";
            }
            else
            {
                //슬라이딩 메뉴가 보였을 때, 메뉴 버튼의 표시
                foreach (Control ctrl in panelSideMenu.Controls)
                {
                    // 모든 컨트롤을 다시 보이게 설정
                    ctrl.Visible = true;
                }

                checkBoxHide.Text = "X";
            }

            //타이머 시작
            timerSliding.Start();
        }

        private void timerSliding_Tick_1(object sender, EventArgs e)
        {
            timerSliding.Interval = 10; // 타이머 간격을 작게 설정하여 프레임 증가

            if (checkBoxHide.Checked == true)
            {
                //슬라이딩 메뉴를 숨기는 동작
                _posSliding -= STEP_SLIDING;
                if (_posSliding <= MIN_SLIDING_WIDTH)
                    timerSliding.Stop();
            }
            else
            {
                //슬라이딩 메뉴를 보이는 동작
                _posSliding += STEP_SLIDING;
                if (_posSliding >= MAX_SLIDING_WIDTH)
                    timerSliding.Stop();
            }

            panelSideMenu.Width = _posSliding;
        }

   

    }
}
