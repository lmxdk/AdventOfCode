module Day8Part2
    open System.Text.RegularExpressions
    open Helpers

    let solveDay8Part2 =
        let lines = readInputLines "Day8Input.txt"

        let regex = new Regex(@"\\|""")
        let countChars (line:string) =
            let matches = regex.Matches(line)
            matches.Count+2

        let memoryDifference =
            lines |>
            Array.map (fun line ->
                let result = countChars line
                result) |>
            Array.sum

        printf "%d" memoryDifference