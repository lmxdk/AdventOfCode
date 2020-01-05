module Day12Part1
    open Helpers
    open System.Text.RegularExpressions

    let solveDay12Part1 =
        let text = readInputText "Day12Input.txt"
        let regex = Regex("-?\\d+")
        let matches = regex.Matches(text)
        let sum = List.sum [for m in matches -> m.Value |> int]
        printfn "%i" sum
