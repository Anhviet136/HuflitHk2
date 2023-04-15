using System;
using FRACTION;
using REC_DATE;
using BOOK;
using STUDENT;
class Part1
{
    public static void Bai1()
    {
        STUDENT.Student chosHuy = new STUDENT.Student();
        STUDENT.Student lozHanh = new STUDENT.Student("22dhblabla", "Hong Hanh", 2004, true, "Th110");

        Console.WriteLine($"Id: {lozHanh.stdID}");
        lozHanh.stdName = "Huynh Hong Hanh";
        lozHanh.PrintInfo();

        chosHuy.BirthYear = 2014;
        chosHuy.PrintInfo();
        chosHuy.Input();
        chosHuy.PrintInfo();

    }
    public static void Bai2()
    {
        Fraction a = new Fraction();
        Fraction b = new Fraction(3, 4);

        a.Numerator = 4;
        a.Denominator = 8;
        Fraction sum = a.Add(b);
        Fraction sub = a.Subtract(b);
        // Fraction div = a.Divide(b);

        System.Console.WriteLine(sum.ToStr());
        System.Console.WriteLine(sub.ToStr());
        // System.Console.WriteLine(div.ToString());
    }
    public static void Bai3()
    {
        Rectangle a = new Rectangle(3.2, 4);
        Console.WriteLine("A area: " + a.GetArea());

        Rectangle b = new Rectangle();
        b.Height = 4;
        b.Width = 3.2;
        Console.WriteLine("B area: " + b.GetArea());
        System.Console.WriteLine("B perimeter: " + b.GetPerimeter());
        Console.WriteLine(a.IsSameArea(b));
        Console.ReadKey();
    }
    public static void Bai4()
    {
        Date now = new Date(13, 3, 2023);
        Date GuraBirthDay = new Date();

        GuraBirthDay.Day = 20;
        GuraBirthDay.Month = 6;
        GuraBirthDay.Year = 2020;

        // GuraBirthDay.ToString();
        // now.ToString();
        System.Console.WriteLine("curent date: " + now.ToStr());
        System.Console.WriteLine("Gura birth day: " + GuraBirthDay.ToStr());

    }
    public static void Bai5()
    {
        Author cunnyUwU = new Author("Cunny luver", "clone@bunbo.com", 'm');
        Author Gura = new Author();
        Gura.Email = "gura@gmail.com";
        Gura.Name = "Gawr Gura";
        Gura.Gender = 'f';

        Book firstBook = new Book("A day without cunny :((", cunnyUwU, 999);
        Book guraBook = new Book("Become an Idol ?", Gura, 99999, 20);


        System.Console.WriteLine(cunnyUwU.ToStr());
        System.Console.WriteLine(Gura.ToStr());
        System.Console.WriteLine(firstBook.ToStr());
        System.Console.WriteLine(guraBook.ToStr());
        System.Console.WriteLine();
        System.Console.WriteLine($"{guraBook.Author.ToStr()}");
    }
}
class Program
{

    static void Main()
    {
        //Part1.Bai1();
       // Part1.Bai2();
       // Part1.Bai3();
        Part1.Bai4();
       // Part1.Bai5();
        // Part2.Bai1();
        // Part3.Bai1();
    }

}
namespace STUDENT {
    class Student
    {
        string studentID;
        string name;
        private int birthYear;
        bool gender; //true male, false female
        string stdClass;

        //
        public Student() { }
        public Student(string studenID, string name, int birthYear, bool gender, string stdClass)
        {
            this.studentID = studenID;
            this.name = name;
            int curYear = DateTime.Now.Year;
            if (birthYear < 1900 || birthYear > curYear)
                this.birthYear = 1900;
            else
                this.birthYear = birthYear;

            this.gender = gender;
            this.stdClass = stdClass;
        }

        public int BirthYear
        {
            get { return birthYear; }
            set
            {
                int curYear = DateTime.Now.Year;
                if (value < 1900 || value > curYear)
                {
                    System.Console.WriteLine("Invalid birth year!!\nset to 1900");
                    this.birthYear = 1900;
                }
                else
                    this.birthYear = value;
            }
        }
        public string stdID
        {
            get { return studentID; }
            set
            {
                this.studentID = value;
            }
        }
        public string stdName
        {
            get { return name; }
            set
            {
                this.name = value;
            }
        }
        public string StdClass
        {
            get { return stdClass; }
            set
            {
                this.stdClass = value;
            }
        }
        public bool stdGender
        {
            get { return gender; }
            set
            {
                this.gender = value;
            }
        }
        public void Input()
        {
            System.Console.Write("student ID: ");
            this.studentID = Console.ReadLine();
            System.Console.Write("Name: ");
            this.name = Console.ReadLine();

            int curYear = DateTime.Now.Year;
            do
            {
                System.Console.Write("Birth Year: ");
                this.birthYear = int.Parse(Console.ReadLine());
            } while (birthYear < 1900 || birthYear > curYear);

            System.Console.Write("Gender: ");
            this.gender = bool.Parse(Console.ReadLine());

            System.Console.Write("Class: ");
            this.stdClass = Console.ReadLine();
        }
        public int GetAge()
        {
            int curYear = DateTime.Now.Year;
            return curYear - this.birthYear;
        }
        public void PrintInfo()
        {
            System.Console.WriteLine($"Student ID: {studentID}\nName: {name}");
            System.Console.Write($"Birth Year: {birthYear}\nGender: ");
            if (gender) System.Console.WriteLine("Nam");
            else System.Console.WriteLine("Nu");
            System.Console.WriteLine($"Class: {stdClass}");
            Console.WriteLine();
        }
    }
}
namespace FRACTION
{
    public class Fraction
    {
        private int numerator;
        private int denominator;
        public Fraction() { }

        public Fraction(int num, int deno)
        {
            Numerator = num;
            Denominator = deno;
            Simplify();
        }
        public Fraction(int numerator)
        {
            this.numerator = numerator;
            this.denominator = 1;
        }
        public int Numerator
        {
            get => numerator;
            set => numerator = value;
        }
        public int Denominator
        {
            get { return denominator; }
            set
            {
                denominator = value;
            }
        }

        public void Simplify()
        {            

            //int [] nums = {numerator,denominator};  
            if (numerator > 0 || denominator > 0)
            {
                int divisor = GCD(numerator, denominator);
                numerator /= divisor;
                denominator /= divisor;
            }
        }
        static int GCD(int a, int b)
        {
            if (b == 0) return a;
            else return GCD(b, a % b);
        }
        public void Input()
        {
            //     string num =Console.ReadLine().S;
            //     string[] num
            System.Console.Write("Numerator / Denominator ");
            numerator = int.Parse(Console.ReadLine());
            denominator = int.Parse(Console.ReadLine());
            Simplify();
        }
        public double Decimal()
        {
            return (double)numerator / denominator;
        }
        public Fraction Add(Fraction p)
        {

            int num = numerator * p.denominator + p.numerator * denominator;
            int deno = denominator * p.denominator;
            Fraction temp = new Fraction(num, deno);
            temp.Simplify();
            return temp;
        }
        public Fraction Subtract(Fraction p)
        {
            int num = (numerator * p.denominator) - p.numerator * denominator;
            int deno = denominator * p.denominator;
            Fraction temp = new Fraction(num, deno);
            temp.Simplify();
            return temp;
        }
        public Fraction Multiply(Fraction p)
        {
            int num = numerator * p.numerator;
            int deno = denominator * p.denominator;
            Fraction temp = new Fraction(num, deno);
            temp.Simplify();
            return temp;
        }
        public Fraction Divide(Fraction p)
        {
            Fraction upSideDown = new Fraction(p.denominator, p.numerator);
            return Multiply(upSideDown);
            /*
            numerator*=p.denominator;
            denominator*=p.numerator; 
            Simplify();
            */
        }
        public string ToStr()
        {
            Simplify();
            return $"{numerator}/{denominator}";
        }

    }
}
namespace REC_DATE {
    public class Rectangle
    {
        protected double width = 0;
        protected double height = 0;

        public Rectangle() { }
        public Rectangle(double width, double height)
        {
            if (width >= 0 && height >= 0)
            {
                this.width = width;
                this.height = height;
            }
        }

        public double Width
        {
            get => width;
            set
            {
                do
                {
                    width = value;
                } while (width < 0);
            }
        }
        public double Height
        {
            get => height;
            set
            {
                do
                {
                    height = value;
                } while (height < 0);
            }
        }
        public void Input()
        {

        }
        public double GetPerimeter()
        {
            return (width + height) * 2;
        }
        public double GetArea()
        {
            return width * height;
        }
        public bool IsSameArea(Rectangle rect)
        {
            if (rect.GetArea() == this.GetArea())
                return true;
            else return false;
        }
    }
    public class Date
    {
        protected int day = 1;
        protected int month = 1;
        protected int year = 2000;
        public Date() { }

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public int Day
        {
            get => day;
            set
            {
                if (day > 0 || day < 32)
                    day = value;
            }
        }
        public int Month
        {
            get => month;
            set
            {
                if (month > 0 || month < 13)
                    month = value;
            }
        }
        public int Year
        {
            get => year;
            set
            {
                if (year >= 1900 || year < 9999)
                    year = value;
            }
        }
        public void SetDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        public string ToStr()
        {
            string eto = $"{day} /{month} /{year}";
            return eto;
            //    System.Console.WriteLine(eto);
        }
    }
}
namespace BOOK
{
    public class Author
    {
        protected string name;
        protected string email;
        protected char gender;

        public Author() { }
        public Author(string name, string email, char gender)
        {
            Name = name;
            Email = email;
            Gender = gender;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Email
        {
            get => email;
            set => email = value;
        }
        public char Gender
        {
            get => gender;
            set
            {
                if (value == 'm')
                    gender = 'm';
                else if (value == 'f')
                    gender = 'f';
                else System.Console.WriteLine("Valid input!!");
            }
        }
        public string ToStr()
        {
            return $"Author: {name}\nEmail: {email}\nGender {gender} ";
        }
    }
    public class Book
    {
        protected string name;
        protected Author author;
        protected double price;
        protected int qty = 0;
        public Book(string name, Author author, double price)
        {
            Name = name;
            Author = author;
            Price = price;
        }
        public Book(string name, Author author, double price, int qty)
        {
            Name = name;
            Author = author;
            Price = price;
            Qty = qty;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        public Author Author
        {
            get => author;
            set => author = value;
        }
        public double Price
        {
            get => price;
            set => price = value;
        }
        public int Qty
        {
            get => qty;
            set => qty = value;
        }
        public string ToStr()
        {
            return $"Book: {name}\n{Author.ToStr()}\n Price: {price}\t Qty: {qty}";
        }

    }
}




