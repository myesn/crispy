namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyKeyValuePairHistoryResponse
    {
        public CrispyKeyValuePairHistoryResponse() { }
        public CrispyKeyValuePairHistoryResponse(string value, CrispyKeyValueValueType valueType, DateTime dateTimeCreated)
        {
            this.Value = value;
            this.ValueType = valueType;
            this.DateTimeCreated = dateTimeCreated.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public string Value { get; set; }
        public CrispyKeyValueValueType ValueType { get; set; }
        public string DateTimeCreated { get; set; }
    }
}
