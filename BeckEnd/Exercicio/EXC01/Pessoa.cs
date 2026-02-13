using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXC01
{
    public class Pessoa
    {
        public string Nome;

        public int Idade;

        public string Sobrenome;

        public void Apresentar(string Nome, int Idade)
        {
            Nome = Nome;
            Idade = Idade;
        }
        public void Apresentar(string Nome, int Idade ,string Sobrenome)
        {
            Nome = Nome;
            Idade = Idade;
            Sobrenome = Sobrenome;
        }




        public void ExibirDados()
        {
            Console.WriteLine($@"
            Nome: {Nome} 
            idade: {Idade}
            Sobrenome: {Sobrenome}");

            if (Idade <= 0)
            {
                Console.WriteLine($"Sua idade esta inconpativel");

            }
        }
    }

}