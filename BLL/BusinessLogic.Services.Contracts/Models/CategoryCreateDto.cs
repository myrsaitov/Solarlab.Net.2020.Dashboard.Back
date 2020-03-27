namespace BusinessLogic.Services.Contracts.Models
{
    /// <summary>
    /// Категория, объект передачи данных
    /// </summary>
    public class CategoryCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
