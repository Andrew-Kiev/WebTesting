using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
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

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();

            ABase aBaseObject;
            BChild bChildObject = new BChild();
            string i = "dfsgrs";
            //aBaseObject.A();


            var varajan = new Human("Vara", "33");
            //var varajan2 = new Human(age: "45", "34", weight: "195");
            //Assert.Greater(100, varajan2.WeightIndex());

            var rudik = new Customer("asdfsa123123123", "Siroga");
            var andrulik = new Uzer("50");
            andrulik.email = "sesfgsdf";
            andrulik.Age = 33;

        }

        class Human
        {
            public string Name;
            public int Age;
            public readonly string Weight;
            public readonly string Height;

            public Human(string name, string age = "30", string weight = "80", string height = "170")
            {
                Name = name;
                //Age = age;
                Weight = weight;
                Height = height;
            }

            public int WeightIndex()
            {
                int result = int.Parse(Weight) / int.Parse(Height);
                return result;
            }
        }

        class Uzer : Human
        {
            public string email;

            public Uzer(string years) : base(years)
            {

            }
        }

        class Customer : Human
        {
            public string BankAccount;


            public Customer(string account, string name) : base(name)
            {
                BankAccount = account;
            }
        }

        class Accountant : Customer
        {
            private string Check;

            public Accountant(string check, string account, string name) : base(account, name)
            {
                Check = check;
            }
        }

        class Fonar { }

        class ABase
        {
            public void A() { }
            public void B() { }
            protected void C() { D(); }
            private void D() { }

            private int i;
            string b;
            Fonar lihtar;
        }

        class BChild : ABase
        {
            public void E() { }
            protected void G() { }
            private void F()
            {
                this.C();
                C();
                // D();

            }
        }
    }
}