using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Security.Authentication;

public interface IOrderService{
    void ProcessOrder (String orderId, String customerName);
}

public class StandardOrderService : IOrderService{
    public void ProcessOrder(string orderId, string customerName){
        Console.WriteLine($"[Standard] Processing Order {orderId} for {customerName}. Ships in 3-5 days");
    }
}

public class ExpressOrderService : IOrderService{
    public void ProcessOrder(string orderId, string customerName){
        Console.WriteLine($"[Express] Processing Order {orderId} for {customerName}. Ships in 1 day!");
    }
}

public class OrderProcessor{
    private readonly IOrderService _orderService;

    public OrderProcessor(IOrderService orderService){
        _orderService = orderService;
    }

    public void HandleOrder(string orderId, String customerName){
        Console.WriteLine($"New order recieved: {orderId}");
        _orderService.ProcessOrder(orderId, customerName);
        Console.WriteLine("Order handling complete. \n");

    }
}

class Program{
    static void Main(string [] args){
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddScoped<IOrderService, StandardOrderService>();
        serviceCollection.AddScoped<OrderProcessor>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var processor = serviceProvider.GetService<OrderProcessor>();

        processor.HandleOrder("ORD123", "Ahmed");
        processor.HandleOrder("ORD456", "Bilal");


        var expressServiceCollection = new ServiceCollection();
        expressServiceCollection.AddScoped<IOrderService, ExpressOrderService>();
        expressServiceCollection.AddScoped<OrderProcessor>();

        var expressProvider = expressServiceCollection.BuildServiceProvider();
        var expressProcessor = expressProvider.GetService<OrderProcessor>();

        expressProcessor.HandleOrder("ORD789", "Rafiq");


    }
}

