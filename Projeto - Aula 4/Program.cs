
using Projeto___Aula_4;


var usuarioAnonimo = new Usuario();
ExibirCentenario(usuarioAnonimo.Nome, usuarioAnonimo.Centenario);


var nome = LeitorDeDados.LerNome();
var dataDeNascimento = LeitorDeDados.LerDataDeNascimento();
var usuario = new Usuario(nome, dataDeNascimento);
ExibirCentenario(usuario.Nome, usuario.Centenario);


usuario.Atualizar("Novo nome");
usuario.Atualizar(DateTime.Now);
ExibirCentenario(usuario.Nome, usuario.Centenario);


void ExibirCentenario(string nome, DateTime centenario)
{
	Console.WriteLine($"Olá, {nome}!");
	Console.WriteLine($"Você fará 100 anos em {centenario.ToShortDateString()}.");
}
