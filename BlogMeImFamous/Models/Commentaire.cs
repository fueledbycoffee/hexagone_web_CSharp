using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMeImFamous.Models
{
    public class Commentaire
    {
        public int Id { get; set; }

        public string Contenu { get; set; }

        public DateTime DatePublication { get; set; }

        public Article Parent { get; set; }
    }
}
