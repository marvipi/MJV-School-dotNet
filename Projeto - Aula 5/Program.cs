
const int MAIOR_NUM_LOTERIA = 60;
const int NUMS_POR_APOSTA = 6;
const decimal PRECO_POR_APOSTA = 5M;


var nome = LerNome();
var dinheiro = LerQtdDinheiro();
var numsDaLoteria = NumerosDaLoteria();
var numsDaSorte = PegarNumerosDaSorte(dinheiro, numsDaLoteria);
Exibir(nome, numsDaSorte);


string LerNome()
{
    Console.Write("Digite o seu nome: ");
    return Console.ReadLine();
}

decimal LerQtdDinheiro()
{
    Console.Write("Quantos reais você tem para jogar na loteria? ");
    return decimal.Parse(Console.ReadLine());
}

int[] PegarNumerosDaSorte(decimal dinheiro, int[] numsDaLoteria)
{
    var qtdApostas = (int)(dinheiro / PRECO_POR_APOSTA);
    var qtdNumsDaSorte = qtdApostas * NUMS_POR_APOSTA;
    var numsDaSorte = new int[qtdNumsDaSorte];
    var rng = new Random();

    for (int i = 0; i < numsDaSorte.Length; i++)
    {
        var indiceAleatorio = rng.Next(numsDaLoteria.Length);
        numsDaSorte[i] = numsDaLoteria[indiceAleatorio];
    }

    return numsDaSorte;
}

int[] NumerosDaLoteria()
{
    var numsPossiveis = new int[60];

    for (int i = 0; i < MAIOR_NUM_LOTERIA; i++)
    {
        numsPossiveis[i] = i;
    }

    return numsPossiveis;
}

void Exibir(string nome, int[] numsDaSorte)
{
    Console.WriteLine($"Olá, {nome}. Seus números da sorte são:");
    for (int i = 0; i < numsDaSorte.Length; i++)
    {
        Console.Write("{0} ", numsDaSorte[i]);
        if (DivisivelPor6(i + 1))
        {
            Console.WriteLine();
        }
    }
}

bool DivisivelPor6(int num) => num % 6 == 0;