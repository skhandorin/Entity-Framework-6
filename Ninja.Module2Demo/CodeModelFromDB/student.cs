namespace CodeModelFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class student
    {
        [Key]
        public int student_id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        public int group_id { get; set; }

        public virtual group group { get; set; }
    }
}
