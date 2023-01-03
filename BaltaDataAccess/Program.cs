using System;
using System.Data;
using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;
namespace BaltaDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=Linkstart@11;TrustServerCertificate=True";


            using (var connection = new SqlConnection(connectionString))
            {
                SelectIn(connection);
            }
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category] ORDER BY [Order]");
            foreach (var item in categories)
            {
                System.Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"INSERT INTO 
                [Category] 
            VALUES 
            (
                @Id,
                @Title, 
                @Url, 
                @Summary, 
                @Order,
                @Description, 
                @Featured
            )";

            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            System.Console.WriteLine($"{rows} linhas inseridas");

        }

        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title]=@title WHERE [Id]=@id";
            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid("25f0f1d6-221e-42c8-8c0c-d54d6026588f"),
                title = "XptoTeste"
            });

            System.Console.WriteLine($"{rows} registros atualizados");
        }

        static void DeleteCategory(SqlConnection connection)
        {
            var deleteQuery = "DELETE FROM [Category] WHERE [Id]=@id";

            var rows = connection.Execute(deleteQuery, new
            {
                id = new Guid("4d7ff38c-2cdc-438e-a860-0b8468836fc0")
            });
        }

        static void CreateManyCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "Categoria Nova";
            category2.Url = "categoria-nova";
            category2.Description = "Categoria Nova";
            category2.Order = 9;
            category2.Summary = "Categoria";
            category2.Featured = true;

            var insertSql = @"INSERT INTO 
                [Category] 
            VALUES 
            (
                @Id,
                @Title, 
                @Url, 
                @Summary, 
                @Order,
                @Description, 
                @Featured
            )";

            var rows = connection.Execute(insertSql, new[]{
            new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            },
            new
            {
                category2.Id,
                category2.Title,
                category2.Url,
                category2.Summary,
                category2.Order,
                category2.Description,
                category2.Featured
            }
            });

            System.Console.WriteLine($"{rows} linhas inseridas");

        }

        static void ExecuteProcedure(SqlConnection connection)
        {
            var procedure = "[spDeleteStudent]";
            var pars = new { StudentId = "b6c05b5a-5c5f-401e-b558-e32abedf9519" };
            var affectedRows = connection.Execute(procedure, pars, commandType: CommandType.StoredProcedure);
            System.Console.WriteLine(affectedRows);
        }

        static void ExecuteReadProcedure(SqlConnection connection)
        {
            var procedure = "[spGetCoursesByCategory]";
            var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
            var courses = connection.Query(
                procedure,
                pars,
                commandType: CommandType.StoredProcedure
            );

            foreach (var item in courses)
            {
                System.Console.WriteLine(item.Id);
            }
        }

        static void ExecuteScalar(SqlConnection connection)
        {
            var category = new Category();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"INSERT INTO 
                [Category] 
            OUTPUT inserted.[Id]
            VALUES 
            (
                NEWID(),
                @Title, 
                @Url, 
                @Summary, 
                @Order,
                @Description, 
                @Featured
            )";

            var id = connection.ExecuteScalar<Guid>(insertSql, new
            {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            System.Console.WriteLine($"A categoria inserida foi: {id}");
        }

        static void ReadView(SqlConnection connection)
        {
            var sql = "SELECT * FROM [vwCourses]";
            var courses = connection.Query(sql);
            foreach (var item in courses)
            {
                System.Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void OneToOne(SqlConnection connection)
        {
            var sql = @"
            SELECT 
                * 
            FROM 
                [CareerItem] 
            INNER JOIN 
                [Course] ON [CareerItem].[CourseId] = [Course].[Id]";

            var items = connection.Query<CareerItem, Course, CareerItem>(sql, (careerItem, course) =>
            {
                careerItem.Course = course;
                return careerItem;
            }, splitOn: "Id");

            foreach (var item in items)
            {
                System.Console.WriteLine($"{item.Title} - Curso: {item.Course.Title}");
            }
        }

        static void OneToMany(SqlConnection connection)
        {
            var sql = @"
            SELECT 
                [Career].[Id],
                [Career].[Title],
                [CareerItem].[CareerId],
                [CareerItem].[Title]
            FROM 
                [Career] 
            INNER JOIN 
                [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
            ORDER BY
                [Career].[Title]";
            var careers = new List<Career>();
            var items = connection.Query<Career, CareerItem, Career>(sql, (career, careerItem) =>
            {
                var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                if (car == null)
                {
                    car = career;
                    car.Items.Add(careerItem);
                    careers.Add(car);
                }
                else
                {
                    car.Items.Add(careerItem);
                }
                return career;
            }, splitOn: "CareerId");

            foreach (var career in careers)
            {
                System.Console.WriteLine(career.Title);
                foreach (var item in career.Items)
                {
                    System.Console.WriteLine($" - {item.Title}");
                }
            }
        }

        static void QueryMutiple(SqlConnection connection)
        {
            var query = "SELECT * FROM [Category]; SELECT * FROM [Course]";

            using (var multi = connection.QueryMultiple(query))
            {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();

                foreach (var item in categories)
                {
                    System.Console.WriteLine(item.Title);
                }

                foreach (var item in courses)
                {
                    System.Console.WriteLine(item.Title);
                }
            }
        }

        static void SelectIn(SqlConnection connection)
        {
            var sql = "SELECT * FROM [Career] WHERE [Id] IN (@Id1, @Id2)";
            var pars = new
            {
                Id1 = "01ae8a85-b4e8-4194-a0f1-1c6190af54cb",
                Id2 = "e6730d1c-6870-4df3-ae68-438624e04c72"
            };
            var careers = connection.Query<Career>(sql, pars);

            foreach (var item in careers)
            {
                System.Console.WriteLine(item.Title);
            }
        }

        static void Like(SqlConnection connection)
        {
            var sql = "SELECT * FROM [Course] WHERE [Title] LIKE @exp";
            var pars = new
            {
                Id1 = "01ae8a85-b4e8-4194-a0f1-1c6190af54cb",
                Id2 = "e6730d1c-6870-4df3-ae68-438624e04c72"
            };
            var careers = connection.Query<Course>(sql, pars);

            foreach (var item in careers)
            {
                System.Console.WriteLine(item.Title);
            }
        }
    }
}
// var connection = new SqlConnection();
// connection.Open();

// connection.Close();
// connection.Dispose();

//  System.Console.WriteLine("Conectado");
//                 connection.Open();
//                 using (var command = new SqlCommand())
//                 {
//                     command.Connection = connection;
//                     command.CommandType = System.Data.CommandType.Text;
//                     command.CommandText = "SELECT [Id], [Title] FROM [Category]";

//                     var reader = command.ExecuteReader();
//                     while (reader.Read())
//                     {
//                         Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
//                     }
//                 }