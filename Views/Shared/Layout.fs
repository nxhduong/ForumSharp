namespace ForumSharp.Views.Shared

open Giraffe.ViewEngine

module Layout =
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
                    body [] content
                ]