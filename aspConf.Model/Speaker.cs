namespace aspConf.Model {

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class Speaker {
        public string FullName { get; set; }

        [UIHint("MultilineText")]
        public string Bio { get; set; }
        public string Twitter { get; set; }
        public string Email { get; set; }
        public int SpeakerId { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
