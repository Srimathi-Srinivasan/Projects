using System;
using System.Collections.Generic;
using ProductAPI.Models;

namespace ProductAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CartDetails = new HashSet<CartDetail>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public long? MobileNumber { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}


//public static class ProductEndpoints
//{
//	public static void MapProductEndpoints (this IEndpointRouteBuilder routes)
//    {
//        routes.MapGet("/api/Product", async (SmartElectronicsContext db) =>
//        {
//            return await db.Products.ToListAsync();
//        })
//        .WithName("GetAllProducts");

//        routes.MapGet("/api/Product/{id}", async (int ProdId, SmartElectronicsContext db) =>
//        {
//            return await db.Products.FindAsync(ProdId)
//                is Product model
//                    ? Results.Ok(model)
//                    : Results.NotFound();
//        })
//        .WithName("GetProductById");

//        routes.MapPut("/api/Product/{id}", async (int ProdId, Product product, SmartElectronicsContext db) =>
//        {
//            var foundModel = await db.Products.FindAsync(ProdId);

//            if (foundModel is null)
//            {
//                return Results.NotFound();
//            }
//            //update model properties here

//            await db.SaveChangesAsync();

//            return Results.NoContent();
//        })   
//        .WithName("UpdateProduct");

//        routes.MapPost("/api/Product/", async (Product product, SmartElectronicsContext db) =>
//        {
//            db.Products.Add(product);
//            await db.SaveChangesAsync();
//            return Results.Created($"/Products/{product.ProdId}", product);
//        })
//        .WithName("CreateProduct");


//        routes.MapDelete("/api/Product/{id}", async (int ProdId, SmartElectronicsContext db) =>
//        {
//            if (await db.Products.FindAsync(ProdId) is Product product)
//            {
//                db.Products.Remove(product);
//                await db.SaveChangesAsync();
//                return Results.Ok(product);
//            }

//            return Results.NotFound();
//        })
//        .WithName("DeleteProduct");
//    }
//}}
