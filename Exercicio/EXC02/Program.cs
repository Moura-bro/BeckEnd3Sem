using EXC02;

Pessoa P = new Pessoa();

Console.WriteLine($"Qual o seu Nome?");
P.Nome = Console.ReadLine();

Console.WriteLine($"Qual a sua Idade?");
P.Idade = int.Parse(Console.ReadLine());

P.ExibirDados();