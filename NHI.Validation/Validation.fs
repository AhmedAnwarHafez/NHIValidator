module NHI.Validation

open NHI.Utils
open NHI.Builders.MaybeBuilder

let tryChecksum (input:string) :int option =
    let getListExceptLast list =
        // return a list except for last element
        // ex: [1,2,3] -> [2,1]
        list |> List.rev |> tryTail
    let modulus x = x % 11
    input
    |> Seq.toList // convert a sequence of chars into a list
    |> List.map (fun x -> x |> getCharValue) // map the value for each char
       // map with index and multiply the element's value with (7 - index)
    |> List.mapi (fun i v -> v |> Option.bind (fun x -> Some(x * ( 7 - i))))  
    |> getListExceptLast
    |> Option.bind (List.reduce plus)
    |> Option.map (fun x -> x % 11)

let tryGetLastChar (input:string) =
    input
    |> Seq.tryLast

let tryCheckDigit checksum : int option = 
    match checksum with
    | 0 -> None
    | _ -> Some((11 - checksum) % 10)


let validate input = 
    let result = maybe {
        let! checksum = tryChecksum input
        let! digit = tryCheckDigit checksum
        let! lastchar = tryGetLastChar input
        let! lastCharValue = tryCharToInt lastchar
        return lastCharValue = digit
    }
    match result with
    | Some _ -> true
    | None -> false
