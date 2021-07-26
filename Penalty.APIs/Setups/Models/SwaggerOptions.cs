namespace Penalty.APIs.Setups.Models
{
    public class SwaggerOptions
    {
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SwaggerContact Contact { get; set; }
    }

    public class SwaggerContact
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
