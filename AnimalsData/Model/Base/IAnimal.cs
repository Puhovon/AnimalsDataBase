using System.ComponentModel.DataAnnotations;

namespace AnimalsData.Model.Base
{
    interface IAnimal
    {
        int Id { get; set; }
        string Name { get; set; }
        [Required]
        string Type { get; set; }
        
    }
}
