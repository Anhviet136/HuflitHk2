namespace SomeGame;
public class PlanningTree
{
    public int size { get; set; }
        
    private bool[] checkRow;
    private int[] planned;
    private int[] minorTree;
    public PlanningTree ( int parkSize)
    {
        size = parkSize;
        checkRow=new bool[size];
        minorTree=new int[size*2-1];
        planned=new int[size];
        
    }
    private void Planning(int tree,int col)
    {
        if (tree>0)
        {
            if (col==size)
            {
                System.Console.WriteLine("an lon rui");
                Print();
            }
            else
            for (int row = 0; row < size; row++)
            {
                if(CheckTree(row,col))
                {
                    continue;
                }                
                else 
                {
                    //Planning(tree,col+1);
                    planned[col]=row;
                    checkRow[row]=true;
                    
                    minorTree[row+col]++;
                    Planning(tree-1,col+1);
                    checkRow[row]=false;
                    minorTree[row+col]--;
                    //plainned[col]=0;
                }
            }

        }
        else
        {
            System.Console.WriteLine("Yahh!!");
            Print();
        }
    }
    public void Park()
    {        
        Planning(size,0);        
    }
    public void Print()
    {
        System.Console.WriteLine("\t1D array");
        foreach (int item in planned)
        {
            System.Console.Write(item + " ");
        }
        System.Console.WriteLine();
        System.Console.WriteLine("\t2D array");
        int[,] park = new int[size,size];
        for (int  col= 0; col < size; col++)
        {
            //if (planned[i]>0)
            park[planned[col],col]=1;
        }
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                System.Console.Write(park[row,col]+ " ");
            }
            System.Console.WriteLine();
        }
    }

    private bool CheckTree(int row, int col){       
       
        if (minorTree[row+col]>=row+col && row+col <=size)
            return true;
        else if (minorTree[row+col]>row+col-size && row+col >size)
            return true;
        else if (checkRow[row]) return true;         
        else return false;
                
    }
}
