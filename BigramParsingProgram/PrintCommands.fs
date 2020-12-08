namespace ConsoleApp

open BigramParser
open System

module PrintCommands =   
    let printWelcomeMessage () =
        printfn "Welcome to the Bigram Parsing Program!"
        printfn "This program will parse the input text you provided and output a histogram of the bigrams contained within the text."
        printfn ""

    let printInputString text =
        printfn "Here is the text you provided:"
        printfn "%s" text
        printfn ""

    let printHistogram text =
        let histogram = new Histogram((new Parser()))
    
        let bigrams = histogram.GetHistogram text

        match bigrams.Count with
        | 0 -> printf "There are no bigrams within the provided text."
        | _ -> printfn "Here is the list of bigrams contained with the text:"
               bigrams |> Seq.iter(fun x -> printfn """"%s": %i""" x.Words x.Count)

    let printInvalidCommandMessage command =
         printf "'%s' is not a valid command. Valid commands are: [-s <STRING>] [-f <FILE_NAME>]." command

    let printMissingCommandMessage () =
        printf "To run this program, you must enter one of the following commands: -s <STRING> or -f <FILE_NAME>."

    let printFailureMessage message =
        printf "%s" message

    let printRunTime (startTime: DateTime) (endTime: DateTime) =
        printfn ""
        printf "Runtime: %s" ((endTime - startTime).ToString())