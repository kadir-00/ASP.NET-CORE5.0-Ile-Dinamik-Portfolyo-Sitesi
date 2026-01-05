using EntityLayer.Concrete;
using System.Linq;
using System.Collections.Generic;

namespace DataAccessLayer.Concrete
{
    public static class ContextSeeder
    {
        public static void Seed(Context context)
        {
            // Clear existing data to fix incorrect paths
            if (context.Features.Any()) { context.Features.RemoveRange(context.Features); }
            if (context.Abouts.Any()) { context.Abouts.RemoveRange(context.Abouts); }
            if (context.Services.Any()) { context.Services.RemoveRange(context.Services); }
            if (context.Skills.Any()) { context.Skills.RemoveRange(context.Skills); }
            if (context.Portfolios.Any()) { context.Portfolios.RemoveRange(context.Portfolios); }
            if (context.Experionces.Any()) { context.Experionces.RemoveRange(context.Experionces); }
            if (context.Testimonials.Any()) { context.Testimonials.RemoveRange(context.Testimonials); }
            if (context.SocialMedias.Any()) { context.SocialMedias.RemoveRange(context.SocialMedias); }
            if (context.Annoncouments.Any()) { context.Annoncouments.RemoveRange(context.Annoncouments); }
            if (context.ToDoListS.Any()) { context.ToDoListS.RemoveRange(context.ToDoListS); }

            context.SaveChanges();

            // Re-seed with correct paths
            context.Features.Add(new Feature
            {
                Header = "Merhaba, Ben",
                Name = "Kadir",
                Title = "Full Stack .NET Developer"
            });

            context.Abouts.Add(new About
            {
                Title = "Hakkımda",
                Description = "Ben, modern web teknolojileri konusunda tutkulu bir yazılım geliştiricisiyim. ASP.NET Core, C# ve Entity Framework üzerinde uzmanlaşmış durumdayım. Karmaşık problemleri çözmeyi ve kullanıcı dostu arayüzler tasarlamayı seviyorum.",
                Age = "25",
                Mail = "kadir@example.com",
                Phone = "+90 555 123 45 67",
                Address = "İstanbul, Türkiye",
                ImageUrl = "/Template/images/avatar.jpg"
            });

            context.Services.AddRange(
                new Service { Title = "Web Tasarım", ImageUrl = "/Template/images/services/web-design.svg" },
                new Service { Title = "UI/UX Tasarım", ImageUrl = "/Template/images/services/ui-ux.svg" },
                new Service { Title = "Mobil Uygulama", ImageUrl = "/Template/images/services/app-development.svg" },
                new Service { Title = "Full Stack Geliştirme", ImageUrl = "/Template/images/services/full-stack.svg" }
            );

            context.Skills.AddRange(
                new Skill { Title = "C#", Value = "90" },
                new Skill { Title = "ASP.NET Core", Value = "85" },
                new Skill { Title = "SQL Server", Value = "80" },
                new Skill { Title = "HTML/CSS", Value = "75" },
                new Skill { Title = "JavaScript", Value = "70" },
                new Skill { Title = "Entity Framework", Value = "85" }
            );

            context.Portfolios.AddRange(
                new Portfolio { Name = "E-Ticaret Sitesi", Platform = "Web", Price = "15000", Status = true, ImageUrl = "/Template/images/portfolio/1.jpg", ImageUrl2 = "/Template/images/portfolio/1.jpg", ProjectUrl = "#", Value = 100 },
                new Portfolio { Name = "Kurumsal Firma Sitesi", Platform = "Web", Price = "8000", Status = true, ImageUrl = "/Template/images/portfolio/2.jpg", ImageUrl2 = "/Template/images/portfolio/2.jpg", ProjectUrl = "#", Value = 95 },
                new Portfolio { Name = "Kişisel Blog", Platform = "Web", Price = "5000", Status = true, ImageUrl = "/Template/images/portfolio/3.jpg", ImageUrl2 = "/Template/images/portfolio/3.jpg", ProjectUrl = "#", Value = 90 },
                new Portfolio { Name = "CRM Paneli", Platform = "Web", Price = "20000", Status = true, ImageUrl = "/Template/images/portfolio/4.jpg", ImageUrl2 = "/Template/images/portfolio/4.jpg", ProjectUrl = "#", Value = 85 },
                new Portfolio { Name = "Mobil Etkinlik Uygulaması", Platform = "Mobil", Price = "12000", Status = true, ImageUrl = "/Template/images/portfolio/5.jpg", ImageUrl2 = "/Template/images/portfolio/5.jpg", ProjectUrl = "#", Value = 80 },
                new Portfolio { Name = "Online Eğitim Platformu", Platform = "Web", Price = "25000", Status = true, ImageUrl = "/Template/images/portfolio/6.jpg", ImageUrl2 = "/Template/images/portfolio/6.jpg", ProjectUrl = "#", Value = 75 }
            );

            context.Experionces.AddRange(
                new Experience { Name = "Kıdemli Yazılım Geliştirici", Date = "2023-Günümüz", Description = "Büyük ölçekli web uygulamaları geliştirme ve ekip liderliği.", ImageUrl = "/Template/images/illustrations/creative-team.svg" },
                new Experience { Name = "Yazılım Geliştirici", Date = "2021-2023", Description = ".NET Core ile backend geliştirme ve API entegrasyonları.", ImageUrl = "/Template/images/illustrations/development.svg" },
                new Experience { Name = "Junior Geliştirici", Date = "2020-2021", Description = "Yazılım geliştirme süreçlerine giriş ve temel kodlama pratikleri.", ImageUrl = "/Template/images/illustrations/website-app.svg" }
            );

            context.Testimonials.AddRange(
                new Testimonial { ClientName = "Ahmet Yılmaz", Company = "Tech A.Ş.", Title = "CEO", Description = "Kadir ile çalışmak harikaydı, projemizi zamanında ve mükemmel kalitede teslim etti.", ImageUrl = "/Template/images/testimonials/client1.jpg" },
                new Testimonial { ClientName = "Ayşe Demir", Company = "Creative Design", Title = "Tasarım Müdürü", Description = "Teknik bilgisi ve iletişim becerileri çok yüksek. Kesinlikle tavsiye ederim.", ImageUrl = "/Template/images/testimonials/client2.jpg" },
                new Testimonial { ClientName = "Mehmet Kaya", Company = "Data Systems", Title = "CTO", Description = "Zorlu projelerin altından başarıyla kalkabiliyor.", ImageUrl = "/Template/images/testimonials/client3.jpg" },
                new Testimonial { ClientName = "Zeynep Çelik", Company = "Mobile First", Title = "Ürün Yöneticisi", Description = "Mobil uygulamamızın backend tarafını harika bir şekilde kurguladı.", ImageUrl = "/Template/images/testimonials/client4.jpg" }
            );

            context.SocialMedias.AddRange(
                new SocialMedia { Name = "GitHub", Url = "https://github.com/", Icon = "fab fa-github", Status = true },
                new SocialMedia { Name = "LinkedIn", Url = "https://linkedin.com/", Icon = "fab fa-linkedin", Status = true },
                new SocialMedia { Name = "Twitter", Url = "https://twitter.com/", Icon = "fab fa-twitter", Status = true },
                new SocialMedia { Name = "Instagram", Url = "https://instagram.com/", Icon = "fab fa-instagram", Status = true }
            );

            context.Annoncouments.AddRange(
               new Annoncoument { Title = "Site Yayında!", Content = "Yeni portfolyo sitemiz yayına girdi. Artık projelerimi buradan takip edebilirsiniz.", Date = System.DateTime.Now, Status = "Aktif" },
               new Annoncoument { Title = "Bakım Çalışması", Content = "Bu haftasonu kısa süreli bir bakım çalışması yapılacaktır.", Date = System.DateTime.Now.AddDays(-5), Status = "Pasif" }
           );

            context.ToDoListS.AddRange(
               new ToDoList { Content = "Portfolyo sitesini tamamla", Status = true },
               new ToDoList { Content = "Blog modülünü ekle", Status = false },
               new ToDoList { Content = "SEO ayarlarını yap", Status = false }
           );

            context.SaveChanges();
        }
    }
}
