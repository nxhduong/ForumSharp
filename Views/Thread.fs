namespace ForumSharp.Views

open Giraffe
open Giraffe.ViewEngine
open ForumSharp.Views.Shared

module Thread =
    let layout =
        Layout.common []

    let handler (name : string) =
        htmlView layout