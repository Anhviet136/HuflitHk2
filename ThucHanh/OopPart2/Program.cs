using System;
using PERSON;
using FRACTION;

class Part2
{
    public static void Bai1(){
        Person shrimp = new Person();
        shrimp.BirthYear=2004;
        shrimp.Name="Shirm lord";
        Console.WriteLine("Shrimp age: "+shrimp.GetAge());
        System.Console.WriteLine(shrimp.ToStr());

        PERSON.Student Lucy = new PERSON.Student("Lucy ka", 2002, "su van hanh", "Cntt", 2022);
        Staff baoZe = new Staff();
        baoZe.Name = "Ho va ten :>";
        Lucy.ChangeProgram="Vua moi nghe";
        System.Console.WriteLine(Lucy.ToStr());
        System.Console.WriteLine(baoZe.ToStr());

    }
    public static void Bai2(){
        Fraction frac =new Fraction(7,4);
        MixedFraction mixfrac = new MixedFraction(frac);

        System.Console.WriteLine(frac.ToStr());
        System.Console.WriteLine(mixfrac.ToStr());
    }
}
class Program
{

    static void Main()
    {
        Part2.Bai1();
    }
}

namespace FRACTION{
public class Fraction
{
    private int numerator;
    private int denominator;
    public Fraction(){}

    public Fraction(int num, int deno)
    {
        Numerator=num;
        Denominator=deno;
        Simplify();
    }
    public Fraction(int numerator)    
    {
        this.numerator=numerator;
        this.denominator=1;
    }
    public int Numerator
    {
        get => numerator;
        set => numerator=value;                
    }
    public int Denominator
    {
        get {return denominator;}
        set {
            denominator=value;
        }
    }
    
    public void Simplify()
    {
        static int GCD (int a, int b)
        {                 
            if (a==0) return b;
            else if (b==0) return a;
            else {
            if (a>b)     
                return GCD(b,a%b);      
            else         
                return GCD(a,b%a);            
            }
        }
        
        //int [] nums = {numerator,denominator};  
        if (numerator >0 || denominator >0)  
        {
            int divisor=GCD(numerator,denominator);        
            numerator/=divisor;
            denominator/=divisor;
        }    
    }
    public void Input ()
    {
    //     string num =Console.ReadLine().S;
    //     string[] num
        System.Console.Write("Numerator / Denominator ");
        numerator=int.Parse(Console.ReadLine());        
        denominator=int.Parse(Console.ReadLine());
        Simplify();
    }
    public double Decimal()
    {
        return (double)numerator/denominator;
    }
    public Fraction Add(Fraction p)
    {

        int num= numerator *p.denominator + p.numerator*denominator;
        int deno=denominator* p.denominator; 
        Fraction temp = new Fraction( num,deno );
        temp.Simplify();
        return temp;
    }
    public Fraction Subtract(Fraction p)
    {
        int num= (numerator *p.denominator) - p.numerator* denominator;
        int deno=denominator*p.denominator; 
        Fraction temp = new Fraction( num,deno );        
        temp.Simplify();
        return temp;
    }
     public Fraction Multiply(Fraction p)
    {
        int num=numerator*p.numerator;
        int deno=denominator*p.denominator; 
        Fraction temp = new Fraction(num,deno);
        temp.Simplify();
        return temp;
    }
    public Fraction Divide (Fraction p)
    {
        Fraction upSideDown = new Fraction(p.denominator,p.numerator);
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
        return $"{numerator}/{denominator}" ;
    }
    
}
public class MixedFraction : Fraction
{
    // protected int wholePart;
    public MixedFraction(int wholePart,int numerator,int denominator )
            :base( numerator,  denominator)
    {
        numerator+= (wholePart* denominator);       
        // if (numerator > denominator){
        //     wholePart=numerator/denominator;
        //     numerator%=denominator;
        // }
    }
    public MixedFraction(Fraction f){
        Numerator=f.Numerator;
        Denominator=f.Denominator;
    }   
    public string ToStr(){
        int wholePart =Numerator/Denominator;
        base.Numerator%=Denominator;
        return $"{wholePart} [{base.ToStr()}]";
    } 
}
}

namespace PERSON{
public class Person
{
    protected string name;
    protected int birthYear;
    protected string address;

    public Person(){}
    public Person(string name, int birthYear, string address){
        Name=name;
        BirthYear=birthYear;
        Address=address;
    }
    public string Name{
        get =>name;
        set =>name=value;
    }
    public int BirthYear{
        get =>birthYear;
        set =>birthYear=value;
    }
    public string Address{
        get =>address;
        set =>address=value;
    }
    public virtual void Input() 
    {
      System.Console.Write("Name: ");          
      name=Console.ReadLine();

        int curYear =DateTime.Now.Year;        
      do
      {
        System.Console.Write("Birth Year: ");
        this.birthYear=int.Parse(Console.ReadLine());
      } while (birthYear<1900 || birthYear > curYear);
      
      System.Console.Write("Address: ");
      address=Console.ReadLine();
    }
    public int GetAge(){
        int curYear =DateTime.Now.Year;
        return curYear-birthYear;        
    }
    public virtual string ToStr(){
        return $"Name: {name}\t Age: {birthYear}\nAddress: {address}";
    }
}
public class Student : Person
{
    protected string program;
    protected int year;
    public Student(){}
    public Student(string name, int birthYear, string address, string program, int year)
                    :base(name,birthYear,address)
    {
        this.program=program;
        this.year=year;
    }
    public string ChangeProgram {        
        set => program=value;
    }
    public override void Input()
    {
        base.Input();
        System.Console.Write("Program: ");          
        program=Console.ReadLine();
        System.Console.Write("Year: ");          
        year=int.Parse(Console.ReadLine());
    }
    public override string ToStr()
    {
        return $"\tStudent: \n{base.ToStr()}\nProgram: {program} - {year}";
    }
}
public class Staff : Person
{
    protected string department;
    protected double salary;
    
    public Staff(){}
    public Staff(string name, int birthYear, string address, string department, double salary)
                    :base(name,birthYear,address)
    {
        this.department=department;
        this.salary=salary;
    }
    public override void Input()
    {
        base.Input();
        System.Console.Write("Deparment: ");          
        department=Console.ReadLine();
        System.Console.Write("Salary: ");          
        salary=int.Parse(Console.ReadLine());
    }
    public override string ToStr()
    {
        return $"\tStaff: \n{base.ToStr()}\nDepartment: {department} - {salary}";
    }
    public int UpdateSalary{
        set=> salary=value;
    }
}
}


