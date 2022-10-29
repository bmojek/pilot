using System;


public interface ITelewizor
{

    int Kanal { get; set; }
    void Wlacz();
    void Wylacz();
    void ZmienKanal(int kanal);

}



public class TvLg : ITelewizor
{

    public TvLg()
    {
        this.Kanal = 1;
    }

    public int Kanal { get; set; }

    public void Wlacz()
    {

        Console.WriteLine("Telewizor LG - włączam się.");
    }

    public void Wylacz()
    {
        Console.WriteLine("Telewizor LG - wyłączam się.");
    }

    public void ZmienKanal(int kanal)
    {
        Kanal = kanal;
    }

}



public class TvXiaomi : ITelewizor
{

    public TvXiaomi()
    {
        this.Kanal = 1;
    }

    public int Kanal { get; set; }

    public void Wlacz()
    {
        Console.WriteLine("Telewizor Xiaomi włączony.");
    }

    public void Wylacz()
    {
        Console.WriteLine("Telewizor Xiaomi - wyłączam się.");
    }

    public void ZmienKanal(int kanal)
    {
        Kanal = kanal;
    }

}



public abstract class PilotAbstrakcyjny
{

    private ITelewizor tv;

    public PilotAbstrakcyjny(ITelewizor tv)
    {
        this.tv = tv;
    }

    public void Wlacz()
    {
        tv.Wlacz();
    }

    public void Wylacz()
    {
        tv.Wylacz();
    }

    public void ZmienKanal(int kanal)
    {
        tv.Kanal = kanal;
    }
    public void SprawdzKanal()
    {
        Console.WriteLine("Sprawdź kanał - bieżący kanał: " + tv.Kanal);
    }
}



public class PilotHarmony : PilotAbstrakcyjny
{

    public PilotHarmony(ITelewizor tv) : base(tv) { }

    public void DoWlacz()
    {
        Console.WriteLine("Pilot Harmony włącza telewizor...");
        Wlacz();
    }


    public void DoWylacz()
    {
        Console.WriteLine("Pilot Philips wyłącza telewizor...");
        Wylacz();
    }


}

public class PilotPhilips : PilotAbstrakcyjny
{
    private ITelewizor tv;
    public PilotPhilips(ITelewizor tv) : base(tv)
    {
        this.tv = tv;
    }

    public void DoWlacz()
    {
        Console.WriteLine("Pilot Harmony włącza telewizor...");
        Wlacz();
    }

    public void DoWylacz()
    {
        Console.WriteLine("Pilot Philips wyłącza telewizor...");
        Wylacz();
    }

    public void DoZmienKanal(int kanal)
    {
        tv.ZmienKanal(kanal);
    }

}



class MainClass
{
    public static void Main(string[] args)
    {

        ITelewizor tv = new TvLg();
        PilotPhilips pilotPhilips = new PilotPhilips(tv);
        PilotHarmony pilotHarmony = new PilotHarmony(tv);

        pilotHarmony.DoWlacz();
        Console.WriteLine("Kanał: " + tv.Kanal);
        pilotPhilips.DoZmienKanal(100);
        Console.WriteLine("Kanał: " + tv.Kanal);
        pilotHarmony.DoWylacz();

    }
}