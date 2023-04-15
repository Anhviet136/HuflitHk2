using System;
// Name space SomeCode that I created
using SomeCode;
class Program{   
   
  static void B1_2_3(){
      // For testing
      int[,] arr= Input.Rand2dArr(4,8);

      // int rows=4,cols =8;
      // System.Console.Write("Nhap so dong, cot: ");
      // string[] num = Console.ReadLine().Split();   
      // int rows = int.Parse(num[0]);
      // int cols = int.Parse(num[1]);
      // int[,] arr= Bai1.Input2dArray(rows,cols);
      System.Console.WriteLine("Mang vua nhap la:");
      Print.Print2d(arr);

      //Test Bai1
      int k =2;    
      Bai1.PrintRow(arr,k);

      //Test Bai2
      Bai2.PrintColumn(arr, k);

      //Test Bai3
      int sumArr=Bai3.Sum(arr);

      System.Console.WriteLine("Sum: " + sumArr);
    }
    static void B4 ()
  {
    //Data for testing
    double[,] table = {{8.4, 6.7, 8.3},
                        {4.8, 8.8, 5},
                        {3.4, 6.7, 9.3}};

    // int soSV =5;
    // int soMonHoc=3;
    // double[,] table = Bai4.Input2dArray(soSV,soMonHoc);
    System.Console.WriteLine("Toan, NVan, TAnh");
    Print.Print2d(table);
    
    int sv =2;
    int monHoc =1;

    double tb_MonHoc = Bai4.TbMonHoc(table, monHoc);
    double tb_SV = Bai4.TbSinhVien(table, sv);
    System.Console.WriteLine($"Trung Binh sinh vien {sv}: {tb_SV:F2}\nTrung Binh mon {monHoc}: {tb_MonHoc:F2}");
  } 
  static void B5_6_7()
  {
    int[,] arr=Input.Rand2dArr(4,4);
    Print.Print2d(arr);

    Bai5_6_7.CheoChinh(arr);
    Bai5_6_7.CheoPhu(arr);
    Bai5_6_7.TamGiacChinh(arr);

  }
  static void B8()
  {
    List<int[]> jag = Bai8.jaggedList();

    foreach (int[] arr in jag)
    {
      foreach (int item in arr)
      {
        System.Console.Write(item + " ");
      }
      System.Console.WriteLine();
    }
  }
  static void Main(string[] args) 
  {    
    //B1_2_3();
    // B4();
    //B5_6_7();
    B8();
  }
}
class Bai1 
{
    public static int[,] Input2dArray (int rows, int cols)
    {
        int[,] arr= new int[rows,cols];
        for (int row = 0; row < rows; row++){
            string[] num = Console.ReadLine().Split();
            for (int col = 0; col < cols; col++)
                arr[row,col] = int.Parse(num[row]);            
        }
        return arr;
    }
    public static void PrintRow(int[,]arr, int row)
    {
      System.Console.WriteLine($"Row {row}:");
      for (int i=0; i<arr.GetLength(1); i++)        
          System.Console.Write(arr[row,i]+ " ");
                  
      System.Console.WriteLine();
    }
}
class Bai2 
{
  public static void PrintColumn(int[,]arr, int col)
    {
      System.Console.WriteLine($"Column {col}:");
        for (int i=0; i<arr.GetLength(0); i++)
        {
            System.Console.WriteLine(arr[i,col]+ " ");
        }
        System.Console.WriteLine();
    }
}
class Bai3
{
  public static int Sum(int[,]arr)
  {
    int sum=0;
    foreach (int item in arr)
    {
      sum+=item;
    }
    return sum;
  }
}
class Bai4 
{
  public static double[,] Input2dArray (int rows, int cols)
    {
        double[,] arr= new double[rows,cols];
        for (int row = 0; row < rows; row++){
            string[] num = Console.ReadLine().Split();
            for (int col = 0; col < cols; col++)
                arr[row,col] = double.Parse(num[row]);            
        }
        return arr;
    }
  public static double TbSinhVien (double[,] table, int id )
  {
    double score =0;
    for (int col = 0; col < table.GetLength(1); col++)
      score += table[id,col];
    
    return score/table.GetLength(1);
  }
  public static double TbMonHoc (double[,] table, int col)
  {
    double score =0;
    for (int row = 0; row < table.GetLength(0); row++)
      score += table[row,col];
    
    return score/table.GetLength(0);
  }
}
class Bai5_6_7{
  public static void CheoChinh (int[,] arr){
    System.Console.WriteLine("Cheo chinh");
    for (int i = 0; i < arr.GetLength(0); i++)    
      System.Console.Write(arr[i,i]+" ");  

    System.Console.WriteLine();      
  }
  public static void CheoPhu (int[,] arr){
    System.Console.WriteLine("Cheo phu");
    int n = arr.GetLength(0);
    for (int row = 0; row <n ; row++)  
    {
      for (int col = n-row-1; col < arr.GetLength(0); col++)
      {
        System.Console.Write(arr[row,col]+" ");
        break;
      }      
    } 
    System.Console.WriteLine();
  }
  public static void TamGiacChinh(int[,] arr) {
    System.Console.WriteLine("Tam giac chinh");
    int n = arr.GetLength(0);
    for (int row = 0; row <n ; row++)  
    {
      for (int col =row; col < arr.GetLength(0); col++)  
       {
        System.Console.Write(arr[row,col]+" ");             
       }    
       System.Console.WriteLine();
    } 
    System.Console.WriteLine();
  }
}
class Bai8 
{
  public static List<int[]> jaggedList ()
  {
    List<int[]> jag= new List<int[]>();       
    System.Console.WriteLine("type end to end !");   
    for (;true;)
    {   
      //index for counting    
      int i=0;      

      string[] num=Console.ReadLine().Split();

      //stop case:                                  
      if (num[0]=="end") break;   

      int[] arr = new int[num.Length]; 

      //assig number in num to arr 
      foreach (string item in num)
      {
        arr[i] = int.Parse(item);
        i++;
      }
      // add arr to List
      jag.Add(arr);
    } 

  return jag;
  }
 }