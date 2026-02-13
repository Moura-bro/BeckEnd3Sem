using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace EXC09
{
    public class CalculadoraClass
    {
        float A;
        float B;
        float Resultado;

        public CalculadoraClass(float a, float b)
        {
            A = a;
            B = b;
        }

        public void Somar()
        {
            Resultado = A + B;
            Console.Clear();
            Console.WriteLine($"O resultado da soma de {A} + {B} = {Resultado}");
        }

        public void Multiplicar()
        {
            Resultado = A + B;
            Console.Clear();
            Console.WriteLine($"O resultado da multpliacação de {A} * {B} = {Resultado}");
        }
    }
}