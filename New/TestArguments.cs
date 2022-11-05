using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ToolsQA
{
    public class TestArguments
    {
        public string browser { get; set; }
        public string url { get; set; }
        //public XmlDocument Doc { get; }

        public TestArguments()

        {
            string configFilePath = @"/Users/amrudincatic/VS_Projects/TestConfiguration/config.xml";

            if (!File.Exists(configFilePath))
                throw new FileNotFoundException("Specified test configuration file does not exist.");

            XmlDocument doc = new XmlDocument();
            doc.Load(configFilePath);

            string driverValue = doc.DocumentElement.SelectSingleNode("//testconfiguration//browser").InnerText;
            string urlValue = doc.DocumentElement.SelectSingleNode("//testconfiguration//url").InnerText;

            if (string.IsNullOrWhiteSpace(driverValue) || string.IsNullOrWhiteSpace(urlValue))
            {
                throw new ArgumentNullException("Test parameters from configuration XML file are not valid. Please check configuration xml file");
            }
            else
            {
                this.browser = driverValue;
                this.url = urlValue;

            }


        }
    }
}
