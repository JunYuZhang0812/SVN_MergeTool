using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVN_MergeTool
{
    class CompareUtil
    {
        static string comparePath;
        public static void CompareFolder( string leftPath , string rightPath )
        {
            EditorUtil.ExecuteProcess(GetCompareExePath(), leftPath +" " + rightPath);
        }
        private static string GetCompareExePath()
        {
            if (!string.IsNullOrEmpty(comparePath))
                return comparePath;
            var xElement = Logic.Instance.GetXmlElement("ComparePath");
            if (xElement != null)
            {
                comparePath = xElement.Value;
                return comparePath;
            }
            if (string.IsNullOrEmpty(comparePath) )
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Title = "请选择Beyond Compare可执行程序";
                dialog.Filter = string.Format("可执行程序(*.exe)|*.exe");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    comparePath = dialog.FileName;
                    Logic.Instance.AddXmlElement("ComparePath", comparePath);
                }
            }
            return comparePath;
        }
    }
}
