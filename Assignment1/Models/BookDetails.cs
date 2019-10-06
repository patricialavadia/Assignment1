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
        [Required]
        [Column("book_title")]
        [StringLength(50)]
        public string BookTitle { get; set; }
        [Required]
        [Column("book_author")]
        [StringLength(50)]
        public string BookAuthor { get; set; }
        [Column("publish_date", TypeName = "date")]
        public DateTime PublishDate { get; set; }
        [Column("book_stocks")]
        public int BookStocks { get; set; }
    }
}
