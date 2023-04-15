using System;
using SomeCode;

class Program 
{
  static int size =4;
  static int[,] board= new int[size,size];  
  // static bool[,] stateBoard = new bool[size,size];
  static int count=0;

  static bool[] column=new bool[size];
  static bool[] major=new bool[size*2-1];
  static bool[] minor=new bool[size*2-1];
  
  static List<int[,]> solution =new List<int[,]>();

  public static void SearchQueen(int row, int queens)
  {
    // int size=board.GetLength(0);
    Print.Print2d(board);    
    if (queens ==size)
      board = new int[size,size];
    
    if (row ==size) {
      System.Console.WriteLine("an lon rui");
      Print.Print2d(board);   
    }
    else if (queens==0) {
      //solution.Add(board);
      count ++;      
      System.Console.WriteLine($"\tSolution {count}");  
        Print.Print2d(board);
    }
    else {
      for (int col =0; col < size; col ++){         
         System.Console.WriteLine($"  {row} {col}");        
          if(IsSafe(row,col))             
        {
          board[row,col]=1;
          AtkRange(row,col,true);
          System.Console.WriteLine($"set  {row} {col} \t Queens: {queens-1} \n----------------" );          
          Print.Print2d(board);          
          
          SearchQueen(row+1,queens-1);
          board[row,col]=0;
          queens++;
          AtkRange(row,col,false);
          System.Console.WriteLine("turn back");
          Print.Print2d(board);                  
        }
      }
      SearchQueen(row+1,queens);
    }
  }
  static void AtkRange(int row, int col,bool state)
  {
    column[col]=state;
    major[row-col+size-1]=state;
    minor[row+col]=state;
  }
  static bool IsSafe(int row,int col)
  {
    if (!column[col]
        &&!major[row-col+size-1]
        &&!minor[row+col])
      return true;    
    else return false;
  }
  static void Main(){        
        // int[] n ={1,2,3,4};
        // int k =2;
        
        // bool[] used = new bool[n.Length+1];
        //Bai1_2_3.ToHop(n,used,k,0);

        // int size=4;
        // board = new int[size,size];
        
        // column=new bool[size];
        // major=new bool[size*2-1];
        // minor=new bool[size*2-1];
        // Bai4.Queen(queen, 0,0,size);        

        // VetCan.Queen(size);

        SearchQueen(0,size);
    }
}
class Bai1_2_3 
{
  // static int[] resut = new int[3];
    public static void ChinhHopChap(int [] n, int k,int i)    
    {
      if (i <k)
      {
        for (int j = 1; j <= n.Length; j++)
        {
           n[i] = j; 
          ChinhHopChap(n,k,i+1);          
        }        
      }        
      else{
        for (int index = 0; index < k; index++)
        {
          System.Console.Write(n[index] + " ");
        }
        System.Console.WriteLine();
      } 
      // System.Console.WriteLine("\t arr");
      // Print.PrintArr(n);
    }
    public static void KhumLap(int [] n,bool[] used, int k,int i )    
    {
      if (i <k)
      {
        for (int j = 1; j <= n.Length; j++)
        {
          //Check if j is used or not
          if (used[j]==false)
          {
            n[i]  = j; 
            //j is used so KhumLap will skip j
            used[j]=true;
            KhumLap(n,used,k,i+1);          
            //done, now reset 
            used[j]=false;
          }
        }        
      }        
      else{
        // Print 
        for (int index = 0; index < k; index++)
        {
          System.Console.Write(n[index] + " ");
        }
        System.Console.WriteLine();
      }       
    }
    
    public static void ToHop(int [] n,bool[] used, int k,int i )    
    {
      if (i <k)
      {
        for (int j = 1; j <= n.Length; j++)
        {
          //Check if j is used or not
          if (used[j]==false)
          {
            n[i]  = j; 
            //j is used so KhumLap will skip j
            used[j]=true;
            KhumLap(n,used,k,i+1);          
            // 
          }
        }        
      }        
      else{
        // Print 
        for (int index = 0; index < k; index++)
        {
          System.Console.Write(n[index] + " ");
        }
        System.Console.WriteLine();
      }       
    }
}
class Bai4
{
  public static int countSln=0;
  static List<int> trackingRow=new List<int>();
  static List<int> trackingCol=new List<int>();
  static int anlonrui=0;
  public static void Queen (int[,] chess, int row, int col, int queens)
  {     
    int chessLength=chess.GetLength(0);
        Tracking();
        System.Console.WriteLine($"  {row} {col} \t Queens: {queens} \n----------------" );  
        Print.Print2d(chess);        
    // if ()
      for (;queens>0;row++)
      {
        //stop case
        // turn back case
        if (row >=chessLength && col >=chessLength)
        {
          // Turn back
          int preQueen = trackingRow.Count-queens;
          System.Console.WriteLine($"\t\tAn lon rui {preQueen}");            
          System.Console.WriteLine($"Uncheck {trackingRow[preQueen]} {trackingCol[preQueen]}");
          chess[trackingRow[preQueen],
              trackingCol[preQueen]] = 0;            
          Queen(chess, trackingRow[preQueen], trackingCol[preQueen], queens+1);
          if (preQueen >0 ){
          }
        }      
        else if (row >= chessLength) Queen(chess, 0 ,col+1, queens);
        else if (col >= chessLength) Queen(chess, row +1 ,col, queens);
        //Check 
        else if (chess[row,col]==0
                && IsSafe(chess,row,col)) 
        {              
          // SetQueen(chess,row,col,queens); 
          System.Console.WriteLine($"\tSet queen {row} {col}");
          chess[row,col]=1;
          trackingRow.Add(row);
          trackingCol.Add(col);           
          Queen(chess,0,col+1,queens-1); 
        }
        //else Queen(chess,row+1,col,queens);            
      }
    
    // else {
    //   countSln++;
    //   Console.WriteLine("count " + countSln);                   

    // }
  }
  
  public static void SetQueen(int[,] chess, int row, int col,int queens)
  {   
   
  } 
  static bool IsSafe(int[,] chess, int row, int col)
  {
    if (trackingRow.Contains(row) && trackingCol.Contains(col))
      //Queen(chess,row+1,col,queens); // move next row
      return false;

    else if (!IsColSafe(chess,row,col)) //Not safe? move next column
          // Queen(chess,0,col+1,queens);
          return false;
        
    else if (!IsRowSafe(chess,row,col) 
            || !IsDiaSafe(chess,row,col))
      // Queen(chess,row+1,col,queens); // move next row
      return false;
    
    return true;

    static bool IsColSafe(int[,] chess, int row,int col){
      if (row>0)row--;
      for (; row >=0; row--)
        if (chess[row,col]==1) return false;          
      return true;
    }
    static bool IsRowSafe(int[,] chess, int row, int col){
      if (col>0) col--;
      for (;col >=0; col--)
        if(chess[row,col]==1) return false;
      return true;
    }
    static bool IsDiaSafe (int[,] chess, int row, int col){
      // left top      
      int Length= chess.GetLength(0);
      for (int i = 1; row-i >=0 && col-i>=0 ; i++)
        if (chess[row-i,col-i]==1) return false;
        
      for (int i = 1; row + i< Length && col-i >=0; i++)
        if (chess[row+i,col-i]==1) return false;

      return true;
    }
  }
  public static void Tracking(){
     System.Console.Write($"pre row: ");
        foreach (int item in trackingRow)
        {
          System.Console.Write(item +" ");
        }
        System.Console.WriteLine();
        System.Console.Write("pre col: ");
        foreach (int item in trackingCol)
        {
          System.Console.Write(item +" ");
        }
        System.Console.WriteLine();
  }
}
class VetCan
{
  static int count =0;
  static int preRow;
  static int preCol;
  public static void Queen ( int size)
  {    
    for (int col = 0; col < size; col++)
      for (int row = 0; row < size; row++)
      {        
        int[,] board= new int[size,size];
        System.Console.WriteLine($"\tSet queen {row} {col}");
        board[row,col]=1;        

        // Find all posible queens
        if (SetQueen(board,0,0,size-1))
        {          
          count ++;       }
      }
    System.Console.WriteLine("Solutions: "+count);      
  }
  
  static bool SetQueen(int[,] board, int row,int col, int queens)
  {
    if (queens==8) return false;
    int length=board.GetLength(0);
    for( ;queens>0;row++)
    {      
      if (row >=length && col >=length){
        System.Console.WriteLine("Anlon rui");
        System.Console.WriteLine($"\t{row} {col}\n\t Queens {queens-1}");

        // Print.Print2d(board)    ;
        if (queens==0) return true;
        else {
          board[preRow,preCol]=0;
          SetQueen(board, preRow+1,preCol,queens+1);          
          return false;
        }
      }
      if (row >= length) 
        return SetQueen(board, 0 ,col+1, queens);
      else if (col >= length) 
        return SetQueen(board, row +1 ,col, queens); 
      else if (IsSafe(board,row,col) && board[row,col]==0){
        board[row,col]=1;
        preRow=row;
        preCol=col;
        // System.Console.WriteLine($"\tSet queen {row} {col}\n\t Queens {queens-1}");
        return SetQueen(board,0,col+1,queens-1) ;        
      }
        Print.Print2d(board);
    }
    return true;
  }
  public static bool IsSafe(int[,]board,int row, int col)  
  {  
    int size = board.GetLength(0);          
    for (int rows =0 ; rows <size; rows++){
      if (board[rows,col]==1) return false;                      
    }        
    for (int cols =0 ; cols <size; cols++){
      if (board[row,cols]==1) return false;                      
    }

    //check left top
    for (int i = 1; row-i >=0 && col-i>=0 ; i++){
        if (board[row-i,col-i]==1) return false;
    }
    //check left bottom  
    for (int i = 1; row + i< size && col-i >=0; i++){
      if (board[row+i,col-i]==1) return false;
    }
    //check right top
    for (int i = 1; row-i >=0 && col+i <size; i++){
        if (board[row-i,col+i]==1) return false;
    }
    //check right bottom
    for (int i = 1; row+i <size && col+i<size ; i++){
        if (board[row+i,col+i]==1) return false;
    }  

    return true;   
  }
}

class TrackingQueen{
  
}

