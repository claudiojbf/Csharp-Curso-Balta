namespace BlogEf.Models
{
    // CREATE TABLE [Role] (
    // [Id] INT NOT NULL IDENTITY(1, 1),
    // [Name] VARCHAR(80) NOT NULL,
    // [Slug] VARCHAR(80) NOT NULL,

    // CONSTRAINT [PK_Role] PRIMARY KEY([Id]),
    // CONSTRAINT [UQ_Role_Slug] UNIQUE([Slug])
    // )
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;

        public List<User> Users { get; set; }
    }
}