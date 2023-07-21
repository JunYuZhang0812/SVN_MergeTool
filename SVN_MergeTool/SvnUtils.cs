using SharpSvn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SVN_MergeTool
{
    class SvnUtils
    {
        /// <summary>
        /// 合并文件
        /// </summary>
        public static int MergeSvnFile(string tarPath, string fromurl = null, string fromrev = null)
        {
            if (!string.IsNullOrEmpty(tarPath))
            {
                if (!string.IsNullOrEmpty(fromurl))
                {
                    if (!string.IsNullOrEmpty(fromrev))
                        return ExecuteProcess(GetSvnProcPath(), string.Format("/command:merge /path:{0} /fromurl:{1} /revrange:{2} /closeonend:0", tarPath, fromurl, fromrev));
                    else
                        return ExecuteProcess(GetSvnProcPath(), string.Format("/command:merge /path:{0} /fromurl:{1} /closeonend:0", tarPath, fromurl));
                }
                else
                    return ExecuteProcess(GetSvnProcPath(), string.Format("/command:merge /path:{0} /closeonend:0", tarPath));
            }
            return -1;
        }
        /// <summary>
        /// 删除本地文件并更新SVN
        /// </summary>
        public static int DelAndUpdateSvnFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return ExecuteProcess(GetSvnProcPath(), string.Format("/command:update /path:{0} /closeonend:0", path));
        }
        /// <summary>
        /// 还原SVN
        /// </summary>
        public static int RevertSvnDirectory(params string[] paths)
        {
            if (paths != null && paths.Length > 0)
            {
                var path = GetSVNOperatePath(paths);
                return ExecuteProcess(GetSvnProcPath(), string.Format("/command:revert -r /path:{0} /closeonend:0", path));
            }
            return -1;
        }
        /// <summary>
        /// 还原并更新SVN
        /// </summary>
        public static int RevertAndUpdateSvnDirectory(params string[] paths)
        {
            if (paths != null && paths.Length > 0)
            {
                var path = GetSVNOperatePath(paths);
                var exitCode1 = ExecuteProcess(GetSvnProcPath(), string.Format("/command:revert -r /path:{0} /closeonend:0", path));
                var exitCode2 = ExecuteProcess(GetSvnProcPath(), string.Format("/command:update /path:{0} /closeonend:0", path));
                if (exitCode1 != 0) return exitCode1;
                if (exitCode2 != 0) return exitCode2;
            }
            return 0;
        }
        /// <summary>
        /// 更新SVN
        /// </summary>
        public static int UpdateSvnDirectory(params string[] paths)
        {
            if (paths != null && paths.Length > 0)
            {
                var path = GetSVNOperatePath(paths);
                return ExecuteProcess(GetSvnProcPath(), string.Format("/command:update /path:{0} /closeonend:0", path));
            }
            return -1;
        }
        /// <summary>
        /// 清理SVN
        /// </summary>
        public static int CleanUpSvnDirectory(params string[] paths)
        {
            if (paths != null && paths.Length > 0)
            {
                var path = GetSVNOperatePath(paths);
                return ExecuteProcess(GetSvnProcPath(), string.Format("/command:cleanup /path:{0} /closeonend:0", path));
            }
            return -1;
        }
        /// <summary>
        /// 提交SVN
        /// </summary>
        public static int CommitSvnDirectory(params string[] paths)
        {
            if (paths != null && paths.Length > 0)
            {
                var path = GetSVNOperatePath(paths);
                return ExecuteProcess(GetSvnProcPath(), string.Format("/command:commit /path:{0} /closeonend:0", path));
            }
            return -1;
        }
        /// <summary>
        /// 锁定文件
        /// </summary>
        public static int GetLockSvnDirectory(string path)
        {
            return ExecuteProcess(GetSvnProcPath(), string.Format("/command:lock /path:{0} /closeonend:0", path));
        }
        /// <summary>
        /// 解除锁定
        /// </summary>
        public static int ReleaseLockSvnDirectory(string path)
        {
            return ExecuteProcess(GetSvnProcPath(), string.Format("/command:unlock /path:{0} /closeonend:0", path));
        }
        /// <summary>
        /// 执行自定义命令
        /// </summary>
        public static int ProcessSvnCommand(string command)
        {
            return ExecuteProcess(GetSvnProcPath(), command);
        }
        /// <summary>
        /// 显示日志
        /// </summary>
        public static int ShowLogSvnFile(params string[] paths)
        {
            if (paths != null && paths.Length > 0)
            {
                var path = GetSVNOperatePath(paths);
                return ExecuteProcess(GetSvnProcPath(), string.Format("/command:log /path:{0} /closeonend:0", path));
            }
            return -1;
        }
        private static string GetSVNOperatePath(params string[] paths)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var pa in paths)
            {
                stringBuilder.Append(pa);
                stringBuilder.Append('*');
            }
            return stringBuilder.ToString().TrimEnd('*');
        }
        private static System.Text.RegularExpressions.Regex m_regexUri = new System.Text.RegularExpressions.Regex(@".*(?=/$)");
        public static string GetUri(string path)
        {
            try
            {
                using (SvnClient client = new SvnClient())
                {
                    Uri uri = client.GetUriFromWorkingCopy(path);
                    return uri.ToString();
                }
            }
            catch
            {

            }
            return "";
        }
        #region 读取SVN路径
        private static List<string> drives = new List<string>() { "c:", "d:", "e:", "f:" };
        private static string _svnPath = "";
        private static string svnPath = @"\Program Files\TortoiseSVN\bin\";
        private static string svnProc = @"TortoiseProc.exe";
        private static string GetSvnProcPath()
        {
            if (_svnPath != string.Empty)
            {
                return _svnPath;
            }
            var xElement = Logic.Instance.GetXmlElement("SvnPath");
            if (xElement != null)
            {
                _svnPath = xElement.Value;
                return _svnPath;
            }
            foreach (string item in drives)
            {
                string path = string.Concat(item, svnPath, svnProc);
                if (File.Exists(path))
                {
                    _svnPath = path;
                    Logic.Instance.AddXmlElement("SvnPath", _svnPath);
                    break;
                }
            }
            if (_svnPath == string.Empty)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Title = "请选择SVN可执行程序";
                dialog.Filter = string.Format("可执行程序(*.exe)|*.exe");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _svnPath = dialog.FileName;
                    Logic.Instance.AddXmlElement("SvnPath", _svnPath);
                }
            }
            return _svnPath;
        }
        #endregion
        private static int ExecuteProcess(string filePath, string command, int seconds = 0)
        {
            return EditorUtil.ExecuteProcess(filePath, command, "", seconds);
        }
    }
}
