namespace ForumSharp.Views.Shared

open Giraffe.ViewEngine

module Layout =
    let forumPartial =
        div [] [
            //
        ]

    let threadPartial =
        div [] [
            table [] [
                tr [] [
                    td [] [
                        h3 [] [str "Thread title"]
                    ]
                    td [] [
                        h3 [] [str "Replies: 0"]
                    ]
                ]
                tr [] [
                    td [] [
                        strong [] [str "username"]
                    ]
                    td [] [
                        p [] [str "post date/last reply date"]
                    ]
                ]
            ]
        ]

    let postPartial =
        div [] [
            table [] [
                tr [] [
                    td [] [
                        img [_id "ava"]
                    ]
                    td [] [
                        p [] [str "Content"]
                    ]
                ]
                tr [] [
                    td [] [
                        h3 [] [str "username"]
                        strong [] [str "member"]
                    ]
                    td [] [
                        p [] [str "date/reacts/id"]
                    ]
                ]
            ]
        ]

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