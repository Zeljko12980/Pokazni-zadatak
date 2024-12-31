using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Pizza
    {
        [Key]
        public int Id{get;set;}
        public string Name{get;set;}
        public string Ingredients{get;set;}
        public decimal Price{get;set;}
        public string PhotoName{get;set;}
        public bool SoldOut{get;set;}


    }
}