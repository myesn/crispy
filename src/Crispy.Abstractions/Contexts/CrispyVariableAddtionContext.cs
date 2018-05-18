namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using ModelRules = CrispyConstants.ModelRules.Variable;

    public class CrispyVariableAddtionContext
    {
        public Guid? ApplicationId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "变量名称为空")]
        //[Range(1, ModelRules.KeyMaxLength, ErrorMessage = "变量名称长度应为 1 - 50")]
        [MinLength(1, ErrorMessage = "变量名称长度应大于 1 ")]
        [MaxLength(ModelRules.KeyMaxLength, ErrorMessage = "变量名称长度应小于等于 50")]
        public string Key { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "变量值为空")]
        //[Range(1, ModelRules.ValueMaxLength, ErrorMessage = "变量值长度应为 1 - 1280")]
        [MinLength(1, ErrorMessage = "变量值长度应大于 1 ")]
        [MaxLength(ModelRules.KeyMaxLength, ErrorMessage = "变量值长度应小于等于 1280")]
        public string Value { get; set; }
    }
}