using ICCA.Interface.Log;
using ICCA.Interface.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ICCA.Interface.Repository
{
    public class SqlRepository
    {
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Philips_ICCA"].ToString();

        public SqlSugarClient db;//用来处理事务多表查询和复杂的操作 
        public SqlRepository()
        {
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样
            });

        }
        public UploadDocModel GetUploadDocBasic()
        {
            var sql = @" select top 1 id as AutoId, pdf.ptEncounterId, reportDate, filePath, pdf.id as DocId, pdf.CreateTime as DocDate , Verifyer as Author from ExportPDFRecord pdf
  left join Form form on pdf.FormID=form.FormID
  where isUpload is not null and isUpload=0   and form.State=2  order by id desc";
            return db.Ado.SqlQuerySingle<UploadDocModel>(sql);
        }

        public UploadDocModel GetRemoveDocBasic()
        {
            var sql = @" select top 1 id as AutoId, pdf.ptEncounterId, reportDate, filePath, pdf.FormID as DocId, pdf.CreateTime as DocDate , Verifyer as Author from ExportPDFRecord pdf
  inner join Form form on pdf.FormID=form.FormID 
  where form.State=1 and isRemove=0 order by id desc";
            return db.Ado.SqlQuerySingle<UploadDocModel>(sql);
        }

        public bool GetDocDetail(UploadDocModel data)
        {
            var result = true;
            var sql = @" SELECT 
	pat.lifetimeNumber as PatientNo,
              enc.encounterNumber as Gestno,
              ppd.terseForm AS PatientName,
              bed.displayLabel AS BedNo
        FROM	CISPrimaryDB.dbo.Patient AS pat WITH (NOLOCK)
                INNER JOIN CISPrimaryDB.dbo.PtEpisode AS epi WITH (NOLOCK) ON epi.patientId = pat.patientId
                  INNER JOIN CISPrimaryDB.dbo.PtEncounter AS enc WITH (NOLOCK) ON enc.ptEpisodeId = epi.ptEpisodeId
                    INNER JOIN CISPrimaryDB.dbo.PtPatientDetail as ppd WITH (NOLOCK) ON ppd.ptEncounterId = enc.ptEncounterId 
                      AND ppd.dataElementConceptId = '9F8CDAC4-96D4-4BE7-A9CC-D9B3FA7FD9B6'  
                      AND ppd.attributePropname IS NULL
                    INNER JOIN CISPrimaryDB.dbo.PtLocationStay AS loc WITH (NOLOCK) ON loc.ptEncounterId = enc.ptEncounterId
                      INNER JOIN CISPrimaryDB.dbo.ClinicalUnit as unt WITH (NOLOCK) ON unt.clinicalUnitId = loc.clinicalUnitId
                      LEFT JOIN CISPrimaryDB.dbo.Bed AS bed WITH (NOLOCK) ON bed.bedId = loc.bedId
                    INNER JOIN CISPrimaryDB.dbo.HostDb AS hos WITH (NOLOCK) ON hos.hostDbId = enc.hostDbId
        	  where enc.ptEncounterId='" + data.PtEncounterId + "'";

            var temp = db.Ado.SqlQuerySingle<UploadDocModel>(sql);
            if (temp != null)
            {
                var patNum = "1";
                if (!string.IsNullOrEmpty(temp.Gestno) && temp.Gestno.Contains("|"))
                {
                     patNum = temp.Gestno.Split('|')[1];
                }
                else
                {
                    result = false;
                    return result;
                }
                data.PatientNo = temp.PatientNo + "-" + patNum;
                data.PatientNum = patNum;
                data.Gestno = "";
                data.Mzh = "";
                data.PatientName = temp.PatientName;
                data.BedNo = temp.BedNo;
            }

            var sexSql = @"SELECT
        pin.terseForm AS value_t
  FROM	CISChartingDB1.dbo.PtIntervention pin 
          INNER JOIN CISChartingDB1.dbo.Intervention itv ON itv.interventionId = pin.interventionId
  WHERE pin.isDeleted = 0 AND pin.ptInterventionVersion = CISChartingDB1.dbo.UfnGetPtInterventionLatestVersion(pin.ptInterventionId) 
        AND (pin.terseForm IS NOT NULL OR pin.verboseForm IS NOT NULL)
		and pin.ptEncounterId='" + data.PtEncounterId + "' and itv.propname='genderInt'";
            var sex = db.Ado.GetString(sexSql);
            if (!string.IsNullOrEmpty(sex))
            {
                data.PatientSex = sex;
            }
            else
            {
                data.PatientSex = "未知";
            }
            if (!string.IsNullOrEmpty(data.FilePath))
            {
                data.Title = data.FilePath.Substring(data.FilePath.IndexOf('_') + 1);
                data.FileBase64 = Convert.ToBase64String(File.ReadAllBytes(data.FilePath));
            }
            return result;
        }

        public void UpdateUploadDocState(int autoId, int state)
        {
            var sql = @"update ExportPDFRecord set isUpload=" + state + " where ID=" + autoId;
            db.Ado.ExecuteCommand(sql);
        }
        public void UpdateRemoveDocState(int autoId, int state)
        {
            var sql = @"update ExportPDFRecord set isRemove=" + state + " where ID=" + autoId;
            db.Ado.ExecuteCommand(sql);
        }
    }
}
