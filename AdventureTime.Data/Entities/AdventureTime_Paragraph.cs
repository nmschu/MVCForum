using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdventureTime.Data.Entities
{
    public class AdventureTime_Paragraph : BaseEntity
    {
        [Key]
        public int ParagraphID { get; set; }
        public int StoryID { get; set; }
        public string ParagraphContent { get; set; }
        public string ParagraphImageSrc { get; set; }
        public string AudioSrc { get; set; }
        public string ChoiceOne { get; set; }
        public string ChoiceTwo { get; set; }
        public string ChoiceThree { get; set; }
        public string ChoiceFour { get; set; }

    }
}
