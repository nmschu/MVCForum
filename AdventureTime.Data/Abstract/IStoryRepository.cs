using System;
using System.Collections.Generic;
using AdventureTime.Data.Entities;

namespace AdventureTime.Data.Abstract
{
    public interface IStoryRepository
    {
        IEnumerable<AdventureTime_Story> Stories { get; }

        void SaveStory(AdventureTime_Story story);

        void DeleteStory(AdventureTime_Story story);
    }
}
