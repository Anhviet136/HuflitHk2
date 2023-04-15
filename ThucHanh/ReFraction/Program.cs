using System;

namespace TestProgram
{
    public void Main(){

    }
}
namespace ReFraction
{
    class Fraction
    {
        #region  Prop,Construc
        public int Num { get; set; }
        private int deno;
        public int Deno
        {
            get { return deno; }
            set { 
                if (value >0)
                deno = value;
            }
        }
        public Fraction(){}
        public Fraction (int num, int deno)
        {
            Num=num;
            Deno=deno;
            Simplyfy();
        }
        public Fraction (int num)
        {
            Num=num;
            Deno=1;
        }
        #endregion

        #region method        
        private void Simplyfy()
        {
            Num/=GCD;
            Deno/=GCD;
        }
        private int GCD (int a, int b)
        {
            if (a==0) return b;
            else GCD(b,a%b);
        }
        public double ToDouble()
        {
            return Num/Deno;
        }
        public override string ToString()
        {
            return $"{Num} /{Deno}";
        }
        #endregion
        #region overload 1ngoi
        #endregion
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.Num*b.Deno+b.Num*a.Deno,a.Deno*b.Deno);
        }
        public 
        #region overload 2ngoi
        #endregion
        #region overload soSanh
        #endregion

    }
}