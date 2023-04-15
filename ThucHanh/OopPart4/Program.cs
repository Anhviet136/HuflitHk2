using System;
using SHAPE;

class Program
{
    static void Test(){
        // Shape shape=new Shape("blue",true);
        // Circle circle = shape;
        Circle circle=new Circle();
        circle.Radius=5;
        Rectangle nah=new Rectangle(3,5);
        Square squ=new Square(4);
        squ.Color="violet";
        Rectangle rec=squ;

        string test =$" circle peri {circle.getPerimeter()}"
                    +$"\n circle area {circle.getArea()}"
                    +$"\n rec area {rec.getArea()}"
                    +$"\n rec area {nah.getArea()}"

                    +$"\n squ area {squ.getArea()}"
                    +$"\n squ peri {squ.getPerimeter()}";
        Console.WriteLine(test);
    }
    static void Main(){
        Test();
    }
}

namespace SHAPE
{
    abstract class Shape
    {
        protected string color="";
        protected bool filled=false;
        public Shape (){}
        public Shape (string color, bool filled){
            Color=color;
            Filled=filled;
        }
        public string Color{
            get=> color;
            set=> color=value;
        }
        public bool Filled{
            get=> filled;
            set=> filled=value;
        }
        public abstract double getArea();
        public abstract double getPerimeter();
        public virtual string ToStr(){
            return $"Color: {Color}, IsFilled: {Filled}";
        }
    }
    class Circle :Shape
    {
        protected double radius;
        public double Radius{
            get=> radius;
            set{
            if (value >0)
                radius=value;
            }
        }
        public Circle(){}
        public Circle(double radius, string color, bool filled)
                    :base(color,filled)
        {
            Radius=radius;
            Color=color;
            Filled=filled;
        }
        public override double getArea(){
            return Math.Pow(Radius,2)*Math.PI;
        }
        public override double getPerimeter(){
            return Radius*Math.PI;
        }
        public override string ToStr()
        {
            return $"\tCircle:\nRadius: {Radius}, {base.ToStr()}";
        }
        
    }
    class Rectangle : Shape
    {
        protected double width;
        protected double length;
        public double Width{
            get=> width;
            set {
                if (value >0)
                width=value;
            }
        }
        public double Length{
            get=> length;
            set {
                if (value >0)
                length=value;
            }
        }
        public Rectangle(){}
        public Rectangle(double width,double length)
        {
            Width=width;
            Length=length;
        }
        public Rectangle(double width,double length, string color,bool filled)
                        :base(color,filled)
        {
            Width=width;
            Length=length;
            Color=color;
            Filled=filled;
        }
        public Rectangle(string color,bool filled)
                        :base(color,filled)
        {           
            Color=color;
            Filled=filled;
        }
        public override double getArea()
        {
            return Width*Length;
        }
        public override double getPerimeter()
        {
            return (Width+Length)*2;
        }
        public override string ToStr()
        {
            return $"\tRectangle:\nWidth: {Width},Length: {Length} ,{base.ToStr()}";
        }
    }
    class Square :Rectangle
    {
        public double getSide{
            get=>Length;            
        }
        public Square(){}
        public Square(double side){
            Length=side;
            Width=side;
        }
        public Square(double side, string color, bool filled)
                    :base(color,filled)
        {
            Length=side;
            Width=side;
            Color=color;
            Filled=filled;
        }
        public override string ToStr()
        {
            return $"\tSquare:\nSize: {base.ToStr()}";
        }

    }
}