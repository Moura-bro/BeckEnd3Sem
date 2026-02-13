using EXC08;

Usuario u = u= new Usuario();
Adiministrador AD = new Adiministrador();

Console.WriteLine($"O Usuario Autenticou" + u.autenticar("123"));
Console.WriteLine($"O Adiministrador Autenticou" + AD.autenticar("admin"));
