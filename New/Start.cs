using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using ToolsQA;
using Assert = NUnit.Framework.Assert;

namespace ToolsQA
{
    [TestClass]
    public class Start

    {
        [TestInitialize]
        public void Init()
        {

            TestArguments parameters = new TestArguments();

            int a = int.Parse(parameters.browser);

            Driver.Initialize(a);
        }


        [TestMethod]
        public void TestMethod()
        {
            string subject = "",
                   body = "";

            TestArguments parameters = new TestArguments();
            string URL = parameters.url;

            OpenUrl.GoTo(URL);

            string messageGoogle = GoogleSearch.SearchParameter("ToolsQA demo");
            string messageDemoQA = GoogleSearch.DemoQA();
            string messageElements = GoogleSearch.Elements();






            if ((!messageGoogle.Contains("ERROR")) && (!messageDemoQA.Contains("ERROR")) && (!messageElements.Contains("ERROR")))

            {
                subject = "Passed!!! " + subject;
                body = "Test passed " + "\n" + messageGoogle + messageDemoQA + messageElements;
            }
            else
            {
                subject = "Failed!!! " + subject;
                body = messageGoogle + messageDemoQA + messageElements;
            }

            Functions.TakeScreenShot();

            //Functions.SendEmailAttachment(subject, body);

            //Assert.IsTrue(subject.Contains("Failed"));
            //Assert.IsFalse(subject.Contains("Passed"));


        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}