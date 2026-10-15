namespace ProfitabilityApi.Data;

public sealed class TransactionException { public long TransactionId { get; set;
     }public decimal OverrideYPProfit { get; set;
     }public decimal OverrideTLProfit { get; set;
     }public string Reason { get; set;
     } = string.Empty;
    public DateTime UpdatedAt { get; set;
     } }
