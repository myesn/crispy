namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using ModelRules = CrispyConstants.ModelRules.Environment;

    public class CrispyEnvironmentUpdateContext
    {
        [Required(ErrorMessage = "环境 Id 为空")]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "环境名称为空")]
        [Range(1, ModelRules.NameMaxLength, ErrorMessage = "环境名称长度应为  1 - 50")]
        public string Name { get; set; }
    }
}
