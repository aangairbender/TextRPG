using System.Collections.Generic;

namespace TextRPG.Domain.Tagging
{
    public interface ISupportTagging
    {
        ICollection<Tag> Tags { get; }
    }
}
