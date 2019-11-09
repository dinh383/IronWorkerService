# IronWorkerService
Testing Worker service in net core
We generate a Worker Service to research its feature in net core 3.0

1. A worker service is a service that runs in background.
2. A worker service is cross-platform can run on different operating systems.
3. All background service in dot net core inherits of BackgroundService class and this class implement IHostedService
4. Depending on where your background service runs you need to install a package to specify the host. For example, if your background service runs in Windows you need to install: Microsoft.Extensions.Hosting.WindowsServices (NuGet Package)
5. To install a Windows service, you have to open a PowerShell as Administrator: >sc.exe create WINDOWS_SERVICE_NAME binpath= EXE_PATH start= START_TYPE
6. To delete a Windows service, you have to open a PowerShell as Administrator: >sc.exe delete WINDOWS_SERVICE_NAME

To more information visit: https://fmoralesdev.com/
