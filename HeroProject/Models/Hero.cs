namespace HeroProject.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Hero")]
    public partial class Hero
    {
        public int HeroId { get; set; }

        [Required]
        [StringLength(25)]
        public string FullName { get; set; }

        [Required]
        [StringLength(10)]
        public string Ability { get; set; }

        public DateTime StartDate { get; set; }

        [Required]
        [StringLength(10)]
        public string SuitColors { get; set; }

        public decimal? StartingPower { get; set; }

        public decimal? CurrentPower { get; set; }

        public int? TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
