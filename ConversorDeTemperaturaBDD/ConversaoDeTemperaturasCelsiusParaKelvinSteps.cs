using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace ConversorDeTemperaturaBDD
{
    [Binding]
    public class ConversaoDeTemperaturasCelsiusParaKelvinSteps
    {
        [Given(@"uma temperatura de (.*) Celsius")]
        public void DadoUmaTemperaturaDeCelsius(int temperatura)
        {
            _temperaturaCelsius = temperatura;
        }

        [When(@"eu solicitar a conversão deste valor")]
        public void QuandoEuSolicitarAConversaoDesteValor()
        {
            TelaConversaoTemperatura tela = new TelaConversaoTemperatura();

            tela.CarregarPagina();
            tela.PreencherTemperaturaCelsius(_temperaturaCelsius);
            tela.ProcessarConversao();
            _temperaturaKelvin = tela.ObterTemperaturaKelvin();
            tela.Fechar();
        }

        [Then(@"o resultado será (.*) Kelvin")]
        public void EntaoOResultadoSeraKelvin(decimal temperaturaKelvin)
        {
            Assert.AreEqual(temperaturaKelvin, _temperaturaKelvin);
        }

        private double _temperaturaCelsius;
        private decimal _temperaturaKelvin;


    }
}
