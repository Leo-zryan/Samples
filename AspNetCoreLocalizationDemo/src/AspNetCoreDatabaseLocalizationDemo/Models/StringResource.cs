using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreDatabaseLocalizationDemo.Models;

public partial class StringResource
{
    public int Id { get; set; }

    public int? LanguageId { get; set; }

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    [NotMapped]
    public virtual Language Language { get; set; }
}
