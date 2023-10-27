
var nome = LerNome();

var dataDeNascimento = PerguntarDataDeNascimento();

var aniversarioCentenario = AniversarioCentenario(dataDeNascimento);

Console.WriteLine($"Você viverá até {aniversarioCentenario.ToShortDateString()}");

string LerNome()
{
	Console.Write("Digite o seu nome: ");
	var nome = Console.ReadLine();
	return nome == string.Empty || nome == null
		? "Anônimo"
		: nome;
}

DateTime PerguntarDataDeNascimento()
{
	Console.Write("Digite a sua data de nascimento: ");
	var entrada = Console.ReadLine();
	while (!DateTime.TryParse(entrada, out _))
	{
		Console.Write("Digite a sua data de nascimento: ");
		entrada = Console.ReadLine();
	}
	return DateTime.Parse(entrada);
}

DateTime AniversarioCentenario(DateTime dataDeNascimento)
{
	var aniversarioCentenario = dataDeNascimento.AddYears(100);
	return aniversarioCentenario;
}