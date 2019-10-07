using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    [Table("book_details")]
    public partial class BookDetails
    {
        [Key]
        [Column("book_id")]
        public int BookId { get; set; }
        [Required (ErrorMessage= "Book Title is Required")]
        [Column("book_title")]
        [StringLength(50)]
        public string BookTitle { get; set; }
        [Required (ErrorMessage= "Book Author is Required ")]
        [Column("book_author")]
        [StringLength(50)]
        public string BookAuthor { get; set; }
        [Required(ErrorMessage = "Published Date is Required ")]
        [Column("publish_date", TypeName = "date")]
         [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        [Required(ErrorMessage = "Number of Stocks is Required ")]
        [Column("book_stocks")]
        public int BookStocks { get; set; }
    }
}
