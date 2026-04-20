using System;
using System.Collections.Generic;

public class Usuario
{
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string NumUsuario { get; set; }
    public DateTime DataCadastro { get; set; }

    public bool VerificarLogin(string senhaDigitada) 
    {
        return this.Senha == senhaDigitada;
    }
}

public class Cliente : Usuario
{
    public string NomeCliente { get; set; }
    public string Endereco { get; set; }
    public string InfoCartaoCredito { get; set; }
    public string InfoFrete { get; set; }
    public float SaldoConta { get; set; }

    public void Registrar() 
    {
        Console.WriteLine("==== REGISTRAR CLIENTE ====");
        Console.Write("Nome: ");
        NomeCliente = Console.ReadLine();
        Console.Write("Endereco: ");
        Endereco = Console.ReadLine();
        Console.Write("Cartao de Credito: ");
        InfoCartaoCredito = Console.ReadLine();
        Console.Write("Frete: ");
        InfoFrete = Console.ReadLine();
        Console.Write("Saldo: ");
        float.TryParse(Console.ReadLine(), out float saldo);
        SaldoConta = saldo;
        DataCadastro = DateTime.Now;
    }

    public void LoginCliente() 
    { 
        Console.WriteLine("==== LOGIN CLIENTE ====");
        Console.Write("Login: ");
        string log = Console.ReadLine();
        Console.Write("Senha: ");
        string sen = Console.ReadLine();
        if (VerificarLogin(sen)) 
            Console.WriteLine("Acesso confirmado.");
        else 
            Console.WriteLine("Senha incorreta.");
    } 

    public void AtualizarLogin() 
    {
        Console.WriteLine("==== ATUALIZAR LOGIN ===="); 
        Console.Write("Digite Senha Atual: ");
        if (VerificarLogin(Console.ReadLine())) {
            Console.Write("Novo Email: ");
            Email = Console.ReadLine();
            Console.Write("Nova Senha: ");
            Senha = Console.ReadLine();
        }
    }
}

public class Administrador : Usuario 
{
    public string NomeAdm { get; set; }
    public string EmailAdm { get; set; }

    public void AtualizarCatalogo() 
    {
        Console.WriteLine("==== ATUALIZAR CATÁLOGO ====");
        Console.Write("Nome do Produto: ");
        string prod = Console.ReadLine();
        Console.Write("Ação [Add/Rem]: ");
        string acao = Console.ReadLine();
        Console.WriteLine($"Produto {prod} atualizado ({acao}) com sucesso.");
    }
}

public class Produto
{
    public string NomeProduto { get; set; }
    public string Material { get; set; }
    public string Status { get; set; }
    public string Tamanho { get; set; }
    public int QuantidadeDisponivel { get; set; }
    public string Favoritar { get; set; }

    public void StatusProduto() 
    {
        Console.WriteLine("==== STATUS PRODUTO ====");
        Console.Write("Novo Status: ");
        Status = Console.ReadLine();
    }

    public void AtualizarQuantidadeDisponivel() 
    {
        Console.WriteLine("==== ATUALIZAR ESTOQUE ====");
        Console.Write("Quantidade: ");
        int.TryParse(Console.ReadLine(), out int qtd);
        QuantidadeDisponivel = qtd;
    }

    public void AtualizarFavoritar() 
    {
        Console.WriteLine("==== FAVORITAR ====");
        Console.Write("Favorito [S/N]: ");
        Favoritar = Console.ReadLine();
    }
}

public class Favoritos
{
    public string NomeProduto { get; set; }
    public string Material { get; set; }
    public string Status { get; set; }
    public string Tamanho { get; set; }

    public void StatusFavorito() 
    {
        Console.WriteLine("==== STATUS FAVORITO ====");
        Console.Write("Observação: ");
        string obs = Console.ReadLine();
        Console.WriteLine("Status do favorito atualizado.");
    }
}

public class CarrinhoDeCompra
{
    public int NumCarrinho { get; set; }
    public int NumProduto { get; set; }
    public int Quantidade { get; set; }
    public string DataAdicionado { get; set; } // Alterado para string para facilitar

    public void AtualizarQuantidade() 
    {
        Console.WriteLine("==== QNT NO CARRINHO ====");
        Console.Write("Nova Quantidade: ");
        int.TryParse(Console.ReadLine(), out int qtd);
        Quantidade = qtd;
    }

    public void AdicionarItemCarrinho() 
    {
        Console.WriteLine("==== ADICIONAR ITEM ====");
        Console.Write("ID do Produto: ");
        int.TryParse(Console.ReadLine(), out int id);
        NumProduto = id;
    }

    public void VerDetalhesCarrinho() 
    {
        Console.WriteLine("==== DETALHES CARRINHO ====");
        Console.WriteLine($"Carrinho nº: {NumCarrinho} | Itens: {Quantidade}");
    }

    public void FinalizarPedido() 
    {
        Console.WriteLine("==== FINALIZAR PEDIDO ====");
        Console.Write("Confirmar [S/N]: ");
        string conf = Console.ReadLine();
        if(conf?.ToUpper() == "S") Console.WriteLine("Pedido enviado para processamento.");
    }
}

public class InformacoesDeEnvio
{
    public int NumFrete { get; set; }
    public string TipoFrete { get; set; }
    public float PrecoFrete { get; set; }
    public float PrecoRegiaoFrete { get; set; }

    public void AtualizarPrecoFrete() 
    {
        Console.WriteLine("==== ATUALIZAR FRETE ====");
        Console.Write("Novo Preco: ");
        float.TryParse(Console.ReadLine(), out float preco);
        PrecoFrete = preco;
    }
}

public class Pedido
{
    public int NumPedido { get; set; }
    public string NomePedido { get; set; }
    public string DataCriacao { get; set; }
    public string Status { get; set; }
    public string NomeCliente { get; set; }
    public string NumCliente { get; set; }
    public string NumFrete { get; set; }

    public void EfetuarPedido() 
    {
        Console.WriteLine("==== EFETUAR PEDIDO ====");
        Console.Write("Nome do Pedido: ");
        NomePedido = Console.ReadLine();
        Status = "Processando";
        DataCriacao = DateTime.Now.ToString();
        Console.WriteLine("Pedido efetuado com sucesso!");
    }
}

public class DetalhesPedido
{
    public int NumPedido { get; set; }
    public string NomePedido { get; set; }
    public int Quantidade { get; set; }
    public float PrecoUnidade { get; set; }
    public float Subtotal { get; set; } 

    public void CalcuPreco() 
    {
        Console.WriteLine("==== CALCULAR PREÇO ====");
        Console.Write("Preço Unidade: ");
        float.TryParse(Console.ReadLine(), out float preco);
        PrecoUnidade = preco;
        Console.Write("Quantidade: ");
        int.TryParse(Console.ReadLine(), out int qtd);
        Quantidade = qtd;
        Subtotal = PrecoUnidade * Quantidade;
        Console.WriteLine($"Subtotal: {Subtotal}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Cliente cliente = new Cliente();
        cliente.Login = "user123";
        cliente.Senha = "1234";    
        
        cliente.Registrar();
        Console.WriteLine("\n");

        cliente.LoginCliente();
        Console.WriteLine("\n");

        Produto notebook = new Produto();
        notebook.NomeProduto = "Notebook Gamer";
        notebook.AtualizarQuantidadeDisponivel();
        notebook.StatusProduto();
        Console.WriteLine("\n");

        CarrinhoDeCompra meuCarrinho = new CarrinhoDeCompra();
        meuCarrinho.NumCarrinho = 101;
        meuCarrinho.AdicionarItemCarrinho();
        meuCarrinho.AtualizarQuantidade();
        meuCarrinho.VerDetalhesCarrinho();
        Console.WriteLine("\n");

        DetalhesPedido detalhes = new DetalhesPedido();
        detalhes.CalcuPreco();
        Console.WriteLine("\n");

        InformacoesDeEnvio envio = new InformacoesDeEnvio();
        envio.AtualizarPrecoFrete();
        
        Pedido novoPedido = new Pedido();
        novoPedido.NumPedido = 5001;
        novoPedido.EfetuarPedido();

        Console.WriteLine("\n--- ÁREA DO ADMINISTRADOR ---");
        Administrador adm = new Administrador();
        adm.AtualizarCatalogo();

        Console.WriteLine("\nSistema finalizado. Pressione qualquer tecla para sair.");
        Console.ReadKey();
    }
}