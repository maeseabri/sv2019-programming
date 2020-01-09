// Title Class + Array

/*
Create an array of 3 "Title"
*/

using System;

class Title
{
    protected string text;
    protected int x;
    protected int y;

    public Title() : this (40, 12, "Welcome!!!")
    {
    }
    
    public Title(string text) : this (40, 12, text)
    {
    }

    public Title(int x, int y, string text)
    {
        this.x = x;
        this.y = y;
        this.text = text;
    }

    public int GetX()
    {
        return x;
    }

    public void SetX(int newX)
    {
        x = newX;
    }

    public int GetY()
    {
        return y;
    }

    public void SetY(int newY)
    {
        y = newY;
    }

    public string GetText()
    {
        return text;
    }

    public void SetText(string newText)
    {
        text = newText;
    }

    public virtual void Display()
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(text);
    }
}

// ----------------

class TitleUnderlined : Title
{
    public TitleUnderlined(int x, int y, string text)
        : base(x, y, text)
    {
    }
    
    public override void Display()
    {
        base.Display();
        Console.SetCursorPosition(x, y+1);
        for (int i = 0; i < text.Length; i++)
            Console.Write("_");
    }
}

// ----------------


class TitleTest
{
    static void Main()
    {
        Title[] titles = new Title[6];
        titles[0] = new Title();
        for (int i = 1; i < 3; i++)
            titles[i] = new Title(4, 5+i, "Hi!");
        for (int i = 3; i < 6; i++)
            titles[i] = new TitleUnderlined(10, 5+i*2, "Hi Underlined!");

        for (int i = 0; i < 6; i++)
            titles[i].Display();
    }
}
