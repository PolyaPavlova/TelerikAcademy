Problem 2 – Tribonacci
=======================

The Tribonacci sequence is a sequence in which every next element is made by the sum of the previous three elements from the sequence.

T<sub>n</sub> = T<sub>n-1</sub> + T<sub>n-2</sub> + T<sub>n-3</sub>
 
Write a computer program that finds the Nth element of the Tribonacci sequence, if you are given the first three elements of the sequence and the number N. Mathematically said: with given T1, T2 and T3 – you must find Tn.

#Input
- The input data should be read from the console.
- The values of the first three Tribonacci elements will be given on the first three input lines.
- The number N will be on the fourth line. This is the number of the consecutive element of the sequence that must be found by your program.
- The input data will always be valid and in the format described. There is no need to check it explicitly.

#Output
- The output data should be printed on the console.
- At the only output line you must print the Nth element of the given Tribonacci sequence.

#Constraints
- The values of the first three elements of the sequence will be integers between -2 000 000 000 and 2 000 000 000.
- The number N will be a positive integer between 1 and 15 000, inclusive.
- Allowed working time for your program: 0.25 seconds.
- Allowed memory: 16 MB.

#Examples

Input:
1
1
1
4


Output:
3

------------------

Input: 
2
3
4
10

Output:
335
