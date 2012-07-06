using System.Collections;
using System.Collections.Generic;
using aspConf.Model;

namespace aspConf.Controllers.Models
{
    public class ScheduleViewModel
    {
        public ScheduleViewModel()
        {
            Days = new List<ScheduleDay>();
        }

        public IList<ScheduleDay> Days { get; set; }
    }

    public class ScheduleDay
    {
        public ScheduleDay()
        {
            Rooms = new List<Room>();
            TimeSlots = new List<TimeSlot>();
        }

        public IList<Room> Rooms { get; set; }

        public IList<TimeSlot> TimeSlots { get; set; }

        public string Title { get; set; }
    }

    public class TimeSlot
    {
        public TimeSlot()
        {
            Times = new List<string>();
            Sessions = new List<ScheduleSession>();
        }

        public TimeSlot AddTime(string time)
        {
            Times.Add(time);
            return this;
        }
        public TimeSlot AddTime(params string[] times)
        {
            foreach (var time in times)
            {
                Times.Add(time);
            }

            return this;
        }

        public TimeSlot AddSession(ScheduleSession session)
        {
            Sessions.Add(session);
            return this;
        }
        public IList<string> Times { get; set; }

        public IList<ScheduleSession> Sessions { get; set; }

    }

    public class ScheduleSession
    {
        public string Url { get; set; }

        public string Title { get; set; }

        public string SpeakerName { get; set; }

        public string SpeakerRateId { get; set; }

        public bool IsKeynote { get; set; }
    }

    public static class ScheduleSessionExtensions
    {
        public static ScheduleSession FindScheduleSession(this ConfContext context, int id, bool isKeynote = false)
        {
            return context.Sessions.Find(id).AsScheduleSession(isKeynote);
        }
        public static ScheduleSession AsScheduleSession(this Session session, bool isKeynote = false)
        {

            return new ScheduleSession()
                       {
                           IsKeynote = isKeynote,
                           SpeakerName = session.Speaker.FullName,
                           Title = session.Title,
                           SpeakerRateId = "",
                           Url = "",
                       };
        }
    }

    public class Room
    {
        public string Name { get; set; }

        public string JoinUrl { get; set; }
    }
}