using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    [Table("booksBorrowed")]
    public partial class BooksBorrowed
    {
        [Key]
        [Column("borrowed_id")]
        public int BorrowedId { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("member_id")]
        public int MemberId { get; set; }
        [Required]
        [Column("book_title")]
        [StringLength(50)]
        public string BookTitle { get; set; }
        [Required]
        [Column("member_fname")]
        [StringLength(50)]
        public string MemberFname { get; set; }
        [Required]
        [Column("member_lname")]
        [StringLength(50)]
        public string MemberLname { get; set; }
        [Column("date_borrowed", TypeName = "date")]
        public DateTime DateBorrowed { get; set; }
        [Column("return_date", TypeName = "date")]
        public DateTime ReturnDate { get; set; }
    }
}
