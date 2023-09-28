// Create a connection to the RabbitMQ server
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Security.Authentication.ExtendedProtection;

var factory = new ConnectionFactory() { HostName = "localhost" }; // Change to your RabbitMQ server address

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    // Declare a queue for receiving responses
    string replyQueueName = channel.QueueDeclare().QueueName;

    // Set up a consumer to listen for responses
    var consumer = new EventingBasicConsumer(channel);
    channel.BasicConsume(queue: replyQueueName, autoAck: true, consumer: consumer);
    channel.BasicQos(prefetchSize: 0, prefetchCount: 5, false);

    Console.WriteLine("Sending messages");

    for (int i = 5; i > 0; i--)
    {
        // Publish the request
        var props = channel.CreateBasicProperties();
        props.ReplyTo = replyQueueName;
        props.CorrelationId = i.ToString();
        props.MessageId = "FirstSequence";
        var body = Encoding.UTF8.GetBytes(i.ToString());

        // I tried to hardcode the last message with a "Flag" that has the "Last" appendix,
        // such that it would know that it was the last message of the sequence,
        // and it could begin receiving a new sequence
        if (i == 5)
        {
            //props.MessageId += "Last";
        }

        channel.BasicPublish(
            exchange: "",
            routingKey: "rpc_queue", // Name of the queue for requests
            basicProperties: props,
            body: body
        );

        Console.WriteLine("Request sent: " + i.ToString());
        Console.WriteLine(props.MessageId);
    }

    //for (int i = 5; i > 0; i--)
    //{
    //    // Publish the request
    //    var props = channel.CreateBasicProperties();
    //    props.ReplyTo = replyQueueName;
    //    props.CorrelationId = i.ToString();
    //    props.MessageId = "SecondSequence";
    //    if (i == 5)
    //    {
    //        //props.MessageId += "Last";
    //    }

    //    var body = Encoding.UTF8.GetBytes(i.ToString());

    //    channel.BasicPublish(
    //        exchange: "",
    //        routingKey: "rpc_queue", // Name of the queue for requests
    //        basicProperties: props,
    //        body: body
    //    );

    //    Console.WriteLine("Request sent: " + i.ToString());
    //    Console.WriteLine(props.MessageId);
    //}

    // Wait for the response
    consumer.Received += (model, ea) =>
    {
        var response = Encoding.UTF8.GetString(ea.Body.ToArray());
        Console.WriteLine("Response received: " + response);
    };

    Console.WriteLine("Press [Enter] to exit.");
    Console.ReadLine();
}