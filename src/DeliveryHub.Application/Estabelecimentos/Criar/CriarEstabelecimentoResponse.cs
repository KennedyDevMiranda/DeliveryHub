namespace DeliveryHub.Application.Estabelecimentos.Criar;

public class CriarEstabelecimentoResponse
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public bool Ativo { get; set; }

    public DateTime CriadoEm { get; set; }
}