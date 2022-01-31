// Søndag 30 Januar 2022 
// Konvertert fra Java til C# av Christian Haugland - haugland.christian@gmail.com
// Koden er konvertert ganske raskt og trengs litt opprydning når det kommer til
// C# Naming conventions og Deklarering av internal/ public / private accessors

// Orginal Java kode kan finnes hos skatteetatens github her -> https://github.com/Skatteetaten/trekktabell

namespace No.Skatteetaten.Fastsetting.Formuenntekt.Forskudd.Trekkrutine2022;

public class Skatteberegning
{
    public static long BeregnKommuneskatt(double alminneligInntektAar)
    {
        return alminneligInntektAar > 0 ? (long)Math.Round(alminneligInntektAar * Konstanter.SKATTORE / 100) : 0L;
    }

    public static long BeregnFelleseskatt(Tabellnummer tabellnummer, double alminneligInntektAar)
    {
        if (alminneligInntektAar < 0)
        {
            return 0L;
        }

        return tabellnummer.tabelltype == Tabelltype.FINNMARK ?
                (long)Math.Round(alminneligInntektAar * Konstanter.FELLES_SKATT_FINNMARK / 100) :
                (long)Math.Round(alminneligInntektAar * Konstanter.FELLES_SKATT_VANLIG / 100);
    }

    public static long BeregnTrinnskatt(Tabellnummer tabellnummer, double personInntektAar)
    {
        if (personInntektAar < Konstanter.TRINN1)
        {
            return 0L;
        }

        double prosentTrinn3;
        if (tabellnummer.tabelltype == Tabelltype.FINNMARK)
        {
            prosentTrinn3 = Konstanter.PROSENT_TRINN3_FINNMARK;
        }
        else
        {
            prosentTrinn3 = Konstanter.PROSENT_TRINN3;
        }

        if (personInntektAar < Konstanter.TRINN2)
        {
            return BeregnTrinnskattHvisInntektUnderTrinn2(personInntektAar);
        }

        if (personInntektAar < Konstanter.TRINN3)
        {
            return BeregnTrinnskattHvisInntektUnderTrinn3(personInntektAar);
        }

        if (personInntektAar < Konstanter.TRINN4)
        {
            return BeregnTrinnskattHvisInntektUnderTrinn4(personInntektAar, prosentTrinn3);
        }

        if (personInntektAar < Konstanter.TRINN5)
        {
            return BeregnTrinnskattHvisInntektUnderTrinn5(personInntektAar, prosentTrinn3);
        }
        return BeregnTrinnskattHvisInntektOverTrinn5(personInntektAar, prosentTrinn3);
    }

    public static long BeregnTrinnskattHvisInntektUnderTrinn2(double personInntektAar)
    {
        return (long)Math.Round((personInntektAar - Konstanter.TRINN1) * Konstanter.PROSENT_TRINN1 / 100);
    }

    public static long BeregnTrinnskattHvisInntektUnderTrinn3(double personInntektAar)
    {
        return (long)Math.Round(((Konstanter.TRINN2 - Konstanter.TRINN1) * Konstanter.PROSENT_TRINN1 / 100)
                + ((personInntektAar - Konstanter.TRINN2) * Konstanter.PROSENT_TRINN2 / 100));
    }

    public static long BeregnTrinnskattHvisInntektUnderTrinn4(double personInntektAar, double prosentTrinn3)
    {
        return (long)Math.Round(((Konstanter.TRINN2 - Konstanter.TRINN1) * Konstanter.PROSENT_TRINN1 / 100)
                + ((Konstanter.TRINN3 - Konstanter.TRINN2) * Konstanter.PROSENT_TRINN2 / 100)
                + ((personInntektAar - Konstanter.TRINN3) * prosentTrinn3 / 100));
    }

    public static long BeregnTrinnskattHvisInntektUnderTrinn5(double personInntektAar, double prosentTrinn3)
    {
        return (long)Math.Round(((Konstanter.TRINN2 - Konstanter.TRINN1) * Konstanter.PROSENT_TRINN1 / 100)
            + ((Konstanter.TRINN3 - Konstanter.TRINN2) * Konstanter.PROSENT_TRINN2 / 100)
            + ((Konstanter.TRINN4 - Konstanter.TRINN3) * prosentTrinn3 / 100)
            + ((personInntektAar - Konstanter.TRINN4) * Konstanter.PROSENT_TRINN4 / 100));
    }

    public static long BeregnTrinnskattHvisInntektOverTrinn5(double personInntektAar, double prosentTrinn3)
    {
        return (long)Math.Round(((Konstanter.TRINN2 - Konstanter.TRINN1) * Konstanter.PROSENT_TRINN1 / 100)
                + ((Konstanter.TRINN3 - Konstanter.TRINN2) * Konstanter.PROSENT_TRINN2 / 100)
                + ((Konstanter.TRINN4 - Konstanter.TRINN3) * prosentTrinn3 / 100)
                + ((Konstanter.TRINN5 - Konstanter.TRINN4) * Konstanter.PROSENT_TRINN4 / 100)
                + ((personInntektAar - Konstanter.TRINN5) * Konstanter.PROSENT_TRINN5 / 100));
    }

    public static long BeregnTrygdeavgift(Tabellnummer tabellnummer, double personInntektAar)
    {
        if (personInntektAar < Konstanter.AVG_FRI_TRYGDEAVGIFT)
        {
            return 0L;
        }
        if (tabellnummer.IkkeTrygdeavgift())
        {
            return 0L;
        }

        if (tabellnummer.LavSatsTrygdeavgift())
        {
            return BeregnTrygdeavgiftLavSats(personInntektAar);
        }
        else
        {
            return BeregnTrygdeavgiftHoySats(personInntektAar);
        }
    }

    public static long BeregnTrygdeavgiftLavSats(double personInntektAar)
    {
        if (personInntektAar > Konstanter.LAV_GRENSE_TRYGDEAVGIFT)
        {
            return (long)Math.Round(personInntektAar * Konstanter.LAV_TRYGDEAVG_PROSENT / 100);
        }
        else
        {
            return (long)Math.Round((personInntektAar - Konstanter.AVG_FRI_TRYGDEAVGIFT) * Konstanter.TRYGDE_PROSENT / 100);
        }
    }

    public static long BeregnTrygdeavgiftHoySats(double personInntektAar)
    {
        if (personInntektAar > Konstanter.HOY_GRENSE_TRYGDEAVGIFT)
        {
            return (long)Math.Round(personInntektAar * Konstanter.HOY_TRYGDEAVG_PROSENT / 100);
        }
        else
        {
            return (long)Math.Round((personInntektAar - Konstanter.AVG_FRI_TRYGDEAVGIFT) * Konstanter.TRYGDE_PROSENT / 100);
        }
    }

    public static long BeregnOverskytendeTrekk(Tabellnummer tabellnummer, Periode periode, double avrundetTrekkgrunnlag)
    {
        if (periode.maxTrekkgrunnlag > avrundetTrekkgrunnlag)
        {
            return 0;
        }

        double overskytendeTrekk =
                (avrundetTrekkgrunnlag - periode.maxTrekkgrunnlag) * tabellnummer.OverskytendeProsent / 100d;

        return (long)Math.Round(overskytendeTrekk);
    }
}
