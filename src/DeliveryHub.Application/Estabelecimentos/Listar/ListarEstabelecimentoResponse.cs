namespace DeliveryHub.Application.Estabelecimentos.Listar;

public class ListarEstabelecimentoResponse
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public bool Ativo { get; set; }

    public DateTime CriadoEm { get; set; }
}