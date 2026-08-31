using DeliveryHub.Application.Repositories;
using DeliveryHub.Domain.Entities;

namespace DeliveryHub.Application.Clientes.Criar;

public class CriarClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public CriarClienteUseCase(
        IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<CriarClienteResponse> ExecutarAsync(
        CriarClienteRequest request)
    {
        var clienteExistente =
            await _clienteRepository.BuscarPorEmailAsync(
                request.Email
            );

        if (clienteExistente is not null)
        {
            throw new ArgumentException(
                "Já existe um cliente com esse e-mail."
            );
        }

        var cliente = new Cliente(
            request.Nome,
            request.Email,
            request.Telefone
        );

        await _clienteRepository.AdicionarAsync(cliente);

        return new CriarClienteResponse
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            Ativo = cliente.Ativo,
            CriadoEm = cliente.CriadoEm
        };
    }
}