namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using ModelRules = CrispyConstants.ModelRules.Application;

    public class CrispyApplicationCreationContext
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "项目名称为空")]
        [MinLength(1, ErrorMessage = "项目名称长度应大于 1 ")]
        [MaxLength(ModelRules.NameMaxLength, ErrorMessage = "项目名称长度应小于等于 50")]
        public string Name { get; set; }
    }
}
