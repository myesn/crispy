namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using ModelRules = CrispyConstants.ModelRules.Variable;

    public class CrispyVariableUpdateContext
    {
        [Required(ErrorMessage = "变量 Id 为空")]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "变量值为空")]
        [Range(1, ModelRules.ValueMaxLength, ErrorMessage = "变量值长度应为 1 - 1280")]
        public string Value { get; set; }
    }
}