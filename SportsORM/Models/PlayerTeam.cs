using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsORM.Models
{
    public class PlayerTeam
    {
        [Key]
        public int PlayerTeamId { get; set; }
        public int PlayerId { get; set; }
        public Player PlayerOnTeam { get; set; }
        public int TeamId { get; set; }
        public Team TeamOfPlayer { get; set; }
    }
}
