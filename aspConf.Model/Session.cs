namespace aspConf.Model {
    using System;

    [Serializable]
    public class Session {
        public string Title { get; set; }
        public int SessionId { get; set; }
        public int SpeakerId { get; set; }
        public string Description { get; set; }

        public virtual Speaker Speaker { get; set; }
    }
}
