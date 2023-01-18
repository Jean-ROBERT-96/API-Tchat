using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Message> Messages { get; } = new List<Message>();
    }
}
