Problem 1 – Cartesian Coordinate System
========================================

You are given a two-dimensional Cartesian coordinate system and the two coordinates (X and Y) of a point in the coordinate system. If you don't know what Cartesian coordinate system is Google it with Bing. As you will find, the coordinate system is divided by 2 lines (see the picture bellow) which divide the plain in four parts. Each of these parts has a lot of points that are numbered between 1 and 4. There is one point where our lines are crossing. This point has the following coordinates: X=0 and Y=0. As a result this point is numbered 0. The points on the lines are also numbered with the numbers 5 and 6 (again see the picture below).

Your task is to write a program that finds the number of the location of the given point in the coordinate system.
 
#Input
- Input data is being read from the console. 
- The number X is on the first input line.
- The number Y is on the second input line.
- The input data will always be valid and in the format described. There is no need to check it explicitly.

#Output
- The output data must be printed on the console.
- On the only output line you must print an integer number between 0 and 6, depending on the location of the given point in the coordinate system.

#Constraints
- The numbers X and Y are numbers between -2 000 000 000 001 337 and 2 000 000 000 001 337, inclusive.
- Allowed working time for your program: 0.25 seconds.
- Allowed memory: 16 MB.

#Examples


Input:
1
2

Output:
1

-------------------

Input:
-3
-4

Output:
3

---------------------

Input:
-3000
9000

Output:
2

-----------------------

Input:
12345
-98786543

Output:
4

------------------------

Input:
1337
0

Output:
6
