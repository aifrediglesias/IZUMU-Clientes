//-----------------------------------------------------------------------
// <copyright file="KafkaManagerAdapter" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifred</author>
// <date>19/07/2025 11:11:05</date>
// <summary>Código fuente interfaz KafkaManagerAdapter.</summary>
//-----------------------------------------------------------------------
namespace IzumuAdapter.Implementations
{
    using Confluent.Kafka;
    using IzumuAdapter;
    using IzumuAdapter.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// KafkaManagerAdapter.
    /// </summary>
    public class KafkaManagerAdapter : IQueueManagerAdapter
    {
        #region Attributes

        /// <summary>
        /// Message Receive Event.
        /// </summary>
        event EventHandler<InputMessageEventHandler>? MessageReceiveEvent;

        /// <summary>
        /// object Lock.
        /// </summary>
        object? _objectLock;

        /// <summary>
        /// Attribute used to application Logger.
        /// </summary>
        private readonly ILogger<KafkaManagerAdapter>? _logger;

        /// <summary>
        /// Configuration manager.
        /// </summary>
        private readonly IConfiguration? _configuration;

        /// <summary>
        /// Producer manager.
        /// </summary>
        private IProducer<Null, string>? _producer;

        /// <summary>
        /// Consumer manager.
        /// </summary>
        private IConsumer<Ignore, string>? _consumer;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KafkaManagerAdapter"/> class.
        /// </summary>
        /// <param name="configuration">Configuration manager.</param>
        /// <param name="logger">Logger manager.</param>
        public KafkaManagerAdapter(IConfiguration configuration, ILogger<KafkaManagerAdapter> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Object Lock.
        /// </summary>
        object ObjectLock
        {
            get
            {
                if (_objectLock == null)
                    _objectLock = new object();

                return _objectLock;
            }
        }

        /// <summary>
        /// Receive data event.
        /// </summary>
        event EventHandler<InputMessageEventHandler> IQueueManagerAdapter.OnMessageReceive
        {
            add
            {
                lock (ObjectLock)
                {
                    MessageReceiveEvent += value;
                }
            }
            remove
            {
                lock (ObjectLock)
                {
                    MessageReceiveEvent -= value;
                }
            }
        }

        /// <summary>
        /// Get Consumer.
        /// </summary>
        public IConsumer<Ignore, string>? Consumer
        {
            get
            {
                if (_consumer == null)
                {
                    var consumerConfig = new ConsumerConfig
                    {
                        BootstrapServers = _configuration?.GetSection("BootstrapServers").Value,
                        GroupId = "IzumuConsumerGroup",
                        AutoOffsetReset = AutoOffsetReset.Earliest
                    };

                    _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
                }
                return _consumer;
            }
        }

        /// <summary>
        /// Get Producer.
        /// </summary>
        public IProducer<Null, string>? Producer
        {
            get
            {
                if (_producer == null)
                {
                    var producerconfig = new ProducerConfig
                    {
                        BootstrapServers = _configuration?.GetSection("BootstrapServers").Value
                    };

                    _producer = new ProducerBuilder<Null, string>(producerconfig).Build();
                }
                return _producer;
            }
        }

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to dispose all memory.
        /// </summary>
        public void Dispose()
        {
            Consumer?.Dispose();
            Producer?.Dispose();
        }

        /// <summary>
        /// Method used to Receive Message From Queue.
        /// </summary>
        /// <param name="topic">Topic.</param>
        /// <param name="stoppingToken">Cancellation token.</param>
        public async void Subscribe(string topic, CancellationToken stoppingToken)
        {
            try
            {
                Consumer?.Subscribe(topic);

                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        await ProcessKafkaMessage();
                    }
                    catch (ConsumeException ex)
                    {
                        _logger?.LogError($"Error processing Kafka message: {ex.Message}");
                    }

                    await Task.Delay(TimeSpan.FromMilliseconds(200), stoppingToken);
                }
            }
            catch (OperationCanceledException ex)
            {
                _logger?.LogError($"Error processing Kafka message: {ex.Message}");
            }
            finally
            {
                Consumer?.Close();
            }
        }

        /// <summary>
        /// Method used to Send Message To Queue.
        /// </summary>
        /// <param name="topic">Topic.</param>
        /// <param name="message">Message to be send.</param>
        /// <returns></returns>
        public async Task ProduceAsync(string topic, string message)
        {
            var kafkamessage = new Message<Null, string> { Value = message, };
            if (kafkamessage != null && !string.IsNullOrEmpty(topic))
                await Producer!.ProduceAsync(topic, kafkamessage);
        }

        /// <summary>
        /// Method used to process message from kafka.
        /// </summary>
        private async Task ProcessKafkaMessage()
        {
            try
            {
                await Task.Run(() =>
                {
                    var consumeResult = Consumer?.Consume(TimeSpan.FromMilliseconds(500));
                    if (consumeResult != null)
                    {
                        var message = consumeResult?.Message.Value;
                        _logger?.LogInformation($"Received inventory update: {message}");

                        if (!string.IsNullOrEmpty(message))
                            MessageReceiveEvent?.Invoke(this, new InputMessageEventHandler() { Message = message });
                    }
                })
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error processing Kafka message: {ex.Message}");
            }
        }

        #endregion
    }
}
