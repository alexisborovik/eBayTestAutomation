﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EbayTestAutomation.Tools
{
    public static class Tool
    {
        public static string GenerateNumbers()
        {
            return DateTime.Now.ToString("MMddyyHmmss");
        }

        public static Dictionary<string,string> LoadSettings(string path = "")
        {
            if(path.Equals(""))
            path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestSettings.xml");
            Dictionary <string, string> sett = new Dictionary<string, string>();
            XmlDocument document = new XmlDocument();
            document.Load(path);
            foreach (XmlNode node in document.DocumentElement.ChildNodes)
            {
                string value = node.InnerText;
                string key = node.Name;
                if (!string.IsNullOrEmpty(value))
                {
                    sett.Add(key.ToUpper(), value);
                }
            }
            return sett;
        }
    }
}
