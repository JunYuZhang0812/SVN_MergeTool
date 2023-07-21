using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SVN_MergeTool
{
    class XmlOp
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        private string m_filePath = string.Empty;
        private XElement xml;
        public XmlOp( string fileName )
        {
            InitFile(fileName);
            GetRootXml();
        }
        private void InitFile(string fileName)
        {
            m_filePath = Application.StartupPath + "\\"+ fileName;
            if( !File.Exists(m_filePath) )
            {
                CreateFile(m_filePath);
                InitXmlFile(fileName);
            }
        }
        private void InitXmlFile(string fileName)
        {
            StreamWriter streamWriter = new StreamWriter(m_filePath);
            streamWriter.WriteLine("<xml>");
            streamWriter.WriteLine("</xml>");
            streamWriter.Flush();
            streamWriter.Close();
            GetRootXml();
            if(fileName.Equals("SvnMergeToolConfig.xml"))
            {
                XElement nameEle1 = new XElement("name");
                nameEle1.Value = "工程名字_1";
                XAttribute pathEle1 = new XAttribute("path", "文件目录_1");
                AddXmlAttribute(pathEle1, nameEle1);
                XAttribute urlEle1 = new XAttribute("url", "url_1");
                AddXmlAttribute(urlEle1, nameEle1);
                AddXmlElement(nameEle1);


                XElement nameEle2 = new XElement("name");
                nameEle2.Value = "工程名字_2";
                XAttribute pathEle2 = new XAttribute("path", "文件目录_2");
                AddXmlAttribute(pathEle2, nameEle2);
                XAttribute urlEle2 = new XAttribute("url", "url_2");
                AddXmlAttribute(urlEle2, nameEle2);

                AddXmlElement(nameEle2);
            }
            else if(fileName.Equals("SvnMergeToolConfig_后缀类型.xml"))
            {
                XElement nameEle1 = new XElement("name");
                nameEle1.Value = "None";
                XAttribute pathEle1 = new XAttribute("addPath", "");
                AddXmlAttribute(pathEle1, nameEle1);
                AddXmlElement(nameEle1);

                XElement nameEle2 = new XElement("name");
                nameEle2.Value = "Code";
                XAttribute pathEle2 = new XAttribute("addPath", "Assets/Code");
                AddXmlAttribute(pathEle2, nameEle2);
                AddXmlElement(nameEle2);

                XElement nameEle3 = new XElement("name");
                nameEle3.Value = "Code_Lua";
                XAttribute pathEle3 = new XAttribute("addPath", "Assets/Code_Lua");
                AddXmlAttribute(pathEle3, nameEle3);
                AddXmlElement(nameEle3);

                XElement nameEle4 = new XElement("name");
                nameEle4.Value = "Resources";
                XAttribute pathEle4 = new XAttribute("addPath", "Assets/Resources");
                AddXmlAttribute(pathEle4, nameEle4);
                AddXmlElement(nameEle4);
            }
        }
        /// <summary>
        /// 获取xml根节点
        /// </summary>
        /// <returns></returns>
        public XElement GetRootXml()
        {
            if (xml == null)
                xml = XElement.Load(m_filePath);
            return xml;
        }
        /// <summary>
        /// 读取所有要素
        /// </summary>
        public List<XElement> GetXmlAllElement( XElement xElement = null)
        {
            List<XElement> xmlList = new List<XElement>();
            if (xElement == null)
                xElement = xml;
            foreach (var item in xElement.Elements())
            {
                if(item.Name == "name")
                    xmlList.Add(item);
            }
            return xmlList;
        }
        /// <summary>
        /// 获取要素
        /// </summary>
        public XElement GetXmlElement( string name, XElement xElement = null)
        {
            if (xElement == null)
                xElement = xml;
            return xElement.Element(name);
        }
        public string GetXmlElementValue( string name , XElement xElement = null)
        {
            XElement element = GetXmlElement(name, xElement);
            if (element == null) return "";
            return element.Value;
        }
        /// <summary>
        /// 获取属性
        /// </summary>
        public string GetXmlAttribut(string xName, XElement xElement = null)
        {
            if (xElement == null)
                xElement = xml;
            var attr = xElement.Attribute(xName);
            if (attr != null)
                return attr.Value;
            return "";
        }
        /// <summary>
        /// 获取属性值
        /// </summary>
        public string GetXmlAttribut(XElement xElement, string name)
        {
            return xElement.Attribute(name).Value;
        }
        /// <summary>
        /// 添加要素
        /// </summary>
        public void AddXmlElement( XElement xElement , XElement parent = null)
        {
            if (parent == null)
                parent = xml;
            parent.Add(xElement);
            Save();
        }
        public void SetOrAddXmlElement(string name,string value,XElement parent = null)
        {
            if (parent == null)
                parent = xml;
            var xe = parent.Element(name);
            if (xe == null)
                parent.Add(new XElement(name, value));
            else
                xe.Value = value;
            Save();
        }
        /// <summary>
        /// 添加属性
        /// </summary>
        public void AddXmlAttribute( XAttribute xAttribute , XElement parent = null)
        {
            if (parent == null)
                parent = xml;
            parent.Add(xAttribute);
            Save();
        }
        private void Save()
        {
            xml.Save(m_filePath);
        }
        /// <summary>
        /// 设置文件路径
        /// </summary>
        public void SetFilePath(string strFilePath)
        {
            m_filePath = strFilePath;
        }
        /// <summary>
        /// 读取文件路径
        /// </summary>
        public string GetFilePtah()
        {
            return m_filePath;
        }
        /// <summary>
        /// 创建文件
        /// </summary>
        public void CreateFile(string strFilePath)
        {
            SetFilePath(strFilePath);
            CreateFile();
        }
        /// <summary>
        /// 创建文件
        /// </summary>
        public void CreateFile()
        {
            if (m_filePath.Length == 0) return;
            if (File.Exists(m_filePath)) return;
            FileStream fileStream = File.Create(m_filePath);
            if (fileStream != null)
                fileStream.Close();
        }
    }
}
