namespace Sales.Domain.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.RegisterDate = DateTime.Now;
            this.Deleted = false;
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public bool? Actived { get; set; }
        public DateTime RegisterDate { get; set; }
        public int IdCreationUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? IdModifyUser { get; set; }
        public int? IdDeleteUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
        public decimal? price { get; set; }
        public decimal? total { get; set; }
        public string? ImageURL { get; set; }
        public string? ImageName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int IdRole { get; set; }
    }
}
