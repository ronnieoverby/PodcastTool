using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Args;
using System.ComponentModel;
using System.Globalization;

namespace PodcastTool
{
    [Description("PodcastTool by Ronnie Overby\r\nhttps://github.com/ronnieoverby/PodcastTool")]
    class Options
    {
        //[Description("The path(s) of the mp3s to split. Seperate multiple paths with commas or semicolons (, or ;);")]
        //[TypeConverter(typeof(StringToStringArrayConverter))]
        [ArgsMemberSwitch(0)]
        [Description("The path of the mp3 to split.")]
        public string Path { get; set; }

        [Description("The duration in seconds that each split mp3 will be. The default is 120.")]
        [DefaultValue(120)]
        public int SplitLength { get; set; }
    }
}