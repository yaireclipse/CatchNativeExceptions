using System;

namespace NativeExceptionsCatcher
{
  class Program
  {
    [System.Security.SecurityCritical]
    [System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptions]
    static void Main(string[] args)
    {
      try
      {
        // Toggle any of the following NativeMethods invocation to choose which to test

        //Console.WriteLine("Managed: calling NativeMethods.throw_runtime_exception()");
        //NativeMethods.throw_runtime_exception();

        //Console.WriteLine("Managed: calling NativeMethods.throw_access_violation_exception()");
        //NativeMethods.throw_access_violation_exception();

        Console.WriteLine("Managed: calling NativeMethods.throw_floating_point_exception()");
        NativeMethods.throw_floating_point_exception();
      }
      catch (System.Runtime.CompilerServices.RuntimeWrappedException)
      {
        Console.WriteLine("Managed: successfully caught native exception as RuntimeWrappedException!");
        Environment.Exit(1);
      }
      catch (Exception e)
      {
        Console.WriteLine("Managed: successfully caught native exception as general Exception!");
        Console.WriteLine($"Managed: Exception: {e.Message}");
        if (e.InnerException != null)
        {
          Console.WriteLine($"Managed: inner exception: {e.InnerException.Message}");
        }
        Environment.Exit(1);
      }
      catch
      {
        Console.WriteLine("Managed: successfully caught native exception in parameter-less catch!");
        Environment.Exit(1);
      }
    }
  }
}
