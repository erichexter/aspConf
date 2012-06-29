namespace CloudFrontManager {
    using System;
    using System.Net.Mail;
    using System.Threading;
    using Amazon.CloudFront;
    using Amazon.CloudFront.Model;

    class Program
    {
        static void Main(string[] args)
        {

            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@aspconf.net");

            message.To.Add(new MailAddress("javier@loznaotek.com"));
            
            
            message.Subject = "This is my subject";
            message.Body = "This is the content";

            SmtpClient client = new SmtpClient();
            client.Send(message);

            //var distributionId = "EJCDLYDTUKDBE";
            //var client = new AmazonCloudFrontClient();
            //var batch = new InvalidationBatch()
            //        .WithCallerReference(Guid.NewGuid().ToString())
            //        .WithPaths(new Paths()
            //            .WithQuantity(1)
            //            .WithItems("/index.htm"));
            
            //var request = new CreateInvalidationRequest()
            //    .WithDistributionId(distributionId)
            //    .WithInvalidationBatch(batch);


            //var response = client.CreateInvalidation(request);
            //var invalidationId = response.CreateInvalidationResult.Invalidation.Id;

            //if (string.IsNullOrEmpty(invalidationId)) return;
            
            //while (true) {
            //    var invalidationResponse = client.GetInvalidation(
            //        new GetInvalidationRequest().WithDistributionId(distributionId).WithId(invalidationId));

            //    var status = invalidationResponse.GetInvalidationResult.Invalidation.Status;
            //    if (status != "InProgress") break;

            //    Console.WriteLine("Waiting 10secs before checking...");
            //    Thread.Sleep(10000);
            //}

            //Console.WriteLine("Invalidation complete!");
        }
    }
}
