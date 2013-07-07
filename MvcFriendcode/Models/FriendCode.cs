using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcFriendcode.Models
{
    public class FriendCode
    {
        public int ID { get; set; }

        [Required]
        public string User { get; set; }

        [Required]
        public string Code { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateAdded { get; set; }

        [Range(0, 10)]
        public decimal Rating { get; set; }
    }

    public class FriendCodeDBContext : DbContext
    {
        public DbSet<FriendCode> FriendCodes { get; set; }
    }

}