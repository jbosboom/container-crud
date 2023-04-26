using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ContainerApi
{
    [Table("Container2")]
    public partial class Container
    {
        [Key]
        public long ContainerKey { get; set; }
        [Column("RFID")]
        public int? Rfid { get; set; }
        [Column("ContainerID")]
        [StringLength(50)]
        [Unicode(false)]
        public string ContainerId { get; set; } = null!;
        [Column("AccessionID")]
        [StringLength(16)]
        [Unicode(false)]
        public string? AccessionId { get; set; }
        [Column("StackID")]
        [StringLength(32)]
        [Unicode(false)]
        public string? StackId { get; set; }
        public int? Slot { get; set; }
        public long ToteKey { get; set; }
        public int? Aliquot { get; set; }
        public int? Category { get; set; }
        public int ContainerTypeKey { get; set; }
        public int? StatusKey { get; set; }
        public int VisitChange { get; set; }
        public int? Flags { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [Column("SourceRackID")]
        [StringLength(12)]
        [Unicode(false)]
        public string? SourceRackId { get; set; }
    }
}
