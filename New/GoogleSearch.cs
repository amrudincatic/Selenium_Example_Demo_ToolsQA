using System.Xml.Linq;
using ToolsQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ToolsQA
{
    public class GoogleSearch
    {
        public static string SearchParameter(string word)
        {
            string message = "",
                   messageGoogle = "";
         

            try
            {

                var GoogleSearch = Driver.Instance.FindElement(By.Name("q"));
                GoogleSearch.Click();
                GoogleSearch.SendKeys(word);
                GoogleSearch.Submit();

                Functions.TakeScreenShot();


            }

            catch (Exception e)
            {
                message += "ERROR!" + e.Message;
            }
            message += messageGoogle;

            return message;


        }

        public static string DemoQA()
        {
            string message = "",
                  messageDemoQA = "";

            try
            {
                var ToolsQA = Driver.Instance.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div > div > div > div > div > div.yuRUbf > a > h3"));
                ToolsQA.Click();


                Functions.TakeScreenShot();

            }

            catch (Exception e)
            {
                message += "ERROR!" + e.Message;
            }
            message += messageDemoQA;

            return message;


        }

        public static string Elements()
        {
            string message = "",
                  messageElements = "";

            try
            {
                var Elements = Driver.Instance.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1) > div > div.avatar.mx-auto.white > svg"));
                Elements.Click();

                var TextBox = Driver.Instance.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[1]/div/div/div[1]/div/ul/li[1]/span"));
                TextBox.Click();

                var FullName = Driver.Instance.FindElement(By.CssSelector("#userName"));
                FullName.Click();
                FullName.SendKeys("Name Name");

                var Email = Driver.Instance.FindElement(By.CssSelector("#userEmail"));
                Email.Click();
                Email.SendKeys("name@mail.com");

                var CurrentAdress = Driver.Instance.FindElement(By.CssSelector("#currentAddress"));
                CurrentAdress.Click();
                CurrentAdress.SendKeys("Adress 123");

                var PermanentAdress = Driver.Instance.FindElement(By.CssSelector("#permanentAddress"));
                PermanentAdress.Click();
                PermanentAdress.SendKeys("Adress 321");

                var SubmitButton = Driver.Instance.FindElement(By.ClassName("btn btn-primary"));
                SubmitButton.Click();

                Functions.TakeScreenShot();

            }



            catch (Exception e)
            {
                message += "ERROR!" + e.Message;
            }
             message += messageElements;

             return message;


        }

    
    }
}




