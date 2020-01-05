module Day14
    open System
    open System.Collections.Generic
    open Helpers

    type Person(id: int, name: string) =
        let mutable preferences = new Dictionary<int, int>()
        member this.Id = id
        member this.Name = name
        member this.getPreferences = preferences

    let solveDay14  =
        let lines = readInputLines "Day14Input.txt"
        let mutable longestDistance = 0
        let mutable fastestReindeer = "Unknown"
        let totalSeconds = 2503

        for line in lines do
            let tokens = line.Split(" ")
            let name = tokens.[0]
            let speed = tokens.[3] |> int
            let secondsOfMovement = tokens.[6] |> int
            let secondsOfRest = tokens.[13] |> int
            //  0    1    2   3    4  5  6    7       8    9 10    11   12 13  14
            //Dancer can fly 27 km/s for 5 seconds, but then must rest for 132 seconds.

            let secondsPerSegment = secondsOfMovement + secondsOfRest
            let wholeSegments = totalSeconds / secondsPerSegment
            let remainingSeconds = totalSeconds - secondsPerSegment*wholeSegments
            let extraSeconds =
                if (remainingSeconds > secondsOfMovement) then
                    secondsOfMovement
                else
                    remainingSeconds
            let dist = speed*wholeSegments*secondsOfMovement + speed*extraSeconds

            if (dist > longestDistance) then
                longestDistance <- dist
                fastestReindeer <- name

        printfn "%s %i" fastestReindeer longestDistance

    //let solveDay13Part1 () = solveDay13 1
    //let solveDay13Part2 () = solveDay13 2