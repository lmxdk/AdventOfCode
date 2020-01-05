module Day12Part2
    open Helpers
    open Newtonsoft.Json.Linq

    let solveDay12Part2 =

        let rec sumItem (item:JToken): bool*int =
            let mutable sum = 0
            match item with
            | :? JArray as arr ->
                for a in arr do
                    let _, aSum = sumItem a
                    sum <- sum + aSum
                (false, sum)
            | :? JObject as obj ->
                let mutable hasRed = false
                for prop in obj.Children<JProperty>() do
                    if not hasRed then
                        let isRed, aSum = sumItem prop.Value
                        hasRed <- isRed
                        sum <- sum + aSum
                if hasRed then
                    sum <- 0
                (false, sum)
            | :? JValue as value ->
                match value.Value with
                | :? string as s ->
                    if (s = "red") then
                        (true, 0)
                    else
                        let (parsed, int) = System.Int32.TryParse(s)
                        if (parsed) then
                            (false, int)
                        else
                            (false, 0)
                | :? int64 as l ->
                    (false, int l)
                | :? int as i ->
                    (false, i)
                | :? double as d ->
                    (false, d |> int)
                | _ ->
                    (false, 0)
            | _ ->
                (false, 0)

        let text = readInputText "Day12Input.txt"
        let token = JToken.Parse(text)
        let _, sum = sumItem token
        printfn "%i" sum