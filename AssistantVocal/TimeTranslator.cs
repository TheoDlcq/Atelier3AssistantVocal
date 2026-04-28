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

            // Calcul de la cible multiple de 5 la plus proche et de la différence
            int targetMinute = (int)Math.Round(minute / 5.0) * 5;
            int diff = Math.Abs(minute - targetMinute);

            int displayHour = targetMinute > 30 ? (hour + 1) % 24 : hour;

            string heureTexte = "";
            string periode = "";

            if (displayHour == 12) heureTexte = "midi";
            else if (displayHour == 0) heureTexte = "minuit";
            else 
            {
                int h12 = displayHour > 12 ? displayHour - 12 : displayHour;
                periode = displayHour < 12 ? " du matin" : " de l'après-midi";
                string s = h12 == 1 ? "" : "s";
                heureTexte = $"{Heures[h12]} heure{s}";
            }

            string minuteTexte = (targetMinute % 60 != 0 && Minutes.ContainsKey(targetMinute)) ? $" {Minutes[targetMinute]}" : "";
            
            string resultatBase = (displayHour == 12 || displayHour == 0) ? $"{heureTexte}{minuteTexte}" : $"{heureTexte}{minuteTexte}{periode}";

            // Ajout du suffixe de précision si nécessaire
            if (diff > 0)
            {
                string diffTexte = diff == 1 ? "une" : "deux";
                string minutePluriel = diff > 1 ? "s" : "";
                return $"{resultatBase} à {diffTexte} minute{minutePluriel} près";
            }

            return resultatBase;
        }
    }
}