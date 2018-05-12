namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyKeyValuePairHistory : CrispyEntityKey
    {
        public dynamic Value { get; set; }
        public CrispyKeyValueValueType ValueType { get; set; }
        public Guid KeyValuePairId { get; set; }

        public virtual CrispyKeyValuePair KeyValuePair { get; set; }
        
    }
}
