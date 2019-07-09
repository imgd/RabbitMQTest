using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitMQMonitor
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.textBoxReceive.Text = ConfigurationManager.AppSettings["StartReceive"].ToString();
            this.textBoxPush.Text = ConfigurationManager.AppSettings["StartPush"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择.exe启动文件";
            dialog.Filter = "所有文件(*.exe*)|*.exe*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBoxReceive.Text = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择.exe启动文件";
            dialog.Filter = "所有文件(*.exe*)|*.exe*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBoxPush.Text = dialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxReceive.Text) ||
                string.IsNullOrEmpty(this.textBoxPush.Text))
            {
                MessageBox.Show("请选择启动路径！！");
            }
            else if (!File.Exists(this.textBoxReceive.Text) ||
                !File.Exists(this.textBoxPush.Text))
            {
                MessageBox.Show("启动路径不存在，请检查！！");
            }
            else if (!this.textBoxReceive.Text.EndsWith(".exe") ||
                !this.textBoxPush.Text.EndsWith(".exe"))
            {
                MessageBox.Show("启动文件必须是.exe文件。");
            }
            else
            {
                SetConfigValue("StartReceive", this.textBoxReceive.Text);
                SetConfigValue("StartPush", this.textBoxPush.Text);
                MessageBox.Show("保存成功。");
            }
        }

        /// <summary>
        /// 修改AppSettings中配置
        /// </summary>
        /// <param name="key">key值</param>
        /// <param name="value">相应值</param>
        public static bool SetConfigValue(string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings[key] != null)
                    config.AppSettings.Settings[key].Value = value;
                else
                    config.AppSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
