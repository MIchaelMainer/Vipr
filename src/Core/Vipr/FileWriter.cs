using System;
using System.Collections.Generic;
using System.IO;
using Vipr.Core;

namespace Vipr
{
    internal static class FileWriter
    {
        public static void Write(IEnumerable<TextFile> textFilesToWrite, string outputDirectoryPath = null)
        {
            if (!string.IsNullOrWhiteSpace(outputDirectoryPath) && !Directory.Exists(outputDirectoryPath))
                Directory.CreateDirectory(outputDirectoryPath);

            foreach (var file in textFilesToWrite)
            {
                var filePath = file.RelativePath;

                if (!string.IsNullOrWhiteSpace(outputDirectoryPath))
                    filePath = Path.Combine(outputDirectoryPath, filePath);

                if (!String.IsNullOrWhiteSpace(Environment.CurrentDirectory) &&
                    !Path.IsPathRooted(filePath))
                    filePath = Path.Combine(Environment.CurrentDirectory, filePath);

                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                File.WriteAllText(filePath, file.Contents);
            }
        }
    }
}