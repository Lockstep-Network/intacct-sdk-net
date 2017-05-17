﻿/*
 * Copyright 2017 Intacct Corporation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"). You may not
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * or in the "LICENSE" file accompanying this file. This file is distributed on 
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either 
 * express or implied. See the License for the specific language governing 
 * permissions and limitations under the License.
 */

using Intacct.Sdk.Functions.InventoryControl;
using Intacct.Sdk.Xml;
using System;
using System.Collections.Generic;

namespace Intacct.Sdk.Functions.OrderEntry
{

    public class OrderEntryTransactionLineUpdate : AbstractOrderEntryTransactionLine
    {

        private int lineNo;
        public int LineNo
        {
            get { return lineNo; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Line No must be greater than zero");
                }

                lineNo = value;
            }
        }

        public OrderEntryTransactionLineUpdate()
        {
        }

        public override void WriteXml(ref IaXmlWriter xml)
        {
            xml.WriteStartElement("updatesotransitem");
            xml.WriteAttribute("line_num", LineNo);

            xml.WriteElement("bundlenumber", BundleNumber);
            xml.WriteElement("itemid", ItemId, true);
            xml.WriteElement("itemdesc", ItemDescription);
            xml.WriteElement("taxable", Taxable);
            xml.WriteElement("warehouseid", WarehouseId);
            xml.WriteElement("quantity", Quantity, true);
            xml.WriteElement("unit", Unit);
            xml.WriteElement("discountpercent", DiscountPercent);
            xml.WriteElement("price", Price);
            xml.WriteElement("discsurchargememo", DiscountSurchargeMemo);
            xml.WriteElement("locationid", LocationId);
            xml.WriteElement("departmentid", DepartmentId);
            xml.WriteElement("memo", Memo);

            if (ItemDetails.Count > 0)
            {
                xml.WriteStartElement("itemdetails");
                foreach (AbstractTransactionItemDetail ItemDetail in ItemDetails)
                {
                    ItemDetail.WriteXml(ref xml);
                }
                xml.WriteEndElement(); //itemdetails
            }

            xml.WriteCustomFieldsExplicit(CustomFields);

            xml.WriteElement("revrectemplate", RevRecTemplate);

            if (RevRecStartDate.HasValue)
            {
                xml.WriteStartElement("revrecstartdate");
                xml.WriteDateSplitElements(RevRecStartDate.Value);
                xml.WriteEndElement(); //revrecstartdate
            }

            if (RevRecEndDate.HasValue)
            {
                xml.WriteStartElement("revrecenddate");
                xml.WriteDateSplitElements(RevRecEndDate.Value);
                xml.WriteEndElement(); //revrecenddate
            }

            xml.WriteElement("renewalmacro", RenewalMacro);
            xml.WriteElement("projectid", ProjectId);
            xml.WriteElement("customerid", CustomerId);
            xml.WriteElement("vendorid", VendorId);
            xml.WriteElement("employeeid", EmployeeId);
            xml.WriteElement("classid", ClassId);
            xml.WriteElement("contractid", ContractId);
            xml.WriteElement("fulfillmentstatus", FulfillmentStatus);
            xml.WriteElement("taskno", TaskNumber);
            xml.WriteElement("billingtemplate", BillingTemplate);

            xml.WriteEndElement(); //updatesotransitem
        }

    }

}