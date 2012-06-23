namespace SpeakerMailer {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using aspConf.Model;

    class Program
    {
        static void Main(string[] args)
        {
            var speakers = GetSpeakers();

            var subject = "We want you as a speaker for aspConf!";
            var from = "javier@lozanotek.com";
            var cc = "eric.hexter@gmail.com";

            var singleBody = @"Thank you for submitting your talk to aspConf!  In the upcoming weeks, you'll receive more information about the logistics for your presentation. <br /><br />
                Again, we want to thank you for your submission and helping us contribute back to the community!  If you have any questions, please reply to this email.
                <br /><br />
                Sincerely,
                <br /><br />
                The aspConf Team";

            var multipleBody = @"Thank you for submitting your talks to aspConf!  Since you submitted multiple talks, please let us know if you want to do one or all of them.  For us, the more the merrier!
                In the upcoming weeks, you'll receive more information about the logistics for your presentation.  
                <br /><br />
                Again, we want to thank you for your submission and helping us contribute back to the community!  If you have any questions, please reply to this email.
                <br /><br />                
                Sincerely,
                <br /><br />
                The aspConf Team";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("javier@lozanotek.com", "d0tn3t20-"),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            foreach (var speaker in speakers)
            {
                var body = speaker.Sessions.Count > 1 ? multipleBody : singleBody;
                var to = speaker.Email;

                var msg = new MailMessage(from, to)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                msg.CC.Add(cc);

                client.Send(msg);
                Console.WriteLine("Sent email to {0} at {1}....", speaker.FullName, speaker.Email);
            }

            Console.WriteLine("Press <ENTER> to exit...");
            Console.ReadKey(true);
        }

        public static IList<Speaker> GetSpeakers() {
            var context = new ConfContext();
            return context.Speakers.OrderBy(spkr => spkr.FullName).ToList();
        }
    }
}
