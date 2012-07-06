using System.Collections.Generic;
using aspConf.Controllers.Models;
using aspConf.Model;

namespace aspConf.Controllers {
    using System.Web.Mvc;

    public class ScheduleController : Controller
    {
        private ConfContext db = new ConfContext();

        public ActionResult Room()
        {
            return View();
        }
        public ActionResult Index()
        {
            var model = new ScheduleViewModel();
            var day1 = new ScheduleDay() {Title = "Day 1"};

            day1.Rooms.Add(new Room() { JoinUrl = "http://live.aspconf.net", Name = "Live Streaming" });
            day1.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 1" });
            day1.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 2" });
            day1.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 3" });
            day1.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 4" });
            day1.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 5" });

            day1.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("9-10:30am CST","7-8:30am PST","3-4:30pm UTC")
                    .AddSession(null)
                    .AddSession(db.FindScheduleSession(22))
                    .AddSession(db.FindScheduleSession(21))
                    .AddSession(db.FindScheduleSession(10))
                    .AddSession(db.FindScheduleSession(37))
                    .AddSession(db.FindScheduleSession(20))
                    );

            day1.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("10:30-12pm CST", "8:30-10am PST", "4:30-6pm UTC")
                    .AddSession(null)
                    .AddSession(db.FindScheduleSession(23))
                    .AddSession(db.FindScheduleSession(17))
                    .AddSession(db.FindScheduleSession(19))
                    .AddSession(db.FindScheduleSession(2))
                    .AddSession(null)
                    );
            day1.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("12-1:30pm CST", "10-11:30am PST", "6-7:30pm UTC")
                    .AddSession(null)
                    .AddSession(db.FindScheduleSession(7))
                    .AddSession(db.FindScheduleSession(18))
                    .AddSession(db.FindScheduleSession(16))
                    .AddSession(db.FindScheduleSession(27))
                    .AddSession(db.FindScheduleSession(3))
                    );
            day1.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("1:30-2:30pm CST", "11:30-12:30pm PST", "7:30-8:30pm UTC")
                    .AddSession(new ScheduleSession()
                                    {
                                        IsKeynote = true,
                                        SpeakerName = "Scott Guthrie"
                                        ,Title = "aspConf Keynote"
                                    })
                    );
           day1.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("4:30-6pm CST", "2:30-4pm PST", "10:30pm-12am UTC")
                    .AddSession(null)
                    .AddSession(db.FindScheduleSession(9))
                    .AddSession(db.FindScheduleSession(24))
                    .AddSession(db.FindScheduleSession(25))
                    .AddSession(db.FindScheduleSession(26))
                    .AddSession(db.FindScheduleSession(1))
                    );

           day1.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("6-7:30pm CST", "4-5:30pm PST", "12-1:30am UTC")
                    .AddSession(null)
                    .AddSession(db.FindScheduleSession(45))
                    .AddSession(null)
                    .AddSession(db.FindScheduleSession(12))
                    .AddSession(db.FindScheduleSession(53))
                    .AddSession(db.FindScheduleSession(4))
                    );

            model.Days.Add(day1);

            var day2 = new ScheduleDay() { Title = "Day 2" };

            day2.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 1" });
            day2.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 2" });
            day2.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 3" });
            day2.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 4" });
            day2.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 5" });

            day2.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("9-10:30am CST", "7-8:30am PST", "3-4:30pm UTC")
                    .AddSession(new ScheduleSession(){IsKeynote = true})
                    );

            day2.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("10:30-12pm CST", "8:30-10am PST", "4:30-6pm UTC")
                    .AddSession(new ScheduleSession() { IsKeynote = true }));
            day2.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("12-1:30pm CST", "10-11:30am PST", "6-7:30pm UTC")
                    .AddSession(new ScheduleSession() { IsKeynote = true }));
            day2.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("1:30-2:30pm CST", "11:30-12:30pm PST", "7:30-8:30pm UTC")
                    .AddSession(new ScheduleSession()
                    {
                        IsKeynote = true,
                        SpeakerName = "Scott Hanselman"
                        ,
                        Title = "aspConf Keynote"
                    })
                    );
            day2.TimeSlots.Add(
                 new TimeSlot()
                     .AddTime("4:30-6pm CST", "2:30-4pm PST", "10:30pm-12am UTC")
                     .AddSession(new ScheduleSession()
                     {
                         IsKeynote = true,
                         SpeakerName = ""
                         ,
                         Title = ""
                     })
                     );

            day2.TimeSlots.Add(
                 new TimeSlot()
                     .AddTime("6-7:30pm CST", "4-5:30pm PST", "12-1:30am UTC")
                     .AddSession(new ScheduleSession()
                     {
                         IsKeynote = true,
                         SpeakerName = ""
                         ,
                         Title = ""
                     })
                     );

            model.Days.Add(day2); 
            return View(model);
        }
    }
}