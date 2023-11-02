
using System.Text;

const int MAIOR_NUM_LOTERIA = 60;
const int NUMS_POR_APOSTA = 6;
const decimal PRECO_POR_APOSTA = 5M;

Apostar();

// Permite que o usuário jogue na loteria, desde que ele tenha dinheiro o suficiente para apostar.
void Apostar()
{
    var nome = LerNome();
    var apostas = new List<int[]>();

    Console.WriteLine(" $$$$$$ LOTERIA PREMIADA $$$$$$ ");
    Console.WriteLine($"Olá, {nome}!");
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

        var aposta = PegarNumerosDaSorte(dinheiro);
        apostas.Add(aposta);

        if (JogarNovamente() == "n")
        {
            Console.WriteLine("Adeus, {0}. Boa sorte no sorteio!", nome);
            break;
        }
    }

    var saida = ApostasToString(nome, apostas);
    Console.WriteLine(saida);
    SalvarResultado(saida);
}

// Cria um arquivo de texto no diretório atual e salva o resultado das apostas dentro dele,
// sobreescrevendo o arquivo se necessário.
void SalvarResultado(string apostas)
{
    // \Projeto - Aula 5\bin\Debug\net7.0\apostas
    var caminhoDirApostas = Path.Combine(Environment.CurrentDirectory, "apostas");
    var dirApostas = Directory.CreateDirectory(caminhoDirApostas);

    // \Projeto - Aula 5\bin\Debug\net7.0\apostas\apostas.txt
    var caminhoArquivoApostas = Path.Combine(dirApostas.FullName, "apostas.txt");
    var arquivoDeApostas = new FileInfo(caminhoArquivoApostas);

    using (var streamWriter = arquivoDeApostas.CreateText())
    {
        foreach (var linha in apostas.Split(Environment.NewLine))
        {
            streamWriter.WriteLine(linha);
        }
    }
}

// Transforma cada aposta em uma string, separando-as entre linhas tracejadas.
string ApostasToString(string nome, List<int[]> apostas)
{
    var sb = new StringBuilder();
    sb.AppendLine($"{nome}, aqui estam os seus números da sorte:");
    foreach (var aposta in apostas)
    {
        sb.AppendLine("--------------------------------");
        var numsDaSorteString = NumsDaSorteToString(aposta);
        sb.Append(numsDaSorteString);
        sb.AppendLine("--------------------------------");
    }
    return sb.ToString();
}

// Transforma os números da sorte da aposta para uma string.
// Cada sequência de números da sorte é separada em uma linha diferente.
string NumsDaSorteToString(int[] aposta)
{
    var sb = new StringBuilder();
    foreach (var i in Enumerable.Range(0, aposta.Length))
    {
        var numDaSorteFormatado = aposta[i].ToString("00");
        sb.AppendFormat("  {0} ", numDaSorteFormatado);

        if (DivisivelPor(i + 1, NUMS_POR_APOSTA))
        {
            sb.AppendLine();
        }
    }
    return sb.ToString();
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
