using Bondski.QvdLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using STCAPI.Core.ViewModel.QVDModel;
using STCAPI.Model.QVD;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STCAPI.Controllers.QVD
{
    /// <summary>
    /// Parse the QVD File and create json response
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
   
    public class QVDController : ControllerBase
    {

        private readonly IConfiguration _IConfiguration;

        public QVDController(IConfiguration iConfiguration)
        {
            _IConfiguration = iConfiguration;
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetQVDDetail()
        {
            QvdReader qvdReader = new QvdReader(_IConfiguration.GetSection("QVDPath:Param1").Value);
            var models = new List<QVDModelParam1>();
            while (qvdReader.NextRow())
            {
                QVDModelParam1 model = new QVDModelParam1();
                models.Add(model);
            }

            return Ok(models);

        }


        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetB2BModel()
        {
            QvdReader qvdReader = new QvdReader(_IConfiguration.GetSection("QVDPath:B2BParam").Value);
            var models = new List<B2BModel>();
            var responseModels = new List<QVDResponseModel>();

            while (qvdReader.NextRow())
            {
                B2BModel model = new B2BModel();

                #region ClassCreation
                model.BATCH_ID = qvdReader["BATCH_ID"].ToString();
                model.DATA_FIELD = qvdReader["DATA_FIELD"].ToString();
                model.REVENUE_MNY = qvdReader["REVENUE_MNY"].ToString();
                model.BILL_CYCLE = qvdReader["BILL_CYCLE"].ToString();
                model.CUSTOMER_TYPE = qvdReader["CUSTOMER_TYPE"].ToString();
                model.CUSTOMER_SUBTYPE = qvdReader["CUSTOMER_SUBTYPE"].ToString();
                model.INDUSTRY_TYPE = qvdReader["INDUSTRY_TYPE"].ToString();
                model.ADJUSTMENT_NAME = qvdReader["ADJUSTMENT_NAME"].ToString();
                model.DISCOUNT_NAME = qvdReader["DISCOUNT_NAME"].ToString();
                model.DISCOUNT_TYPE = qvdReader["DISCOUNT_TYPE"].ToString();
                model.DISCOUNT_CLASS = qvdReader["DISCOUNT_CLASS"].ToString();
                model.PERIOD = qvdReader["PERIOD"].ToString();
                model.CREATION_DATE = qvdReader["CREATION_DATE"].ToString();
                model.STC_SHARE = qvdReader["STC_SHARE"].ToString();
                model.REV_SHARE_FLAG = qvdReader["REV_SHARE_FLAG"].ToString();
                model.BILL_DATE = qvdReader["BILL_DATE"].ToString();
                model.BATCH_REC_SEQ = qvdReader["BATCH_REC_SEQ"].ToString();
                model.CUSTOMER_SEGMENT = qvdReader["CUSTOMER_SEGMENT"].ToString();
                model.CUSTOMER_VALUE = qvdReader["CUSTOMER_VALUE"].ToString();
                model.RELATED_PARTY = qvdReader["RELATED_PARTY"].ToString();
                model.INDUSTRY_NAME = qvdReader["INDUSTRY_NAME"].ToString();
                model.SERVICE_CODE = qvdReader["SERVICE_CODE"].ToString();
                model.ADJUSTMENT_TYPE = qvdReader["ADJUSTMENT_TYPE"].ToString();
                model.SP_ACCOUNT_NUM = qvdReader["SP_ACCOUNT_NUM"].ToString();
                model.TAX_CODE = qvdReader["TAX_CODE"].ToString();
                model.INVOICE_NUMBER = qvdReader["INVOICE_NUMBER"].ToString();
                model.ACCOUNT_NUM = qvdReader["ACCOUNT_NUM"].ToString();
                model.TAX_RATE = qvdReader["TAX_RATE"].ToString();
                model.INVOICE_REVENUE_AMOUNT = qvdReader["INVOICE_REVENUE_AMOUNT"].ToString();
                model.INVOICE_VAT_AMOUNT = qvdReader["INVOICE_VAT_AMOUNT"].ToString();
                model.SUMMARY_ID_FOREIGN_KEY = qvdReader["SUMMARY_ID_FOREIGN_KEY"].ToString();
                model.KEYPercentage = qvdReader["%KEY"].ToString();
                model.SOURCE = qvdReader["SOURCE"].ToString();
                model.REVERSAL_FLAG = qvdReader["REVERSAL_FLAG"].ToString();
                model.QUANTITY = qvdReader["QUANTITY"].ToString();
                model.JURISDICTION = qvdReader["JURISDICTION"].ToString();
                model.PEAK_OFF_PEAK_FLAG = qvdReader["PEAK_OFF_PEAK_FLAG"].ToString();
                model.SERVICE_TYPE = qvdReader["SERVICE_TYPE"].ToString();
                model.PRODUCT_ID = qvdReader["PRODUCT_ID"].ToString();
                model.DISC_USAGE_TYPE = qvdReader["DISC_USAGE_TYPE"].ToString();
                model.DISTRICT = qvdReader["DISTRICT"].ToString();
                model.GL_REV_CODE_NAME = qvdReader["GL_REV_CODE_NAME"].ToString();
                model.ABC_REV_CODE_NAME = qvdReader["ABC_REV_CODE_NAME"].ToString();
                model.SP_NAME = qvdReader["SP_NAME"].ToString();
                model.SP_PERCENTAGE = qvdReader["SP_PERCENTAGE"].ToString();
                model.SP_ADJUSTMENT_TYPE = qvdReader["SP_ADJUSTMENT_TYPE"].ToString();
                model.SP_REVENUE_CODE_NAME = qvdReader["SP_REVENUE_CODE_NAME"].ToString();
                model.REVENUE_CODE_ID = qvdReader["REVENUE_CODE_ID"].ToString();
                model.REVENUE_CODE_NAME = qvdReader["REVENUE_CODE_NAME"].ToString();
                model.EVENT_TYPE = qvdReader["EVENT_TYPE"].ToString();
                model.USAGE_TYPE = qvdReader["USAGE_TYPE"].ToString();
                model.USAGE_TYPE_DESC = qvdReader["USAGE_TYPE_DESC"].ToString();
                model.IRB_PRICE_PLAN = qvdReader["IRB_PRICE_PLAN"].ToString();
                model.CALL_CATEGORY = qvdReader["CALL_CATEGORY"].ToString();
                model.DESTINATION = qvdReader["DESTINATION"].ToString();
                model.VPLMN = qvdReader["VPLMN"].ToString();
                model.PRODUCT_NAME = qvdReader["PRODUCT_NAME"].ToString();
                model.CHARGE_TYPE = qvdReader["CHARGE_TYPE"].ToString();
                model.CUSTOMER_REF = qvdReader["CUSTOMER_REF"].ToString();

                models.Add(model);
                #endregion
            }

            var BATCH_ID = new QVDResponseModel(); BATCH_ID.key = "BATCH_ID"; BATCH_ID.value = models.Select(x => x.BATCH_ID).Distinct().ToList();
            var DATA_FIELD = new QVDResponseModel(); DATA_FIELD.key = "DATA_FIELD"; DATA_FIELD.value = models.Select(x => x.DATA_FIELD).Distinct().ToList();
            var REVENUE_MNY = new QVDResponseModel(); REVENUE_MNY.key = "REVENUE_MNY"; REVENUE_MNY.value = models.Select(x => x.REVENUE_MNY).Distinct().ToList();
            var BILL_CYCLE = new QVDResponseModel(); BILL_CYCLE.key = "BILL_CYCLE"; BILL_CYCLE.value = models.Select(x => x.BILL_CYCLE).Distinct().ToList();
            var CUSTOMER_TYPE = new QVDResponseModel(); CUSTOMER_TYPE.key = "CUSTOMER_TYPE"; CUSTOMER_TYPE.value = models.Select(x => x.CUSTOMER_TYPE).Distinct().ToList();
            var CUSTOMER_SUBTYPE = new QVDResponseModel(); CUSTOMER_SUBTYPE.key = "CUSTOMER_SUBTYPE"; CUSTOMER_SUBTYPE.value = models.Select(x => x.CUSTOMER_SUBTYPE).Distinct().ToList();
            var INDUSTRY_TYPE = new QVDResponseModel(); INDUSTRY_TYPE.key = "INDUSTRY_TYPE"; INDUSTRY_TYPE.value = models.Select(x => x.INDUSTRY_TYPE).Distinct().ToList();
            var ADJUSTMENT_NAME = new QVDResponseModel(); ADJUSTMENT_NAME.key = "ADJUSTMENT_NAME"; ADJUSTMENT_NAME.value = models.Select(x => x.ADJUSTMENT_NAME).Distinct().ToList();
            var DISCOUNT_NAME = new QVDResponseModel(); DISCOUNT_NAME.key = "DISCOUNT_NAME"; DISCOUNT_NAME.value = models.Select(x => x.DISCOUNT_NAME).Distinct().ToList();
            var DISCOUNT_TYPE = new QVDResponseModel(); DISCOUNT_TYPE.key = "DISCOUNT_TYPE"; DISCOUNT_TYPE.value = models.Select(x => x.DISCOUNT_TYPE).Distinct().ToList();
            var DISCOUNT_CLASS = new QVDResponseModel(); DISCOUNT_CLASS.key = "DISCOUNT_CLASS"; DISCOUNT_CLASS.value = models.Select(x => x.DISCOUNT_CLASS).Distinct().ToList();
            var PERIOD = new QVDResponseModel(); PERIOD.key = "PERIOD"; PERIOD.value = models.Select(x => x.PERIOD).Distinct().ToList();
            var CREATION_DATE = new QVDResponseModel(); CREATION_DATE.key = "CREATION_DATE"; CREATION_DATE.value = models.Select(x => x.CREATION_DATE).Distinct().ToList();
            var STC_SHARE = new QVDResponseModel(); STC_SHARE.key = "STC_SHARE"; STC_SHARE.value = models.Select(x => x.STC_SHARE).Distinct().ToList();
            var REV_SHARE_FLAG = new QVDResponseModel(); REV_SHARE_FLAG.key = "REV_SHARE_FLAG"; REV_SHARE_FLAG.value = models.Select(x => x.REV_SHARE_FLAG).Distinct().ToList();
            var BILL_DATE = new QVDResponseModel(); BILL_DATE.key = "BILL_DATE"; BILL_DATE.value = models.Select(x => x.BILL_DATE).Distinct().ToList();
            var BATCH_REC_SEQ = new QVDResponseModel(); BATCH_REC_SEQ.key = "BATCH_REC_SEQ"; BATCH_REC_SEQ.value = models.Select(x => x.BATCH_REC_SEQ).Distinct().ToList();
            var CUSTOMER_SEGMENT = new QVDResponseModel(); CUSTOMER_SEGMENT.key = "CUSTOMER_SEGMENT"; CUSTOMER_SEGMENT.value = models.Select(x => x.CUSTOMER_SEGMENT).Distinct().ToList();
            var CUSTOMER_VALUE = new QVDResponseModel(); CUSTOMER_VALUE.key = "CUSTOMER_VALUE"; CUSTOMER_VALUE.value = models.Select(x => x.CUSTOMER_VALUE).Distinct().ToList();
            var RELATED_PARTY = new QVDResponseModel(); RELATED_PARTY.key = "RELATED_PARTY"; RELATED_PARTY.value = models.Select(x => x.RELATED_PARTY).Distinct().ToList();
            var INDUSTRY_NAME = new QVDResponseModel(); INDUSTRY_NAME.key = "INDUSTRY_NAME"; INDUSTRY_NAME.value = models.Select(x => x.INDUSTRY_NAME).Distinct().ToList();
            var SERVICE_CODE = new QVDResponseModel(); SERVICE_CODE.key = "SERVICE_CODE"; SERVICE_CODE.value = models.Select(x => x.SERVICE_CODE).Distinct().ToList();
            var ADJUSTMENT_TYPE = new QVDResponseModel(); ADJUSTMENT_TYPE.key = "ADJUSTMENT_TYPE"; ADJUSTMENT_TYPE.value = models.Select(x => x.ADJUSTMENT_TYPE).Distinct().ToList();
            var SP_ACCOUNT_NUM = new QVDResponseModel(); SP_ACCOUNT_NUM.key = "SP_ACCOUNT_NUM"; SP_ACCOUNT_NUM.value = models.Select(x => x.SP_ACCOUNT_NUM).Distinct().ToList();
            var TAX_CODE = new QVDResponseModel(); TAX_CODE.key = "TAX_CODE"; TAX_CODE.value = models.Select(x => x.TAX_CODE).Distinct().ToList();
            var INVOICE_NUMBER = new QVDResponseModel(); INVOICE_NUMBER.key = "INVOICE_NUMBER"; INVOICE_NUMBER.value = models.Select(x => x.INVOICE_NUMBER).Distinct().ToList();
            var ACCOUNT_NUM = new QVDResponseModel(); ACCOUNT_NUM.key = "ACCOUNT_NUM"; ACCOUNT_NUM.value = models.Select(x => x.ACCOUNT_NUM).Distinct().ToList();
            var TAX_RATE = new QVDResponseModel(); TAX_RATE.key = "TAX_RATE"; TAX_RATE.value = models.Select(x => x.TAX_RATE).Distinct().ToList();
            var INVOICE_REVENUE_AMOUNT = new QVDResponseModel(); INVOICE_REVENUE_AMOUNT.key = "INVOICE_REVENUE_AMOUNT"; INVOICE_REVENUE_AMOUNT.value = models.Select(x => x.INVOICE_REVENUE_AMOUNT).Distinct().ToList();
            var INVOICE_VAT_AMOUNT = new QVDResponseModel(); INVOICE_VAT_AMOUNT.key = "INVOICE_VAT_AMOUNT"; INVOICE_VAT_AMOUNT.value = models.Select(x => x.INVOICE_VAT_AMOUNT).Distinct().ToList();
            var SUMMARY_ID_FOREIGN_KEY = new QVDResponseModel(); SUMMARY_ID_FOREIGN_KEY.key = "SUMMARY_ID_FOREIGN_KEY"; SUMMARY_ID_FOREIGN_KEY.value = models.Select(x => x.SUMMARY_ID_FOREIGN_KEY).Distinct().ToList();
            //var % KEY = new QVDResponseModel();% KEY.key =% KEY;% KEY.value = models.Select(x => x.% KEY).Distinct().ToList();
            var SOURCE = new QVDResponseModel(); SOURCE.key = "SOURCE"; SOURCE.value = models.Select(x => x.SOURCE).Distinct().ToList();
            var REVERSAL_FLAG = new QVDResponseModel(); REVERSAL_FLAG.key = "REVERSAL_FLAG"; REVERSAL_FLAG.value = models.Select(x => x.REVERSAL_FLAG).Distinct().ToList();
            var QUANTITY = new QVDResponseModel(); QUANTITY.key = "QUANTITY"; QUANTITY.value = models.Select(x => x.QUANTITY).Distinct().ToList();
            var JURISDICTION = new QVDResponseModel(); JURISDICTION.key = "JURISDICTION"; JURISDICTION.value = models.Select(x => x.JURISDICTION).Distinct().ToList();
            var PEAK_OFF_PEAK_FLAG = new QVDResponseModel(); PEAK_OFF_PEAK_FLAG.key = "PEAK_OFF_PEAK_FLAG"; PEAK_OFF_PEAK_FLAG.value = models.Select(x => x.PEAK_OFF_PEAK_FLAG).Distinct().ToList();
            var SERVICE_TYPE = new QVDResponseModel(); SERVICE_TYPE.key = "SERVICE_TYPE"; SERVICE_TYPE.value = models.Select(x => x.SERVICE_TYPE).Distinct().ToList();
            var PRODUCT_ID = new QVDResponseModel(); PRODUCT_ID.key = "PRODUCT_ID"; PRODUCT_ID.value = models.Select(x => x.PRODUCT_ID).Distinct().ToList();
            var DISC_USAGE_TYPE = new QVDResponseModel(); DISC_USAGE_TYPE.key = "DISC_USAGE_TYPE"; DISC_USAGE_TYPE.value = models.Select(x => x.DISC_USAGE_TYPE).Distinct().ToList();
            var DISTRICT = new QVDResponseModel(); DISTRICT.key = "DISTRICT"; DISTRICT.value = models.Select(x => x.DISTRICT).Distinct().ToList();
            var GL_REV_CODE_NAME = new QVDResponseModel(); GL_REV_CODE_NAME.key = "GL_REV_CODE_NAME"; GL_REV_CODE_NAME.value = models.Select(x => x.GL_REV_CODE_NAME).Distinct().ToList();
            var ABC_REV_CODE_NAME = new QVDResponseModel(); ABC_REV_CODE_NAME.key = "ABC_REV_CODE_NAME"; ABC_REV_CODE_NAME.value = models.Select(x => x.ABC_REV_CODE_NAME).Distinct().ToList();
            var SP_NAME = new QVDResponseModel(); SP_NAME.key = "SP_NAME"; SP_NAME.value = models.Select(x => x.SP_NAME).Distinct().ToList();
            var SP_PERCENTAGE = new QVDResponseModel(); SP_PERCENTAGE.key = "SP_PERCENTAGE"; SP_PERCENTAGE.value = models.Select(x => x.SP_PERCENTAGE).Distinct().ToList();
            var SP_ADJUSTMENT_TYPE = new QVDResponseModel(); SP_ADJUSTMENT_TYPE.key = "SP_ADJUSTMENT_TYPE"; SP_ADJUSTMENT_TYPE.value = models.Select(x => x.SP_ADJUSTMENT_TYPE).Distinct().ToList();
            var SP_REVENUE_CODE_NAME = new QVDResponseModel(); SP_REVENUE_CODE_NAME.key = "SP_REVENUE_CODE_NAME"; SP_REVENUE_CODE_NAME.value = models.Select(x => x.SP_REVENUE_CODE_NAME).Distinct().ToList();
            var REVENUE_CODE_ID = new QVDResponseModel(); REVENUE_CODE_ID.key = "REVENUE_CODE_ID"; REVENUE_CODE_ID.value = models.Select(x => x.REVENUE_CODE_ID).Distinct().ToList();
            var REVENUE_CODE_NAME = new QVDResponseModel(); REVENUE_CODE_NAME.key = "REVENUE_CODE_NAME"; REVENUE_CODE_NAME.value = models.Select(x => x.REVENUE_CODE_NAME).Distinct().ToList();
            var EVENT_TYPE = new QVDResponseModel(); EVENT_TYPE.key = "EVENT_TYPE"; EVENT_TYPE.value = models.Select(x => x.EVENT_TYPE).Distinct().ToList();
            var USAGE_TYPE = new QVDResponseModel(); USAGE_TYPE.key = "USAGE_TYPE"; USAGE_TYPE.value = models.Select(x => x.USAGE_TYPE).Distinct().ToList();
            var USAGE_TYPE_DESC = new QVDResponseModel(); USAGE_TYPE_DESC.key = "USAGE_TYPE_DESC"; USAGE_TYPE_DESC.value = models.Select(x => x.USAGE_TYPE_DESC).Distinct().ToList();
            var IRB_PRICE_PLAN = new QVDResponseModel(); IRB_PRICE_PLAN.key = "IRB_PRICE_PLAN"; IRB_PRICE_PLAN.value = models.Select(x => x.IRB_PRICE_PLAN).Distinct().ToList();
            var CALL_CATEGORY = new QVDResponseModel(); CALL_CATEGORY.key = "CALL_CATEGORY"; CALL_CATEGORY.value = models.Select(x => x.CALL_CATEGORY).Distinct().ToList();
            var DESTINATION = new QVDResponseModel(); DESTINATION.key = "DESTINATION"; DESTINATION.value = models.Select(x => x.DESTINATION).Distinct().ToList();
            var VPLMN = new QVDResponseModel(); VPLMN.key = "VPLMN"; VPLMN.value = models.Select(x => x.VPLMN).Distinct().ToList();
            var PRODUCT_NAME = new QVDResponseModel(); PRODUCT_NAME.key = "PRODUCT_NAME"; PRODUCT_NAME.value = models.Select(x => x.PRODUCT_NAME).Distinct().ToList();
            var CHARGE_TYPE = new QVDResponseModel(); CHARGE_TYPE.key = "CHARGE_TYPE"; CHARGE_TYPE.value = models.Select(x => x.CHARGE_TYPE).Distinct().ToList();
            var CUSTOMER_REF = new QVDResponseModel(); CUSTOMER_REF.key = "CUSTOMER_REF"; CUSTOMER_REF.value = models.Select(x => x.CUSTOMER_REF).Distinct().ToList();


            if (BATCH_ID.value.Count < 10000) responseModels.Add(BATCH_ID);
            if (DATA_FIELD.value.Count < 10000) responseModels.Add(DATA_FIELD);
            if (REVENUE_MNY.value.Count < 10000) responseModels.Add(REVENUE_MNY);
            if (BILL_CYCLE.value.Count < 10000) responseModels.Add(BILL_CYCLE);
            if (CUSTOMER_TYPE.value.Count < 10000) responseModels.Add(CUSTOMER_TYPE);
            if (CUSTOMER_SUBTYPE.value.Count < 10000) responseModels.Add(CUSTOMER_SUBTYPE);
            if (INDUSTRY_TYPE.value.Count < 10000) responseModels.Add(INDUSTRY_TYPE);
            if (ADJUSTMENT_NAME.value.Count < 10000) responseModels.Add(ADJUSTMENT_NAME);
            if (DISCOUNT_NAME.value.Count < 10000) responseModels.Add(DISCOUNT_NAME);
            if (DISCOUNT_TYPE.value.Count < 10000) responseModels.Add(DISCOUNT_TYPE);
            if (DISCOUNT_CLASS.value.Count < 10000) responseModels.Add(DISCOUNT_CLASS);
            if (PERIOD.value.Count < 10000) responseModels.Add(PERIOD);
            if (CREATION_DATE.value.Count < 10000) responseModels.Add(CREATION_DATE);
            if (STC_SHARE.value.Count < 10000) responseModels.Add(STC_SHARE);
            if (REV_SHARE_FLAG.value.Count < 10000) responseModels.Add(REV_SHARE_FLAG);
            if (BILL_DATE.value.Count < 10000) responseModels.Add(BILL_DATE);
            if (BATCH_REC_SEQ.value.Count < 10000) responseModels.Add(BATCH_REC_SEQ);
            if (CUSTOMER_SEGMENT.value.Count < 10000) responseModels.Add(CUSTOMER_SEGMENT);
            if (CUSTOMER_VALUE.value.Count < 10000) responseModels.Add(CUSTOMER_VALUE);
            if (RELATED_PARTY.value.Count < 10000) responseModels.Add(RELATED_PARTY);
            if (INDUSTRY_NAME.value.Count < 10000) responseModels.Add(INDUSTRY_NAME);
            if (SERVICE_CODE.value.Count < 10000) responseModels.Add(SERVICE_CODE);
            if (ADJUSTMENT_TYPE.value.Count < 10000) responseModels.Add(ADJUSTMENT_TYPE);
            if (SP_ACCOUNT_NUM.value.Count < 10000) responseModels.Add(SP_ACCOUNT_NUM);
            if (TAX_CODE.value.Count < 10000) responseModels.Add(TAX_CODE);
            if (INVOICE_NUMBER.value.Count < 10000) responseModels.Add(INVOICE_NUMBER);
            if (ACCOUNT_NUM.value.Count < 10000) responseModels.Add(ACCOUNT_NUM);
            if (TAX_RATE.value.Count < 10000) responseModels.Add(TAX_RATE);
            if (INVOICE_REVENUE_AMOUNT.value.Count < 10000) responseModels.Add(INVOICE_REVENUE_AMOUNT);
            if (INVOICE_VAT_AMOUNT.value.Count < 10000) responseModels.Add(INVOICE_VAT_AMOUNT);
            if (SUMMARY_ID_FOREIGN_KEY.value.Count < 10000) responseModels.Add(SUMMARY_ID_FOREIGN_KEY);
            //if (% KEY.value.Count < 10000) responseModels.Add(% KEY);
            if (SOURCE.value.Count < 10000) responseModels.Add(SOURCE);
            if (REVERSAL_FLAG.value.Count < 10000) responseModels.Add(REVERSAL_FLAG);
            if (QUANTITY.value.Count < 10000) responseModels.Add(QUANTITY);
            if (JURISDICTION.value.Count < 10000) responseModels.Add(JURISDICTION);
            if (PEAK_OFF_PEAK_FLAG.value.Count < 10000) responseModels.Add(PEAK_OFF_PEAK_FLAG);
            if (SERVICE_TYPE.value.Count < 10000) responseModels.Add(SERVICE_TYPE);
            if (PRODUCT_ID.value.Count < 10000) responseModels.Add(PRODUCT_ID);
            if (DISC_USAGE_TYPE.value.Count < 10000) responseModels.Add(DISC_USAGE_TYPE);
            if (DISTRICT.value.Count < 10000) responseModels.Add(DISTRICT);
            if (GL_REV_CODE_NAME.value.Count < 10000) responseModels.Add(GL_REV_CODE_NAME);
            if (ABC_REV_CODE_NAME.value.Count < 10000) responseModels.Add(ABC_REV_CODE_NAME);
            if (SP_NAME.value.Count < 10000) responseModels.Add(SP_NAME);
            if (SP_PERCENTAGE.value.Count < 10000) responseModels.Add(SP_PERCENTAGE);
            if (SP_ADJUSTMENT_TYPE.value.Count < 10000) responseModels.Add(SP_ADJUSTMENT_TYPE);
            if (SP_REVENUE_CODE_NAME.value.Count < 10000) responseModels.Add(SP_REVENUE_CODE_NAME);
            if (REVENUE_CODE_ID.value.Count < 10000) responseModels.Add(REVENUE_CODE_ID);
            if (REVENUE_CODE_NAME.value.Count < 10000) responseModels.Add(REVENUE_CODE_NAME);
            if (EVENT_TYPE.value.Count < 10000) responseModels.Add(EVENT_TYPE);
            if (USAGE_TYPE.value.Count < 10000) responseModels.Add(USAGE_TYPE);
            if (USAGE_TYPE_DESC.value.Count < 10000) responseModels.Add(USAGE_TYPE_DESC);
            if (IRB_PRICE_PLAN.value.Count < 10000) responseModels.Add(IRB_PRICE_PLAN);
            if (CALL_CATEGORY.value.Count < 10000) responseModels.Add(CALL_CATEGORY);
            if (DESTINATION.value.Count < 10000) responseModels.Add(DESTINATION);
            if (VPLMN.value.Count < 10000) responseModels.Add(VPLMN);
            if (PRODUCT_NAME.value.Count < 10000) responseModels.Add(PRODUCT_NAME);
            if (CHARGE_TYPE.value.Count < 10000) responseModels.Add(CHARGE_TYPE);
            if (CUSTOMER_REF.value.Count < 10000) responseModels.Add(CUSTOMER_REF);





            return Ok(responseModels);
        }



        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetB2CModel()
        {
            QvdReader qvdReader = new QvdReader(_IConfiguration.GetSection("QVDPath:B2CParam").Value);
            var models = new List<B2CModel>();
            var responseModels = new List<QVDResponseModel>();

            while (qvdReader.NextRow())
            {
                var model = new B2CModel();

                #region ClassCreation
                model.BATCH_ID = qvdReader["BATCH_ID"].ToString();
                model.DATA_FIELD = qvdReader["DATA_FIELD"].ToString();
                model.REVENUE_MNY = qvdReader["REVENUE_MNY"].ToString();
                model.BILL_CYCLE = qvdReader["BILL_CYCLE"].ToString();
                model.CUSTOMER_TYPE = qvdReader["CUSTOMER_TYPE"].ToString();
                model.CUSTOMER_SUBTYPE = qvdReader["CUSTOMER_SUBTYPE"].ToString();
                model.INDUSTRY_TYPE = qvdReader["INDUSTRY_TYPE"].ToString();
                model.ADJUSTMENT_NAME = qvdReader["ADJUSTMENT_NAME"].ToString();
                model.DISCOUNT_NAME = qvdReader["DISCOUNT_NAME"].ToString();
                model.DISCOUNT_TYPE = qvdReader["DISCOUNT_TYPE"].ToString();
                model.DISCOUNT_CLASS = qvdReader["DISCOUNT_CLASS"].ToString();
                model.PERIOD = qvdReader["PERIOD"].ToString();
                model.CREATION_DATE = qvdReader["CREATION_DATE"].ToString();
                model.STC_SHARE = qvdReader["STC_SHARE"].ToString();
                model.REV_SHARE_FLAG = qvdReader["REV_SHARE_FLAG"].ToString();
                model.BILL_DATE = qvdReader["BILL_DATE"].ToString();
                model.BATCH_REC_SEQ = qvdReader["BATCH_REC_SEQ"].ToString();
                model.CUSTOMER_SEGMENT = qvdReader["CUSTOMER_SEGMENT"].ToString();
                model.CUSTOMER_VALUE = qvdReader["CUSTOMER_VALUE"].ToString();
                model.RELATED_PARTY = qvdReader["RELATED_PARTY"].ToString();
                model.INDUSTRY_NAME = qvdReader["INDUSTRY_NAME"].ToString();
                model.SERVICE_CODE = qvdReader["SERVICE_CODE"].ToString();
                model.ADJUSTMENT_TYPE = qvdReader["ADJUSTMENT_TYPE"].ToString();
                model.SP_ACCOUNT_NUM = qvdReader["SP_ACCOUNT_NUM"].ToString();
                model.TAX_CODE = qvdReader["TAX_CODE"].ToString();
                model.INVOICE_NUMBER = qvdReader["INVOICE_NUMBER"].ToString();
                model.ACCOUNT_NUM = qvdReader["ACCOUNT_NUM"].ToString();
                model.INVOICE_NUMBER_ID = qvdReader["INVOICE_NUMBER_ID"].ToString();
                model.TAX_RATE = qvdReader["TAX_RATE"].ToString();
                model.INVOICE_REVENUE_AMOUNT = qvdReader["INVOICE_REVENUE_AMOUNT"].ToString();
                model.INVOICE_VAT_AMOUNT = qvdReader["INVOICE_VAT_AMOUNT"].ToString();
                model.SUMMARY_ID_FOREIGN_KEY = qvdReader["SUMMARY_ID_FOREIGN_KEY"].ToString();
                //model.KEYPercentage = qvdReader["% KEY"].ToString();
                model.SOURCE = qvdReader["SOURCE"].ToString();
                model.REVERSAL_FLAG = qvdReader["REVERSAL_FLAG"].ToString();
                model.QUANTITY = qvdReader["QUANTITY"].ToString();
                model.JURISDICTION = qvdReader["JURISDICTION"].ToString();
                model.PEAK_OFF_PEAK_FLAG = qvdReader["PEAK_OFF_PEAK_FLAG"].ToString();
                model.SERVICE_TYPE = qvdReader["SERVICE_TYPE"].ToString();
                model.PRODUCT_ID = qvdReader["PRODUCT_ID"].ToString();
                model.DISC_USAGE_TYPE = qvdReader["DISC_USAGE_TYPE"].ToString();
                model.DISTRICT = qvdReader["DISTRICT"].ToString();
                model.GL_REV_CODE_NAME = qvdReader["GL_REV_CODE_NAME"].ToString();
                model.ABC_REV_CODE_NAME = qvdReader["ABC_REV_CODE_NAME"].ToString();
                model.SP_NAME = qvdReader["SP_NAME"].ToString();
                model.SP_PERCENTAGE = qvdReader["SP_PERCENTAGE"].ToString();
                model.SP_ADJUSTMENT_TYPE = qvdReader["SP_ADJUSTMENT_TYPE"].ToString();
                model.SP_REVENUE_CODE_NAME = qvdReader["SP_REVENUE_CODE_NAME"].ToString();
                model.REVENUE_CODE_ID = qvdReader["REVENUE_CODE_ID"].ToString();
                model.REVENUE_CODE_NAME = qvdReader["REVENUE_CODE_NAME"].ToString();
                model.EVENT_TYPE = qvdReader["EVENT_TYPE"].ToString();
                model.USAGE_TYPE = qvdReader["USAGE_TYPE"].ToString();
                model.USAGE_TYPE_DESC = qvdReader["USAGE_TYPE_DESC"].ToString();
                model.IRB_PRICE_PLAN = qvdReader["IRB_PRICE_PLAN"].ToString();
                model.CALL_CATEGORY = qvdReader["CALL_CATEGORY"].ToString();
                model.DESTINATION = qvdReader["DESTINATION"].ToString();
                model.VPLMN = qvdReader["VPLMN"].ToString();
                model.PRODUCT_NAME = qvdReader["PRODUCT_NAME"].ToString();
                model.CHARGE_TYPE = qvdReader["CHARGE_TYPE"].ToString();


                models.Add(model);
                #endregion
            }

            var BATCH_ID = new QVDResponseModel(); BATCH_ID.key = "BATCH_ID"; BATCH_ID.value = models.Select(x => x.BATCH_ID).Distinct().ToList();
            var DATA_FIELD = new QVDResponseModel(); DATA_FIELD.key = "DATA_FIELD"; DATA_FIELD.value = models.Select(x => x.DATA_FIELD).Distinct().ToList();
            var REVENUE_MNY = new QVDResponseModel(); REVENUE_MNY.key = "REVENUE_MNY"; REVENUE_MNY.value = models.Select(x => x.REVENUE_MNY).Distinct().ToList();
            var BILL_CYCLE = new QVDResponseModel(); BILL_CYCLE.key = "BILL_CYCLE"; BILL_CYCLE.value = models.Select(x => x.BILL_CYCLE).Distinct().ToList();
            var CUSTOMER_TYPE = new QVDResponseModel(); CUSTOMER_TYPE.key = "CUSTOMER_TYPE"; CUSTOMER_TYPE.value = models.Select(x => x.CUSTOMER_TYPE).Distinct().ToList();
            var CUSTOMER_SUBTYPE = new QVDResponseModel(); CUSTOMER_SUBTYPE.key = "CUSTOMER_SUBTYPE"; CUSTOMER_SUBTYPE.value = models.Select(x => x.CUSTOMER_SUBTYPE).Distinct().ToList();
            var INDUSTRY_TYPE = new QVDResponseModel(); INDUSTRY_TYPE.key = "INDUSTRY_TYPE"; INDUSTRY_TYPE.value = models.Select(x => x.INDUSTRY_TYPE).Distinct().ToList();
            var ADJUSTMENT_NAME = new QVDResponseModel(); ADJUSTMENT_NAME.key = "ADJUSTMENT_NAME"; ADJUSTMENT_NAME.value = models.Select(x => x.ADJUSTMENT_NAME).Distinct().ToList();
            var DISCOUNT_NAME = new QVDResponseModel(); DISCOUNT_NAME.key = "DISCOUNT_NAME"; DISCOUNT_NAME.value = models.Select(x => x.DISCOUNT_NAME).Distinct().ToList();
            var DISCOUNT_TYPE = new QVDResponseModel(); DISCOUNT_TYPE.key = "DISCOUNT_TYPE"; DISCOUNT_TYPE.value = models.Select(x => x.DISCOUNT_TYPE).Distinct().ToList();
            var DISCOUNT_CLASS = new QVDResponseModel(); DISCOUNT_CLASS.key = "DISCOUNT_CLASS"; DISCOUNT_CLASS.value = models.Select(x => x.DISCOUNT_CLASS).Distinct().ToList();
            var PERIOD = new QVDResponseModel(); PERIOD.key = "PERIOD"; PERIOD.value = models.Select(x => x.PERIOD).Distinct().ToList();
            var CREATION_DATE = new QVDResponseModel(); CREATION_DATE.key = "CREATION_DATE"; CREATION_DATE.value = models.Select(x => x.CREATION_DATE).Distinct().ToList();
            var STC_SHARE = new QVDResponseModel(); STC_SHARE.key = "STC_SHARE"; STC_SHARE.value = models.Select(x => x.STC_SHARE).Distinct().ToList();
            var REV_SHARE_FLAG = new QVDResponseModel(); REV_SHARE_FLAG.key = "REV_SHARE_FLAG"; REV_SHARE_FLAG.value = models.Select(x => x.REV_SHARE_FLAG).Distinct().ToList();
            var BILL_DATE = new QVDResponseModel(); BILL_DATE.key = "BILL_DATE"; BILL_DATE.value = models.Select(x => x.BILL_DATE).Distinct().ToList();
            var BATCH_REC_SEQ = new QVDResponseModel(); BATCH_REC_SEQ.key = "BATCH_REC_SEQ"; BATCH_REC_SEQ.value = models.Select(x => x.BATCH_REC_SEQ).Distinct().ToList();
            var CUSTOMER_SEGMENT = new QVDResponseModel(); CUSTOMER_SEGMENT.key = "CUSTOMER_SEGMENT"; CUSTOMER_SEGMENT.value = models.Select(x => x.CUSTOMER_SEGMENT).Distinct().ToList();
            var CUSTOMER_VALUE = new QVDResponseModel(); CUSTOMER_VALUE.key = "CUSTOMER_VALUE"; CUSTOMER_VALUE.value = models.Select(x => x.CUSTOMER_VALUE).Distinct().ToList();
            var RELATED_PARTY = new QVDResponseModel(); RELATED_PARTY.key = "RELATED_PARTY"; RELATED_PARTY.value = models.Select(x => x.RELATED_PARTY).Distinct().ToList();
            var INDUSTRY_NAME = new QVDResponseModel(); INDUSTRY_NAME.key = "INDUSTRY_NAME"; INDUSTRY_NAME.value = models.Select(x => x.INDUSTRY_NAME).Distinct().ToList();
            var SERVICE_CODE = new QVDResponseModel(); SERVICE_CODE.key = "SERVICE_CODE"; SERVICE_CODE.value = models.Select(x => x.SERVICE_CODE).Distinct().ToList();
            var ADJUSTMENT_TYPE = new QVDResponseModel(); ADJUSTMENT_TYPE.key = "ADJUSTMENT_TYPE"; ADJUSTMENT_TYPE.value = models.Select(x => x.ADJUSTMENT_TYPE).Distinct().ToList();
            var SP_ACCOUNT_NUM = new QVDResponseModel(); SP_ACCOUNT_NUM.key = "SP_ACCOUNT_NUM"; SP_ACCOUNT_NUM.value = models.Select(x => x.SP_ACCOUNT_NUM).Distinct().ToList();
            var TAX_CODE = new QVDResponseModel(); TAX_CODE.key = "TAX_CODE"; TAX_CODE.value = models.Select(x => x.TAX_CODE).Distinct().ToList();
            var INVOICE_NUMBER = new QVDResponseModel(); INVOICE_NUMBER.key = "INVOICE_NUMBER"; INVOICE_NUMBER.value = models.Select(x => x.INVOICE_NUMBER).Distinct().ToList();
            var ACCOUNT_NUM = new QVDResponseModel(); ACCOUNT_NUM.key = "ACCOUNT_NUM"; ACCOUNT_NUM.value = models.Select(x => x.ACCOUNT_NUM).Distinct().ToList();
            var INVOICE_NUMBER_ID = new QVDResponseModel(); INVOICE_NUMBER_ID.key = "INVOICE_NUMBER_ID"; INVOICE_NUMBER_ID.value = models.Select(x => x.INVOICE_NUMBER_ID).Distinct().ToList();
            var TAX_RATE = new QVDResponseModel(); TAX_RATE.key = "TAX_RATE"; TAX_RATE.value = models.Select(x => x.TAX_RATE).Distinct().ToList();
            var INVOICE_REVENUE_AMOUNT = new QVDResponseModel(); INVOICE_REVENUE_AMOUNT.key = "INVOICE_REVENUE_AMOUNT"; INVOICE_REVENUE_AMOUNT.value = models.Select(x => x.INVOICE_REVENUE_AMOUNT).Distinct().ToList();
            var INVOICE_VAT_AMOUNT = new QVDResponseModel(); INVOICE_VAT_AMOUNT.key = "INVOICE_VAT_AMOUNT"; INVOICE_VAT_AMOUNT.value = models.Select(x => x.INVOICE_VAT_AMOUNT).Distinct().ToList();
            var SUMMARY_ID_FOREIGN_KEY = new QVDResponseModel(); SUMMARY_ID_FOREIGN_KEY.key = "SUMMARY_ID_FOREIGN_KEY"; SUMMARY_ID_FOREIGN_KEY.value = models.Select(x => x.SUMMARY_ID_FOREIGN_KEY).Distinct().ToList();
            //var keyPercetage = new QVDResponseModel();% KEY.key =% KEY;% KEY.value = models.Select(x => x.% KEY).Distinct().ToList();
            var SOURCE = new QVDResponseModel(); SOURCE.key = "SOURCE"; SOURCE.value = models.Select(x => x.SOURCE).Distinct().ToList();
            var REVERSAL_FLAG = new QVDResponseModel(); REVERSAL_FLAG.key = "REVERSAL_FLAG"; REVERSAL_FLAG.value = models.Select(x => x.REVERSAL_FLAG).Distinct().ToList();
            var QUANTITY = new QVDResponseModel(); QUANTITY.key = "QUANTITY"; QUANTITY.value = models.Select(x => x.QUANTITY).Distinct().ToList();
            var JURISDICTION = new QVDResponseModel(); JURISDICTION.key = "JURISDICTION"; JURISDICTION.value = models.Select(x => x.JURISDICTION).Distinct().ToList();
            var PEAK_OFF_PEAK_FLAG = new QVDResponseModel(); PEAK_OFF_PEAK_FLAG.key = "PEAK_OFF_PEAK_FLAG"; PEAK_OFF_PEAK_FLAG.value = models.Select(x => x.PEAK_OFF_PEAK_FLAG).Distinct().ToList();
            var SERVICE_TYPE = new QVDResponseModel(); SERVICE_TYPE.key = "SERVICE_TYPE"; SERVICE_TYPE.value = models.Select(x => x.SERVICE_TYPE).Distinct().ToList();
            var PRODUCT_ID = new QVDResponseModel(); PRODUCT_ID.key = "PRODUCT_ID"; PRODUCT_ID.value = models.Select(x => x.PRODUCT_ID).Distinct().ToList();
            var DISC_USAGE_TYPE = new QVDResponseModel(); DISC_USAGE_TYPE.key = "DISC_USAGE_TYPE"; DISC_USAGE_TYPE.value = models.Select(x => x.DISC_USAGE_TYPE).Distinct().ToList();
            var DISTRICT = new QVDResponseModel(); DISTRICT.key = "DISTRICT"; DISTRICT.value = models.Select(x => x.DISTRICT).Distinct().ToList();
            var GL_REV_CODE_NAME = new QVDResponseModel(); GL_REV_CODE_NAME.key = "GL_REV_CODE_NAME"; GL_REV_CODE_NAME.value = models.Select(x => x.GL_REV_CODE_NAME).Distinct().ToList();
            var ABC_REV_CODE_NAME = new QVDResponseModel(); ABC_REV_CODE_NAME.key = "ABC_REV_CODE_NAME"; ABC_REV_CODE_NAME.value = models.Select(x => x.ABC_REV_CODE_NAME).Distinct().ToList();
            var SP_NAME = new QVDResponseModel(); SP_NAME.key = "SP_NAME"; SP_NAME.value = models.Select(x => x.SP_NAME).Distinct().ToList();
            var SP_PERCENTAGE = new QVDResponseModel(); SP_PERCENTAGE.key = "SP_PERCENTAGE"; SP_PERCENTAGE.value = models.Select(x => x.SP_PERCENTAGE).Distinct().ToList();
            var SP_ADJUSTMENT_TYPE = new QVDResponseModel(); SP_ADJUSTMENT_TYPE.key = "SP_ADJUSTMENT_TYPE"; SP_ADJUSTMENT_TYPE.value = models.Select(x => x.SP_ADJUSTMENT_TYPE).Distinct().ToList();
            var SP_REVENUE_CODE_NAME = new QVDResponseModel(); SP_REVENUE_CODE_NAME.key = "SP_REVENUE_CODE_NAME"; SP_REVENUE_CODE_NAME.value = models.Select(x => x.SP_REVENUE_CODE_NAME).Distinct().ToList();
            var REVENUE_CODE_ID = new QVDResponseModel(); REVENUE_CODE_ID.key = "REVENUE_CODE_ID"; REVENUE_CODE_ID.value = models.Select(x => x.REVENUE_CODE_ID).Distinct().ToList();
            var REVENUE_CODE_NAME = new QVDResponseModel(); REVENUE_CODE_NAME.key = "REVENUE_CODE_NAME"; REVENUE_CODE_NAME.value = models.Select(x => x.REVENUE_CODE_NAME).Distinct().ToList();
            var EVENT_TYPE = new QVDResponseModel(); EVENT_TYPE.key = "EVENT_TYPE"; EVENT_TYPE.value = models.Select(x => x.EVENT_TYPE).Distinct().ToList();
            var USAGE_TYPE = new QVDResponseModel(); USAGE_TYPE.key = "USAGE_TYPE"; USAGE_TYPE.value = models.Select(x => x.USAGE_TYPE).Distinct().ToList();
            var USAGE_TYPE_DESC = new QVDResponseModel(); USAGE_TYPE_DESC.key = "USAGE_TYPE_DESC"; USAGE_TYPE_DESC.value = models.Select(x => x.USAGE_TYPE_DESC).Distinct().ToList();
            var IRB_PRICE_PLAN = new QVDResponseModel(); IRB_PRICE_PLAN.key = "IRB_PRICE_PLAN"; IRB_PRICE_PLAN.value = models.Select(x => x.IRB_PRICE_PLAN).Distinct().ToList();
            var CALL_CATEGORY = new QVDResponseModel(); CALL_CATEGORY.key = "CALL_CATEGORY"; CALL_CATEGORY.value = models.Select(x => x.CALL_CATEGORY).Distinct().ToList();
            var DESTINATION = new QVDResponseModel(); DESTINATION.key = "DESTINATION"; DESTINATION.value = models.Select(x => x.DESTINATION).Distinct().ToList();
            var VPLMN = new QVDResponseModel(); VPLMN.key = "VPLMN"; VPLMN.value = models.Select(x => x.VPLMN).Distinct().ToList();
            var PRODUCT_NAME = new QVDResponseModel(); PRODUCT_NAME.key = "PRODUCT_NAME"; PRODUCT_NAME.value = models.Select(x => x.PRODUCT_NAME).Distinct().ToList();
            var CHARGE_TYPE = new QVDResponseModel(); CHARGE_TYPE.key = "CHARGE_TYPE"; CHARGE_TYPE.value = models.Select(x => x.CHARGE_TYPE).Distinct().ToList();


            if (BATCH_ID.value.Count < 10000) responseModels.Add(BATCH_ID);
            if (DATA_FIELD.value.Count < 10000) responseModels.Add(DATA_FIELD);
            if (REVENUE_MNY.value.Count < 10000) responseModels.Add(REVENUE_MNY);
            if (BILL_CYCLE.value.Count < 10000) responseModels.Add(BILL_CYCLE);
            if (CUSTOMER_TYPE.value.Count < 10000) responseModels.Add(CUSTOMER_TYPE);
            if (CUSTOMER_SUBTYPE.value.Count < 10000) responseModels.Add(CUSTOMER_SUBTYPE);
            if (INDUSTRY_TYPE.value.Count < 10000) responseModels.Add(INDUSTRY_TYPE);
            if (ADJUSTMENT_NAME.value.Count < 10000) responseModels.Add(ADJUSTMENT_NAME);
            if (DISCOUNT_NAME.value.Count < 10000) responseModels.Add(DISCOUNT_NAME);
            if (DISCOUNT_TYPE.value.Count < 10000) responseModels.Add(DISCOUNT_TYPE);
            if (DISCOUNT_CLASS.value.Count < 10000) responseModels.Add(DISCOUNT_CLASS);
            if (PERIOD.value.Count < 10000) responseModels.Add(PERIOD);
            if (CREATION_DATE.value.Count < 10000) responseModels.Add(CREATION_DATE);
            if (STC_SHARE.value.Count < 10000) responseModels.Add(STC_SHARE);
            if (REV_SHARE_FLAG.value.Count < 10000) responseModels.Add(REV_SHARE_FLAG);
            if (BILL_DATE.value.Count < 10000) responseModels.Add(BILL_DATE);
            if (BATCH_REC_SEQ.value.Count < 10000) responseModels.Add(BATCH_REC_SEQ);
            if (CUSTOMER_SEGMENT.value.Count < 10000) responseModels.Add(CUSTOMER_SEGMENT);
            if (CUSTOMER_VALUE.value.Count < 10000) responseModels.Add(CUSTOMER_VALUE);
            if (RELATED_PARTY.value.Count < 10000) responseModels.Add(RELATED_PARTY);
            if (INDUSTRY_NAME.value.Count < 10000) responseModels.Add(INDUSTRY_NAME);
            if (SERVICE_CODE.value.Count < 10000) responseModels.Add(SERVICE_CODE);
            if (ADJUSTMENT_TYPE.value.Count < 10000) responseModels.Add(ADJUSTMENT_TYPE);
            if (SP_ACCOUNT_NUM.value.Count < 10000) responseModels.Add(SP_ACCOUNT_NUM);
            if (TAX_CODE.value.Count < 10000) responseModels.Add(TAX_CODE);
            if (INVOICE_NUMBER.value.Count < 10000) responseModels.Add(INVOICE_NUMBER);
            if (ACCOUNT_NUM.value.Count < 10000) responseModels.Add(ACCOUNT_NUM);
            if (INVOICE_NUMBER_ID.value.Count < 10000) responseModels.Add(INVOICE_NUMBER_ID);
            if (TAX_RATE.value.Count < 10000) responseModels.Add(TAX_RATE);
            if (INVOICE_REVENUE_AMOUNT.value.Count < 10000) responseModels.Add(INVOICE_REVENUE_AMOUNT);
            if (INVOICE_VAT_AMOUNT.value.Count < 10000) responseModels.Add(INVOICE_VAT_AMOUNT);
            if (SUMMARY_ID_FOREIGN_KEY.value.Count < 10000) responseModels.Add(SUMMARY_ID_FOREIGN_KEY);
            // if (% KEY.value.Count < 10000) responseModels.Add(keyP);
            if (SOURCE.value.Count < 10000) responseModels.Add(SOURCE);
            if (REVERSAL_FLAG.value.Count < 10000) responseModels.Add(REVERSAL_FLAG);
            if (QUANTITY.value.Count < 10000) responseModels.Add(QUANTITY);
            if (JURISDICTION.value.Count < 10000) responseModels.Add(JURISDICTION);
            if (PEAK_OFF_PEAK_FLAG.value.Count < 10000) responseModels.Add(PEAK_OFF_PEAK_FLAG);
            if (SERVICE_TYPE.value.Count < 10000) responseModels.Add(SERVICE_TYPE);
            if (PRODUCT_ID.value.Count < 10000) responseModels.Add(PRODUCT_ID);
            if (DISC_USAGE_TYPE.value.Count < 10000) responseModels.Add(DISC_USAGE_TYPE);
            if (DISTRICT.value.Count < 10000) responseModels.Add(DISTRICT);
            if (GL_REV_CODE_NAME.value.Count < 10000) responseModels.Add(GL_REV_CODE_NAME);
            if (ABC_REV_CODE_NAME.value.Count < 10000) responseModels.Add(ABC_REV_CODE_NAME);
            if (SP_NAME.value.Count < 10000) responseModels.Add(SP_NAME);
            if (SP_PERCENTAGE.value.Count < 10000) responseModels.Add(SP_PERCENTAGE);
            if (SP_ADJUSTMENT_TYPE.value.Count < 10000) responseModels.Add(SP_ADJUSTMENT_TYPE);
            if (SP_REVENUE_CODE_NAME.value.Count < 10000) responseModels.Add(SP_REVENUE_CODE_NAME);
            if (REVENUE_CODE_ID.value.Count < 10000) responseModels.Add(REVENUE_CODE_ID);
            if (REVENUE_CODE_NAME.value.Count < 10000) responseModels.Add(REVENUE_CODE_NAME);
            if (EVENT_TYPE.value.Count < 10000) responseModels.Add(EVENT_TYPE);
            if (USAGE_TYPE.value.Count < 10000) responseModels.Add(USAGE_TYPE);
            if (USAGE_TYPE_DESC.value.Count < 10000) responseModels.Add(USAGE_TYPE_DESC);
            if (IRB_PRICE_PLAN.value.Count < 10000) responseModels.Add(IRB_PRICE_PLAN);
            if (CALL_CATEGORY.value.Count < 10000) responseModels.Add(CALL_CATEGORY);
            if (DESTINATION.value.Count < 10000) responseModels.Add(DESTINATION);
            if (VPLMN.value.Count < 10000) responseModels.Add(VPLMN);
            if (PRODUCT_NAME.value.Count < 10000) responseModels.Add(PRODUCT_NAME);
            if (CHARGE_TYPE.value.Count < 10000) responseModels.Add(CHARGE_TYPE);


            return Ok(responseModels);
        }


        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetB2BSummaryReport()
        {
            QvdReader qvdReader = new QvdReader(_IConfiguration.GetSection("QVDPath:B2CReportParam").Value);
            var models = new List<B2BSummaryReportModel>();
            var responseModels = new List<QVDResponseModel>();

            while (qvdReader.NextRow())
            {
                var model = new B2BSummaryReportModel();

                #region PropertyBinding
                model.BATCH_ID = qvdReader["BATCH_ID"].ToString();
                model.DATA_FIELD = qvdReader["DATA_FIELD"].ToString();
                model.REVENUE_MNY = qvdReader["REVENUE_MNY"].ToString();
                model.REVERSAL_FLAG = qvdReader["REVERSAL_FLAG"].ToString();
                model.QUANTITY = qvdReader["QUANTITY"].ToString();
                model.JURISDICTION = qvdReader["JURISDICTION"].ToString();
                model.PEAK_OFF_PEAK_FLAG = qvdReader["PEAK_OFF_PEAK_FLAG"].ToString();
                model.SERVICE_TYPE = qvdReader["SERVICE_TYPE"].ToString();
                model.PRODUCT_ID = qvdReader["PRODUCT_ID"].ToString();
                model.DISC_USAGE_TYPE = qvdReader["DISC_USAGE_TYPE"].ToString();
                model.BILL_CYCLE = qvdReader["BILL_CYCLE"].ToString();
                model.DISTRICT = qvdReader["DISTRICT"].ToString();
                model.CUSTOMER_TYPE = qvdReader["CUSTOMER_TYPE"].ToString();
                model.CUSTOMER_SUBTYPE = qvdReader["CUSTOMER_SUBTYPE"].ToString();
                model.INDUSTRY_TYPE = qvdReader["INDUSTRY_TYPE"].ToString();
                model.INDUSTRY_NAME = qvdReader["INDUSTRY_NAME"].ToString();
                model.GL_REV_CODE_NAME = qvdReader["GL_REV_CODE_NAME"].ToString();
                model.ABC_REV_CODE_NAME = qvdReader["ABC_REV_CODE_NAME"].ToString();
                model.SP_NAME = qvdReader["SP_NAME"].ToString();
                model.SP_PERCENTAGE = qvdReader["SP_PERCENTAGE"].ToString();
                model.SP_ADJUSTMENT_TYPE = qvdReader["SP_ADJUSTMENT_TYPE"].ToString();
                model.SP_REVENUE_CODE_NAME = qvdReader["SP_REVENUE_CODE_NAME"].ToString();
                model.REVENUE_CODE_ID = qvdReader["REVENUE_CODE_ID"].ToString();
                model.REVENUE_CODE_NAME = qvdReader["REVENUE_CODE_NAME"].ToString();
                model.SERVICE_CODE = qvdReader["SERVICE_CODE"].ToString();
                model.EVENT_TYPE = qvdReader["EVENT_TYPE"].ToString();
                model.USAGE_TYPE = qvdReader["USAGE_TYPE"].ToString();
                model.USAGE_TYPE_DESC = qvdReader["USAGE_TYPE_DESC"].ToString();
                model.IRB_PRICE_PLAN = qvdReader["IRB_PRICE_PLAN"].ToString();
                model.CALL_CATEGORY = qvdReader["CALL_CATEGORY"].ToString();
                model.DESTINATION = qvdReader["DESTINATION"].ToString();
                model.VPLMN = qvdReader["VPLMN"].ToString();
                model.PRODUCT_NAME = qvdReader["PRODUCT_NAME"].ToString();
                model.CHARGE_TYPE = qvdReader["CHARGE_TYPE"].ToString();
                model.ADJUSTMENT_TYPE = qvdReader["ADJUSTMENT_TYPE"].ToString();
                model.ADJUSTMENT_NAME = qvdReader["ADJUSTMENT_NAME"].ToString();
                model.DISCOUNT_NAME = qvdReader["DISCOUNT_NAME"].ToString();
                model.DISCOUNT_TYPE = qvdReader["DISCOUNT_TYPE"].ToString();
                model.DISCOUNT_CLASS = qvdReader["DISCOUNT_CLASS"].ToString();
                model.PERIOD = qvdReader["PERIOD"].ToString();
                model.CREATION_DATE = qvdReader["CREATION_DATE"].ToString();
                model.STC_SHARE = qvdReader["STC_SHARE"].ToString();
                model.SP_ACCOUNT_NUM = qvdReader["SP_ACCOUNT_NUM"].ToString();
                model.REV_SHARE_FLAG = qvdReader["REV_SHARE_FLAG"].ToString();
                model.BILL_DATE = qvdReader["BILL_DATE"].ToString();
                model.BATCH_REC_SEQ = qvdReader["BATCH_REC_SEQ"].ToString();
                model.CUSTOMER_SEGMENT = qvdReader["CUSTOMER_SEGMENT"].ToString();
                model.CUSTOMER_VALUE = qvdReader["CUSTOMER_VALUE"].ToString();
                model.RELATED_PARTY = qvdReader["RELATED_PARTY"].ToString();
                model.SOURCE_SYSTEM = qvdReader["SOURCE_SYSTEM"].ToString();
                model.ORG_CUSTOMER_SEGMENT = qvdReader["ORG_CUSTOMER_SEGMENT"].ToString();
                model.FILE_NAME = qvdReader["FILE_NAME"].ToString();
                model.XCREATION_DATE = qvdReader["XCREATION_DATE"].ToString();
                model.CREATED_BY = qvdReader["CREATED_BY"].ToString();
                model.LAST_UPDATED_DATE = qvdReader["LAST_UPDATED_DATE"].ToString();
                model.LAST_UPDATED_BY = qvdReader["LAST_UPDATED_BY"].ToString();
                model.LAST_UPDATED_LOGIN = qvdReader["LAST_UPDATED_LOGIN"].ToString();
                model.STATUS = qvdReader["STATUS"].ToString();
                model.CEXCEPTION = qvdReader["CEXCEPTION"].ToString();

                models.Add(model);

                #endregion

            }


            #region Distinct Details

            var BATCH_ID = new QVDResponseModel(); BATCH_ID.key = "BATCH_ID"; BATCH_ID.value = models.Select(x => x.BATCH_ID).Distinct().ToList();
            var DATA_FIELD = new QVDResponseModel(); DATA_FIELD.key = "DATA_FIELD"; DATA_FIELD.value = models.Select(x => x.DATA_FIELD).Distinct().ToList();
            var REVENUE_MNY = new QVDResponseModel(); REVENUE_MNY.key = "REVENUE_MNY"; REVENUE_MNY.value = models.Select(x => x.REVENUE_MNY).Distinct().ToList();
            var REVERSAL_FLAG = new QVDResponseModel(); REVERSAL_FLAG.key = "REVERSAL_FLAG"; REVERSAL_FLAG.value = models.Select(x => x.REVERSAL_FLAG).Distinct().ToList();
            var QUANTITY = new QVDResponseModel(); QUANTITY.key = "QUANTITY"; QUANTITY.value = models.Select(x => x.QUANTITY).Distinct().ToList();
            var JURISDICTION = new QVDResponseModel(); JURISDICTION.key = "JURISDICTION"; JURISDICTION.value = models.Select(x => x.JURISDICTION).Distinct().ToList();
            var PEAK_OFF_PEAK_FLAG = new QVDResponseModel(); PEAK_OFF_PEAK_FLAG.key = "PEAK_OFF_PEAK_FLAG"; PEAK_OFF_PEAK_FLAG.value = models.Select(x => x.PEAK_OFF_PEAK_FLAG).Distinct().ToList();
            var SERVICE_TYPE = new QVDResponseModel(); SERVICE_TYPE.key = "SERVICE_TYPE"; SERVICE_TYPE.value = models.Select(x => x.SERVICE_TYPE).Distinct().ToList();
            var PRODUCT_ID = new QVDResponseModel(); PRODUCT_ID.key = "PRODUCT_ID"; PRODUCT_ID.value = models.Select(x => x.PRODUCT_ID).Distinct().ToList();
            var DISC_USAGE_TYPE = new QVDResponseModel(); DISC_USAGE_TYPE.key = "DISC_USAGE_TYPE"; DISC_USAGE_TYPE.value = models.Select(x => x.DISC_USAGE_TYPE).Distinct().ToList();
            var BILL_CYCLE = new QVDResponseModel(); BILL_CYCLE.key = "BILL_CYCLE"; BILL_CYCLE.value = models.Select(x => x.BILL_CYCLE).Distinct().ToList();
            var DISTRICT = new QVDResponseModel(); DISTRICT.key = "DISTRICT"; DISTRICT.value = models.Select(x => x.DISTRICT).Distinct().ToList();
            var CUSTOMER_TYPE = new QVDResponseModel(); CUSTOMER_TYPE.key = "CUSTOMER_TYPE"; CUSTOMER_TYPE.value = models.Select(x => x.CUSTOMER_TYPE).Distinct().ToList();
            var CUSTOMER_SUBTYPE = new QVDResponseModel(); CUSTOMER_SUBTYPE.key = "CUSTOMER_SUBTYPE"; CUSTOMER_SUBTYPE.value = models.Select(x => x.CUSTOMER_SUBTYPE).Distinct().ToList();
            var INDUSTRY_TYPE = new QVDResponseModel(); INDUSTRY_TYPE.key = "INDUSTRY_TYPE"; INDUSTRY_TYPE.value = models.Select(x => x.INDUSTRY_TYPE).Distinct().ToList();
            var INDUSTRY_NAME = new QVDResponseModel(); INDUSTRY_NAME.key = "INDUSTRY_NAME"; INDUSTRY_NAME.value = models.Select(x => x.INDUSTRY_NAME).Distinct().ToList();
            var GL_REV_CODE_NAME = new QVDResponseModel(); GL_REV_CODE_NAME.key = "GL_REV_CODE_NAME"; GL_REV_CODE_NAME.value = models.Select(x => x.GL_REV_CODE_NAME).Distinct().ToList();
            var ABC_REV_CODE_NAME = new QVDResponseModel(); ABC_REV_CODE_NAME.key = "ABC_REV_CODE_NAME"; ABC_REV_CODE_NAME.value = models.Select(x => x.ABC_REV_CODE_NAME).Distinct().ToList();
            var SP_NAME = new QVDResponseModel(); SP_NAME.key = "SP_NAME"; SP_NAME.value = models.Select(x => x.SP_NAME).Distinct().ToList();
            var SP_PERCENTAGE = new QVDResponseModel(); SP_PERCENTAGE.key = "SP_PERCENTAGE"; SP_PERCENTAGE.value = models.Select(x => x.SP_PERCENTAGE).Distinct().ToList();
            var SP_ADJUSTMENT_TYPE = new QVDResponseModel(); SP_ADJUSTMENT_TYPE.key = "SP_ADJUSTMENT_TYPE"; SP_ADJUSTMENT_TYPE.value = models.Select(x => x.SP_ADJUSTMENT_TYPE).Distinct().ToList();
            var SP_REVENUE_CODE_NAME = new QVDResponseModel(); SP_REVENUE_CODE_NAME.key = "SP_REVENUE_CODE_NAME"; SP_REVENUE_CODE_NAME.value = models.Select(x => x.SP_REVENUE_CODE_NAME).Distinct().ToList();
            var REVENUE_CODE_ID = new QVDResponseModel(); REVENUE_CODE_ID.key = "REVENUE_CODE_ID"; REVENUE_CODE_ID.value = models.Select(x => x.REVENUE_CODE_ID).Distinct().ToList();
            var REVENUE_CODE_NAME = new QVDResponseModel(); REVENUE_CODE_NAME.key = "REVENUE_CODE_NAME"; REVENUE_CODE_NAME.value = models.Select(x => x.REVENUE_CODE_NAME).Distinct().ToList();
            var SERVICE_CODE = new QVDResponseModel(); SERVICE_CODE.key = "SERVICE_CODE"; SERVICE_CODE.value = models.Select(x => x.SERVICE_CODE).Distinct().ToList();
            var EVENT_TYPE = new QVDResponseModel(); EVENT_TYPE.key = "EVENT_TYPE"; EVENT_TYPE.value = models.Select(x => x.EVENT_TYPE).Distinct().ToList();
            var USAGE_TYPE = new QVDResponseModel(); USAGE_TYPE.key = "USAGE_TYPE"; USAGE_TYPE.value = models.Select(x => x.USAGE_TYPE).Distinct().ToList();
            var USAGE_TYPE_DESC = new QVDResponseModel(); USAGE_TYPE_DESC.key = "USAGE_TYPE_DESC"; USAGE_TYPE_DESC.value = models.Select(x => x.USAGE_TYPE_DESC).Distinct().ToList();
            var IRB_PRICE_PLAN = new QVDResponseModel(); IRB_PRICE_PLAN.key = "IRB_PRICE_PLAN"; IRB_PRICE_PLAN.value = models.Select(x => x.IRB_PRICE_PLAN).Distinct().ToList();
            var CALL_CATEGORY = new QVDResponseModel(); CALL_CATEGORY.key = "CALL_CATEGORY"; CALL_CATEGORY.value = models.Select(x => x.CALL_CATEGORY).Distinct().ToList();
            var DESTINATION = new QVDResponseModel(); DESTINATION.key = "DESTINATION"; DESTINATION.value = models.Select(x => x.DESTINATION).Distinct().ToList();
            var VPLMN = new QVDResponseModel(); VPLMN.key = "VPLMN"; VPLMN.value = models.Select(x => x.VPLMN).Distinct().ToList();
            var PRODUCT_NAME = new QVDResponseModel(); PRODUCT_NAME.key = "PRODUCT_NAME"; PRODUCT_NAME.value = models.Select(x => x.PRODUCT_NAME).Distinct().ToList();
            var CHARGE_TYPE = new QVDResponseModel(); CHARGE_TYPE.key = "CHARGE_TYPE"; CHARGE_TYPE.value = models.Select(x => x.CHARGE_TYPE).Distinct().ToList();
            var ADJUSTMENT_TYPE = new QVDResponseModel(); ADJUSTMENT_TYPE.key = "ADJUSTMENT_TYPE"; ADJUSTMENT_TYPE.value = models.Select(x => x.ADJUSTMENT_TYPE).Distinct().ToList();
            var ADJUSTMENT_NAME = new QVDResponseModel(); ADJUSTMENT_NAME.key = "ADJUSTMENT_NAME"; ADJUSTMENT_NAME.value = models.Select(x => x.ADJUSTMENT_NAME).Distinct().ToList();
            var DISCOUNT_NAME = new QVDResponseModel(); DISCOUNT_NAME.key = "DISCOUNT_NAME"; DISCOUNT_NAME.value = models.Select(x => x.DISCOUNT_NAME).Distinct().ToList();
            var DISCOUNT_TYPE = new QVDResponseModel(); DISCOUNT_TYPE.key = "DISCOUNT_TYPE"; DISCOUNT_TYPE.value = models.Select(x => x.DISCOUNT_TYPE).Distinct().ToList();
            var DISCOUNT_CLASS = new QVDResponseModel(); DISCOUNT_CLASS.key = "DISCOUNT_CLASS"; DISCOUNT_CLASS.value = models.Select(x => x.DISCOUNT_CLASS).Distinct().ToList();
            var PERIOD = new QVDResponseModel(); PERIOD.key = "PERIOD"; PERIOD.value = models.Select(x => x.PERIOD).Distinct().ToList();
            var CREATION_DATE = new QVDResponseModel(); CREATION_DATE.key = "CREATION_DATE"; CREATION_DATE.value = models.Select(x => x.CREATION_DATE).Distinct().ToList();
            var STC_SHARE = new QVDResponseModel(); STC_SHARE.key = "STC_SHARE"; STC_SHARE.value = models.Select(x => x.STC_SHARE).Distinct().ToList();
            var SP_ACCOUNT_NUM = new QVDResponseModel(); SP_ACCOUNT_NUM.key = "SP_ACCOUNT_NUM"; SP_ACCOUNT_NUM.value = models.Select(x => x.SP_ACCOUNT_NUM).Distinct().ToList();
            var REV_SHARE_FLAG = new QVDResponseModel(); REV_SHARE_FLAG.key = "REV_SHARE_FLAG"; REV_SHARE_FLAG.value = models.Select(x => x.REV_SHARE_FLAG).Distinct().ToList();
            var BILL_DATE = new QVDResponseModel(); BILL_DATE.key = "BILL_DATE"; BILL_DATE.value = models.Select(x => x.BILL_DATE).Distinct().ToList();
            var BATCH_REC_SEQ = new QVDResponseModel(); BATCH_REC_SEQ.key = "BATCH_REC_SEQ"; BATCH_REC_SEQ.value = models.Select(x => x.BATCH_REC_SEQ).Distinct().ToList();
            var CUSTOMER_SEGMENT = new QVDResponseModel(); CUSTOMER_SEGMENT.key = "CUSTOMER_SEGMENT"; CUSTOMER_SEGMENT.value = models.Select(x => x.CUSTOMER_SEGMENT).Distinct().ToList();
            var CUSTOMER_VALUE = new QVDResponseModel(); CUSTOMER_VALUE.key = "CUSTOMER_VALUE"; CUSTOMER_VALUE.value = models.Select(x => x.CUSTOMER_VALUE).Distinct().ToList();
            var RELATED_PARTY = new QVDResponseModel(); RELATED_PARTY.key = "RELATED_PARTY"; RELATED_PARTY.value = models.Select(x => x.RELATED_PARTY).Distinct().ToList();
            var SOURCE_SYSTEM = new QVDResponseModel(); SOURCE_SYSTEM.key = "SOURCE_SYSTEM"; SOURCE_SYSTEM.value = models.Select(x => x.SOURCE_SYSTEM).Distinct().ToList();
            var ORG_CUSTOMER_SEGMENT = new QVDResponseModel(); ORG_CUSTOMER_SEGMENT.key = "ORG_CUSTOMER_SEGMENT"; ORG_CUSTOMER_SEGMENT.value = models.Select(x => x.ORG_CUSTOMER_SEGMENT).Distinct().ToList();
            var FILE_NAME = new QVDResponseModel(); FILE_NAME.key = "FILE_NAME"; FILE_NAME.value = models.Select(x => x.FILE_NAME).Distinct().ToList();
            var XCREATION_DATE = new QVDResponseModel(); XCREATION_DATE.key = "XCREATION_DATE"; XCREATION_DATE.value = models.Select(x => x.XCREATION_DATE).Distinct().ToList();
            var CREATED_BY = new QVDResponseModel(); CREATED_BY.key = "CREATED_BY"; CREATED_BY.value = models.Select(x => x.CREATED_BY).Distinct().ToList();
            var LAST_UPDATED_DATE = new QVDResponseModel(); LAST_UPDATED_DATE.key = "LAST_UPDATED_DATE"; LAST_UPDATED_DATE.value = models.Select(x => x.LAST_UPDATED_DATE).Distinct().ToList();
            var LAST_UPDATED_BY = new QVDResponseModel(); LAST_UPDATED_BY.key = "LAST_UPDATED_BY"; LAST_UPDATED_BY.value = models.Select(x => x.LAST_UPDATED_BY).Distinct().ToList();
            var LAST_UPDATED_LOGIN = new QVDResponseModel(); LAST_UPDATED_LOGIN.key = "LAST_UPDATED_LOGIN"; LAST_UPDATED_LOGIN.value = models.Select(x => x.LAST_UPDATED_LOGIN).Distinct().ToList();
            var STATUS = new QVDResponseModel(); STATUS.key = "STATUS"; STATUS.value = models.Select(x => x.STATUS).Distinct().ToList();
            var CEXCEPTION = new QVDResponseModel(); CEXCEPTION.key = "CEXCEPTION"; CEXCEPTION.value = models.Select(x => x.CEXCEPTION).Distinct().ToList();


            #endregion

            #region Filteration
            if (BATCH_ID.value.Count < 10000) responseModels.Add(BATCH_ID);
            if (DATA_FIELD.value.Count < 10000) responseModels.Add(DATA_FIELD);
            if (REVENUE_MNY.value.Count < 10000) responseModels.Add(REVENUE_MNY);
            if (REVERSAL_FLAG.value.Count < 10000) responseModels.Add(REVERSAL_FLAG);
            if (QUANTITY.value.Count < 10000) responseModels.Add(QUANTITY);
            if (JURISDICTION.value.Count < 10000) responseModels.Add(JURISDICTION);
            if (PEAK_OFF_PEAK_FLAG.value.Count < 10000) responseModels.Add(PEAK_OFF_PEAK_FLAG);
            if (SERVICE_TYPE.value.Count < 10000) responseModels.Add(SERVICE_TYPE);
            if (PRODUCT_ID.value.Count < 10000) responseModels.Add(PRODUCT_ID);
            if (DISC_USAGE_TYPE.value.Count < 10000) responseModels.Add(DISC_USAGE_TYPE);
            if (BILL_CYCLE.value.Count < 10000) responseModels.Add(BILL_CYCLE);
            if (DISTRICT.value.Count < 10000) responseModels.Add(DISTRICT);
            if (CUSTOMER_TYPE.value.Count < 10000) responseModels.Add(CUSTOMER_TYPE);
            if (CUSTOMER_SUBTYPE.value.Count < 10000) responseModels.Add(CUSTOMER_SUBTYPE);
            if (INDUSTRY_TYPE.value.Count < 10000) responseModels.Add(INDUSTRY_TYPE);
            if (INDUSTRY_NAME.value.Count < 10000) responseModels.Add(INDUSTRY_NAME);
            if (GL_REV_CODE_NAME.value.Count < 10000) responseModels.Add(GL_REV_CODE_NAME);
            if (ABC_REV_CODE_NAME.value.Count < 10000) responseModels.Add(ABC_REV_CODE_NAME);
            if (SP_NAME.value.Count < 10000) responseModels.Add(SP_NAME);
            if (SP_PERCENTAGE.value.Count < 10000) responseModels.Add(SP_PERCENTAGE);
            if (SP_ADJUSTMENT_TYPE.value.Count < 10000) responseModels.Add(SP_ADJUSTMENT_TYPE);
            if (SP_REVENUE_CODE_NAME.value.Count < 10000) responseModels.Add(SP_REVENUE_CODE_NAME);
            if (REVENUE_CODE_ID.value.Count < 10000) responseModels.Add(REVENUE_CODE_ID);
            if (REVENUE_CODE_NAME.value.Count < 10000) responseModels.Add(REVENUE_CODE_NAME);
            if (SERVICE_CODE.value.Count < 10000) responseModels.Add(SERVICE_CODE);
            if (EVENT_TYPE.value.Count < 10000) responseModels.Add(EVENT_TYPE);
            if (USAGE_TYPE.value.Count < 10000) responseModels.Add(USAGE_TYPE);
            if (USAGE_TYPE_DESC.value.Count < 10000) responseModels.Add(USAGE_TYPE_DESC);
            if (IRB_PRICE_PLAN.value.Count < 10000) responseModels.Add(IRB_PRICE_PLAN);
            if (CALL_CATEGORY.value.Count < 10000) responseModels.Add(CALL_CATEGORY);
            if (DESTINATION.value.Count < 10000) responseModels.Add(DESTINATION);
            if (VPLMN.value.Count < 10000) responseModels.Add(VPLMN);
            if (PRODUCT_NAME.value.Count < 10000) responseModels.Add(PRODUCT_NAME);
            if (CHARGE_TYPE.value.Count < 10000) responseModels.Add(CHARGE_TYPE);
            if (ADJUSTMENT_TYPE.value.Count < 10000) responseModels.Add(ADJUSTMENT_TYPE);
            if (ADJUSTMENT_NAME.value.Count < 10000) responseModels.Add(ADJUSTMENT_NAME);
            if (DISCOUNT_NAME.value.Count < 10000) responseModels.Add(DISCOUNT_NAME);
            if (DISCOUNT_TYPE.value.Count < 10000) responseModels.Add(DISCOUNT_TYPE);
            if (DISCOUNT_CLASS.value.Count < 10000) responseModels.Add(DISCOUNT_CLASS);
            if (PERIOD.value.Count < 10000) responseModels.Add(PERIOD);
            if (CREATION_DATE.value.Count < 10000) responseModels.Add(CREATION_DATE);
            if (STC_SHARE.value.Count < 10000) responseModels.Add(STC_SHARE);
            if (SP_ACCOUNT_NUM.value.Count < 10000) responseModels.Add(SP_ACCOUNT_NUM);
            if (REV_SHARE_FLAG.value.Count < 10000) responseModels.Add(REV_SHARE_FLAG);
            if (BILL_DATE.value.Count < 10000) responseModels.Add(BILL_DATE);
            if (BATCH_REC_SEQ.value.Count < 10000) responseModels.Add(BATCH_REC_SEQ);
            if (CUSTOMER_SEGMENT.value.Count < 10000) responseModels.Add(CUSTOMER_SEGMENT);
            if (CUSTOMER_VALUE.value.Count < 10000) responseModels.Add(CUSTOMER_VALUE);
            if (RELATED_PARTY.value.Count < 10000) responseModels.Add(RELATED_PARTY);
            if (SOURCE_SYSTEM.value.Count < 10000) responseModels.Add(SOURCE_SYSTEM);
            if (ORG_CUSTOMER_SEGMENT.value.Count < 10000) responseModels.Add(ORG_CUSTOMER_SEGMENT);
            if (FILE_NAME.value.Count < 10000) responseModels.Add(FILE_NAME);
            if (XCREATION_DATE.value.Count < 10000) responseModels.Add(XCREATION_DATE);
            if (CREATED_BY.value.Count < 10000) responseModels.Add(CREATED_BY);
            if (LAST_UPDATED_DATE.value.Count < 10000) responseModels.Add(LAST_UPDATED_DATE);
            if (LAST_UPDATED_BY.value.Count < 10000) responseModels.Add(LAST_UPDATED_BY);
            if (LAST_UPDATED_LOGIN.value.Count < 10000) responseModels.Add(LAST_UPDATED_LOGIN);
            if (STATUS.value.Count < 10000) responseModels.Add(STATUS);
            if (CEXCEPTION.value.Count < 10000) responseModels.Add(CEXCEPTION);
            #endregion

            return Ok(responseModels);
        }



        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetB2CSummaryReport()
        {
            QvdReader qvdReader = new QvdReader(_IConfiguration.GetSection("QVDPath:B2CReportParam").Value);
            var models = new List<B2BSummaryReportModel>();
            var responseModels = new List<QVDResponseModel>();

            while (qvdReader.NextRow())
            {
                var model = new B2BSummaryReportModel();

                #region PropertyBinding
                model.BATCH_ID = qvdReader["BATCH_ID"].ToString();
                model.DATA_FIELD = qvdReader["DATA_FIELD"].ToString();
                model.REVENUE_MNY = qvdReader["REVENUE_MNY"].ToString();
                model.REVERSAL_FLAG = qvdReader["REVERSAL_FLAG"].ToString();
                model.QUANTITY = qvdReader["QUANTITY"].ToString();
                model.JURISDICTION = qvdReader["JURISDICTION"].ToString();
                model.PEAK_OFF_PEAK_FLAG = qvdReader["PEAK_OFF_PEAK_FLAG"].ToString();
                model.SERVICE_TYPE = qvdReader["SERVICE_TYPE"].ToString();
                model.PRODUCT_ID = qvdReader["PRODUCT_ID"].ToString();
                model.DISC_USAGE_TYPE = qvdReader["DISC_USAGE_TYPE"].ToString();
                model.BILL_CYCLE = qvdReader["BILL_CYCLE"].ToString();
                model.DISTRICT = qvdReader["DISTRICT"].ToString();
                model.CUSTOMER_TYPE = qvdReader["CUSTOMER_TYPE"].ToString();
                model.CUSTOMER_SUBTYPE = qvdReader["CUSTOMER_SUBTYPE"].ToString();
                model.INDUSTRY_TYPE = qvdReader["INDUSTRY_TYPE"].ToString();
                model.INDUSTRY_NAME = qvdReader["INDUSTRY_NAME"].ToString();
                model.GL_REV_CODE_NAME = qvdReader["GL_REV_CODE_NAME"].ToString();
                model.ABC_REV_CODE_NAME = qvdReader["ABC_REV_CODE_NAME"].ToString();
                model.SP_NAME = qvdReader["SP_NAME"].ToString();
                model.SP_PERCENTAGE = qvdReader["SP_PERCENTAGE"].ToString();
                model.SP_ADJUSTMENT_TYPE = qvdReader["SP_ADJUSTMENT_TYPE"].ToString();
                model.SP_REVENUE_CODE_NAME = qvdReader["SP_REVENUE_CODE_NAME"].ToString();
                model.REVENUE_CODE_ID = qvdReader["REVENUE_CODE_ID"].ToString();
                model.REVENUE_CODE_NAME = qvdReader["REVENUE_CODE_NAME"].ToString();
                model.SERVICE_CODE = qvdReader["SERVICE_CODE"].ToString();
                model.EVENT_TYPE = qvdReader["EVENT_TYPE"].ToString();
                model.USAGE_TYPE = qvdReader["USAGE_TYPE"].ToString();
                model.USAGE_TYPE_DESC = qvdReader["USAGE_TYPE_DESC"].ToString();
                model.IRB_PRICE_PLAN = qvdReader["IRB_PRICE_PLAN"].ToString();
                model.CALL_CATEGORY = qvdReader["CALL_CATEGORY"].ToString();
                model.DESTINATION = qvdReader["DESTINATION"].ToString();
                model.VPLMN = qvdReader["VPLMN"].ToString();
                model.PRODUCT_NAME = qvdReader["PRODUCT_NAME"].ToString();
                model.CHARGE_TYPE = qvdReader["CHARGE_TYPE"].ToString();
                model.ADJUSTMENT_TYPE = qvdReader["ADJUSTMENT_TYPE"].ToString();
                model.ADJUSTMENT_NAME = qvdReader["ADJUSTMENT_NAME"].ToString();
                model.DISCOUNT_NAME = qvdReader["DISCOUNT_NAME"].ToString();
                model.DISCOUNT_TYPE = qvdReader["DISCOUNT_TYPE"].ToString();
                model.DISCOUNT_CLASS = qvdReader["DISCOUNT_CLASS"].ToString();
                model.PERIOD = qvdReader["PERIOD"].ToString();
                model.CREATION_DATE = qvdReader["CREATION_DATE"].ToString();
                model.STC_SHARE = qvdReader["STC_SHARE"].ToString();
                model.SP_ACCOUNT_NUM = qvdReader["SP_ACCOUNT_NUM"].ToString();
                model.REV_SHARE_FLAG = qvdReader["REV_SHARE_FLAG"].ToString();
                model.BILL_DATE = qvdReader["BILL_DATE"].ToString();
                model.BATCH_REC_SEQ = qvdReader["BATCH_REC_SEQ"].ToString();
                model.CUSTOMER_SEGMENT = qvdReader["CUSTOMER_SEGMENT"].ToString();
                model.CUSTOMER_VALUE = qvdReader["CUSTOMER_VALUE"].ToString();
                model.RELATED_PARTY = qvdReader["RELATED_PARTY"].ToString();
                model.SOURCE_SYSTEM = qvdReader["SOURCE_SYSTEM"].ToString();
                model.ORG_CUSTOMER_SEGMENT = qvdReader["ORG_CUSTOMER_SEGMENT"].ToString();
                model.FILE_NAME = qvdReader["FILE_NAME"].ToString();
                model.XCREATION_DATE = qvdReader["XCREATION_DATE"].ToString();
                model.CREATED_BY = qvdReader["CREATED_BY"].ToString();
                model.LAST_UPDATED_DATE = qvdReader["LAST_UPDATED_DATE"].ToString();
                model.LAST_UPDATED_BY = qvdReader["LAST_UPDATED_BY"].ToString();
                model.LAST_UPDATED_LOGIN = qvdReader["LAST_UPDATED_LOGIN"].ToString();
                model.STATUS = qvdReader["STATUS"].ToString();
                model.CEXCEPTION = qvdReader["CEXCEPTION"].ToString();

                models.Add(model);

                #endregion

            }


            #region Distinct Details

            var BATCH_ID = new QVDResponseModel(); BATCH_ID.key = "BATCH_ID"; BATCH_ID.value = models.Select(x => x.BATCH_ID).Distinct().ToList();
            var DATA_FIELD = new QVDResponseModel(); DATA_FIELD.key = "DATA_FIELD"; DATA_FIELD.value = models.Select(x => x.DATA_FIELD).Distinct().ToList();
            var REVENUE_MNY = new QVDResponseModel(); REVENUE_MNY.key = "REVENUE_MNY"; REVENUE_MNY.value = models.Select(x => x.REVENUE_MNY).Distinct().ToList();
            var REVERSAL_FLAG = new QVDResponseModel(); REVERSAL_FLAG.key = "REVERSAL_FLAG"; REVERSAL_FLAG.value = models.Select(x => x.REVERSAL_FLAG).Distinct().ToList();
            var QUANTITY = new QVDResponseModel(); QUANTITY.key = "QUANTITY"; QUANTITY.value = models.Select(x => x.QUANTITY).Distinct().ToList();
            var JURISDICTION = new QVDResponseModel(); JURISDICTION.key = "JURISDICTION"; JURISDICTION.value = models.Select(x => x.JURISDICTION).Distinct().ToList();
            var PEAK_OFF_PEAK_FLAG = new QVDResponseModel(); PEAK_OFF_PEAK_FLAG.key = "PEAK_OFF_PEAK_FLAG"; PEAK_OFF_PEAK_FLAG.value = models.Select(x => x.PEAK_OFF_PEAK_FLAG).Distinct().ToList();
            var SERVICE_TYPE = new QVDResponseModel(); SERVICE_TYPE.key = "SERVICE_TYPE"; SERVICE_TYPE.value = models.Select(x => x.SERVICE_TYPE).Distinct().ToList();
            var PRODUCT_ID = new QVDResponseModel(); PRODUCT_ID.key = "PRODUCT_ID"; PRODUCT_ID.value = models.Select(x => x.PRODUCT_ID).Distinct().ToList();
            var DISC_USAGE_TYPE = new QVDResponseModel(); DISC_USAGE_TYPE.key = "DISC_USAGE_TYPE"; DISC_USAGE_TYPE.value = models.Select(x => x.DISC_USAGE_TYPE).Distinct().ToList();
            var BILL_CYCLE = new QVDResponseModel(); BILL_CYCLE.key = "BILL_CYCLE"; BILL_CYCLE.value = models.Select(x => x.BILL_CYCLE).Distinct().ToList();
            var DISTRICT = new QVDResponseModel(); DISTRICT.key = "DISTRICT"; DISTRICT.value = models.Select(x => x.DISTRICT).Distinct().ToList();
            var CUSTOMER_TYPE = new QVDResponseModel(); CUSTOMER_TYPE.key = "CUSTOMER_TYPE"; CUSTOMER_TYPE.value = models.Select(x => x.CUSTOMER_TYPE).Distinct().ToList();
            var CUSTOMER_SUBTYPE = new QVDResponseModel(); CUSTOMER_SUBTYPE.key = "CUSTOMER_SUBTYPE"; CUSTOMER_SUBTYPE.value = models.Select(x => x.CUSTOMER_SUBTYPE).Distinct().ToList();
            var INDUSTRY_TYPE = new QVDResponseModel(); INDUSTRY_TYPE.key = "INDUSTRY_TYPE"; INDUSTRY_TYPE.value = models.Select(x => x.INDUSTRY_TYPE).Distinct().ToList();
            var INDUSTRY_NAME = new QVDResponseModel(); INDUSTRY_NAME.key = "INDUSTRY_NAME"; INDUSTRY_NAME.value = models.Select(x => x.INDUSTRY_NAME).Distinct().ToList();
            var GL_REV_CODE_NAME = new QVDResponseModel(); GL_REV_CODE_NAME.key = "GL_REV_CODE_NAME"; GL_REV_CODE_NAME.value = models.Select(x => x.GL_REV_CODE_NAME).Distinct().ToList();
            var ABC_REV_CODE_NAME = new QVDResponseModel(); ABC_REV_CODE_NAME.key = "ABC_REV_CODE_NAME"; ABC_REV_CODE_NAME.value = models.Select(x => x.ABC_REV_CODE_NAME).Distinct().ToList();
            var SP_NAME = new QVDResponseModel(); SP_NAME.key = "SP_NAME"; SP_NAME.value = models.Select(x => x.SP_NAME).Distinct().ToList();
            var SP_PERCENTAGE = new QVDResponseModel(); SP_PERCENTAGE.key = "SP_PERCENTAGE"; SP_PERCENTAGE.value = models.Select(x => x.SP_PERCENTAGE).Distinct().ToList();
            var SP_ADJUSTMENT_TYPE = new QVDResponseModel(); SP_ADJUSTMENT_TYPE.key = "SP_ADJUSTMENT_TYPE"; SP_ADJUSTMENT_TYPE.value = models.Select(x => x.SP_ADJUSTMENT_TYPE).Distinct().ToList();
            var SP_REVENUE_CODE_NAME = new QVDResponseModel(); SP_REVENUE_CODE_NAME.key = "SP_REVENUE_CODE_NAME"; SP_REVENUE_CODE_NAME.value = models.Select(x => x.SP_REVENUE_CODE_NAME).Distinct().ToList();
            var REVENUE_CODE_ID = new QVDResponseModel(); REVENUE_CODE_ID.key = "REVENUE_CODE_ID"; REVENUE_CODE_ID.value = models.Select(x => x.REVENUE_CODE_ID).Distinct().ToList();
            var REVENUE_CODE_NAME = new QVDResponseModel(); REVENUE_CODE_NAME.key = "REVENUE_CODE_NAME"; REVENUE_CODE_NAME.value = models.Select(x => x.REVENUE_CODE_NAME).Distinct().ToList();
            var SERVICE_CODE = new QVDResponseModel(); SERVICE_CODE.key = "SERVICE_CODE"; SERVICE_CODE.value = models.Select(x => x.SERVICE_CODE).Distinct().ToList();
            var EVENT_TYPE = new QVDResponseModel(); EVENT_TYPE.key = "EVENT_TYPE"; EVENT_TYPE.value = models.Select(x => x.EVENT_TYPE).Distinct().ToList();
            var USAGE_TYPE = new QVDResponseModel(); USAGE_TYPE.key = "USAGE_TYPE"; USAGE_TYPE.value = models.Select(x => x.USAGE_TYPE).Distinct().ToList();
            var USAGE_TYPE_DESC = new QVDResponseModel(); USAGE_TYPE_DESC.key = "USAGE_TYPE_DESC"; USAGE_TYPE_DESC.value = models.Select(x => x.USAGE_TYPE_DESC).Distinct().ToList();
            var IRB_PRICE_PLAN = new QVDResponseModel(); IRB_PRICE_PLAN.key = "IRB_PRICE_PLAN"; IRB_PRICE_PLAN.value = models.Select(x => x.IRB_PRICE_PLAN).Distinct().ToList();
            var CALL_CATEGORY = new QVDResponseModel(); CALL_CATEGORY.key = "CALL_CATEGORY"; CALL_CATEGORY.value = models.Select(x => x.CALL_CATEGORY).Distinct().ToList();
            var DESTINATION = new QVDResponseModel(); DESTINATION.key = "DESTINATION"; DESTINATION.value = models.Select(x => x.DESTINATION).Distinct().ToList();
            var VPLMN = new QVDResponseModel(); VPLMN.key = "VPLMN"; VPLMN.value = models.Select(x => x.VPLMN).Distinct().ToList();
            var PRODUCT_NAME = new QVDResponseModel(); PRODUCT_NAME.key = "PRODUCT_NAME"; PRODUCT_NAME.value = models.Select(x => x.PRODUCT_NAME).Distinct().ToList();
            var CHARGE_TYPE = new QVDResponseModel(); CHARGE_TYPE.key = "CHARGE_TYPE"; CHARGE_TYPE.value = models.Select(x => x.CHARGE_TYPE).Distinct().ToList();
            var ADJUSTMENT_TYPE = new QVDResponseModel(); ADJUSTMENT_TYPE.key = "ADJUSTMENT_TYPE"; ADJUSTMENT_TYPE.value = models.Select(x => x.ADJUSTMENT_TYPE).Distinct().ToList();
            var ADJUSTMENT_NAME = new QVDResponseModel(); ADJUSTMENT_NAME.key = "ADJUSTMENT_NAME"; ADJUSTMENT_NAME.value = models.Select(x => x.ADJUSTMENT_NAME).Distinct().ToList();
            var DISCOUNT_NAME = new QVDResponseModel(); DISCOUNT_NAME.key = "DISCOUNT_NAME"; DISCOUNT_NAME.value = models.Select(x => x.DISCOUNT_NAME).Distinct().ToList();
            var DISCOUNT_TYPE = new QVDResponseModel(); DISCOUNT_TYPE.key = "DISCOUNT_TYPE"; DISCOUNT_TYPE.value = models.Select(x => x.DISCOUNT_TYPE).Distinct().ToList();
            var DISCOUNT_CLASS = new QVDResponseModel(); DISCOUNT_CLASS.key = "DISCOUNT_CLASS"; DISCOUNT_CLASS.value = models.Select(x => x.DISCOUNT_CLASS).Distinct().ToList();
            var PERIOD = new QVDResponseModel(); PERIOD.key = "PERIOD"; PERIOD.value = models.Select(x => x.PERIOD).Distinct().ToList();
            var CREATION_DATE = new QVDResponseModel(); CREATION_DATE.key = "CREATION_DATE"; CREATION_DATE.value = models.Select(x => x.CREATION_DATE).Distinct().ToList();
            var STC_SHARE = new QVDResponseModel(); STC_SHARE.key = "STC_SHARE"; STC_SHARE.value = models.Select(x => x.STC_SHARE).Distinct().ToList();
            var SP_ACCOUNT_NUM = new QVDResponseModel(); SP_ACCOUNT_NUM.key = "SP_ACCOUNT_NUM"; SP_ACCOUNT_NUM.value = models.Select(x => x.SP_ACCOUNT_NUM).Distinct().ToList();
            var REV_SHARE_FLAG = new QVDResponseModel(); REV_SHARE_FLAG.key = "REV_SHARE_FLAG"; REV_SHARE_FLAG.value = models.Select(x => x.REV_SHARE_FLAG).Distinct().ToList();
            var BILL_DATE = new QVDResponseModel(); BILL_DATE.key = "BILL_DATE"; BILL_DATE.value = models.Select(x => x.BILL_DATE).Distinct().ToList();
            var BATCH_REC_SEQ = new QVDResponseModel(); BATCH_REC_SEQ.key = "BATCH_REC_SEQ"; BATCH_REC_SEQ.value = models.Select(x => x.BATCH_REC_SEQ).Distinct().ToList();
            var CUSTOMER_SEGMENT = new QVDResponseModel(); CUSTOMER_SEGMENT.key = "CUSTOMER_SEGMENT"; CUSTOMER_SEGMENT.value = models.Select(x => x.CUSTOMER_SEGMENT).Distinct().ToList();
            var CUSTOMER_VALUE = new QVDResponseModel(); CUSTOMER_VALUE.key = "CUSTOMER_VALUE"; CUSTOMER_VALUE.value = models.Select(x => x.CUSTOMER_VALUE).Distinct().ToList();
            var RELATED_PARTY = new QVDResponseModel(); RELATED_PARTY.key = "RELATED_PARTY"; RELATED_PARTY.value = models.Select(x => x.RELATED_PARTY).Distinct().ToList();
            var SOURCE_SYSTEM = new QVDResponseModel(); SOURCE_SYSTEM.key = "SOURCE_SYSTEM"; SOURCE_SYSTEM.value = models.Select(x => x.SOURCE_SYSTEM).Distinct().ToList();
            var ORG_CUSTOMER_SEGMENT = new QVDResponseModel(); ORG_CUSTOMER_SEGMENT.key = "ORG_CUSTOMER_SEGMENT"; ORG_CUSTOMER_SEGMENT.value = models.Select(x => x.ORG_CUSTOMER_SEGMENT).Distinct().ToList();
            var FILE_NAME = new QVDResponseModel(); FILE_NAME.key = "FILE_NAME"; FILE_NAME.value = models.Select(x => x.FILE_NAME).Distinct().ToList();
            var XCREATION_DATE = new QVDResponseModel(); XCREATION_DATE.key = "XCREATION_DATE"; XCREATION_DATE.value = models.Select(x => x.XCREATION_DATE).Distinct().ToList();
            var CREATED_BY = new QVDResponseModel(); CREATED_BY.key = "CREATED_BY"; CREATED_BY.value = models.Select(x => x.CREATED_BY).Distinct().ToList();
            var LAST_UPDATED_DATE = new QVDResponseModel(); LAST_UPDATED_DATE.key = "LAST_UPDATED_DATE"; LAST_UPDATED_DATE.value = models.Select(x => x.LAST_UPDATED_DATE).Distinct().ToList();
            var LAST_UPDATED_BY = new QVDResponseModel(); LAST_UPDATED_BY.key = "LAST_UPDATED_BY"; LAST_UPDATED_BY.value = models.Select(x => x.LAST_UPDATED_BY).Distinct().ToList();
            var LAST_UPDATED_LOGIN = new QVDResponseModel(); LAST_UPDATED_LOGIN.key = "LAST_UPDATED_LOGIN"; LAST_UPDATED_LOGIN.value = models.Select(x => x.LAST_UPDATED_LOGIN).Distinct().ToList();
            var STATUS = new QVDResponseModel(); STATUS.key = "STATUS"; STATUS.value = models.Select(x => x.STATUS).Distinct().ToList();
            var CEXCEPTION = new QVDResponseModel(); CEXCEPTION.key = "CEXCEPTION"; CEXCEPTION.value = models.Select(x => x.CEXCEPTION).Distinct().ToList();


            #endregion

            #region Filteration
            if (BATCH_ID.value.Count < 10000) responseModels.Add(BATCH_ID);
            if (DATA_FIELD.value.Count < 10000) responseModels.Add(DATA_FIELD);
            if (REVENUE_MNY.value.Count < 10000) responseModels.Add(REVENUE_MNY);
            if (REVERSAL_FLAG.value.Count < 10000) responseModels.Add(REVERSAL_FLAG);
            if (QUANTITY.value.Count < 10000) responseModels.Add(QUANTITY);
            if (JURISDICTION.value.Count < 10000) responseModels.Add(JURISDICTION);
            if (PEAK_OFF_PEAK_FLAG.value.Count < 10000) responseModels.Add(PEAK_OFF_PEAK_FLAG);
            if (SERVICE_TYPE.value.Count < 10000) responseModels.Add(SERVICE_TYPE);
            if (PRODUCT_ID.value.Count < 10000) responseModels.Add(PRODUCT_ID);
            if (DISC_USAGE_TYPE.value.Count < 10000) responseModels.Add(DISC_USAGE_TYPE);
            if (BILL_CYCLE.value.Count < 10000) responseModels.Add(BILL_CYCLE);
            if (DISTRICT.value.Count < 10000) responseModels.Add(DISTRICT);
            if (CUSTOMER_TYPE.value.Count < 10000) responseModels.Add(CUSTOMER_TYPE);
            if (CUSTOMER_SUBTYPE.value.Count < 10000) responseModels.Add(CUSTOMER_SUBTYPE);
            if (INDUSTRY_TYPE.value.Count < 10000) responseModels.Add(INDUSTRY_TYPE);
            if (INDUSTRY_NAME.value.Count < 10000) responseModels.Add(INDUSTRY_NAME);
            if (GL_REV_CODE_NAME.value.Count < 10000) responseModels.Add(GL_REV_CODE_NAME);
            if (ABC_REV_CODE_NAME.value.Count < 10000) responseModels.Add(ABC_REV_CODE_NAME);
            if (SP_NAME.value.Count < 10000) responseModels.Add(SP_NAME);
            if (SP_PERCENTAGE.value.Count < 10000) responseModels.Add(SP_PERCENTAGE);
            if (SP_ADJUSTMENT_TYPE.value.Count < 10000) responseModels.Add(SP_ADJUSTMENT_TYPE);
            if (SP_REVENUE_CODE_NAME.value.Count < 10000) responseModels.Add(SP_REVENUE_CODE_NAME);
            if (REVENUE_CODE_ID.value.Count < 10000) responseModels.Add(REVENUE_CODE_ID);
            if (REVENUE_CODE_NAME.value.Count < 10000) responseModels.Add(REVENUE_CODE_NAME);
            if (SERVICE_CODE.value.Count < 10000) responseModels.Add(SERVICE_CODE);
            if (EVENT_TYPE.value.Count < 10000) responseModels.Add(EVENT_TYPE);
            if (USAGE_TYPE.value.Count < 10000) responseModels.Add(USAGE_TYPE);
            if (USAGE_TYPE_DESC.value.Count < 10000) responseModels.Add(USAGE_TYPE_DESC);
            if (IRB_PRICE_PLAN.value.Count < 10000) responseModels.Add(IRB_PRICE_PLAN);
            if (CALL_CATEGORY.value.Count < 10000) responseModels.Add(CALL_CATEGORY);
            if (DESTINATION.value.Count < 10000) responseModels.Add(DESTINATION);
            if (VPLMN.value.Count < 10000) responseModels.Add(VPLMN);
            if (PRODUCT_NAME.value.Count < 10000) responseModels.Add(PRODUCT_NAME);
            if (CHARGE_TYPE.value.Count < 10000) responseModels.Add(CHARGE_TYPE);
            if (ADJUSTMENT_TYPE.value.Count < 10000) responseModels.Add(ADJUSTMENT_TYPE);
            if (ADJUSTMENT_NAME.value.Count < 10000) responseModels.Add(ADJUSTMENT_NAME);
            if (DISCOUNT_NAME.value.Count < 10000) responseModels.Add(DISCOUNT_NAME);
            if (DISCOUNT_TYPE.value.Count < 10000) responseModels.Add(DISCOUNT_TYPE);
            if (DISCOUNT_CLASS.value.Count < 10000) responseModels.Add(DISCOUNT_CLASS);
            if (PERIOD.value.Count < 10000) responseModels.Add(PERIOD);
            if (CREATION_DATE.value.Count < 10000) responseModels.Add(CREATION_DATE);
            if (STC_SHARE.value.Count < 10000) responseModels.Add(STC_SHARE);
            if (SP_ACCOUNT_NUM.value.Count < 10000) responseModels.Add(SP_ACCOUNT_NUM);
            if (REV_SHARE_FLAG.value.Count < 10000) responseModels.Add(REV_SHARE_FLAG);
            if (BILL_DATE.value.Count < 10000) responseModels.Add(BILL_DATE);
            if (BATCH_REC_SEQ.value.Count < 10000) responseModels.Add(BATCH_REC_SEQ);
            if (CUSTOMER_SEGMENT.value.Count < 10000) responseModels.Add(CUSTOMER_SEGMENT);
            if (CUSTOMER_VALUE.value.Count < 10000) responseModels.Add(CUSTOMER_VALUE);
            if (RELATED_PARTY.value.Count < 10000) responseModels.Add(RELATED_PARTY);
            if (SOURCE_SYSTEM.value.Count < 10000) responseModels.Add(SOURCE_SYSTEM);
            if (ORG_CUSTOMER_SEGMENT.value.Count < 10000) responseModels.Add(ORG_CUSTOMER_SEGMENT);
            if (FILE_NAME.value.Count < 10000) responseModels.Add(FILE_NAME);
            if (XCREATION_DATE.value.Count < 10000) responseModels.Add(XCREATION_DATE);
            if (CREATED_BY.value.Count < 10000) responseModels.Add(CREATED_BY);
            if (LAST_UPDATED_DATE.value.Count < 10000) responseModels.Add(LAST_UPDATED_DATE);
            if (LAST_UPDATED_BY.value.Count < 10000) responseModels.Add(LAST_UPDATED_BY);
            if (LAST_UPDATED_LOGIN.value.Count < 10000) responseModels.Add(LAST_UPDATED_LOGIN);
            if (STATUS.value.Count < 10000) responseModels.Add(STATUS);
            if (CEXCEPTION.value.Count < 10000) responseModels.Add(CEXCEPTION);
            #endregion

            return Ok(responseModels);
        }
    }
}
