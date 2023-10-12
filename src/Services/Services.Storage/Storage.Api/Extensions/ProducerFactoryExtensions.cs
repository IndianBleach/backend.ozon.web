﻿using Confluent.Kafka;
using Ozon.Bus.DTOs.StorageService;
using Ozon.Bus;

namespace Storage.Api.Extensions
{
    public static class ProducerFactoryExtensions
    {
        public static void AddProducerFactory(
            this IServiceCollection services,
            string kafkaHost)
        {
            var producerFactory = new ProducerFactory();
            producerFactory.Register<string, StorageProductUpdateMarketplaceStockInfo>(new ProducerConfig()
            {
                BootstrapServers = kafkaHost,
                Acks = Acks.Leader,
                EnableBackgroundPoll = false,
            });

            producerFactory.Register<string, SyncProductRegistryInfoAnswer>(new ProducerConfig()
            {
                BootstrapServers = kafkaHost,
                Acks = Acks.Leader,
                EnableBackgroundPoll = false
            });

            producerFactory.Register<string, AddStorageMessage>(new ProducerConfig()
            {
                BootstrapServers = kafkaHost,
                Acks = Acks.Leader,
                EnableBackgroundPoll = false,
            });

            services.AddSingleton<IProducerFactory>(producerFactory);
        }
    }
}
