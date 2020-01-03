module Day9Part1
    open Day1Part1
    open System
    open System.Collections.Generic
    open Helpers

    type Node(id: int, name: string) =
        let mutable connections = new Dictionary<int, int>()
        member this.Id = id
        member this.Name = name
        member this.getConnections = connections

    let solveDay9 isBetterRoute startDistance =
        let lines = readInputLines "Day9Input.txt"

        let nodesByName = new Dictionary<string, Node>()

        let getNode name =
            let (found, node) = nodesByName.TryGetValue name
            if (found) then
                node
            else
                let index = nodesByName.Count
                let newNode = Node(index, name)
                nodesByName.Add(name, newNode)
                newNode

        let readConnection (line:string) =
            let tokens = line.Split(' ')
            let distance = tokens.[4] |> int
            let fromNode = getNode tokens.[0]
            let toNode = getNode tokens.[2]
            fromNode.getConnections.Add(toNode.Id, distance)
            toNode.getConnections.Add(fromNode.Id, distance)

        lines |>
            Array.iter readConnection

        let mutable bestRoute = [||]
        let mutable bestDistance = startDistance

        let nodes = [|for node in nodesByName.Values do node|]
        let routes = enumeratePermutations nodes
        let len = Array.length nodes
        let lenMinusOne = len - 1

        let getDistance (route: Node[]) =
            let mutable last = route.[0]
            let mutable dist = 0
            for i = 1 to lenMinusOne do
                let current = route.[i]
                dist <- dist + last.getConnections.[current.Id]
                last <- current
            dist

        let printRoute dist (route: Node[]) =
            let routeAsNames = route |> Array.map (fun node -> node.Name)
            printfn "%i %s" dist (String.Join(" -> ", routeAsNames))

        for route in routes do
            let distance = getDistance route
            let better = isBetterRoute distance bestDistance
            if better then
                bestRoute <- route.[0..lenMinusOne]
                printRoute distance bestRoute
                bestDistance <- distance

        printRoute bestDistance bestRoute


    let solveDay9Part1 () =
        let comparison distance bestDistance =
            distance < bestDistance
        solveDay9 comparison Int32.MaxValue

    let solveDay9Part2 () =
        let comparison distance bestDistance =
            distance > bestDistance
        solveDay9 comparison Int32.MinValue