using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICCA.Interface.Model
{
    public class UploadDocModel
    {
        public int AutoId { get; set; }
        public string DocId { get; set; }
        public string PatientNo { get; set; }
        public string Title { get; set; }
        public string Gestno { get; set; }
        public string Mzh { get; set; }
        public string PatientNum { get; set; }
        public string PatientName { get; set; }
        public string PatientSex { get; set; }
        public string BedNo { get; set; }
        public string Author { get; set; }
        public string DocDate { get; set; }
        public string Reason { get; set; }
        public string ReportDate { get; set; }
        public string FileBase64 { get; set; }

        public string FilePath { get; set; }
        public string PtEncounterId { get; set; }
    }
}
