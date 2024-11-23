namespace DBP_final
{
    partial class AdminNotice
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet8 = new DBP_final.DataSet8();
            this.nOTICESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nOTICESTableAdapter = new DBP_final.DataSet8TableAdapters.NOTICESTableAdapter();
            this.nOTICEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tITLEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cONTENTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEDATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nOTICESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(297, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "공지사항 작성하기";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(112, 82);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(225, 21);
            this.textBoxTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(45, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "제목";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(45, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "내용";
            // 
            // textBoxContent
            // 
            this.textBoxContent.Location = new System.Drawing.Point(112, 136);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(225, 100);
            this.textBoxContent.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(49, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(288, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "저장하기";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.dataGridView1.ColumnHeadersHeight = 28;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nOTICEIDDataGridViewTextBoxColumn,
            this.tITLEDataGridViewTextBoxColumn,
            this.cONTENTDataGridViewTextBoxColumn,
            this.cREATEDATDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.nOTICESBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(404, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(404, 150);
            this.dataGridView1.TabIndex = 6;
            // 
            // dataSet8
            // 
            this.dataSet8.DataSetName = "DataSet8";
            this.dataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nOTICESBindingSource
            // 
            this.nOTICESBindingSource.DataMember = "NOTICES";
            this.nOTICESBindingSource.DataSource = this.dataSet8;
            // 
            // nOTICESTableAdapter
            // 
            this.nOTICESTableAdapter.ClearBeforeFill = true;
            // 
            // nOTICEIDDataGridViewTextBoxColumn
            // 
            this.nOTICEIDDataGridViewTextBoxColumn.DataPropertyName = "NOTICE_ID";
            this.nOTICEIDDataGridViewTextBoxColumn.HeaderText = "NOTICE_ID";
            this.nOTICEIDDataGridViewTextBoxColumn.Name = "nOTICEIDDataGridViewTextBoxColumn";
            // 
            // tITLEDataGridViewTextBoxColumn
            // 
            this.tITLEDataGridViewTextBoxColumn.DataPropertyName = "TITLE";
            this.tITLEDataGridViewTextBoxColumn.HeaderText = "TITLE";
            this.tITLEDataGridViewTextBoxColumn.Name = "tITLEDataGridViewTextBoxColumn";
            // 
            // cONTENTDataGridViewTextBoxColumn
            // 
            this.cONTENTDataGridViewTextBoxColumn.DataPropertyName = "CONTENT";
            this.cONTENTDataGridViewTextBoxColumn.HeaderText = "CONTENT";
            this.cONTENTDataGridViewTextBoxColumn.Name = "cONTENTDataGridViewTextBoxColumn";
            // 
            // cREATEDATDataGridViewTextBoxColumn
            // 
            this.cREATEDATDataGridViewTextBoxColumn.DataPropertyName = "CREATED_AT";
            this.cREATEDATDataGridViewTextBoxColumn.HeaderText = "CREATED_AT";
            this.cREATEDATDataGridViewTextBoxColumn.Name = "cREATEDATDataGridViewTextBoxColumn";
            // 
            // AdminNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(848, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.label1);
            this.Name = "AdminNotice";
            this.Text = "공지사항";
            this.Load += new System.EventHandler(this.AdminNotice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nOTICESBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet8 dataSet8;
        private System.Windows.Forms.BindingSource nOTICESBindingSource;
        private DataSet8TableAdapters.NOTICESTableAdapter nOTICESTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOTICEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tITLEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cONTENTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEDATDataGridViewTextBoxColumn;
    }
}