module Day1Part1
    open Helpers
    let solveDay1Part1 =
        let directions = readInputText "Day1Input.txt"

        let floor =
            [for char in directions -> if char = '(' then 1 else -1] |>
                List.sum

        printf "%d" floor