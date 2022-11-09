using KeyboArt.Data.Static;
using KeyboArt.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyboArt.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Products
                if (!context.Products.Any())
                {

                    context.Products.AddRange(new List<Product>()
                    {
                        //Keyboards
                        new Product()
                        {
                            Name = "TOFU 60",
                            Description = "Opis klawiatury zawierający ponad 20 znaków",
                            Price = 899.00,
                            Quantity = 1,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/ecd777f34ee924e2ddd99ca1603c73fb_315be477-a1b1-4e51-a00f-d26fe29ddcc4_360x.jpg?v=1652253343",
                            CategoryId = 1
                        },
                         new Product()
                        {
                            Name = "KBD75 V3.1",
                            Description = "Opis klawiatury zawierający ponad 20 znaków",
                            Price = 1199.00,
                            Quantity = 1,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/6_b0d05bc7-7762-4391-b403-eb679f63362a_360x.jpg?v=1651044067",
                            CategoryId = 1
                        },
                          new Product()
                        {
                            Name = "BLADE 60",
                            Description = "Opis klawiatury zawierający ponad 20 znaków",
                            Price = 999.00,
                            Quantity = 1,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/2_4d232484-1a37-43de-9a1d-70ed1efdf755_360x.jpg?v=1646899482",
                            CategoryId = 1
                        },
                          
                          //Switches
                          new Product()
                        {
                            Name = "TECSEE SAPPHIRE",
                            Description = "Opis przełącznika zawierający ponad 20 znaków",
                            Price = 25.00,
                            Quantity = 10,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/lQDPDhtkWnJSKQzNB9DNB9CwF_8HSOfYXSQCdReQdkAGAA_2000_2000_360x.jpg?v=1651648901",
                            CategoryId = 2
                        },
                          new Product()
                        {
                            Name = "GATERON BOX CJ",
                            Description = "Opis przełącznika zawierający ponad 20 znaków",
                            Price = 95.00,
                            Quantity = 10,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/lQDPDhsshBty7FnNB9DNB9CwUZy7fcR_-MECGZu3PICaAA_2000_2000_360x.jpg?v=1645509654",
                            CategoryId = 2
                        },
                          new Product()
                        {
                            Name = "KAILH BOX JADE",
                            Description = "Opis przełącznika zawierający ponad 20 znaków",
                            Price = 30.00,
                            Quantity = 10,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/3_74665e23-f096-4a67-aadd-6a19e7d4e323_360x.jpg?v=1644994865",
                            CategoryId = 2
                        },

                          //Cases
                          new Product()
                        {
                            Name = "BLADE 65 ALUMINIUM",
                            Description = "Opis obudowy zawierający ponad 20 znaków",
                            Price = 999.00,
                            Quantity = 1,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/21_e2f09a02-3bb3-4301-8ee5-cd0e41db053e_360x.jpg?v=1651998576",
                            CategoryId = 3
                        },
                          new Product()
                        {
                            Name = "TOFU 65 WOODEN",
                            Description = "Opis obudowy zawierający ponad 20 znaków",
                            Price = 150.00,
                            Quantity = 1,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/60_2_61a8c1a4-fbc4-4e77-89c7-9788452b8947_360x.jpg?v=1631280489",
                            CategoryId = 3
                        },
                          new Product()
                        {
                            Name = "D84 ACRYLIC",
                            Description = "Opis obudowy zawierający ponad 20 znaków",
                            Price = 899.00,
                            Quantity = 1,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/2df20f51221b6b4e8bc127c84fffb270_30e8a798-3c41-479a-a611-df7078a8f6e9_360x.jpg?v=1637809206",
                            CategoryId = 3
                        },
                          //Keycaps
                          new Product()
                        {
                            Name = "DSA CHALK DYE-SUB",
                            Description = "Opis nasadek zawierający ponad 20 znaków",
                            Price = 299.00,
                            Quantity = 151,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/1_ccd317d5-3697-4c21-a639-44b5869b2c3a_360x.jpg?v=1623386201",
                            CategoryId = 4
                        },
                          new Product()
                        {
                            Name = "ENJOYPBT GREEN&WHITE",
                            Description = "Opis nasadek zawierający ponad 20 znaków",
                            Price = 180.00,
                            Quantity = 100,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/DP0315_360x.jpg?v=1650242560",
                            CategoryId = 4
                        },
                          new Product()
                        {
                            Name = "MAXKEY SA SET",
                            Description = "Opis nasadek zawierający ponad 20 znaków",
                            Price = 50.00,
                            Quantity = 100,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/DP0231_360x.jpg?v=1653292874",
                            CategoryId = 4
                        },

                          //PCB plates
                          new Product()
                        {
                            Name = "DZ60 SOLDERABLE",
                            Description = "Opis płyty PCB zawierający ponad 20 znaków",
                            Price = 150.00,
                            Quantity = 1,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/9_dc30a2d3-0781-4184-b998-6e5750ae0e71_360x.jpg?v=1645423765",
                            CategoryId = 5
                        },
                          new Product()
                        {
                            Name = "DZ60RGB-ANSI HOT SWAP",
                            Description = "Opis płyty PCB zawierający ponad 20 znaków",
                            Price = 250.00,
                            Quantity = 1,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/DZ60RGBANSI-2000_360x.jpg?v=1627521245",
                            CategoryId = 5
                        },
                          new Product()
                        {
                            Name = "KBD75 REV 2.0 SOLDERABLE",
                            Description = "Opis płyty PCB zawierający ponad 20 znaków",
                            Price = 200.00,
                            Quantity = 1,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/1_e08f5fc7-4eea-434b-b80f-465de7d50034_360x.jpg?v=1622443286",
                            CategoryId = 5
                        },
                          
                          //Accesories
                          new Product()
                        {
                            Name = "KBDFANS KABEL USB-C",
                            Description = "Opis akcesorium zawierający ponad 20 znaków",
                            Price = 220.00,
                            Quantity = 1,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/1_9879d153-3e3c-451b-896f-5f9a4ce39be8_360x.jpg?v=1652172186",
                            CategoryId = 6
                        },
                          new Product()
                        {
                            Name = "KBDFANS PODKŁADKA TETRIS",
                            Description = "Opis akcesorium zawierający ponad 20 znaków",
                            Price = 220.00,
                            Quantity = 1,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/1_9e17b32d-29b1-4746-87db-df9a7a1bc3a3_360x.jpg?v=1651562594",
                            CategoryId = 6
                        },
                          new Product()
                        {
                            Name = "KBDFANS STABILIZATORY",
                            Description = "Opis akcesorium zawierający ponad 20 znaków",
                            Price = 110.00,
                            Quantity = 1,
                            ImageURL = "https://cdn.shopify.com/s/files/1/1473/3902/products/1_c60beb13-717e-4ac2-9bb8-df23aa058c49_360x.jpg?v=1605143434",
                            CategoryId = 6
                        },

                    });
                }
                //Categories
                if (!context.Categories.Any())
                {

                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            CategoryName = "Klawiatury",
                        },
                        new Category()
                        {
                            CategoryName = "Przełączniki"
                        },
                        new Category()
                        {
                            CategoryName = "Obudowy"
                        },
                        new Category()
                        {
                            CategoryName = "Nasadki"
                        },
                        new Category()
                        {
                            CategoryName = "Płyty PCB"
                        },
                        new Category()
                        {
                            CategoryName = "Akcesoria"
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@keyboart.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@keyboart.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "User",
                        UserName = "user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "User@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
