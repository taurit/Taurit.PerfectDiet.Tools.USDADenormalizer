# USDADenormalizer
Creates flat and friendly representation of [USDA National Nutrient Database for Standard Reference (SR)](http://ndb.nal.usda.gov/).

## What does it do

The USDA National Nutrient Database for SR is the major source of food composition data in the United States. It's an enormous source of information about different kinds of food. It contains data about products that are being sold in the United States, but also about raw products (like vegetables or spices) that might be useful for researchers all around the world.

This project aims at reading the database data in a format that it's published by the USDA, and transforming it in a way that the **most important data about food items is stored in a single table**. Also, the naming of the columns in that table is simple and descriptive whenever possible.

In database world this process is called denormalization. In this case, the reason for doing this is to make it easier for people who want to experiment with the nutrient data to start. With a single table, there's no need to install database management system (like Microsoft Access) and write or design queries. Instead, you can just open *.csv* file in Excel or other tools for data analysis and start experimenting.

In original database, there are 12 tables, and there are 136 pages of documentation to understand how entities are connected and what data it contains. Reading it will certainly make you better understand this data, how the studies were conducted, and to what degree can you trust given informations. But it's for you to choose now which approach is more suitable for the problem you are going to solve.

## What is included

In the package you can find:
* **A copy of USDA National Nutrient Database for SR** database in its *sr26-ascii* version (licensed under Creative Commons Attribution)
* **USDADenormalizer**, a C# project of Portable Class Library type. It contains the .NET representation of the data model of the original database, and the model od denormalized representation of this database, along with the logic that allows to transform the former to the latter.
* **USDAExport**, a simple Windows console application in C#, that utilizes the *USDADenormalizer* library to convert the *sr26-ascii* version of the database to a single CSV file. 

## How to run it

USDAExport project is a Windows console application that expects two command-line parameters:

1. Full path to the directory containing ASCII version of database in a filesystem
2. Path to the output CSV file

You can open the solution in Visual Studio 2015, build the library and the console program, and then run the program to perform the transformation. Example:

    d:\food>USDAExport.exe d:\food\sr26-ascii-version\ products.csv

Alternatively, you might include USDADenormalizer library as a reference in your .NET project (targetting any language or platform) and use it as a mean to have strongly-typed representation of the database in both original and flat representation. 

## Bugs and support

The library was developed for my own use, but if you use it and notice some problems or would like to see some improvements, you can use [project's GitHub page](https://github.com/taurit/USDADenormalizer/) to let me know :)
