module Day13
    open System
    open System.Collections.Generic
    open Helpers

    type Person(id: int, name: string) =
        let mutable preferences = new Dictionary<int, int>()
        member this.Id = id
        member this.Name = name
        member this.getPreferences = preferences

    let solveDay13Part1 =
        let lines = readInputLines "Day13Input.txt"
        let personsByName = Dictionary<string, Person>()

        let getPerson name =
            let (found, person) = personsByName.TryGetValue name
            if (found) then
                person
            else
                let index = personsByName.Count
                let newNode = Person(index, name)
                personsByName.Add(name, newNode)
                newNode

        let parsePreferences (line:string) =
            let tokens = line.Split(" ")
            let amount = (tokens.[3] |> int) * (if tokens.[2] = "lose" then -1 else 1)
            let person = getPerson(tokens.[0])
            let target = getPerson(tokens.[10].Trim '.')
            person.getPreferences.Add(target.Id, amount)

        for line in lines do parsePreferences line
        let mutable bestSeating = [||]
        let mutable bestHappiness = Int32.MinValue

        let persons = [|for person in personsByName.Values do person|]
        let seatings = enumeratePermutations persons
        let len = Array.length persons
        let lenMinusOne = len - 1

        let getHappiness (seats: Person[]) =
            let mutable last = seats.[lenMinusOne]
            let mutable happiness = 0
            for i = 0 to lenMinusOne do
                let current = seats.[i]
                happiness <- happiness + last.getPreferences.[current.Id] + current.getPreferences.[last.Id]
                last <- current
            happiness

        for seating in seatings do
            let happiness = getHappiness seating
            if happiness > bestHappiness then
                bestSeating <- seating.[0..lenMinusOne]
                bestHappiness <- happiness

        printfn "%O" bestHappiness