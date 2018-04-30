## NHI Validator

NHI is a unique 7-characters code assigned to New Zealand patients.
The NHI valiation can be done offline using a simple algorithm ([Wikipedia](https://en.wikipedia.org/wiki/NHI_Number)).
This is an implementation of the NHI validation written in F#.

Here is an example on how to consume the library.
First add a reference to the library `open NHI.Validation` and then call `validate` function.
Bad NHI will return `false`, otherwise, it will return `true`.
    
``` 
validate "DAB8233"
val it : bool = false
``` 

``` 
validate "CGC2720"
val it : bool = true
``` 