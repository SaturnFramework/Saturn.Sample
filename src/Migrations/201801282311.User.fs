namespace Migrations
open SimpleMigrations

[<Migration(201801282311L, "Create Users")>]
type CreateUsers() =
  inherit Migration()

  override __.Up() =
    base.Execute(@"CREATE TABLE Users(
      id string NOT NULL,
      password string NOT NULL,
      login string NOT NULL
    )")

  override __.Down() =
    base.Execute(@"DROP TABLE Users")
