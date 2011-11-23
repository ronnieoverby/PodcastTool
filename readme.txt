Watch the demo: http://youtu.be/w6_M7vv77f8

PodcastTool.exe accepts single argument: the path to an MP3 file.

The tool will
 - create a directory beside and named after the source mp3
 - split the source mp3 at every 2 minute interval, writing to the created directory
 - name each split mp3 with a four digit number before the file extension for proper file system sortability
 - transfer all ID3 data to the split mp3 files
 - replace the track # metadata for each split mp3 with the proper sequence number for mp3 players that sort by metadata and not filename