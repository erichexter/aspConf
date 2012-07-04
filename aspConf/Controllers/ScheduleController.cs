using System.Collections.Generic;
using aspConf.Controllers.Models;

namespace aspConf.Controllers {
    using System.Web.Mvc;

    public class ScheduleController : Controller
    {
        public ActionResult Room()
        {
            return View();
        }
        public ActionResult Index()
        {
            var model = new ScheduleViewModel();
            var day1 = new ScheduleDay() {Title = "Day 1"};
            
            day1.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("8-9am CST")
                    .AddTime("6-7AM PST")
                    .AddTime("14-15 UTC")
                    .AddSession(null)
                    .AddSession(new ScheduleSession()
                                    {
                                        IsKeynote = false,
                                        SpeakerName = "Shay Friedman",
                                        Title = "The Big Comparison of ASP.NET MVC View Engines",
                                        SpeakerRateId = "5518",
                                        Url = "/sessions/#friedman"
                                    })
                    .AddSession(new ScheduleSession()
                    {
                        IsKeynote = false,
                        SpeakerName = "John Peterson",
                        Title = "Intro to MVC2",
                        SpeakerRateId = "1",
                        Url = "/sessions/#friedman"
                    })
                    .AddSession(new ScheduleSession()
                    {
                        IsKeynote = false,
                        SpeakerName = "John Peterson",
                        Title = "Intro to MVC3",
                        SpeakerRateId = "2",
                        Url = "/sessions/#friedman"
                    })
                    .AddSession(new ScheduleSession()
                    {
                        IsKeynote = false,
                        SpeakerName = "John Peterson",
                        Title = "Intro to MVC4",
                        SpeakerRateId = "3",
                        Url = "/sessions/#friedman"
                    })
                
                );

            day1.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("9-10am CST")
                    .AddTime("7-8AM PST")
                    .AddTime("15-16 UTC")
                    .AddSession(null)
                    .AddSession(new ScheduleSession()
                    {
                        IsKeynote = false,
                        SpeakerName = "Shay Friedman",
                        Title = "The Big Comparison of ASP.NET MVC View Engines",
                        SpeakerRateId = "5518",
                        Url = "/sessions/#friedman"
                    })
                    .AddSession(new ScheduleSession()
                    {
                        IsKeynote = false,
                        SpeakerName = "John Peterson",
                        Title = "Intro to MVC2",
                        SpeakerRateId = "1",
                        Url = "/sessions/#friedman"
                    })
                    .AddSession(new ScheduleSession()
                    {
                        IsKeynote = false,
                        SpeakerName = "John Peterson",
                        Title = "Intro to MVC3",
                        SpeakerRateId = "2",
                        Url = "/sessions/#friedman"
                    })
                    .AddSession(new ScheduleSession()
                    {
                        IsKeynote = false,
                        SpeakerName = "John Peterson",
                        Title = "Intro to MVC4",
                        SpeakerRateId = "3",
                        Url = "/sessions/#friedman"
                    })
                );

            day1.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("10am CST")
                    .AddTime("8AM PST")
                    .AddTime("16 UTC")
                    
                    .AddSession(new ScheduleSession()
                    {
                        IsKeynote = true,
                        SpeakerName = "The Gu",
                        Title = "Keynote",
                        SpeakerRateId = "5518",
                        Url = "/sessions/#friedman"
                    })
                );

            day1.Rooms.Add(new Room() { JoinUrl = "http://live.aspconf.net", Name = "Live Streaming" });
            day1.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 1" });
            day1.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 2" });
            day1.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 3" });
            day1.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 4" });
            //model.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 5" }); 

            model.Days.Add(day1);

            //model.Days.Add(new ScheduleDay(){Title = "Day 2"});
            return View(model);
        }
    }
}