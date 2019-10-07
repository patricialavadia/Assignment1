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
        [Required(ErrorMessage = "Book ID is Required")]
        [Column("book_id")]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Member ID is Required")]
        [Column("member_id")]
        public int MemberId { get; set; }
        [Required (ErrorMessage = "Book Title is Required")]
        [Column("book_title")]
        [StringLength(50)]
        public string BookTitle { get; set; }
        [Required (ErrorMessage = "First Name is Required")]
        [Column("member_fname")]
        [StringLength(50)]
        public string MemberFname { get; set; }
        [Required (ErrorMessage = "Last Name is Required")]
        [Column("member_lname")]
        [StringLength(50)]
        public string MemberLname { get; set; }
        [Required(ErrorMessage = "Date Borrowed is Required")]
        [Column("date_borrowed", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateBorrowed { get; set; }
        [Required(ErrorMessage = "Return Date is Required")]
        [Column("return_date", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
