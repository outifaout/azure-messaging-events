namespace Common.Settings
{
    public class MessageSenderSettings
    {
        public string ServiceBusNamespace { get; set; }
        public string SharedAccessKey { get; set; }
        public string SharedAccessKeyName { get; set; }
        public string QueueName { get; set; }

        internal string GetConnectionString()
        {
            return $"Endpoint=sb://{ServiceBusNamespace}.servicebus.windows.net/;SharedAccessKeyName={SharedAccessKeyName};SharedAccessKey={SharedAccessKey}";
        }
    }
}
