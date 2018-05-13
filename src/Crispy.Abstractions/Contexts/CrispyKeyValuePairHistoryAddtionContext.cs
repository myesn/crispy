namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using ModelRules = CrispyConstants.ModelRules.KeyValuePairHistory;

    public class CrispyKeyValuePairHistoryAddtionContext
    {
        [Required(ErrorMessage = "配置的 Id 为空")]
        public Guid KeyValuePairId { get; set; }
        [Range(0, ModelRules.ValueMaxLength, ErrorMessage = "配置的 Value 长度应为 0 - 1280")]
        public string Value { get; set; }        
        public CrispyKeyValueValueType ValueType { get; set; }
    }
}
