using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace MSTestDenmarkRadio
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\WebDrivers\\chromedriver_win32 (2)";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }
        [TestMethod]
        public void TestMethod()
        {

            string url = "http://127.0.0.1:5501/index.html";
            _driver.Navigate().GoToUrl(url);

            Assert.AreEqual("Denmark Radio", _driver.Title);

            IWebElement inputElement = _driver.FindElement(By.Id("deleteInput"));
            inputElement.SendKeys("10");

            IWebElement button1 = _driver.FindElement(By.Id("deleteButton"));
            button1.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            IWebElement deleteMusic = wait.Until(d => d.FindElement(By.Id("outputDelete")));

            Assert.AreEqual("200", deleteMusic.Text);



        }
    }
}