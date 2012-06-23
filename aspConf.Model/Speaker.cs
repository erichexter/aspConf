namespace aspConf.Model {

    using System;
    using System.Collections.Generic;

    [Serializable]
    public class Speaker {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Twitter { get; set; }
        public string Email { get; set; }
        public int SpeakerId { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
