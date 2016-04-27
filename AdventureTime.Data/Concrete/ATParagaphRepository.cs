using System;
using System.Collections.Generic;
using AdventureTime.Data.Abstract;
using AdventureTime.Data.Entities;

namespace AdventureTime.Data.Concrete
{
    public class ATParagaphRepository : IParagraphRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<AdventureTime_Paragraph> Paragraphs
        {
            get { return context.Paragraphs; }
        }

        public void SaveParagraph(AdventureTime_Paragraph para)
        {
            if (para.ParagraphID == 0)
            {
                context.Paragraphs.Add(para);
            }
            else
            {
                AdventureTime_Paragraph dbEntry = context.Paragraphs.Find(para.ParagraphID);
                if (dbEntry != null)
                {
                    dbEntry.ParagraphID = para.ParagraphID;
                    dbEntry.StoryID = para.StoryID;
                    dbEntry.ParagraphContent = para.ParagraphContent;
                    dbEntry.ParagraphImageSrc = para.ParagraphImageSrc;
                    dbEntry.AudioSrc = para.AudioSrc;
                    dbEntry.ChoiceOne = para.ChoiceOne;
                    dbEntry.ChoiceTwo = para.ChoiceTwo;
                    dbEntry.ChoiceThree = para.ChoiceThree;
                    dbEntry.ChoiceFour = para.ChoiceFour;
                }

            }

            context.SaveChanges();
        }
    }
}
