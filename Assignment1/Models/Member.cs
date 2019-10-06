using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    [Table("member")]
    public partial class Member
    {
        [Column("member_id")]
        public int MemberId { get; set; }
        [Required]
        [Column("member_fname")]
        [StringLength(50)]
        public string MemberFname { get; set; }
        [Required]
        [Column("member_lname")]
        [StringLength(50)]
        public string MemberLname { get; set; }
        [Column("contact_no")]
        public int ContactNo { get; set; }
        [Required]
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Column("expiration", TypeName = "date")]
        public DateTime Expiration { get; set; }
    }
}
