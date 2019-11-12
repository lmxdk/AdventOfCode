module Day3Part1
    open System.Collections.Generic
    open Helpers

    //How many total feet of ribbon should they order?
    let solveDay3Part1 =
        let directions = readInputText "Day3Input.txt"
        let directionList = [for direction in directions -> direction]

        let getPosAfterMove (x: int, y: int) direction =
            match direction with
                | '^' -> (x, y+1)
                | '>' -> (x+1, y)
                | 'v' -> (x, y-1)
                | '<' -> (x-1, y)
                | _ -> (x,y)

        let rec solve (set:Set<int*int>) directions (x:int, y: int) =
            match directions with
            | direction :: tail ->
                let newPos = getPosAfterMove (x,y) direction
                let newSet = set.Add (x,y)
                solve newSet tail newPos
            | [] ->
                set.Add (x,y)

        let set = solve Set.empty directionList (0,0)

        printf "%d" set.Count