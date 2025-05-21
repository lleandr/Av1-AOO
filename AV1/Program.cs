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
        Console.WriteLine($"Canal: Telefone ({NumeroTelefone})");
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
        Console.WriteLine($"Canal: Usuário ({Usuarios})");
        mensagem.Enviar();
    }
}

class Program
{
    static void Main()
    {
        ICanal canal1 = new Telefone("+55 11 98765-4321");
        ICanal canal2 = new Usuario("joao123");

        Mensagem msg1 = new MensagemSMS("oi", DateTime.Now);
        Mensagem msg2 = new Video("vídeo", "video.mp4", "mp4", 120);
        Mensagem msg3 = new Foto("foto", "foto.jpg", "jpg");
        Mensagem msg4 = new Arquivo("aquivo", "arquivo.pdf", "pdf");

        canal1.EnviarMensagem(msg1);
        canal2.EnviarMensagem(msg2);

        canal2.EnviarMensagem(msg3);
        canal1.EnviarMensagem(msg4);
    }
}
