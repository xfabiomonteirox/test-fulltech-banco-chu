using System.Reflection;

namespace BancoChu.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
