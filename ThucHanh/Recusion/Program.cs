using System;
//usingusing static SomeCode; 

class Program{ 
    static void B1(){
      //var code= new SomeCode();
      
      
      int n=  SomeCode.Random(0,9);

      int giaiThua=Bai1.GiaiThua(n);
      System.Console.WriteLine($"{n}! = {giaiThua}");
    }
    static void B2(){
      int n=SomeCode.Random(0,9);
      int a=SomeCode.Random(0,9);

      double luyThua=Bai2.LuyThua(a,n);
      System.Console.WriteLine($"{a}^{n} = {luyThua}");
    }
    static void B3(){
      int a= SomeCode.Random(0,30);
      int b= SomeCode.Random(0,30);

      int gcd = Bai3.GCD(a,b);
      System.Console.WriteLine($"GCD of {a} and {b} = {gcd}");
    }
    static void B4(){
      int n =20;
      
       List<byte> bin = new List<byte>();
      Bai4.DecToBin(n, bin);
      
      foreach (byte item in bin)
      {
        System.Console.Write(item + " ");
      }
      System.Console.WriteLine();
      
    }
    static void Main(string[] args) 
  {
    // B1();
    // B2();
    //  B3();
    B4();
    
  }
}
class SomeCode {
  public static int Random(int min, int max){
    Random rand = new Random();
    return rand.Next(min,max);
  }

}
class Bai1{
  public static int GiaiThua (int n){
    int giaiThua=n;
    if (giaiThua==1) return giaiThua;
    else {
      giaiThua*=Bai1.GiaiThua(n-1);
    }
    return giaiThua;
  }
}
class Bai2{
  public static int LuyThua(int a, int n){    
    int luyThua=a;
    System.Console.WriteLine(luyThua);
    if(n==0) return 1;
    else if(n%2==0) return luyThua*=Bai2.LuyThua(luyThua,n-1);
    else  return luyThua*=Bai2.LuyThua(luyThua,(n-1));
  }
}
class Bai3{
  public static int GCD (int a,int b){
    if (a==0) return b;
    else if (b==0) return a;
    else {
      if (a>b)     
        return Bai3.GCD(b,a-b);      
      else         
        return Bai3.GCD(a,b-a);            
    }
  }
}
class Bai4{
  public static void DecToBin (int n, List<byte> bin){
    // System.Console.WriteLine(n);

     if (n==0)  bin.Insert(0,0);
     else if (n==1) bin.Insert(0,1);
     else if(n%2==0){
      bin.Insert(0,0);
      Bai4.DecToBin(n/2, bin);
     }
     else {
      bin.Insert(0,1);
      Bai4.DecToBin((n-1)/2, bin);
     }


  }  
}

