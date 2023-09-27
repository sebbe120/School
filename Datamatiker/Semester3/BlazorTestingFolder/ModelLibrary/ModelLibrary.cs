using System.ComponentModel.DataAnnotations;

namespace ModelLibrary
{
    public class RentalPost
    {
        [Required]
        [StringLength(10, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = "Title";
        [Required]
        [StringLength(100, ErrorMessage = "Description is too long.")]
        public string Description { get; set; } = "Description";
        public RentalItem RentalItem { get; set; }
        [Required]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "Field Cannot be Blank Or Whitespace")]
        public string Category { get; set; }
        [Required]
        public DateTime AvailableDateFrom { get; set; } = DateTime.Now.Date;
        [Required]
        public DateTime AvailableDateTo { get; set; } = DateTime.Now.Date.AddDays(1);
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        public int Price { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        public int Deposit { get; set; }
        public byte[] Picture { get; set; }
        public DateTime PostedDate { get; private set; } = DateTime.Now.Date;

        public override string ToString()
        {
            return $"{Title}, {Price}DKK, {Description}, Available From {AvailableDateFrom:dd/MM/yyyy}, Available To {AvailableDateTo:dd/MM/yyyy}, PostDate {PostedDate:dd/MM/yyyy}, HasPicture={Picture != null}";
        }
    }

    public class RentalItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Condition { get; set; }
    }
    /* RentalPost properties for database
     * •	Title
     * •	Category
     * •	Price
     * •	Deposit
     * •	Description
     * •	Date From
     * •	Date To
     * •	Posted Date
     */
}