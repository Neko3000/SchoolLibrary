namespace SchoolLibrary.Migrations.SchoolLibraryMigration
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SchoolLibrary.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolLibrary.Models.SchoolLibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\SchoolLibraryMigration";
        }

        protected override void Seed(SchoolLibrary.Models.SchoolLibraryContext context)
        {
            //context.Categories.Add(new Category { Name = "��־" });
            var books = new List<Book>
            {
                new Book
                {
                    Title = "�������鼮",
                    Author = "God",
                    PublishTime = DateTime.Now,
                    Category = new Category { Name = "��ֵ" },
                    CurrentCount = 1

                },
                new Book
                {
                    Title = "�����������������",
                    Author = "��įһҹ",
                    PublishTime = DateTime.Now,
                    Category = new Category { Name = "����С˵" },
                    CurrentCount = 1
                },
                new Book
                {
                    Title = "���������ʽ",
                    Author = "�ҳԲ���ӣ����",
                    PublishTime = DateTime.Now,
                    Category = new Category { Name = "����ѧ" },
                    CurrentCount = 2
                },
                new Book
                {
                    Title = "��ƶ�ħ�ĳ���ʷ",
                    Author = "Ģ��������",
                    PublishTime = DateTime.Now,
                    Category = new Category { Name = "��ʷ����" },
                    CurrentCount = 2
                },
                new Book
                {
                    Title = "�Һ��ҵ�����",
                    Author = "������",
                    PublishTime = DateTime.Now,
                    Category = new Category { Name = "����С˵" },
                    CurrentCount = 2
                },
                new Book
                {
                    Title = "����˼��",
                    Author = "Nidhogg",
                    PublishTime = DateTime.Now,
                    Category = new Category { Name = "���ն���" },
                    CurrentCount = 2
                }
            };
            books.ForEach(singleBook => context.Books.AddOrUpdate(
                i=>i.Title,
                singleBook));
            context.SaveChanges();

            //var popularBooks = new List<PopularBook>
            //{
            //    new PopularBook
            //    {
            //        BookId=books.Single(s=>s.Title=="�����������������"),
            //        RecordedTime=DateTime.Now
            //    },
            //    new PopularBook
            //    {
            //        BookId=books.Single(s=>s.Title=="��ƶ�ħ�ĳ���ʷ"),
            //        RecordedTime=DateTime.Now
            //    }
            //};
            //popularBooks.ForEach(singlePopularBook => context.PopularBooks.AddOrUpdate(
            //    i=>i.BookId.Title,
            //singlePopularBook));

            //context.SaveChanges();
        }
    }
}
