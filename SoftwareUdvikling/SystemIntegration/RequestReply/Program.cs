// Create a connection to the RabbitMQ server
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" }; // Change to your RabbitMQ server address

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    // Declare a queue for receiving responses
    string replyQueueName = channel.QueueDeclare().QueueName;

    // Set up a consumer to listen for responses
    var consumer = new EventingBasicConsumer(channel);
    channel.BasicConsume(queue: replyQueueName, autoAck: true, consumer: consumer);

    Console.WriteLine("Enter your request:");
    string message = "5";

    // Publish the request
    var props = channel.CreateBasicProperties();
    props.ReplyTo = replyQueueName;
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(
        exchange: "",
        routingKey: "rpc_queue", // Name of the queue for requests
        basicProperties: props,
        body: body
    );

    Console.WriteLine("Request sent: " + message);

    // Wait for the response
    consumer.Received += (model, ea) =>
    {
        var response = Encoding.UTF8.GetString(ea.Body.ToArray());
        Console.WriteLine("Response received: " + response);
    };

    Console.WriteLine("Press [Enter] to exit.");
    Console.ReadLine();
}