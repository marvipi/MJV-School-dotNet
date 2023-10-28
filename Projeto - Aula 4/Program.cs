using System.Globalization;


var culturaAlema = new CultureInfo("de-de");
var usuarioAnonimo = new Usuario();
ExibirCentenario(usuarioAnonimo.Nome, usuarioAnonimo.Centenario, culturaAlema);


var culturaBrasileira = new CultureInfo("pt-br");
var nome = LeitorDeDados.LerNome();
var dataDeNascimento = LeitorDeDados.LerDataDeNascimento();
var usuario = new Usuario(nome, dataDeNascimento);
ExibirCentenario(usuario.Nome, usuario.Centenario, culturaBrasileira);


void ExibirCentenario(string nome, DateOnly centenario, IFormatProvider formatoCultural)
{
	var centenarioEmFormatoLongo = centenario.ToString("D", formatoCultural);
	Console.WriteLine($"Olá, {nome}!");
	Console.WriteLine($"Você fará 100 anos em {centenarioEmFormatoLongo}.");
}
