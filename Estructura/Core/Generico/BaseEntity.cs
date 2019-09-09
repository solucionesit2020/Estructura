using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generico
{
    public class BaseEntity
    {
        public Int32 Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? AddedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedDate { get; set; }
    }
}
