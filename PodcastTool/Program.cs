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
            string mp3Path = args[0];
            if (!File.Exists(mp3Path)) return;
                        
            const int splitLength = 120; // seconds
                        
            TagLib.Tag id3;
            using (var tagFile = TagLib.File.Create(mp3Path)) id3 = tagFile.Tag;

            var mp3Dir = Path.GetDirectoryName(mp3Path);
            var mp3File = Path.GetFileName(mp3Path);
            var splitDir = Path.Combine(mp3Dir, Path.GetFileNameWithoutExtension(mp3Path));
            Directory.CreateDirectory(splitDir);

            Console.WriteLine(mp3File);

            int splitI = 0;
            int secsOffset = 0;
            string splitFilePath = null;

            using (var reader = new Mp3FileReader(mp3Path))
            {
                FileStream writer = null;
                var createWriter = new Action(() =>
                {
                    splitFilePath = Path.Combine(splitDir, Path.ChangeExtension(mp3File, (++splitI).ToString("D4") + ".mp3"));
                    writer = File.Create(splitFilePath);
                });

                var copyId3 = new Action(() =>
                {
                    using (var tagFile = TagLib.File.Create(splitFilePath))
                    {
                        id3.CopyTo(tagFile.Tag, true);
                        tagFile.Tag.Track = (uint)splitI;
                        tagFile.Save();
                    }
                });

                var showProgress = new Action(() => 
                {
                    Console.WriteLine("{0}) {1}", splitI, Path.GetFileName(splitFilePath));
                });

                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    if (writer == null) createWriter();

                    if ((int)reader.CurrentTime.TotalSeconds - secsOffset >= splitLength)
                    {
                        // time for a new file
                        writer.Dispose();
                        copyId3();
                        showProgress();
                        createWriter();
                        secsOffset = (int)reader.CurrentTime.TotalSeconds;
                    }

                    writer.Write(frame.RawData, 0, frame.RawData.Length);
                }

                if (writer != null)
                {
                    writer.Dispose();
                    copyId3();
                    showProgress();
                }
            }
        }
    }
}
