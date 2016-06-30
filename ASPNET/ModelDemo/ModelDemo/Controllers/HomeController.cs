using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ModelDemo.Models.Context;

namespace ModelDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Заполнение БД демо-данными если они отсутствуют
            using (var context = new StoreContext())
            {
                if (!context.Products.Any() && !context.Categories.Any())
                {
                    InsertData();
                }
            }

            return View();
        }

        public ActionResult Products()
        {
            List<Category> categories;

            using (var context = new StoreContext())
            {
                //метод  Include() используется для принудительного внедрение Lazy связей
                categories = context.Categories.Include(x => x.Products).ToList();
            }

            return View(categories);
        }

        public ActionResult Order(Guid id)
        {
            var order = new Order
            {
                ProductId = id,
                Date = DateTime.Now,
                Id = Guid.NewGuid(),
                IsProcessing = false,
                Owner = "Тестовый Пользователь",
                Status = "Ожидается подтверждение"
            };

            using (var context = new StoreContext())
            {
                context.Orders.Add(order);

                context.SaveChanges();
            }

            return RedirectToAction("Orders");
        }

        public ActionResult Process(Guid id)
        {
            using (var context = new StoreContext())
            {
                var order = context.Orders.FirstOrDefault(x => x.Id == id);

                if (order != null)
                {
                    order.IsProcessing = true;
                    order.Status = "Заказ Обработан!";
                }

                context.SaveChanges();
            }

            return RedirectToAction("Orders");
        }

        public ActionResult Delete(Guid id)
        {
            using (var context = new StoreContext())
            {
                var order = context.Orders.FirstOrDefault(x => x.Id == id);

                if (order != null)
                {
                    context.Orders.Remove(order);
                }

                context.SaveChanges();
            }

            return RedirectToAction("Orders");
        }

        public ActionResult Orders()
        {
            List<Order> orders;

            using (var context = new StoreContext())
            {
                orders = context.Orders.Include(x => x.Product).ToList();
            }

            return View(orders);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Our contact page.";

            return View();
        }




        //метод для заполнения демo данными
        private void InsertData()
        {
            using (var context = new StoreContext())
            {

                context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid(),
                    Title = "Спальня",
                    Products = new List<Product>()
                    {
                        new Product
                        {
                            Id = Guid.NewGuid(),
                            Title = "ТВ",
                            Description = "ТВ для спальни",
                            IsAvalialbe = true,
                            Price = 23.1
                        },
                        new Product
                        {
                            Id = Guid.NewGuid(),
                            Title = "Кровать",
                            Description = "Мягкая и удобная кровать для любой спальни",
                            IsAvalialbe = true,
                            Price = 232.5
                        },
                        new Product
                        {
                            Id = Guid.NewGuid(),
                            Title = "Ковер",
                            Description = "Обычный ковер 200х200",
                            IsAvalialbe = true,
                            Price = 10
                        }
                    }
                });

                context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid(),
                    Title = "Кухня",
                    Products = new List<Product>()
                    {
                        new Product
                        {
                            Id = Guid.NewGuid(),
                            Title = "ТВ",
                            Description = "Телевизор для кухни",
                            IsAvalialbe = true,
                            Price = 13.1
                        },
                        new Product
                        {
                            Id = Guid.NewGuid(),
                            Title = "Стул",
                            Description = "Стул деревянный белый",
                            IsAvalialbe = true,
                            Price = 232.5
                        },
                        new Product
                        {
                            Id = Guid.NewGuid(),
                            Title = "Стол",
                            Description = "Стол небольшой 100х100",
                            IsAvalialbe = true,
                            Price = 10
                        },
                        new Product
                        {
                            Id = Guid.NewGuid(),
                            Title = "Семейный стол",
                            Description = "Стол большой 200х150",
                            IsAvalialbe = true,
                            Price = 15
                        }
                    }
                });

                context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid(),
                    Title = "Прихожая",
                    Products = new List<Product>()
                    {
                        new Product
                        {
                            Id = Guid.NewGuid(),
                            Title = "Ковер",
                            Description = "Небольшой ковер для прихожей",
                            IsAvalialbe = true,
                            Price = 5.9
                        },
                        new Product
                        {
                            Id = Guid.NewGuid(),
                            Title = "Вешалка",
                            Description = "Вешалка деревянная белая",
                            IsAvalialbe = true,
                            Price = 22.5
                        }
                    }
                });

                context.SaveChanges();
            }
        }
    }
}