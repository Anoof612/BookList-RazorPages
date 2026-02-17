using System.ComponentModel.DataAnnotations;

namespace Book_list.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string Author { get; set; } = string.Empty;

        public string ISBN { get; set; }

    }
}
