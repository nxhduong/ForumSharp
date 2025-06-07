namespace ForumSharp.Models

open Microsoft.EntityFrameworkCore
open System

type ForumContext() = 
    inherit DbContext()

    member this.DbPath = 
            Environment.SpecialFolder.LocalApplicationData 
            |> Environment.GetFolderPath 
            |> fun(p) -> System.IO.Path.Join("forum.db")
            
    override this.OnConfiguring(options) =
        options.UseSqlite $"Data Source={this.DbPath}" |> ignore