using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public bool Status { get; set; }
        public DateTime AddedData { get; set; }
        public DateTime? ModifiedData { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}