namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CrispyEnviromentUpdateContext
    {
        [Required(ErrorMessage = "环境 Id 为空")]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "环境名称为空")]
        [Range(1, 50, ErrorMessage = "环境名称长度应为  1 - 50")]
        public string Name { get; set; }
    }
}
