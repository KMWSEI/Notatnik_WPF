using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotatnikWPF;
using System.Windows;
using System.Windows.Media;
using System.Drawing;

namespace Notepad_UnitTests
{
    [TestClass]
    public class Notepad_UnitTests
    {
        [TestMethod]
        public void TestSaveLanguage()
        {
            Settings.SaveLanguage("pl");
            Assert.AreEqual("pl-PL", System.Threading.Thread.CurrentThread.CurrentUICulture.ToString());
        }

        [TestMethod]
        public void TestReadLanguage()
        {
            Settings.SaveLanguage("en");
            Settings.ReadLanguage();
            Assert.AreEqual("en", System.Threading.Thread.CurrentThread.CurrentUICulture.ToString());
        }

        [TestMethod]
        public void TestDefaultFont()
        {
            NotatnikWPF.Fonts DefaultFont = NotatnikWPF.Fonts.Default;
            NotatnikWPF.Fonts font = new NotatnikWPF.Fonts();
            font.Family = new System.Windows.Media.FontFamily("Times New Roman");
            font.Style = FontStyles.Normal;
            font.Weight = FontWeights.Normal;
            font.TextDecorations = null;
            font.Size = 12;
            font.Color = Colors.Black;
            Assert.AreEqual(font.Family, DefaultFont.Family);
            Assert.AreEqual(font.Style, DefaultFont.Style);
            Assert.AreEqual(font.Weight, DefaultFont.Weight);
            Assert.AreEqual(font.TextDecorations, DefaultFont.TextDecorations);
            Assert.AreEqual(font.Size, DefaultFont.Size);
            Assert.AreEqual(font.Color, DefaultFont.Color);
        }

        [TestMethod]
        public void TestConvertColorToARGB()
        {
            System.Windows.Media.Color nColor = new System.Windows.Media.Color();
            nColor.A = 255;
            nColor.R = 0;
            nColor.B = 0;
            nColor.G = 0;
            System.Windows.Media.Color oColor = NotatnikWPF.Fonts.Convert(System.Drawing.Color.Black);
            Assert.AreEqual(oColor.A, nColor.A);
            Assert.AreEqual(oColor.R, nColor.R);
            Assert.AreEqual(oColor.G, nColor.G);
            Assert.AreEqual(oColor.B, nColor.B);
        }

        [TestMethod]
        public void TestConverColorFromARGB()
        {
            System.Drawing.Color aColor = System.Drawing.Color.Black;
            System.Windows.Media.Color nColor = NotatnikWPF.Fonts.Convert(aColor);
            Assert.AreEqual(aColor.A, nColor.A);
            Assert.AreEqual(aColor.R, nColor.R);
            Assert.AreEqual(aColor.G, nColor.G);
            Assert.AreEqual(aColor.B, nColor.B);
        }

        [TestMethod]
        public void TestConvertToDrawingFont()
        {
            System.Drawing.Font SDFont = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Underline);
            NotatnikWPF.Fonts WPFont = NotatnikWPF.Fonts.Default;
            WPFont.TextDecorations = TextDecorations.Underline;
            System.Drawing.Font font = NotatnikWPF.Fonts.ConvertToDrawingFont(WPFont);
            Assert.AreEqual(SDFont.FontFamily, font.FontFamily);
            Assert.AreEqual(SDFont.Style, font.Style);
            Assert.AreEqual(SDFont.Size, font.Size);
        }

        [TestMethod]
        public void TestConvertFromDrawingFont()
        {
            NotatnikWPF.Fonts Font = NotatnikWPF.Fonts.Default;
            System.Drawing.Font SDFont = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Regular);
            System.Drawing.Color SDColor = System.Drawing.Color.Black;
            NotatnikWPF.Fonts WPFont = NotatnikWPF.Fonts.ConvertFromDrawingFont(SDFont, SDColor);
            Assert.AreEqual(WPFont.FamilyName, Font.FamilyName);
            Assert.AreEqual(WPFont.Family, Font.Family);
            Assert.AreEqual(WPFont.Size, Font.Size);
            Assert.AreEqual(WPFont.Weight, Font.Weight);
            Assert.AreEqual(WPFont.Color, Font.Color);
            Assert.AreEqual(WPFont.Style, Font.Style);
        }
    }
}
