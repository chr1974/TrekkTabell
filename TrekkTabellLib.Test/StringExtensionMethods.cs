// Søndag 30 Januar 2022 
// Konvertert fra Java til C# av Christian Haugland - haugland.christian@gmail.com
// Koden er konvertert ganske raskt og trengs litt opprydning når det kommer til
// C# Naming conventions og Deklarering av internal/ public / private accessors

// Orginal Java kode kan finnes hos skatteetatens github her -> https://github.com/Skatteetaten/trekktabell

//NB: Denne klassen er ikke fra SkatteEtatens kode!

namespace TrekkTabellLibTest
{
    public static class StringExtensionMethods
    {
        public static char CharAt(this string str, int index)
        {
            char[] chars = str.ToCharArray();
            return chars[index];
        }
    }
}
