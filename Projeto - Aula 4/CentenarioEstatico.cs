namespace Projeto___Aula_4;

/// <summary>
///		Representa um algoritmo que calcula a data do centenário do usuário.
/// </summary>
public static class CentenarioEstatico
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

	/// <summary>
	///		Calcula a data em que o usuário fará 100 anos de idade.
	/// </summary>
	/// <param name="dataDeNascimento"> 
	///		A data de nascimento do usuário. 
	/// </param>
	/// <returns> 
	///		Um <see cref="DateTime"/> que representa a data na qual o usuário fará 100 anos de idade. 
	/// </returns>
	public static DateTime CalcularCentenario(DateTime dataDeNascimento) => dataDeNascimento.AddYears(100);
}
