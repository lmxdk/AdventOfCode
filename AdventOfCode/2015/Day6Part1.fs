module Day6Part1
    open System
    open Helpers

    exception UnknownInstruction
    let solveDay6Part1 =
        let instructions = readInputLines "Day6Input.txt"

        let width = 10_000
        let height = 10_000
        let mutable lights = Array2D.create height width false

        let parsePoint (pointStr:string) =
            let parts = pointStr.Split ','
            ((parts.[0] |> int), parts.[1] |> int)

        let toggle =
            fun x y -> lights.[x,y] <- not lights.[x,y]

        let turn state =
            fun x y -> lights.[x,y] <- state

        let applyToMap func (startX, startY) (endX, endY) =
            for y = startY to endY do
                for x = startX to endX do
                    func x y

        let parseInstruction (instruction:string) =
            let items = instruction.Split ' '
            match items.[0] with
            | "toggle" ->
                applyToMap toggle (parsePoint items.[1]) (parsePoint items.[3])
            | "turn" ->
                applyToMap (turn (items.[1] = "on")) (parsePoint items.[2]) (parsePoint items.[4])
            | _ -> raise UnknownInstruction

        instructions |>
            Array.iter parseInstruction

        let mutable count = 0
        lights |>
            Array2D.iter (fun i ->
                if i then
                    count <- count+1)

        printf "%d" count