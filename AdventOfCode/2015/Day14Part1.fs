module Day14Part1
    open Helpers

    let solveDay14Part1  =
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