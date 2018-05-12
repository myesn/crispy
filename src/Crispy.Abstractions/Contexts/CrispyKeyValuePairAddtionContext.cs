namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CrispyKeyValuePairAddtionContext
    {
        public Guid? OwnerdId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "配置的 Key 为空")]
        [Range(1, 50, ErrorMessage = "配置的 Key 长度应为 1 - 50")]
        public string Key { get; set; }
        public dynamic Value { get; set; }
        public CrispyKeyValueValueType ValueType { get; set; }
        [Range(0, 100, ErrorMessage = "配置的描述长度应为 1 - 100")]
        public string Description { get; set; }
    }
}
