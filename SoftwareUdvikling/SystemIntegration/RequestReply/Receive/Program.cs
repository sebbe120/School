using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

// Create a connection to the RabbitMQ server
var factory = new ConnectionFactory() { HostName = "localhost" }; // Change to your RabbitMQ server address

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    // Declare a queue for receiving requests
    channel.QueueDeclare(queue: "rpc_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

    // Set up a consumer to listen for requests
    var consumer = new EventingBasicConsumer(channel);
    channel.BasicConsume(queue: "rpc_queue", autoAck: false, consumer: consumer);
    channel.BasicQos(prefetchSize: 0, prefetchCount: 5, false);

    Console.WriteLine("Receiver waiting for requests...");

    int nextMessageId = 1;
    string currentMassageID = "";

    consumer.Received += (model, ea) =>
    {
        var request = Encoding.UTF8.GetString(ea.Body.ToArray());
        Console.WriteLine("Received request: " + request);

        // Send the response back to the sender
        var props = ea.BasicProperties;
        var replyProps = channel.CreateBasicProperties();
        replyProps.CorrelationId = props.CorrelationId;

        // Process the request (e.g., perform some work)
        var response = "Response to " + props.MessageId + " " + int.Parse(request);

        if (currentMassageID == "")
        {
            currentMassageID = props.MessageId;
        }

        if (props.MessageId.Contains(currentMassageID) && int.Parse(replyProps.CorrelationId) == nextMessageId)
        {
            channel.BasicAck(ea.DeliveryTag, false);
            var responseBytes = Encoding.UTF8.GetBytes(response);

            channel.BasicPublish(
                exchange: "",
                routingKey: props.ReplyTo,
                basicProperties: replyProps,
                body: responseBytes);

            nextMessageId++;

            if (props.MessageId.Contains("Last"))
            {
                currentMassageID = "";
                nextMessageId = 0;
                Console.WriteLine("Reset" + currentMassageID);
            }
        }
        else
        {
            channel.BasicNack(ea.DeliveryTag, false, true);
        }
    };

    Console.WriteLine("Press [Enter] to exit.");
    Console.ReadLine();
}
