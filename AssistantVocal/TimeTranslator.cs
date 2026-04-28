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
            
            // Interception des cas spéciaux "pile"
            if (time.Minute == 0)
            {
                if (hour == 12) return "midi";
                if (hour == 0) return "minuit";
            }

            string periode = hour < 12 ? "du matin" : "de l'après-midi";
            int displayHour = hour > 12 ? hour - 12 : hour;
            
            return $"{Heures[displayHour]} heures {periode}";
        }
    }
}