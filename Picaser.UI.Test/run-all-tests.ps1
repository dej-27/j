Clear-Host
Add-Type -Path "C:\Program Files (x86)\Common Files\microsoft shared\Phone Tools\CoreCon\10.0\Bin\Microsoft.Smartdevice.Connectivity.dll"

#Add-Type -AssemblyName System
#$wp7_image = "`"C:\Program Files (x86)\Microsoft SDKs\Windows Phone\v7.0\Emulation\Images\WM70C1.en-US.unlocked.bin`" /VMID {E575DA31-FC47-4766-853F-018D823B9EE6}"
#start-process "C:\Program Files (x86)\Microsoft XDE\1.0\XDE.exe" $wp7_image  
#http://justinangel.net/WindowsPhone7EmulatorAutomation
##run all script
#foreach ($file in Get-Childitem *.sikuli)
#{
	#java -jar $Env:SIKULI_HOME\sikuli-script.jar $file.name
#}


#########################################################################
# Run emulator and install latest version of app
#########################################################################
$appName = "Picaser"
$appID = new-object System.Guid("a5304aaf-98e8-4c3f-a565-31bd79aba60a")
$mgr = new-object Microsoft.SmartDevice.Connectivity.DatastoreManager(1033)
$platform = $mgr.GetPlatforms()
#($platform[0]).getDevices()
$device = ($platform[0]).getDevices()[1]
$device.Connect()
if($device.IsApplicationInstalled($appID)){
	Write-Host "Uninstalling $appName from emulator..."
	$device.GetApplication($appID).Uninstall()
	Write-Host "$appName uninstalled."
}
Write-Host "Installing $appName to Emulator..."
$app = $device.InstallApplication($appID, $appID, "NormalApp", (Resolve-Path "..\$appName\Bin\Debug\ApplicationIcon.png"), (Resolve-Path "..\$appName\Bin\Debug\$appName.xap") )
Write-Host "$appName installed to Emulator"
Write-Host "Launching $appName..."
$app.Launch()