module Day14Part2
    open System
    open Helpers

    type Reindeer = { name: string; speed: int; secondsOfMovement: int; secondsOfRest: int; secondsInState: int }
    let solveDay14Part2 () =
        let lines = readInputLines "Day14Input.txt"
        let totalSeconds = 2503

        let reindeer = [|
            for line in lines ->
                let tokens = line.Split(" ")
                let name = tokens.[0]
                let speed = tokens.[3] |> int
                let secondsOfMovement = tokens.[6] |> int
                let secondsOfRest = tokens.[13] |> int
                let deer = { name = name; speed = speed; secondsOfMovement = secondsOfMovement; secondsOfRest = secondsOfRest; secondsInState = 0 }
                deer|]

        let len = Array.length reindeer
        let mutable deerStats = Array2D.create len 4 0
        let distanceIndex = 0
        let stateIndex = 1 // 0 moving, 1 resting
        let secondsInState = 2
        let scoreIndex = 3

        let tick deer index =
            let secs = deerStats.[index, secondsInState] + 1

            if (deerStats.[index, stateIndex] = 0) then //moving
                deerStats.[index, distanceIndex] <- deerStats.[index, distanceIndex] + deer.speed
                if (secs < deer.secondsOfMovement) then
                    deerStats.[index, secondsInState] <- secs
                else
                    deerStats.[index, secondsInState] <- 0
                    deerStats.[index, stateIndex] <- 1
            else //resting
                if (secs < deer.secondsOfRest) then
                    deerStats.[index, secondsInState] <- secs
                else
                    deerStats.[index, secondsInState] <- 0
                    deerStats.[index, stateIndex] <- 0

            deerStats.[index, distanceIndex]

        let mutable maxDistance = Int32.MinValue
        let mutable maxIndexes = []
        let lenMinusOne = len-1

        for sec = 1 to totalSeconds do
            maxDistance <- Int32.MinValue
            maxIndexes <- []

            for i = 0 to lenMinusOne do
                let distance = tick reindeer.[i] i
                if distance > maxDistance then
                    maxIndexes <- [i]
                    maxDistance <- distance
                else if distance = maxDistance then
                    maxIndexes <- List.append maxIndexes [i]


            //printf "%i " sec
            for i in maxIndexes do
                deerStats.[i, scoreIndex] <- deerStats.[i, scoreIndex] + 1
                //printf ", %s score: %i " reindeer.[i].name deerStats.[i, scoreIndex]
            //printfn ", distance: %i"  maxDistance

        let mutable mostPoints = Int32.MinValue
        let mutable bestReindeers = []
        for i = 0 to lenMinusOne do
            let points = deerStats.[i, scoreIndex]
            if points > mostPoints then
                bestReindeers <- [i]
                mostPoints <- points
            else if points = mostPoints then
                bestReindeers <- List.append bestReindeers [i]

        for i in bestReindeers do
            printfn "%s score: %i, dist: %i" reindeer.[i].name deerStats.[i, scoreIndex] deerStats.[i, distanceIndex]