// Søndag 30 Januar 2022 
// Konvertert fra Java til C# av Christian Haugland - haugland.christian@gmail.com
// Koden er konvertert ganske raskt og trengs litt opprydning når det kommer til
// C# Naming conventions og Deklarering av internal/ public / private accessors

// Orginal Java kode kan finnes hos skatteetatens github her -> https://github.com/Skatteetaten/trekktabell

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using No.Skatteetaten.Fastsetting.Formuenntekt.Forskudd.Trekkrutine2022;
using NUnit.Framework;

namespace TrekkTabellLibTest;

public class TrekkRutineLikhetsTest
{
    [Test]
    public void LikhetsTestMotAnnenKilde()
    {
        try
        {
            string filename = "trekktabellerFraAnnenKilde.txt";

            using (StreamReader sr = new StreamReader(filename))
            {
                string linje;

                while (!sr.EndOfStream)
                {
                    linje = sr.ReadLine();

                    if (linje.CharAt(0) == '0') break;

                    Tabellnummer tabellnummer = LeggTilPForPensjonistTabeller(linje);
                    Periode periode = HentPeriode(linje);

                    long.TryParse(linje.Substring(6, 5), out long grunnlag);
                    long.TryParse(linje.Substring(11, 5), out long trekk);

                    long beregnetTrekk = Trekkrutine.BeregnTabelltrekk(tabellnummer, periode, grunnlag);
                    long diff = beregnetTrekk - trekk;

                    int maksDiff = 2;

                    if(DifferanseErMerEnn(maksDiff, diff) &! KjenteFeilICobolRutinen(tabellnummer, periode, grunnlag))
                    {
                        NUnit.Framework.Assert.Fail(
                            $"Testen skal ikke ha avvik. {tabellnummer.GetName()}, {periode.GetName()}\n" +
                            $"Grunnlag= {grunnlag}, Beregnet trekk= {beregnetTrekk}, Trekk fra fil= {trekk}, Maks akseptert avik= {maksDiff}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);
        }
    }

    private Periode HentPeriode(string linje)
    {
        char trekkperiodeFraFil = linje.CharAt(4);

        switch(trekkperiodeFraFil)
        {
            case '1': return Periode.PERIODE_1_MAANED;
            case '2': return Periode.PERIODE_14_DAGER;
            case '3': return Periode.PERIODE_1_UKE;
            case '4': return Periode.PERIODE_4_DAGER;
            case '5': return Periode.PERIODE_3_DAGER;
            case '6': return Periode.PERIODE_2_DAGER;
            case '7': return Periode.PERIODE_1_DAG;                                
        }

        throw new Exception("Ugyldig periode i filen !");
    }

    private Tabellnummer? LeggTilPForPensjonistTabeller(string linje)
    {              
        Tabellnummer tabellnummer;
        bool IsCharAt = linje.CharAt(5) == '1';
        string tabellnr = linje.Substring(0, 4);

        if(IsCharAt)
        {
            tabellnummer = (Tabellnummer)Tabellnummer.Values.Where(tn => tn.GetName() == $"TABELL_{tabellnr}P").First();
        }
        else
        {
            tabellnummer = (Tabellnummer)Tabellnummer.Values.Where(tn => tn.GetName() == $"TABELL_{tabellnr}").First();
        }
                        
        return tabellnummer;
    }

    private bool DifferanseErMerEnn(int maksDiff, long diff) => diff > maksDiff || diff < -maksDiff;

    private bool KjenteFeilICobolRutinen(Tabellnummer tabellnummer, Periode periode, long grunnlag) =>
        (tabellnummer == Tabellnummer.TABELL_7131P && periode == Periode.PERIODE_1_MAANED && grunnlag <= 200) || 
        (tabellnummer == Tabellnummer.TABELL_7132P && periode == Periode.PERIODE_1_MAANED && grunnlag == 200);
}
