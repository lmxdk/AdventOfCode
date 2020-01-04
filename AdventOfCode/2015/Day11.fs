module Day11
    open System.Text

    let solveDay11 (lastPassword:string) =
        let password = StringBuilder(lastPassword)
        let len = lastPassword.Length-1

        let notValid (password:StringBuilder) =
            let mutable lastChar = password.[0]

            let mutable repeatedChar = 'Ø'
            let mutable repeats = 0
            let mutable ascending = 0
            let mutable hasAscending = false
            for x = 1 to len do
                let c = password.[x]
                if c = lastChar then
                    if repeatedChar <> c then
                        repeatedChar <- c
                        repeats <- repeats + 1
                    ascending <- 0
                else if c = lastChar + char 1 then
                    ascending <- ascending + 1
                    if ascending = 2 then
                        hasAscending <- true
                else
                    ascending <- 0
                lastChar <- c

            (not hasAscending) || repeats < 2

        let mutable i = len
        let nextPassword () =
            let letter = password.[i]
            match letter with
            | 'h' | 'k' | 'n' ->
                password.[i] <- letter + char 2
                i <- len
                notValid password
            | 'z' ->
                password.[i] <- 'a'
                i <- i-1
                true
            | _ ->
                password.[i] <- letter + char 1
                i <- len
                notValid password

        while nextPassword () do
            //printfn "%O" password
            ignore |> ignore

        printfn "%O" password

    let solveDay11Part1 () =
        solveDay11 "hxbxwxba"

    let solveDay11Part2 () =
        solveDay11 "hxbxxyzz"
