﻿using System;

namespace ExcelMapper.Pipeline
{
    public class ParseAsEnum<TEnum> : PipelineItem<TEnum> where TEnum : struct
    {
        public override PipelineResult<TEnum> TryMap(PipelineResult<TEnum> item)
        {
            if (string.IsNullOrEmpty(item.StringValue))
            {
                return item.MakeEmpty();
            }

            if (!Enum.TryParse(item.StringValue, out TEnum result))
            {
                return item.MakeInvalid();
            }

            return item.MakeCompleted(result);
        }
    }
}
