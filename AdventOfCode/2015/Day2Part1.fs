module Day2Part1
    open Helpers

    let solveDay2Part1 =
        let packageLines = readInputLines "Day2Part1Input.txt"

        let getSize (line:string) =
            let sizes = line.Split 'x'
                        |> Array.map int
            let l = sizes.[0]
            let w = sizes.[1]
            let h = sizes.[2]
            let slack = [l*w; w*h; h*l]
                        |> List.min
            2*l*w + 2*w*h + 2*h*l + slack

        let area = [for line in packageLines -> getSize(line)]
                   |> List.sum

        printf "%d" area