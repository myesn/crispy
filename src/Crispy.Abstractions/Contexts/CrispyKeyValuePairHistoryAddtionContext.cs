namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CrispyKeyValuePairHistoryAddtionContext
    {
        [Required(ErrorMessage = "配置的 Id 为空")]
        public Guid KeyValuePairId { get; set; }
        public dynamic Value { get; set; }        
        public CrispyKeyValueValueType ValueType { get; set; }
    }
}
