using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumLinkedinSayfamiZiyaret
{
    class Program
    {
        static void Main(string[] args)
        {//Nuget Paketini kurarken Tarayıcı(chrome) sürümüne dikkat et sonra build et

            IWebDriver driver = new ChromeDriver();//Hangi tarayıcı üzerinden işlem yapacağımı belirtiyorum.
            driver.Navigate().GoToUrl("http://google.com");//Url'e gitme işlemi

            driver.FindElement(By.Name("q")).SendKeys("alisari41");
            //Google a incele yaptıktan sonra arama kısmını ismini "q" aldıktan sonra o kısma istediğim veriyii gönderiyorum

            driver.FindElement(By.Name("q")).Submit();
            //Arama kısmına gönderdiğim veriyi bu sefer submit ederek arama işlemini gerçekleştiriyorum.


            ReadOnlyCollection<IWebElement> searchResult = driver.FindElements(By.CssSelector("a > h3"));
            //Arama kısmında çıkan sekmeleri Consola yazdırma işlemi bunun için Collection kullandım
            //İncele yaptıktan sonra "a" linkleri içersinde "h3" başlıkları bize site textlerini verdiği anlaşılıyor

            //bunları console yazdırmak için foreach kullanılması gerekir
            foreach (var r in searchResult)
            {
                var title = r.Text;//bana "a" linkleri içersindeki "h3" başlıkların textini getir.
                Console.WriteLine(title);
            }


            //Arama yapıp listelediğim sitelerin bir tanesine gitmek istiyorum. LinkText çalışmadı PartialLinkText kullandım
            driver.FindElement(By.PartialLinkText("Ali SARI - Düzce Üniversitesi - Derince, Kocaeli, Türkiye")).Click();


        }
    }
}
