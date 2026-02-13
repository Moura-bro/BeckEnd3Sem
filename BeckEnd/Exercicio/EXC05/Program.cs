using EXC05;

// Funcionario
Funcionario F = new Funcionario();
Console.WriteLine($"Qual o seu Nome?");
F.Nome = Console.ReadLine();


Console.WriteLine($"Qual a sua Idade?");
F.Idade = int.Parse(Console.ReadLine());

Console.WriteLine($"Qunto voce ganha?");
F.salario = float.Parse(Console.ReadLine());

F.ExibirDados();