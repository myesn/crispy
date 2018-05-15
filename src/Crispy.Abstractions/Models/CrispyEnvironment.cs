namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyEnvironment : CrispyEntityKey
    {
        public CrispyEnvironment() { }
        public CrispyEnvironment(Guid applicationId,string name, CrispyEnviromentType type = CrispyEnviromentType.Basic)
        {

            this.ApplicatoinId = applicationId;
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; set; }
        public CrispyEnviromentType Type { get; set; }
        public bool IncludeGlobalConfig { get; set; } = false;
        public bool Encryption { get; set; } = false;
        public bool Enabler { get; set; } = true;
        public bool Deleted { get; set; } = false;
        public Guid ApplicatoinId { get; set; }

        public virtual CrispyApplication Application { get; set; }
        public virtual ICollection<CrispyKeyValuePair> KeyValuePairs { get; set; } = new List<CrispyKeyValuePair>();

    }
}
