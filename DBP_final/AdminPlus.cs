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
        public AdminPlus()
        {
            InitializeComponent();
        }

        private void AdminPlus_Load(object sender, EventArgs e)
        {
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
            MessageBox.Show("강의 개설과 교수님 배정이 완료되었습니다.");
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
    }
}
