module Day6Part2
    open System
    open Helpers

    exception UnknownInstruction
    let solveDay6Part2 =
        let instructions = readInputLines "Day6Input.txt"

        let width = 10_000
        let height = 10_000
        let mutable lights = Array2D.create height width 0

        let parsePoint (pointStr:string) =
            let parts = pointStr.Split ','
            ((parts.[0] |> int), parts.[1] |> int)

        let turn delta =
            fun x y -> lights.[x,y] <- Math.Max(lights.[x,y] + delta, 0)

        let applyToMap func (startX, startY) (endX, endY) =
            for y = startY to endY do
                for x = startX to endX do
                    func x y

        let parseInstruction (instruction:string) =
            let items = instruction.Split ' '
            match items.[0] with
            | "toggle" ->
                applyToMap (turn 2) (parsePoint items.[1]) (parsePoint items.[3])
            | "turn" ->
                applyToMap (turn (if items.[1] = "on" then 1 else -1)) (parsePoint items.[2]) (parsePoint items.[4])
            | _ -> raise UnknownInstruction

        instructions |>
            Array.iter parseInstruction

        let mutable count = 0
        lights |>
            Array2D.iter (fun i -> count <- count+i)

        printf "%d" count