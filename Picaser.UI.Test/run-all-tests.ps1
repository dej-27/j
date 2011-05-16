Clear-Host
$wp7_image = "`"C:\Program Files (x86)\Microsoft SDKs\Windows Phone\v7.0\Emulation\Images\WM70C1.en-US.unlocked.bin`" /VMID {E575DA31-FC47-4766-853F-018D823B9EE6}"
start-process "C:\Program Files (x86)\Microsoft XDE\1.0\XDE.exe" $wp7_image  
#http://justinangel.net/WindowsPhone7EmulatorAutomation


##run all script
#foreach ($file in Get-Childitem *.sikuli)
#{
	#java -jar $Env:SIKULI_HOME\sikuli-script.jar $file.name
#}

