namespace ForumSharp.Views.Shared

open Giraffe.ViewEngine

module Layout =
    let forumPartial =
        div [] [
            //
        ]

    let threadPartial =
        div [] []

    let postPartial =
        div [] []

    let common (content: XmlNode list) =
        html [] [
            head [] [
                title []  [ encodedText "ForumSharp" ]
                link [ 
                    _rel  "stylesheet"
                    _type "text/css"
                    _href "/main.css" 
                    ]
            ]
            body [] [
                header [] [
                    h1 [] [str "ForumSharp"]
                    form [_id "search"] [
                        input [_type "text"]
                        input [_type "submit"] 
                    ]
                ]
                div [_id "sidebar"] [
                    div [_id "recent"] []
                    div [_id "popular"] []
                ]
                div [_id "stats"] []
                div [] content
                footer [] []
            ]
        ]