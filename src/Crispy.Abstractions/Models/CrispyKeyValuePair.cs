namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyKeyValuePair : CrispyEntityKey
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public CrispyKeyValueValueType ValueType { get; set; }
        public CrispyKeyValuePairApplyType ApplyType { get; set; }
        public bool Deleted { get; set; } = false;
        public bool Enabler { get; set; } = true;
        public byte[] Timestamp { get; set; }
        public Guid? EnvironmentId { get; set; }

        public virtual CrispyEnvironment Environment { get; set; }
        public virtual ICollection<CrispyKeyValuePairHistory> Histories { get; set; } = new List<CrispyKeyValuePairHistory>();
    }
}
