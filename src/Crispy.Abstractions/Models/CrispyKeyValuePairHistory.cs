namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyKeyValuePairHistory : CrispyEntityKey
    {
        public CrispyKeyValuePairHistory() { }
        public CrispyKeyValuePairHistory(Guid keyValuePairId, string value, CrispyKeyValueValueType valueType)
        {
            this.KeyValuePairId = keyValuePairId;
            this.Value = value;
            this.ValueType = valueType;
        }

        public string Value { get; set; }
        public CrispyKeyValueValueType ValueType { get; set; }
        public Guid KeyValuePairId { get; set; }

        public virtual CrispyKeyValuePair KeyValuePair { get; set; }

    }
}
