﻿using ISDomain.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISRepository
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookInOrder> BooksInOrder { get; set; }
        public virtual DbSet<BookInShoppingCart> BooksInShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<BookInShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<BookInShoppingCart>()
                .HasOne(z => z.Books)
                .WithMany(z => z.BooksInShoppingCart)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<BookInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.BooksInShoppingCart)
                .HasForeignKey(z => z.BookId);

            builder.Entity<BookInOrder>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<BookInOrder>()
                .HasOne(z => z.Books)
                .WithMany(z => z.BooksInOrder)
                .HasForeignKey(z => z.OrderId);

            builder.Entity<BookInOrder>()
                .HasOne(z => z.Books)
                .WithMany(z => z.BooksInOrder)
                .HasForeignKey(z => z.BookId);

            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .HasOne(z => z.User)
                .WithOne(z => z.ShoppingCart)
                .HasForeignKey<ShoppingCart>(z => z.UserId);

            builder.Entity<Order>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
