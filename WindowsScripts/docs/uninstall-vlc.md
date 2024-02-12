Script: *uninstall-vlc.ps1*
========================

This PowerShell script uninstalls the VLC media player from the local computer.

Parameters
----------
```powershell
PS> ./uninstall-vlc.ps1 [<CommonParameters>]

[<CommonParameters>]
    This script supports the common parameters: Verbose, Debug, ErrorAction, ErrorVariable, WarningAction, 
    WarningVariable, OutBuffer, PipelineVariable, and OutVariable.
```

Example
-------
```powershell
PS> ./uninstall-vlc.ps1
⏳ Uninstalling VLC media player...
✔️ Removal of VLC media player took 7 sec

```

Notes
-----
Author: Markus Fleschutz | License: CC0

Related Links
-------------
https://github.com/fleschutz/PowerShell

Script Content
--------------
```powershell
<#
.SYNOPSIS
	Uninstalls VLC
.DESCRIPTION
	This PowerShell script uninstalls the VLC media player from the local computer.
.EXAMPLE
	PS> ./uninstall-vlc.ps1
	⏳ Uninstalling VLC media player...
	✔️ Removal of VLC media player took 7 sec
.LINK
	https://github.com/fleschutz/PowerShell
.NOTES
	Author: Markus Fleschutz | License: CC0
#>

try {
	"⏳ Uninstalling VLC media player..."
	$StopWatch = [system.diagnostics.stopwatch]::startNew()

	& winget uninstall --id XPDM1ZW6815MQM
	if ($lastExitCode -ne "0") { throw "Can't uninstall VLC media player, is it installed?" }

	[int]$Elapsed = $StopWatch.Elapsed.TotalSeconds
	"✔️ Removal of VLC media player took $Elapsed sec"
	exit 0 # success
} catch {
	"Sorry: $($Error[0])"
	exit 1
}
```

*(generated by convert-ps2md.ps1 using the comment-based help of uninstall-vlc.ps1 as of 01/25/2024 13:58:43)*