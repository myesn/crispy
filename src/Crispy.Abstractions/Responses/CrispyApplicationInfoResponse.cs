namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyApplicationInfoResponse
    {
        public CrispyApplicationInfoResponse() { }
        public CrispyApplicationInfoResponse(CrispyApplication application)
        {
            this.Id = application.Id;
            this.Name = application.Name;
            this.IncludeGlobalConfig = application.IncludeGlobalConfig;
            this.Encryption = application.Encryption;
            this.Enabler = application.Enabler;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IncludeGlobalConfig { get; set; }
        public bool Encryption { get; set; }
        public bool Enabler { get; set; }
        public IEnumerable<ValueTuple<Guid, string>> Environments { get; set; } = new List<ValueTuple<Guid, string>>();
    }
}
