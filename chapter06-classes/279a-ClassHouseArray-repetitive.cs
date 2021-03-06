class House
{
    protected int area;
    protected string color;

    public House(float area, string color)
    {
        this.area = (int) area;
        this.color = color;
    }

    public float GetArea() { return area; }
    public string GetColor() { return color; }

    public void SetArea(float area) { this.area = (int)area; }
    public void SetColor(string color) { this.color = color; }

    public virtual void Show()
    {
        System.Console.WriteLine("House: " + color +
            ", " + area + "m2");
    }
}

// --------------

class Flat : House
{
    public Flat() : base(80, "white")
    {
    }

    public override void Show()
    {
        System.Console.WriteLine("Flat: " + color +
            ", " + area + "m2");
    }
}

// --------------

class SmallFlat : Flat
{
    public SmallFlat()
    {
        area = 45;
    }

    public override void Show()
    {
        System.Console.WriteLine("SmallFlat: " + color +
            ", " + area + "m2");
    }
}

// --------------

class HouseTest
{
    static void Main()
    {
        House h = new House( 120, "red");
        Flat flat = new Flat();
        SmallFlat sf = new SmallFlat();

        House[] myHouses = new House[3];
        myHouses[0] = h;
        myHouses[1] = flat;
        myHouses[2] = sf;

        foreach (House house in myHouses)
        {
            house.Show();
        }

        sf.SetColor("yellow");
        sf.SetArea(47);
        sf.Show();
    }
    
}
