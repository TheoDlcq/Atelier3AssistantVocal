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
            { 5, "cinq" }, { 10, "dix" }, { 15, "et quart" }, { 20, "vingt" }, { 25, "vingt-cinq" }, { 30, "et demi" },
            { 35, "moins vingt-cinq" }, { 40, "moins vingt" }, { 45, "moins le quart" }, { 50, "moins dix" }, { 55, "moins cinq" }
        };

        public static string GetTimeAsText(DateTime time)
        {
            int hour = time.Hour;
            int minute = time.Minute;
            
            // Si on est dans la deuxième moitié de l'heure, on se base sur l'heure suivante
            int displayHour = minute > 30 ? (hour + 1) % 24 : hour;

            string heureTexte = "";
            string periode = "";

            if (displayHour == 12) heureTexte = "midi";
            else if (displayHour == 0) heureTexte = "minuit";
            else 
            {
                int h12 = displayHour > 12 ? displayHour - 12 : displayHour;
                periode = displayHour < 12 ? " du matin" : " de l'après-midi";
                
                // Gestion singulier/pluriel pour "heure"
                string s = h12 == 1 ? "" : "s";
                heureTexte = $"{Heures[h12]} heure{s}";
            }

            if (minute == 0) return (heureTexte + periode).Trim();

            string minuteTexte = Minutes.ContainsKey(minute) ? $" {Minutes[minute]}" : "";

            if (displayHour == 12 || displayHour == 0) return $"{heureTexte}{minuteTexte}";
            return $"{heureTexte}{minuteTexte}{periode}";
        }
    }
}