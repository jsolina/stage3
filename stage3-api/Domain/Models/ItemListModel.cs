using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class ItemListModel
    {
        [Key]
        [Column("idItem")]
        public int idItem { get; set; }
        public int idTask { get; set; }
        public string itemName { get; set; }
        public string itemDetails { get; set; }
        public string itemStatus { get; set; }
    }
}
