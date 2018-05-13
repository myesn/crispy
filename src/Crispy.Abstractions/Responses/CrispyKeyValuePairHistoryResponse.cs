namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyKeyValuePairHistoryResponse
    {
        public string Value { get; set; }
        public CrispyKeyValueValueType ValueType { get; set; }
    }
}
