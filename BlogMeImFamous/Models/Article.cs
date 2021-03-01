using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMeImFamous.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Titre { get; set; }

        public string Contenu { get; set; }

        public DateTime DatePublication { get; set; }

        public ICollection<Commentaire> Commentaires { get; set; }

    }
}
