namespace ForumSharp.Models

module Post =
    type Post(Id, Title, Content, Author, Time, Reacts) =
        member this.Id: string = Id
        member this.Title: string = Title
        member this.Content: string = Content
        member this.Author: string = Author
        member this.Time: string = Time
        member this.Reacts: (string * string) list = Reacts