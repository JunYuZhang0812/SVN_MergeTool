using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SVN_MergeTool
{
    public partial class SVN_MergeTool : Form
    {
        enum AsyncType
        {
            commit,
            updata,
            clearUp,
            revert,
            showLog,
            merge,
        }
        System.Text.RegularExpressions.Regex m_regex = new System.Text.RegularExpressions.Regex(@"(\\|/)$");
        Logic m_logicIns = Logic.Instance;
        List<XElement> m_srcXmls,m_tarXmls;
        List<XElement> m_directoryTypeXmls;

        int ScreenLeft = 0;
        int ScreenRight = 0;
        bool m_isShow = true;
        public SVN_MergeTool()
        {
            InitializeComponent();
            InitData();
            InitPanel();
            timer1.Interval = 200;
            timer1.Start();
        }
        private void InitData()
        {
            m_srcXmls = m_logicIns.GetXmlAllElement();
            m_tarXmls = m_srcXmls;
            m_directoryTypeXmls = m_logicIns.DirTypeXmlFile.GetXmlAllElement();
            m_logicIns.Working = false;

            ScreenLeft = 0;
            ScreenRight = 0;
            var scenes = Screen.AllScreens;
            for (int i = 0; i < scenes.Length; i++)
            {
                var area = scenes[i].WorkingArea;
                if (area.Left < ScreenLeft)
                    ScreenLeft = area.Left;
                if (area.Right > ScreenRight)
                    ScreenRight = area.Right;
            }
        }

        private void InitPanel()
        {
            m_addPanel.Location = new Point(3, 4);
            m_addPanel.Visible = false;
            /*var autoHide = Logic.Instance.XmlFile.GetXmlElement("AutoHide");
            if( autoHide != null)
            {
                m_autoHide.Checked = autoHide.Value == "true";
            }
            else
            {
                m_autoHide.Checked = true;
            }*/
            InitFileDirectory();
            InitDirectoryType();
        }
        private void InitFileDirectory()
        {
            for (int i = 0; i < m_srcXmls.Count; i++)
            {
                m_comSrc.Items.Add(m_srcXmls[i].Value);
            }
            if(m_comSrc.Items.Count>0)
            {
                int index = 0;
                if( int.TryParse(Logic.Instance.GetXmlElementValue("SrcIndex"),out index ))
                {

                }
                m_comSrc.SelectedIndex = index;
            }
            for (int i = 0; i < m_tarXmls.Count; i++)
            {
                m_comTar.Items.Add(m_tarXmls[i].Value);
            }
            if (m_comTar.Items.Count > 0)
            {
                int index = 0;
                if (int.TryParse(Logic.Instance.GetXmlElementValue("TarIndex"), out index))
                {

                }
                m_comTar.SelectedIndex = index;
            }
        }
        private void InitDirectoryType()
        {
            for (int i = 0; i < m_directoryTypeXmls.Count; i++)
            {
                m_directoryType.Items.Add(m_directoryTypeXmls[i].Value);
            }
            if (m_directoryType.Items.Count > 0)
                m_directoryType.SelectedIndex = int.Parse( m_logicIns.DirTypeXmlFile.GetXmlElementValue("index") );
        }
        #region 面板操作
        private void m_btnCommit_Click(object sender, EventArgs e)
        {
            BeginAsyncWorker(AsyncType.commit);
        }

        private void m_btnMerge_Click(object sender, EventArgs e)
        {
            XElement xDirTypeElement = m_directoryTypeXmls[m_logicIns.DirectoryTypeIndex];
            var addPath = m_logicIns.DirTypeXmlFile.GetXmlAttribut("addPath", xDirTypeElement);
            if(addPath != "" )
            {
                var re = MessageBox.Show("当前目录不是Client目录，点击确认切换到Client目录进行合并", "提示", MessageBoxButtons.OKCancel);
                if(re == DialogResult.OK)
                {
                    for (int i = 0; i < m_directoryTypeXmls.Count; i++)
                    {
                        var path = m_logicIns.DirTypeXmlFile.GetXmlAttribut("addPath", m_directoryTypeXmls[i]);
                        if (path == "")
                        {
                            m_directoryType.SelectedIndex = i;
                        }
                    }
                }
            }
            BeginAsyncWorker(AsyncType.merge);
        }

        private void m_btnUpdata_Click(object sender, EventArgs e)
        {
            BeginAsyncWorker(AsyncType.updata);
        }

        private void m_btnClear_Click(object sender, EventArgs e)
        {
            BeginAsyncWorker(AsyncType.clearUp);
        }
        private void m_btnRevert_Click(object sender, EventArgs e)
        {
            BeginAsyncWorker(AsyncType.revert);
        }
        private void m_btnLog_Click(object sender, EventArgs e)
        {
            BeginAsyncWorker(AsyncType.showLog);
        }

        private void m_btnOpenSrcPath_Click(object sender, EventArgs e)
        {
            int currIndex = m_comSrc.SelectedIndex;
            XElement xElement = m_srcXmls[currIndex];
            var path = m_logicIns.GetXmlAttribut("path", xElement);
            path = GetFullPath(path);
            System.Diagnostics.Process.Start(path);
        }

        private void m_btnOpenTarPath_Click(object sender, EventArgs e)
        {
            int currIndex = m_comTar.SelectedIndex;
            XElement xElement = m_tarXmls[currIndex];
            var path = m_logicIns.GetXmlAttribut("path", xElement);
            path = GetFullPath(path);
            System.Diagnostics.Process.Start(path);
        }
        private void m_btnCompare_Click(object sender, EventArgs e)
        {
            int currSrcIndex = m_logicIns.CurrSrcIndex;
            XElement fromElement = m_srcXmls[currSrcIndex];
            string fromPath = m_logicIns.GetXmlAttribut("path", fromElement);
            int currTarIndex = m_logicIns.CurrTarIndex;
            XElement toElement = m_tarXmls[currTarIndex];
            var tarPath = m_logicIns.GetXmlAttribut("path", toElement);
            tarPath = GetFullPath(tarPath);
            fromPath = GetFullPath(fromPath);
            CompareUtil.CompareFolder(fromPath, tarPath);
        }
        private void BeginAsyncWorker(AsyncType asyncWorkType)
        {
            if (m_logicIns.Working)
            {
                //MessageBox.Show("不能同时进行多个SVN操作");
                //return;
            }
            m_logicIns.Working = true;
            m_asyncWorker.RunWorkerAsync(asyncWorkType);
        }
        private void m_comSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_logicIns.CurrSrcIndex = m_comSrc.SelectedIndex;
            Logic.Instance.SetOrAddElement("SrcIndex" , m_comSrc.SelectedIndex.ToString());
        }

        private void m_comTar_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_logicIns.CurrTarIndex = m_comTar.SelectedIndex;
            Logic.Instance.SetOrAddElement("TarIndex", m_comTar.SelectedIndex.ToString());
        }
        private void m_asyncWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            AsyncType _type = (AsyncType)e.Argument;
            int currTarIndex = m_logicIns.CurrTarIndex;
            XElement xElement = m_tarXmls[currTarIndex];
            var tarPath = m_logicIns.GetXmlAttribut("path", xElement);
            tarPath = GetFullPath(tarPath);
            if (!PathCheck(tarPath)) return;
            switch (_type)
            {
                case AsyncType.commit:
                    SvnUtils.CommitSvnDirectory(tarPath);
                    break;
                case AsyncType.merge:
                    int currSrcIndex = m_logicIns.CurrSrcIndex;
                    XElement fromElement = m_srcXmls[currSrcIndex];
                    string fromUrl = m_logicIns.GetXmlAttribut("url", fromElement);
                    string fromPath = m_logicIns.GetXmlAttribut("path", fromElement);
                    fromUrl = GetFullPath(fromUrl);
                    fromPath = GetFullPath(fromPath);
                    if (fromPath == tarPath)
                    {
                        MessageBox.Show("源目录与目标目录一样，不可合并！");
                        return;
                    }
                    SvnUtils.MergeSvnFile(tarPath, fromUrl);
                    break;
                case AsyncType.updata:
                    SvnUtils.UpdateSvnDirectory(tarPath);
                    break;
                case AsyncType.clearUp:
                    SvnUtils.CleanUpSvnDirectory(tarPath);
                    break;
                case AsyncType.revert:
                    SvnUtils.RevertSvnDirectory(tarPath);
                    break;
                case AsyncType.showLog:
                    SvnUtils.ShowLogSvnFile(tarPath);
                    break;
            }
        }
        private void m_asynWorker_Complete(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            m_logicIns.Working = false;
        }
        #endregion
        private string GetFullPath(string path)
        {

            XElement xDirTypeElement = m_directoryTypeXmls[m_logicIns.DirectoryTypeIndex];
            var addPath = m_logicIns.DirTypeXmlFile.GetXmlAttribut("addPath", xDirTypeElement);
            if(m_regex.IsMatch(path))
            {
                return path + addPath;
            }
            else
            {
                return path + "/" + addPath;
            }
        }
        private void m_comSrc_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(m_comSrc.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y + 3);
        }
        private void m_comTar_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(m_comTar.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y + 3);
        }

        private bool PathCheck(string path)
        {
            if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
            {
                return true;
            }
            MessageBox.Show("文件夹路径不存在！" + path);
            return false;
        }
        #region 桌面效果相关

        //边缘停靠
        private void timer1_Tick(object sender, EventArgs e)
        {
            dt += timer1.Interval / 1000.0f;
            if (dt > 1)
            {
                dt -= 1;
                SecondUpdate();
            }
            //if (!m_autoHide.Checked) return;
            if (m_comSrc.DroppedDown || m_comTar.DroppedDown) return;
            AutoSideHideOrShow();
        }

        private float dt = 0;
        private void SecondUpdate()
        {
            if (!m_isShow)
            {
                Focus();
            }
        }
        void AutoSideHideOrShow()
        {
            int sideThickness = 5;//边缘的厚度，窗体停靠在边缘隐藏后留出来的可见部分的厚度
            //如果窗体最小化或最大化了则什么也不做
            if (this.WindowState == FormWindowState.Minimized || this.WindowState == FormWindowState.Maximized)
            {
                return;
            }
            var ScreenTop = 0;
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                var area = Screen.AllScreens[i].WorkingArea;
                if (Cursor.Position.X >= area.Left && Cursor.Position.X < area.Right )
                {
                    ScreenTop = area.Top;
                    break;
                }
            }
            //如果鼠标在窗体内
            if (Cursor.Position.X >= this.Left && Cursor.Position.X < this.Right && Cursor.Position.Y >= this.Top && Cursor.Position.Y < this.Bottom)
            {
                //如果窗体离屏幕边缘很近，则自动停靠在该边缘
                if (this.Top <= ScreenTop + sideThickness)
                {
                    this.Top = ScreenTop;
                }
                if (this.Left <= ScreenLeft + sideThickness)
                {
                    this.Left = ScreenLeft;
                }
                if (this.Left >= ScreenRight - this.Width - sideThickness)
                {
                    this.Left = ScreenRight - this.Width;
                }
                m_isShow = true;
            }
            //当鼠标离开窗体以后
            else
            {
                m_isShow = false;
                //隐藏到屏幕左边缘
                if (this.Left == ScreenLeft)
                {
                    this.Left = ScreenLeft + sideThickness - this.Width;
                }
                //隐藏到屏幕右边缘
                else if (this.Left == ScreenRight - this.Width)
                {
                    this.Left = ScreenRight - sideThickness;
                }
                //隐藏到屏幕上边缘
                else if (this.Top == ScreenTop && this.Left > ScreenLeft && this.Left < ScreenRight - this.Width)
                {
                    this.Top = ScreenTop + sideThickness - this.Height;
                }
            }
        }

        #endregion
        #region 拖拽相关
        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            m_addPanel.Visible = true;
            // 对文件拖拽事件做处理 
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            m_addPanel.Visible = false;
        }

        private void m_btnAdd_Click(object sender, EventArgs e)
        {
            if( string.IsNullOrEmpty(m_inputName.Text))
            {
                MessageBox.Show("请输入名字！");
                return;
            }
            if( !Directory.Exists(m_inputPath.Text))
            {
                MessageBox.Show("文件路径不正确，找不到文件！");
                return;
            }
            XElement xElement = new XElement("name");
            xElement.Value = m_inputName.Text;
            XAttribute xa1 = new XAttribute("path", m_inputPath.Text);
            xElement.Add(xa1);
            XAttribute xa2 = new XAttribute("url", m_inputSVN.Text);
            xElement.Add(xa2);
            Logic.Instance.XmlFile.AddXmlElement(xElement);
            m_srcXmls.Add(xElement);
            m_tarXmls.Add(xElement);
            m_comSrc.Items.Add(xElement.Value);
            m_comTar.Items.Add(xElement.Value);
            m_addPanel.Visible = false;
        }

        private void m_autoHide_CheckedChanged(object sender, EventArgs e)
        {
            //Logic.Instance.XmlFile.SetOrAddXmlElement("AutoHide", m_autoHide.Checked ? "true" : "false" );
        }

        private void m_directoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_logicIns.DirTypeXmlFile.SetOrAddXmlElement("index", m_directoryType.SelectedIndex.ToString());
            m_logicIns.DirectoryTypeIndex = m_directoryType.SelectedIndex;
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            if (!m_addPanel.Visible) return;
            var filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filePath.Length > 0)
            {
                var file = filePath[0];
                var ex = Path.GetExtension(file);
                m_inputPath.Text = file;
                m_inputSVN.Text = SvnUtils.GetUri(file);
            }
        }
        #endregion
    }
}
