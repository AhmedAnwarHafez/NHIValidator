module NHI.Builders.MaybeBuilder

type Maybe() =
        member __.Bind(o, f) = Option.bind f o
        member __.Return(v) = Some v

    let maybe = Maybe()