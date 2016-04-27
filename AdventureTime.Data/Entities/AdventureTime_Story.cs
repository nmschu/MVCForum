using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdventureTime.Data.Entities
{
    public class AdventureTime_Story : BaseEntity
    {
        [Key]
        public int StoryID { get; set; }
        public string StoryTitle { get; set; }
        public string StoryGenre { get; set; }
        public int AuthorID { get; set; }
        public DateTime? DateCreated { get; set; }
        

    }
}
