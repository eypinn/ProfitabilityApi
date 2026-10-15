namespace ProfitabilityApi.Data;

public sealed class MonthlyProfitability { public int DateKey { get; set;
     }public string PortfolioCode { get; set;
     } = string.Empty;
    public int BranchId { get; set;
     }public long CustomerCode { get; set;
     }public string SegmentCode { get; set;
     } = string.Empty;
    public string ProductCode { get; set;
     } = string.Empty;
    public string SubProductCode { get; set;
     } = string.Empty;
    public string CurrencyCode { get; set;
     } = string.Empty;
    public decimal TotalYPProfit { get; set;
     }public decimal TotalTLProfit { get; set;
     }public int TransactionCount { get; set;
     } }
