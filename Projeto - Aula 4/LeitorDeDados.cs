﻿using System.Globalization;

/// <summary>
/// Representa um algoritmo que lê dados do console.
/// </summary>
public static class LeitorDeDados
{
	/// <summary>
	/// Lê o nome do usuário no console.
	/// </summary>
	/// <returns>
	/// Uma <see cref="string"/> que representa o nome digitado pelo usuário,
	/// ou "Anônimo", caso o usuário não tenha digitado nada.
	/// </returns>
	public static string LerNome()
	{
		Console.Write("Digite o seu nome: ");
		var nome = Console.ReadLine();

		return string.IsNullOrWhiteSpace(nome)
			? "Anônimo"
			: nome;
	}

	/// <summary>
	/// Lê a data de nascimento do usuário no console.
	/// </summary>
	/// <remarks>
	/// O método não retorna até que o usuário digite uma data num formato aceito pelo <see cref="DateOnly"/>.
	/// </remarks>
	/// <returns>
	/// Um <see cref="DateOnly"/> que representa a data de nascimento digitada pelo usuário. 
	/// </returns>
	public static DateOnly LerDataDeNascimento()
	{
		var entrada = string.Empty;
		DateOnly dataValida;

		while (!DateOnly.TryParse(entrada, out dataValida))
		{
			entrada = PerguntarDataDeNascimento();
		}

		return dataValida;
	}

    /// <summary>
    /// Lê a data de nascimento do usuário no console.
    /// </summary>
    /// <remarks>
    /// O método não retorna até que o usuário digite uma data num formato aceito pelo <see cref="DateOnly"/>.
    /// </remarks>
    /// <returns>
    /// Um <see cref="DateOnly"/> que representa a data de nascimento digitada pelo usuário. 
    /// </returns>
    public static DateOnly LerDataDeNascimentoTryCatch()
    {
        var entrada = string.Empty;
        DateOnly dataValida;

        while (true)
        {
            try
            {
                entrada = PerguntarDataDeNascimento();
                dataValida = DateOnly.Parse(entrada!);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Formato inválido. Esperado: dd/MM/aaaa. Digitado: {entrada}");
            }
        }

        return dataValida;
    }

    /// <summary>
    /// Lê a data de nascimento do usuário no console.
    /// </summary>
    /// <remarks>
    /// O método não retorna até que o usuário digite uma data num formato aceito pelo <see cref="DateOnly"/>.
    /// </remarks>
    /// <returns>
    /// Um <see cref="DateOnly"/> de cultura invariante, que representa a data de nascimento digitada pelo usuário. 
    /// </returns>
    public static DateOnly LerDataDeNascimentoRecursivo()
	{
		var entrada = PerguntarDataDeNascimento();

		return DateOnly.TryParse(entrada, CultureInfo.InvariantCulture, out var dataValida)
			? dataValida
			: LerDataDeNascimentoRecursivo();
	}

	static string? PerguntarDataDeNascimento()
	{
		Console.Write("Digite a sua data de nascimento no formato dd/mm/aaaa: ");
		return Console.ReadLine();
	}
}
