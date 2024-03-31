using System.Reflection;
using PersonalBests.Interfaces;

namespace PersonalBests.Client;

internal static class AppAssemblies
{
    public static Assembly?[] All
        =>
        [
            Assembly.GetEntryAssembly(),
            Assembly.GetAssembly(typeof(IScoreProvider)),
        ];
}
