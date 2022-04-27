using ICCA.Interface.Log;
using ICCA.Interface.Model;
using ICCA.Interface.Repository;
using ICCA.Interface.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Xml;

namespace ICCA.Interface
{
    partial class Service : ServiceBase
    {
        private ConfigInfo config;
        private Timer timerMainCallback;
        private Object timerMainCallbackLock = new object();
        public Service()
        {
            InitializeComponent();
            config = Common.LoadServiceConfig();
            timerMainCallback = new Timer();
            timerMainCallback.Interval = config.InInterval;
            timerMainCallback.Enabled = true;
            timerMainCallback.Elapsed += new ElapsedEventHandler(OnTimerMainCallback);
        }
        /// <summary>
        /// Timer response function.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private void OnTimerMainCallback(object sender, EventArgs e)
        {
            lock (timerMainCallbackLock)
            {
                try
                {
                    timerMainCallback.Enabled = false;
                    if (config.EnableUpload == "true")
                    {
                        UploadDoc();
                    }
                    if (config.EnableRemove == "true")
                    {
                        RemoveDoc();
                    }
                }
                catch(Exception ex)
                {
                    LogUtil.ErrorLog("OnTimerMainCallback 发生错误:" + ex.Message);
                }
                finally
                {
                    timerMainCallback.Enabled = true;
                }
            }
        }
        public void Test()
        {
            if (config.EnableUpload == "true")
            {
                UploadDoc();
            }
            if (config.EnableRemove == "true")
            {
                RemoveDoc();
            }
        }

        protected override void OnStart(string[] args)
        {
            LogUtil.DebugLog("Enter Service OnStart().");
        }

        protected override void OnStop()
        {
            LogUtil.DebugLog("Exit Service OnStart().");
        }

        public void UploadDoc()
        {
            var docId = "";
            try
            {
                SqlRepository sqlRepository = new SqlRepository();
                var doc = sqlRepository.GetUploadDocBasic();
                if (doc != null)
                {
                    docId = doc.DocId;
                    LogUtil.CommonLog("UploadDoc-有文件需要上传，文件ID:" + doc.AutoId);
                    if (sqlRepository.GetDocDetail(doc))
                    {


                        var uploadXml = Common.GetText(config.XmlFilePath, "upload.txt");
                        uploadXml = uploadXml.Replace("{docid}", doc.DocId);
                        uploadXml = uploadXml.Replace("{patientno}", doc.PatientNo);
                        uploadXml = uploadXml.Replace("{title}", doc.Title);
                        uploadXml = uploadXml.Replace("{gestno}", doc.Gestno);
                        uploadXml = uploadXml.Replace("{mzh}", doc.Mzh);
                        uploadXml = uploadXml.Replace("{patnum}", doc.PatientNum);
                        uploadXml = uploadXml.Replace("{patname}", doc.PatientName);
                        uploadXml = uploadXml.Replace("{patsex}", doc.PatientSex);
                        uploadXml = uploadXml.Replace("{bedno}", doc.BedNo);
                        uploadXml = uploadXml.Replace("{author}", doc.Author);
                        uploadXml = uploadXml.Replace("{doctypename}", config.Doctypename);
                        uploadXml = uploadXml.Replace("{docdate}", Convert.ToDateTime(doc.DocDate).ToString("yyyy-MM-dd HH:mm:ss"));
                        uploadXml = uploadXml.Replace("{reason}", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("重症记录单")));
                        uploadXml = uploadXml.Replace("{reportdate}", Convert.ToDateTime(doc.ReportDate).ToString("yyyy-MM-dd HH:mm:ss"));

                        LogUtil.CommonLog("UploadDoc-上传XML:" + uploadXml);
                        uploadXml = uploadXml.Replace("{base64}", doc.FileBase64);

                        //上传文档
                        LogUtil.CommonLog("UploadDoc-开始上传文档");
                        PDFService.DocumentTransferSoapClient documentTransferSoapClient = new PDFService.DocumentTransferSoapClient();
                        var response = documentTransferSoapClient.UploadDoc(uploadXml);

                        if (response.result == 1)
                        {
                            LogUtil.CommonLog("UploadDoc-上传成功");
                            sqlRepository.UpdateUploadDocState(doc.AutoId, 1);
                        }
                        else
                        {
                            var base64EncodedBytes = System.Convert.FromBase64String(response.error);
                            LogUtil.CommonLog("UploadDoc-上传失败:" + Encoding.UTF8.GetString(base64EncodedBytes));
                            sqlRepository.UpdateUploadDocState(doc.AutoId, -1);
                        }
                        LogUtil.CommonLog("UploadDoc-更新上传状态");
                        
                    }
                    else
                    {
                        LogUtil.WarningLog("UploadDoc-PtenconuntId:" + doc.PtEncounterId + "没有就诊号");
                        sqlRepository.UpdateUploadDocState(doc.AutoId, -1);
                    }
                }
                else
                {
                    LogUtil.CommonLog("UploadDoc-没有文件需要上传");
                }
            }
            catch (Exception ex)
            {
                LogUtil.ErrorLog("UploadDoc-docId:" + docId + " 发生错误:" + ex.Message);
            }
        }


        public void RemoveDoc()
        {
            var docId = "";
            try
            {
                SqlRepository sqlRepository = new SqlRepository();
                var doc = sqlRepository.GetRemoveDocBasic();
                if (doc != null)
                {
                    docId = doc.DocId;
                    LogUtil.CommonLog("RemoveDoc-有文件需要移除，文件ID:" + doc.AutoId);
                    if (sqlRepository.GetDocDetail(doc))
                    {

                        var uploadXml = Common.GetText(config.XmlFilePath, "remove.txt");
                        uploadXml = uploadXml.Replace("{docid}", doc.DocId);
                        uploadXml = uploadXml.Replace("{patientno}", doc.PatientNo);
                        uploadXml = uploadXml.Replace("{title}", doc.Title);
                        uploadXml = uploadXml.Replace("{gestno}", doc.Gestno);
                        uploadXml = uploadXml.Replace("{mzh}", doc.Mzh);
                        uploadXml = uploadXml.Replace("{patnum}", doc.PatientNum);
                        uploadXml = uploadXml.Replace("{patname}", doc.PatientName);
                        uploadXml = uploadXml.Replace("{patsex}", doc.PatientSex);
                        uploadXml = uploadXml.Replace("{bedno}", doc.BedNo);
                        uploadXml = uploadXml.Replace("{author}", doc.Author);
                        uploadXml = uploadXml.Replace("{doctypename}", config.Doctypename);
                        uploadXml = uploadXml.Replace("{docdate}", Convert.ToDateTime(doc.DocDate).ToString("yyyy-MM-dd HH:mm:ss"));
                        uploadXml = uploadXml.Replace("{reason}", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("重症记录单")));
                        uploadXml = uploadXml.Replace("{reportdate}", Convert.ToDateTime(doc.ReportDate).ToString("yyyy-MM-dd HH:mm:ss"));

                        LogUtil.CommonLog("RemoveDoc-删除XML:" + uploadXml);

                        //上传文档
                        LogUtil.CommonLog("RemoveDoc-开始删除文档");
                        PDFService.DocumentTransferSoapClient documentTransferSoapClient = new PDFService.DocumentTransferSoapClient();
                        var response = documentTransferSoapClient.RemoveDoc(uploadXml);

                        if (response.result == 1)
                        {
                            LogUtil.CommonLog("RemoveDoc-删除成功");
                            sqlRepository.UpdateRemoveDocState(doc.AutoId, 1);
                        }
                        else
                        {
                            var base64EncodedBytes = System.Convert.FromBase64String(response.error);
                            LogUtil.CommonLog("RemoveDoc-删除失败:" + Encoding.UTF8.GetString(base64EncodedBytes));
                            sqlRepository.UpdateRemoveDocState(doc.AutoId, -1);
                        }
                        LogUtil.CommonLog("RemoveDoc-删除流程完成");
                       
                    }
                    else
                    {
                        LogUtil.WarningLog("RemoveDoc-PtenconuntId:" + doc.PtEncounterId + "没有就诊号");
                        sqlRepository.UpdateRemoveDocState(doc.AutoId, -1);
                    }
                }
                else
                {
                    LogUtil.CommonLog("RemoveDoc-没有文件需要删除");
                }
            }
            catch (Exception ex)
            {
                LogUtil.ErrorLog("RemoveDoc-docId:" + docId + " 发生错误:" + ex.Message);
            }
        }

    }
}
