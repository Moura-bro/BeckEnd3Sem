using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXC01
{
    public class Funcionario : Pessoa
    {
        public float salario;

        public void ExibirDados()
        {
            Console.WriteLine($@"
            Nome: {Nome} 
            idade: {Idade}
            Salario: R${salario}");

            if (Idade < 0)
            {
                Console.WriteLine($"Sua idade esta inconpativel");
            }
            
        }
    }
}