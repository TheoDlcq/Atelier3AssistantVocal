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
            return $"{Heures[time.Hour]} heures du matin";
        }
    }
}