using System;
using System.Collections.Generic;

namespace Pajutrao_Project.Models;

public partial class QuizScore
{
    public int QuizNo { get; set; }

    public int? AccountNo { get; set; }

    public string? Score { get; set; }

    public DateTime? DateTimeTaken { get; set; }

    public virtual Account? AccountNoNavigation { get; set; }
}
