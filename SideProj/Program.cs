using System;
using SomeGame;

public class Program
{
    public static void Main()
    {
        // var TaoDanPark = new PlanningTree(4);
        // TaoDanPark.Park();

        var jumpG = new JumpGame3();
        int[] arr={4,2,3,0,3,1,2};
        int start = 5;
        System.Console.WriteLine(jumpG.CanReach(arr,start));
        
    }
}