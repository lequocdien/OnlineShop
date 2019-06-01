namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupMenu")]
    public partial class GroupMenu
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
