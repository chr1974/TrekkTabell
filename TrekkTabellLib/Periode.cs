// Søndag 30 Januar 2022 
// Konvertert fra Java til C# av Christian Haugland - haugland.christian@gmail.com
// Koden er konvertert ganske raskt og trengs litt opprydning når det kommer til
// C# Naming conventions og Deklarering av internal/ public / private accessors

// Orginal Java kode kan finnes hos skatteetatens github her -> https://github.com/Skatteetaten/trekktabell

namespace No.Skatteetaten.Fastsetting.Formuenntekt.Forskudd.Trekkrutine2022;

public class Periode
{
    public static Periode PERIODE_1_MAANED { get { return new Periode("PERIODE_1_MAANED", 12.12d, 10.5d, 12d, 11d, 12d, 10.5d, 100, 99800); } }
    public static Periode PERIODE_14_DAGER { get { return new Periode("PERIODE_14_DAGER", 26.26d, 23d, 26d, 24d, 26d, 23d, 50, 46000); } }
    public static Periode PERIODE_1_UKE { get { return new Periode("PERIODE_1_UKE", 52.52d, 46d, 52d, 48d, 52d, 46d, 20, 23000); } }
    public static Periode PERIODE_4_DAGER { get { return new Periode("PERIODE_4_DAGER", 60.60d, (60d * 46d) / 52d, 91d, (91d * 11d) / 12d, 91d, (91d * 10.5d) / 12d, 20, 19900); } }
    public static Periode PERIODE_3_DAGER { get { return new Periode("PERIODE_3_DAGER", 80.80d, (80d * 46d) / 52d, 122d, (122d * 11d) / 12d, 122d, (122d * 10.5d) / 12d, 20, 14900); } }
    public static Periode PERIODE_2_DAGER { get { return new Periode("PERIODE_2_DAGER", 121.20d, (120d * 46d) / 52d, 183d, (183d * 11d) / 12d, 183d, (183d * 10.5d) / 12d, 20, 9900); } }
    public static Periode PERIODE_1_DAG { get { return new Periode("PERIODE_1_DAG", 242.40d, (240d * 46d) / 52d, 365d, (365d * 11d) / 12d, 365d, (365d * 10.5d) / 12d, 20, 4900); } }

    public static List<Periode> Values = new List<Periode>() {
        PERIODE_1_MAANED, PERIODE_14_DAGER, PERIODE_1_UKE, PERIODE_4_DAGER,
        PERIODE_3_DAGER, PERIODE_2_DAGER, PERIODE_1_DAG
    };

    internal readonly string name;
    internal readonly double inntektsPeriode;
    internal readonly double trekkPeriode;
    internal readonly double inntektsPeriodePensjon;
    internal readonly double trekkPeriodePensjon;
    internal readonly double inntektsPeriodeStandardfradrag;
    internal readonly double trekkPeriodeStandardfradrag;
    internal readonly int avrunding;
    public readonly int maxTrekkgrunnlag;



    public Periode(string name, double inntektsPeriode, double trekkPeriode,
            double inntektsPeriodePensjon, double trekkPeriodePensjon,
            double inntektsPeriodeStandardfradrag, double trekkPeriodeStandardfradrag,
            int avrunding,
            int maxTrekkgrunnlag)
    {
        this.name = name;
        this.inntektsPeriode = inntektsPeriode;
        this.trekkPeriode = trekkPeriode;
        this.inntektsPeriodePensjon = inntektsPeriodePensjon;
        this.trekkPeriodePensjon = trekkPeriodePensjon;
        this.inntektsPeriodeStandardfradrag = inntektsPeriodeStandardfradrag;
        this.trekkPeriodeStandardfradrag = trekkPeriodeStandardfradrag;
        this.avrunding = avrunding;
        this.maxTrekkgrunnlag = maxTrekkgrunnlag;
    }

    public string GetName()
    {
        return name;
    }

    internal double GetInntektsPeriode(Tabellnummer tabellnummer)
    {
        if (tabellnummer.tabelltype == Tabelltype.PENSJONIST) return this.inntektsPeriodePensjon;
        if (tabellnummer.tabelltype == Tabelltype.VANLIG) return this.inntektsPeriode;

        return this.inntektsPeriodeStandardfradrag;
    }

    internal double GetTrekkPeriode(Tabellnummer tabellnummer)
    {
        if (tabellnummer.tabelltype == Tabelltype.PENSJONIST) return this.trekkPeriodePensjon;
        if (tabellnummer.tabelltype == Tabelltype.VANLIG) return this.trekkPeriode;

        if (tabellnummer.trekk_i_12_mnd) return this.inntektsPeriodeStandardfradrag; // Hvis 12-måneders-trekk, skal inntektsperioden returneres !

        return this.trekkPeriodeStandardfradrag;
    }
}