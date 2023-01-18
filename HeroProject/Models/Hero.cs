using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroProject.Models
{

    [Table("Hero")]
    public partial class Hero
    {

        public int HeroId { get; set; }

        [Required]
        [StringLength(25)]
        public string FullName { get; set; }

        [EnumDataType(typeof(Ability))]
        public Ability Ability { get; set; }

        public DateTime StartDate { get; set; }

        [Required]
        [StringLength(10)]
        public string SuitColors { get; set; }

        public decimal? StartingPower { get; set; }

        public decimal? CurrentPower { get; set; }

        public int? TrainerId { get; set; }

    }
    public enum Ability
    {
        Attacker = 0,
        Defender = 1
    }
}
