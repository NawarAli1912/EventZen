using System.Reflection;

namespace EventZen.Modules.Events.Application;
public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
