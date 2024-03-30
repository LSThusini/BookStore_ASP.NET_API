using System.ComponentModel.DataAnnotations;

namespace BookStore_API.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The title field in mandatory")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
