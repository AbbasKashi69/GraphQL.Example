چرا GraphQL؟
انعطاف پذیری: کلاینت ها میتوانند دقیقاً همان داده هایی که نیاز دارند را درخواست کنند.
کاهش Overhead: فقط دادههای مورد نیاز ارسال میشوند، نه بیشتر.
توسعه پذیری: اضافه کردن فیلدهای جدید به API بدون شکستن تغییرات قبلی.

پیادهسازی GraphQL در .NET
برای شروع، باید پکیجهای لازم را نصب کنید:



dotnet add package HotChocolate.AspNetCore

dotnet add package HotChocolate.Data



۱. تعریف Schema
در GraphQL، Schema قلب سیستم شماست. اینجا یک Schema ساده برای مدیریت فیلم ها تعریف میکنیم:



 public class Movie
 {
     public int Id { get; set; }
     public string Name { get; set; }
     public string Genre { get; set; }
     public TimeOnly Time { get; set; }
 }

public class MovieService
{
    public  List<Movie> GetMovies() =>
        Enumerable.Range(1, 25).Select(index => new Movie
        {
            Id = index,
            Genre = Genres[Random.Shared.Next(0, 6)],
            Name = "movie " + Random.Shared.Next(1, 100),
            Time = new TimeOnly(Random.Shared.Next(2), Random.Shared.Next(59), 0),
        }).ToList();

    private  string[] Genres => ["Action", "Comedy", "Drama", "Horror", "Romance", "Science Fiction", "Thriller"];

}



۲. پیکربندی GraphQL در Startup
در فایل Program.cs یا Startup.cs، GraphQL را پیکربندی کنید:



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddQueryType<Movie>();

var app = builder.Build();

app.MapGraphQL();

app.Run();



۳. اجرا و تست API
پروژه را اجرا کنید و به آدرس /graphql بروید. حالا میتوانید کوئری های GraphQL را اجرا کنید. مثلاً:

{
  movies {
    id
    name
    genre
  }
}



خروجی:

{
  "data": {
    "movies": [
      {
        "id": 1,
        "name": "movie 34",
        "genre": "Romance"
      },
      {
        "id": 2,
        "name": "movie 7",
        "genre": "Drama"
      },
      {
        "id": 3,
        "name": "movie 88",
        "genre": "Romance"
      },
        
    ]
  }
}



۴. اضافه کردن Mutation
برای تغییر داده ها، از Mutation استفاده میکنیم. مثلاً برای اضافه کردن فیلم:



public class MovieService
{
    public  List<Movie> GetMovies() =>
        Enumerable.Range(1, 25).Select(index => new Movie
        {
            Id = index,
            Genre = Genres[Random.Shared.Next(0, 6)],
            Name = "movie " + Random.Shared.Next(1, 100),
            Time = new TimeOnly(Random.Shared.Next(2), Random.Shared.Next(59), 0),
        }).ToList();

    private  string[] Genres => ["Action", "Comedy", "Drama", "Horror", "Romance", "Science Fiction", "Thriller"];

    public string AddMovie(string name, string genre)
    {
        return $"فیلم {name} با موفقیت ثبت شد.";
    }
}



و در پیکربندی:



builder.Services.AddGraphQLServer().AddQueryType<Movie>().AddMutationType<MovieService>();



حالا میتوانید Mutation زیر را اجرا کنید:



MovieService{
  addMovie(name: "test", genre: "horror")
  
}



۵. نکات حرفه ای
اعتبارسنجی: از ویژگیهای داخلی HotChocolate برای اعتبارسنجی داده ها استفاده کنید.
فیلترینگ و صفحه بندی: با استفاده از HotChocolate.Data، فیلترینگ و صفحه بندی را به راحتی پیاده سازی کنید.
افزودن Authorization: برای کنترل دسترسی به داده ها، از Policyهای ASP.NET Core استفاده کنید.



چرا GraphQL در .NET ?
سرعت بالا: HotChocolate یکی از سریعترین کتابخانه های GraphQL است.
یکپارچگی با .NET: بهراحتی با Entity Framework و سایر ابزارهای .NET ادغام میشود.
جامعه فعال: پشتیبانی قوی و مستندات جامع
