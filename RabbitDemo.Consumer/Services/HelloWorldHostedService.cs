namespace RabbitDemo.Consumer.Services;

public class HelloWorldHostedService : BackgroundService
{
    private readonly IHelloWorldConsumerService _helloWorldConsumerService;

    public HelloWorldHostedService(IHelloWorldConsumerService helloWorldConsumerService)
    {
        _helloWorldConsumerService = helloWorldConsumerService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _helloWorldConsumerService.ConsumeHelloWorldMessage();
    }
}