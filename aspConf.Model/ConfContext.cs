namespace aspConf.Model {
    using System.Data.Entity;

    public class ConfContext : DbContext {
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
