using System;
namespace SomeCode{
public class Input{
    // public static  void CheckInput(out int x, string name)
    // {
    //     string str = Console.ReadLine();
    //     x=0;
    //     for (bool res=int.TryParse(str, out x);res == false;   )
    //     {                
    //             Console.Write($"\tValid input!! \n{name} = ");
    //             str=Console.ReadLine();  
    //             res=int.TryParse(str, out x);
    //     }
    // }

    // public static  void CheckInput(out double x, string name)
    // {
    //     string str = Console.ReadLine();
    //     x=0;
    //     for (bool res=double.TryParse(str, out x);res == false;   )
    //     {
                
    //             Console.Write($"\tValid input!! \n{name} = ");
    //             str=Console.ReadLine();  
    //             res=double.TryParse(str, out x);
    //     }
    // }  

    // public static int[] InputArr(int n)
    // {
    //     int[] arr = new int[n];
    //     string[] array = Console.ReadLine().Split();
    //     for (int i=0; i<n;i++)
    //     {   string name = $"arr {i}:";         
    //         arr[i] = int.Parse(array[i]);
    //         CheckInput(out arr[i], name);
    //     }
    //     return arr;
    // }
 
    // public static double[] RandomArr(int n)
    // {
    //     Random rand= new Random();
    //     double[] arr = new double[n];
    //     for (int i=0; i<n; i++)        
    //         arr[i]=rand.NextDouble();

    //     return arr;
    // }
    public static int[,] Input2dArray (int rows, int cols)
    {
        int[,] arr= new int[rows,cols];
        for (int row = 0; row < rows; row++){
            string[] num = Console.ReadLine().Split();
            for (int col = 0; col < cols; col++){
                arr[row,col] = int.Parse(num[row]);
            }
        }
        return arr;
    }
    public static int[] RandomArr(int size) {
        Random rand = new Random();
        int[] arr = new int[size];

        for (int i = 0; i < size; i++)        
            arr[i] = rand.Next(0, 10);        
        return arr;
    }

    public static int[,] Rand2dArr (int rows, int cols){
        Random rand = new Random();
        int[,] arr = new int[rows,cols];
        for (int row = 0; row < rows; row++)
            for (int col = 0; col < cols; col++)            
                arr[row,col] = rand.Next(0,9);        
        
        return arr;                        
    } 

    public static int Random(int min, int max){
        Random rand = new Random();
        return rand.Next(min,max);
    }
}
public class Print {
    public static void PrintArr( int[] arr)
    { 
        int n=arr.Length;
        for (int i=0; i<n; i++)
        {
            Console.Write(arr[i] +" ");
        }
        Console.WriteLine();
    }

    public static void PrintArr( double[] arr)
    {
        int n=arr.Length;
        for (int i=0; i<n; i++)
        {
            Console.Write(arr[i] +" ");
        }
        Console.WriteLine();
    }  

    public static void Print2d (int[,] arr)   {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++)
                System.Console.Write(arr[row,col]+ " ");
            System.Console.WriteLine();
        }
        System.Console.WriteLine();
    }

    public static void Print2d (double[,] arr)   {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++)
                System.Console.Write(arr[row,col]+ " ");
            System.Console.WriteLine();
        }
        System.Console.WriteLine();
    }
    public static void Print2d (bool[,] arr)   {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (arr[row,col])
                System.Console.Write("X ");
                else 
                System.Console.Write("0 ");
            }
        System.Console.WriteLine();
        }
        System.Console.WriteLine();
        
    }

}
public class Algorithms 
{
    public static void QickSort(int[] arr, int left, int right)
    {
        int tempR = right; // to remember the range
        int tempL= left;
        int pivot =arr[(left+right)/2];

        while (left < right) // stop case: when there only one element in array
        {            
            // Go right to search for element > than pivot
            for (; arr[left] < pivot; left ++){}
            // Go left to search for element < than pivot
            for (; arr[right] > pivot; right --){}                                                            
           
            if (left >= right )  //Divice and continute 
            {                            
                QickSort(arr, tempL ,left);
                QickSort(arr, left+1, tempR  );
            }
            else // elemens < pivot on the left and > pivot on the right 
            {
                Algorithms.Swap(ref arr[left], ref arr[right]);                      
            }
        }                    
    }
    public static void Swap (ref int a, ref int b)  
    {
        int temp = a;
        a = b;
        b=temp;
    }
}
}
