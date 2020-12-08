namespace ConsoleApp

open System
open System.IO

module ProgramCommands =

    let readFromString text =
        PrintCommands.printInputString text
        PrintCommands.printHistogram text

    let readFromFile fileName =
        try
            let startTime = DateTime.Now

            let text = File.ReadAllText fileName
            PrintCommands.printHistogram text

            let endTime = DateTime.Now
            PrintCommands.printRunTime startTime endTime

        with
        | :? FileNotFoundException ->
            let message = sprintf "The file '%s' could not be found. Please verify the file exists." fileName
            PrintCommands.printFailureMessage message
        | ex ->
            let message = sprintf "An unexpected error occurred when opening '%s'. Exception: %s." fileName ex.Message
            PrintCommands.printFailureMessage message

    let runCommand (command: string) (input: string) =
        match command with
        | "-s" -> readFromString input
        | "-f" -> readFromFile input
        | _ -> PrintCommands.printInvalidCommandMessage command |> ignore

    let runProgram (argv: string[]) =
        PrintCommands.printWelcomeMessage()

        match argv.Length with
        | 2 -> runCommand (argv.[0]) (argv.[1])
        | _ -> PrintCommands.printMissingCommandMessage () |> ignore
            