/// <summary>
/// Representa um usuário deste sistema, que tem um nome, uma data de nascimento e uma data de centenário.
/// </summary>
public class Usuario
{
    DateOnly _dataDeNascimento;

    /// <summary>
    /// O nome deste usuário.
    /// </summary>
    /// <remarks>
    /// Pressupõe que todos os valores passados são nomes válidos.
    /// </remarks>
    public string Nome { get; set; }

    /// <summary>
    /// A data de nascimento deste usuário.
    /// </summary>
    /// <remarks>
    /// Pressupõe que todos os valores passados são datas de nascimento válidas.
    /// </remarks>
    public DateOnly DataDeNascimento 
    { 
        get => _dataDeNascimento;
        set
        {
			_dataDeNascimento = value;
			Centenario = _dataDeNascimento.AddYears(100);
        }
    }

    /// <summary>
    /// A data em que este usuário fará 100 anos de idade.
    /// </summary>
    public DateOnly Centenario { get; private set; }

    /// <summary>
    /// Instancia um novo usuário, cujo nome é "Anônimo" e cuja data de centenario é daqui 100 anos.
    /// </summary>
    public Usuario() : this("Anônimo", DateOnly.FromDateTime(DateTime.Now)) { }

    /// <summary>
    /// Instancia um novo usuário, inicializando o nome, a data de nascimento e a data do centenário.
    /// </summary>
    public Usuario(string nome, DateOnly dataDeNascimento)
    {
		Nome = nome;
		DataDeNascimento = dataDeNascimento;
	}
	
}
