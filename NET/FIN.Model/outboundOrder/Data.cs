namespace FIN.Model.outboundOrder
{
    public class Data
    {
        public string Add(outboundOrderModel M_Model)
        {
            string arr = "{";
            arr += "    \"NeedUpDateFields\": [],";
            arr += "    \"NeedReturnFields\": [],";
            arr += "    \"IsDeleteEntry\": \"true\",";
            arr += "    \"SubSystemId\": \"\",";
            arr += "    \"IsVerifyBaseDataField\": \"false\",";
            arr += "    \"IsEntryBatchFill\": \"true\",";
            arr += "    \"ValidateFlag\": \"true\",";
            arr += "    \"NumberSearch\": \"true\",";
            arr += "    \"IsAutoAdjustField\": \"false\",";
            arr += "    \"InterationFlags\": \"\",";
            arr += "    \"IgnoreInterationFlag\": \"\",";
            arr += "    \"Model\": {";
            arr += "        \"FID\": 0,";
            arr += "        \"FBillTypeID\": {";
            arr += "            \"FNUMBER\": \"" + M_Model.FBillTypeID + "\"";
            arr += "        },";
            arr += "        \"FDate\": \"" + M_Model.FDATE + "\",";
            arr += "        \"FSaleOrgId\": {";
            arr += "            \"FNumber\": \"" + M_Model.FSaleOrgId + "\"";
            arr += "        },";
            arr += "        \"FCustomerID\": {";
            arr += "            \"FNumber\": \"" + M_Model.FCustomerID + "\"";
            arr += "        },";
            arr += "        \"FReceiverID\": {";
            arr += "            \"FNumber\": \"" + M_Model.FCustomerID + "\"";
            arr += "        },";
            arr += "        \"FStockOrgId\": {";
            arr += "            \"FNumber\": \"" + M_Model.FStockOrgId + "\"";
            arr += "        },";
            arr += "        \"FSettleID\": {";
            arr += "            \"FNumber\": \"" + M_Model.FCustomerID + "\"";
            arr += "        },";
            arr += "        \"FPayerID\": {";
            arr += "            \"FNumber\": \"" + M_Model.FCustomerID + "\"";
            arr += "        },";
            arr += "        \"FOwnerTypeIdHead\": \""+ M_Model.FOwnerTypeIdHead + "\",";
            arr += "        \"FIsTotalServiceOrCost\": false,";
            arr += "        \"SubHeadEntity\": {";
            arr += "            \"FSettleCurrID\": {";
            arr += "                \"FNumber\": \""+ M_Model.FSettleCurrID + "\"";
            arr += "            },";
            arr += "            \"FSettleOrgID\": {";
            arr += "                \"FNumber\": \""+ M_Model.FSettleOrgID + "\"";
            arr += "            },";
            arr += "            \"FIsIncludedTax\": true,";
            arr += "            \"FLocalCurrID\": {";
            arr += "                \"FNumber\": \""+ M_Model.FLocalCurrID + "\"";
            arr += "            },";
            arr += "            \"FExchangeTypeID\": {";
            arr += "                \"FNumber\": \""+ M_Model.FExchangeTypeID + "\"";
            arr += "            },";
            arr += "            \"FExchangeRate\": 1.0,";
            arr += "            \"FIsPriceExcludeTax\": true";
            arr += "        },";
            arr += "        \"FEntity\": [" + M_Model.FEntity + "]";
            arr += "    }";
            arr += "}";

            return arr;
        }
        public string FEntity(Add_list M_Model)
        {
            string arr = "		{";
            arr += "                \"FRowType\": \"Standard\",";
            arr += "                \"FMaterialID\": {";
            arr += "                    \"FNumber\": \""+ M_Model.FMaterialID + "\"";
            arr += "                },";
            arr += "                \"FUnitID\": {";
            arr += "                    \"FNumber\": \""+ M_Model.FUnitID + "\"";
            arr += "                },";
            arr += "                \"FRealQty\": " + M_Model.FRealQty + ",";
            arr += "                \"FIsFree\": false,";
            arr += "                \"FOwnerTypeID\": \"" + M_Model.FOwnerTypeID + "\",";
            arr += "                \"FOwnerID\": {";
            arr += "                    \"FNumber\": \"" + M_Model.FOwnerID + "\"";
            arr += "                },";
            arr += "                \"FStockID\": {";
            arr += "                    \"FNumber\": \"" + M_Model.FStockID + "\"";
            arr += "                },";
            arr += "                \"FStockStatusID\": {";
            arr += "                    \"FNumber\": \"" + M_Model.FStockStatusID + "\"";
            arr += "                },";
            arr += "                \"FSalUnitID\": {";
            arr += "                    \"FNumber\": \"" + M_Model.FUnitID + "\"";
            arr += "                },";
            arr += "                \"FSALUNITQTY\": " + M_Model.FRealQty + ",";
            arr += "                \"FSALBASEQTY\": " + M_Model.FRealQty + ",";
            arr += "                \"FPRICEBASEQTY\": " + M_Model.FRealQty + ",";
            arr += "                \"FOUTCONTROL\": false,";
            arr += "                \"FIsOverLegalOrg\": false,";
            arr += "                \"FARNOTJOINQTY\": " + M_Model.FRealQty + ",";
            arr += "                \"FCheckDelivery\": false,";
            arr += "                \"FSettleBySon\": false";
            arr += "            }";

            return arr;
        }
    }
}
