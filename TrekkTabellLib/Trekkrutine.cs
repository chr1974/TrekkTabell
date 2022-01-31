// Søndag 30 Januar 2022 
// Konvertert fra Java til C# av Christian Haugland - haugland.christian@gmail.com
// Koden er konvertert ganske raskt og trengs litt opprydning når det kommer til
// C# Naming conventions og Deklarering av internal/ public / private accessors

// Orginal Java kode kan finnes hos skatteetatens github her -> https://github.com/Skatteetaten/trekktabell

using J2N.Collections.Generic;

namespace No.Skatteetaten.Fastsetting.Formuenntekt.Forskudd.Trekkrutine2022;

public class Trekkrutine
{
    public static long BeregnTabelltrekk(Tabellnummer tabellnummer, Periode periode, long trekkgrunnlag)
    {
        long avrundetTrekkgrunnlag = FinnAvrundetTrekkgrunnlag(periode, trekkgrunnlag);

        long overskytendeTrekk = Skatteberegning.BeregnOverskytendeTrekk(tabellnummer, periode, avrundetTrekkgrunnlag);

        if (overskytendeTrekk > 0)
            avrundetTrekkgrunnlag = periode.maxTrekkgrunnlag;

        long personInntektAar = (long)Math.Round(avrundetTrekkgrunnlag * periode.GetInntektsPeriode(tabellnummer));

        double alminneligInntektAar = FinnAlminneligInntektAar(tabellnummer, personInntektAar);

        long sumSkatt = BeregnSkatt(tabellnummer, personInntektAar, alminneligInntektAar);

        long trekk = BeregnTrekk(tabellnummer, periode, sumSkatt) + overskytendeTrekk;

        if (trekk > trekkgrunnlag && overskytendeTrekk == 0)
            trekk = trekkgrunnlag;

        return trekk;
    }

    public static HeleTabellen BeregnHeleTabellen(Tabellnummer tabellnummer, Periode periode)
    {
        LinkedDictionary<long, long> alleTrekk = new();
        

        for (long grunnlag = 0; grunnlag <= periode.maxTrekkgrunnlag; grunnlag += periode.avrunding)
        {
            long trekk = BeregnTabelltrekk(tabellnummer, periode, grunnlag);
            if (trekk > 0)
            {
                if (alleTrekk.Count == 0)
                {
                    if ((grunnlag - periode.avrunding) > 0)
                    {
                        alleTrekk.Add(grunnlag - periode.avrunding, 0L);
                    }
                }
                alleTrekk.Add(grunnlag, trekk);
            }
        }

        return new HeleTabellen(alleTrekk, tabellnummer.OverskytendeProsent);
    }

    internal static long FinnAvrundetTrekkgrunnlag(Periode periode, long trekkgrunnlag)
    {
        int avrunding = periode.avrunding;
        return (trekkgrunnlag / avrunding * avrunding) + (avrunding / 2);
    }

    /*
    Finner netto årsinntekt (alminneligInntekt)
    */
    internal static long FinnAlminneligInntektAar(Tabellnummer tabellnummer, long personInntektAar)
    {
        return personInntektAar
                - Fradrag.BeregnMinsteFradrag(tabellnummer, personInntektAar)
                - tabellnummer.tabellFradrag
                - Fradrag.BeregnStandardFradrag(tabellnummer, personInntektAar)
                - Fradrag.BeregnSjoFradrag(tabellnummer, personInntektAar)
                - tabellnummer.klasseFradrag;
    }

    internal static long BeregnSkatt(Tabellnummer tabellnummer, double personInntektAar, double alminneligInntektAar)
    {
        return Skatteberegning.BeregnKommuneskatt(alminneligInntektAar)
                + Skatteberegning.BeregnFelleseskatt(tabellnummer, alminneligInntektAar)
                + Skatteberegning.BeregnTrinnskatt(tabellnummer, personInntektAar)
                + Skatteberegning.BeregnTrygdeavgift(tabellnummer, personInntektAar);
    }

    internal static long BeregnTrekk(Tabellnummer tabellnummer, Periode periode, double sumSkatt)
    {
        double trekkMedDesimaler = sumSkatt / periode.GetTrekkPeriode(tabellnummer);

        return tabellnummer.tabelltype == Tabelltype.SJØ ?
                (long)Math.Floor(trekkMedDesimaler) :
                (long)Math.Round(trekkMedDesimaler);
    }
}
