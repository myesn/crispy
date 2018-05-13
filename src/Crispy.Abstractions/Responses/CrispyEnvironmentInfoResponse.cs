namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyEnvironmentInfoResponse
    {
        public CrispyEnvironmentInfoResponse(){}
        public CrispyEnvironmentInfoResponse(CrispyEnvironment environment)
        {
            this.Id = environment.Id;
            this.Name = environment.Name;
            this.IncludeGlobalConfig = environment.IncludeGlobalConfig;
            this.Encryption = environment.Encryption;
            this.Enabler = environment.Enabler;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IncludeGlobalConfig { get; set; }
        public bool Encryption { get; set; }
        public bool Enabler { get; set; }
    }
}
