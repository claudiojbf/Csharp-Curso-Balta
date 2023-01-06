using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEf.Models
{
    // CREATE TABLE [Tag] (
    //     [Id] INT NOT NULL IDENTITY(1, 1),
    //     [Name] VARCHAR(80) NOT NULL,
    //     [Slug] VARCHAR(80) NOT NULL,

    //     CONSTRAINT [PK_Tag] PRIMARY KEY([Id]),
    //     CONSTRAINT [UQ_Tag_Slug] UNIQUE([Slug])
    // )
    [Table("Tag")]
    public class Tag
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}