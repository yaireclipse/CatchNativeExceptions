# CatchNativeExceptions

Demonstrates how native exceptions are not caught by managed C# .NET Core code, on Linux. Tested on CentOS and Ubuntu.

## How To Run The Test:

1.  `git clone git@github.com:yaireclipse/CatchNativeExceptions.git`;
2.  Open `CatchNativeExceptions.sln` with Visual Studio 2017;
3.  Connect VS to the Linux machine via `Tools`->`Options`->`Cross Platform`->`Connection Manager`;
4.  Build solution via `Build`->`Build Solution`;
5.  Publish `NativeExceptionsCatcher` via `Build`->`Publish NativeExceptionsCatcher`;
6.  Move the published files to a folder on the Linux machine (if not there already);
7.  Go to that folder and run `dotnet NativeExceptionsCatcher.dll`.

## Expected Result:

The exception thrown by the native library is caught by the `try..catch` in the managed code, which causes a `Managed: successfully caught native exception...` to be printed to console.

## Actual Result:

The expected message is NOT printed (which means the native exception isn't caught by the `try..catch` in the managed code).
