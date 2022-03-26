using System.IO;
using Xunit;


namespace DiscordEntities.Tests;


public class DocPathUtilTests
{
    [Fact]
    public void ThrowsWhenDoesNotExist()
    {
        Assert.Throws<DirectoryNotFoundException>(
            () => DocPathUtil.ThrowIfNotExist("doesnotexist:)"));
    }

    [Fact]
    public void WorkingDir_DoesNotThrow()
    {
       var workingDir = DocPathUtil.GetWorkingDir();
       Assert.False(string.IsNullOrEmpty(workingDir));
       
    }
    
    [Fact]
    public void SolutionDir_DoesNotThrow()
    {
       var workingDir = DocPathUtil.GetWorkingDir();
       var solutionDir = DocPathUtil.GetSolutionDir(workingDir);
       Assert.False(string.IsNullOrEmpty(solutionDir));
       
    }
    
    [Fact]
    public void SolutionDir_DoesThrow()
    {
       Assert.Throws<DirectoryNotFoundException>(
           () => DocPathUtil.GetSolutionDir("\\doesnotexist"));
    }
    
     
    [Fact]
    public void SubmoduleDir_DoesNotThrow()
    {
       var workingDir = DocPathUtil.GetWorkingDir();
       var solutionDir = DocPathUtil.GetSolutionDir(workingDir);
       var submoduleDir = DocPathUtil.GetSubmoduleDir(solutionDir);
       Assert.False(string.IsNullOrEmpty(submoduleDir));
    }
    
    [Fact]
    public void SubmoduleDir_DoesThrow()
    {
       Assert.Throws<DirectoryNotFoundException>(
           () => DocPathUtil.GetSubmoduleDir("\\doesnotexist"));
    }
    
     
    [Fact]
    public void DiscordSubmoduleDir_DoesNotThrow()
    {
       var workingDir = DocPathUtil.GetWorkingDir();
       var solutionDir = DocPathUtil.GetSolutionDir(workingDir);
       var submoduleDir = DocPathUtil.GetSubmoduleDir(solutionDir);
       var discordSubmoduleDir = DocPathUtil.GetDiscordSubmoduleDir(submoduleDir);
       Assert.False(string.IsNullOrEmpty(discordSubmoduleDir));
    }
    
    [Fact]
    public void DiscordSubmoduleDir_DoesThrow()
    {
       Assert.Throws<DirectoryNotFoundException>(
           () => DocPathUtil.GetDiscordSubmoduleDir("\\doesnotexist"));
    }
    
     
    [Fact]
    public void DiscordDocsDir_DoesNotThrow()
    {
       var workingDir = DocPathUtil.GetWorkingDir();
       var solutionDir = DocPathUtil.GetSolutionDir(workingDir);
       var submoduleDir = DocPathUtil.GetSubmoduleDir(solutionDir);
       var discordSubmoduleDir = DocPathUtil.GetDiscordSubmoduleDir(submoduleDir);
       var discordDocsDir = DocPathUtil.GetDiscordDocsDir(discordSubmoduleDir);
       Assert.False(string.IsNullOrEmpty(discordDocsDir));
    }
    
    [Fact]
    public void DiscordDocsDir_DoesThrow()
    {
       Assert.Throws<DirectoryNotFoundException>(
           () => DocPathUtil.GetDiscordDocsDir("\\doesnotexist"));
    }
    
         
    [Fact]
    public void DiscordDocResourcesDir_DoesNotThrow()
    {
       var workingDir = DocPathUtil.GetWorkingDir();
       var solutionDir = DocPathUtil.GetSolutionDir(workingDir);
       var submoduleDir = DocPathUtil.GetSubmoduleDir(solutionDir);
       var discordSubmoduleDir = DocPathUtil.GetDiscordSubmoduleDir(submoduleDir);
       var discordDocsDir = DocPathUtil.GetDiscordDocsDir(discordSubmoduleDir);
       var discordDocResourcesDir = DocPathUtil.GetDiscordDocResourcesDir(discordDocsDir);
       Assert.False(string.IsNullOrEmpty(discordDocResourcesDir));
    }
    
    [Fact]
    public void DiscordDocResourcesDir_DoesThrow()
    {
       Assert.Throws<DirectoryNotFoundException>(
           () => DocPathUtil.GetDiscordDocResourcesDir("\\doesnotexist"));
    }
}