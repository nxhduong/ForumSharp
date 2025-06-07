namespace ForumSharp.Models

open ForumSharp.Models.Post

module Board =
    type Board<'T>(Id, Title, Posts) =
        member this.Id = Id
        member this.Title = Title
        member this.Posts : 'T list = Posts

    type Child = Thread of Post list | Board of Board<Child>
    type GeneralBoard = Board<Child>