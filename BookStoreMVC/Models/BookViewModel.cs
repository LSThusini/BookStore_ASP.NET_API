using System.ComponentModel.DataAnnotations;

namespace BookStoreMVC.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The title field in mandatory")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
