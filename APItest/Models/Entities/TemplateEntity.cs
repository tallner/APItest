namespace APItest.Models.Entities
{
    public class TemplateEntity
    {
        public Guid Id { get; set; }
        public string TemplateField1 { get; set; }
        public string TemplateField2 { get; set; }
        public string TemplateField3 { get; set; }

        public Boolean IsVisible { get; set; }
    }
}
