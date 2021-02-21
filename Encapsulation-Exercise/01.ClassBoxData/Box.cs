
using System;
using System.Runtime.InteropServices;
using System.Text;

public class Box
{
    const string ARG_EXC = "{0} cannot be zero or negative.";
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get
        {
            return this.length;
        }
        private set
        {
            ValidateSide(value, nameof(Length));
            this.length = value;
        }
    }
    public double Width
    {
        get
        {
            return this.Width;
        }
        private set
        {
            ValidateSide(value, nameof(Width));
            this.width = value;
        }
    }
    public double Height
    {
        get
        {
            return this.Height;
        }
        private set
        {
            ValidateSide(value, nameof(Height));
            this.height = value;
        }
    }

    public double SurfacAarea()
    {
        //2lw + 2lh + 2wh
        return (this.length * this.width) * 2 + (this.length * this.height) * 2 + (this.width * this.height) * 2;
    }

    public double LateralSurfaceArea()
    {
        return (this.length * this.height) * 2 + (this.width * this.height)*2;
    }

    public double Volume()
    {
        return this.length * this.height * this.width;
    }

    public void ValidateSide(double side,string paramName)
    {
        if (side<=0)
        {
            throw new ArgumentException(string.Format(ARG_EXC, paramName));
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"Surface Area - {this.SurfacAarea():F2}");
        result.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}");
        result.AppendLine($"Volume - {this.Volume():F2}");

        return result.ToString().TrimEnd();
    }
}

