module Day3Part2
    open System.Collections.Generic
    open Helpers

    //How many total feet of ribbon should they order?
    let solveDay3Part2 =
        let directions = readInputText "Day3Input.txt"
        let directionList = [for direction in directions -> direction]

        let getPosAfterMove (x: int, y: int) direction =
            match direction with
                | '^' -> (x, y+1)
                | '>' -> (x+1, y)
                | 'v' -> (x, y-1)
                | '<' -> (x-1, y)
                | _ -> (x,y)

        let rec solve (set:Set<int*int>) directions (pos:int*int) (otherPos:int*int) =
            match directions with
            | direction :: tail ->
                let newPos = getPosAfterMove pos direction
                let newSet = set.Add newPos
                solve newSet tail otherPos newPos
            | [] ->
                set

        let startPos = (0,0)
        let startSet = Set.empty.Add(startPos)
        let set = solve startSet directionList startPos startPos

        printf "%d" set.Count