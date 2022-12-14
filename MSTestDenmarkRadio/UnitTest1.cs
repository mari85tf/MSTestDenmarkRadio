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

            string url = "https://denmarkradioui.azurewebsites.net/";
            _driver.Navigate().GoToUrl(url);

            Assert.AreEqual("Denmark Radio", _driver.Title);

            IWebElement inputElement = _driver.FindElement(By.Id("deleteInput"));
            inputElement.SendKeys("5");

            IWebElement button1 = _driver.FindElement(By.Id("deleteButton"));
            button1.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            IWebElement deleteMusic = wait.Until(d => d.FindElement(By.Id("outputDelete")));

            Assert.AreEqual("200 OK", deleteMusic.Text);

            IWebElement inputTitle = _driver.FindElement(By.Id("title"));
            inputTitle.SendKeys("test");

            IWebElement inputArtist = _driver.FindElement(By.Id("artist"));
            inputArtist.SendKeys("tester");

            IWebElement inputDuration = _driver.FindElement(By.Id("duration"));
            inputDuration.SendKeys("1");

            IWebElement inputPublicationYear = _driver.FindElement(By.Id("publicationYear"));
            inputPublicationYear.SendKeys("2000");

            IWebElement button2 = _driver.FindElement(By.Id("addMusic"));
            button2.Click();

            WebDriverWait waitMusic = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            IWebElement addMusic = waitMusic.Until(d => d.FindElement(By.Id("addMessage")));

            Assert.AreEqual("response 201 Created", addMusic.Text);
        }
    }
}