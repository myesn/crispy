namespace Crispy.Abstractions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyApplication : CrispyEntityKey
    {
        public CrispyApplication() { }
        public CrispyApplication(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public bool IncludeGlobalConfig { get; set; } = false;
        public bool Encryption { get; set; } = false;
        public bool Enabler { get; set; } = true;
        public bool Deleted { get; set; } = false;

        public virtual ICollection<CrispyEnvironment> Enviroments { get; set; } = new List<CrispyEnvironment>();
        public virtual ICollection<CrispyVariable> Variables { get; set; } = new List<CrispyVariable>();

    }
}
