using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXC04
{
    public class Pessoa
    {
        public string Nome;

        public string Sobrenome;

        public int Idade;


        



         public Pessoa(string N, int I)
        {
            Nome = N;
            Idade = I;
        }

        public Pessoa(string N, int I, string S)
        {
            Nome = N;
            Sobrenome = S;
            Idade = I;
        }

          public void ExibirDados()
        {
            Console.WriteLine($@"
            Nome: {Nome} 
            idade: {Idade}
            ");
        }
    

          public void Apresentar()
        {
            Console.WriteLine($@"
            Nome: {Nome} 
            idade: {Idade}
            Sobrenome: {Sobrenome}");
        }
    }
}