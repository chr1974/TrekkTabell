// Søndag 30 Januar 2022 
// Konvertert fra Java til C# av Christian Haugland - haugland.christian@gmail.com
// Koden er konvertert ganske raskt og trengs litt opprydning når det kommer til
// C# Naming conventions og Deklarering av internal/ public / private accessors

// Orginal Java kode kan finnes hos skatteetatens github her -> https://github.com/Skatteetaten/trekktabell

using J2N.Collections.Generic;

namespace No.Skatteetaten.Fastsetting.Formuenntekt.Forskudd.Trekkrutine2022;

public class HeleTabellen
{
    public readonly LinkedDictionary<long, long> alleTrekk;
    public readonly int overskytendeProsent;
    public HeleTabellen(LinkedDictionary<long, long> alleTrekk, int overskytendeProsent)
    {
        this.alleTrekk = alleTrekk;
        this.overskytendeProsent = overskytendeProsent;
    }
}
