#load "Utils.fs"
#load "MaybeBuilder.fs"
#load "Validation.fs"
open NHI.Validation


let ``Bad NHI should return false`` = 
    validate "DAB8233"

let ``Good NHI should return true`` = 
    validate "CGC2720"

let ``Good' NHI should return true`` = 
    validate "EPT6335"

let ``Singleton list should return false`` = 
    validate "X"

let ``Empty list should return false`` = 
    validate ""

let ``A list with more than seven chars should return false`` = 
    validate "XXXXXXX"

let ``A list with a non alpha numeric should return false`` = 
    validate "#$%^&*()"

let ``n null value should return false`` = 
    validate null