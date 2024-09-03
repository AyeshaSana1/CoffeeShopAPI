using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopAPI.Models
{
    public class CoffeeShop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }

        public bool IsOpen
        {
            get
            {
                var now = DateTime.Now.TimeOfDay;
                return OpeningTime <= now && now <= ClosingTime;
            }
        }
    }
}
