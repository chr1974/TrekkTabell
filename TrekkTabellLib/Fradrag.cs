// Søndag 30 Januar 2022 
// Konvertert fra Java til C# av Christian Haugland - haugland.christian@gmail.com
// Koden er konvertert ganske raskt og trengs litt opprydning når det kommer til
// C# Naming conventions og Deklarering av internal/ public / private accessors

// Orginal Java kode kan finnes hos skatteetatens github her -> https://github.com/Skatteetaten/trekktabell

namespace No.Skatteetaten.Fastsetting.Formuenntekt.Forskudd.Trekkrutine2022;

public class Fradrag
{
    internal static long BeregnMinsteFradrag(Tabellnummer tabellnummer, long personInntektAar)
    {
        if (tabellnummer.tabelltype == Tabelltype.PENSJONIST)
            return BeregnMinstefradragPensjon(personInntektAar);

        if (tabellnummer.tabelltype == Tabelltype.SJØ)
            return BeregnMinstefradragSjo(personInntektAar);

        return BeregnMinstefradragVanlig(personInntektAar);
    }

    // Beregner både for vanlige tabeller og standardfradrag-tabeller
    internal static long BeregnMinstefradragVanlig(long personInntektAar)
    {
        long minstefradrag = (long)Math.Round((personInntektAar * Konstanter.ANV_MINSTE_FRAD_PROSENT) / 100);

        if (minstefradrag > Konstanter.MAX_ANV_MINSTE_FRADRAG)
        {
            minstefradrag = Konstanter.MAX_ANV_MINSTE_FRADRAG;
        }
        if (minstefradrag < Konstanter.MIN_ANV_MINSTE_FRADRAG)
        {
            minstefradrag = Konstanter.MIN_ANV_MINSTE_FRADRAG;
        }
        if (minstefradrag < Konstanter.ANV_LONNSFRADRAG)
        {
            minstefradrag = Konstanter.ANV_LONNSFRADRAG;
        }
        if (minstefradrag > personInntektAar)
        {
            minstefradrag = personInntektAar;
        }
        return minstefradrag;
    }

    internal static long BeregnMinstefradragPensjon(long personInntektAar)
    {
        long minstefradrag = (long)Math.Round((personInntektAar * Konstanter.ANV_MINSTE_FRAD_PROSENT_PENSJ) / 100);

        if (minstefradrag > Konstanter.MAX_ANV_MINSTE_FRADRAG_PENSJ)
        {
            minstefradrag = Konstanter.MAX_ANV_MINSTE_FRADRAG_PENSJ;
        }
        if (minstefradrag < Konstanter.MIN_ANV_MINSTE_FRADRAG)
        {
            minstefradrag = Konstanter.MIN_ANV_MINSTE_FRADRAG;
        }
        if (minstefradrag > personInntektAar)
        {
            minstefradrag = personInntektAar;
        }
        return minstefradrag;
    }

    internal static long BeregnMinstefradragSjo(long personInntektAar)
    {
        long minstefradrag = (long)Math.Round((personInntektAar * Konstanter.MINSTE_FRAD_PROSENT) / 100);

        if (minstefradrag > Konstanter.MAX_MINSTE_FRADRAG)
        {
            minstefradrag = Konstanter.MAX_MINSTE_FRADRAG;
        }
        if (minstefradrag < Konstanter.MIN_MINSTE_FRADRAG)
        {
            minstefradrag = Konstanter.MIN_MINSTE_FRADRAG;
        }
        if (minstefradrag < Konstanter.LONNSFRADRAG)
        {
            minstefradrag = Konstanter.LONNSFRADRAG;
        }
        if (minstefradrag > personInntektAar)
        {
            minstefradrag = personInntektAar;
        }
        return minstefradrag;
    }

    internal static long BeregnStandardFradrag(Tabellnummer tabellnummer, long personInntektAar)
    {
        if (!tabellnummer.IsStandardFradrag())
            return 0L;

        long standardFradrag = (long)Math.Round((personInntektAar * Konstanter.STFRADRAG_PROSENT) / 100);
        return (standardFradrag > Konstanter.MAX_STFRADRAG) ? Konstanter.MAX_STFRADRAG : standardFradrag;
    }

    internal static long BeregnSjoFradrag(Tabellnummer tabellnummer, long personInntektAar)
    {
        if (tabellnummer.tabelltype != Tabelltype.SJØ)
            return 0L;

        long sjoFradrag = (long)Math.Round((personInntektAar * Konstanter.SJO_PROSENT) / 100);
        return (sjoFradrag > Konstanter.MAX_SJO_FRADRAG) ? Konstanter.MAX_SJO_FRADRAG : sjoFradrag;
    }
}
