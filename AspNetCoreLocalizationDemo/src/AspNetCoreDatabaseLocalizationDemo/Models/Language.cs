using System;
using System.Collections.Generic;

namespace AspNetCoreDatabaseLocalizationDemo.Models;

public partial class Language
{
    public Language()
    {
        StringResources = new HashSet<StringResource>();
    }
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Culture { get; set; } = null!;
    public virtual ICollection<StringResource> StringResources { get; set; }
}
