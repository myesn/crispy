namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CrispyProjectCreationContext
    {
        [Required(ErrorMessage = "项目名称为空")]
        [Range(1, 5, ErrorMessage = "项目名称长度应为 1 - 50")]
        public string Name { get; set; }
    }
}
