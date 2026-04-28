using System;
using System.Collections.Generic;

namespace AssistantVocal
{
    public static class TimeTranslator
    {
        private static readonly string[] Heures = { 
            "minuit", "une", "deux", "trois", "quatre", "cinq", "six", 
            "sept", "huit", "neuf", "dix", "onze", "midi" 
        };

        private static readonly Dictionary<int, string> Minutes = new Dictionary<int, string>
        {
            { 5, "cinq" },
            { 10, "dix" },
            { 15, "et quart" },
            { 20, "vingt" },
            { 25, "vingt-cinq" },
            { 30, "et demi" }
        };

        public static string GetTimeAsText(DateTime time)
        {
            int hour = time.Hour;
            int minute = time.Minute;
            
            string heureTexte = "";
            string periode = "";

            // 1. Détermination de l'heure de base
            if (hour == 12) heureTexte = "midi";
            else if (hour == 0) heureTexte = "minuit";
            else 
            {
                int displayHour = hour > 12 ? hour - 12 : hour;
                periode = hour < 12 ? " du matin" : " de l'après-midi";
                heureTexte = $"{Heures[displayHour]} heures";
            }

            // 2. Si heure pile, on renvoie directement
            if (minute == 0) return (heureTexte + periode).Trim();

            // 3. Ajout des minutes
            string minuteTexte = Minutes.ContainsKey(minute) ? $" {Minutes[minute]}" : "";

            // 4. Assemblage (Midi et minuit ne prennent pas de période)
            if (hour == 12 || hour == 0)
            {
                return $"{heureTexte}{minuteTexte}";
            }

            return $"{heureTexte}{minuteTexte}{periode}";
        }
    }
}