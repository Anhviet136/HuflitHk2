using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using SomeCode lib
using SomeCode; 

    class Program
    {
        static void B1(){            
            int size = 8;
            // Funcion in SomeCode namespace
            int[]arr = Input.RandomArr(size);
            Print.PrintArr(arr);

            int Min= Bai1.FindMin(arr,0,arr.Length-1);
            System.Console.WriteLine("Find min: "+Min);                        

        }
        static void B2()
        {
            int size = 9;
            int[] arr ={8,5,7,2,6,9,1,4,3};
            //int[] arr=Input.RandomArr(size);
            Print.PrintArr(arr);

            Algorithms.QickSort(arr, 0, size-1);
            Print.PrintArr(arr);

            int x=23;
            int indexOf=Bai2.BinarySearch(arr,x);
            System.Console.WriteLine($"index of {x} is {indexOf}" );
        }
        static void Main(string[] args)
        {
            // B2();
            Bai3.HanoiTower(1,'A','B','C')  ;
            
        } }
    class Bai1 {
        public static int FindMin( int[]arr,int left, int right) 
        {
            // If array have 1 element
            if (left == right) return arr[left];
            // if array have 2 element
            else if (left == right - 1)
            {
                if (arr[left] > arr[right]) return arr[right];
                else return arr[left];
            }
            // 
            else {
                int mid = (left + right) / 2;
                //Divice the array
                int temp1= FindMin(arr, left, mid);
                int temp2= FindMin(arr, mid + 1, right);
                if (temp1 > temp2) return temp2;
                else return temp1;
            }             
        }                
    }
    class Bai2{
        public static int BinarySearch(int[] arr,int x) 
        {
            //Algorithms.QickSort(arr,0,arr.Length-1);
            int low = 0;
            int hight = arr.Length;                        
            int mid= (low+hight)/2;

            for (;x!=arr[mid];) // stop case: mid is index of x in array
            { 
                // x in the right of mid
                if (x > arr[mid] ) low = mid+1;
                // x in the left of mid
                else hight=mid-1;  

                mid= (low+hight)/2;   
               // System.Console.WriteLine($"low: {low}\tmid: {mid}\thight: {hight}");
                // stop case: x nor in the left or right of mid
                if (mid== hight || mid == low) return -1;
            }
            return mid;            
        }
    }
    class Bai3{
        public static void HanoiTower (int disk, char sauce, char mid, char des)
        {
            if (disk >0){                                
                // move n-1 disk to mid tower
                HanoiTower (disk-1, sauce, des,mid);
                //
                System.Console.WriteLine($"Take {disk} disk {sauce} to {des}"  );
                //move n-1 disk from mid tower to destiny tower
                HanoiTower(disk-1, mid,sauce,des);                
            }
         }
    }

