namespace DBP_final
{
    partial class StudentEnroll
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet5 = new DBP_final.DataSet5();
            this.cOURSES2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cOURSES2TableAdapter = new DBP_final.DataSet5TableAdapters.COURSES2TableAdapter();
            this.cIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPENDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLASSPRONAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLASSROOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOURSES2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIDDataGridViewTextBoxColumn,
            this.cNAMEDataGridViewTextBoxColumn,
            this.oPENDATEDataGridViewTextBoxColumn,
            this.cLASSPRONAMEDataGridViewTextBoxColumn,
            this.cLASSROOMDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.cOURSES2BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(572, 150);
            this.dataGridView1.TabIndex = 0;
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
            // cIDDataGridViewTextBoxColumn
            // 
            this.cIDDataGridViewTextBoxColumn.DataPropertyName = "C_ID";
            this.cIDDataGridViewTextBoxColumn.HeaderText = "과목코드";
            this.cIDDataGridViewTextBoxColumn.Name = "cIDDataGridViewTextBoxColumn";
            this.cIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // cNAMEDataGridViewTextBoxColumn
            // 
            this.cNAMEDataGridViewTextBoxColumn.DataPropertyName = "C_NAME";
            this.cNAMEDataGridViewTextBoxColumn.HeaderText = "과목명";
            this.cNAMEDataGridViewTextBoxColumn.Name = "cNAMEDataGridViewTextBoxColumn";
            this.cNAMEDataGridViewTextBoxColumn.Width = 150;
            // 
            // oPENDATEDataGridViewTextBoxColumn
            // 
            this.oPENDATEDataGridViewTextBoxColumn.DataPropertyName = "OPENDATE";
            this.oPENDATEDataGridViewTextBoxColumn.HeaderText = "개설학기";
            this.oPENDATEDataGridViewTextBoxColumn.Name = "oPENDATEDataGridViewTextBoxColumn";
            // 
            // cLASSPRONAMEDataGridViewTextBoxColumn
            // 
            this.cLASSPRONAMEDataGridViewTextBoxColumn.DataPropertyName = "CLASS_PRO_NAME";
            this.cLASSPRONAMEDataGridViewTextBoxColumn.HeaderText = "강의교수명";
            this.cLASSPRONAMEDataGridViewTextBoxColumn.Name = "cLASSPRONAMEDataGridViewTextBoxColumn";
            // 
            // cLASSROOMDataGridViewTextBoxColumn
            // 
            this.cLASSROOMDataGridViewTextBoxColumn.DataPropertyName = "CLASSROOM";
            this.cLASSROOMDataGridViewTextBoxColumn.HeaderText = "강의실";
            this.cLASSROOMDataGridViewTextBoxColumn.Name = "cLASSROOMDataGridViewTextBoxColumn";
            // 
            // StudentEnroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StudentEnroll";
            this.Text = "수강신청";
            this.Load += new System.EventHandler(this.StudentEnroll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOURSES2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet5 dataSet5;
        private System.Windows.Forms.BindingSource cOURSES2BindingSource;
        private DataSet5TableAdapters.COURSES2TableAdapter cOURSES2TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPENDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLASSPRONAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLASSROOMDataGridViewTextBoxColumn;
    }
}