namespace aspConf.Model {
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class Session {
        public string Title { get; set; }
        public int SessionId { get; set; }
        public int SpeakerId { get; set; }
        public bool IsActive { get; set; }

        [UIHint("MultilineText")]
        public string Description { get; set; }

        public virtual Speaker Speaker { get; set; }
    }
}
