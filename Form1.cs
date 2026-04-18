using System;
using System.Windows.Forms;

namespace exam
{
    public partial class Form1 : Form
    {
        private ApiHost apiHost = new ApiHost();

        public Form1()
        {
            InitializeComponent();

            // 日志绑定
            DataCenter.LogAction = (msg) =>
            {
                Invoke(new Action(() =>
                {
                    txtLog.AppendText(msg + Environment.NewLine);
                }));
            };
        }

        // 启动服务
        private void btnStart_Click(object sender, EventArgs e)
        {
            apiHost.Start(9095);
        }

        // 停止服务
        private void btnStop_Click(object sender, EventArgs e)
        {
            apiHost.Stop();
        }

        // 加载学生数据（下发）
        private void btnLoadStudents_Click(object sender, EventArgs e)
        {
            DataCenter.Students.Clear();

            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                //if (row.Cells[0].Value == null) continue;

                DataCenter.Students.Add(new Student
                {
                    //test_id = row.Cells[0].Value.ToString(),
                    //name = row.Cells[1].Value.ToString(),
                    //gender = row.Cells[2].Value.ToString(),
                    //current_class = row.Cells[3].Value.ToString()
                    test_id = "1",
                    name = "赵四",
                    gender = "男",
                    current_class = "1",       
                    id_card_number = null,
                    ethnic ="01",
                    birth = null,
                    address = null,
                    age = null,
                    current_grade =23,
                    gradename ="初中三年级",
                    school = "高新区第一初级中学"
                });
            }
            DataCenter.Log($"已加载学生：{DataCenter.Students.Count}条");
        }
    }
}