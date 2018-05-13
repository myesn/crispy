namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyApplicationPageResponse
    {
        public CrispyApplicationPageResponse(){}
        public CrispyApplicationPageResponse(Guid id , string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
