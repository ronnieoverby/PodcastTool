using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NAudio.Wave;

namespace PodcastTool
{
    class Program
    {
        static void Main(string[] args)
        {            
            // check for passed in argument
            if (args == null || !args.Any()) return;

            // check file exists
            string filePath = args[0];
            if (!File.Exists(filePath)) return;

        
        }
    }
}
