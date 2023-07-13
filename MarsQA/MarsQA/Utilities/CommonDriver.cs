using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MarsQA.Utilities
{
    [Binding]
    public sealed class CommonDriver
    {
        //Initialize the browser
        public static IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            //Defining the browser
            driver = new ChromeDriver();

            //Maximise the window
            driver.Manage().Window.Maximize();

            //Navigating to Mars portal
            driver.Navigate().GoToUrl("http://localhost:5000/");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //Closing the browser
            driver.Close();
        }
    }
}