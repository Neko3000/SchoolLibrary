using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolLibrary.Models
{
    public class SchoolLibraryContextInitializer:System.Data.Entity.DropCreateDatabaseAlways<SchoolLibraryContext>
    {
        protected override void Seed(SchoolLibraryContext context)
        {
            context.Categories.Add(new Category { Name = "杂志" });
            context.Books.Add(new Book
            {            
                    Title = "测试用书籍",
                    Author = "God",
                    PublishTime = DateTime.Now,
                    Category = new Category { Name = "价值" },
                    CurrentCount = 1
                
            });
            var books = new List<Book>
            {
                new Book
                {
                    Title = "文艺青年的自我修养",
                    Author = "寂寞一夜",
                    PublishTime = DateTime.Now,
                    Category = new Category { Name = "幻想小说" },
                    CurrentCount = 1
                },
                new Book
                {
                    Title = "贡丸的烹煮方式",
                    Author = "我吃叉烧樱桃肉",
                    PublishTime = DateTime.Now,
                    Category = new Category { Name = "教育学" },
                    CurrentCount = 2
                },
                new Book
                {
                    Title = "外科恶魔的成名史",
                    Author = "蘑菇不吃肉",
                    PublishTime = DateTime.Now,
                    Category = new Category { Name = "历史读物" },
                    CurrentCount = 2
                },
                new Book
                {
                    Title = "我和我的旅行",
                    Author = "萨萨卡",
                    PublishTime = DateTime.Now,
                    Category = new Category { Name = "玄幻小说" },
                    CurrentCount = 2
                },
                new Book
                {
                    Title = "怎样思考",
                    Author = "Nidhogg",
                    PublishTime = DateTime.Now,
                    Category = new Category { Name = "科普读物" },
                    CurrentCount = 2
                }
            };
            books.ForEach(a => context.Books.Add(a));

            var popularBooks = new List<PopularBook>
            {
                new PopularBook
                {
                    BookId=books.Single(s=>s.Title=="文艺青年的自我修养"),
                    RecordedTime=DateTime.Now
                },
                new PopularBook
                {
                    BookId=books.Single(s=>s.Title=="外科恶魔的成名史"),
                    RecordedTime=DateTime.Now
                }
            };
            popularBooks.ForEach(a => context.PopularBooks.Add(a));

            base.Seed(context);
        }
    }
}