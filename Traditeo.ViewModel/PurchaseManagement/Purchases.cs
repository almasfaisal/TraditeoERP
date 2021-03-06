﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Traditeo.ViewModel.Transactions;

namespace Traditeo.ViewModel.PurchaseManagement
{
    public class Purchases
    {
        public int id { get; set; }
        [Key]
        public Int64 UniqueID { get; set; }
        public Int64 PurchaseID { get; set; }

        [Display (Name= "PurchaseNumber", ResourceType =typeof(ApplicationUtility.Resources) )]
        public string PurchaseNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "DueDate", ResourceType = typeof(ApplicationUtility.Resources))]
        public DateTime DueDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "PurchaseDate", ResourceType = typeof(ApplicationUtility.Resources))]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Branch", ResourceType = typeof(ApplicationUtility.Resources))]
        public int BranchID { get; set; }

        public string BranchCode { get; set; }
        public string Branch { get; set; }

        [Display(Name = "Vendor", ResourceType = typeof(ApplicationUtility.Resources))]
        public int VendorID { get; set; }
        public string VendorCode { get; set; }
        public string Vendor { get; set; }

        [Display(Name = "PaymentTerm", ResourceType = typeof(ApplicationUtility.Resources))]
        public int? PaymentTermID { get; set; }

        [Display(Name = "PurchaseOrderNumber", ResourceType = typeof(ApplicationUtility.Resources))]
        public int? PurchaseOrderID { get; set; }
        public string PurchaseOrderNumber { get; set; }

        [Display(Name = "PurchaseSuggestionNumber", ResourceType = typeof(ApplicationUtility.Resources))]
        public int? PurchaseSuggestionID { get; set; }
        public string PurchaseSuggestionNumber { get; set; }

        [Display(Name = "PurchaseRequestNumber", ResourceType = typeof(ApplicationUtility.Resources))]
        public int? PurchaseRequestID { get; set; }
        public string PurchaseRequestNumber { get; set; }

        [Display(Name = "ReferenceNumber", ResourceType = typeof(ApplicationUtility.Resources))]
        public string ReferenceNumber { get; set; }
        public string VoucherNumber { get; set; }
        public int BusinessPeriodID { get; set; }

        [Display(Name = "PurchaseAuthority", ResourceType = typeof(ApplicationUtility.Resources))]
        public int PurchaseAuthorityID { get; set; }
        public string PurchaseAuthority { get; set; }

        [Display(Name = "Currency", ResourceType = typeof(ApplicationUtility.Resources))]
        public int CurrencyID { get; set; }
        public decimal ExchangeRate { get; set; }
        public int? ProjectID { get; set; }
        public int? DivisionID { get; set; }
        public decimal LineTotal { get; set; }
        public decimal LineMargin { get; set; }
        public decimal LineItemDiscount { get; set; }
        public decimal LineDiscount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal AditionalCharge { get; set; }
        public decimal GrandTotal { get; set; }
        public bool IsPosted { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public bool IsDisputePayment { get; set; }
        public string FilePath { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public string AddUser { get; set; }
        public DateTime AddDate { get; set; }
        public string EditUser { get; set; }
        public DateTime ? EditDate { get; set; }

        public object TransactionItemJson { get; set; }
        public object TransactionLedgerJson { get; set; }
        public object TransactionChargeJson { get; set; }

        public List<TransactionItems> TransactionItem { get; set; }
        public List<TransactionLedgers> TransactionLedger { get; set; }
        public List<TransactionCharges> TransactionCharge { get; set; }
        
    }
}
