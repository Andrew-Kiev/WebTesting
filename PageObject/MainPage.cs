using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
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

        public decimal buyUSDValue => Decimal.Parse(buyUSD.Text);
        public decimal sellUSDValue => Decimal.Parse(sellUSD.Text);
        public decimal buyEURValue => Decimal.Parse(buyEUR.Text);
        public decimal sellEURValue => Decimal.Parse(sellEUR.Text);
        public decimal buyRUBValue => Decimal.Parse(buyRUB.Text);
        public decimal sellRUBValue => Decimal.Parse(sellRUB.Text);

        [FindsBy(How = How.XPath, Using = "(//tr[th/text()='USD']//span[contains(@class,'value')])[1]/span[1]")]
        private IWebElement buyUSD;

        [FindsBy(How = How.XPath, Using = "(//tr[th/text()='USD']//span[contains(@class,'value')])[2]/span[1]")]
        private IWebElement sellUSD;

        [FindsBy(How = How.XPath, Using = "(//tr[th/text()='EUR']//span[contains(@class,'value')])[1]/span[1]")]
        private IWebElement buyEUR;

        [FindsBy(How = How.XPath, Using = "(//tr[th/text()='EUR']//span[contains(@class,'value')])[2]/span[1]")]
        private IWebElement sellEUR;

        [FindsBy(How = How.XPath, Using = "(//tr[th/text()='RUB']//span[contains(@class,'value')])[1]/span[1]")]
        private IWebElement buyRUB;

        [FindsBy(How = How.XPath, Using = "(//tr[th/text()='RUB']//span[contains(@class,'value')])[2]/span[1]")]
        private IWebElement sellRUB;

        public void ExchangeAmount(string amount, string currency, string bank = "NBU")
        {
            driver.FindElement(By.Id("currency_amount")).SendKeys(amount);//if will be used only here/this method
            //buyEUR.SendKeys(amount); //If this control is used somwhere else, declare and use it here
            var selectCurrency = new SelectElement(driver.FindElement(By.Name("converter_currency")));
            selectCurrency.SelectByText(currency);//use only this if we use selectCurrency somwhere else

            var convertionBank = driver.FindElement(By.Id("converter_bank"));
            var selectBank = new SelectElement(convertionBank);// convert webelement to dropdown
            selectBank.SelectByText(bank);
        }
        
        //public decimal ConvertedSum3 => Decimal.Parse(driver.FindElement(By.XPath("//p[@id='UAH']//input[@id='currency_exchange']")).GetAttribute("value").Replace(" ", ""));// the same as below

        public decimal ConvertedSum
        {
            get
            {
                var control = driver.FindElement(By.XPath("//p[@id='UAH']//input[@id='currency_exchange']"));
                var currencyExchange = control.GetAttribute("value").Replace(" ", "");
                //currencyExchange = currencyExchange.Replace(" ", "");
                return Decimal.Parse(currencyExchange);                
            }
        }
        //decimal privatUSD = Convert.ToDecimal(driver.FindElement(By.XPath("(//a [text()='ПриватБанк']/../../td[@class='buy_rate'])[1]")).Text);

        public decimal ExchangeRate(string bank = "NBU")
        {
            var text = driver.FindElement(By.XPath($"(//a [text()='{bank}']/../../td[@class='buy_rate'])[1]")).Text;
            //"(//a [text()='" + bank + "']/../../td[@class='buy_rate'])[1]"// the same as above
            return Decimal.Parse(text);
        }

        //public decimal MarjaUSD()
        //{
        //    decimal marjaUSD;
        //    marjaUSD = Decimal.Parse(sellUSD.Text) - Decimal.Parse(buyUSD.Text);
        //    return marjaUSD;
        //}
        public decimal MarjaEUR()
        {
            decimal marjaEUR;
            marjaEUR = Decimal.Parse(sellEUR.Text) - Decimal.Parse(buyEUR.Text);
            return marjaEUR;
        }
        public decimal MarjaRUB()
        {
            decimal marjaRUB;
            marjaRUB = Decimal.Parse(sellRUB.Text) - Decimal.Parse(buyRUB.Text);
            return marjaRUB;
        }
        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://finance.i.ua/");
        }
    }


}
