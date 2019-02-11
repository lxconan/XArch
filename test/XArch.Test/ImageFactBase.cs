using System;
using System.IO;
using System.Threading;
using Serilog;
using Serilog.Core;
using Xunit.Abstractions;

namespace XArch.Test
{
    public abstract class ImageFactBase
    {
        protected Logger Logger { get; }
        protected string ResourcePath => resourcePath.Value;
        static readonly Lazy<string> resourcePath = new Lazy<string>(
            FindResourcePath, LazyThreadSafetyMode.ExecutionAndPublication);

        protected ImageFactBase(ITestOutputHelper output)
        {
            Logger = new LoggerConfiguration()
                .WriteTo.TestOutput(output)
                .CreateLogger();
        }

        protected string GetResourcePath(string relativePath)
        {
            return Path.Combine(ResourcePath, relativePath);
        }
        
        protected FileStream OpenResourceStream(string relativePath)
        {
            return new FileStream(
                GetResourcePath(relativePath),
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);
        }

        static string FindResourcePath()
        {
            string binDir = AppDomain.CurrentDomain.BaseDirectory;
            var currentDir = new DirectoryInfo(binDir);
            const int maxSearchLevel = 6;
            for (int i = 0; i < maxSearchLevel; ++i)
            {
                string path = Path.Combine(currentDir.FullName, "Resources");
                if (Directory.Exists(path)) { return path; }
                currentDir = currentDir.Parent;
                if (currentDir == null) { break; }
            }
            
            throw new IOException("Cannot find resource path for images.");
        }
    }
}