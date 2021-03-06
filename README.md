# Azure Messaging and Events Examples

Sample repository for demonstrating messaging and events using azure services such as Azure Service Bus, Event Grid, and more.

## Other areas to look for

In addition to Azure messaging and events these examples also illustrate use of:

* Configuration
* Logging
* Dependency Injection
* .NET Core Console Application

## Note about Scripts

There are various provisioning scripts available as part of this repository that will help provision any Azure resources. You can execute these scripts either using [Azure Cloud Shell](https://docs.microsoft.com/en-us/azure/cloud-shell/overview?view=azure-cli-latest) or [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/?view=azure-cli-latest) if you have it installed directly on your machine.

## Service Bus Examples

### Service Bus Sender

This example shows how to **send** messages **to** a Service Bus **Queue**. To work through this example follow the steps below:

#### Setup Service Bus Sender

1. Go to the [setup-service-bus.azcli](ops/provision/setup-service-bus.azcli) script located in this repository.
2. Edit any `Variables` in the script if you want to change anything prior to execution or leave as is.
3. Execute the script (see [note](#note-about-scripts))
4. The script outputs to a `connectionString` variable, make note of this connection string value for use in the source code. It will look something like the below:

    ```bash
    # view the variable
    echo $connectionString

    # Output but with the actual values
    Endpoint=sb://<yournamespace>.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=<youraccesskey>
    ```

5. Go to [ServiceBusSender](src/ServiceBusSender) directory and find the [appsettings.json](src/ServiceBusSender/appsettings.json) file
6. In appsettings.json find the `ServiceBusSettings` section and update the values for `ServiceBusNamespace` and `SharedAccessKey` specifying the values from the connection string that was output from the script execution in previous steps. **NOTE**: Do not check this into source control, alternatively you can add an `appsettings.local.json` file and specify the settings there.
7. Additionally, if you changed the `queueName` in the Variables of the provisioning script you will need to update the `QueueName` setting in the `ServiceBusSettings` section of appsettings.json file as well.
8. Rebuild the Solution
9. Run the `ServiceBusSender` console application using Visual Studio

### Service Bus Receiver

This example shows how to **receive** messages **from** a Service Bus **Queue**. To work through this example follow the steps below:

#### Setup Service Bus Receiver

1. Go thru the steps for [Service Bus Sender](#setup-service-bus-sender) to send some message into a queue and get some of the initial setup complete that is also used in the receiver proejct
2. Have the `connectionString` information on hand that was used when working thru [Service Bus Sender](#service-bus-sender).
3. Go to [ServiceBusReceiver](src/ServiceBusReceiver) directory and find the [appsettings.json](src/ServiceBusReceiver/appsettings.json) file
4. In appsettings.json find the `ServiceBusSettings` section and update the values for `ServiceBusNamespace` and `SharedAccessKey` specifying the values from the connection string that was output from the script execution in previous steps. **NOTE**: Do not check this into source control, alternatively you can add an `appsettings.local.json` file and specify the settings there.
5. Additionally, if you changed the `queueName` in the Variables of the provisioning script you will need to update the `QueueName` setting in the `ServiceBusSettings` section of appsettings.json file as well.
6. Rebuild the Solution
7. Run the `ServiceBusReceiver` console application using Visual Studio

## References

* [Quickstart: Use the Azure CLI to create a Service Bus queue](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-quickstart-cli)
* [Get started with Service Bus queues](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-dotnet-get-started-with-queues)
* [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/?view=azure-cli-latest)
* [Azure Cloud Shell](https://docs.microsoft.com/en-us/azure/cloud-shell/overview?view=azure-cli-latest)
