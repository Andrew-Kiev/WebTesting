using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_1
{
    class Demo
    {
        IWebDriver driver;


        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C:\\Driver");
        }

        [Test]
        public void test()
        {
            driver.Url = "http://www.google.co.in";
        }


        //[TearDown]
        //public void closeBrowser()
        //{
        //    driver.Close();

        //    ABase aBaseObject;
        //    BChild bChildObject = new BChild();
        //    string i = "dfsgrs";
        //    aBaseObject.A();

            public void A()
        {
            var varajan = new Human("Vara", "33");
            Assert.LessOrEqual(varajan.Age, 15);

            var age = varajan.Age;

            varajan.Age = 45;
        }

        //    var varajan2 = new Human(age: "45", "34", weight: "195");
        //    Assert.Greater(100, varajan2.WeightIndex());

        //    var rudik = new Customer("asdfsa123123123", "Siroga");
        //    var andrulik = new Uzer("50");
        //    andrulik.email = "sesfgsdf";
        //    andrulik.Age = 33;
        //var v = new Vehicles();
    }

        abstract class Vehicles
        {
            public string Type; // private (default) - in current class only; protected - for current class and all child
            public string EngineType;
            public int EnginePower;
            public int Year;
            public string Colour;
            public string Manufacturer;
            public int Price;
            abstract public int Tax { get; }
        

            public Vehicles(string type, string engineType, int enginePower, int year, string colour, string manufacturer, int price = 1000)
            {
                Type = type;
                EngineType = engineType;
                EnginePower = enginePower;
                Year = year;
                Colour = colour;
                Manufacturer = manufacturer;
            Price = price;

            //in each test
            var page = new MainPage();

            page.LoginField.SendKeys("Vasia"); // 5 sec
            page.LoginField.SendKeys("Vasia");  // 0 sec
            page.LoginField.SendKeys("Vasia");  // 0 sec
            page.LoginField.SendKeys("Vasia"); //  0 sec
            page.PasswordField.SendKeys("asdf"); // 5 sec
            page.PasswordField.SendKeys("asdf"); // 5 sec
            page.PasswordField.SendKeys("asdf"); // 5 sec
            page.PasswordField.SendKeys("asdf"); // 5 sec
            page.PasswordField.SendKeys("asdf"); // 5 sec
            page.LoginButton.Click(); // 5 sec
            page.LoginButton.Click(); // 0 sec
            page.LoginButton.Click(); // 0 sec

            page.Login("Vasia", "asdf");

            //rows below are realy identical
            string a = null;
            string b = "b";

            string c = a ?? b;
            string d = a != null ? a : b;
            string e;
            if (a != null) e = a; else e = b;
        }
    }

    public class MainPage
    {
        IWebDriver driver;

        public void Login(string name, string pass)
        {
            LoginField.SendKeys(name);
            PasswordField.SendKeys(pass);
            LoginButton.Click();
        }

        public void PrepareReport(int yearfrom, int yearto)
        {
            //set year from
            //set year to
            // click GenerateReport button
            // wait for ready

          
        }

        private IWebElement loginField;
        public IWebElement LoginField
        {
            get
            {
                if (loginField == null)
                {
                    driver.SwitchTo().Frame("google_ads_iframe_/55937117/olx.ua/homepage_2");
                    driver.SwitchTo().ParentFrame();
                    loginField = driver.FindElement(By.Id("asdf"));
                }

                return loginField;
            }
                // "get" = "=>" initialize on requesting this control
        }

        // if used 1-2 times in test
        public IWebElement PasswordField => driver.FindElement(By.Id("asdf"));

        // if 5 times or more
        private IWebElement loginButton;
        public IWebElement LoginButton => loginButton = loginButton ?? driver.FindElement(By.Id("asdf"));
    }

    class ElectricCars : Vehicles
    {
        public ElectricCars(string type, string engineType, int enginePower, int year, string colour, string manufacturer) : base(type, engineType, enginePower, year, colour, manufacturer)
        {
        }

        public override int Tax
        {
            get { return (int)(Price * 0.01); }
        }
    }
    class DiselCars : Vehicles
    {
        public int EngineVolume;

        public DiselCars(string type, string engineType, int enginePower, int year, string colour, string manufacturer, int engineVolume) : base(type, engineType, enginePower, year, colour, manufacturer)
        {
            EngineVolume = engineVolume;
        }

        public override int Tax
        {
            get
            {
                if (Year > 2005 && EngineVolume < 2) //&& - and, || - or, ! not
                {
                    return (int)(Price * 0.1);
                }
                else
                {
                    return 100;
                }
            }
        }
    }

    class Human
    {
        public string Name;
        string _age;
        string Weight;
        string Height;

        public Human(string name, string age = "30", string weight = "80", string height = "170")
        {
            Name = name;
            _age = age;
            Weight = weight;
            Height = height;
        }

        public int Age
        {
            get { return int.Parse(_age); }
            set { _age = value.ToString(); }
        }

        public int WeightIndex()
        {
            int result = int.Parse(Weight) / int.Parse(Height);
            return result;
        }
    }

    //class Uzer : Human
    //{
    //    public string email;

    //    public Uzer(string years) : base(years)
    //    {

    //    }
    //}

    //class Customer : Human
    //{
    //    public string BankAccount;


    //    public Customer(string account, string name) : base(name)
    //    {
    //        BankAccount = account;
    //    }
    //}

    //class Accountant : Customer
    //{
    //    private string Check;

    //    public Accountant(string check, string account, string name) : base(account, name)
    //    {
    //        Check = check;
    //    }
    //}

    //class Fonar { }

    //class ABase
    //{
    //    public void A() { }
    //    public void B() { }
    //    protected void C() { D(); }
    //    private void D() { }

    //    private int i;
    //    string b;
    //    Fonar lihtar;
    //}

    //class BChild : ABase
    //{
    //    public void E() { }
    //    protected void G() { }
    //    private void F()
    //    {
    //        this.C();
    //        C();
    //        D();

    //    }
    //}

}