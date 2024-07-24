using Amazon.SQS;

namespace InterviewTestQA.InterviewTestAutomation
{
    public class SQSAutomation
    {
        private readonly AmazonSQSClient _amazonSQSClient;
        public SQSAutomation()
        {
            AmazonSQSConfig config = new AmazonSQSConfig()
            {
                ServiceURL = "https://localhost.localstack.cloud:4566",
                AuthenticationRegion = "us-east-1",
            };

            _amazonSQSClient = new AmazonSQSClient("xx", "xx", config);
        }

        public async Task<string> CreateOrSetQueueUrl()
        {
            string queueName = "test";
            try
            {
                var getQueueUrlResponse = await _amazonSQSClient.GetQueueUrlAsync(queueName);
                return getQueueUrlResponse.QueueUrl;
            }
            catch (Exception ex)
            {
                var createResponse = await _amazonSQSClient.CreateQueueAsync(queueName);
                return createResponse.QueueUrl;
            }
        }

        [Fact]
        public async void SendAndVerify()
        {
            var _queueUrl = await CreateOrSetQueueUrl();

            var message = "test message";
            var sendResponse = await _amazonSQSClient.SendMessageAsync(_queueUrl, message);
            Assert.Equal(System.Net.HttpStatusCode.OK, sendResponse.HttpStatusCode);

            var receiveResponse = await _amazonSQSClient.ReceiveMessageAsync(_queueUrl);
            Assert.Equal(System.Net.HttpStatusCode.OK, receiveResponse.HttpStatusCode);
            Assert.NotEmpty(receiveResponse.Messages);
            Assert.Equal(message, receiveResponse.Messages.First().Body);

            var deleteResponse = await _amazonSQSClient.DeleteQueueAsync(_queueUrl);
            Assert.Equal(System.Net.HttpStatusCode.OK, deleteResponse.HttpStatusCode);

        }

    }
}