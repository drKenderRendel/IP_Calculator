<H1>How to run on Windows</H1>
<hr>
<p>Open the ".SLN" project via Visual Studio and run it.</p>
<p><i>I have used .NET Core 9 in my implementation, so using it to build the project is most advised.</i></p>

<H1>How to run on Linux</H1>
<hr>
<p>Download the dotnet SDK using the instructions at https://learn.microsoft.com/en-us/dotnet/core/install/ <i>(I recommend using .NET Core 9)</i></p>
<p>Build the project using <code>dotnet build IP_Calculator.sln</code></p>
<p>Run <code>cd IP_Calculator/bin/debug/net9.0/ && ./IP_Calculator</code> </p>
<p><i>If you don't have <code>net9.0</code> use the path relevant to the .NET version you're using.</i></p>
