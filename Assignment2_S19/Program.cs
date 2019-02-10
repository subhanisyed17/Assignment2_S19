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
            long rightsum = 0, leftsum = 0; //intialising leftsum and rightsum
            bool found = false;
            int length = arr.Count;
            try
            {
                while (length > 0)   // calculating the leftsum and rightsum for all elements
                {
                    found = false;
                    for (int j = 0; j < arr.Count; j++)  // for loop to calculate all the right side elements sum
                    {
                        rightsum += arr[j];
                    }
                    for (int k = 0; k < arr.Count; k++) // for loop for calculating left sum and then comparing with rightsum
                    {
                        rightsum -= arr[k];  // removing an element and then it will be added to leftsum  to balance the sum of left and right
                        if (leftsum == rightsum) // comparing left sum and right sum and breaking from loop if such value is found
                        {
                            found = true;   // if such element is found
                            break;
                        }
                        leftsum += arr[k];  // adding the element to leftsum
                    }
                    length--;  // decreasing the length for while condition
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured while computing balancedsums and the error is {0}", ex.Message);
            }
            return (found == true ? "YES" : "NO"); //condition expression using found variable to return yes or no
        }// submitted by Saksham Rana

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
            try
            {
                for (int i = 0; i < grades.Length; i++)   // loop to iterate through all the grades
                {
                    if (grades[i] > 37 && grades[i] % 5 > 2) /*checking whether grade is atleast 38 and whether grades 
																deserves for rounding off nearest multiple of 5*/
                    {
                        grades[i] += (5 - (grades[i] % 5));   // if yes rounding off the grade to nearest multiple of 5
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured while computing gardingStudents and the error is {0}", ex.Message);
            }
            return grades;
        }//submitted by saksham rana

        // Complete the findMedian function below.
        static int findMedian(int[] arr)
        {
            try
            {
                int result = 0; //variable to store the result
                int median_index; /*variable to store median index*/
                int temp;/*temporary variable used for swap operation during sorting*/
                median_index = arr.Length / 2; /* As the array length is always odd,median_index will be length of array divided by 2*/
                for (int i = 0; i < arr.Length - 1; i++) //for loop for selection sort
                {


                    for (int j = i + 1; j < arr.Length; j++) // inner for loop to iterate from (i+1)th element 
                    {
                        if (arr[j] < arr[i])// swap operation to bring lowest number to starting position
                        {
                            temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                        } //edof if




                    }//edof for with iteration 


                    if (i == median_index)// sorting the array only till the median index, to optimize the code.
                    {
                        result = arr[i];
                    }//edof if

                }//edof for with iteration variable i


                return result;

            } //edof try
            catch
            {
                Console.WriteLine("error occured in findMedian function");
                return 0;
            }//edof catch


        }//edof findMedian function-submitted by Indra Reddy


        // Complete the closestNumbers function below.
        static int[] closestNumbers(int[] arr)
        {

            try
            {
                int[] sorted_arr = sortArray(arr); //calling function to sort the elements

                int min_diff = sorted_arr[1] - sorted_arr[0]; //variable to store minimum difference between the elements in array
                List<int> result_list = new List<int>() { sorted_arr[0], sorted_arr[1] }; //list to store the result variables

                for (int i = 1; i < (sorted_arr.Length - 1); i++) //for loop to iterate through 0th index till last but one index
                {
                    if (min_diff > sorted_arr[i + 1] - sorted_arr[i]) /*condition to check if difference between adjacent numbers 
                                                                          is less than the min_diff
                                                                          if condition is met, clear the list and add both adjacent numbers*/
                    {
                        result_list.Clear();
                        result_list.Add(sorted_arr[i]);
                        result_list.Add(sorted_arr[i + 1]);
                        min_diff = sorted_arr[i + 1] - sorted_arr[i];// set new value to min_diff

                    }//edof if 
                    else if (min_diff == sorted_arr[i + 1] - sorted_arr[i]) /* condition to check if difference between adjacent numbers
                                                                                    is equal to min_diff
                                                                                    if condition is met,append adjacent numbers to list*/
                    {
                        result_list.Add(sorted_arr[i]);
                        result_list.Add(sorted_arr[i + 1]);

                    }//edof else if

                }//edof for


                return result_list.ToArray();//converting list to array and returning


            }//edof try
            catch
            {
                Console.WriteLine("Error occured while finding closest numbers");
                return new int[] { };
            }//edof catch


        }//edof ClosestNumbers function-Submitted by Indra Reddy

        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {
            string result; //variable to store the result date
            try
            {
                if (year > 1918) //condition for Gregorian calendar system
                {
                    if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) //Checking if the year is a leap year
                    {
                        result = "12.09." + year.ToString(); //result if if its loop year
                    }//edof leap year if
                    else
                    {
                        result = "13.09." + year.ToString(); //result if not a leap year
                    }//edof if
                }//edof if year condition

                else if (year < 1917)// condition for Julian calendar
                {
                    if (year % 4 == 0) // condition for leap year
                    {
                        result = "12.09." + year.ToString(); //Day of the programmer if year selected is leap year
                    }//edof leap year if
                    else
                    {
                        result = "13.09." + year.ToString();  //Day of the programmer if year selected is not an leap year
                    }//edof if
                }//edof if <1918

                else
                {
                    result = "26.09.1918"; // Day of the programmer if year selected is 1918
                }//edof else
            }
            catch
            {
                Console.WriteLine("Exception occured in dayofProgrammer");
                return "error";
            }//edof catch


            return result;
        }//edof method Day of programmer-submitted by Indra Reddy

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


		#region
		/*second approach for missing nummbers without using list.contains() method*/

		//static int[] missingNumbers(int[] arr, int[] brr)
		//{
		//	var watch = Stopwatch.StartNew();
		//	List<int> missingnumberslist = new List<int>(); /*this list is used only to store missing numbers
		//													as a dynamic collection is needed to store missing numbers*/
		//	bool matched;
		//	try
		//	{
		//		int[] afreq = calFrequency(arr);          /*calculates frequency of array, (i) will have value 
		//													and (i+1) will have frequency of element at i */
		//		int[] bfreq = calFrequency(brr);
		//		for (int i = 0; (i + 1) < bfreq.Length; i += 2)     /*looping through original array b and checking whether
		//															that element is present in missing array a*/
		//		{
		//			matched = false;
		//			for (int j = 0; (j + 1) < afreq.Length; j += 2)  /*looping through a array for element at index and frequency comparison*/
		//			{
		//				if (bfreq[i] == afreq[j] && bfreq[i + 1] == afreq[j + 1])   /*checking whether element is present and frequency 
		//																			is equal in both array a and b*/
		//				{
		//					matched = true;                        // if element is found and frequencies are equal then its match
		//				}
		//			}
		//			if (!matched)
		//				missingnumberslist.Add(bfreq[i]);       // if not match then adding it in missing numbers list
		//		}

		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine("An error occured while computing missingNumbers and the error message is {0}", ex.Message);
		//	}
		//	watch.Stop();
		//	Console.WriteLine("Time Taken by missing numbers function is {0}",watch.ElapsedMilliseconds);
		//	return sortArray(missingnumberslist.ToArray());
		//}

		//static int[] calFrequency(int[] ar)
		//{
		//	int count;
		//	int[] freq = new int[ar.Length];  // freq array to set dummy frequency to all elements of ar array intially
		//	List<int> arvalandfreq = new List<int>();  // this list will store value and frequency of that value next to each other
		//	try
		//	{
		//		for (int i = 0; i < freq.Length; i++) //loop to assign dummy frequency for all elements intially
		//		{
		//			freq[i] = -1;
		//		}
		//		for (int i = 0; i < ar.Length; i++)  // taking each element 
		//		{
		//			count = 1;                      // every variable will have frequency >= 1
		//			for (int j = i + 1; j < ar.Length; j++)  // comparing that element with all other remaining elements of array
		//			{
		//				if (ar[i] == ar[j])       // if element found assigning its frequency to 0 and increasing the count by 1
		//				{
		//					freq[j] = 0;
		//					count++;
		//				}
		//			}
		//			if (freq[i] != 0)     // if frequency!=0 adding the element and its frequency to list
		//			{
		//				arvalandfreq.Add(ar[i]);   //adding element
		//				arvalandfreq.Add(count);   // adding frequency of that element
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine("An error occured while computing calFrequency and the error message is {0}", ex.Message);
		//	}
		//	return arvalandfreq.ToArray();  // converting the list to array and returning
		//}

		#endregion

	}
}
