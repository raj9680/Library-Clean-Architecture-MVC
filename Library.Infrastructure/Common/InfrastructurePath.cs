namespace Library.Infrastructure.Common
{
    public static class InfrastructurePath
    {
        public static string Data(params string[] paths)
        {
            string solutionRoot = Directory.GetParent(AppContext.BaseDirectory)!
                .Parent!.Parent!.Parent!.Parent!.FullName;

            return Path.Combine(
                solutionRoot,
                "Library.Infrastructure",
                "Data",
                Path.Combine(paths));
        }
    }
}
