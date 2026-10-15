namespace ProfitabilityApi.Data;

public sealed class Transaction { public long TransactionId { get; set;
     }public int BranchId { get; set;
     }public string TransactionCode { get; set;
     } = string.Empty;
    public string PortfolioCode { get; set;
     } = string.Empty;
    public long CustomerCode { get; set;
     }public string ProductCode { get; set;
     } = string.Empty;
    public string SubProductCode { get; set;
     } = string.Empty;
    public DateTime TransactionDate { get; set;
     }public decimal YPProfit { get; set;
     }public decimal TLProfit { get; set;
     }public string CurrencyCode { get; set;
     } = string.Empty;
     }
