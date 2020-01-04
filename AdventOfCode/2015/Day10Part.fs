module Day10Part
    open System.Text

    let lookAndSay items =
        let mutable lastNumber = 'Ø'
        let mutable count = 0
        let newItems = StringBuilder()

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

    let lookAndSayStep items iterations =
        let mutable newItems = items
        for i = 1 to iterations do
            newItems <- lookAndSay newItems
            //printfn "%s" newItems
            printf "%i " i
        printf "%i" newItems.Length

    let solveDay10Part1 () =
        //let result = lookAndSayStepStr "1"
        lookAndSayStep "3113322113" 40

    let solveDay10Part2 () =
        lookAndSayStep "3113322113" 50