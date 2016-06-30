using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ModelDemo.Models.Context
{
    [Table("Order")]
    public partial class Order
    {
        public Guid Id { get; set; }

        [Display(Name="Время добавления")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Владелец")]
        public string Owner { get; set; }

        public bool IsProcessing { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        public Guid ProductId { get; set; }

        [Display(Name = "Товар")]
        public virtual Product Product { get; set; }
    }
}
