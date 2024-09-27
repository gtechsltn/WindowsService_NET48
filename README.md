# Windows Service in .NET Framework 4.8

Scheduler in .NET (C#)

https://docs.google.com/document/d/14HVwuakWWFr_bCE5JcSiN8xM76-6y3fEWGsP32IrGas

Fluent in .NET (C#)

https://docs.google.com/document/d/1z5dk1jaOTWTSFqTWC68EnUFY0WhpBP5oe5ynJs9D7oY

Create A Windows Service In C#

https://www.c-sharpcorner.com/article/create-windows-services-in-c-sharp/

Creating a simple Windows Service

https://www.codeproject.com/Articles/106742/Creating-a-simple-Windows-Service

Simple Windows Service Sample

https://www.codeproject.com/Articles/3990/Simple-Windows-Service-Sample

Creating a Basic Windows Service in C#

https://www.codeproject.com/Articles/14353/Creating-a-Basic-Windows-Service-in-C

https://www.c-sharpcorner.com/UploadFile/8f2b4a/how-to-installuninstall-net-windows-service-C-Sharp/

## Install
```
cd "C:\Windows\Microsoft.NET\Framework64\v4.0.30319"
InstallUtil -i "D:\gtechsltn\WindowsService_NET48\zip\WindowsService.NET.exe"
```

## Uninstall
```
cd "C:\Windows\Microsoft.NET\Framework64\v4.0.30319"
InstallUtil -u "D:\gtechsltn\WindowsService_NET48\zip\WindowsService.NET.exe"
```

# Create a Windows Service in C# using Visual Studio

Quick tutorial explaining how to create and configure a custom Windows Service in C# with Visual Studio 2019

https://www.ryadel.com/en/create-windows-service-asp-net-c-sharp-how-to-tutorial-guide/

https://github.com/Darkseal/WindowsService.NET

https://github.com/gtechsltn/WindowsService.NET

## Two ways with a few considerations:

### Deploy as a Windows Service

For this, for simplicity sake, I'd recommend something like http://topshelf-project.com/ which will simplify the deployment process for you.

Once deployed, you should expect to see the service startup set to 'Automatic' given your requirements. No doubt you will need to configure topshelf prior to building your solution. So in the code for your service you can set a timer to regularly run whatever piece of functionality is it you want running. That said, given the fact you want this running regularly, I'd also seriously consider...

### Windows Task Scheduler

This will take care of the timing issue for you. There is no need to reinvent the wheel when it comes to scheduling the execution of your code, Windows has this built in for you.

https://www.digitalcitizen.life/how-create-task-basic-task-wizard/

# Windows Service in .NET Core

## Building a Windows Service Using C# and .NET Core

https://github.com/jonowilliams26/WindowsServiceDotNetCore

https://github.com/gtechsltn/WindowsServiceDotNetCore

https://www.youtube.com/watch?v=9QZwo21OgXk&ab_channel=JonoWilliams

## Running .NET Core Applications as a Windows Service

https://code-maze.com/aspnetcore-running-applications-as-windows-service/

## Building Windows Services in .NET 7

https://consultwithgriff.com/building-window-services-in-dotnet/

https://github.com/1kevgriff/WindowsServiceDotNetExample

https://github.com/gtechsltn/WindowsServiceDotNetExample
