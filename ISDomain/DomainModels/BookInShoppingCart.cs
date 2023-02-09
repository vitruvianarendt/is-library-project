﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ISDomain.DomainModels
{
    public class BookInShoppingCart : BaseEntity
    {
        public Guid BookId { get; set; }
        public Book Books { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }        
    }
}
