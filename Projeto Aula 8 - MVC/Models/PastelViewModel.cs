namespace Projeto_Aula_8___MVC.Models;

public class PastelViewModel
{

    public string Recheio { get; private set; }
    public decimal Preco { get; private set; }

    public PastelViewModel(string recheio, decimal preco)
    {
        Recheio = recheio;
        Preco = preco;
    }

}
