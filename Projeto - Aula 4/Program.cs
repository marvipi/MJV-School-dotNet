
var nome = LerNome();
var dataDeNascimento = LerDataDeNascimento();
var centenario = CalcularCentenario(dataDeNascimento);

Console.WriteLine($"Olá, {nome}!");
Console.WriteLine($"Você fará 100 anos em {centenario.ToShortDateString()}.");

string LerNome()
{
	Console.Write("Digite o seu nome: ");
	var nome = Console.ReadLine();
	return nome == string.Empty || nome == null
		? "Anônimo"
		: nome;
}

DateTime LerDataDeNascimento()
{
	var entrada = string.Empty;
	DateTime dataValida;

	// Tente converter o que o usuário digitou para um DateTime.
	// Se a conversão suceder, armazene o resultado da conversão na variável dataValida e saia do while.
	// Senão, peça para o usuário digitar de novo e tente fazer a conversão novamente.
	while (!DateTime.TryParse(entrada, out dataValida)) 
	{
		Console.Write("Digite a sua data de nascimento no formato dd/mm/aaaa: ");
		entrada = Console.ReadLine();
	}

	return dataValida;
}

DateTime CalcularCentenario(DateTime dataDeNascimento) => dataDeNascimento.AddYears(100);