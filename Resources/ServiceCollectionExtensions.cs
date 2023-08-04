using System;
using System.Collections.Generic;
using CartService.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CartService.Resources
{
    internal static class ServiceCollectionExtensions
    {
        public static IHost CreateDbIfNotExists(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApiContext>();

                    context.Carts.AddRange(new Cart()
                    {
                        Id = new Guid("23ad0181-9182-4dd7-9223-817baafb7e83"),
                        UserId = new Guid("59da66e2-d894-411e-9eaa-a020a3c1ac0a"),

                        Items = new List<CartItem>
                        {
                            new CartItem
                            {
                                CartId = new Guid("23ad0181-9182-4dd7-9223-817baafb7e83"),
                                ProductId = new Guid("c0bcc4ea-7c30-451a-83a5-a9b9182ea43b"),
                                Quantity = 1,
                                Price = 2000,
                                TotalAmount = 2000
                            },
                            new CartItem
                            {
                                CartId = new Guid("23ad0181-9182-4dd7-9223-817baafb7e83"),
                                ProductId = new Guid("648ca0fc-005c-449d-96e8-b112ad100e61"),
                                Quantity = 2,
                                Price = 3000,
                                TotalAmount = 6000
                            },
                            new CartItem
                            {
                                CartId = new Guid("23ad0181-9182-4dd7-9223-817baafb7e83"),
                                ProductId = new Guid("502d83fe-7d19-4e77-a54f-bf14230d8ea4"),
                                Quantity = 1,
                                Price = 4000,
                                TotalAmount = 4000
                            }
                        }
                    },

                    new Cart()
                    {
                        Id = new Guid("032f9c4c-bda9-4dde-a5b2-20c001bdd303"),
                        UserId = new Guid("b8a4b99b-8c91-4782-b06a-35fc2c8cf74d"),
                        Items = new List<CartItem>()
                        {
                            new CartItem
                            {
                                CartId = new Guid("032f9c4c-bda9-4dde-a5b2-20c001bdd303"),
                                ProductId = new Guid("08cd0565-32c1-4574-b257-2548fdeb4751"),
                                Quantity = 1,
                                Price = 2000,
                                TotalAmount = 2000
                            },
                            new CartItem
                            {
                                CartId = new Guid("032f9c4c-bda9-4dde-a5b2-20c001bdd303"),
                                ProductId = new Guid("175f78ba-0d00-4570-a3ed-5095e4813a7c"),
                                Quantity = 1,
                                Price = 2000,
                                TotalAmount = 2000
                            }
                        }
                    });

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
                return host;
            }
        }
    }
}