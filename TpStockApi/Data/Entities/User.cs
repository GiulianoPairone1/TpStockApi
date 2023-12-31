﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TpStockApi.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName {get; set;}
        public string UserName { get; set;}
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public bool State { get; set; } = true;

    }
}
