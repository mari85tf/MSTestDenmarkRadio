using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            inputElement.SendKeys("2");

            IWebElement button1 = _driver.FindElement(By.Id("deleteButton"));
            button1.Click();

            //IWebElement button2 = _driver.FindElement(By.Id("buttonShow"));
            //button2.Click();

            IWebElement outputElement1 = _driver.FindElement(By.Id("outputDelete"));
            string text1 = outputElement1.Text;

            Assert.AreEqual("", text1);

            //IWebElement button3 = _driver.FindElement(By.Id("buttonClear"));
            //button3.Click();

            //IWebElement outputElement2 = _driver.FindElement(By.Id("outputField"));
            //string text2 = outputElement2.Text;

            //Assert.AreEqual("", text2);

        }
    }
}