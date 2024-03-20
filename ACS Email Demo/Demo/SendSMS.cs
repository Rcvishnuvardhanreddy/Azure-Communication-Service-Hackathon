using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;
    using Azure;
    using Azure.Communication;
    using Azure.Communication.Sms;

    namespace SendSMS
    {
        internal class Program
        {
            private static void Main()
            {
                var connectionString = "endpoint=https://notificationservicedemo.unitedstates.communication.azure.com/;accesskey=ihJYTq2ED4+kCSImDJOF5sBA81UIb4MrCRzIhg+RIphKR+5ayQ8f/m7vVR+frT3iE8Gw6t8VZjT7TxLQnGIZYw==\""; // Find your Communication Services resource in the Azure portal
                SmsClient smsClient = new SmsClient(connectionString);

                SmsSendResult sendResult = smsClient.Send(
                    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                    to: "<to-phone-number>", // E.164 formatted recipient phone number
                    message: "Hello 👋🏻");
                Console.WriteLine($"Message id {sendResult.MessageId}");

                Response<IReadOnlyList<SmsSendResult>> response = smsClient.Send(
                from: "<from-phone-number>",
                to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }, // E.164 formatted recipient phone numbers
                message: "Hello 👋🏻",
                options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
                {
                    Tag = "greeting", // custom tags
                });

                IEnumerable<SmsSendResult> results = response.Value;
                foreach (SmsSendResult result in results)
                {
                    Console.WriteLine($"Sms id: {result.MessageId}");
                    Console.WriteLine($"Send Result Successful: {result.Successful}");
                }
            }
        }
    }

}
