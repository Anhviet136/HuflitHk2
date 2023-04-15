using System;
class Program{   
     static void B1(){ 
        // khoi tao mang 2d a
        int [,] arr1= SomeCode.Rand2dArr(4,5);
        System.Console.WriteLine("Array a:");
        SomeCode.Print2d(arr1); 
        // khoi tao mang 2d b   
        int [,] arr2= SomeCode.Rand2dArr(4,5);
        System.Console.WriteLine("Array b:");
        SomeCode.Print2d(arr2);

        int[,] sum = Bai1.MatrixSum(arr1, arr2);
        System.Console.WriteLine("\tMatrix Sum: ");
        SomeCode.Print2d(sum);
        }
    static void B2(){
        // int m =4, n=5, p=3;
        // // khoi tao mang 2d a
        // int [,] arr1= SomeCode.Rand2dArr(m,n);
        // System.Console.WriteLine("Array a:");
        // SomeCode.Print2d(arr1); 
        // // khoi tao mang 2d b   
        // int [,] arr2= SomeCode.Rand2dArr(n,p);
        // System.Console.WriteLine("Array b:");
        // SomeCode.Print2d(arr2);
        int[,] arr1={{1,2},
                    {3,4}};
        int[,] arr2={{5,6,7},
                    {8,9,10}}  ;
        int[,] product=Bai2.MatrixProduct(arr1, arr2);
        SomeCode.Print2d(product);

    }
    static void B3 (){
        //Data for testing
        //int m=3, n=4;
        int[] prices = {3,4,2};
        int[,] sold = {{12,15,11,10},
                        {32,30,40,23},
                        {13,12,20,15}};
        int[] sumPerDay=Bai3.DotProduct(prices, sold) ;
        int sum=0;
        foreach (int item in sumPerDay)
        {
            sum+= item;
            System.Console.Write(item + " ");
        }  
        System.Console.WriteLine($"\n Sum: {sum}");                          
    }
    static void B4()
    {
        int[,] arr = SomeCode.Rand2dArr(4,6);
        SomeCode.Print2d(arr);

        System.Console.WriteLine("After transpose: ");
        int[,] transpose=Bai4.Transpose(arr);
        SomeCode.Print2d(transpose);

        System.Console.WriteLine("After transpose: ");
        int[,] transpose2=Bai4.Transpose2(arr);
        SomeCode.Print2d(transpose2);
    }
    static void B5(){
        // System.Console.WriteLine("\t2d array a:");
        // int[,] a = SomeCode.Rand2dArr(4,6);
        // SomeCode.Print2d(a);
        // System.Console.WriteLine("\t2d array b:");
        // int[,] b = SomeCode.Rand2dArr(4,6);
        // SomeCode.Print2d(b);

        int[,] a={{4,5},{6,7}};
        int[,] b={{2,5},{8,1}};

        double Euclid = Bai5.Distant(a,b);
        System.Console.WriteLine($" Distant: {Euclid:F2}");
    }
    static void B6(){
        int[,] a={{2,1,2},{1,1,1},{4,5,6}};
        int[,] b={{4,5,6},{2,3,4},{1,2,3}};

        System.Console.WriteLine(Bai6.DotProduct(a, b));
    }
    static void B7(){
        //data for test
        int[,] image ={{4,2,2,4},
                        {1,9,5,3},
                        {1,4,2,4},
                        {0,9,8,1}};
        SomeCode.Print2d(image);
        
        int[,] kernel= {{-1,-1,-1},
                        {-1,8,-1},
                        {-1,-1,-1}};
        SomeCode.Print2d(image);
        SomeCode.Print2d(kernel);
        double [,] result = Bai7.Convolution(image,kernel);
        SomeCode.Print2d(result);
    }
  static void Main(string[] args) 
  {
    // B1();
    //B2();
    //B3();
    // B4();
    // B5();
    // B6();
        B7();
  }
}
class SomeCode{
    public static int[,] Rand2dArr (int rows, int cols){
        Random rand = new Random();
        int[,] arr = new int[rows,cols];
        for (int row = 0; row < rows; row++)
            for (int col = 0; col < cols; col++)            
                arr[row,col] = rand.Next(0,9);        
        
        return arr;                        
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
}
class Bai1{
    public static int[,] MatrixSum (int[,] arr1, int[,] arr2){
        // cho de nhin
        int rows = arr1.GetLength(0);
        int cols = arr1.GetLength(1);
        int[,] sum = new int [rows,cols]; // bien chua ket qua
        //Cong 2 ma tran
         for (int row = 0; row < rows; row++)
            for (int col = 0; col < cols; col++)            
                sum[row,col] = arr1[row,col] + arr2[row,col];
        return sum;
    }
}
class Bai2{
    public static int[,] MatrixProduct(int[,] arr1, int[,] arr2 ){
        int m=arr1.GetLength(0), n=arr2.GetLength(0), p= arr2.GetLength(1);
        int[,] product = new int[m,p];

        for (int row = 0; row < m; row++)        
            for (int col = 0; col < p; col++)
                for (int i = 0; i < n; i++)                
                    product[row,col]+= arr1[row,i] *arr2[i,col]  ;                            
        return product;
    }
}
class Bai3{
    public static int[] DotProduct(int[] prices, int[,] sold){
        //sold column is amount of days
        int[] sumPerDay=new int[sold.GetLength(1)];
        
        for (int col = 0; col < sold.GetLength(1); col++)
            for (int row = 0; row < sold.GetLength(0); row++)
                // product of sold col and prices 
                sumPerDay[col]+=sold[row,col] * prices[row];
        return sumPerDay;       
    }
}
class Bai4{
    public static int[,] Transpose(int[,] arr){
        int rows = arr.GetLength(1);
        int cols = arr.GetLength(0);
        int[,] transpose= new int[rows,cols];

        // to keep value after each time foreach block code ocur
        // khai báo ngoài để giữ giá trị sau mỗi lần lặ
        int row=0       
           ,col=0;        
        foreach (int item in arr)
        { 
            if (row < rows )
            //add each item to each column on row
            // then incre row and repeat
                if (col< cols){
                    transpose[row,col] = item; 
                    // to next posistion                   
                    col++;                    
                }
                else {
                    // col out of transpose'column
                    //incre row and reset column to 0
                    row++;
                    col=0;
                    transpose[row,col] = item;
                    col++;
                }
        }  
        return transpose;           
    }
    public static int[,] Transpose2 (int[,] arr){
        int rows = arr.GetLength(1);
        int cols = arr.GetLength(0);
        int[,] transpose= new int[rows,cols];

        for (int row = 0; row < rows; row++)
            for (int col = 0; col < cols; col++)
                //swich row and col to transpose the matrix
                transpose[row,col]=arr[col,row];
        return transpose;
    }
}
class Bai5{
    public static double Distant(int[,] a, int[,] b){
        double sum =0;
         int rows = a.GetLength(0);
        int cols = a.GetLength(1);

        for (int row = 0; row < rows; row++)        
            for (int col = 0; col < cols ; col++)
                sum+=  Math.Pow(a[row,col] - b[row,col], 2);

        System.Console.WriteLine(sum);
        return Math.Pow(sum,0.5);
    }
}
class Bai6{
    public static double DotProduct(int[,] a, int[,]b){
        double sum =0;
         int rows = a.GetLength(0);
        int cols = a.GetLength(1);

        for (int row = 0; row < rows; row++)        
            for (int col = 0; col < cols ; col++)
                sum+= a[row,col]*b[row,col];                

        return sum;
    }

}
class Bai7 {
   // public static int[,] Coppy2d(int[,] arr){}
    public static double[,] Convolution (int[,] image, int[,] kernel){
        //for clean code
        int rowA = image.GetLength(0);
        int colA = image.GetLength(1);
        int rowB = kernel.GetLength(0);
        int rows = rowA-rowB +1;
        int cols = colA-rowB +1;

        // use array instead of 2d array to reduce amount of for loop
        double[] result= new double[rows*cols];
        int[,] temp=new int[kernel.GetLength(0),kernel.GetLength(0)];
        
        int goRight =0, goDow=0;
        int row=0, col=0;

        //
        for (int i = 0; i < rows*cols; i++) {
            // check if temp go out side of image 2d arr            
            if (row+goDow >rowA) goRight++;
            if (col+goRight > colA) {
                goDow++;
                goRight=0;
            }
            // coppy element in image to new 2d array with kernel size
            for (  row = 0; row < rowB  ; row++)        
                for (  col = 0; col < rowB ; col++)
                    temp[row,col]= image[row+goDow,col+goRight];
            // continute to next arena
            goRight++;
            
            {
                //for debug
            // foreach (int item in temp)
            // {
            //     System.Console.Write(item+" ");
            // }
            // System.Console.WriteLine("\t ..\n");
            } 
        //Dot product of kernel and a part of image 2d array                      
        result[i] = Bai6.DotProduct(kernel,temp);
        }   

        {
            //For Debug
        // foreach (double item in result)
        // {
        //     System.Console.WriteLine(item + " ");
        // }
        }

        //Convert resut array to convolution 2d array
        double [,] convolution = new double[rows,cols];
        int j =0;
        for ( row = 0; row < rows; row++)        
           for ( col = 0; col < cols ; col++,j++)
                // j and col will incre at the same time
                convolution[row,col]= result[j];

        return convolution;
    }
}