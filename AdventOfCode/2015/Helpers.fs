module public Helpers
    open System.IO
    let getInput(fileName): string = Path.Combine(__SOURCE_DIRECTORY__, "input", fileName)

    let readInputText fileName = getInput fileName |> File.ReadAllText
    let readInputLines fileName = getInput fileName |> File.ReadAllLines

    let swap arr index otherIndex =
        let value = Array.get arr index
        let otherValue = Array.get arr otherIndex
        Array.set arr index otherValue
        Array.set arr otherIndex value
        None

    let enumeratePermutations arr =
        let n = Array.length arr
        //c is an encoding of the stack state. c[k] encodes the for-loop counter for when generate(k+1, A) is called
        let mutable c = Array.zeroCreate n

        seq {
            yield arr

            //i acts similarly to the stack pointer
            let mutable i = 0
            while i < n do
                let ci = c.[i]
                if ci < i then
                    if i % 2 = 0 then //even
                        swap arr 0 i |> ignore
                    else
                        swap arr ci i |> ignore

                    yield arr

                    //Swap has occurred ending the for-loop. Simulate the increment of the for-loop counter
                    c.[i] <- ci + 1
                    //Simulate recursive call reaching the base case by bringing the pointer to the base case analog in the array
                    i <- 0
                else
                    //Calling generate(i+1, A) has ended as the for-loop terminated. Reset the state and simulate popping the stack by incrementing the pointer.
                    c.[i] <- 0
                    i <- i + 1
        }