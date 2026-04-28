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
        [TestMethod]
        public void GetTimeAsText_Midi_RetourneMidi()
        {
            var date = new DateTime(2026, 4, 28, 12, 0, 0);
            Assert.AreEqual("midi", TimeTranslator.GetTimeAsText(date));
        }

        [TestMethod]
        public void GetTimeAsText_Minuit_RetourneMinuit()
        {
            var date = new DateTime(2026, 4, 28, 0, 0, 0);
            Assert.AreEqual("minuit", TimeTranslator.GetTimeAsText(date));
        }

        [TestMethod]
        public void GetTimeAsText_MinutesPremiereDemiHeure_RetourneTexte()
        {
            Assert.AreEqual("midi dix", TimeTranslator.GetTimeAsText(new DateTime(2026, 4, 28, 12, 10, 0)));
            Assert.AreEqual("trois heures vingt-cinq de l'après-midi", TimeTranslator.GetTimeAsText(new DateTime(2026, 4, 28, 15, 25, 0)));
            Assert.AreEqual("minuit et quart", TimeTranslator.GetTimeAsText(new DateTime(2026, 4, 28, 0, 15, 0)));
        }

        [TestMethod]
        public void GetTimeAsText_MinutesApresDemiHeure_RetourneTexte()
        {
            Assert.AreEqual("neuf heures moins le quart du matin", TimeTranslator.GetTimeAsText(new DateTime(2026, 4, 28, 8, 45, 0)));
            Assert.AreEqual("une heure moins vingt-cinq de l'après-midi", TimeTranslator.GetTimeAsText(new DateTime(2026, 4, 28, 12, 35, 0)));
        }
    }
}