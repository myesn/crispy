namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyKeyValuePairResponse
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public CrispyKeyValueValueType ValueType { get; set; }
        public bool Enabled { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
