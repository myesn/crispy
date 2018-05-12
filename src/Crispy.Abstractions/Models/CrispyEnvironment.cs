namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyEnvironment : CrispyEntityKey
    {
        public string Name { get; set; }
        public CrispyEnviromentType Type { get; set; }
        public bool IncludeGlobalConfig { get; set; }
        public bool Encrypt { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public Guid ProjectId { get; set; }

        public virtual CrispyProject Project { get; set; }
        public virtual ICollection<CrispyKeyValuePair> KeyValuePairs { get; set; }

    }
}
