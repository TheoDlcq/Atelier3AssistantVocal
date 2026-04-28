using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssistantVocal;
using System;

namespace AssistantVocal.Tests
{
    [TestClass]
    public class TimeTranslatorTest
    {
        [TestMethod]
        public void GetTimeAsText_HeurePileMatin_RetourneTexte()
        {
            var date = new DateTime(2026, 4, 28, 7, 0, 0);
            Assert.AreEqual("sept heures du matin", TimeTranslator.GetTimeAsText(date));
        }

        [TestMethod]
        public void GetTimeAsText_HeurePileApresMidi_RetourneTexte()
        {
            var date = new DateTime(2026, 4, 28, 14, 0, 0);
            Assert.AreEqual("deux heures de l'après-midi", TimeTranslator.GetTimeAsText(date));
        }
    }
}