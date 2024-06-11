using Rotalarim.Entity;
using Microsoft.EntityFrameworkCore;

namespace Rotalarim.Data.Concrete.EfCore{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app){
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<RotalarimContext>();

                if (context != null)
                {
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate();
                    }
                    if (!context.Tags.Any())
                    {
                        context.Tags.AddRange(
                            new Tag { Text = "deniz" ,Url="deniz" ,Color = TagColors.primary},
                            new Tag { Text = "şehir" , Url="gece" ,Color = TagColors.warning},
                            new Tag { Text = "gece" ,Url="gece" ,Color = TagColors.success},
                            new Tag { Text = "manzara" , Url="manzara" ,Color = TagColors.danger},
                            new Tag { Text = "seyahat" ,Url="seyahat" ,Color = TagColors.info}
                        );
                        context.SaveChanges();
                    }

                    if (!context.Users.Any())
                    {
                        context.Users.AddRange(
                            new User { UserName = "doanneslihan" ,Image="p1.jpg"},
                            new User { UserName = "aysesanemagca" ,Image="p2.jpg"}
                        );
                        context.SaveChanges();
                    }
                    if (!context.Posts.Any())
                    {
                        context.Posts.AddRange(
                            new Post {
                                Title = "Bursa",
                                Content = "Bursa gezilecek yerler",
                                Url = "bursa",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-10),
                                Tags = context.Tags.Take(3).ToList(),
                                Image="1.jpg",
                                UserId = 1,
                                Comments = new List<Comment>{ 
                                    new Comment {Text = "Çok güzel bir yer", PublishedOn = new DateTime() ,UserId =1},
                                    new Comment {Text = "Harika manzara", PublishedOn = new DateTime() ,UserId =2}
                                    
                                }
                            },
                            new Post {
                                Title = "Kocaeli",
                                Content = "Kocaeli gezilecek yerler",
                                Url = "kocaeli",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-20),
                                Tags = context.Tags.Take(2).ToList(),
                                Image="2.jpg",
                                UserId = 1
                            },
                            new Post {
                                Title = "Karadeniz",
                                Content = "Karadeniz gezilecek yerler",
                                Url = "karadeniz",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-5),
                                Tags = context.Tags.Take(4).ToList(),
                                Image="3.jpg",
                                UserId = 2,
                                Comments = new List<Comment>{ 
                                    new Comment {Text = "Bu neee mükemmell", PublishedOn = new DateTime() ,UserId =1}
                                }
                            },
                            new Post {
                                Title = "Hatay",
                                Content = "Hatay gezilecek yerler",
                                Url = "hatay",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-30),
                                Tags = context.Tags.Take(4).ToList(),
                                Image="3.jpg",
                                UserId = 2
                            },
                            new Post {
                                Title = "Malatya",
                                Content = "Malatya gezilecek yerler",
                                Url = "malatya",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-40),
                                Tags = context.Tags.Take(4).ToList(),
                                Image="3.jpg",
                                UserId = 2
                            },
                            new Post {
                                Title = "Konya",
                                Content = "Konya gezilecek yerler",
                                Url = "konya",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-50),
                                Tags = context.Tags.Take(4).ToList(),
                                Image="3.jpg",
                                UserId = 2
                            }
                        );
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
