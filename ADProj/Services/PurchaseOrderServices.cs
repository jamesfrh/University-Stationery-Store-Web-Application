﻿using ADProj.DB;
using ADProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADProj.Services
{
    public class PurchaseOrderServices
    {
        protected ADProjContext dbcontext;

        public PurchaseOrderServices(ADProjContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public int addPO(string supplierId)
        {
            PurchaseOrder po = new PurchaseOrder();
            po.Date = DateTime.Now;
            po.SupplierId = supplierId;
            dbcontext.Add(po);
            dbcontext.SaveChanges();
            dbcontext.Entry(po).GetDatabaseValues();
            return po.Id;
        }
        public void addPODetails(int poId, List<CustomPODetails> poDetailsList)
        {
            foreach (CustomPODetails detail in poDetailsList)
            {
                PurchaseOrderDetails poDetails = new PurchaseOrderDetails();
                poDetails.PurchaseOrderId = poId;
                poDetails.Qty = int.Parse(detail.Quantity);
                poDetails.InventoryItemId = detail.ItemId;
                poDetails.ItemCategoryId = int.Parse(detail.CategoryId);
                dbcontext.Add(poDetails);
                dbcontext.SaveChanges();
            }
        }
    }
}