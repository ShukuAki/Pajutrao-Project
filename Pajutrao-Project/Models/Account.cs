using System;
using System.Collections.Generic;

namespace Pajutrao_Project.Models;

public partial class Account
{
    public int AccNo { get; set; }

    public string? AccName { get; set; }

    public string? AccPass { get; set; }

    public bool? Ufda { get; set; }

    public bool? Ulog { get; set; }

    public bool? Udbf { get; set; }

    public bool? Ucanv { get; set; }

    public virtual ICollection<QuizScore> QuizScores { get; set; } = new List<QuizScore>();
}
