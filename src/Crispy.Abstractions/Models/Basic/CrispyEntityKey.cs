namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyEntityKey : CrispyDateTimeCreated
    {
        public Guid Id { get; set; }
    }
}
