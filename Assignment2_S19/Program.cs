using System;
using System.Collections.Generic;

namespace Assignment2_S19
{
    class Program
    {
        static void Main(string[] args)
        {
            // left rotation
            Console.WriteLine("Left Rotation");
            int d = 4;
            int[] a = { 1, 2, 3, 4, 5 };
            int[] r = rotLeft(a, d);
            displayArray(r);

            // Maximum toys
            Console.WriteLine("\n\nMaximum toys");
            int k = 50;
            int[] prices = { 1, 12, 5, 111, 200, 1000, 10 };
            Console.WriteLine(maximumToys(prices, k));

            // Balanced sums
            Console.WriteLine("\n\nBalanced sums");
            List<int> arr = new List<int> { 1, 2, 3 };
            Console.WriteLine(balancedSums(arr));

            // Missing numbers
            Console.WriteLine("\n\nMissing numbers");
            int[] arr1 = { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206};
            int[] brr = {203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204};
            int[] r2 = missingNumbers(arr1, brr);
            displayArray(r2);

            // grading students
            Console.WriteLine("\n\nGrading students");
            int[] grades = { 73, 67, 38, 33 };
            int[] r3 = gradingStudents(grades);
            displayArray(r3);

            // find the median
            Console.WriteLine("\n\nFind the median");
            int[] arr2 = { 0, 1, 2, 4, 6, 5, 3};
            Console.WriteLine(findMedian(arr2));

            // closest numbers
            Console.WriteLine("\n\nClosest numbers");
            int[] arr3 = { 5, 4, 3, 2 };
            int[] r4 = closestNumbers(arr3);
            displayArray(r4);

            // Day of programmer
            Console.WriteLine("\n\nDay of Programmer");
            int year = 2017;
            Console.WriteLine(dayOfProgrammer(year));

			Console.ReadKey(true);
        }

        static void displayArray(int []arr) {
            Console.WriteLine();
            foreach(int n in arr) {
                Console.Write(n + " ");
            }
        }

        // Complete the rotLeft function below.
        static int[] rotLeft(int[] ar, int d)
        {
			int[] temp_arr = new int[ar.Length]; // created a temp array with size as that of original array
			try
			{

				for (int i = 0; i < ar.Length - d; i++) /* this for loop is for making rotations and loading them into temp array
														 this loop loads (array.length-rotations) elements into temp_arr*/
				{
					temp_arr[i] = ar[i + d];
				}
				for (int i = ar.Length - d; i < ar.Length; i++) /*this for loop is for rotating and loading the elements into temp array
																this loop loads the elements which are not shifted by first loop*/
				{
					temp_arr[i] = ar[i + d - ar.Length];
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An exception occured while computing rotLeft and the exception is {0}", ex.Message);
			}
			return temp_arr;  // returning the rotated array by d rotations
		}

        // Complete the maximumToys function below.
        static int maximumToys(int[] prices, int marksbudget)
		{
			int max_toys = 0, amount_spent = 0;  //intialising max_toys and amount_spent variables
			try
			{
				prices = sortArray(prices);   // sorting the array
				foreach (int k in prices)
				{
					amount_spent += k;        // adding each toy cost to the amount spent after purchasing each toy
					if (amount_spent < marksbudget) /* checking whether the amount_spent is less than the budget of mark, if yes then
													purchasing the toy */
						++max_toys;
					else
						break;                // otherwise mark over ran his budget
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An exception occured while computing maximumToys and the error message is {0}", ex.Message);
			}
			return max_toys;      // returning max_toys that can be purchased with marks budget
		}

        // Complete the balancedSums function below.
        static string balancedSums(List<int> arr)
        {
            return "";
        }

        // Complete the missingNumbers function below.
        static int[] missingNumbers(int[] arr, int[] brr)
        {
			int bfreq, afreq; // declaring afreq and bfreq to hold frequency of each element in two arrays
			bool isfound;
			List<int> misNumbersList = new List<int>(); //list to store missing elements
			try
			{
				for (int i = 0; i < brr.Length; i++)             /* taking each element in b array and checking its frequency and comparing with
																  each element of a*/
				{
					bfreq = 0; afreq = 0; isfound = false;    // intialising frequencies and isfound
					for (int j = 0; j < brr.Length; j++)           // comparing with each element of b to find frequency of each element in b
					{
						if (brr[i] == brr[j])
							bfreq++;                    // upon encountering increase the count by 1
					}
					for (int k = 0; k < arr.Length; k++)      //loop for checking whether element in b is presernt in a array
					{
						if (brr[i] == arr[k])
						{
							afreq++;                //upon encountering increase the count by 1 for element in a and setting isfound to true
							isfound = true;
						}
					}
					if ((!isfound || afreq != bfreq) && !misNumbersList.Contains(brr[i]))   /*checking isfound or not and frequencies are equal
																						using negative logic and whether that element is
																						already added to list by the loop using negative logic
																						*/
						misNumbersList.Add(brr[i]);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occured while computing missingNumbers and the error message is {0}", ex.Message);
			}
			return sortArray(misNumbersList.ToArray());    // converting list to array and calling sortArray method to return sorted array

		}


		// Complete the gradingStudents function below.
		static int[] gradingStudents(int[] grades)
        {
            return new int[] { };
        }

        // Complete the findMedian function below.
        static int findMedian(int[] arr)
        {
            return 0;
        }

        // Complete the closestNumbers function below.
        static int[] closestNumbers(int[] arr)
        {
            return new int[] { };
        }

        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {
            return "";
        }

		static int[] sortArray(int[] arr)
		{
			int position, temp;  // intialising position to hold min value index and temp to swap values
			try
			{
				for (int i = 0; i < arr.Length - 1; i++) /* first for loop for looping all array elements and last element will be automatically sorted
														  after iteration*/

				{
					position = i;
					for (int j = i + 1; j < arr.Length; j++) /*starting from next element of position and looping till end*/
					{
						if (arr[j] < arr[position])   /*if value is less that the value at index then assign then assign it to position*/
						{
							position = j;
						}
					}
					if (position != i)  // if min value index has changed when compared to curr index swapping values
					{
						temp = arr[i];
						arr[i] = arr[position];
						arr[position] = temp;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An exception occured while executing sortArray and the error is {0}", ex.Message);
			}
			return arr;   // returning array after performing selection sort
		}

	}
}
