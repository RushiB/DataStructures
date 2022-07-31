using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgos.Algos
{
    internal class Sort
    {
        // Good reference: mycodeschool
        // https://www.youtube.com/watch?v=TzeBrDU-JaY

        public void MergeSort(ref int[] input)
        {
            // break i/p into 2 halves
            int len = input.Length;
            int mid = len / 2;

            if (len == 1)
            {
                return;
            }

            var leftArr = new int[mid];
            var rightArr = new int[len - mid];

            for(int i = 0; i < leftArr.Length; i++)
            {
                leftArr[i] = input[i];
            }
            for(int i = 0; i < rightArr.Length; i++)
            {
                rightArr[i] = input[i + mid];
            }

            // recursive call on left and right halves
            MergeSort(ref leftArr);
            MergeSort(ref rightArr);

            Console.WriteLine("left, right arr b4 merge:");
            printAllArrays(input, leftArr, rightArr);
            
            // merge both half arrays
            Merge(ref input, leftArr, rightArr);

            Console.WriteLine("left, right arr after merge:");
            printAllArrays(input, leftArr, rightArr);

        }

        public void printAllArrays(int[] input, int[] leftArr, int[] rightArr)
        {
            Console.Write("L -> ");
            foreach (int i in leftArr)
                Console.Write(i + ", ");
                    
            Console.Write("R -> ");
            foreach (int i in rightArr)
                Console.Write(i + ", ");
            
            Console.WriteLine();
            foreach (int i in input)
                Console.Write(i + ", ");
            Console.WriteLine();

        }

        public void Merge(ref int[] input, int[] leftArr, int[] rightArr)
        {
            int inputArrMarker = 0, leftMarker = 0, rightMarker = 0;

            // while loop is bewtfr than for loop to avoid confusion of incrementing here
            //for (inputArrMarker = 0; (inputArrMarker < input.Length); /*inputArrMarker++ <- this shud not be done as this marker is updated inside loop*/)

            while (inputArrMarker < input.Length)
            {
                if (leftArr[leftMarker] <= rightArr[rightMarker])
                {
                    input[inputArrMarker] = leftArr[leftMarker];
                    inputArrMarker++;
                    leftMarker++;
                    
                    if (leftMarker == leftArr.Length)
                        break;
                }
                else
                {
                    input[inputArrMarker] = rightArr[rightMarker];
                    inputArrMarker++;
                    rightMarker++;

                    if (rightMarker == rightArr.Length)
                        break;
                }
            }

            while(leftMarker < leftArr.Length)
            {
                input[inputArrMarker] = leftArr[leftMarker];
                inputArrMarker++;
                leftMarker++;
            }

            while (rightMarker < rightArr.Length)
            {
                input[inputArrMarker] = rightArr[rightMarker];
                inputArrMarker++;
                rightMarker++;
            }

        }


        public void TestSort()
        {
            //var arr = new int[] { 9,8,7,6,5,4 };
            var arr = new int[] { 9,5,7,3,1,2,4,6,9,8,5,10,2};

            MergeSort(ref arr);
        }


    }
}
