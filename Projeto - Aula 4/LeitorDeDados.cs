namespace Projeto___Aula_4;

/// <summary>
///		Representa um algoritmo que lê dados do console.
/// </summary>
public static class LeitorDeDados
{
	/// <summary>
	///		Lê o nome do usuário no console.
	/// </summary>
	/// <returns> 
	///		Uma <see cref="string"/> que representa o nome digitado pelo usuário, 
	///		ou "Anônimo", caso o usuário não tenha digitado nada.
	/// </returns>
	public static string LerNome()
	{
		Console.Write("Digite o seu nome: ");
		var nome = Console.ReadLine();
		return nome == string.Empty || nome == null
			? "Anônimo"
			: nome;
	}

	/// <summary>
	///		Lê a data de nascimento do usuário no console.
	/// </summary>
	/// <remarks>
	///		O método não retorna até que o usuário digite uma data num formato aceito pelo <see cref="DateTime"/>.
	/// </remarks>
	/// <returns> 
	///		Um <see cref="DateTime"/> que representa a data de nascimento digitada pelo usuário. 
	/// </returns>
	public static DateTime LerDataDeNascimento()
	{
		var entrada = string.Empty;
		DateTime dataValida;

		while (!DateTime.TryParse(entrada, out dataValida))
		{
			Console.Write("Digite a sua data de nascimento no formato dd/mm/aaaa: ");
			entrada = Console.ReadLine();
		}

		return dataValida;
	}
}
