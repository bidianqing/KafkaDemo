using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://github.com/wurstmeister/kafka-docker
            // https://github.com/sheepkiller/kafka-manager-docker

            var config = new Dictionary<string, object>
            {
                { "bootstrap.servers", "192.168.199.235:9092" }
            };

            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                while (true)
                {
                    Console.WriteLine("按任意键发送消息");
                    Console.ReadKey();
                    var dr = producer.ProduceAsync("my-topic", null, "test message text").Result;
                    Console.WriteLine($"Delivered '{dr.Value}' to: {dr.TopicPartitionOffset}");
                }
            }
        }
    }
}
