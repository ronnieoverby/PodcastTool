PodcastTool by Ronnie Overby
https://github.com/ronnieoverby/PodcastTool

Watch the demo: http://youtu.be/w6_M7vv77f8

Usage:
<command> Path [/SplitLength]

Path                  The path of the mp3 to split.
[/SplitLength|/S]     The duration in seconds that each split mp3 will be. The
                      default is 120.


The tool will
 - create a directory beside and named after the source mp3
 - split the source mp3 at defined interval, writing to the created directory
 - name each split mp3 with a four digit number before the file extension for proper file system sortability
 - transfer all ID3 data to the split mp3 files
 - replace the track # metadata for each split mp3 with the proper sequence number for mp3 players that sort by metadata and not filename