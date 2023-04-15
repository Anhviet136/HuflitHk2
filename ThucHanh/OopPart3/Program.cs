using System;
using CACULATOR;
using FRACTION;

using CaculFrac;
class Part3
{
    public static void Bai1(){
        Caculator cal = new Caculator();
        // int sub = cal.Subtract(10,8);
        // System.Console.WriteLine(sub);
        int sum =Caculator.Add(3,4)    ;        
        System.Console.WriteLine(sum);
        
        // => static goi qua class, non-static goi qua oject ?
        // Caculator.Add(3,4) <> cal.Subtract(10,8)
    }    
    public static void Bai2(){
        Fraction a =new Fraction(3,7);
        Fraction b= new Fraction(2,7);
        MixedFraction c =new MixedFraction(3,2,7);

        Fraction x = new Fraction(4,7);
        
        Fraction sum = a+c;
        Fraction sub = a-b;
        Fraction times = a*c;
        Fraction divice = a/x;
        System.Console.WriteLine(sum.ToStr());
        System.Console.WriteLine(sub.ToStr());
        System.Console.WriteLine(times.ToStr());
        System.Console.WriteLine(divice.ToStr());
        
        string test =$"\n a={ a.ToStr()} |b={ b.ToStr()}"
                    +$"\n x {x.ToStr()} |c {c.ToStr()}"
                    +$"\n x { x.ToStr()} |-x {(-x).ToStr()}"                    
                    +$"\n c!=a { c!=a} |c==a {c==a}"
                    +$"\n x<a { x<a} |x>a { x > a}"
                    +$"\n b>=a {b>=a} |b<=c { b <= c}";
        System.Console.WriteLine(test);

        Fraction d = 3.7;
        Fraction e = 4;
        double f = (double)a;

        string testC = $"\n d={ d.ToStr()} |e={ e.ToStr()}"
                    +$"\n f={f:F2} |";
        System.Console.WriteLine(testC);
       
    }
}
class Program 
{    
    static void Main(){
        Part3.Bai2();
    }    
}
namespace CACULATOR
{
    
public class Caculator
{    
    // public  Caculator(){}    
    public static  int Add(int a, int b){
        return a+b;
    }
    public static  double Add(double a, double b){
        return a+b;
    }
    public static  int Subtract(int a, int b){
        return a-b;
    }
    public static  double Subtract(double a, double b){
        return a-b;
    }
    public static  int Multiply(int a, int b){
        return a*b;
    }
    public static  double Multiply(double a, double b){
        return a*b;
    }
    public static  double Divide(int a, int b){
        return (double)a/b;
    }
    public static  double Divide(double a, double b){
        return a/b;
    }    
}

}

namespace CaculFrac
{
    // public class Fraction : Fraction 
    // {
    //     public Fraction(int numerator,int denominator)
    //                         :base(numerator,denominator)
    //     {}
    //     public static Fraction operator + (Fraction a, Fraction b)
    //     {
    //         int num= a.Numerator *b.Denominator + b.Numerator*a.Denominator;
    //         int deno=a.Denominator* b.Denominator; 
    //         Fraction temp = new Fraction( num,deno );
    //         temp.Simplify();
    //         return temp;
    //     }
    // }
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
    
    #region Method
    public void Simplify()
    { 
        //int [] nums = {numerator,denominator};  
        if (numerator >0 || denominator >0)  
        {
            int divisor=GCD(numerator,denominator);        
            numerator/=divisor;
            denominator/=divisor;
        }    
    }
    static int GCD(int a, int b)
    {
        if (b == 0) return a;
        else return GCD(b, a % b);
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

    public string ToStr()
    {
        Simplify();
        return $"{numerator}/{denominator}" ;
    }
    #endregion
        
    #region ToanTu1Ngoi    
    public static Fraction operator - (Fraction a)
    {
        return new Fraction(-a.Numerator,a.Denominator);
    }
    public static Fraction operator ++ (Fraction a)
    {
        return new Fraction (a.Numerator+1,a.Denominator);
    }
    public static Fraction operator -- (Fraction a)
    {
        return new Fraction (a.Numerator-1,a.Denominator);
    }
    #endregion

    #region ToanTu2Ngoi
    public static Fraction operator + (Fraction a,Fraction b)
    {

        int num= a.Numerator *b.Denominator + b.Numerator*a.Denominator;
        int deno=a.Denominator* b.Denominator; 
        Fraction temp = new Fraction( num,deno );
        temp.Simplify();
        return temp;
    }
    public static Fraction operator -(Fraction a,Fraction b)
    {
        int num= (a.Numerator *b.Denominator) - b.Numerator* a.Denominator;
        int deno=a.Denominator*b.Denominator; 
        Fraction temp = new Fraction( num,deno );        
        temp.Simplify();
        return temp;
    }
     public static Fraction operator *(Fraction a,Fraction b)
    {
        int num=a.Numerator*b.Numerator;
        int deno=a.Denominator*b.Denominator; 
        Fraction temp = new Fraction(num,deno);
        temp.Simplify();
        return temp;
    }
    public static Fraction operator / (Fraction a,Fraction b)
    {
        Fraction upSideDown = new Fraction(b.Denominator,b.Numerator);
        return a*upSideDown;
        //Multiply(a,upSideDown);
        /*
        numerator*=b.Denominator;
        denominator*=b.Numerator; 
        Simplify();
        */
    }
    #endregion

    #region ToanTuSoSanh
    public static bool operator == (Fraction a, Fraction b)
    {
        if(a.Denominator == b.Denominator)
            if (a.Numerator == b.Numerator) return true;
            else return false;
        else 
        {
            int tempA=a.Numerator*b.Denominator;
            int tempB=b.Numerator*a.Denominator;
            if (tempA == tempB) return true;
            else return false;
        }
    }
    public static bool operator != (Fraction a, Fraction b)
    {
        if (a==b) return false;
        else return true;
    }
    public static bool operator > (Fraction a, Fraction b)
    {
        if(a.Denominator > b.Denominator)
            if (a.Numerator > b.Numerator) return true;
            else return false;
        else 
        {
            int tempA=a.Numerator*b.Denominator;
            int tempB=b.Numerator*a.Denominator;
            if (tempA > tempB) return true;
            else return false;
        }
    }
    public static bool operator < (Fraction a, Fraction b)
    {
        if (a> b || a==b) return false;
        else return true;
    }
    public static bool operator >= (Fraction a, Fraction b)
    {
        if(a.Denominator >= b.Denominator)
            if (a.Numerator >= b.Numerator) return true;
            else return false;
        else 
        {
            int tempA=a.Numerator*b.Denominator;
            int tempB=b.Numerator*a.Denominator;
            if (tempA >= tempB) return true;
            else return false;
        }
    }
    public static bool operator <= (Fraction a, Fraction b)
    {
        if (a>b) return false;
        else return true;
    }


    #endregion

    #region Convert
    public static implicit operator Fraction (double a)       
    {
        string nums = a.ToString();
        int dotIndex = nums.LastIndexOf('.');
        int count = nums.Length-dotIndex;
        int num =(int) (a*Math.Pow(10,count));
        int deno =(int)Math.Pow(10,count);
        Fraction temp = new Fraction(num,deno);
        temp.Simplify();
        return temp;
    }
    public static implicit operator Fraction (int a)
    {
        return new Fraction(a);
    }
    public static explicit operator double (Fraction a)
    {
        return (double)a.Numerator/a.Denominator;
    }
    #endregion

}
public class MixedFraction : Fraction
{
    // protected int wholePart;
    public MixedFraction(int wholePart,int numerator,int denominator )
            :base( numerator,  denominator)
    {
        Numerator+= (wholePart* Denominator);       
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
        return $"{wholePart}[{base.ToStr()}]";
    } 
    
}
}


