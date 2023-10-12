using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Creature
{
    public string cellType;

    public void PrintCellType()
    {
        Debug.Log(cellType);
    }
}

public interface IFastRunnable
{
    public void RunFast();
}

public class Plant : Creature
{
    public string rootType;
    public int leafCount;
}

public class FloweringPlant : Plant
{
    public string crownLeafColor;
    public string sepalColor;
}

public class Human : Creature, IFastRunnable
{
    public string hairColor;
    public string skinColor;

    public void RunFast()
    {

    }
}

public class Animal: Creature
{
    public string birthType;
    public bool hasTail;
    public string faceType;
}

public class Feline : Animal
{
    public float whiskerLength;
    public bool canSeeAtNight;
    public string pawType;
}

public class Cheetah : Feline , IFastRunnable
{
    public void RunFast()
    {

    }
}

public class Lion : Feline
{
    public string maneColor;
}

public static class Program
{
    public static void Main()
    {
        List<Feline> felines = new List<Feline>();
        Lion lion1 = new Lion();
        Cheetah cheetah1 = new Cheetah();
        Human human1 = new Human();

        felines.Add(lion1); //Cheetah, Feline sınıfından türediği için bu listeye eklenebilir, hata vermez.
        felines.Add(cheetah1); //Cheetah, Feline sınıfından türediği için bu listeye eklenebilir, hata vermez.

        //----------------------------------------------------------------------------

        Feline feline1 = new Cheetah(); //Cheetah, Feline sınıfından türediği için bu referansla(etiketle) referanslanabilir, hata vermez.
        Animal animal2 = new Lion(); //Lion da, Feline sınıfından türediği için bu referansla(etiketle) referanslanabilir, hata vermez.
        //Cheetah cheetah2 = new Animal(); //Her Animal'ın Cheetah olması gibi bir zorunluluk olmadığından, cheetah referansına (etiketine), sadece Animal olduğunu bildiğimiz bir obje verilemez.


        IFastRunnable fastRunner = new Human(); //Human, IFastRunnable interface'inden kalıtıldığı için bu etiketle etiketlenebilir.
        fastRunner.RunFast(); //Fakat IFastRunnable türünden bir referansta, sadece IFastRunnable interface'inden alınan özelliklere ulaşılabilir. Human'ın diğer özelliklerine ulaşılamaz.

        List<IFastRunnable> fastRunners = new List<IFastRunnable>();
        fastRunners.Add(cheetah1); //Cheetah, IFastRunnable interface'inden kalıtıldığı için bu listeye eklenebilir, hata vermez.
        // fastRunners.Add(lion1); //Human, IFastRunnable interface'inden kalıtılmadığı için bu listeye eklenemez, hata verir.
        fastRunners.Add(human1); //Human, IFastRunnable interface'inden kalıtıldığı için bu listeye eklenebilir, hata vermez.

        fastRunners[0].RunFast();

        

    }
}