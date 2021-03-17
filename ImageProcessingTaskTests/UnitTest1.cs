using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageProcessingTask;
using System.Drawing;

namespace ImageProcessingTaskTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckPixelColor()
        {
            ImageProcessing imageProcessing = new ImageProcessing();
            Assert.AreEqual(imageProcessing.GetSelectedColor(1), Color.Red);
            Assert.AreEqual(imageProcessing.GetSelectedColor(2), Color.Green);
            Assert.AreEqual(imageProcessing.GetSelectedColor(3), Color.Blue);
            Assert.AreEqual(imageProcessing.GetSelectedColor(4), Color.Black);
        }

        [TestMethod]
        public void CheckTestMaxPixel()
        {
            ImageProcessing imageProcessing = new ImageProcessing();
            Color color = default;

            int maxPixel = 0;
            imageProcessing.SetMaxPixel(ref maxPixel, -20, color);

            Assert.AreEqual(maxPixel, 2);
    
        }
    }
}
