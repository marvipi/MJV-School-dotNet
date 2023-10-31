
const int MAIOR_NUM_LOTERIA = 60;
const int NUMS_POR_APOSTA = 6;
const decimal PRECO_POR_APOSTA = 5M;

Apostar();

// Permite que o usuário jogue na loteria, desde que ele tenha dinheiro o suficiente para apostar.
void Apostar()
{
    Console.WriteLine(" $$$$$$ LOTERIA PREMIADA $$$$$$ ");
    var nome = LerNome();
    while (true)
    {
        var dinheiro = LerQtdDinheiro();
        if (dinheiro < PRECO_POR_APOSTA)
        {
            var msg = string.Format("Infelizmente você precisa de R${0} para apostar mas só tem R${1}.", 
                PRECO_POR_APOSTA, dinheiro);
            Console.WriteLine(msg);
            break;
        }

        var numsDaSorte = PegarNumerosDaSorte(dinheiro);
        Exibir(nome, numsDaSorte);

        if (JogarNovamente() == "n")
        {
            Console.WriteLine("Adeus, {0}. Boa sorte no sorteio!", nome);
            break;
        }
    }
}

// Gera uma sequência de apostas, cada uma contendo NUMS_POR_APOSTA números distintos.
// A quantidade de dinheiro digitada pelo usuário delimita a quantidade de apostas feita.
// Pressupõe que dinheiro é maior ou igual a PRECO_POR_APOSTA.
int[] PegarNumerosDaSorte(decimal dinheiro)
{
    var qtdNumsDaSorte = DefinirQtdNumsDaSorte(dinheiro);
    return GerarNumerosDaSorte(qtdNumsDaSorte);
}

// Gera uma sequência de apostas feita pelo usuário.
// Cada aposta tem NUMS_POR_APOSTA números distintos.
// Pressupõe que qtdNumsDaSorte é divisível por NUMS_POR_APOSTA.
int[] GerarNumerosDaSorte(int qtdNumsDaSorte) 
{
    var numsDaSorte = new int[qtdNumsDaSorte];
    var rng = new Random();
    foreach (var i in Enumerable.Range(0, numsDaSorte.Length))
    {
        foreach (var j in Enumerable.Range(0, NUMS_POR_APOSTA))
        {
            var novoNumDaSorte = 0;
            var apostaAtual = new int[NUMS_POR_APOSTA];

            while (apostaAtual.Contains(novoNumDaSorte)) // Apostas não podem ter números duplicados.
            {
                novoNumDaSorte = rng.Next(MAIOR_NUM_LOTERIA) + 1;
            }

            apostaAtual[j] = novoNumDaSorte;
            numsDaSorte[i] = novoNumDaSorte;
        }
    }

    return numsDaSorte;
}

// Calcula a quantidade de números da sorte que o usuário pode gerar.
// Pressupõe que dinheiro é maior ou igual a PRECO_POR_APOSTA.
int DefinirQtdNumsDaSorte(decimal dinheiro)
{
    var qtdNumsDaSorte = (int)(dinheiro / PRECO_POR_APOSTA) * NUMS_POR_APOSTA;

    qtdNumsDaSorte = DivisivelPor(qtdNumsDaSorte, NUMS_POR_APOSTA)
        ? qtdNumsDaSorte
        : (qtdNumsDaSorte - (qtdNumsDaSorte % NUMS_POR_APOSTA));

    return qtdNumsDaSorte;
}

// Exibe todos os números da sorte, mostrando cada aposta em uma linha diferente.
// Pressupõe que o comprimento de numsDaSorte é maior que zero e divisível por NUMS_POR_APOSTA.
void Exibir(string nome, int[] numsDaSorte)
{
    Console.WriteLine($"Olá, {nome}. Seus números da sorte são:");

    foreach (var i in Enumerable.Range(0, numsDaSorte.Length))
    {
        var numDaSorteFormatado = numsDaSorte[i].ToString("00");
        Console.Write("{0} ", numDaSorteFormatado);

        if (DivisivelPor(i + 1, NUMS_POR_APOSTA))
        {
            Console.WriteLine();
        }
    }
}

string JogarNovamente()
{
    var entrada = string.Empty;
    
    while (entrada != "s" && entrada != "n")
    {
        Console.WriteLine("Gostaria de apostar novamente? s/n");
        entrada = Console.ReadLine()?.ToLower();
    }

    return entrada;
}

string LerNome()
{
    Console.Write("Qual é o seu nome: ");
    return Console.ReadLine()!;
}

decimal LerQtdDinheiro()
{
    Console.Write("Quantos reais você gostaria de apostar na loteria? ");
    return decimal.Parse(Console.ReadLine()!);
}

bool DivisivelPor(int n, int d) => n % d == 0;
