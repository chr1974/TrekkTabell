// Søndag 30 Januar 2022 
// Konvertert fra Java til C# av Christian Haugland - haugland.christian@gmail.com
// Koden er konvertert ganske raskt og trengs litt opprydning når det kommer til
// C# Naming conventions og Deklarering av internal/ public / private accessors

// Orginal Java kode kan finnes hos skatteetatens github her -> https://github.com/Skatteetaten/trekktabell

namespace No.Skatteetaten.Fastsetting.Formuenntekt.Forskudd.Trekkrutine2022;

public class Tabellnummer
{
    /*
      Når argument nr 2 er et positivt tall, er det et tabellfradrag; når negativt er det et tabelltillegg.
    public*/
    public static readonly Tabellnummer TABELL_7100 = new("TABELL_7100", Tabelltype.VANLIG, 0L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7101 = new("TABELL_7101", Tabelltype.VANLIG, 10000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7102 = new("TABELL_7102", Tabelltype.VANLIG, 20000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7103 = new("TABELL_7103", Tabelltype.VANLIG, 30000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7104 = new("TABELL_7104", Tabelltype.VANLIG, 40000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7105 = new("TABELL_7105", Tabelltype.VANLIG, 50000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7106 = new("TABELL_7106", Tabelltype.VANLIG, 60000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7107 = new("TABELL_7107", Tabelltype.VANLIG, 70000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7108 = new("TABELL_7108", Tabelltype.VANLIG, 80000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7109 = new("TABELL_7109", Tabelltype.VANLIG, 90000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7110 = new("TABELL_7110", Tabelltype.VANLIG, 100000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7111 = new("TABELL_7111", Tabelltype.VANLIG, 110000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7112 = new("TABELL_7112", Tabelltype.VANLIG, 120000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7113 = new("TABELL_7113", Tabelltype.VANLIG, 130000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7114 = new("TABELL_7114", Tabelltype.VANLIG, 140000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7115 = new("TABELL_7115", Tabelltype.VANLIG, 150000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7116 = new("TABELL_7116", Tabelltype.VANLIG, 160000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7117 = new("TABELL_7117", Tabelltype.VANLIG, 170000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7118 = new("TABELL_7118", Tabelltype.VANLIG, 180000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7119 = new("TABELL_7119", Tabelltype.VANLIG, 190000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);

    public static readonly Tabellnummer TABELL_7120 = new("TABELL_7120", Tabelltype.VANLIG, -10000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7121 = new("TABELL_7121", Tabelltype.VANLIG, -20000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7122 = new("TABELL_7122", Tabelltype.VANLIG, -30000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7123 = new("TABELL_7123", Tabelltype.VANLIG, -40000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7124 = new("TABELL_7124", Tabelltype.VANLIG, -50000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7125 = new("TABELL_7125", Tabelltype.VANLIG, -60000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7126 = new("TABELL_7126", Tabelltype.VANLIG, -70000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7127 = new("TABELL_7127", Tabelltype.VANLIG, -80000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7128 = new("TABELL_7128", Tabelltype.VANLIG, -90000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7129 = new("TABELL_7129", Tabelltype.VANLIG, -100000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7130 = new("TABELL_7130", Tabelltype.VANLIG, -110000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7131 = new("TABELL_7131", Tabelltype.VANLIG, -120000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7132 = new("TABELL_7132", Tabelltype.VANLIG, -130000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);
    public static readonly Tabellnummer TABELL_7133 = new("TABELL_7133", Tabelltype.VANLIG, -140000L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_VANLIG);

    public static readonly Tabellnummer TABELL_7100P = new("TABELL_7100P", Tabelltype.PENSJONIST, 0L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7101P = new("TABELL_7101P", Tabelltype.PENSJONIST, 10000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7102P = new("TABELL_7102P", Tabelltype.PENSJONIST, 20000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7103P = new("TABELL_7103P", Tabelltype.PENSJONIST, 30000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7104P = new("TABELL_7104P", Tabelltype.PENSJONIST, 40000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7105P = new("TABELL_7105P", Tabelltype.PENSJONIST, 50000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7106P = new("TABELL_7106P", Tabelltype.PENSJONIST, 60000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7107P = new("TABELL_7107P", Tabelltype.PENSJONIST, 70000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7108P = new("TABELL_7108P", Tabelltype.PENSJONIST, 80000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7109P = new("TABELL_7109P", Tabelltype.PENSJONIST, 90000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7110P = new("TABELL_7110P", Tabelltype.PENSJONIST, 100000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7111P = new("TABELL_7111P", Tabelltype.PENSJONIST, 110000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7112P = new("TABELL_7112P", Tabelltype.PENSJONIST, 120000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7113P = new("TABELL_7113P", Tabelltype.PENSJONIST, 130000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7114P = new("TABELL_7114P", Tabelltype.PENSJONIST, 140000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7115P = new("TABELL_7115P", Tabelltype.PENSJONIST, 150000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7116P = new("TABELL_7116P", Tabelltype.PENSJONIST, 160000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7117P = new("TABELL_7117P", Tabelltype.PENSJONIST, 170000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7118P = new("TABELL_7118P", Tabelltype.PENSJONIST, 180000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7119P = new("TABELL_7119P", Tabelltype.PENSJONIST, 190000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);

    public static readonly Tabellnummer TABELL_7120P = new("TABELL_7120P", Tabelltype.PENSJONIST, -10000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7121P = new("TABELL_7121P", Tabelltype.PENSJONIST, -20000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7122P = new("TABELL_7122P", Tabelltype.PENSJONIST, -30000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7123P = new("TABELL_7123P", Tabelltype.PENSJONIST, -40000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7124P = new("TABELL_7124P", Tabelltype.PENSJONIST, -50000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7125P = new("TABELL_7125P", Tabelltype.PENSJONIST, -60000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7126P = new("TABELL_7126P", Tabelltype.PENSJONIST, -70000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7127P = new("TABELL_7127P", Tabelltype.PENSJONIST, -80000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7128P = new("TABELL_7128P", Tabelltype.PENSJONIST, -90000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7129P = new("TABELL_7129P", Tabelltype.PENSJONIST, -100000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7130P = new("TABELL_7130P", Tabelltype.PENSJONIST, -110000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7131P = new("TABELL_7131P", Tabelltype.PENSJONIST, -120000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7132P = new("TABELL_7132P", Tabelltype.PENSJONIST, -130000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);
    public static readonly Tabellnummer TABELL_7133P = new("TABELL_7133P", Tabelltype.PENSJONIST, -140000L, Konstanter.KLASSE1_VANLIG, "Lav", false, Konstanter.OVERSKYTENDE_PROSENT_PENSJONIST);

    public static readonly Tabellnummer TABELL_7300 = new("TABELL_7300", Tabelltype.STANDARDFRADRAG, 0L, Konstanter.KLASSE1_VANLIG, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_7300);
    public static readonly Tabellnummer TABELL_7350 = new("TABELL_7350", Tabelltype.STANDARDFRADRAG, 0L, Konstanter.KLASSE1_VANLIG, "Høy", true, Konstanter.OVERSKYTENDE_PROSENT_7350);
    public static readonly Tabellnummer TABELL_7500 = new("TABELL_7500", Tabelltype.STANDARDFRADRAG, 0L, Konstanter.KLASSE1_VANLIG, "Ingen", true, Konstanter.OVERSKYTENDE_PROSENT_7500);
    public static readonly Tabellnummer TABELL_7550 = new("TABELL_7550", Tabelltype.STANDARDFRADRAG, 0L, Konstanter.KLASSE1_VANLIG, "Ingen", false, Konstanter.OVERSKYTENDE_PROSENT_7550);
    public static readonly Tabellnummer TABELL_7700 = new("TABELL_7700", Tabelltype.STANDARDFRADRAG, 0L, Konstanter.KLASSE1_VANLIG, "Lav", true, Konstanter.OVERSKYTENDE_PROSENT_7700);

    public static readonly Tabellnummer TABELL_6300 = new("TABELL_6300", Tabelltype.FINNMARK, 0L, Konstanter.KLASSE1_FINNMARK, "Høy", false, Konstanter.OVERSKYTENDE_PROSENT_6300);
    public static readonly Tabellnummer TABELL_6350 = new("TABELL_6350", Tabelltype.FINNMARK, 0L, Konstanter.KLASSE1_FINNMARK, "Høy", true, Konstanter.OVERSKYTENDE_PROSENT_6350);
    public static readonly Tabellnummer TABELL_6500 = new("TABELL_6500", Tabelltype.FINNMARK, 0L, Konstanter.KLASSE1_FINNMARK, "Ingen", true, Konstanter.OVERSKYTENDE_PROSENT_6500);
    public static readonly Tabellnummer TABELL_6550 = new("TABELL_6550", Tabelltype.FINNMARK, 0L, Konstanter.KLASSE1_FINNMARK, "Ingen", false, Konstanter.OVERSKYTENDE_PROSENT_6550);
    public static readonly Tabellnummer TABELL_6700 = new("TABELL_6700", Tabelltype.FINNMARK, 0L, Konstanter.KLASSE1_FINNMARK, "Lav", true, Konstanter.OVERSKYTENDE_PROSENT_6700);

    public static readonly Tabellnummer TABELL_0100 = new("TABELL_0100", Tabelltype.SJØ, 0L, Konstanter.KLASSE1_VANLIG, "Ingen", true, Konstanter.OVERSKYTENDE_PROSENT_0100);
    public static readonly Tabellnummer TABELL_0101 = new("TABELL_0101", Tabelltype.SJØ, 0L, Konstanter.KLASSE1_VANLIG, "Høy", true, Konstanter.OVERSKYTENDE_PROSENT_0101);

    public static readonly Tabellnummer TABELL_7150 = new("TABELL_7150", Tabelltype.SPESIAL, 0L, Konstanter.KLASSE1_VANLIG, "Høy", true, Konstanter.OVERSKYTENDE_PROSENT_7150);
    public static readonly Tabellnummer TABELL_7160 = new("TABELL_7160", Tabelltype.SPESIAL, 0L, Konstanter.KLASSE1_VANLIG, "Ingen", true, Konstanter.OVERSKYTENDE_PROSENT_7160);
    public static readonly Tabellnummer TABELL_7170 = new("TABELL_7170", Tabelltype.SPESIAL, 0L, Konstanter.KLASSE1_VANLIG, "Ingen", false, Konstanter.OVERSKYTENDE_PROSENT_7170);

    public static readonly List<Tabellnummer> Values = new List<Tabellnummer>() 
    {
        TABELL_7100, TABELL_7101, TABELL_7102, TABELL_7103, TABELL_7104,
        TABELL_7105, TABELL_7106, TABELL_7107, TABELL_7108, TABELL_7109,
        TABELL_7110, TABELL_7111, TABELL_7112, TABELL_7113, TABELL_7114,
        TABELL_7115, TABELL_7116, TABELL_7117, TABELL_7118, TABELL_7119,
        TABELL_7120, TABELL_7121, TABELL_7122, TABELL_7123, TABELL_7124,
        TABELL_7125, TABELL_7126, TABELL_7127, TABELL_7128, TABELL_7129,
        TABELL_7130, TABELL_7131, TABELL_7132, TABELL_7133, TABELL_7100,
        TABELL_7101, TABELL_7102, TABELL_7103, TABELL_7104, TABELL_7105,
        TABELL_7106, TABELL_7107, TABELL_7108, TABELL_7109, TABELL_7110,
        TABELL_7111, TABELL_7112, TABELL_7113, TABELL_7114, TABELL_7115,
        TABELL_7116, TABELL_7117, TABELL_7118, TABELL_7119, TABELL_7120,
        TABELL_7121, TABELL_7122, TABELL_7123, TABELL_7124, TABELL_7125,
        TABELL_7126, TABELL_7127, TABELL_7128, TABELL_7129, TABELL_7130,
        TABELL_7131, TABELL_7132, TABELL_7133, TABELL_7300, TABELL_7350,
        TABELL_7500, TABELL_7550, TABELL_7700, TABELL_6300, TABELL_6350,
        TABELL_6500, TABELL_6550, TABELL_6700, TABELL_0100, TABELL_0101,
        TABELL_7150, TABELL_7160, TABELL_7170
    };

    public readonly Tabelltype tabelltype;
    internal readonly long tabellFradrag;
    internal readonly long klasseFradrag;
    internal readonly string trygdeavgiftstype;
    internal readonly bool trekk_i_12_mnd;
    internal readonly string name;
    internal readonly int OverskytendeProsent;



    Tabellnummer(string name, Tabelltype tabelltype, long tabellFradrag, long klasseFradrag, string trygdeavgiftstype,
            bool trekk_i_12_mnd, int overskytendeProsent)
    {
        this.tabelltype = tabelltype;
        this.tabellFradrag = tabellFradrag;
        this.klasseFradrag = klasseFradrag;
        this.trygdeavgiftstype = trygdeavgiftstype;
        this.trekk_i_12_mnd = trekk_i_12_mnd;
        OverskytendeProsent = overskytendeProsent;
        this.name = name;
    }

    public string GetName()
    {
        return this.name;
    }

    public bool IsStandardFradrag()
    {
        return (this.tabelltype == Tabelltype.STANDARDFRADRAG ||
                this.tabelltype == Tabelltype.SJØ ||
                this.tabelltype == Tabelltype.FINNMARK);
    }

    public bool IkkeTrygdeavgift()
    {
        return this.trygdeavgiftstype.Equals("Ingen");
    }
    public bool LavSatsTrygdeavgift()
    {
        return this.trygdeavgiftstype.Equals("Lav");
    }
}
