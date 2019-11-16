module Day5Part1
    open Helpers

    let solveDay5Part1 =
        let words = readInputLines "Day5Input.txt"

        let rec isNice word lastChar vowelCount hasDoubleChar =
            match word with
            | char :: tail ->
                match (lastChar, char) with
                | ('a', 'b')
                | ('c', 'd')
                | ('p', 'q')
                | ('x', 'y') ->
                    false
                | _ ->
                    let newVowelCount = if "aeiou".Contains(char) then vowelCount + 1 else vowelCount
                    isNice tail char newVowelCount (hasDoubleChar || (char = lastChar))
            | [] ->
                hasDoubleChar && vowelCount >= 3

        let mapIsNice (line:string) =
            let word = [for char in line -> char]
            if (isNice word 'Ø' 0 false) then 1 else 0

        let count = Array.map mapIsNice words
                    |> Array.sum

        printf "%d" count