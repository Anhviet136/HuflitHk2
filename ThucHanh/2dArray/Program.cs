using System;
class Program{    
  static void Main(string[] args) 
  {
    // Bai1();
    //Bai2();
    //Bai3();
    //Bai4();
    //Bai5();
    Bai6();
  }
    static void Bai1() 
  {
     System.Console.WriteLine("In put array a");
     int [,] a;
     InputArr(out a);
     System.Console.WriteLine("\tArr a: ");
     Print(a);

     System.Console.WriteLine("Input array b");
     int[,] b;
     b = InputArr1();
     System.Console.WriteLine("\tArr b: ");
     Print(b);

     System.Console.WriteLine("\tInput arr c");
     int m, n;
     m = 5; //int.Parse(Console.ReadLine());
     n = 3; //int.Parse(Console.ReadLine());
     int[,] c = new int [m,n];
     InputArr2(c);
     System.Console.WriteLine("\tArr c: ");
     Print(c);


  }
  static void Print (int[,] arr)
  {
    int i=0;
    foreach (int item in arr)
    {
      if (i == arr.GetLength(1)) {
        System.Console.WriteLine();
        i=0;
      }         
        System.Console.Write(item + " ");
      i ++;
    }
    System.Console.WriteLine();
  }
  static void InputArr(out int[,] arr) 
  {
  Random rand= new Random();
    System.Console.WriteLine("Column");
    int column = 10;//int.Parse(Console.ReadLine());
    System.Console.WriteLine("Row: ");
    int row = 6;//int.Parse(Console.ReadLine());
    

    arr = new int[row,column];
    for (int rowtmp = 0; rowtmp < row ; rowtmp++)
    {
        for (int columntmp = 0; columntmp < column; columntmp++)
        {
            arr[rowtmp,columntmp]=rand.Next(0,10);
            //int.Parse(Console.ReadLine());
            System.Console.WriteLine($"{rowtmp},{columntmp}: {arr[rowtmp,columntmp]} ");
        }        
    }
  }
  static int[,] InputArr1()
  {    
    InputArr(out int[,] arr);
    return arr;
  }
  static void InputArr2(int[,] arr)
  {

  Random rand= new Random();
    for (int row = 0; row < arr.GetLength(0); row++)
    {
        for (int col = 0; col < arr.GetLength(1); col++)
        {
            System.Console.Write($"arr[{row},{col}] = ");
            arr[row,col]=rand.Next(0,10);
            System.Console.WriteLine($"{arr[row,col]}");
        }
    }
  }
  static void Bai2()
  {
    int [,] arr=InputArr1();
    System.Console.WriteLine("\t 2d array: ");
    Print(arr);
    System.Console.Write("k = ");    
    int k=int.Parse(Console.ReadLine());
    
    while (k >= arr.GetLength(0) || k <0)
    {
      System.Console.WriteLine("Invalid K !!");
      System.Console.Write("k = ");    
      k=int.Parse(Console.ReadLine());
    }
    for (int i = 0; i < arr.GetLength(0); i++)
    {
      System.Console.Write(arr[k,i] + " ");   
    }
  }
  static void Bai3()
  {
    int [,] arr=InputArr1();
    System.Console.WriteLine("\t 2d array: ");
    Print(arr);
    System.Console.Write("k = ");    
    int k=int.Parse(Console.ReadLine());
    
    while (k >= arr.GetLength(1) || k <0)
    {
      System.Console.WriteLine("Invalid K !!");
      System.Console.Write("k = ");    
      k=int.Parse(Console.ReadLine());
    }
    System.Console.WriteLine($"\t\t dimension 1: {arr.GetLength(0)}");
    System.Console.WriteLine($"\t\t dimension 2: {arr.GetLength(1)}");
    for (int i = 0; i < arr.GetLength(0); i++)
    {
      System.Console.WriteLine(arr[i,k] );   
    }
  }
  static void Bai4()
  {
    int[,] arr = InputArr1();
    Print(arr);

    System.Console.Write("k = ");
    int k =2;
    // int k =int.Parse(Console.ReadLine());
    // while (k>= arr.GetLength(0) || k >= arr.GetLength(1) || k <0 )
    // {
    //   System.Console.WriteLine("Invalid K !!");
    //   System.Console.Write("k = ");    
    //   k=int.Parse(Console.ReadLine());
    // }

    int sumInRow = SumInRow(arr, k);
    int sumInCol = SumInCol(arr,k);
    int sum= Sum(arr);
    int sumEven= SumEven(arr);
    int sumOdd= SumOdd(arr);
    int args = Arvage(arr);
    System.Console.WriteLine($" Sum all element in row {k}: {sumInRow}");
    System.Console.WriteLine($" Sum all element in column {k}: {sumInCol}");
    System.Console.WriteLine($" Sum all element in array : {sum}");
    System.Console.WriteLine($" Sum all odd element : {sumOdd}");
    System.Console.WriteLine($" Sum all even element : {sumEven}");
    System.Console.WriteLine($" Arvage in array : {args}");

  }
  static int SumInRow (int[,] arr, int row)
  {
    int sum=0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
      sum+=arr[row,i]    ;
    }
    return sum;
  }
  static int SumInCol (int[,] arr, int col)
  {
    int sum=0;
    for (int i = 0; i < arr.GetLength(1); i++)
    {
        sum+=arr[i,col];
    }
    return sum;
  }
  static int Sum (int[,] arr)
  {
    int sum=0;
    foreach (int item in arr)
    {
        sum +=item;
    }
    return sum;
  }
  static int SumEven(int[,] arr)
  {
    int sum=0;
    foreach (int item in arr)
    {
        if (item %2==0)
        {
          sum+=item;
        }
    }
    return sum;
  }
  static int SumOdd(int[,] arr)
  {
    int sum =0;
    foreach (int item in arr)
    {
        if (item %2 !=2) sum+=item;        
    }
    return sum;
  }
  static int Arvage(int[,] arr)
  {
    return Sum(arr) / arr.Length;
  }
  static void Bai5()
  {
    int[,] arr = InputArr1();
    Print(arr);
    int k=5;
    int maxInRow = MaxInRow(arr, k);
    int minInCol = MinInCol(arr, k);
    
    System.Console.WriteLine($"Bigest element in row {k}: {maxInRow}");
    System.Console.WriteLine($"Smol est element in column {k}: {minInCol}");

    List<int> prime = PrimeInArr(arr);
    foreach (int item in prime)
    {
        System.Console.Write(item + " ");
    }
  }

    static int MaxInRow (int[,] arr, int k)
  {
      int max=arr[k,0];
      for (int i =0; i< arr.GetLength(1); i++)
      {
          if (max< arr[k,i])   max=arr[k,i];
      }
      return max;
  }
  static int MinInCol (int[,] arr, int k)
  {
      int min=arr[0,k];
      for (int i =0; i< arr.GetLength(0); i++)
      {
          if (min< arr[i,k])   min=arr[i,k];
      }
      return min;
  }
  static bool IsPrime(int x)
  {
      if (x<2) return false;
      else {
          for (int i=2; i <= x/2; i++)
          {
              if (x%i==0) return false;
          }
      }
      return true;
  }
  static List<int> PrimeInArr (int[,] arr)
  {
      List<int> prime = new List<int>();
      foreach(int item in arr)
      {
        bool check =IsPrime(item);
        if (check)  prime.Add(item);       
      }
      return prime;
  }
  static void Bai6()
  {
    int[,] arr = InputArr1();
    System.Console.WriteLine("\tArray: ");
    Print(arr);
    int k = 3;

    System.Console.WriteLine($"\tArray after Asc in row {k}:");
    AscArr2dInRow(arr, k);
    Print(arr);

    System.Console.WriteLine($"\tArray after Des in column {k}:");
    Des2dInCol(arr, k);
    Print(arr);

    int[,] arr1 = InputArr1();
    System.Console.WriteLine("\tArray: ");
    Print(arr1);
    int row1=2; int row2 =5;
    System.Console.WriteLine($"\tArray after swiching row {row1} and {row2}:");
    SwitchRow(arr1, row1, row2);
    Print(arr1);
    
    //Change the row only
    AscRow(arr1);
    System.Console.WriteLine("\tArray after Asc row by their sum in row");
    Print(arr1);
    // for test the resut
    for (int i = 0; i < arr1.GetLength(0); i++)
    {
      System.Console.WriteLine($"\tSum in row {i}: {SumInRow(arr1, i)}");      
        
    }
  }
  static void AscArr2dInRow (int[,] arr, int row)
  {          
    for (int i = 0; i < arr.GetLength(1); i++)
    {
        for (int index = i + 1; index < arr.GetLength(1); index++)
        {
            if (arr[row,i] > arr[row,index])
            {
                int tmp = arr[row,i];
                arr[row,i] = arr[row,index];
                arr[row,index] = tmp;
            }                
        }
    }            
  }
  static void Des2dInCol(int[,] arr, int col)
  {
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int index = i + 1; index < arr.GetLength(0); index++)
        {
            if (arr[i,col] < arr[index,col])
            {
                int tmp = arr[i,col];
                arr[i,col] = arr[index,col];
                arr[index,col] = tmp;
            }                
        }
    } 
  }
  static void SwitchRow(int[,] arr, int row1, int row2)
  {
    for (int i = 0; i < arr.GetLength(1); i++)
    {
        int tmp=arr[row1,i];
        arr[row1,i]=arr[row2,i];
        arr[row2,i]=tmp;
    }
  }
  static void AscRow(int[,] arr)
  {
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int index = i + 1; index < arr.GetLength(0); index++)
        {
            if (SumInRow(arr,i)> SumInRow(arr,index))
            {
              SwitchRow(arr,i,index);
            }                         
        }
    }            
  }
}
