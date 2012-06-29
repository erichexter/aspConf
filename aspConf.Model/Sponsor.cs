namespace aspConf.Model {
    using System;

    [Serializable]
    public class Sponsor {
        public string Bio { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int SponsorId { get; set; }
        public int? LevelId { get; set; }
        public bool IsActive { get; set; }
    }
}
