namespace ThingsToDo.Models
{
    public class List
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public List()
        {
            // Inicializa la propiedad en el constructor
            Name = string.Empty; // O un valor predeterminado adecuado
        }
    }
}
