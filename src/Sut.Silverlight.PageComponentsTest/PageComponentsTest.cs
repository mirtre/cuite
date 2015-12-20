using System.IO;
using CassiniDev;
using CUITe.ObjectRepository;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sut.Silverlight.PageComponentsTest.ObjectRepository;

namespace Sut.Silverlight.PageComponentsTest
{
    using System.Diagnostics;
    using System.Drawing;

    [CodedUITest]
    [DeploymentItem("Sut.Silverlight.PageComponents.html")]
#if DEBUG
    [DeploymentItem(@"..\..\..\Sut.Silverlight.PageComponents\Bin\Debug\Sut.Silverlight.PageComponents.xap")]
#else
    [DeploymentItem(@"..\..\..\Sut.Silverlight.PageComponents\Bin\Release\Sut.Silverlight.PageComponents.xap")]
#endif
    public class PageComponentsTest
    {
        private static readonly CassiniDevServer WebServer = new CassiniDevServer();
        
        private MainPage mainPage;

        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for
        /// the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            WebServer.StartServer(Directory.GetCurrentDirectory(), 8080, "/", "localhost");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            WebServer.StopServer();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mainPage = Page.Launch<MainPage>(WebServer.RootUrl + "Sut.Silverlight.PageComponents.html");
        }

        /// <summary>
        /// Runs after each test.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            Trace.WriteLine(string.Format("Test Results Directory: {0}", TestContext.TestResultsDirectory));

            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                Image image = UITestControl.Desktop.CaptureImage();
                string fileName = Path.Combine(TestContext.TestResultsDirectory, "Failure.png");
                image.Save(fileName);
                TestContext.AddResultFile(fileName);
            }
        }

        [TestMethod]
        public void UpperLeft()
        {
            // Assert
            Assert.IsTrue(mainPage.UpperLeft.CheckBoxExists);
        }

        [TestMethod]
        public void RebasedUpperLeft()
        {
            // Assert
            Assert.IsTrue(mainPage.RebasedUpperLeft.CheckBoxExists);
        }

        [TestMethod]
        public void UpperRight()
        {
            // Assert
            Assert.IsTrue(mainPage.UpperRight.CheckBoxExists);
        }

        [TestMethod]
        public void RebasedUpperRight()
        {
            // Assert
            Assert.IsTrue(mainPage.RebasedUpperRight.CheckBoxExists);
        }

        [TestMethod]
        public void LowerLeft()
        {
            // Assert
            Assert.IsTrue(mainPage.LowerLeft.RadioButtonExists);
        }

        [TestMethod]
        public void RebasedLowerLeft()
        {
            // Assert
            Assert.IsTrue(mainPage.RebasedLowerLeft.RadioButtonExists);
        }

        [TestMethod]
        public void LowerRight()
        {
            // Assert
            Assert.IsTrue(mainPage.LowerRight.RadioButtonExists);
        }

        [TestMethod]
        public void RebasedLowerRight()
        {
            // Assert
            Assert.IsTrue(mainPage.RebasedLowerRight.RadioButtonExists);
        }

        [TestMethod]
        public void Browser()
        {
            // Act
            BrowserWindow actual = mainPage.Browser;

            // Assert
            Assert.AreEqual(mainPage.UpperLeft.Browser, actual);
            Assert.AreEqual(mainPage.RebasedUpperLeft.Browser, actual);
            Assert.AreEqual(mainPage.UpperRight.Browser, actual);
            Assert.AreEqual(mainPage.RebasedUpperRight.Browser, actual);
            Assert.AreEqual(mainPage.LowerLeft.Browser, actual);
            Assert.AreEqual(mainPage.RebasedLowerLeft.Browser, actual);
            Assert.AreEqual(mainPage.LowerRight.Browser, actual);
            Assert.AreEqual(mainPage.RebasedLowerRight.Browser, actual);
        }

        [TestMethod]
        public void NavigateToDialog()
        {
            // Act
            var dialogScreen = mainPage.MiddleComponent.NavigateToDialogPage();

            // Assert
            Assert.IsTrue(dialogScreen.CloseButtonExists);
        }
    }
}