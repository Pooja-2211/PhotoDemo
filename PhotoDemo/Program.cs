using System;

public class Photo
{
    private int width;
    private int height;

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    public int Height
    {
        get { return height; }
        set { height = value; }
    }

    protected decimal price;

    public decimal Price
    {
        get { return price; }
    }

    public Photo(int width, int height)
    {
        this.width = width;
        this.height = height;
        CalculatePrice();
    }

    protected virtual void CalculatePrice()
    {
        if (width == 8 && height == 10)
            price = 3.99m;
        else if (width == 10 && height == 12)
            price = 5.99m;
        else
            price = 9.99m;
    }

    public virtual void Display()
    {
        Console.WriteLine($"Width: {width} inches");
        Console.WriteLine($"Height: {height} inches");
        Console.WriteLine($"Price: ${price}");
    }
}

public class MattedPhoto : Photo
{
    private string color;

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public MattedPhoto(int width, int height, string color) : base(width, height)
    {
        this.color = color;
        CalculatePrice();
    }

    protected override void CalculatePrice()
    {
        base.CalculatePrice();
        price += 10m;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Color: {color}");
    }
}

public class FramedPhoto : Photo
{
    private string material;
    private string style;

    public string Material
    {
        get { return material; }
        set { material = value; }
    }

    public string Style
    {
        get { return style; }
        set { style = value; }
    }

    public FramedPhoto(int width, int height, string material, string style) : base(width, height)
    {
        this.material = material;
        this.style = style;
        CalculatePrice();
    }

    protected override void CalculatePrice()
    {
        base.CalculatePrice();
        price += 25m;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Material: {material}");
        Console.WriteLine($"Style: {style}");
    }
}

public class PhotoDemo
{
    public static void Main()
    {
        Photo photo1 = new Photo(8, 10);
        photo1.Display();

        Console.WriteLine();

        MattedPhoto mattedPhoto1 = new MattedPhoto(10, 12, "Red");
        mattedPhoto1.Display();

        Console.WriteLine();

        FramedPhoto framedPhoto1 = new FramedPhoto(8, 10, "Silver", "Modern");
        framedPhoto1.Display();
    }
}
