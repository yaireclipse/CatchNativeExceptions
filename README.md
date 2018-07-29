# CatchNativeExceptions

Demonstrates how native exceptions are not caught by managed C# code, on CentOS.

## Steps to Reproduce:

1.  `git clone git@github.com:yaireclipse/CatchNativeExceptions.git`;
2.  Open `CatchNativeExceptions.sln` with Visual Studio 2017;
3.  Prepare a CentOS machine, either a real one, a VM or a docker (I used Docker On Windows). This machine should have SSH server listening on the port of your choice, and a user & (optional) password so that VS can SSH and compile sources. Later, this machine could also be used to actually run the application (either by deploying the output files to the CentOS machine, or by mapping the Windows file-system drive on which the repository was cloned - e.g. `C` - to a folder on the CentOS machine - e.g. /mnt/c`);
4.  Add a remote connection to the CentOS machine via `Tools`->`Options`->`Cross Platform`->`Connection Manager`;
5.  From VS, choose `Release` configuration and `Build` the solution;
6.  From VS, still on `Release` configuration, `Publish` the `NativeExceptionsCatcher` project. The default parameters of the `Publish` are fine:
    1.  `Target Location` - `bin\Release\PublishOutput`;
    2.  `Configuration` - `Release`;
    3.  `Target Framework` - `netcoreapp2.0`;
    4.  `Target Runtime` - `Portable`.
7.  SSH into the CentOS machine, go to the folder in which the output files were deployed; or if the Windows file-system drive was mapped to a folder on CentOS, go to the publish folder. There, run the command `dotnet NativeExceptionsCatcher.dll`.

## Expected Result:

The exception thrown by the native library is caught by the `try..catch` in the managed code, which causes a `Managed: successfully caught native exception...` to be printed to console.

## Actual Result:

The expected message is NOT printed (which means the native exception isn't caught by the `try..catch` in the managed code).
