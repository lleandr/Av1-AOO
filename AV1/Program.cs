using System;
using System.Collections.Generic;

class Mensagem
{
    public string Texto { get; set; }

    public Mensagem(string text)
    {
        Texto = text;
    }

    public virtual void Enviar()
    {
        Console.WriteLine($"[Mensagem] Texto: {Texto}");
    }
}

class MensagemSMS : Mensagem
{
    public DateTime DataEnvio { get; set; }

    public MensagemSMS(string conteudo, DateTime dataEnvio) : base(conteudo)
    {
        DataEnvio = dataEnvio;
    }

    public override void Enviar()
    {
        Console.WriteLine($"[Texto] Mensagem: {Texto}, Data de Envio: {DataEnvio}");
    }
}

class Video : Mensagem
{
    public string Arquivo { get; set; }
    public string Formato { get; set; }
    public int Duracao { get; set; } 

    public Video(string conteudo, string arquivo, string formato, int duracao) : base(conteudo)
    {
        Arquivo = arquivo;
        Formato = formato;
        Duracao = duracao;
    }

    public override void Enviar()
    {
        Console.WriteLine($"[Vídeo] Mensagem: {Texto}, Título: {Arquivo}, Formato: {Formato}, Duração: {Duracao}s");
    }
}

class Foto : Mensagem
{
    public string Arquivo { get; set; }
    public string Formato { get; set; }

    public Foto(string conteudo, string arquivo, string formato) : base(conteudo)
    {
        Arquivo = arquivo;
        Formato = formato;
    }

    public override void Enviar()
    {
        Console.WriteLine($"[Foto] Mensagem: {Texto}, Título: {Arquivo}, Formato: {Formato}");
    }
}

class Arquivo : Mensagem
{
    public string Arquivos  { get; set; }
    public string Formato { get; set; }

    public Arquivo(string conteudo, string arquivo, string formato) : base(conteudo)
    {
        Arquivos = arquivo;
        Formato = formato;
    }

    public override void Enviar()
    {
        Console.WriteLine($"[Arquivo] Mensagem: {Texto}, Título: {Arquivos}, Formato: {Formato}");
    }
}

interface ICanal
{
    void EnviarMensagem(Mensagem mensagem);
}

class Telefone : ICanal
{
    

    public string NumeroTelefone { get; set; }

    public Telefone(string numero)
    {
        NumeroTelefone = numero;
    }

    public void EnviarMensagem(Mensagem mensagem)
    {
        Console.WriteLine($"\nCanal: Telefone (+55 (xx) {NumeroTelefone})");
        mensagem.Enviar();
    }
}

class Usuario : ICanal
{
    public string Usuarios { get; set; }

    public Usuario(string usuario)
    {
        Usuarios = usuario;
    }

    public void EnviarMensagem(Mensagem mensagem)
    {
        Console.WriteLine($"\nCanal: Usuário (@{Usuarios})");
        mensagem.Enviar();
    }
}

class Program
{
    static void Main()
    {   
        Console.Write($@"Escolha o canal para enviar sua mensagem:
1 - Número de telefone
2 - Usuário
Digite a opção (1 ou 2): ");
        int escolha = Convert.ToInt32(Console.ReadLine());
        string cananal;
        string ccc;
        ICanal canal;

        if (escolha == 1 )
        {
            Console.Write("\nDigite o número de telefone: +55 (xx) ");
            string numero = Console.ReadLine();
            canal = new Telefone(numero);
            cananal = "Telegram e Whatsapp";
            ccc = "Contato";
        }
        else if (escolha == 2)
        {
            Console.Write("\nDigite o nome do usuário: @");
            string nome = Console.ReadLine();
            canal = new Usuario(nome);
            cananal = "Instagram, Facebook e Telegram";
            ccc = "Usuário";
        }
        else
        {
            Console.WriteLine("\nOpção inválida.");
            return;
        }
        
        Console.Write($@"
Escolha o tipo de arquivo:
1 - Texto
2 - Vídeo
3 - Foto
4 - Arquivo
Digite a opção (1, 2, 3 ou 4): ");

        int tipo = Convert.ToInt32(Console.ReadLine());
        Mensagem mensagem = null;
        if (tipo == 1)
        {
            Console.Write("\nDigite o texto da mensagem: ");
            string texto = Console.ReadLine();
            mensagem = new Mensagem(texto);
        }
        else if (tipo == 2)
        {
            Console.Write("\nDigite o título do vídeo: ");
            string titulo = Console.ReadLine();
            Console.Write("\nDigite o formato do vídeo: ");
            string formato = Console.ReadLine();
            Console.Write("\nDigite a duração do vídeo (em segundos): ");
            
            int duracao = int.Parse(Console.ReadLine());
            mensagem = new Video(titulo, titulo, formato, duracao);
        }
        else if (tipo == 3)
        {
            Console.Write("\nDigite o título da foto: ");
            string titulo = Console.ReadLine();
            Console.Write("\nDigite o formato da foto: ");
            string formato = Console.ReadLine();
            mensagem = new Foto(titulo, titulo, formato);
        }
        else if (tipo == 4)
        {
            Console.Write("\nDigite o título do arquivo: ");
            string titulo = Console.ReadLine();
            Console.Write("\nDigite o formato do arquivo: ");
            string formato = Console.ReadLine();
            mensagem = new Arquivo(titulo, titulo, formato);
        }
        else
        {
            Console.WriteLine("\nOpção inválida. ");
            
        }
        canal.EnviarMensagem(mensagem);
        Console.WriteLine($"Mensagem enviada pelos canais: {cananal} do {ccc} selecionado");
    }
}
