using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SVN_MergeTool
{
    //C#调用可执行文件  
    public class EditorUtil
    {
        public static int ExecuteProcess(string filePath, string command, string workPath = "", int seconds = 0)
        {
            int exitCode = 0;
            if (string.IsNullOrEmpty(filePath))
            {
                return exitCode;
            }
            Process process = new Process();//创建进程对象  
            process.StartInfo.WorkingDirectory = workPath;
            process.StartInfo.FileName = filePath;
            process.StartInfo.Arguments = command;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.RedirectStandardOutput = false;//不重定向输出  
            try
            {
                process.Start();
                /*if (process.Start())
                {
                    if (seconds == 0)
                    {
                        process.WaitForExit(); //无限等待进程结束  
                    }
                    else
                    {
                        process.WaitForExit(seconds); //等待毫秒  
                    }
                }*/
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                //exitCode = process.ExitCode;
                //process.Close();
            }
            return exitCode;
        }
    }
}
