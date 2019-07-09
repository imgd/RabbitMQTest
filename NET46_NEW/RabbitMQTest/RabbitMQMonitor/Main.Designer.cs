namespace RabbitMQMonitor
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.添加一个消费进程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加一个消费进程ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.添加2个消费者进程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加5个消费者进程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加15个消费者进程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭所有消费进程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加一个生产进程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加一个生产者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭所有生产者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.消费者进程 = new System.Windows.Forms.TabPage();
            this.生产者进程 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.contextMenuStripReceive = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.结束进程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripPush = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.结束进程ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.消费者进程.SuspendLayout();
            this.生产者进程.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStripReceive.SuspendLayout();
            this.contextMenuStripPush.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(581, 502);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加一个消费进程ToolStripMenuItem,
            this.添加一个生产进程ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 添加一个消费进程ToolStripMenuItem
            // 
            this.添加一个消费进程ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加一个消费进程ToolStripMenuItem1,
            this.添加2个消费者进程ToolStripMenuItem,
            this.添加5个消费者进程ToolStripMenuItem,
            this.添加15个消费者进程ToolStripMenuItem,
            this.关闭所有消费进程ToolStripMenuItem});
            this.添加一个消费进程ToolStripMenuItem.Name = "添加一个消费进程ToolStripMenuItem";
            this.添加一个消费进程ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.添加一个消费进程ToolStripMenuItem.Text = "消费者";
            this.添加一个消费进程ToolStripMenuItem.Click += new System.EventHandler(this.添加一个消费进程ToolStripMenuItem_Click);
            // 
            // 添加一个消费进程ToolStripMenuItem1
            // 
            this.添加一个消费进程ToolStripMenuItem1.Name = "添加一个消费进程ToolStripMenuItem1";
            this.添加一个消费进程ToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.添加一个消费进程ToolStripMenuItem1.Text = "添加1个消费进程";
            this.添加一个消费进程ToolStripMenuItem1.Click += new System.EventHandler(this.添加一个消费进程ToolStripMenuItem1_Click);
            // 
            // 添加2个消费者进程ToolStripMenuItem
            // 
            this.添加2个消费者进程ToolStripMenuItem.Name = "添加2个消费者进程ToolStripMenuItem";
            this.添加2个消费者进程ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.添加2个消费者进程ToolStripMenuItem.Text = "添加2个消费者进程";
            this.添加2个消费者进程ToolStripMenuItem.Click += new System.EventHandler(this.添加2个消费者进程ToolStripMenuItem_Click);
            // 
            // 添加5个消费者进程ToolStripMenuItem
            // 
            this.添加5个消费者进程ToolStripMenuItem.Name = "添加5个消费者进程ToolStripMenuItem";
            this.添加5个消费者进程ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.添加5个消费者进程ToolStripMenuItem.Text = "添加5个消费者进程";
            this.添加5个消费者进程ToolStripMenuItem.Click += new System.EventHandler(this.添加5个消费者进程ToolStripMenuItem_Click);
            // 
            // 添加15个消费者进程ToolStripMenuItem
            // 
            this.添加15个消费者进程ToolStripMenuItem.Name = "添加15个消费者进程ToolStripMenuItem";
            this.添加15个消费者进程ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.添加15个消费者进程ToolStripMenuItem.Text = "添加15个消费者进程";
            this.添加15个消费者进程ToolStripMenuItem.Click += new System.EventHandler(this.添加15个消费者进程ToolStripMenuItem_Click);
            // 
            // 关闭所有消费进程ToolStripMenuItem
            // 
            this.关闭所有消费进程ToolStripMenuItem.Name = "关闭所有消费进程ToolStripMenuItem";
            this.关闭所有消费进程ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.关闭所有消费进程ToolStripMenuItem.Text = "关闭所有消费进程";
            this.关闭所有消费进程ToolStripMenuItem.Click += new System.EventHandler(this.关闭所有消费进程ToolStripMenuItem_Click);
            // 
            // 添加一个生产进程ToolStripMenuItem
            // 
            this.添加一个生产进程ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加一个生产者ToolStripMenuItem,
            this.关闭所有生产者ToolStripMenuItem});
            this.添加一个生产进程ToolStripMenuItem.Name = "添加一个生产进程ToolStripMenuItem";
            this.添加一个生产进程ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.添加一个生产进程ToolStripMenuItem.Text = "生产者";
            this.添加一个生产进程ToolStripMenuItem.Click += new System.EventHandler(this.添加一个生产进程ToolStripMenuItem_Click);
            // 
            // 添加一个生产者ToolStripMenuItem
            // 
            this.添加一个生产者ToolStripMenuItem.Name = "添加一个生产者ToolStripMenuItem";
            this.添加一个生产者ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.添加一个生产者ToolStripMenuItem.Text = "添加一个生产者";
            this.添加一个生产者ToolStripMenuItem.Click += new System.EventHandler(this.添加一个生产者ToolStripMenuItem_Click);
            // 
            // 关闭所有生产者ToolStripMenuItem
            // 
            this.关闭所有生产者ToolStripMenuItem.Name = "关闭所有生产者ToolStripMenuItem";
            this.关闭所有生产者ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.关闭所有生产者ToolStripMenuItem.Text = "关闭所有生产者";
            this.关闭所有生产者ToolStripMenuItem.Click += new System.EventHandler(this.关闭所有生产者ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.消费者进程);
            this.tabControl1.Controls.Add(this.生产者进程);
            this.tabControl1.Location = new System.Drawing.Point(12, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 537);
            this.tabControl1.TabIndex = 2;
            // 
            // 消费者进程
            // 
            this.消费者进程.Controls.Add(this.dataGridView1);
            this.消费者进程.Location = new System.Drawing.Point(4, 22);
            this.消费者进程.Name = "消费者进程";
            this.消费者进程.Padding = new System.Windows.Forms.Padding(3);
            this.消费者进程.Size = new System.Drawing.Size(593, 511);
            this.消费者进程.TabIndex = 0;
            this.消费者进程.Text = "消费者进程";
            this.消费者进程.UseVisualStyleBackColor = true;
            // 
            // 生产者进程
            // 
            this.生产者进程.Controls.Add(this.dataGridView2);
            this.生产者进程.Location = new System.Drawing.Point(4, 22);
            this.生产者进程.Name = "生产者进程";
            this.生产者进程.Padding = new System.Windows.Forms.Padding(3);
            this.生产者进程.Size = new System.Drawing.Size(593, 511);
            this.生产者进程.TabIndex = 1;
            this.生产者进程.Text = "生产者进程";
            this.生产者进程.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 6);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(581, 499);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDown);
            // 
            // contextMenuStripReceive
            // 
            this.contextMenuStripReceive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.结束进程ToolStripMenuItem});
            this.contextMenuStripReceive.Name = "contextMenuStripReceive";
            this.contextMenuStripReceive.Size = new System.Drawing.Size(125, 26);
            // 
            // 结束进程ToolStripMenuItem
            // 
            this.结束进程ToolStripMenuItem.Name = "结束进程ToolStripMenuItem";
            this.结束进程ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.结束进程ToolStripMenuItem.Text = "结束进程";
            this.结束进程ToolStripMenuItem.Click += new System.EventHandler(this.结束进程ToolStripMenuItem_Click);
            // 
            // contextMenuStripPush
            // 
            this.contextMenuStripPush.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.结束进程ToolStripMenuItem1});
            this.contextMenuStripPush.Name = "contextMenuStripPush";
            this.contextMenuStripPush.Size = new System.Drawing.Size(125, 26);
            // 
            // 结束进程ToolStripMenuItem1
            // 
            this.结束进程ToolStripMenuItem1.Name = "结束进程ToolStripMenuItem1";
            this.结束进程ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.结束进程ToolStripMenuItem1.Text = "结束进程";
            this.结束进程ToolStripMenuItem1.Click += new System.EventHandler(this.结束进程ToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 589);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Queue进程多开程序";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.消费者进程.ResumeLayout(false);
            this.生产者进程.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStripReceive.ResumeLayout(false);
            this.contextMenuStripPush.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加一个消费进程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加一个生产进程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加一个消费进程ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关闭所有消费进程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加一个生产者ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭所有生产者ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage 消费者进程;
        private System.Windows.Forms.TabPage 生产者进程;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripReceive;
        private System.Windows.Forms.ToolStripMenuItem 结束进程ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPush;
        private System.Windows.Forms.ToolStripMenuItem 结束进程ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 添加2个消费者进程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加5个消费者进程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加15个消费者进程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
    }
}

