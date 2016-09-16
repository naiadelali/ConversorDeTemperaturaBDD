using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ConversorDeTemperaturaBDD
{

    public class TelaConversaoTemperatura
    {
        private IWebDriver _driver;

        public TelaConversaoTemperatura()
        {
            _driver = new FirefoxDriver();

        }

        public void CarregarPagina()
        {
            _driver.Manage().Timeouts().SetPageLoadTimeout(
               TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl(
                    ConfigurationManager.AppSettings["urlTelaConversaoTemp"]);
        }

        public void PreencherTemperaturaCelsius(double valor)
        {
            IWebElement CampoTemperatura = _driver.FindElement(By.Id("temperatura"));
            CampoTemperatura.SendKeys(valor.ToString());


        }

        public void ProcessarConversao()
        {
            IWebElement botaoConverter = _driver.FindElement(By.Id("btnConverter"));
            botaoConverter.Submit();

            WebDriverWait wait = new WebDriverWait(
                _driver, TimeSpan.FromSeconds(10));
            wait.Until((drv) => _driver.FindElement(By.Id("resultado")) != null);
        }

        public double ObterTemperaturaKelvin()
        {
            IWebElement resultado = _driver.FindElement(By.Id("resultado"));
            return Convert.ToDouble(resultado.Text);
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
