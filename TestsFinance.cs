using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Globalization;
using ConsoleApplication2.PageObject_iFinance;

namespace TestApplication
{
    class FinanceWebPage
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {

            driver = new ChromeDriver("C:\\Drivers\\Chrome");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        [Test]
        public void ExchangeRates()
        {
            var finance = new MainPage();

            finance.goToPage();
            Assert.Greater(finance.sellUSDValue, finance.buyUSDValue);
            Assert.Greater(finance.sellEURValue, finance.buyEURValue);
            Assert.Greater(finance.sellRUBValue, finance.buyRUBValue);
           
            //Assert.Greater(sellUSD,buyUSD);
            //Assert.Greater(sellEUR,buyEUR);
            //Assert.Greater(sellRUB,buyRUB);
        }

        [Test]
        public void Convertion()
        {
            var finance = new MainPage();

            finance.goToPage();
            finance.ExchangeAmount("1000", "USD", "ПриватБанк");
            Assert.AreEqual(finance.ExchangeRate("ПриватБанк") * 1000, finance.ConvertedSum);

            //driver.FindElement(By.Id("currency_amount")).SendKeys("1000");
            //var currency = driver.FindElement(By.Name("converter_currency"));
            //var selectElement1 = new SelectElement(currency);
            //selectElement1.SelectByText("USD"); //Выбираем доллары для конвертации                        
            //var convertionBank = driver.FindElement(By.Id("converter_bank"));
            //var selectElement2 = new SelectElement(convertionBank);
            //selectElement2.SelectByText("ПриватБанк"); //Выбираем по какому курсу считать                       

            //string convertedSum = driver.FindElement(By.XPath("//p[@id='UAH']//input[@id='currency_exchange']")).GetAttribute("value");
            //decimal privatUSD = Convert.ToDecimal(driver.FindElement(By.XPath("(//a [text()='ПриватБанк']/../../td[@class='buy_rate'])[1]")).Text); //Берем курс ПриватБанка из таблицы Курс валют банков в Украине            

            //decimal calculatedSum = privatUSD * 1000;

            //decimal convertSum = Decimal.Parse(convertedSum.Replace(" ", ""));


        }
        [Test]
        public void UsefullLinksNames()
        {
            //Проверим есть ли основные ссылки (их название) в блоке Полезные ссылки
            string banks = driver.FindElement(By.XPath("(//div[@class='widget widget-links']//a[@class='icon-s i_catalog'])[1]")).Text;
            string crediting = driver.FindElement(By.XPath("(//div[@class='widget widget-links']//a[@class='icon-s i_catalog'])[2]")).Text;
            string forex = driver.FindElement(By.XPath("(//div[@class='widget widget-links']//a[@class='icon-s i_catalog'])[3]")).Text;
            string insurance = driver.FindElement(By.XPath("(//div[@class='widget widget-links']//a[@class='icon-s i_catalog'])[4]")).Text;
            string financeServices = driver.FindElement(By.XPath("(//div[@class='widget widget-links']//a[@class='icon-s i_catalog'])[5]")).Text;

            Assert.AreEqual(banks, "Банки");
            Assert.AreEqual(crediting, "Кредитование");
            Assert.AreEqual(forex, "Forex");
            Assert.AreEqual(insurance, "Страхование");
            Assert.AreEqual(financeServices, "Финансовые услуги");

            //Проверим работают ли эти ссылки

            IWebElement banksLink = driver.FindElement(By.XPath("(//div[@class='widget widget-links']//a[@class='icon-s i_catalog'])[1]"));
            banksLink.Click();
            string bankslink = driver.FindElement(By.XPath("//p[@class='breadCrumbs']/b")).Text;
            driver.Navigate().Back();
            IWebElement creditingLink = driver.FindElement(By.XPath("(//div[@class='widget widget-links']//a[@class='icon-s i_catalog'])[2]"));
            creditingLink.Click();
            string creditinglink = driver.FindElement(By.XPath("//p[@class='breadCrumbs']/b")).Text;
            driver.Navigate().Back();
            IWebElement forexLink = driver.FindElement(By.XPath("(//div[@class='widget widget-links']//a[@class='icon-s i_catalog'])[3]"));
            forexLink.Click();
            string forexlink = driver.FindElement(By.XPath("//p[@class='breadCrumbs']/b")).Text;
            driver.Navigate().Back();
            IWebElement insuranceLink = driver.FindElement(By.XPath("(//div[@class='widget widget-links']//a[@class='icon-s i_catalog'])[4]"));
            insuranceLink.Click();
            string insurancelink = driver.FindElement(By.XPath("//p[@class='breadCrumbs']/b")).Text;
            driver.Navigate().Back();
            IWebElement financeServicesLink = driver.FindElement(By.XPath("(//div[@class='widget widget-links']//a[@class='icon-s i_catalog'])[5]"));
            financeServicesLink.Click();
            string financeServiceslink = driver.FindElement(By.XPath("//p[@class='breadCrumbs']/b")).Text;
            driver.Navigate().Back();

            Assert.AreEqual(bankslink, "Банки");
            Assert.AreEqual(creditinglink, "Кредитование");
            Assert.AreEqual(forexlink, "Рынок валют Forex");
            Assert.AreEqual(insurancelink, "Страхование");
            Assert.AreEqual(financeServiceslink, "Финансовые услуги");
        }
    }

}