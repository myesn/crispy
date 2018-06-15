namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using ModelRules = CrispyConstants.ModelRules.Environment;


    public class CrispyEnvironmentAddtionContext
    {
        [Required(ErrorMessage = "应用 Id 为空")]
        public Guid ApplicationId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "环境名称为空")]
        [MinLength(1, ErrorMessage = "环境名称长度应大于 1 ")]
        [MaxLength(ModelRules.NameMaxLength, ErrorMessage = "环境名称长度应小于等于 50")]
        public string Name { get; set; }
    }
}
