using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEf.Models
{
    // CREATE TABLE [User] (
    // [Id] INT NOT NULL IDENTITY(1, 1),
    // [Name] NVARCHAR(80) NOT NULL,
    // [Email] VARCHAR(200) NOT NULL,
    // [PasswordHash] VARCHAR(255) NOT NULL,
    // [Bio] TEXT NOT NULL,
    // [Image] VARCHAR(2000) NOT NULL,
    // [Slug] VARCHAR(80) NOT NULL,

    // CONSTRAINT [PK_User] PRIMARY KEY([Id]),
    // CONSTRAINT [UQ_User_Email] UNIQUE([Email]),
    // CONSTRAINT [UQ_User_Slug] UNIQUE([Slug])
    // )
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Slug { get; set; } = null!;

        public IList<Post> Posts { get; set; }
        public IList<Role> Roles { get; set; }
    }
}