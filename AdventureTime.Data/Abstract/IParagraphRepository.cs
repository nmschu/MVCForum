using System;
using System.Collections.Generic;
using AdventureTime.Data.Entities;

namespace AdventureTime.Data.Abstract
{
    public interface IParagraphRepository
    {
        IEnumerable<AdventureTime_Paragraph> Paragraphs { get; }

        void SaveParagraph(AdventureTime_Paragraph para);
    }
}
