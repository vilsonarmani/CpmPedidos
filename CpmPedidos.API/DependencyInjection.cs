﻿using CpmPedidos.Interface;
using CpmPedidos.Repository;

namespace CpmPedidos.API;
public class DependencyInjection
{
    public static void Register(IServiceCollection serviceProvider)
    {
        RepositoryDependence(serviceProvider);
    }

    private static void RepositoryDependence(IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<IProdutoRepository, ProdutoRepository>();
        serviceProvider.AddScoped<IPedidoRepository, PedidoRepository>();
    }
}
