# Bigram Parsing Program

A bigram parsing and histogram solution

## Table of Contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)

## General info
This project contains a program used to parse input text, either a string or file, and output the bigrams contained within the text.

The parser, written in C#, reads the input text, removes any special characters, and outputs a histogram of the bigrams.
The command line application, written in F#, is used to run the parser and to output the histogram to the console.

The program is designed to only support sentences written in English.  Other languages are not supported at this time.

## Technologies
- .NET 5
- .NET Standard 2.1
- C# 8.0
- F# 5.0

## Setup
```
This program is configured to run on Windows but can be configured to run on any operating system.
To run this program on Windows, perform the following steps:

1. Create a local copy of the repository.
2. Open the solution in Visual Studios.
3. Right click the BigramParsingProgram project, select 'Publish', and then select 'Publish to Folder'.
4. Copy the published folder to a location of your choice.
5. To execute the program from the command prompt run one of the following commands:
   BigramParsingProgram.exe -s <STRING> or -f <FILE_NAME>

   Example Commands:
     - BigramParsingProgram.exe -s "Santa is coming to town today and Santa is going to bring presents!"
     - BigramParsingProgram.exe -f Input.txt

   Example Output:
    "santa is": 2
    "is coming": 1
    "coming to": 1
    "to town": 1
    "town today": 1
    "today and": 1
    "and santa": 1
    "is going": 1
    "going to": 1
    "to bring": 1
    "bring presents": 1
```
