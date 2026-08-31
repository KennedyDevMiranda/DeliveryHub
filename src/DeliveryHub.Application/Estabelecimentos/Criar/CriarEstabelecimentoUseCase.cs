using DeliveryHub.Application.Repositories;
using DeliveryHub.Domain.Entities;

namespace DeliveryHub.Application.Estabelecimentos.Criar;

public class CriarEstabelecimentoUseCase
{
    private readonly IEstabelecimentoRepository _repository;

    public CriarEstabelecimentoUseCase(
        IEstabelecimentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<CriarEstabelecimentoResponse> ExecutarAsync(
        CriarEstabelecimentoRequest request)
    {
        var estabelecimento = new Estabelecimento(
            request.Nome,
            request.Descricao
        );

        await _repository.AdicionarAsync(estabelecimento);

        return new CriarEstabelecimentoResponse
        {
            Id = estabelecimento.Id,
            Nome = estabelecimento.Nome,
            Descricao = estabelecimento.Descricao,
            Ativo = estabelecimento.Ativo,
            CriadoEm = estabelecimento.CriadoEm
        };
    }
}