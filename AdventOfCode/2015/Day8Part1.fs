module Day8Part1
    open System.Text.RegularExpressions
    open Helpers

    let solveDay8Part1 =
        let lines = readInputLines "Day8Input.txt"

        let regex = new Regex("\\\\(x[a-fA-F0-9]{2}|\"|\\\\)")
        let countChars (line:string) =
            let unquoted = line.Substring(1, line.Length-2)
            let matches = regex.Matches(unquoted)
            let sum =
                [for m in matches -> m.Length-1] |>
                List.sum
            sum+2

        let memoryDifference =
            lines |>
            Array.map (fun line ->
                let result = countChars line
                // printf "%d\r\n" result
                result) |>
            Array.sum

        printf "%d" memoryDifference