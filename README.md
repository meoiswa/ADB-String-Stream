ADB-String-Stream
=================

A C# GUI for sending strings to android devices using adb

Initial setup for USB mode:

  1. Enable Developer in your Android device
  2. Enable USB Debugger in the Developer options of your Android device
  3. Connect your Android device via USB to your computer
  4. Excecute ADBStringStream.exe


Initial setup for TCP/IP mode:

  Rooted Device:
    1. Execute the following shell commands in your Android device
    su
    setprop service.adb.tcp.port 5555
    stop adbd
    start adbd
    
    Source: http://stackoverflow.com/questions/2604727/how-can-i-connect-to-android-with-adb-over-tcp
    
    2. Excecute ADBStringStream.exe
    3. Type your Android Device IP address in the Device IP Textbox
    4. Click Connect.
    
  Non-Rooted Device:
    <TODO>
