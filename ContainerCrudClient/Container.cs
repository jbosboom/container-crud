namespace ContainerCrudClient
{
    public class Container
    {
        public long ContainerKey { get; set; }
        public int? Rfid { get; set; }
        public string ContainerId { get; set; } = null!;
        public string? AccessionId { get; set; }
        public string? StackId { get; set; }
        public int? Slot { get; set; }
        public long ToteKey { get; set; }
        public int? Aliquot { get; set; }
        public int? Category { get; set; }
        public int ContainerTypeKey { get; set; }
        public int? StatusKey { get; set; }
        public int VisitChange { get; set; }
        public int? Flags { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string? SourceRackId { get; set; }
    }
}
