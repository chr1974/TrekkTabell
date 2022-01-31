// Søndag 30 Januar 2022 
// Konvertert fra Java til C# av Christian Haugland - haugland.christian@gmail.com
// Koden er konvertert ganske raskt og trengs litt opprydning når det kommer til
// C# Naming conventions og Deklarering av internal/ public / private accessors

// Orginal Java kode kan finnes hos skatteetatens github her -> https://github.com/Skatteetaten/trekktabell

using NUnit.Framework;
using No.Skatteetaten.Fastsetting.Formuenntekt.Forskudd.Trekkrutine2022;
using System.Diagnostics;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using J2N.Collections.Generic;
using J2N.Text;

namespace TrekkTabellLib.Test;

public class TrekkrutineTest
{    

    [Test]
    public void SkalReturnere_0_VedTrekkGrunnlagLik_0()
    {
        long beregnetTrekk = Trekkrutine.BeregnTabelltrekk(Tabellnummer.TABELL_7100, Periode.PERIODE_1_MAANED, 0L);
        Assert.AreEqual(0, beregnetTrekk);
    }

    [Test]
    public void TrekketSkalVaereMindreEllerLikTrekkgrunnlag2()
    {
        try
        {
            foreach (Tabellnummer tabellnummer in Tabellnummer.Values)
            {
                foreach(Periode periode in Periode.Values)
                {
                    for (long trekkgrunnlag = 10L; trekkgrunnlag < 1000L; trekkgrunnlag += 166)
                    {
                        long beregnetTrekk = Trekkrutine.BeregnTabelltrekk(tabellnummer, periode, trekkgrunnlag);
                        Assert.True(trekkgrunnlag >= beregnetTrekk);
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.Print(ex.Message);
        }
    }

    [Test]
    public void SkalIkkeHaTrygdeAvgift()
    {
        foreach(Tabellnummer tabellnummer in Tabellnummer.Values)
        {
            for (double inntekt = 10d; inntekt < 1000000L; inntekt+=16666)
            {
                if (tabellnummer.IkkeTrygdeavgift())
                {
                    long trygdeavgift = Skatteberegning.BeregnTrygdeavgift(tabellnummer, inntekt);
                    Assert.AreEqual(0L, trygdeavgift);
                }
            }
        }
    }

    [Test]
    public void OverskytendeTrekkSkalVaereStorreEnn0()
    {
        try
        {
            foreach (Tabellnummer tabellnummer in Tabellnummer.Values)
            {
                foreach (Periode periode in Periode.Values)
                {
                    for (double trekkgrunnlag = 1000L; trekkgrunnlag < 100000; trekkgrunnlag += 166)
                    {
                        if(trekkgrunnlag > periode.maxTrekkgrunnlag)
                        {
                            long overskytendeTrekk = Skatteberegning.BeregnOverskytendeTrekk(tabellnummer, periode, trekkgrunnlag);
                            Assert.IsTrue(overskytendeTrekk > 0L);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);
        }
    }

    [Test]
    public void KontrollerBeregningAvLavGrenseTrygdeAvgift()
    {
        try
        {
            long grenseTrygdeavgiftLavSats = Konstanter.BeregnLavGrenseTrygdeavgift();
            Assert.AreEqual(81219L, grenseTrygdeavgiftLavSats);
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);
        }
    }

    [Test]
    public void KontrollerBeregningAvHoyGrenseTrygdeAvgift()
    {
        long grenseTrygdeAvgiftHoySats = Konstanter.BeregnHoyGrenseTrygdeavgift();
        Assert.AreEqual(95074L, grenseTrygdeAvgiftHoySats);
    }

    [Test]
    public void KontrollerHeleTabellenAlle()
    {
        try
        {
            foreach (Tabellnummer tabellnummer in Tabellnummer.Values)
            {
                foreach (Periode periode in Periode.Values)
                {
                    HeleTabellen heletabellen = Trekkrutine.BeregnHeleTabellen(tabellnummer, periode);
                    Assert.IsTrue(heletabellen.alleTrekk.Count > 100);
                    Assert.IsTrue(heletabellen.overskytendeProsent > 30);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);            
        }
    }

    [Test]
    public void KontrollerAtMaxEttTrekkgrunnlagMed0ITrekkVedHeleTabellen()
    {
        try
        {
            foreach (Tabellnummer tabellnummer in Tabellnummer.Values)
            {
                foreach (Periode periode in Periode.Values)
                {
                    HeleTabellen heletabellen = Trekkrutine.BeregnHeleTabellen(tabellnummer, periode);
                    long antallMed0 = heletabellen.alleTrekk.Values.Where(trekk => trekk == 0).Count();
                    Assert.IsTrue(antallMed0 < 2);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);            
        }
    }

    [Test]
    public void KontrollerEndredeOverskytendeProsenter()
    {
        try
        {
            HeleTabellen heletabellen = Trekkrutine.BeregnHeleTabellen(Tabellnummer.TABELL_7100, Periode.PERIODE_1_MAANED);
            Assert.AreEqual(heletabellen.overskytendeProsent, 54);

            heletabellen = Trekkrutine.BeregnHeleTabellen(Tabellnummer.TABELL_7300, Periode.PERIODE_1_MAANED);
            Assert.AreEqual(heletabellen.overskytendeProsent, 54);

            heletabellen = Trekkrutine.BeregnHeleTabellen(Tabellnummer.TABELL_6300, Periode.PERIODE_1_MAANED);
            Assert.AreEqual(heletabellen.overskytendeProsent, 50);
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);            
        }
    }

    [Test]
    public void KontrollerAvrundingVedOverskytendeTrekk()
    {
        try
        {
            long beregnetTrekk = Trekkrutine.BeregnTabelltrekk(Tabellnummer.TABELL_7100, Periode.PERIODE_1_MAANED, 109700);
            long beregnetTrekk2 = Trekkrutine.BeregnTabelltrekk(Tabellnummer.TABELL_7100, Periode.PERIODE_1_MAANED, 109799);
            Assert.AreEqual(beregnetTrekk, beregnetTrekk2);
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);
        }
    }

    [Test, Ignore("Test passerer, ignorer så vi ikke skriver til disk hver gang vi kjører testen")]
    public void TrekkTabellerTilManuellKontroll()
    {
        try
        {
            using (StreamWriter sw = new StreamWriter("alleTabellerFraCSharp.txt"))
            {
                foreach (Tabellnummer tabellnummer in Tabellnummer.Values)
                {
                    foreach (Periode periode in Periode.Values)
                    {
                        HeleTabellen heletabellen = Trekkrutine.BeregnHeleTabellen(tabellnummer, periode);
                        sw.Write($"TABELLNR: {tabellnummer.GetName()} - PERIODE: {periode.GetName()}\n");
                        LinkedDictionary<long, long> alletrekk = heletabellen.alleTrekk;

                        // her brukes _ i front av variabler som er like i blokken under da de har lokal scope 
                        foreach (long _grl in alletrekk.Keys)
                        {
                            long _trekk = alletrekk.GetValueOrDefault(_grl);
                            sw.Write($"{_grl} {_trekk}\n");
                        }

                        int grl = periode.maxTrekkgrunnlag + 2000;
                        long trekk = Trekkrutine.BeregnTabelltrekk(tabellnummer, periode, grl);
                        sw.Write($"{grl} {trekk}\n");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);
        }
    }

    [Test, Ignore("Test passerer, ignorer så vi ikke skriver til disk hver gang vi kjører testen")]
    public void TrekkTabellerTilFilPaaGammeltFormat()
    {
        try
        {
            using (StreamWriter sw = new StreamWriter("trekkTabellerPaaGammeltFormat.txt"))
            {
                int teller = 0;

                foreach (Tabellnummer tabellnummer in Tabellnummer.Values)
                {
                    foreach (Periode periode in Periode.Values)
                    {
                        HeleTabellen heletabellen = Trekkrutine.BeregnHeleTabellen(tabellnummer, periode);
                        char per = FinnPeriode(periode);
                        char tabType = FinnTabelltype(tabellnummer.tabelltype);

                        LinkedDictionary<long, long> alletrekk = heletabellen.alleTrekk;

                        foreach (long grl in alletrekk.Keys)
                        {
                            string _name = tabellnummer.GetName();
                            int startindex = 7;
                            int endindex = _name.Length;
                            int length = endindex - startindex;
                            _name = _name.Substring(startindex, length);
                            long trekk = alletrekk.GetValueOrDefault(grl);
                            sw.Write($"1{_name}{per}{tabType}{grl.ToString("D6")}{trekk.ToString("D6")}\n");
                            teller++;
                        }
                    }
                }

                Debug.Print($"Skrevet til fil: {teller}");
            }
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);
        }
    }

    [Test, Ignore("Test passerer, ignorer så vi ikke skriver til disk hver gang vi kjører testen")]
    public void TrekkTabellerTilSkatteetatenNo()
    {
        try
        {
            using (StreamWriter sw = new StreamWriter("alleTabelleneIEnFilTilSkatteetatenNo.txt"))
            {
                int teller = 0;

                foreach (Tabellnummer tabellnummer in Tabellnummer.Values)
                {
                    if (AktuellTabell(tabellnummer))
                    {
                        foreach (Periode periode in Periode.Values)
                        {
                            if (AktuellPeriode(tabellnummer, periode))
                            {
                                HeleTabellen heletabellen = Trekkrutine.BeregnHeleTabellen(tabellnummer, periode);
                                char per = FinnPeriode(periode);
                                char tabType = FinnTabelltype(tabellnummer.tabelltype);

                                LinkedDictionary<long, long> alletrekk = heletabellen.alleTrekk;

                                foreach (long grl in alletrekk.Keys)
                                {
                                    string _name = tabellnummer.GetName();
                                    int startindex = 7;
                                    int endindex = _name.Length;
                                    int length = endindex - startindex;
                                    _name = _name.Substring(startindex, length);

                                    long trekk = alletrekk.GetValueOrDefault(grl);
                                    sw.Write($"{_name}{per}{tabType}{grl.ToString("D5")}{trekk.ToString("D5")}\r\n");
                                    teller++;
                                }
                            }
                        }
                    }
                }

                Debug.Print($"Skrevet til fil: {teller}");
            }
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);
        }
    }

    // Hjelpefunksjoner
    private char FinnPeriode(Periode periode)
    {
        var name = periode.ToString();
        Debug.Print(name);
        switch (periode.GetName())
        {
            case "PERIODE_1_MAANED":
                return '1';
            case "PERIODE_14_DAGER":
                return '2';
            case "PERIODE_1_UKE":
                return '3';
            case "PERIODE_4_DAGER":
                return '4';
            case "PERIODE_3_DAGER":
                return '5';
            case "PERIODE_2_DAGER":
                return '6';
            case "PERIODE_1_DAG":
                return '7';
        }
        throw new ArgumentException("Ugyldig periode !");
    }

    private char FinnTabelltype(Tabelltype tabelltype)
    {
        if (tabelltype == Tabelltype.PENSJONIST)
        {
            return '1';
        }
        return '0';
    }

    private bool AktuellTabell(Tabellnummer tabellnummer)
    {
        string tabellnavn = tabellnummer.GetName();
        if (tabellnavn.StartsWith("TABELL_72") || tabellnavn.StartsWith("TABELL_02") || tabellnavn.StartsWith("TABELL_64") ||
            tabellnavn.StartsWith("TABELL_66") || tabellnavn.StartsWith("TABELL_68") || tabellnavn.StartsWith("TABELL_74") ||
            tabellnavn.StartsWith("TABELL_76") || tabellnavn.StartsWith("TABELL_78"))
        {
            return false;
        }
            return true;
    }

    private bool AktuellPeriode(Tabellnummer tabellnummer, Periode periode)
    {
        if (tabellnummer.tabelltype == Tabelltype.PENSJONIST)
        {
            return periode == Periode.PERIODE_1_MAANED;
        }
        if (tabellnummer.tabelltype == Tabelltype.SJØ)
        {
            return periode == Periode.PERIODE_1_MAANED || periode == Periode.PERIODE_14_DAGER ||
                periode == Periode.PERIODE_1_UKE;
        }

        return true;
    }
}
