using System.Collections.Generic;
using aspConf.Controllers.Models;

namespace aspConf.Controllers {
    using System.Web.Mvc;

    public class ScheduleController : Controller
    {
        public ActionResult Index()
        {
            var model = new ScheduleViewModel();
            
            model.TimeSlots.Add(
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
            
            model.Rooms.Add(new Room(){JoinUrl = "/live",Name = "Live Streaming"});
            model.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 1" });
            model.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 2" });
            model.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 3" });
            model.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 4" });
            //model.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 5" }); 
            return View(model);
        }
    }
}