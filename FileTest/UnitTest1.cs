
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using TestFiles;
namespace FileTests
{
    [TestClass]
    public class FileUnitTests
    {
        [TestMethod]
        public void ReadFile_ReturnsListOfSettings_IfFileIsNotEmpty()
        {
           
            List<string> systemConfig=new List<string>();
            string winDir = "C:\\Windows";
            string path = "\\system.ini";
          
            systemConfig = TestFiles.File.ReadFile(systemConfig, winDir, path);
        
            Assert.IsTrue(systemConfig.Count > 0); //korjattu

        }
        [TestMethod]
        public void ReadFile_ReturnsEmptyList_IfFileIsEmpty()
        {
            // Arrange
            List<string> systemConfig = new List<string>();
            string winDir = "C:\\TestDirectory";
            string path = "\\";

            // Act & Assert
            var ex = Assert.ThrowsException<System.IO.FileNotFoundException>(() => systemConfig = TestFiles.File.ReadFile(systemConfig, winDir, path));
            Assert.AreEqual($"Could not find file '{winDir + path}'.", ex.Message);
            Assert.IsTrue(systemConfig.Count == 0);
        }
        [TestMethod]
        public void ReadFile_ThrowsFileNotFoundException_IfFileDoesNotExist()
        {
            List<string> systemConfig = new List<string>();
            string winDir = Path.GetTempPath();
            string path = "\\nonExistentFile.txt";
            string fullPath = winDir + path;
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            //Act & Assert
            Assert.ThrowsException<FileNotFoundException>(() => TestFiles.File.ReadFile(systemConfig, winDir, path));
        }
        [TestMethod]
        [ExpectedException(typeof(System.UnauthorizedAccessException))]
        public void ReadFile_FindsDDriveSchoolFiles_IfFileIsNotEmpty()
        {
            List<string> systemConfig = new List<string>();
            string winDir = "D:\\Koulu";
            string path = "\\C# Gradia";

            systemConfig = TestFiles.File.ReadFile(systemConfig, winDir, path);

            Assert.IsTrue(systemConfig.Count > 0);
        }
    }
}