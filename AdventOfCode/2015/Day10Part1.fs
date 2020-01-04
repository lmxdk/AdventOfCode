module Day10Part1
    open System.Text

    let lookAndSay items =
        let mutable lastNumber = 'Ø'
        let mutable count = 0
        let newItems = new StringBuilder()

        for number in items do
            if lastNumber = number then
                count <- count + 1
            else if lastNumber = 'Ø' then
                count <- 1
            else
                newItems.Append(count) |> ignore
                newItems.Append(lastNumber) |> ignore
                count <- 1

            lastNumber <- number

        newItems.Append(count) |> ignore
        newItems.Append(lastNumber) |> ignore
        newItems.ToString()

    let lookAndSayStep items =
        let mutable newItems = items
        for i = 1 to 40 do
            newItems <- lookAndSay newItems
            //printfn "%s" newItems
            printf "%i " i
        newItems

    let solveDay10Part1 =
        //let result = lookAndSayStepStr "1"
        let result = lookAndSayStep "3113322113"
        printf "%i" result.Length