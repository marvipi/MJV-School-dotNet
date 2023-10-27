/// <summary>
/// Representa um usuário deste sistema, que tem um nome, uma data de nascimento e uma data de centenário.
/// </summary>
public class Usuario
{
    /// <remarks>
    /// Nenhuma validação é feita para assegurar que este valor realmente é um nome.
    /// </remarks>
    public string Nome { get; private set; }

    /// <remarks>
    /// Nenhuma validação é feita para assegurar que esta data é realista.
    /// </remarks>
    public DateTime DataDeNascimento { get; private set; }

    /// <summary>
    /// A data em que este usuário fará 100 anos de idade.
    /// </summary>
    public DateTime Centenario { get; private set; }

    /// <summary>
    /// Instancia um novo usuário, cujo nome é "Anônimo" e cuja data de centenario é daqui 100 anos.
    /// </summary>
    public Usuario() : this("Anônimo", DateTime.Now) { }

    /// <summary>
    /// Instancia um novo usuário, inicializando o nome, a data de nascimento e a data do centenário.
    /// </summary>
    /// <param name="nome"> O nome do usuário. </param>
    /// <param name="dataDeNascimento"> A data de nascimento do usuário. </param>
    public Usuario(string nome, DateTime dataDeNascimento)
	{
        Nome = nome;
        Atualizar(dataDeNascimento);
	}

    /// <summary>
    /// Atualiza o nome deste usuário.
    /// </summary>
	public void Atualizar(string nome) => Nome = nome;

    /// <summary>
    /// Atualiza a data de nascimento e a data do centenário.
    /// </summary>
    public void Atualizar(DateTime dataDeNascimento)
    {
        DataDeNascimento = dataDeNascimento;
        CalcularCentenario();
    }
    
    void CalcularCentenario() => Centenario = DataDeNascimento.AddYears(100);
	
}
