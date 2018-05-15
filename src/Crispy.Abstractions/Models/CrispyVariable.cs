namespace Crispy.Abstractions
{
    using System;

    public class CrispyVariable : CrispyEntityKey
    {
        public CrispyVariable() { }
        public CrispyVariable(Guid? applicationId, string key, string value)
        {
            this.ApplicationId = applicationId;
            this.Key = key;
            this.Value = value;
        }
        
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Deleted { get; set; } = false;
        public bool Enabler { get; set; } = true;
        public Guid? ApplicationId { get; set; }

        public virtual CrispyApplication Application { get; set; }
    }
}