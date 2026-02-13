using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXC03
{
    public class Pessoa
    {
        
        public string Nome;

        public int Idade;

         public void ExibirDados()
        {
            Console.WriteLine($@"
            Nome: {Nome} 
            idade: {Idade}");
            

            if (Idade <= 0)
            {
                Console.WriteLine($"Sua idade esta inconpativel");

            }
        }
    }
}