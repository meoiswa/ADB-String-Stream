ADB-String-Stream
=================

A Windows Forms C# GUI for sending strings to android devices using adb.exe

It allows sending text written using a computer keyboard into an active text field selected in the Android Device
Examples of use are replying to messages in any app quickly or pasting complex URLs

This program consists of System.Process calls to a copy of adb.exe inside the same working directory.
adb.exe, and it's corresponding dlls, can be retrieved using the Android SDK tools.

This program is intended for users with experience in Android development, and therefore no binaries are provided and must be compiled by the end user.

It was compiled and tested successfully in Visual Studio 2013, .Net framework 4.5 and Windows 8.1

Known Bugs:
  -Parenthesis will break the syntax and cause the string to not arrive at the Android Device.

#Initial setup#

##USB Mode##

  1. Enable Developer in your Android device
  2. Enable USB Debugger in the Developer options of your Android device

##TCP/IP mode (Rooted devices)##

Execute the following shell commands in your Android device
 
    su
    setprop service.adb.tcp.port 5555
    stop adbd
    start adbd

##TCP/IP Mode (Non-Rooted Devices)##
If you already have a valid USB connection, excecute the following commands using the windows shell inside the ADBStringStream directory, replacing [device-ip] with your Android Device's IP:

    adb.exe tcpip 5555
    adb.exe connect [device-ip]:5555
  
Afterwards you can plug off your phone

[Source](http://stackoverflow.com/questions/2604727/how-can-i-connect-to-android-with-adb-over-tcp "Here")

#Usage#

##USB Mode##
  1. Plug your Android device via USB to your computer
     (TCP/IP Mode) Connect your Android device to your LAN
  2. Excecute ADBStringStream.exe
  3. Write the string to type in the textbox
  4. Click Send to write it on the Android Device, and send a [Enter] keyevent

##TCP/IP Mode##
  1. Connect your Android Device and Computer to the same LAN
  2. Execute ADBStringStream.exe
  3. Write the Android Device's IP in the "Device IP" Textbox and hit Connect
  4. Write the string to type in the textbox
  5. Click Send to write it on the Android Device, and send a [Enter] keyevent
