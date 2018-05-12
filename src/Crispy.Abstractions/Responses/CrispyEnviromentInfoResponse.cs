namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyEnviromentInfoResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IncludeGlobalConfig { get; set; }
        public bool Encrypt { get; set; }
        public bool Enabled { get; set; }
    }
}
