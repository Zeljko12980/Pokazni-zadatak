using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<CartItem> Cart { get; set; } // Ovo je sada kolekcija ugnežđenih objekata
        public decimal TotalPrice { get; set; }
    }

    [Owned] // Ovaj atribut govori EF Core-u da `CartItem` treba da bude ugnežđen
    public class CartItem
    {
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string PhotoName { get; set; }
        public decimal Price { get; set; }
        public bool SoldOut { get; set; }
    }
}
