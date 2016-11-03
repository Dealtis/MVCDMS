using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Security;
using System.Text;
using System.Security.Cryptography;
using System.IO;



namespace MvcApplication1.Controllers
{
   

    public class flash
    {
        public String FLAOTSNUM { get; set; }
        public String FLANOMDEST { get; set; }
        public String FLAADRDEST { get; set; }
        public String FLACPDEST { get; set; }
        public String FLAVILLEDEST { get; set; }
        public String FLANBFLASHER { get; set; }
        public String FLANBCOLIS { get; set; }
        public string FLAZONETHEORIQUE { get; set; }
        public string FLAZONEFLASHER { get; set; }
        public String FLAPDS { get; set; }
        public String FLAPAL { get; set; }
        public String FLACOLIS { get; set; }
        public List<flashEVE> FLAEVE { get; set; }

    }

    public class StatSTJ
    {
        public String OTPSOCCODE { get; set; }
        public String OTSSOCCODE { get; set; }
        public String TIETTYCODE { get; set; }
        public String OTPTRSCODE { get; set; }
        public String OTSDEPDTDEB { get; set; }
        public String OTSDEPUSRVILCP { get; set; }
        public String OTSARRUSRVILCP { get; set; }
        public decimal OTPMTVTED2 { get; set; }
        public decimal OTPMTD2 { get; set; }
        public String OTSTYPEDEPARR { get; set; }
        public String OTSRETURN { get; set; }
        public String OTSFACNUM { get; set; }    
        public string OTPPDSKG { get; set; }
        public String OTPPAL { get; set; }
        public String OTSLONG { get; set; }
        public String OTPCOL { get; set; }

        public String FACDTDEF { get; set; }

    }

    public class flashEVE
    {

        public string EVECODE { get; set; }
        public string EVEDATE { get; set; }
        public string EVEOTEVAL1 { get; set; }
    }


  




    
    

   

    

    

    

    public class flashController : ApiController
    {
        

        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string strSQL;

        public flash Get(string val)
        {
           
              using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
          
            var filename2 = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + "log\\" + "FLASH.txt";
            var sw2 = new System.IO.StreamWriter(filename2, true);
            sw2.WriteLine(DateTime.Now.ToString() + "DEBUT PROCEDURE");
            sw2.Close();
            try
            {
                Conn.Open();

                 filename2 = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + "log\\" + "FLASH.txt";
                sw2 = new System.IO.StreamWriter(filename2, true);
                sw2.WriteLine(DateTime.Now.ToString() + "DEBUT");
                sw2.Close();
                //   strSQl = "SELECT DGPCOND,DGPPOSITION,DGPHEUREPOS FROM DMSGPS WHERE DGPCOND='" + val + "' AND DGPDATE='" + DateTime.Now.ToString("d") + "'";
                strSQL = "SELECT TOP 1 OTSID,OTSNUM,replace(OTSTIENOM,'&','') AS OTSTIENOM,OTSETTCODEL1,OTSVILLIB,OTSPDS,OTSCOL,OTSPAL,OTSMEMOEDI,OTSARRTEL,OTSTYPEDEPARR,OTSMEMO,(select TOP 1 CAST(OTLCLASS as NVARCHAR)+' le :'+CONVERT(VARCHAR(10),OTLDATEM,3) from ordcol where OTLOTSID=OTSID) AS ZONEQUAI , (select count(*) from ORDCOL where OTLOTSID = OTSID) AS NBCOLIS, (select count(*) from ORDCOL where OTLOTSID = OTSID and OTLDTDEC is NOT null) AS NBCOLISFLASHE ,(select TOP 1 QUALIBL1 from ordre A, QUAI where  OTSVPECODE*=QUAVTOCODE and A.OTSID=OTSID) as ZONETHEO   FROM ORDCOL,ORDRE WHERE OTLOTSID=OTSID AND OTLNUMCB='" + val + "' AND OTSSOCCODE LIKE 'STJ25%'";// AND OTSSOCCODE LIKE '" + strSOCCODE + "%'";
                strSQL = strSQL + " UNION SELECT TOP 1 OTSID,OTSNUM,replace(OTSTIENOM,'&','') AS OTSTIENOM,OTSETTCODEL1,OTSVILLIB,OTSPDS,OTSCOL,OTSPAL,OTSMEMOEDI,OTSARRTEL,OTSTYPEDEPARR,OTSMEMO,(select TOP 1 CAST(OTLCLASS as NVARCHAR)+' le :'+CONVERT(VARCHAR(10),OTLDATEM,3) from ordcol where OTLOTSID=OTSID) AS ZONEQUAI, (select count(*) from ORDCOL where OTLOTSID = OTSID) AS NBCOLIS, (select count(*) from ORDCOL where OTLOTSID = OTSID and OTLDTDEC is NOT null) AS NBCOLISFLASHE,(select TOP 1 QUALIBL1 from ordre A, QUAI where  OTSVPECODE*=QUAVTOCODE and A.OTSID=OTSID) as ZONETHEO   FROM ORDRE WHERE  OTSNUM='" + val + "' AND OTSSOCCODE LIKE 'STJ25%'";// AND OTSSOCCODE LIKE '" & strSOCCODE + "%'";
               // strSQL = strSQL + " UNION SELECT TOP 1 OTSID,OTSNUM,replace(OTSTIENOM,'&','') AS OTSTIENOM,OTSETTCODEL1,OTSVILLIB,OTSPDS,OTSCOL,OTSPAL,OTSMEMOEDI,OTSARRTEL,OTSTYPEDEPARR,OTSMEMO,(select TOP 1 CAST(OTLCLASS as NVARCHAR)+' le :'+CONVERT(VARCHAR(10),OTLDATEM,3) from ordcol where OTLOTSID=OTSID) AS ZONEQUAI, (select count(*) from ORDCOL where OTLOTSID = OTSID) AS NBCOLIS, (select count(*) from ORDCOL where OTLOTSID = OTSID and OTLDTDEC is NOT null) AS NBCOLISFLASHE,(select TOP 1 QUALIBL1 from ordre A, QUAI where  OTSVPECODE*=QUAVTOCODE and A.OTSID=OTSID) as ZONETHEO   FROM ORDRE WHERE  OTSREF='" + val + "' AND OTSSOCCODE LIKE 'STJ25%' ";//AND OTSSOCCODE LIKE '" & strSOCCODE + "%'";
                // strSQL = strSQL + " UNION SELECT TOP 1 OTSID,OTSNUM,replace(OTSTIENOM,'&','') AS OTSTIENOM,OTSETTCODEL1,OTSVILLIB,OTSPDS,OTSCOL,OTSPAL,OTSMEMOEDI,OTSARRTEL,OTSTYPEDEPARR,OTSMEMO,(select TOP 1 CAST(OTLCLASS as NVARCHAR)+' le :'+CONVERT(VARCHAR(10),OTLDATEM,3) from ordcol where OTLOTSID=OTSID) AS ZONEQUAI, (select count(*) from ORDCOL where OTLOTSID = OTSID) AS NBCOLIS, (select count(*) from ORDCOL where OTLOTSID = OTSID and OTLDTDEC is NOT null) AS NBCOLISFLASHE  FROM ORDRE WHERE  OTSREFEQUINOXE='" + val + "'";// AND OTSSOCCODE LIKE '" & strSOCCODE + "%'";

                strSQL = "SELECT TOP 1 OTSID,OTSNUM,replace(OTSTIENOM,'&','') AS OTSTIENOM,OTSETTCODEL1,OTSVILLIB,OTSPDS,OTSCOL,OTSPAL,OTSMEMOEDI,OTSARRTEL,OTSTYPEDEPARR,OTSMEMO,(select TOP 1 CAST(OTLCLASS as NVARCHAR)+' le :'+CONVERT(VARCHAR(10),OTLDATEM,3) from ordcol where OTLOTSID=OTSID) AS ZONEQUAI , (select count(*) from ORDCOL where OTLOTSID = OTSID) AS NBCOLIS, (select count(*) from ORDCOL where OTLOTSID = OTSID and OTLDTDEC is NOT null) AS NBCOLISFLASHE ,(select TOP 1 QUALIBL1 from ordre A, QUAI where  OTSVPECODE*=QUAVTOCODE and A.OTSID=OTSID) as ZONETHEO   FROM ORDCOL,ORDRE WHERE OTLOTSID=OTSID AND OTLNUMCB='" + val + "' AND OTSSOCCODE LIKE 'STJ25%'";

                SqlCommand command = new SqlCommand(strSQL, Conn);
                SqlDataReader sdr = command.ExecuteReader();
                 filename2 = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + "log\\" + "FLASH.txt";
                 sw2 = new System.IO.StreamWriter(filename2, true);
                sw2.WriteLine(DateTime.Now.ToString() + "EXECUTION REQUETE");
                sw2.Close();
                DataTable FlashOrdre = new DataTable();
                FlashOrdre.Load(sdr);

                flash flashposition = new flash();


                for (int i = 0; i < FlashOrdre.Rows.Count; i++)
                {
                    flashposition.FLAOTSNUM = FlashOrdre.Rows[i]["OTSNUM"].ToString();
                    flashposition.FLANOMDEST = FlashOrdre.Rows[i]["OTSTIENOM"].ToString();
                    flashposition.FLAVILLEDEST = FlashOrdre.Rows[i]["OTSVILLIB"].ToString();
                    flashposition.FLAPAL = FlashOrdre.Rows[i]["OTSPAL"].ToString();
                    flashposition.FLAPDS = FlashOrdre.Rows[i]["OTSPDS"].ToString();
                    flashposition.FLACOLIS = FlashOrdre.Rows[i]["OTSCOL"].ToString();
                    flashposition.FLANBFLASHER = FlashOrdre.Rows[i]["NBCOLISFLASHE"].ToString();
                    flashposition.FLANBCOLIS = FlashOrdre.Rows[i]["NBCOLIS"].ToString();
                    flashposition.FLAZONEFLASHER = FlashOrdre.Rows[i]["ZONEQUAI"].ToString();
                    flashposition.FLAZONETHEORIQUE = FlashOrdre.Rows[i]["ZONETHEO"].ToString();

                    var listeve = new List<flashEVE>();
                    filename2 = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + "log\\" + "FLASH.txt";
                    sw2 = new System.IO.StreamWriter(filename2, true);
                    sw2.WriteLine(DateTime.Now.ToString() + "AVANT ORDEVE");
                    sw2.Close();
               
                    strSQL = "SELECT TOP 3 OTETEVCODEL1,OTEVAL3,LEFT(CONVERT(VARCHAR(8), OTEVAL1, 3), 5) AS OTEVAL1,OTETEVLIBCL1,LEFT(CONVERT(VARCHAR(8), OTEDATEC, 3), 5) AS OTEDATEC FROM ORDEVE WHERE OTEOTSID= " + FlashOrdre.Rows[i]["OTSID"].ToString() + " ORDER BY OTEID DESC";
                    command = new SqlCommand(strSQL, Conn);
                    sdr = command.ExecuteReader();
                    DataTable OrdreEVE = new DataTable();
                    OrdreEVE.Load(sdr);
                    for (int j = 0; j < OrdreEVE.Rows.Count; j++)
                    {
                        flashEVE evenement = new flashEVE();
                        evenement.EVECODE = OrdreEVE.Rows[j]["OTETEVLIBCL1"].ToString();
                        evenement.EVEDATE = OrdreEVE.Rows[j]["OTEDATEC"].ToString();
                        evenement.EVEOTEVAL1 = OrdreEVE.Rows[j]["OTEVAL1"].ToString();

                        listeve.Add(evenement);
                    }
                    filename2 = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + "log\\" + "FLASH.txt";
                    sw2 = new System.IO.StreamWriter(filename2, true);
                    sw2.WriteLine(DateTime.Now.ToString() + "FIN");
                    sw2.Close();
               
                    flashposition.FLAEVE = listeve;


                }

                Conn.Close();
            
                filename2 = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + "log\\" + "FLASH.txt";
                sw2 = new System.IO.StreamWriter(filename2, true);
                sw2.WriteLine(DateTime.Now.ToString() + "FIN PROCEDURE");
                sw2.Close();
                return flashposition;
            }
            
            catch (Exception ex)
            {
                Conn.Close();
                var flashposition = new flash();
                return flashposition;
            }
        }
        }
    }


    public class StatBDDController : ApiController
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string strSQL;

        public List<StatSTJ> Get(string DATEDEBUT,string DATEFIN,string strTYPE,string SOCIETE)
        {
            try
            {
                Conn.Open();
                //   strSQl = "SELECT DGPCOND,DGPPOSITION,DGPHEUREPOS FROM DMSGPS WHERE DGPCOND='" + val + "' AND DGPDATE='" + DateTime.Now.ToString("d") + "'";
                // strSQL = strSQL + " UNION SELECT TOP 1 OTSID,OTSNUM,replace(OTSTIENOM,'&','') AS OTSTIENOM,OTSETTCODEL1,OTSVILLIB,OTSPDS,OTSCOL,OTSPAL,OTSMEMOEDI,OTSARRTEL,OTSTYPEDEPARR,OTSMEMO,(select TOP 1 CAST(OTLCLASS as NVARCHAR)+' le :'+CONVERT(VARCHAR(10),OTLDATEM,3) from ordcol where OTLOTSID=OTSID) AS ZONEQUAI, (select count(*) from ORDCOL where OTLOTSID = OTSID) AS NBCOLIS, (select count(*) from ORDCOL where OTLOTSID = OTSID and OTLDTDEC is NOT null) AS NBCOLISFLASHE,(select TOP 1 QUALIBL1 from ordre A, QUAI where  OTSVPECODE*=QUAVTOCODE and A.OTSID=OTSID) as ZONETHEO   FROM ORDRE WHERE  OTSREF='" + val + "' AND OTSSOCCODE LIKE 'STJ25%' ";//AND OTSSOCCODE LIKE '" & strSOCCODE + "%'";
                // strSQL = strSQL + " UNION SELECT TOP 1 OTSID,OTSNUM,replace(OTSTIENOM,'&','') AS OTSTIENOM,OTSETTCODEL1,OTSVILLIB,OTSPDS,OTSCOL,OTSPAL,OTSMEMOEDI,OTSARRTEL,OTSTYPEDEPARR,OTSMEMO,(select TOP 1 CAST(OTLCLASS as NVARCHAR)+' le :'+CONVERT(VARCHAR(10),OTLDATEM,3) from ordcol where OTLOTSID=OTSID) AS ZONEQUAI, (select count(*) from ORDCOL where OTLOTSID = OTSID) AS NBCOLIS, (select count(*) from ORDCOL where OTLOTSID = OTSID and OTLDTDEC is NOT null) AS NBCOLISFLASHE  FROM ORDRE WHERE  OTSREFEQUINOXE='" + val + "'";// AND OTSSOCCODE LIKE '" & strSOCCODE + "%'";

                if (strTYPE == "1")
                {
                    strSQL = "select ROUND(ISNULL(OTPMTVTED2,'0'),2) AS VENTESEGMENT,ROUND(ISNULL(OTPMTVTED2,'0'),2) AS ACHAT,* from STAT_ORDPLA_ORDRE where FACDTDEF between '" + DATEDEBUT + " 00:00' AND '" + DATEFIN + " 23:59' and FACSOCCODE='" + SOCIETE + "'";
                    strSQL = "select sum(ROUND(ISNULL(OTPMTVTED2,'0'),2)) AS VENTESEGMENT,sum(ROUND(ISNULL(OTPMTVTED2,'0'),2)) AS ACHAT,sum(OTPPDSKG) as OTPPDSKG, sum(OTPPAL) as OTPPAL, sum(OTSLONG) as OTSLONG , sum(OTPCOL) AS OTPCOL ,OTSTYPEDEPARR,OTPSOCCODE,OTSSOCCODE,TIETTYCODE,OTPTRSCODE, DPDEPART, DPARRIVEE,OTSTYPEDEPARR2,OTSRETURN from STAT_ORDPLA_ORDRE where FACDTDEF between '" + DATEDEBUT + " 00:00' AND '" + DATEFIN + " 23:59' and FACSOCCODE='" + SOCIETE + "' group by OTSTYPEDEPARR,OTPSOCCODE,OTSSOCCODE,TIETTYCODE,OTPTRSCODE,DPDEPART,DPARRIVEE,OTSTYPEDEPARR2,OTSRETURN ";
                }
                else
                {
                    strSQL = "select sum(ROUND(ISNULL(OTPMTVTED2,'0'),2)) AS VENTESEGMENT,sum(ROUND(ISNULL(OTPMTVTED2,'0'),2)) AS ACHAT,sum(OTPPDSKG) as OTPPDSKG, sum(OTPPAL) as OTPPAL, sum(OTSLONG) as OTSLONG , sum(OTPCOL) AS OTPCOL ,OTSTYPEDEPARR,OTPSOCCODE,OTSSOCCODE,TIETTYCODE,OTPTRSCODE, DPDEPART, DPARRIVEE,OTSTYPEDEPARR2,OTSRETURN from STAT_ORDPLA_ORDRE where FACDTDEF between '01/01/2016 00:00' AND '30/06/2016 23:59' and FACSOCCODE='STJ25' group by OTSTYPEDEPARR,OTPSOCCODE,OTSSOCCODE,TIETTYCODE,OTPTRSCODE,DPDEPART,DPARRIVEE,OTSTYPEDEPARR2,OTSRETURN ";
                    strSQL = "select sum(ROUND(ISNULL(OTPMTVTED2,'0'),2)) AS VENTESEGMENT,sum(ROUND(ISNULL(OTPMTVTED2,'0'),2)) AS ACHAT,sum(OTPPDSKG) as OTPPDSKG, sum(OTPPAL) as OTPPAL, sum(OTSLONG) as OTSLONG , sum(OTPCOL) AS OTPCOL ,OTSTYPEDEPARR,OTPSOCCODE,OTSSOCCODE,TIETTYCODE,OTPTRSCODE, DPDEPART, DPARRIVEE,OTSTYPEDEPARR2,OTSRETURN from STAT_ORDPLA_ORDRE where OTSDEPDTDEB between '" + DATEDEBUT + " 00:00' AND '" + DATEFIN + " 23:59' and FACSOCCODE='" + SOCIETE + "' group by OTSTYPEDEPARR,OTPSOCCODE,OTSSOCCODE,TIETTYCODE,OTPTRSCODE,DPDEPART,DPARRIVEE,OTSTYPEDEPARR2,OTSRETURN ";
             
                }
           

                SqlCommand command = new SqlCommand(strSQL, Conn);
                SqlDataReader sdr = command.ExecuteReader();

                DataTable StatTABLE = new DataTable();
                StatTABLE.Load(sdr);

                     var ListSTAT = new List<StatSTJ>();
           

                for (int i = 0; i < StatTABLE.Rows.Count; i++)
                {   
                    
                    StatSTJ PosSTAT = new StatSTJ();
            
                    PosSTAT.OTPSOCCODE = StatTABLE.Rows[i]["OTPSOCCODE"].ToString();
                    PosSTAT.OTSSOCCODE = StatTABLE.Rows[i]["OTSSOCCODE"].ToString();
                    PosSTAT.TIETTYCODE = StatTABLE.Rows[i]["TIETTYCODE"].ToString();
                    PosSTAT.OTPTRSCODE = StatTABLE.Rows[i]["OTPTRSCODE"].ToString();
                  //  PosSTAT.OTSDEPDTDEB = StatTABLE.Rows[i]["OTSDEPDTDEB"].ToString();
                    PosSTAT.OTSDEPUSRVILCP = StatTABLE.Rows[i]["DPDEPART"].ToString();
                    PosSTAT.OTSARRUSRVILCP = StatTABLE.Rows[i]["DPARRIVEE"].ToString();
                    PosSTAT.OTPMTVTED2 = Convert.ToDecimal(StatTABLE.Rows[i]["ACHAT"]);
                    PosSTAT.OTPMTD2 = Convert.ToDecimal(StatTABLE.Rows[i]["VENTESEGMENT"]);
                    PosSTAT.OTSTYPEDEPARR = StatTABLE.Rows[i]["OTSTYPEDEPARR"].ToString();
                    PosSTAT.OTSRETURN = StatTABLE.Rows[i]["OTSRETURN"].ToString();
                    //PosSTAT.OTSFACNUM = StatTABLE.Rows[i]["OTSFACNUM"].ToString();
                    PosSTAT.OTPPDSKG = StatTABLE.Rows[i]["OTPPDSKG"].ToString();
                    PosSTAT.OTPPAL = StatTABLE.Rows[i]["OTPPAL"].ToString();
                    PosSTAT.OTSLONG = StatTABLE.Rows[i]["OTSLONG"].ToString();
                    PosSTAT.OTPCOL = StatTABLE.Rows[i]["OTPCOL"].ToString();
                   // PosSTAT.SOOFACNUM = StatTABLE.Rows[i]["OTSSOCCODE"].ToString();
                    //PosSTAT.FACDTDEF = StatTABLE.Rows[i]["FACDTDEF"].ToString();


                    ListSTAT.Add(PosSTAT);



                }

                Conn.Close();
                return ListSTAT;
            }
            catch (Exception ex)
            {
                Conn.Close();
                var ListSTAT = new List<StatSTJ>();
                return ListSTAT;
            }

        }
    }
}

