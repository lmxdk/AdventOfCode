module Day1Part2
    open Helpers
    exception BasementFound

    let solveDay1Part2 =
        let directions = readInputText "Day1Input.txt"

        //find the first position 1 based that yields the basement (floor -1)
        let rec solve chars floor index =
            match chars with
             | head :: tail ->
                let newFloor = floor + (if head = '(' then 1 else -1)
                if (newFloor = -1) then
                    index
                else
                    solve tail newFloor index+1
             | [] -> -1

        let charList = [for char in directions -> char]
        let index = solve charList 0 0

        printf "%d" index