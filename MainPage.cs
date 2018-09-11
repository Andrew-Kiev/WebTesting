using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.PageObject_iFinance
{
    public class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public MainPage()
        {
        }

        [FindsBy(How = How.XPath, Using = "(//tr[th/text()='USD']//span[contains(@class,'value')])[1]/span[1]")]
        private decimal buyUSD;
        [FindsBy(How = How.XPath, Using = "(//tr[th/text()='USD']//span[contains(@class,'value')])[1]/span[1]")]
        private decimal sellUSD;
        [FindsBy(How = How.XPath, Using = "(//tr[th/text()='USD']//span[contains(@class,'value')])[1]/span[1]")]
        private decimal buyEUR;
        [FindsBy(How = How.XPath, Using = "(//tr[th/text()='USD']//span[contains(@class,'value')])[1]/span[1]")]
        private decimal sellEUR;
        [FindsBy(How = How.XPath, Using = "(//tr[th/text()='USD']//span[contains(@class,'value')])[1]/span[1]")]
        private decimal buyRUB;
        [FindsBy(How = How.XPath, Using = "(//tr[th/text()='USD']//span[contains(@class,'value')])[1]/span[1]")]
        private decimal sellRUB;

        public static int MarjaUSD(decimal buyUSD, decimal sellUSD)
        {
            decimal marjaUSD;
            marjaUSD = sellUSD - buyUSD;
            return marjaUSD;
        }
        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://finance.i.ua/");
        }
    }


}
