﻿using RoutingApp.BookActivityOperations;

namespace RoutingApp;

public class Handler(
    IRouterParameterFactory factory,
    IBookActivityRouter router,
    IServiceProvider keyedServiceProvider)
    : IHandler
{
    public async Task UseHandler(Command command)
    {
        var parameters = await factory.GetParameters(command);

        var operationName = router.GetOperation(parameters);

        var operation = keyedServiceProvider.GetRequiredKeyedService<IBookActivityOperation>(operationName);

        await operation.DoOperation();
    }
}