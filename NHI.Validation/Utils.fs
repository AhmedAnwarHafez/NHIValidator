module NHI.Utils

open System.Text.RegularExpressions
open System


// apply regular expression
let isMatch input =
    let pattern = @"^[A-HJ-NP-Z]{3}[0-9]{4}$"
    let reg = new Regex(pattern)
    match reg.IsMatch(input) with
    | true  -> Some(input)
    | false -> None


// find the integer value of a char in a list of alphabets (except O and I letters)
// example 'A' returns 1
// example 'Z' returns 24
let tryCharToVal (c:char) :int option =
    // alpha conversion table omitting O and I. A=1~Z=24
    let alphabet = [ 'A'; 'B'; 'C'; 'D'; 'E'; 'F'; 'G'; 'H'; 'J'; 'K'; 'L'; 'M'; 'N'; 'P'; 'Q'; 'R'; 'S'; 'T'; 'U'; 'V'; 'W'; 'X'; 'Y'; 'Z' ]
    alphabet
    |> List.tryFindIndex (fun x -> c.Equals(x))
    |> Option.bind (fun x -> Some(x + 1)) // add one to start indexing from 1

// parse char to int
// example '5' returns 5
let tryCharToInt (c:char) :int option =
    match Int32.TryParse(string c) with 
    | (true, n) -> Some(n)
    | (false, _) -> None

// for a given char, check if it's a letter or a number, then get the integer value
let getCharValue (c:char) : int Option =
    match (Char.IsLetter(c), Char.IsNumber(c)) with
    | (true, _) ->  tryCharToVal c
    | (_, true) ->  tryCharToInt c
    | (_,_)     ->  None

// appy a binary operation if both operands have values
let lift op a b =
    match a, b with
    | Some av, Some bv  -> Some(op av bv)
    | _,_               -> None

// an addition function
let plus = lift (+)

// get the tail in a list of any length
let tryTail xs :'a list option =
    match xs with
    | []        -> None
    | [x]       -> None
    | _::xs     -> Some(xs)
