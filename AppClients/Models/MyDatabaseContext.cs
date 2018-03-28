using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppClients.Models
{
    public class MyDatabaseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public MyDatabaseContext() : base("name=MyDbConnection")
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
    public class TaskDbInitializer : DropCreateDatabaseAlways<MyDatabaseContext>
    {
        protected override void Seed(MyDatabaseContext context)
        {
            Client s1 = new Client { Id = 1, FirstName = "Sergey", LastName = "Bondarenko", City = "Kharkov", Address = "street Akademika Pavlova", Phone1 = "0633509870", Phone2 = "0950056789", Phone3 = "" };
            Client s2 = new Client { Id = 2, FirstName = "Dmitrij", LastName = "Dmitriev", City = "Kiev", Address = "street Pobedi 183", Phone1 = "0954345678", Phone2 = "0967894567", Phone3 = "0505078990" };
            Client s3 = new Client { Id = 3, FirstName = "Andrey", LastName = "Kozlov", City = "Lugansk", Address = "street Pobedonosnaya", Phone1 = "0957078956", Phone2 = "0638884567", Phone3 = "0508099090" };
            Client s4 = new Client { Id = 4, FirstName = "Ivan", LastName = "Perhov", City = "Donetsk", Address = "street Pavlova 84/a", Phone1 = "0508980102", Phone2 = "0632223435", Phone3 = "0962345678" };
            Client s5 = new Client { Id = 5, FirstName = "Aleksandr", LastName = "Andreev", City = "Poltava", Address = "street Zarechnaya 3", Phone1 = "0958055523", Phone2 = "0965552311", Phone3 = "" };
            Client s6 = new Client { Id = 6, FirstName = "Vladimir", LastName = "Kravets", City = "Lugansk", Address = "street Olhovskaya 188", Phone1 = "0957876767", Phone2 = "0960099987", Phone3 = "06389009090" };
            Client s7 = new Client { Id = 7, FirstName = "Aleksandr", LastName = "Ovcharenko", City = "Kharkiv", Address = "street Vlasenko 50", Phone1 = "0960507070", Phone2 = "0734995656", Phone3 = "" };
            Client s8 = new Client { Id = 8, FirstName = "Sergey", LastName = "Petrov", City = "Kiev", Address = "street Klochkovskaya 5", Phone1 = "0959097676", Phone2 = "0634567887", Phone3 = "0967123421" };

            context.Clients.Add(s1);
            context.Clients.Add(s2);
            context.Clients.Add(s3);
            context.Clients.Add(s4);
            context.Clients.Add(s5);
            context.Clients.Add(s6);
            context.Clients.Add(s7);
            context.Clients.Add(s8);


            Task c1 = new Task
            {
                Id = 1,
                TaskName = "Seminar on marketing",
                Description = "Increase the effectiveness of marketing by developing and implementing a system for planning and implementing marketing activities.",
                StartTime = new DateTime(2018, 7, 20, 08, 30, 00),
                EndTime = new DateTime(2018, 7, 20, 10, 00, 00),
                Clients = new List<Client>() { s1, s2, s3, s4, s5, s6, s7, s8 }
            };
            Task c2 = new Task
            {
                Id = 2,
                TaskName = "Seminar on psychology",
                Description = "Psychological training is short-term training, which is conducted on a specific topic related to human psychology. Such training will increase your resistance to changes in life, help to develop skills of self-development.",
                StartTime = new DateTime(2018, 7, 20, 10, 30, 00),
                EndTime = new DateTime(2018, 7, 20, 12, 00, 00),
                Clients = new List<Client>() { s2, s3, s6, s7, s8, s4 }
            };
            Task c3 = new Task
            {
                Id = 3,
                TaskName = "Seminar on enterprise management",
                Description = "Until recently, it seemed that the growth of the market will always be. Now, during the economic downturn," +
                              "most companies strive to improve the efficiency of their business and set the main goal" +
                              "optimization of the management system.For most companies, the priority goal has changed" +
                              "development - instead of gaining market share, the goal of raising efficiency and effectiveness of doing business." +
                               "topic related to human psychology. Such training will increase your resistance to changes " +
                               "in life, help to develop skills of self-development.",
                StartTime = new DateTime(2018, 7, 20, 14, 30, 00),
                EndTime = new DateTime(2018, 7, 20, 15, 30, 00),
                Clients = new List<Client>() { s1, s3, s4, s7, s8, s4 }
            };

            context.Tasks.Add(c1);
            context.Tasks.Add(c2);
            context.Tasks.Add(c3);

            base.Seed(context);
        }
    }
}