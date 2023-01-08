namespace HeroProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Trainer")]
    public partial class Trainer
    {
        public Trainer()
        {
            Heroes = new HashSet<Hero>();
        }

        public int TrainerId { get; set; }

        [Required]
        [StringLength(25)]
        public string FullName { get; set; }

        [Required]
        [StringLength(25)]
        public string Email { get; set; }

        [Required]
        [StringLength(8)]
        public string SecretPassword { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
