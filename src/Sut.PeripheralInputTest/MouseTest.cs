using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sut.PeripheralInputTest.ObjectRepository;
using Screen = CUITe.ObjectRepository.Screen;

namespace Sut.PeripheralInputTest
{
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using TestHelpers;

    [CodedUITest]
#if DEBUG
    [DeploymentItem(@"..\..\..\Sut.PeripheralInput\bin\Debug\Sut.PeripheralInput.exe")]
#else
    [DeploymentItem(@"..\..\..\Sut.PeripheralInput\bin\Release\Sut.PeripheralInput.exe")]
#endif
    public class MouseTest
    {
        private const string ApplicationFilePath = @"Sut.PeripheralInput.exe";
        private MainScreen mainScreen;

        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for
        /// the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            mainScreen = Screen.Launch<MainScreen>(ApplicationFilePath);

            CustomPlaybackSettings.Initialize();
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

        #region Click

        [TestMethod]
        public void LeftClick()
        {
            // Act
            mainScreen.MouseClickText.Click();

            // Assert
            Assert.AreEqual("Left click", mainScreen.MouseClickResult.Text);
        }

        [TestMethod]
        public void MiddleClick()
        {
            // Act
            mainScreen.MouseClickText.Click(MouseButtons.Middle);

            // Assert
            Assert.AreEqual("Middle click", mainScreen.MouseClickResult.Text);
        }

        [TestMethod]
        public void RightClick()
        {
            // Act
            mainScreen.MouseClickText.Click(MouseButtons.Right);

            // Assert
            Assert.AreEqual("Right click", mainScreen.MouseClickResult.Text);
        }
        
        [TestMethod]
        public void XButton1Click()
        {
            // Act
            mainScreen.MouseClickText.Click(MouseButtons.XButton1);

            // Assert
            Assert.AreEqual("XButton1 click", mainScreen.MouseClickResult.Text);
        }

        [TestMethod]
        public void XButton2Click()
        {
            // Act
            mainScreen.MouseClickText.Click(MouseButtons.XButton2);

            // Assert
            Assert.AreEqual("XButton2 click", mainScreen.MouseClickResult.Text);
        }

        #endregion

        #region Double click

        [TestMethod]
        public void LeftDoubleClick()
        {
            // Act
            mainScreen.MouseClickText.DoubleClick();

            // Assert
            Assert.AreEqual("Left double click", mainScreen.MouseClickResult.Text);
        }

        [TestMethod]
        public void MiddleDoubleClick()
        {
            // Act
            mainScreen.MouseClickText.DoubleClick(MouseButtons.Middle);

            // Assert
            Assert.AreEqual("Middle double click", mainScreen.MouseClickResult.Text);
        }

        [TestMethod]
        public void RightDoubleClick()
        {
            // Act
            mainScreen.MouseClickText.DoubleClick(MouseButtons.Right);

            // Assert
            Assert.AreEqual("Right double click", mainScreen.MouseClickResult.Text);
        }

        [TestMethod]
        public void XButton1DoubleClick()
        {
            // Act
            mainScreen.MouseClickText.DoubleClick(MouseButtons.XButton1);

            // Assert
            Assert.AreEqual("XButton1 double click", mainScreen.MouseClickResult.Text);
        }

        [TestMethod]
        public void XButton2DoubleClick()
        {
            // Act
            mainScreen.MouseClickText.DoubleClick(MouseButtons.XButton2);

            // Assert
            Assert.AreEqual("XButton2 double click", mainScreen.MouseClickResult.Text);
        }

        #endregion

        #region Click with modifier

        [TestMethod]
        public void ClickWithAltModifier()
        {
            // Act
            mainScreen.MouseClickText.Click(ModifierKeys.Alt);

            // Assert
            Assert.AreEqual("Left click with Alt", mainScreen.MouseClickResult.Text);
        }

        [TestMethod]
        public void ClickWithControlModifier()
        {
            // Act
            mainScreen.MouseClickText.Click(ModifierKeys.Control);

            // Assert
            Assert.AreEqual("Left click with Control", mainScreen.MouseClickResult.Text);
        }

        [TestMethod]
        public void ClickWithShiftModifier()
        {
            // Act
            mainScreen.MouseClickText.Click(ModifierKeys.Shift);

            // Assert
            Assert.AreEqual("Left click with Shift", mainScreen.MouseClickResult.Text);
        }

        #endregion
    }
}