namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyProjectInfoResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IncludeGlobalConfig { get; set; }
        public bool Encryption { get; set; }
        public bool Enabler { get; set; }
        public Tuple<Guid, string> Enviroments { get; set; }
    }
}
