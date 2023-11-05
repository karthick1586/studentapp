using System;
using System.IO;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class func_na_studentapp
    {
        [FunctionName("func_na_studentapp")]
        public void Run([ServiceBusTrigger("studentappqueue", Connection = "sbqueueconnectionstring")]string myQueueItem, 
        [Blob("studentappblob/{messageId}.txt", System.IO.FileAccess.Write, Connection = "blobstorageconnectionstring")] Stream outblob, 
        ILogger log)
        {
            log.LogInformation(System.Environment.GetEnvironmentVariable("Environment", EnvironmentVariableTarget.Process));
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            outblob.Write(Encoding.ASCII.GetBytes(myQueueItem));
        }
    }
}
