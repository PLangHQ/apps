Script: *set-volume.ps1*
========================

This PowerShell script sets the audio volume to the given value in percent (0..100).

Parameters
----------
```powershell
PS> ./set-volume.ps1 [-percent] <Int32> [<CommonParameters>]

-percent <Int32>
    Specifies the volume in percent (0..100)
    
    Required?                    true
    Position?                    1
    Default value                0
    Accept pipeline input?       false
    Accept wildcard characters?  false

[<CommonParameters>]
    This script supports the common parameters: Verbose, Debug, ErrorAction, ErrorVariable, WarningAction, 
    WarningVariable, OutBuffer, PipelineVariable, and OutVariable.
```

Example
-------
```powershell
PS> ./set-volume.ps1 50

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
	Sets the audio volume 
.DESCRIPTION
	This PowerShell script sets the audio volume to the given value in percent (0..100).
.PARAMETER percent
	Specifies the volume in percent (0..100)
.EXAMPLE
	PS> ./set-volume.ps1 50
.LINK
	https://github.com/fleschutz/PowerShell
.NOTES
	Author: Markus Fleschutz | License: CC0
#>

Param([Parameter(Mandatory=$true)] [ValidateRange(0,100)] [Int] $percent)

try {
	# Create the Windows Shell object. 
	$obj = New-Object -ComObject WScript.Shell
    
	# First, set volume to zero. 
	for ([int]$i = 0; $i -lt 100; $i += 2) {
		$obj.SendKeys([char]174) # each tick is -2%
	}
    
	# Raise volume to specified level. 
	for ([int]$i = 0; $i -lt $percent; $i += 2) {
		$obj.SendKeys([char]175) # each tick is +2%
	}
	exit 0 # success
} catch {
	"⚠️ Error in line $($_.InvocationInfo.ScriptLineNumber): $($Error[0])"
	exit 1
}
```

*(generated by convert-ps2md.ps1 using the comment-based help of set-volume.ps1 as of 01/25/2024 13:58:42)*