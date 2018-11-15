# Code-Challenge
Code Challenge to determine the year(s) in which the most people were alive between 1900-2000

The approach I have taken is a full stack approach using C# as the language to develop the back end server side application with .NET 4.6.1 as the .NET version and NancyFx as I believe NancyFx is a lightweight and all around faster alternative to WebAPI. I will then use Angular to develop the front end. 

The back end server will receive a GET request for the dataset which in turn downloads the CSV file, applies the algorithm and returns it to the front end application as an object consisting of the entire dataset and the year(s) in which the most people was alive during.


When the front end receives this data, it will be displayed concisely, alongside charts showing the frequency of the people alive in all the years between 1900 and 2000.

The dataset I used was generated in Excel as a CSV file. It consists of two columns, Birth Year and Death Year. I then used =RANDBETWEEN(1900, 2000) in the first column to generate a completely random list of birth years, and =RANDBETWEEN(A, 2000) to generate a completely random list of death years which are always the same or greater than the birth year.

| ﻿birth | death |
|-------|-------|
| 1982  | 1992  |
| 1929  | 1999  |
| 1969  | 1995  |
| 1983  | 1987  |
| 1942  | 1978  |
| 1949  | 1993  |
| 1989  | 1993  |
| 1973  | 1979  |
| 2000  | 2000  |
| 1960  | 1997  |
| 1905  | 1994  |
| 1914  | 1916  |

In the dataset there are over 200 entries.


![Page](https://i.imgur.com/uVqRoSu.png)

# From my code it is clear that the two years with the most people alive within my dataset are 1967 and 1968. This is visible in both plain text and in the chart.

Instructions:

Once the repo is cloned, you can open and run the backend application as a command line application, this will start the server on port 8080.

You can then open up the Front end application in any IDE you wish, I developed this in Visual Studio Code. From there you can either 'ng serve' to run the front end on port 4200. You can also (recommended) copy the dist folder after using 'ng build' to the executing folder (debug or release) of the back end server. This will allow the static files to be browsed from http://localhost:8080.
