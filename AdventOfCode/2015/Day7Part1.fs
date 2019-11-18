module Day7Part1
    open System.Collections.Generic
    open Helpers

    exception UnkownOperator

    let solveDay7Part1 =
        let instructions = readInputLines "Day7Input.txt"

        let wiresWithValue = new Dictionary<string, uint16>()
        let wiresWithTokens = new Dictionary<string, string[]>()

        let parseLine (line:string) =
            let tokens = line.Split ' '
            let wire = tokens.[tokens.Length-1]
            wiresWithTokens.Add(wire, tokens)

        for line in instructions do
            parseLine line |> ignore

        let rec evaluate (wire:string) =
            let (intParsed, int) = System.UInt16.TryParse(wire)
            if (intParsed) then
                int
            else
                let (found, value) = wiresWithValue.TryGetValue(wire)
                if (found) then
                    value
                else
                    let tokens = wiresWithTokens.[wire]
                    let result =
                        if tokens.[0] = "NOT" then
                            ~~~ (evaluate tokens.[1])
                        else if tokens.Length = 5 then
                            let leftOperand = (evaluate tokens.[0])
                            let rightOperand = (evaluate tokens.[2])
                            match tokens.[1] with
                            | "OR" -> leftOperand ||| rightOperand
                            | "AND" -> leftOperand &&& rightOperand
                            | "LSHIFT" -> leftOperand <<< (rightOperand |> int32)
                            | "RSHIFT" -> leftOperand >>> (rightOperand |> int32)
                            | _ -> raise UnkownOperator
                        else //"->"
                            evaluate tokens.[0]

                    wiresWithValue.Add(wire, result)
                    //printf "%s = %d\r\n" wire result
                    result

        evaluate "a" |>
            printf "%d"