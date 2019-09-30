using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataLayer
{
    [Table("MessagesOfTheDay")]
    public class MessageOfTheDay
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Created { get; set; }
        public DateTime? ShowOn { get; set; }
        public string EnGb {get;set;}
        public string Fr { get; set; }
        public string De { get; set; } 
    }


}
