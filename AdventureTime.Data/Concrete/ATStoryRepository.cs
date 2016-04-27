using System;
using System.Collections.Generic;
using AdventureTime.Data.Abstract;
using AdventureTime.Data.Entities;

namespace AdventureTime.Data.Concrete
{
    public class ATStoryRepository : IStoryRepository
    {
        // Instantiate the DbContext
        private EFDbContext context = new EFDbContext();
        // Retrieve any or all stories to the Interface repo
        public IEnumerable<AdventureTime_Story> Stories
        {
            get { return context.Stories; }
        }
        // Save new stories or make changes to existing stories
        public void SaveStory(AdventureTime_Story story)
        {
            // Check to see if story exists
            if (story.StoryID == 0)
            {
                context.Stories.Add(story);
            }
            else
            {
                // Retrieve existing story and rewrite any changes
                AdventureTime_Story dbEntry = context.Stories.Find(story.StoryID);
                if (dbEntry != null)
                {
                    dbEntry.StoryID = story.StoryID;
                    dbEntry.StoryTitle = story.StoryTitle;
                    dbEntry.StoryGenre = story.StoryGenre;
                    dbEntry.AuthorID = story.AuthorID;
                    dbEntry.DateCreated = story.DateCreated;

                }
            }

            context.SaveChanges();
        }

        public void DeleteStory(AdventureTime_Story story)
        {
            
            foreach(var paragragh in context.Paragraphs)
            {
                if (story.StoryID == paragragh.StoryID)
                {
                    context.Paragraphs.Remove(paragragh);
                    context.SaveChanges();
                }
            }

            context.Stories.Remove(story);
            context.SaveChanges();
        }
    }
}
