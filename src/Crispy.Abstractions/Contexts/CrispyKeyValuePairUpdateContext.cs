namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using ModelRules = CrispyConstants.ModelRules.KeyValuePair;

    public class CrispyKeyValuePairUpdateContext
    {
        [Required(ErrorMessage = "配置项的 Id 为空")]
        public Guid Id { get; set; }

        //[Range(0, ModelRules.ValueMaxLength, ErrorMessage = "配置的 Value 长度应为 0 - 1280")]
        [MinLength(1, ErrorMessage = "配置的 Value 长度应大于 1 ")]
        [MaxLength(ModelRules.ValueMaxLength, ErrorMessage = "配置的 Value 长度应小于等于 1280")]
        public string Value { get; set; }

        public CrispyKeyValueValueType ValueType { get; set; }

        //[Range(0, ModelRules.DescriptionMaxLength, ErrorMessage = "配置的描述长度应为 1 - 100")]
        [MinLength(1, ErrorMessage = "配置的描述长度应大于 1 ")]
        [MaxLength(ModelRules.DescriptionMaxLength, ErrorMessage = "配置的描述长度应小于等于 1280")]
        public string Description { get; set; }

    }
}
