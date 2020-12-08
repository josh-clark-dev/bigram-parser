# Bigram Parsing Program - a bigram parsing and histogram solution

## Table of Contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)

## General info
This project contains a program used to parse input text and output the bigrams contained within the text.

The parser, written in C#, reads the input text, removes any special characters, and outputs a histogram of the bigrams.
The command line application, written in F#, is used to run the parser and to output the histogram to the console.

## Technologies
.NET 5
.NET Standard 2.1
C# 8.0
F# 5.0

## Setup
```
This program is configured to run on Windows, but can be configured to run on any operating system.
To run this program on Windows, perform the following steps:

1. Open the solution in Visual Studios
2. Right click the BigramParsingProgram project, select 'Publish', and then select 'Publish to Folder'.
3. Copy the published folder to a location of your choice.
4. To execute the program run one of the following commands:
   BigramParsingProgram.exe -s <STRING> or -f <FILE_NAME>

   Example Commands:
     - BigramParsingProgram.exe -s "The quick brown fox and the quick blue hare."
     - BigramParsingProgram.exe -f Input.txt

   Example Output:
    "the quick": 2
    "quick brown": 1
    "brown fox": 1
    "fox and": 1
    "and the": 1
    "quick blue": 1
    "blue hare": 1 
```