namespace DBP_final
{
    partial class AdminGradeInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eXAMSCOREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aTTSCOREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSSSCORE1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSSSCORE2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fINALGRADEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eNROLLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet3 = new DBP_final.DataSet3();
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillByToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.button2 = new System.Windows.Forms.Button();
            this.eNROLLTableAdapter = new DBP_final.DataSet3TableAdapters.ENROLLTableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.학생이름DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.과목명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fINALGRADEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eNROLLWITHNAMESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet4 = new DBP_final.DataSet4();
            this.eNROLLWITHNAMESTableAdapter = new DBP_final.DataSet4TableAdapters.ENROLLWITHNAMESTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNROLLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet3)).BeginInit();
            this.fillByToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNROLLWITHNAMESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(14, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "저장하기";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sIDDataGridViewTextBoxColumn,
            this.cIDDataGridViewTextBoxColumn,
            this.eXAMSCOREDataGridViewTextBoxColumn,
            this.aTTSCOREDataGridViewTextBoxColumn,
            this.aSSSCORE1DataGridViewTextBoxColumn,
            this.aSSSCORE2DataGridViewTextBoxColumn,
            this.fINALGRADEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.eNROLLBindingSource;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 37);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(743, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // sIDDataGridViewTextBoxColumn
            // 
            this.sIDDataGridViewTextBoxColumn.DataPropertyName = "S_ID";
            this.sIDDataGridViewTextBoxColumn.HeaderText = "학번";
            this.sIDDataGridViewTextBoxColumn.Name = "sIDDataGridViewTextBoxColumn";
            // 
            // cIDDataGridViewTextBoxColumn
            // 
            this.cIDDataGridViewTextBoxColumn.DataPropertyName = "C_ID";
            this.cIDDataGridViewTextBoxColumn.HeaderText = "과목코드";
            this.cIDDataGridViewTextBoxColumn.Name = "cIDDataGridViewTextBoxColumn";
            // 
            // eXAMSCOREDataGridViewTextBoxColumn
            // 
            this.eXAMSCOREDataGridViewTextBoxColumn.DataPropertyName = "EXAM_SCORE";
            this.eXAMSCOREDataGridViewTextBoxColumn.HeaderText = "시험점수";
            this.eXAMSCOREDataGridViewTextBoxColumn.Name = "eXAMSCOREDataGridViewTextBoxColumn";
            // 
            // aTTSCOREDataGridViewTextBoxColumn
            // 
            this.aTTSCOREDataGridViewTextBoxColumn.DataPropertyName = "ATT_SCORE";
            this.aTTSCOREDataGridViewTextBoxColumn.HeaderText = "출석점수";
            this.aTTSCOREDataGridViewTextBoxColumn.Name = "aTTSCOREDataGridViewTextBoxColumn";
            // 
            // aSSSCORE1DataGridViewTextBoxColumn
            // 
            this.aSSSCORE1DataGridViewTextBoxColumn.DataPropertyName = "ASS_SCORE1";
            this.aSSSCORE1DataGridViewTextBoxColumn.HeaderText = "과제점수1";
            this.aSSSCORE1DataGridViewTextBoxColumn.Name = "aSSSCORE1DataGridViewTextBoxColumn";
            // 
            // aSSSCORE2DataGridViewTextBoxColumn
            // 
            this.aSSSCORE2DataGridViewTextBoxColumn.DataPropertyName = "ASS_SCORE2";
            this.aSSSCORE2DataGridViewTextBoxColumn.HeaderText = "과제점수2";
            this.aSSSCORE2DataGridViewTextBoxColumn.Name = "aSSSCORE2DataGridViewTextBoxColumn";
            // 
            // fINALGRADEDataGridViewTextBoxColumn
            // 
            this.fINALGRADEDataGridViewTextBoxColumn.DataPropertyName = "FINAL_GRADE";
            this.fINALGRADEDataGridViewTextBoxColumn.HeaderText = "등급";
            this.fINALGRADEDataGridViewTextBoxColumn.Name = "fINALGRADEDataGridViewTextBoxColumn";
            // 
            // eNROLLBindingSource
            // 
            this.eNROLLBindingSource.DataMember = "ENROLL";
            this.eNROLLBindingSource.DataSource = this.dataSet3;
            // 
            // dataSet3
            // 
            this.dataSet3.DataSetName = "DataSet3";
            this.dataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fillByToolStrip
            // 
            this.fillByToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillByToolStripButton});
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(810, 25);
            this.fillByToolStrip.TabIndex = 3;
            this.fillByToolStrip.Text = "fillByToolStrip";
            // 
            // fillByToolStripButton
            // 
            this.fillByToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByToolStripButton.Name = "fillByToolStripButton";
            this.fillByToolStripButton.Size = new System.Drawing.Size(39, 22);
            this.fillByToolStripButton.Text = "FillBy";
            this.fillByToolStripButton.Click += new System.EventHandler(this.fillByToolStripButton_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(14, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(271, 39);
            this.button2.TabIndex = 4;
            this.button2.Text = "최종 평가";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // eNROLLTableAdapter
            // 
            this.eNROLLTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.ColumnHeadersHeight = 30;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.학생이름DataGridViewTextBoxColumn,
            this.과목명DataGridViewTextBoxColumn,
            this.fINALGRADEDataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.eNROLLWITHNAMESBindingSource;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(412, 228);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(343, 150);
            this.dataGridView2.TabIndex = 5;
            // 
            // 학생이름DataGridViewTextBoxColumn
            // 
            this.학생이름DataGridViewTextBoxColumn.DataPropertyName = "학생이름";
            this.학생이름DataGridViewTextBoxColumn.HeaderText = "학생이름";
            this.학생이름DataGridViewTextBoxColumn.Name = "학생이름DataGridViewTextBoxColumn";
            this.학생이름DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 과목명DataGridViewTextBoxColumn
            // 
            this.과목명DataGridViewTextBoxColumn.DataPropertyName = "과목명";
            this.과목명DataGridViewTextBoxColumn.HeaderText = "과목명";
            this.과목명DataGridViewTextBoxColumn.Name = "과목명DataGridViewTextBoxColumn";
            this.과목명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fINALGRADEDataGridViewTextBoxColumn1
            // 
            this.fINALGRADEDataGridViewTextBoxColumn1.DataPropertyName = "FINAL_GRADE";
            this.fINALGRADEDataGridViewTextBoxColumn1.HeaderText = "등급";
            this.fINALGRADEDataGridViewTextBoxColumn1.Name = "fINALGRADEDataGridViewTextBoxColumn1";
            this.fINALGRADEDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // eNROLLWITHNAMESBindingSource
            // 
            this.eNROLLWITHNAMESBindingSource.DataMember = "ENROLLWITHNAMES";
            this.eNROLLWITHNAMESBindingSource.DataSource = this.dataSet4;
            // 
            // dataSet4
            // 
            this.dataSet4.DataSetName = "DataSet4";
            this.dataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eNROLLWITHNAMESTableAdapter
            // 
            this.eNROLLWITHNAMESTableAdapter.ClearBeforeFill = true;
            // 
            // AdminGradeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(810, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.fillByToolStrip);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "AdminGradeInput";
            this.Text = "성적입력";
            this.Load += new System.EventHandler(this.AdminGradeInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNROLLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet3)).EndInit();
            this.fillByToolStrip.ResumeLayout(false);
            this.fillByToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNROLLWITHNAMESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet3 dataSet3;
        private System.Windows.Forms.BindingSource eNROLLBindingSource;
        private DataSet3TableAdapters.ENROLLTableAdapter eNROLLTableAdapter;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.ToolStripButton fillByToolStripButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private DataSet4 dataSet4;
        private System.Windows.Forms.BindingSource eNROLLWITHNAMESBindingSource;
        private DataSet4TableAdapters.ENROLLWITHNAMESTableAdapter eNROLLWITHNAMESTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eXAMSCOREDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aTTSCOREDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSSSCORE1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSSSCORE2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fINALGRADEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 학생이름DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 과목명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fINALGRADEDataGridViewTextBoxColumn1;
    }
}