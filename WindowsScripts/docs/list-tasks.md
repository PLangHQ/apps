Script: *list-tasks.ps1*
========================

list-tasks.ps1 


Parameters
----------
```powershell


[<CommonParameters>]
    This script supports the common parameters: Verbose, Debug, ErrorAction, ErrorVariable, WarningAction, 
    WarningVariable, OutBuffer, PipelineVariable, and OutVariable.
```

Script Content
--------------
```powershell
<#
.SYNOPSIS
	Lists all scheduled tasks
.DESCRIPTION
	This PowerShell script lists all scheduled tasks.
.EXAMPLE
	PS> ./list-tasks.ps1

	TaskName                            State  TaskPath                                       
	--------                            -----  --------
	.NET Framework NGEN v4.0.30319      Ready  \Microsoft\Windows\.NET Framework\             
	...
.LINK
	https://github.com/fleschutz/PowerShell
.NOTES
	Author: Markus Fleschutz | License: CC0
#>

try {
	Get-ScheduledTask | Format-Table -property TaskName,State,TaskPath
	exit 0 # success
} catch {
	"⚠️ Error in line $($_.InvocationInfo.ScriptLineNumber): $($Error[0])"
	exit 1
}
```

*(generated by convert-ps2md.ps1 using the comment-based help of list-tasks.ps1 as of 01/25/2024 13:58:39)*