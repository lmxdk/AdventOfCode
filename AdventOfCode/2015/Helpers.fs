module public Helpers
    open System.IO
    let getInput(fileName): string = Path.Combine(__SOURCE_DIRECTORY__, "input", fileName)

    let readInputText fileName = getInput fileName |> File.ReadAllText
    let readInputLines fileName = getInput fileName |> File.ReadAllLines