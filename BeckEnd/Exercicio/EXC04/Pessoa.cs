using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXC04
{
    public class Pessoa
    {
        public string Nome;

        public int Idade;



        public Pessoa(string N, int I)
        {
            Nome = N;
            Idade = I;
        }

          public void ExibirDados()
        {
            Console.WriteLine($@"
            Nome: {Nome} 
            idade: {Idade}");
        }
    }
}