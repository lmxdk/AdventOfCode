module Day10Part1
    open System
    open System.Collections.Generic
    open Helpers
    let rec lookAndSay lastNumber count items =
        match items with
        | number :: tail ->
            if lastNumber = number then
                lookAndSay lastNumber (count+1) tail
            else if lastNumber = -1 then
                lookAndSay number 1 tail
            else
                let result = lookAndSay number 1 tail
                List.append [count; lastNumber] result
        | _ ->
            [count; lastNumber]

    let rec lookAndSayStep items iteration =
        if iteration = 40 then
            List.length items
        else
            let newItems = lookAndSay -1 0 items
            newItems |>
                List.map (fun i -> sprintf "%i" i) |>
                List.fold (+) "" |>
                printfn "%s"

            lookAndSayStep newItems (iteration + 1)


    let solveDay10Part1 =
        let result = lookAndSayStep [1] 0
        //let result = lookAndSayStep [3;1;1;3;3;2;2;1;1;3] 0
        printf "%i" result
