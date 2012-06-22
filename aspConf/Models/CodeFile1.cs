using System;
using System.Collections.Generic;
using System.Data.Entity;

[Serializable]
public class Sponsor {
    public string Bio { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }
    public string ImageName { get; set; }
    public int SponsorId { get; set; }
    public int? LevelId { get; set; }
}

[Serializable]
public class Speaker {
    public string FullName { get; set; }
    public string Bio { get; set; }
    public string Twitter { get; set; }
    public string Email { get; set; }
    public int SpeakerId { get; set; }

    public virtual ICollection<Session> Sessions { get; set; }
}

[Serializable]
public class Session {
    public string Title { get; set; }
    public int SessionId { get; set; }
    public int SpeakerId { get; set; }
    public string Description { get; set; }

    public virtual Speaker Speaker { get; set; }
}

public class ConfContext : DbContext {
    public DbSet<Sponsor> Sponsors { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Session> Sessions { get; set; }
}

