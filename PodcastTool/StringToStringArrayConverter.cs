using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Args;
using System.ComponentModel;
using System.Globalization;

namespace PodcastTool
{
    class StringToStringArrayConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string source = value as string;

            if (string.IsNullOrWhiteSpace(source))
                return new string[0];

            return source.Split(",;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}
