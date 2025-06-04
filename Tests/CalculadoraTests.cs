using NUnit.Framework;
using System;
using CalculadoraApp;

namespace CalculadoraApp.Tests
{
    [TestFixture]
    public class CalculadoraTests
    {
        private Calculadora calculadora;

        [SetUp]
        public void Setup()
        {
            // Se ejecuta antes de cada test
            calculadora = new Calculadora();
        }

        [TearDown]
        public void TearDown()
        {
            // Se ejecuta después de cada test (limpieza si es necesaria)
            calculadora = null;
        }

        #region Pruebas de Suma
        [Test]
        public void Sumar_NumerosPositivos_RetornaResultadoCorrecto()
        {
            double a = 5.5;
            double b = 3.2;
            double esperado = 9.7;

            double resultado = calculadora.Sumar(a, b);

            Assert.AreEqual(esperado, resultado, 0.001);
        }

        [Test]
        public void Sumar_NumeroNegativoYPositivo_RetornaResultadoCorrecto()
        {
            double a = -5;
            double b = 10;
            double esperado = 5;

            double resultado = calculadora.Sumar(a, b);

            Assert.AreEqual(esperado, resultado);
        }

        [TestCase(0, 0, 0)]
        [TestCase(1, 1, 2)]
        [TestCase(-1, -1, -2)]
        [TestCase(100, 200, 300)]
        public void Sumar_VariosValores_RetornaResultadoEsperado(double a, double b, double esperado)
        {
            double resultado = calculadora.Sumar(a, b);

            Assert.AreEqual(esperado, resultado);
        }
        #endregion

        #region Pruebas de División
        [Test]
        public void Dividir_NumerosValidos_RetornaResultadoCorrecto()
        {
            double a = 10;
            double b = 2;
            double esperado = 5;

            double resultado = calculadora.Dividir(a, b);

            Assert.AreEqual(esperado, resultado);
        }

        [Test]
        public void Dividir_PorCero_LanzaExcepcion()
        {
            double a = 10;
            double b = 0;

            var ex = Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(a, b));
            Assert.AreEqual("No se puede dividir por cero", ex.Message);
        }
        #endregion

        #region Pruebas de Porcentaje
        [Test]
        public void CalcularPorcentaje_ValoresValidos_RetornaResultadoCorrecto()
        {
            double cantidad = 200;
            double porcentaje = 15;
            double esperado = 30;

            double resultado = calculadora.CalcularPorcentaje(cantidad, porcentaje);

            Assert.AreEqual(esperado, resultado);
        }

        [Test]
        public void CalcularPorcentaje_PorcentajeNegativo_LanzaExcepcion()
        {
            double cantidad = 100;
            double porcentaje = -10;

            Assert.Throws<ArgumentException>(() => calculadora.CalcularPorcentaje(cantidad, porcentaje));
        }
        #endregion

        #region Pruebas de Número Par
        [Test]
        public void EsNumeroPar_NumeroParPositivo_RetornaTrue()
        {
            int numero = 4;

            bool resultado = calculadora.EsNumeroPar(numero);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void EsNumeroPar_NumeroImpar_RetornaFalse()
        {
            int numero = 5;

            bool resultado = calculadora.EsNumeroPar(numero);

            Assert.IsFalse(resultado);
        }

        [TestCase(0, true)]
        [TestCase(2, true)]
        [TestCase(-2, true)]
        [TestCase(1, false)]
        [TestCase(-1, false)]
        public void EsNumeroPar_VariosValores_RetornaResultadoEsperado(int numero, bool esperado)
        {
            bool resultado = calculadora.EsNumeroPar(numero);

            Assert.AreEqual(esperado, resultado);
        }
        #endregion

        #region Pruebas de Raíz Cuadrada
        [Test]
        public void CalcularRaizCuadrada_NumeroPositivo_RetornaResultadoCorrecto()
        {
            double numero = 16;
            double esperado = 4;

            double resultado = calculadora.CalcularRaizCuadrada(numero);

            Assert.AreEqual(esperado, resultado, 0.001);
        }

        [Test]
        public void CalcularRaizCuadrada_NumeroNegativo_LanzaExcepcion()
        {
            double numero = -9;

            var ex = Assert.Throws<ArgumentException>(() => calculadora.CalcularRaizCuadrada(numero));
            Assert.That(ex.Message, Does.Contain("número negativo"));
        }
        #endregion

        #region Pruebas Múltiples con TestCase
        [TestCase(10, 5, 2)]
        [TestCase(15, 3, 5)]
        [TestCase(100, 4, 25)]
        public void Dividir_VariosValores_RetornaResultadoEsperado(double a, double b, double esperado)
        {
            double resultado = calculadora.Dividir(a, b);

            Assert.AreEqual(esperado, resultado);
        }
        #endregion
    }
}