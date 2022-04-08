﻿using TypographyContracts.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace TypographyDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int PrintedId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        public virtual Printed Printed { get; set; }
    }
}