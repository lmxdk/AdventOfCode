module Day5Part2
    open Helpers

    let solveDay5Part2 =
        let words = readInputLines "Day5Input.txt" // [|"qjhvhtzxzqqjkmpb"; "xxyxx"; "uurcxstgmygtbstg"; "ieodomkazucvgmuy" |]

        let rec hasMirrorLetters word otherChar middleChar =
            match word with
            | char :: tail ->
                if char = otherChar then
                    true
                else
                    hasMirrorLetters tail middleChar char
            | [] ->
                false

        let rec hasRepeatedDoubleChar (word:string) index =
            if (index = word.Length-2) then
                false
            else
                let needle = word.Substring(index, 2)
                if (word.IndexOf(needle, index+2) > 0) then
                    true
                else
                    hasRepeatedDoubleChar word (index+1)

        let isNice line =
            let word = [for char in line -> char]
            hasMirrorLetters word 'Ø' 'Ø' && hasRepeatedDoubleChar line 0

        let count = Array.map (fun line -> if (isNice line) then 1 else 0) words
                    |> Array.sum

        printf "%d" count