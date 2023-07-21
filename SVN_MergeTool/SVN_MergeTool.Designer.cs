namespace SVN_MergeTool
{
    partial class SVN_MergeTool
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
            this.m_comSrc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_comTar = new System.Windows.Forms.ComboBox();
            this.m_btnCommit = new System.Windows.Forms.Button();
            this.m_btnMerge = new System.Windows.Forms.Button();
            this.m_btnUpdata = new System.Windows.Forms.Button();
            this.m_btnClear = new System.Windows.Forms.Button();
            this.m_btnRevert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.m_btnOpenSrcPath = new System.Windows.Forms.Button();
            this.m_btnOpenTarPath = new System.Windows.Forms.Button();
            this.m_btnLog = new System.Windows.Forms.Button();
            this.m_asyncWorker = new System.ComponentModel.BackgroundWorker();
            this.m_btnCompare = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.m_addPanel = new System.Windows.Forms.Panel();
            this.m_btnAdd = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_inputSVN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_inputPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_inputName = new System.Windows.Forms.TextBox();
            this.m_directoryType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_notifyIconMenu = new System.Windows.Forms.NotifyIcon(this.components);
            this.m_addPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_comSrc
            // 
            this.m_comSrc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.m_comSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comSrc.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_comSrc.FormattingEnabled = true;
            this.m_comSrc.IntegralHeight = false;
            this.m_comSrc.ItemHeight = 22;
            this.m_comSrc.Location = new System.Drawing.Point(71, 28);
            this.m_comSrc.MaxDropDownItems = 10;
            this.m_comSrc.Name = "m_comSrc";
            this.m_comSrc.Size = new System.Drawing.Size(199, 28);
            this.m_comSrc.TabIndex = 0;
            this.m_comSrc.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.m_comSrc_DrawItem);
            this.m_comSrc.SelectedIndexChanged += new System.EventHandler(this.m_comSrc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "源目录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "目标目录";
            // 
            // m_comTar
            // 
            this.m_comTar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.m_comTar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comTar.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_comTar.FormattingEnabled = true;
            this.m_comTar.ItemHeight = 22;
            this.m_comTar.Location = new System.Drawing.Point(71, 110);
            this.m_comTar.MaxDropDownItems = 10;
            this.m_comTar.Name = "m_comTar";
            this.m_comTar.Size = new System.Drawing.Size(199, 28);
            this.m_comTar.TabIndex = 3;
            this.m_comTar.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.m_comTar_DrawItem);
            this.m_comTar.SelectedIndexChanged += new System.EventHandler(this.m_comTar_SelectedIndexChanged);
            // 
            // m_btnCommit
            // 
            this.m_btnCommit.Location = new System.Drawing.Point(296, 28);
            this.m_btnCommit.Name = "m_btnCommit";
            this.m_btnCommit.Size = new System.Drawing.Size(75, 23);
            this.m_btnCommit.TabIndex = 4;
            this.m_btnCommit.Text = "提交";
            this.m_btnCommit.UseVisualStyleBackColor = true;
            this.m_btnCommit.Click += new System.EventHandler(this.m_btnCommit_Click);
            // 
            // m_btnMerge
            // 
            this.m_btnMerge.Location = new System.Drawing.Point(382, 28);
            this.m_btnMerge.Name = "m_btnMerge";
            this.m_btnMerge.Size = new System.Drawing.Size(75, 110);
            this.m_btnMerge.TabIndex = 5;
            this.m_btnMerge.Text = "合并";
            this.m_btnMerge.UseVisualStyleBackColor = true;
            this.m_btnMerge.Click += new System.EventHandler(this.m_btnMerge_Click);
            // 
            // m_btnUpdata
            // 
            this.m_btnUpdata.Location = new System.Drawing.Point(296, 57);
            this.m_btnUpdata.Name = "m_btnUpdata";
            this.m_btnUpdata.Size = new System.Drawing.Size(75, 23);
            this.m_btnUpdata.TabIndex = 6;
            this.m_btnUpdata.Text = "更新";
            this.m_btnUpdata.UseVisualStyleBackColor = true;
            this.m_btnUpdata.Click += new System.EventHandler(this.m_btnUpdata_Click);
            // 
            // m_btnClear
            // 
            this.m_btnClear.Location = new System.Drawing.Point(296, 86);
            this.m_btnClear.Name = "m_btnClear";
            this.m_btnClear.Size = new System.Drawing.Size(75, 23);
            this.m_btnClear.TabIndex = 7;
            this.m_btnClear.Text = "清理";
            this.m_btnClear.UseVisualStyleBackColor = true;
            this.m_btnClear.Click += new System.EventHandler(this.m_btnClear_Click);
            // 
            // m_btnRevert
            // 
            this.m_btnRevert.Location = new System.Drawing.Point(296, 115);
            this.m_btnRevert.Name = "m_btnRevert";
            this.m_btnRevert.Size = new System.Drawing.Size(75, 23);
            this.m_btnRevert.TabIndex = 8;
            this.m_btnRevert.Text = "还原";
            this.m_btnRevert.UseVisualStyleBackColor = true;
            this.m_btnRevert.Click += new System.EventHandler(this.m_btnRevert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(296, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "下列操作都是针对目标目录哦";
            // 
            // m_btnOpenSrcPath
            // 
            this.m_btnOpenSrcPath.Location = new System.Drawing.Point(195, 62);
            this.m_btnOpenSrcPath.Name = "m_btnOpenSrcPath";
            this.m_btnOpenSrcPath.Size = new System.Drawing.Size(75, 23);
            this.m_btnOpenSrcPath.TabIndex = 10;
            this.m_btnOpenSrcPath.Text = "打开目录";
            this.m_btnOpenSrcPath.UseVisualStyleBackColor = true;
            this.m_btnOpenSrcPath.Click += new System.EventHandler(this.m_btnOpenSrcPath_Click);
            // 
            // m_btnOpenTarPath
            // 
            this.m_btnOpenTarPath.Location = new System.Drawing.Point(195, 144);
            this.m_btnOpenTarPath.Name = "m_btnOpenTarPath";
            this.m_btnOpenTarPath.Size = new System.Drawing.Size(75, 23);
            this.m_btnOpenTarPath.TabIndex = 11;
            this.m_btnOpenTarPath.Text = "打开目录";
            this.m_btnOpenTarPath.UseVisualStyleBackColor = true;
            this.m_btnOpenTarPath.Click += new System.EventHandler(this.m_btnOpenTarPath_Click);
            // 
            // m_btnLog
            // 
            this.m_btnLog.Location = new System.Drawing.Point(296, 144);
            this.m_btnLog.Name = "m_btnLog";
            this.m_btnLog.Size = new System.Drawing.Size(75, 23);
            this.m_btnLog.TabIndex = 12;
            this.m_btnLog.Text = "查看日志";
            this.m_btnLog.UseVisualStyleBackColor = true;
            this.m_btnLog.Click += new System.EventHandler(this.m_btnLog_Click);
            // 
            // m_asyncWorker
            // 
            this.m_asyncWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_asyncWorker_DoWork);
            this.m_asyncWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_asynWorker_Complete);
            // 
            // m_btnCompare
            // 
            this.m_btnCompare.Location = new System.Drawing.Point(382, 144);
            this.m_btnCompare.Name = "m_btnCompare";
            this.m_btnCompare.Size = new System.Drawing.Size(75, 23);
            this.m_btnCompare.TabIndex = 13;
            this.m_btnCompare.Text = "比较文件夹";
            this.m_btnCompare.UseVisualStyleBackColor = true;
            this.m_btnCompare.Click += new System.EventHandler(this.m_btnCompare_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // m_addPanel
            // 
            this.m_addPanel.Controls.Add(this.m_btnAdd);
            this.m_addPanel.Controls.Add(this.m_btnCancel);
            this.m_addPanel.Controls.Add(this.m_inputSVN);
            this.m_addPanel.Controls.Add(this.label6);
            this.m_addPanel.Controls.Add(this.m_inputPath);
            this.m_addPanel.Controls.Add(this.label5);
            this.m_addPanel.Controls.Add(this.label4);
            this.m_addPanel.Controls.Add(this.m_inputName);
            this.m_addPanel.Location = new System.Drawing.Point(276, 86);
            this.m_addPanel.Name = "m_addPanel";
            this.m_addPanel.Size = new System.Drawing.Size(454, 163);
            this.m_addPanel.TabIndex = 14;
            // 
            // m_btnAdd
            // 
            this.m_btnAdd.Location = new System.Drawing.Point(293, 106);
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(75, 23);
            this.m_btnAdd.TabIndex = 7;
            this.m_btnAdd.Text = "确定";
            this.m_btnAdd.UseVisualStyleBackColor = true;
            this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Location = new System.Drawing.Point(114, 106);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.m_btnCancel.TabIndex = 6;
            this.m_btnCancel.Text = "取消";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_inputSVN
            // 
            this.m_inputSVN.Location = new System.Drawing.Point(81, 63);
            this.m_inputSVN.Name = "m_inputSVN";
            this.m_inputSVN.Size = new System.Drawing.Size(351, 21);
            this.m_inputSVN.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "SVN路径：";
            // 
            // m_inputPath
            // 
            this.m_inputPath.Location = new System.Drawing.Point(81, 37);
            this.m_inputPath.Name = "m_inputPath";
            this.m_inputPath.Size = new System.Drawing.Size(351, 21);
            this.m_inputPath.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "本地路径：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "名字：";
            // 
            // m_inputName
            // 
            this.m_inputName.Location = new System.Drawing.Point(81, 12);
            this.m_inputName.Name = "m_inputName";
            this.m_inputName.Size = new System.Drawing.Size(351, 21);
            this.m_inputName.TabIndex = 0;
            // 
            // m_directoryType
            // 
            this.m_directoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_directoryType.FormattingEnabled = true;
            this.m_directoryType.Location = new System.Drawing.Point(71, 2);
            this.m_directoryType.Name = "m_directoryType";
            this.m_directoryType.Size = new System.Drawing.Size(121, 20);
            this.m_directoryType.TabIndex = 15;
            this.m_directoryType.SelectedIndexChanged += new System.EventHandler(this.m_directoryType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "目录后缀";
            // 
            // m_notifyIconMenu
            // 
            this.m_notifyIconMenu.Visible = true;
            // 
            // SVN_MergeTool
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 175);
            this.Controls.Add(this.m_addPanel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_directoryType);
            this.Controls.Add(this.m_btnCompare);
            this.Controls.Add(this.m_btnLog);
            this.Controls.Add(this.m_btnOpenTarPath);
            this.Controls.Add(this.m_btnOpenSrcPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_btnRevert);
            this.Controls.Add(this.m_btnClear);
            this.Controls.Add(this.m_btnUpdata);
            this.Controls.Add(this.m_btnMerge);
            this.Controls.Add(this.m_btnCommit);
            this.Controls.Add(this.m_comTar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_comSrc);
            this.MaximumSize = new System.Drawing.Size(1200, 1800);
            this.MinimumSize = new System.Drawing.Size(477, 209);
            this.Name = "SVN_MergeTool";
            this.ShowInTaskbar = true;
            this.Text = "SVN合并工具";
            this.TopMost = true;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.m_addPanel.ResumeLayout(false);
            this.m_addPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox m_comSrc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_comTar;
        private System.Windows.Forms.Button m_btnCommit;
        private System.Windows.Forms.Button m_btnMerge;
        private System.Windows.Forms.Button m_btnUpdata;
        private System.Windows.Forms.Button m_btnClear;
        private System.Windows.Forms.Button m_btnRevert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_btnOpenSrcPath;
        private System.Windows.Forms.Button m_btnOpenTarPath;
        private System.Windows.Forms.Button m_btnLog;
        private System.ComponentModel.BackgroundWorker m_asyncWorker;
        private System.Windows.Forms.Button m_btnCompare;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel m_addPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_inputName;
        private System.Windows.Forms.TextBox m_inputSVN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox m_inputPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button m_btnAdd;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.ComboBox m_directoryType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NotifyIcon m_notifyIconMenu;
    }
}

