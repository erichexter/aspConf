using System.Collections.Generic;
using aspConf.Controllers.Models;
using aspConf.Model;

namespace aspConf.Controllers {
    using System.Web.Mvc;
    using aspConf.Models;

    public class ScheduleController : Controller
    {
        private ConfContext db = new ConfContext();

        public ActionResult Room()
        {
            return View();
        }
        public ActionResult Index() {
            
            var model = new ScheduleViewModel();
            model.ShowJoinButtons = false;//turn this on the day of the conf.
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
                    .AddSession(db.FindScheduleSession(62))
                    .AddSession(db.FindScheduleSession(10))
                    .AddSession(db.FindScheduleSession(37))
                    .AddSession(null)
                    );

            day1.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("10:30-12pm CST", "8:30-10am PST", "4:30-6pm UTC")
                    .AddSession(null)
                    .AddSession(db.FindScheduleSession(23))
                    .AddSession(db.FindScheduleSession(21))
                    .AddSession(db.FindScheduleSession(19))
                    .AddSession(db.FindScheduleSession(2))
                    .AddSession(db.FindScheduleSession(57))
                    );
            day1.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("12-1:30pm CST", "10-11:30am PST", "6-7:30pm UTC")
                    .AddSession(null)
                    .AddSession(db.FindScheduleSession(7))
                    .AddSession(null)
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
                    .AddTime("3-4:30pm CST", "1-2:30pm PST", "9-10:30am UTC")
                    .AddSession(null)
                    .AddSession(db.FindScheduleSession(9))
                    .AddSession(db.FindScheduleSession(24))
                    .AddSession(db.FindScheduleSession(25))
                    .AddSession(db.FindScheduleSession(26))
                    .AddSession(db.FindScheduleSession(1))
                    );

           day1.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("4:30-6pm CST", "2:30-4pm PST", "10:30am-12pm UTC")
                    .AddSession(null)
                    .AddSession(db.FindScheduleSession(30))
                    .AddSession(db.FindScheduleSession(32))
                    .AddSession(db.FindScheduleSession(17))
                    .AddSession(db.FindScheduleSession(14))
                    .AddSession(db.FindScheduleSession(15))
                    );

           day1.TimeSlots.Add(
    new TimeSlot()
        .AddTime("6-7:30pm CST", "4-5:30pm PST", "12-1:30am UTC")
        .AddSession(null)
        .AddSession(db.FindScheduleSession(45))
        .AddSession(db.FindScheduleSession(58))
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
            day2.Rooms.Add(new Room() { JoinUrl = "/live", Name = "Room 6" });

            day2.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("9-10:30am CST", "7-8:30am PST", "3-4:30pm UTC")
                    .AddSession(db.FindScheduleSession(31))
                    .AddSession(db.FindScheduleSession(11))
                    .AddSession(db.FindScheduleSession(59))
                    .AddSession(db.FindScheduleSession(48))
                    .AddSession(null)
                    .AddSession(null)
                    );

            day2.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("10:30-12pm CST", "8:30-10am PST", "4:30-6pm UTC")
                    .AddSession(db.FindScheduleSession(42))
                    .AddSession(db.FindScheduleSession(51))
                    .AddSession(db.FindScheduleSession(52))
                    .AddSession(db.FindScheduleSession(38))
                    .AddSession(null)
                    .AddSession(null)
                    );
            day2.TimeSlots.Add(
                new TimeSlot()
                    .AddTime("12-1:30pm CST", "10-11:30am PST", "6-7:30pm UTC")
                    .AddSession(db.FindScheduleSession(33))
                    .AddSession(null)
                    .AddSession(db.FindScheduleSession(60))
                    .AddSession(null)
                    .AddSession(db.FindScheduleSession(20))
                    .AddSession(null)
                    );
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
                     .AddTime("3-4:30pm CST", "1-2:30pm PST", "9-10:30pm UTC")
                    .AddSession(db.FindScheduleSession(41))
                    .AddSession(db.FindScheduleSession(54))
                    .AddSession(db.FindScheduleSession(49))
                    .AddSession(db.FindScheduleSession(50))
                    .AddSession(db.FindScheduleSession(47))
                    .AddSession(db.FindScheduleSession(39))
                     );
            day2.TimeSlots.Add(
                 new TimeSlot()
                     .AddTime("4:30-6pm CST", "2:30-4pm PST", "10:30pm-12am UTC")
                    .AddSession(db.FindScheduleSession(40))
                    .AddSession(db.FindScheduleSession(54))
                    .AddSession(db.FindScheduleSession(43))
                    .AddSession(db.FindScheduleSession(46))
                    .AddSession(db.FindScheduleSession(61))
                    .AddSession(null)
                     );


            model.Days.Add(day2); 
            return View(model);
        }
    }
}