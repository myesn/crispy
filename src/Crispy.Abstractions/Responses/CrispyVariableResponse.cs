namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyVariableResponse
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Deleted { get; set; }
        public bool Enabler { get; set; }
    }
}