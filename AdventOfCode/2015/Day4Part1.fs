module Day4Part1
    open System.Text
    open System.Security.Cryptography

    exception HashFound
    let solveDay4Part1 =
        let prefix = "yzbqklnj"
        let md5 = MD5.Create()

        let prefixBytes = Encoding.ASCII.GetBytes(prefix)
        let mutable number = 0

        try
            while true do
                let numberBytes = number.ToString()
                                  |> Encoding.ASCII.GetBytes
                let hash = Array.append prefixBytes numberBytes
                           |> md5.ComputeHash
                if (hash.[0] = 0uy && hash.[1] = 0uy && hash.[2] < 16uy) then
                    raise HashFound
                else
                    number <- number + 1
        with
            | HashFound ->

        printf "%d" number