using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitMQMonitor
{
    public partial class Main : Form
    {
        //消费进程名称
        private static string executeNameReceive
        {
            get
            {
                var path = ConfigurationManager.AppSettings["StartReceive"];
                var index = path.LastIndexOf("\\");
                return path.Substring(index + 1, path.Length - index - 5);
            }
        }

        //生产进程名称
        private static string executeNamePush
        {
            get
            {
                var path = ConfigurationManager.AppSettings["StartPush"];
                var index = path.LastIndexOf("\\");
                return path.Substring(index + 1, path.Length - index - 5);
            }
        }
        public Main()
        {
            InitializeComponent();
            ResetGirdViewData();
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += Timer1_Tick;
            //this.timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ResetGirdViewData();
        }

        private void ResetGirdViewData()
        {
            var process = Process.GetProcessesByName(executeNameReceive);
            var process2 = Process.GetProcessesByName(executeNamePush);

            this.dataGridView1.DataSource = GetDataView(process);
            this.dataGridView2.DataSource = GetDataView(process2);
        }
        private List<object> GetDataView(Process[] Processs)
        {
            var result = new List<object>();
            var index = 1;
            foreach (Process item in Processs)
            {
                var cpuCounter = new PerformanceCounter("Process", "% Processor Time", item.ProcessName, true);
                result.Add(new
                {
                    序号 = index,
                    状态 = "运行中",
                    SPID = item.Id,
                    进程名 = item.ProcessName,
                    内存 = $"{(long)(item.WorkingSet64) / 1024 / 1024}MB",
                    CPU = $"{cpuCounter.NextValue()}%",
                    磁盘 = $"{0}MB/秒",
                    网络 = $"{0}Mbps"
                });
                index++;
            }
            return result;
        }
        private string GetCPU(Process process)
        {
            //间隔时间（毫秒）
            int interval = 1000;
            //上次记录的CPU时间

            //当前时间
            var curTime = process.TotalProcessorTime;
            //间隔时间内的CPU运行时间除以逻辑CPU数量
            var value = (curTime - TimeSpan.Zero).TotalMilliseconds / interval / Environment.ProcessorCount * 100;

            return $"{value.ToString()}%";

        }

        private void 添加一个消费进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 添加一个生产进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 添加一个消费进程ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Process poc = new Process();
            poc.StartInfo.FileName = GetReceiveFilePath();
            poc.StartInfo.CreateNoWindow = true;
            poc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            poc.Start();
            MessageBox.Show("消费者添加成功。");

        }

        private void 添加一个生产者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process poc = new Process();
            poc.StartInfo.FileName = GetPushFilePath();
            poc.StartInfo.CreateNoWindow = true;
            poc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            poc.Start();
            MessageBox.Show("生产者添加成功。");
        }

        private string GetReceiveFilePath()
        {
            return ConfigurationManager.AppSettings["StartReceive"];
        }
        private string GetPushFilePath()
        {
            return ConfigurationManager.AppSettings["StartPush"];
        }

        private void 关闭所有消费进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("确定要关闭所有消费者进程。", "友情提醒", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                var process = Process.GetProcessesByName(executeNameReceive);
                foreach (var item in process)
                {
                    item.Kill();
                }

                MessageBox.Show("关闭成功");
            }

        }

        private void 关闭所有生产者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("确定要关闭所有生产者进程。", "友情提醒", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                var process = Process.GetProcessesByName(executeNamePush);
                foreach (var item in process)
                {
                    item.Kill();
                }

                MessageBox.Show("关闭成功");
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    contextMenuStripReceive.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void 结束进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectRows = this.dataGridView1.SelectedRows.Count;
            if (selectRows == 1)
            {
                var spid = this.dataGridView1.SelectedRows[0].Cells[2].Value;
                var proc = Process.GetProcessById(Convert.ToInt32(spid), Environment.MachineName);
                proc.Kill();
                MessageBox.Show("已结束进程");
            }
        }

        private void 结束进程ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var selectRows = this.dataGridView2.SelectedRows.Count;
            if (selectRows == 1)
            {
                var spid = this.dataGridView2.SelectedRows[0].Cells[2].Value;
                var proc = Process.GetProcessById(Convert.ToInt32(spid), Environment.MachineName);
                proc.Kill();
                MessageBox.Show("已结束进程");
            }
        }

        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView2.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView2.ClearSelection();
                        dataGridView2.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView2.SelectedRows.Count == 1)
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    contextMenuStripPush.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void 添加2个消费者进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                Process poc = new Process();
                poc.StartInfo.FileName = GetReceiveFilePath();
                poc.StartInfo.CreateNoWindow = true;
                poc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                poc.Start();
            }

            MessageBox.Show("消费者添加成功。");
        }

        private void 添加5个消费者进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Process poc = new Process();
                poc.StartInfo.FileName = GetReceiveFilePath();
                poc.StartInfo.CreateNoWindow = true;
                poc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                poc.Start();
            }

            MessageBox.Show("消费者添加成功。");
        }

        private void 添加15个消费者进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                Process poc = new Process();
                poc.StartInfo.FileName = GetReceiveFilePath();
                poc.StartInfo.CreateNoWindow = true;
                poc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                poc.Start();
            }

            MessageBox.Show("消费者添加成功。");
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings setfrom = new Settings();
            setfrom.ShowDialog();
        }
    }
}
