module Day2Part2
    open Helpers

    //How many total feet of ribbon should they order?
    let solveDay2Part2 =
        let packageLines = readInputLines "Day2Input.txt"

        let getSize (line:string) =
            let sizes = line.Split 'x'
                        |> Array.map int

            let l = sizes.[0]
            let w = sizes.[1]
            let h = sizes.[2]
            let bow = l*w*h

            let sumOfTwoSmallest = sizes |> Array.sort |> Array.take 2 |> Array.sum
            bow + sumOfTwoSmallest*2

        let feetOfRibbon = [for line in packageLines -> getSize(line)]
                           |> List.sum

        printf "%d" feetOfRibbon