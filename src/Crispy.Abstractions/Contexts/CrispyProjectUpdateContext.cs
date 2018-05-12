namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CrispyProjectUpdateContext : CrispyProjectCreationContext
    {
        [Required(ErrorMessage = "项目 Id 为空")]
        public Guid Id { get; set; }
    }
}
