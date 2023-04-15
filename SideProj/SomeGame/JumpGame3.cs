using System;
using System.Text;
namespace SomeGame
{
    public class JumpGame3
    {
        //private StringBuilder solution = new StringBuilder();

        
        public bool CanReach(int[] arr, int start) {
            if(arr[start]==0){

                return true;
            }
            else {
                bool goLeft=start-arr[start]>=0;
                bool goRight=start+arr[start]<arr.Length;
                if (goLeft&&goRight)
                {                    
                    if(!CanReach(arr,start+arr[start]))
                    {
                        return CanReach(arr,start-arr[start]);
                    }
                }
                else if (goLeft)
                {
                    return CanReach(arr,start-arr[start]);
                }
                else if (goRight)
                {
                    return CanReach(arr,start+arr[start]);
                }
                else 
                    return false;
                
                return false;
            }
        }
        private void Print() 
        {
            System.Console.WriteLine("");
        }
    
        
    }
}
