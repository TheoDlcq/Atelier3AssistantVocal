using System;

namespace AssistantVocal
{
    public static class TimeTranslator
    {
        private static readonly string[] Heures = { 
            "minuit", "une", "deux", "trois", "quatre", "cinq", "six", 
            "sept", "huit", "neuf", "dix", "onze", "midi" 
        };

        public static string GetTimeAsText(DateTime time)
        {
            int hour = time.Hour;
            
            string periode = hour < 12 ? "du matin" : "de l'après-midi";
            int displayHour = hour > 12 ? hour - 12 : hour;
            
            return $"{Heures[displayHour]} heures {periode}";
        }
    }
}