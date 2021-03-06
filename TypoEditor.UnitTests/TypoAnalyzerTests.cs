﻿namespace TypoEditor.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class TypoAnalyzerTests
    {
        [TestMethod]
        public void TestConstructorWithNullFileSystem()
        {
            try
            {
                var analyzer = new TypoAnalyzer(null, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("fileSystem", ex.ParamName);
                return;
            }
            Assert.Fail("Expected ArgumentNullException is not thrown.");
        }

        [TestMethod]
        public void TestConstructorWithNullCorrectWords()
        {
            try
            {
                var analyzer = new TypoAnalyzer(new FakeFileSystem(), null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("correctWords", ex.ParamName);
                return;
            }
            Assert.Fail("Expected ArgumentNullException is not thrown.");
        }

        [TestMethod]
        public void TestAnalyze()
        {
            FakeProgressReporter progressReporter = new FakeProgressReporter();
            var analyzer = new TypoAnalyzer(new FakeFileSystem(), new FakeCorrectWords());
            TypoAnalyzerResult result = analyzer.Analyze(@"c:\dev", "*.cs", progressReporter);
            KeywordOccurrences[] keywords = result.Keywords.ToArray();
            Assert.AreEqual("cruel", keywords[0].Keyword);
            Assert.AreEqual("hello", keywords[1].Keyword);
            Assert.AreEqual("world", keywords[2].Keyword);
            Assert.IsTrue(Enumerable.SequenceEqual(new string[] { "b.cs" }, keywords[0].Occurrences));
        }
    }
}
