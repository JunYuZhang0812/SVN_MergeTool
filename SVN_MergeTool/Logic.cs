using System.Collections.Generic;
using System.Xml.Linq;

namespace SVN_MergeTool
{
    class Logic
    {
        #region 单例
        private static Logic _instance;
        public static Logic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Logic();
                return _instance;
            }
        }
        #endregion
        #region 配置文件
        private XmlOp _cfgFile;
        /// <summary>
        /// 配置文件
        /// </summary>
        public XmlOp XmlFile
        {
            get
            {
                if (_cfgFile == null)
                    _cfgFile = new XmlOp("SvnMergeToolConfig.xml");
                return _cfgFile;
            }
        }
        private XmlOp _dirTypeXmlFile;
        public XmlOp DirTypeXmlFile
        {
            get
            {
                if (_dirTypeXmlFile == null)
                    _dirTypeXmlFile = new XmlOp("SvnMergeToolConfig_后缀类型.xml");
                return _dirTypeXmlFile;
            }
        }
        public int DirectoryTypeIndex { get; set; }
        //读取文件数据
        public List<XElement> GetXmlAllElement( XElement xElement = null)
        {
            return XmlFile.GetXmlAllElement(xElement);
        }
        public XElement GetXmlElement(string key, XElement xElement = null)
        {
            return XmlFile.GetXmlElement(key, xElement);
        }
        public string GetXmlAttribut(string key, XElement parent = null)
        {
            return XmlFile.GetXmlAttribut(key, parent);
        }
        public void SetOrAddElement(string name, string value, XElement parent = null)
        {
            XmlFile.SetOrAddXmlElement(name, value, parent);
        }
        public void AddXmlElement(string name , string value , XElement parent = null )
        {
            XElement xElement = new XElement(name);
            xElement.Value = value;
            XmlFile.AddXmlElement(xElement, parent);
        }
        public string GetXmlElementValue(string name, XElement xElement = null)
        {
            return XmlFile.GetXmlElementValue(name, xElement);
        }
        #endregion
        public int CurrSrcIndex { get; set; }
        public int CurrTarIndex { get; set; }
        public bool Working { get; set; }
    }
}
