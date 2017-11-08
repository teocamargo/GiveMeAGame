using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace GiveMeAGame.Models
{
    public class GameViewModel
    {
        public Game Game { get; set; }
        public IEnumerable<SelectListItem> Friends { get; set; }

        public GameViewModel()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Friends = context.Friends.Select(x => new SelectListItem { Text = x.FriendName, Value = x.FriendId.ToString() });
        }
    }

    public class Game
    {
        [Key]
        public int GameId { get; set; }
        [Display(Name ="Nome do Jogo")]
        public string GameName { get; set; }

        [Display(Name ="Emprestado Para")]
        public int? FriendId { get; set; }

        [Display(Name = "Emprestado Para")]
        [ForeignKey("FriendId")]
        public virtual Friend Friend { get; set; }
    }

    public class Friend
    {
        [Key]
        public int FriendId { get; set; }
        [Display(Name ="Nome do Amigo")]
        public string FriendName { get; set; }

        [Display(Name = "Jogos Emprestados")]
        public virtual ICollection<Game> Games { get; set; }
    }

    public class FriendRegister
    {
        public int FriendId { get; set; }
        public string FriendName { get; set; }
    }
}