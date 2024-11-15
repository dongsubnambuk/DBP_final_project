namespace DBP_final
{
    partial class AdminPlus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cOURSESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new DBP_final.DataSet1();
            this.cOURSESTableAdapter = new DBP_final.DataSet1TableAdapters.COURSESTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cOURSESWITHPROFESSORNAMEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new DBP_final.DataSet2();
            this.cOURSESWITHPROFESSORNAMEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cOURSESWITHPROFESSORNAMETableAdapter = new DBP_final.DataSet2TableAdapters.COURSESWITHPROFESSORNAMETableAdapter();
            this.dataSet5 = new DBP_final.DataSet5();
            this.cOURSES2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cOURSES2TableAdapter = new DBP_final.DataSet5TableAdapters.COURSES2TableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPENDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLASSPRONAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLASSROOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataSet61 = new DBP_final.DataSet6();
            this.classesTableAdapter1 = new DBP_final.DataSet6TableAdapters.CLASSESTableAdapter();
            this.timerSliding = new System.Windows.Forms.Timer(this.components);
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.checkBoxHide = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cOURSESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOURSESWITHPROFESSORNAMEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOURSESWITHPROFESSORNAMEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOURSES2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet61)).BeginInit();
            this.panelSideMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cOURSESBindingSource
            // 
            this.cOURSESBindingSource.DataMember = "COURSES";
            this.cOURSESBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cOURSESTableAdapter
            // 
            this.cOURSESTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "강의교수";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(76, 190);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(112, 21);
            this.textBox4.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "개설학기";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(76, 144);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(112, 21);
            this.textBox3.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "과목명";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(76, 105);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 21);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "과목코드";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 21);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "이번학기 과목";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(233)))), ((int)(((byte)(213)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(22, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "등록하기";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cOURSESWITHPROFESSORNAMEBindingSource1
            // 
            this.cOURSESWITHPROFESSORNAMEBindingSource1.DataMember = "COURSESWITHPROFESSORNAME";
            this.cOURSESWITHPROFESSORNAMEBindingSource1.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cOURSESWITHPROFESSORNAMEBindingSource
            // 
            this.cOURSESWITHPROFESSORNAMEBindingSource.DataMember = "COURSESWITHPROFESSORNAME";
            this.cOURSESWITHPROFESSORNAMEBindingSource.DataSource = this.dataSet2;
            // 
            // cOURSESWITHPROFESSORNAMETableAdapter
            // 
            this.cOURSESWITHPROFESSORNAMETableAdapter.ClearBeforeFill = true;
            // 
            // dataSet5
            // 
            this.dataSet5.DataSetName = "DataSet5";
            this.dataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cOURSES2BindingSource
            // 
            this.cOURSES2BindingSource.DataMember = "COURSES2";
            this.cOURSES2BindingSource.DataSource = this.dataSet5;
            // 
            // cOURSES2TableAdapter
            // 
            this.cOURSES2TableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(233)))), ((int)(((byte)(213)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIDDataGridViewTextBoxColumn,
            this.cNAMEDataGridViewTextBoxColumn,
            this.oPENDATEDataGridViewTextBoxColumn,
            this.cLASSPRONAMEDataGridViewTextBoxColumn,
            this.cLASSROOMDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.cOURSES2BindingSource;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(16, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(505, 115);
            this.dataGridView1.TabIndex = 8;
            // 
            // cIDDataGridViewTextBoxColumn
            // 
            this.cIDDataGridViewTextBoxColumn.DataPropertyName = "C_ID";
            this.cIDDataGridViewTextBoxColumn.HeaderText = "과목코드";
            this.cIDDataGridViewTextBoxColumn.Name = "cIDDataGridViewTextBoxColumn";
            this.cIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cNAMEDataGridViewTextBoxColumn
            // 
            this.cNAMEDataGridViewTextBoxColumn.DataPropertyName = "C_NAME";
            this.cNAMEDataGridViewTextBoxColumn.HeaderText = "과목명";
            this.cNAMEDataGridViewTextBoxColumn.Name = "cNAMEDataGridViewTextBoxColumn";
            this.cNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oPENDATEDataGridViewTextBoxColumn
            // 
            this.oPENDATEDataGridViewTextBoxColumn.DataPropertyName = "OPENDATE";
            this.oPENDATEDataGridViewTextBoxColumn.HeaderText = "개설학기";
            this.oPENDATEDataGridViewTextBoxColumn.Name = "oPENDATEDataGridViewTextBoxColumn";
            this.oPENDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cLASSPRONAMEDataGridViewTextBoxColumn
            // 
            this.cLASSPRONAMEDataGridViewTextBoxColumn.DataPropertyName = "CLASS_PRO_NAME";
            this.cLASSPRONAMEDataGridViewTextBoxColumn.HeaderText = "강의교수명";
            this.cLASSPRONAMEDataGridViewTextBoxColumn.Name = "cLASSPRONAMEDataGridViewTextBoxColumn";
            this.cLASSPRONAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cLASSROOMDataGridViewTextBoxColumn
            // 
            this.cLASSROOMDataGridViewTextBoxColumn.DataPropertyName = "CLASSROOM";
            this.cLASSROOMDataGridViewTextBoxColumn.HeaderText = "강의실";
            this.cLASSROOMDataGridViewTextBoxColumn.Name = "cLASSROOMDataGridViewTextBoxColumn";
            this.cLASSROOMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 413);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "강의실";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(76, 410);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(112, 21);
            this.textBox5.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "수업요일";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(76, 364);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(112, 21);
            this.textBox6.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "과목코드";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(76, 325);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(112, 21);
            this.textBox7.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "수업번호";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(76, 284);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(112, 21);
            this.textBox8.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(233)))), ((int)(((byte)(213)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(22, 437);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "등록하기";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // dataSet61
            // 
            this.dataSet61.DataSetName = "DataSet6";
            this.dataSet61.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // classesTableAdapter1
            // 
            this.classesTableAdapter1.ClearBeforeFill = true;
            // 
            // timerSliding
            // 
            this.timerSliding.Tick += new System.EventHandler(this.timerSliding_Tick_1);
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.panelSideMenu.Controls.Add(this.checkBoxHide);
            this.panelSideMenu.Controls.Add(this.label11);
            this.panelSideMenu.Controls.Add(this.button2);
            this.panelSideMenu.Controls.Add(this.label6);
            this.panelSideMenu.Controls.Add(this.label5);
            this.panelSideMenu.Controls.Add(this.textBox5);
            this.panelSideMenu.Controls.Add(this.button1);
            this.panelSideMenu.Controls.Add(this.label7);
            this.panelSideMenu.Controls.Add(this.label10);
            this.panelSideMenu.Controls.Add(this.textBox6);
            this.panelSideMenu.Controls.Add(this.textBox4);
            this.panelSideMenu.Controls.Add(this.label8);
            this.panelSideMenu.Controls.Add(this.textBox1);
            this.panelSideMenu.Controls.Add(this.textBox7);
            this.panelSideMenu.Controls.Add(this.label9);
            this.panelSideMenu.Controls.Add(this.label4);
            this.panelSideMenu.Controls.Add(this.textBox8);
            this.panelSideMenu.Controls.Add(this.label2);
            this.panelSideMenu.Controls.Add(this.textBox3);
            this.panelSideMenu.Controls.Add(this.textBox2);
            this.panelSideMenu.Controls.Add(this.label3);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSideMenu.Location = new System.Drawing.Point(670, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(200, 495);
            this.panelSideMenu.TabIndex = 10;
            // 
            // checkBoxHide
            // 
            this.checkBoxHide.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxHide.FlatAppearance.BorderSize = 0;
            this.checkBoxHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxHide.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBoxHide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(233)))), ((int)(((byte)(213)))));
            this.checkBoxHide.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxHide.Location = new System.Drawing.Point(2, 1);
            this.checkBoxHide.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxHide.Name = "checkBoxHide";
            this.checkBoxHide.Size = new System.Drawing.Size(34, 31);
            this.checkBoxHide.TabIndex = 13;
            this.checkBoxHide.Text = "+";
            this.checkBoxHide.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxHide.UseVisualStyleBackColor = true;
            this.checkBoxHide.CheckedChanged += new System.EventHandler(this.checkBoxHide_CheckedChanged_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(48, 251);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 19);
            this.label11.TabIndex = 12;
            this.label11.Text = "강의실 배정";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(18, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 19);
            this.label10.TabIndex = 11;
            this.label10.Text = "과목 및 강의 배정";
            // 
            // AdminPlus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(233)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(870, 495);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "AdminPlus";
            this.Text = "과목등록 및 배정";
            this.Load += new System.EventHandler(this.AdminPlus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cOURSESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOURSESWITHPROFESSORNAMEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOURSESWITHPROFESSORNAMEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOURSES2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet61)).EndInit();
            this.panelSideMenu.ResumeLayout(false);
            this.panelSideMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource cOURSESBindingSource;
        private DataSet1TableAdapters.COURSESTableAdapter cOURSESTableAdapter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource cOURSESWITHPROFESSORNAMEBindingSource;
        private DataSet2TableAdapters.COURSESWITHPROFESSORNAMETableAdapter cOURSESWITHPROFESSORNAMETableAdapter;
        private System.Windows.Forms.BindingSource cOURSESWITHPROFESSORNAMEBindingSource1;
        private DataSet5 dataSet5;
        private System.Windows.Forms.BindingSource cOURSES2BindingSource;
        private DataSet5TableAdapters.COURSES2TableAdapter cOURSES2TableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPENDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLASSPRONAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLASSROOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button2;
        private DataSet6 dataSet61;
        private DataSet6TableAdapters.CLASSESTableAdapter classesTableAdapter1;
        private System.Windows.Forms.Timer timerSliding;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxHide;
    }
}