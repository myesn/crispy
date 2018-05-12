namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyKeyValuePair : CrispyEntityKey
    {
        public string Key { get; set; }
        public dynamic Value { get; set; }
        public string Description { get; set; }
        public CrispyKeyValueValueType ValueType { get; set; }
        public CrispyKeyValuePairApplyType ApplyType { get; set; }
        public bool Deleted { get; set; }
        public bool Enabled { get; set; }
        public byte[] Timestamp { get; set; }
        public Guid? OwnerdId { get; set; }

        public virtual CrispyEnvironment OwnerdEnviroment { get; set; }
        public virtual ICollection<CrispyKeyValuePairHistory> Histories { get; set; }
    }
}
