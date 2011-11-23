<Query Kind="Statements">
  <Reference>&lt;ProgramFiles&gt;\Microsoft\ILMerge\ILMerge.exe</Reference>
  <GACReference>System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</GACReference>
</Query>

var ilm = new ILMerging.ILMerge();
ilm.OutputFile = @"C:\Users\ronnie\Desktop\PodcastTool.exe";
ilm.SetInputAssemblies(new[]{
	@"C:\Users\ronnie\Dropbox\Code\PodcastTool\PodcastTool\bin\Release\PodcastTool.exe",
	@"C:\Users\ronnie\Dropbox\Code\PodcastTool\PodcastTool\bin\Release\NAudio.dll",
	@"C:\Users\ronnie\Dropbox\Code\PodcastTool\PodcastTool\bin\Release\taglib-sharp.dll"
});
ilm.SetTargetPlatform("4",@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\");
ilm.DebugInfo = false;
ilm.Merge();