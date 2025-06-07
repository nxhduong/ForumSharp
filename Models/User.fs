namespace ForumSharp.Models

open System.ComponentModel.DataAnnotations

module User =
    type User(username, hashPass, avatar, role, bio, reputation) =
        [<Required>]
        [<Length(1, 25)>]
        member this.username: string = username
        
        [<Required>]
        [<DataType(DataType.Password)>]
        member this.hashPass: string = hashPass

        member this.avatar: string = avatar

        [<Length(1, 25)>]
        member this.role = defaultArg role "member"

        member this.bio: string = bio

        member this.reputation = defaultArg reputation 0