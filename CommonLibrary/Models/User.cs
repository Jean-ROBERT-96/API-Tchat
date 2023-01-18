using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int Theme { get; set; }
        public virtual ICollection<Message> Messages { get; } = new List<Message>();
        public virtual ICollection<Channel> Channels { get; } = new List<Channel>();
    }
}
