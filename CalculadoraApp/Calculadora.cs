using System;

namespace CalculadoraApp
{
    public class Calculadora
    {
        public double Sumar(double a, double b)
        {
            return a + b;
        }

        public double Restar(double a, double b)
        {
            return a - b;
        }

        public double Multiplicar(double a, double b)
        {
            return a * b;
        }

        public double Dividir(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("No se puede dividir por cero");

            return a / b;
        }

        public double CalcularPorcentaje(double cantidad, double porcentaje)
        {
            if (porcentaje < 0)
                throw new ArgumentException("El porcentaje no puede ser negativo");

            return (cantidad * porcentaje) / 100;
        }

        public bool EsNumeroPar(int numero)
        {
            return numero % 2 == 0;
        }

        public double CalcularRaizCuadrada(double numero)
        {
            if (numero < 0)
                throw new ArgumentException("No se puede calcular la raíz cuadrada de un número negativo");

            return Math.Sqrt(numero);
        }
    }
}