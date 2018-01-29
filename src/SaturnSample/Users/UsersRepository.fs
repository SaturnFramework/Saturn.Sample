namespace Users

open Database
open Microsoft.Data.Sqlite
open System.Threading.Tasks

module Database =
  let getAll connectionString : Task<Result<User seq, exn>> =
    use connection = new SqliteConnection(connectionString)
    query connection "SELECT id, password, login FROM Users" None

  let getById connectionString id : Task<Result<User option, exn>> =
    use connection = new SqliteConnection(connectionString)
    querySingle connection "SELECT id, password, login FROM Users WHERE id=@id" (Some <| dict ["id" => id])

  let update connectionString v : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "UPDATE Users SET id = @id, password = @password, login = @login WHERE id=@id" v

  let insert connectionString v : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "INSERT INTO Users(id, password, login) VALUES (@id, @password, @login)" v

  let delete connectionString id : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "DELETE FROM Users WHERE id=@id" (dict ["id" => id])

