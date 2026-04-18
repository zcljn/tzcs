namespace exam
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            btnStop = new Button();
            txtLog = new TextBox();
            dgvStudents = new DataGridView();
            btnLoadStudents = new Button();
            id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            gender = new DataGridViewTextBoxColumn();
            cl = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnStart.Location = new Point(79, 33);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(89, 43);
            btnStart.TabIndex = 0;
            btnStart.Text = "开启";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnStop.Location = new Point(211, 33);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(89, 43);
            btnStop.TabIndex = 0;
            btnStop.Text = "停止";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(632, 2);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(506, 551);
            txtLog.TabIndex = 1;
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Columns.AddRange(new DataGridViewColumn[] { id, name, gender, cl });
            dgvStudents.Location = new Point(1, 116);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.Size = new Size(602, 437);
            dgvStudents.TabIndex = 2;
            // 
            // btnLoadStudents
            // 
            btnLoadStudents.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnLoadStudents.Location = new Point(349, 33);
            btnLoadStudents.Name = "btnLoadStudents";
            btnLoadStudents.Size = new Size(124, 43);
            btnLoadStudents.TabIndex = 0;
            btnLoadStudents.Text = "加载学生";
            btnLoadStudents.UseVisualStyleBackColor = true;
            btnLoadStudents.Click += btnLoadStudents_Click;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.Name = "id";
            // 
            // name
            // 
            name.HeaderText = "姓名";
            name.Name = "name";
            // 
            // gender
            // 
            gender.HeaderText = "性别";
            gender.Name = "gender";
            // 
            // cl
            // 
            cl.HeaderText = "班级";
            cl.Name = "cl";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 555);
            Controls.Add(dgvStudents);
            Controls.Add(txtLog);
            Controls.Add(btnLoadStudents);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private TextBox txtLog;
        private DataGridView dgvStudents;
        private Button btnLoadStudents;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn gender;
        private DataGridViewTextBoxColumn cl;
    }
}
