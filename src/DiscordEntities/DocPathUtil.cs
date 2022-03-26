using System.Runtime.CompilerServices;

namespace DiscordEntities;

internal static class DocPathUtil

{
    public static string GetDiscordSubmoduleDir()
    {
        var workingDir = GetWorkingDir();
        var solutionDir = GetSolutionDir(workingDir);
        var submoduleDir = GetSubmoduleDir(solutionDir);
        var discordSubmoduleDir = GetDiscordSubmoduleDir(submoduleDir);
        ThrowIfNotExist(discordSubmoduleDir);
        return discordSubmoduleDir;
    }

    public static void ThrowIfNotExist(string path)
    {
        if (!Directory.Exists(path))
        {
            throw new DirectoryNotFoundException(path);
        }
    }

    public static string GetWorkingDir()
    {
        var workingDir = Environment.CurrentDirectory;
        ThrowIfNotExist(workingDir);
        return workingDir;
    }

    public static string GetSolutionDir(string workingDirectory)
    {
        string solutionDir;
        try
        {
            solutionDir = Directory.GetParent(workingDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
        }
        catch (NullReferenceException e)
        {
            throw new DirectoryNotFoundException($"Could not find relative solution dir of: {workingDirectory}");
        }

        ThrowIfNotExist(solutionDir);
        return solutionDir;
    }

    public static string GetSubmoduleDir(string solutionDir)
    {
        var submoduleDir = Path.Combine(solutionDir, "submodules");
        ThrowIfNotExist(submoduleDir);
        return submoduleDir;
    }

    public static string GetDiscordSubmoduleDir(string submoduleDir)
    {
        var discordSubmoduleDir = Path.Combine(submoduleDir, "discord-api-docs");
        ThrowIfNotExist(submoduleDir);
        return discordSubmoduleDir;
    }

    public static string GetDiscordDocsDir(string discordSubmoduleDir)
    {
        var docs = Path.Combine(discordSubmoduleDir, "docs");
        ThrowIfNotExist(docs);
        return docs;
    }

    public static string GetDiscordDocResourcesDir(string discordDocsDir)
    {
        var resources = Path.Combine(discordDocsDir, "resources");
        ThrowIfNotExist(resources);
        return resources;
    }
}