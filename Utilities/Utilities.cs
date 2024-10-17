using DocAIPCPQAAutomation.Support;
using System;
using System.IO;
using System.Linq;

namespace APITestAutomation.Support
{
    public class Utilities
    {
        /// <summary>
        /// Returns the base address of any URL.
        /// </summary>
        /// <param name="completeURL">Complete URL</param>
        /// <param name="baseURL">Base URL</param>
        public void GetBaseURLFromCompleteURL(string completeURL, out string baseURL)
        {
            baseURL = completeURL.Substring(0, completeURL.IndexOf(".uk") + 3);
        }

        /// <summary>
        /// Returns the substring of the URL which starts after the base address.
        /// </summary>
        /// <param name="completeURL">Complete URL</param>
        /// <param name="endpoint">Includes directory slug etc.</param>
        public void GetEndpointFromCompleteURL(string completeURL, out string endpoint)
        {
            int lastIndexOfBaseAddress = completeURL.IndexOf(".uk") + 3;
            endpoint = completeURL.Substring(lastIndexOfBaseAddress + 1, completeURL.Length - lastIndexOfBaseAddress - 1);
        }

        /// <summary>
        /// Function returns the absolute path of the TestData folder.
        /// </summary>
        /// <returns>Path of the TestData folder</returns>
        public string GetPathOfTestDataFolder()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            string pathName = Directory.GetParent(currentDirectory).Parent.Parent.ToString();
            string testDataFolderPath = Path.Combine(pathName, Constants.TESTDATA_FOLDER_NAME);
            return testDataFolderPath;
        }

        /// <summary>
        /// Gets the path of a file within a specified folder in the project directory.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="folderName">The name of the folder.</param>
        /// <returns>The path of the file.</returns>
        public string GetPathOfFile(string fileName, string folderName)
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            while (!Directory.GetFiles(projectDirectory, "*.sln").Any())
            {
                projectDirectory = Directory.GetParent(projectDirectory)?.FullName;
                if (projectDirectory == null)
                {
                    throw new DirectoryNotFoundException("Could not locate the project root directory.");
                }
            }
            string folderPath = Path.Combine(projectDirectory, folderName);

            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException($"The folder '{folderName}' does not exist in the project directory.");
            }
            string filePath = Path.Combine(folderPath, fileName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{fileName}' does not exist in the folder '{folderName}'.");
            }
            return filePath;
        }
    }
}