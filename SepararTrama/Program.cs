using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepararSWITCHDUMPLOG
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "524486*.dat", SearchOption.AllDirectories);
                if (files.Length > 0)
                {
                    Console.WriteLine("Se encontró " + files.Length + " archivos validos.\nDesea procesarlos? ([Y]/N)");
                    string key = Console.ReadLine();
                    if (key != "N")
                    {
                        foreach (string file in files)
                        {
                            procesarArchivo(file);
                        }    
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró archivos validos en la ruta " + Directory.GetCurrentDirectory());
                }
            }
            else
            {
                Console.WriteLine("Se recibió el siguiente archivo: " + args[0]);
                procesarArchivo(args[0]);
            }
            Console.WriteLine("Fin");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void procesarArchivo(string filename)
        {
            int nLineas = 0;
            int cantidadCaracteres = 560;
            string text = File.ReadAllText(filename);

            string[] lineas = new string[text.Length / cantidadCaracteres];
            DataTable dt;

            while (nLineas * cantidadCaracteres < text.Length)
            {
                try
                {
                    lineas[nLineas] = text.Substring(nLineas * cantidadCaracteres, cantidadCaracteres).Replace(",", " ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                nLineas++;
            }
            
            dt = separarColumnas(lineas);
            ExportarDataTableCSV(dt, filename);
        }

        private static DataTable separarColumnas(string[] lineas)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Transaction Type Identifier");
            dt.Columns.Add("Data Compression Technique");
            dt.Columns.Add("Data Packet Sequence Number");
            dt.Columns.Add("More Data Follow");
            dt.Columns.Add("Message Type");
            dt.Columns.Add("STFWD Indicator");
            dt.Columns.Add("Primary Account Number");
            dt.Columns.Add("Código de acción de la transacción");
            dt.Columns.Add("Tipo de cuenta de origen");
            dt.Columns.Add("Tipo de cuenta de destino");
            dt.Columns.Add("Transaction Amount");
            dt.Columns.Add("Settlement Amount");
            dt.Columns.Add("Card Issuer Amount");
            dt.Columns.Add("Transmission Date");
            dt.Columns.Add("Transmission Time");
            dt.Columns.Add("Conversion rate Settlement");
            dt.Columns.Add("Conversion rate Cardholder billing");
            dt.Columns.Add("System trace audit number");
            dt.Columns.Add("Time local transaction");
            dt.Columns.Add("Date local transaction");
            dt.Columns.Add("Date expiry");
            dt.Columns.Add("Date settlemen");
            dt.Columns.Add("Date conversion");
            dt.Columns.Add("Data Capture");
            dt.Columns.Add("Merchant type");
            dt.Columns.Add("Point of service entry mode");
            dt.Columns.Add("Network Identifier");
            dt.Columns.Add("Point of service condition code");
            dt.Columns.Add("Amount Settlement transaction fee");
            dt.Columns.Add("Amount Settlement processing fee");
            dt.Columns.Add("Acquiring Institution Identification Code");
            dt.Columns.Add("Forwarding Inst. Ident. Code");
            dt.Columns.Add("Track 2 data");
            dt.Columns.Add("Retrieval Reference Number");
            dt.Columns.Add("Auth. Identification Response");
            dt.Columns.Add("Response Code");
            dt.Columns.Add("Card Acceptor Terminal Id.");
            dt.Columns.Add("Card Acceptor Location");
            dt.Columns.Add("Currency Code Transaction");
            dt.Columns.Add("Currency code Settlement");
            dt.Columns.Add("Currency Code Card Holder Billing");
            dt.Columns.Add("Original Message Type");
            dt.Columns.Add("Original trace Number");
            dt.Columns.Add("Original Date");
            dt.Columns.Add("Original Time");
            dt.Columns.Add("Original Acq. Inst. Ident. Code");
            dt.Columns.Add("Original Forw. Inst. Ident Code");
            dt.Columns.Add("Replacement Transaction Amount");
            dt.Columns.Add("Replacement Settlement Amount");
            dt.Columns.Add("Replacement transaction Fee");
            dt.Columns.Add("Replacement Settlement Fee");
            dt.Columns.Add("Payee (Name of Merchant)");
            dt.Columns.Add("Requesting Institution");
            dt.Columns.Add("Account Identification 1");
            dt.Columns.Add("Account Identification 2");
            dt.Columns.Add("Card Category");
            dt.Columns.Add("Tier II");
            dt.Columns.Add("Longitud del campo");
            dt.Columns.Add("Longitud del sub campo");
            dt.Columns.Add("Código del sub campo");
            dt.Columns.Add("Importe Cash Back");
            dt.Columns.Add("Cuota CMR");
            dt.Columns.Add("Card Acceptor Identification");
            dt.Columns.Add("TRAMA");

            int[] longitud = new int[dt.Columns.Count];
            longitud[0] = 1;
            longitud[1] = 4;
            longitud[2] = 1;
            longitud[3] = 4;
            longitud[4] = 1;
            longitud[5] = 4;
            longitud[6] = 3;
            longitud[7] = 19;
            longitud[8] = 2;
            longitud[9] = 2;
            longitud[10] = 2;
            longitud[11] = 12;
            longitud[12] = 12;
            longitud[13] = 12;
            longitud[14] = 4;
            longitud[15] = 6;
            longitud[16] = 8;
            longitud[17] = 8;
            longitud[18] = 6;
            longitud[19] = 6;
            longitud[20] = 4;
            longitud[21] = 4;
            longitud[22] = 4;
            longitud[23] = 4;
            longitud[24] = 4;
            longitud[25] = 4;
            longitud[26] = 3;
            longitud[27] = 3;
            longitud[28] = 2;
            longitud[29] = 9;
            longitud[30] = 9;
            longitud[31] = 11;
            longitud[32] = 11;
            longitud[33] = 37;
            longitud[34] = 12;
            longitud[35] = 6;
            longitud[36] = 3;
            longitud[37] = 8;
            longitud[38] = 40;
            longitud[39] = 3;
            longitud[40] = 3;
            longitud[41] = 3;
            longitud[42] = 4;
            longitud[43] = 6;
            longitud[44] = 4;
            longitud[45] = 6;
            longitud[46] = 11;
            longitud[47] = 11;
            longitud[48] = 12;
            longitud[49] = 12;
            longitud[50] = 9;
            longitud[51] = 9;
            longitud[52] = 25;
            longitud[53] = 11;
            longitud[54] = 29;
            longitud[55] = 29;
            longitud[56] = 2;
            longitud[57] = 20;
            longitud[58] = 3;
            longitud[59] = 3;
            longitud[60] = 2;
            longitud[61] = 9;
            longitud[62] = 22;
            longitud[63] = 15;
            //longitud[64] = 2;



            int pos = 0;
            int cantidad = 0;
            DateTime fecha = DateTime.Now;
            for (int j = 0; j < lineas.Length; j++)
            {
                pos = 0;
                if (lineas[j].StartsWith("A"))
                {
                    fecha = DateTime.Parse("20"+lineas[j].Substring(24, 2) + "-" + lineas[j].Substring(26, 2) + "-" + lineas[j].Substring(28, 2));
                }
                else if (lineas[j].StartsWith("B"))
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count - 1; i++)
                    {
                        if (i == 5)
                        {
                            dr[i] = "=\"" + lineas[j].Substring(pos + 3, longitud[i] - 3) + "\"";
                            switch (lineas[j].Substring(pos, longitud[i]))
                            {
                                case "0100":
                                    dr[i] = "=\"Solicitud de autorización (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0110":
                                    dr[i] = "=\"Respuesta a solicitud de autorización (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0120":
                                    dr[i] = "=\"Notificación de autorización (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0130":
                                    dr[i] = "=\"Respuesta a la notificación de autorización (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0200":
                                    dr[i] = "=\"Requerimiento de transacción financiera (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0210":
                                    dr[i] = "=\"Respuesta al requerimiento de transacción financiera (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0302":
                                    dr[i] = "=\"Requerimiento de transacción administrativa de tarjetas, cuentas y relación cuenta-tarjeta (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0312":
                                    dr[i] = "=\"Respuesta al requerimiento de administrativa de tarjetas, cuentas y relación tarjeta-cuenta (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0400":
                                    dr[i] = "=\"Requerimiento de extorno (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0410":
                                    dr[i] = "=\"Respuesta al requerimiento de extorno (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0420":
                                    dr[i] = "=\"Notificación de extorno (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0430":
                                    dr[i] = "=\"Respuesta a la notificación de extorno de transacción financiera (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0800":
                                    dr[i] = "=\"Requerimiento de gestión de red del Switch (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "0810":
                                    dr[i] = "=\"Respuesta al requerimiento de gestión de red del Switch (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                default:
                                    dr[i] = "=\"" + lineas[j].Substring(pos, longitud[i]) + "\"";
                                    break;
                            }
                        }
                        else if (i == 6)
                        {
                            if (lineas[j].Substring(15, 1) == "C")
                            {
                                dr[i] = "=\"Institución respondió (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                            }
                            else
                            {
                                dr[i] = "=\"UNIBANCA respondió (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                            }
                        }
                        else if (i == 7)
                        {
                            dr[i] = "=\"" + lineas[j].Substring(pos + 3, longitud[i] - 3) + "\"";
                        }
                        else if (i == 8)
                        {
                            switch (lineas[j].Substring(pos, longitud[i]))
                            {
                                case "00":
                                    dr[i] = "=\"Compras (MC) (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "01":
                                    dr[i] = "=\"Retiros (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "20":
                                    dr[i] = "=\"Reembolso (MC) (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "28":
                                    dr[i] = "=\"Money Send (MC) (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "31":
                                    dr[i] = "=\"Consulta de Saldos a una cuenta (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "39":
                                    dr[i] = "=\"Consulta de últimos movimientos (RU) (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "91":
                                    dr[i] = "=\"Cambio de Clave (RU) (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "96":
                                    dr[i] = "=\"Cambio de Clave (RU) (emisor valida PIN) (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                default:
                                    dr[i] = "=\"" + lineas[j].Substring(pos, longitud[i]) + "\"";
                                    break;
                            }
                        }
                        else if (i == 9)
                        {
                            switch (lineas[j].Substring(pos, longitud[i]))
                            {
                                case "00":
                                    dr[i] = "=\"Tipo de cuenta no especificado o pre-pago (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "10":
                                    dr[i] = "=\"Cuenta de Ahorros (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "20":
                                    dr[i] = "=\"Cuenta Corriente (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "30":
                                    dr[i] = "=\"Cuenta de Tarjeta Crédito (MC) (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "40":
                                    dr[i] = "=\"Línea de Crédito (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "50":
                                    dr[i] = "=\"CTS (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "90":
                                    dr[i] = "=\"Tarjeta de crédito (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                default:
                                    dr[i] = "=\"" + lineas[j].Substring(pos, longitud[i]) + "\"";
                                    break;
                            }
                        }
                        else if (i == 10)
                        {
                            switch (lineas[j].Substring(pos, longitud[i]))
                            {
                                case "00":
                                    dr[i] = "=\"Tipo de cuenta no especificado o pre-pago (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "10":
                                    dr[i] = "=\"Cuenta de Ahorros (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "20":
                                    dr[i] = "=\"Cuenta Corriente (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "30":
                                    dr[i] = "=\"Cuenta de Tarjeta Crédito (MC) (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "40":
                                    dr[i] = "=\"Línea de Crédito (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "50":
                                    dr[i] = "=\"CTS (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "90":
                                    dr[i] = "=\"Tarjeta de crédito (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                default:
                                    dr[i] = "=\"" + lineas[j].Substring(pos, longitud[i]) + "\"";
                                    break;
                            }
                        }
                        else if (i == 11 || i == 12 || i == 13)
                        {
                            dr[i] = "=\"" + (Double.Parse(lineas[j].Substring(pos, longitud[i])) / 100).ToString("#,###,##0.00") + "\"";
                        }
                        else if (i == 14)
                        {
                            dr[i] = "=\"" + lineas[j].Substring(pos + 2, 2) + "/" + lineas[j].Substring(pos, 2) + "/" + fecha.ToString("yyyy") + "\"";
                        }
                        else if (i == 15 || i == 19)
                        {
                            dr[i] = "=\"" + lineas[j].Substring(pos, 2) + ":" + lineas[j].Substring(pos + 2, 2) + ":" + lineas[j].Substring(pos + 4, 2) + "\"";
                        }
                        else if (i == 20 || i == 22 || i == 23 || i == 24)
                        {
                            if (lineas[j].Substring(pos, longitud[i]) != "0000")
                                dr[i] = "=\"" + lineas[j].Substring(pos + 2, 2) + "/" + lineas[j].Substring(pos, 2) + "\"";
                            else
                                dr[i] = "=\"\"";
                        }
                        else if (i == 21)
                        {
                            dr[i] = "=\"" + lineas[j].Substring(pos, 2) + "/" + lineas[j].Substring(pos + 2, 2) + "\"";
                        }
                        else if (i == 28)
                        {
                            switch (lineas[j].Substring(pos, longitud[i]))
                            {
                                case "02":
                                    dr[i] = "=\"Red Unicard o Red Interconectada (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                case "14":
                                    dr[i] = "=\"Red MasterCard (" + lineas[j].Substring(pos, longitud[i]) + ")\"";
                                    break;
                                default:
                                    dr[i] = "=\"" + lineas[j].Substring(pos, longitud[i]) + "\"";
                                    break;
                            }
                        }
                        else if (i == 29 || i == 30)
                        {
                            dr[i] = "=\"" + (Double.Parse(lineas[j].Substring(pos + 1, longitud[i] - 1)) / 100).ToString("#,###,##0.00") + "\"";
                        }
                        else if (i == 39 || i == 40 || i == 41)
                        {
                            dr[i] = "=\"" + LookupByNumber(Int32.Parse(lineas[j].Substring(pos, longitud[i]))).Code + "\"";

                        }
                        else if (i == 48 || i == 49 || i == 50 || i == 51)
                        {
                            dr[i] = "=\"" + (Double.Parse(lineas[j].Substring(pos + 1, longitud[i] - 1)) / 100).ToString("#,###,##0.00") + "\"";
                        }
                        else
                        {
                            dr[i] = "=\"" + lineas[j].Substring(pos, longitud[i]) + "\"";
                        }
                        pos += longitud[i];
                    }
                    //TramaCompleta
                    dr[64] = lineas[j];
                    dt.Rows.Add(dr);
                    cantidad++;
                }
            }
            return dt;
        }

        public static void ExportarDataTableCSV(DataTable dt, string name)
        {
            
            string fileName = Directory.GetCurrentDirectory() + "\\" + Path.GetFileNameWithoutExtension(name) + ".csv";

            int cols;

            string[] outputCsv = new string[dt.Rows.Count + 1];
            string columnNames = "";
            cols = dt.Columns.Count;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                columnNames += dt.Columns[i].ColumnName + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
            }
            outputCsv[0] += columnNames;

            //Recorremos el DataTable rellenando la hoja de trabajo
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] != null)
                    {
                        outputCsv[i + 1] += dt.Rows[i][j].ToString().Replace(",", " ") + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                    }
                }
            }
            File.WriteAllLines(fileName, outputCsv, Encoding.UTF8);
            Console.WriteLine(" Se generó el .csv " + fileName);
        }


        public static string GetCurrencySymbol(string currencyCode)
        {
            string symbol = string.Empty;
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            ArrayList Result = new ArrayList();
            foreach (CultureInfo ci in cultures)
            {
                RegionInfo ri = new RegionInfo(ci.LCID);
                if (ri.ISOCurrencySymbol == currencyCode)
                {
                    symbol = ri.CurrencySymbol;
                    return symbol;
                }
            }
            return symbol;
        }

        public static Iso4217Definition LookupByCode(string code)
        {
            return DefinitionCollection.SingleOrDefault(d => d.Code == code.ToUpper()) ?? Iso4217Definition.NotFound();
        }

        public static Iso4217Definition LookupByNumber(int number)
        {
            return DefinitionCollection.SingleOrDefault(d => d.Number == number) ?? Iso4217Definition.NotFound();
        }

        public class Iso4217Definition
        {
            private readonly string _code;
            private readonly int _number;
            private readonly int _minorunit;
            public bool Found { get; set; }
            public string Code { get { return _code; } }
            public int Number { get { return _number; } }
            public int MinorUnit { get { return _minorunit; } }
            private Iso4217Definition() { }
            public Iso4217Definition(string code, int number, int minorunit)
            {
                _code = code;
                _number = number;
                _minorunit = minorunit;
                Found = true;
            }

            public static Iso4217Definition NotFound()
            {
                return new Iso4217Definition { Found = false };
            }
        }

        private static readonly List<Iso4217Definition> DefinitionCollection =
    new List<Iso4217Definition> {
        new Iso4217Definition("AED", 784, 2), new Iso4217Definition("AFN", 971, 2), new Iso4217Definition("ALL", 8, 2),
        new Iso4217Definition("AMD", 51, 2), new Iso4217Definition("ANG", 532, 2), new Iso4217Definition("AOA", 973, 2),
        new Iso4217Definition("ARS", 32, 2), new Iso4217Definition("AUD", 36, 2), new Iso4217Definition("AWG", 533, 2),
        new Iso4217Definition("AZN", 944, 2), new Iso4217Definition("BAM", 977, 2), new Iso4217Definition("BBD", 52, 2),
        new Iso4217Definition("BDT", 50, 2), new Iso4217Definition("BGN", 975, 2), new Iso4217Definition("BHD", 48, 3),
        new Iso4217Definition("BIF", 108, 0), new Iso4217Definition("BMD", 60, 2), new Iso4217Definition("BND", 96, 2),
        new Iso4217Definition("BOB", 68, 2), new Iso4217Definition("BOV", 984, 2), new Iso4217Definition("BRL", 986, 2),
        new Iso4217Definition("BSD", 44, 2), new Iso4217Definition("BTN", 64, 2), new Iso4217Definition("BWP", 72, 2),
        new Iso4217Definition("BYR", 974, 0), new Iso4217Definition("BZD", 84, 2), new Iso4217Definition("CAD", 124, 2),
        new Iso4217Definition("CDF", 976, 2), new Iso4217Definition("CHE", 947, 2), new Iso4217Definition("CHF", 756, 2),
        new Iso4217Definition("CHW", 948, 2), new Iso4217Definition("CLF", 990, 0), new Iso4217Definition("CLP", 152, 0),
        new Iso4217Definition("CNY", 156, 2), new Iso4217Definition("COP", 170, 2), new Iso4217Definition("COU", 970, 2),
        new Iso4217Definition("CRC", 188, 2), new Iso4217Definition("CUC", 931, 2), new Iso4217Definition("CUP", 192, 2),
        new Iso4217Definition("CVE", 132, 0), new Iso4217Definition("CZK", 203, 2), new Iso4217Definition("DJF", 262, 0),
        new Iso4217Definition("DKK", 208, 2), new Iso4217Definition("DOP", 214, 2), new Iso4217Definition("DZD", 12, 2),
        new Iso4217Definition("EGP", 818, 2), new Iso4217Definition("ERN", 232, 2), new Iso4217Definition("ETB", 230, 2),
        new Iso4217Definition("EUR", 978, 2), new Iso4217Definition("FJD", 242, 2), new Iso4217Definition("FKP", 238, 2),
        new Iso4217Definition("GBP", 826, 2), new Iso4217Definition("GEL", 981, 2), new Iso4217Definition("GHS", 936, 2),
        new Iso4217Definition("GIP", 292, 2), new Iso4217Definition("GMD", 270, 2), new Iso4217Definition("GNF", 324, 0),
        new Iso4217Definition("GTQ", 320, 2), new Iso4217Definition("GYD", 328, 2), new Iso4217Definition("HKD", 344, 2),
        new Iso4217Definition("HNL", 340, 2), new Iso4217Definition("HRK", 191, 2), new Iso4217Definition("HTG", 332, 2),
        new Iso4217Definition("HUF", 348, 2), new Iso4217Definition("IDR", 360, 2), new Iso4217Definition("ILS", 376, 2),
        new Iso4217Definition("INR", 356, 2), new Iso4217Definition("IQD", 368, 3), new Iso4217Definition("IRR", 364, 0),
        new Iso4217Definition("ISK", 352, 0), new Iso4217Definition("JMD", 388, 2), new Iso4217Definition("JOD", 400, 3),
        new Iso4217Definition("JPY", 392, 0), new Iso4217Definition("KES", 404, 2), new Iso4217Definition("KGS", 417, 2),
        new Iso4217Definition("KHR", 116, 2), new Iso4217Definition("KMF", 174, 0), new Iso4217Definition("KPW", 408, 0),
        new Iso4217Definition("KRW", 410, 0), new Iso4217Definition("KWD", 414, 3), new Iso4217Definition("KYD", 136, 2),
        new Iso4217Definition("KZT", 398, 2), new Iso4217Definition("LAK", 418, 0), new Iso4217Definition("LBP", 422, 0),
        new Iso4217Definition("LKR", 144, 2), new Iso4217Definition("LRD", 430, 2), new Iso4217Definition("LSL", 426, 2),
        new Iso4217Definition("LTL", 440, 2), new Iso4217Definition("LVL", 428, 2), new Iso4217Definition("LYD", 434, 3),
        new Iso4217Definition("MAD", 504, 2), new Iso4217Definition("MDL", 498, 2), new Iso4217Definition("MGA", 969, 2),
        new Iso4217Definition("MKD", 807, 0), new Iso4217Definition("MMK", 104, 0), new Iso4217Definition("MNT", 496, 2),
        new Iso4217Definition("MOP", 446, 2), new Iso4217Definition("MRO", 478, 2), new Iso4217Definition("MUR", 480, 2),
        new Iso4217Definition("MVR", 462, 2), new Iso4217Definition("MWK", 454, 2), new Iso4217Definition("MXN", 484, 2),
        new Iso4217Definition("MXV", 979, 2), new Iso4217Definition("MYR", 458, 2), new Iso4217Definition("MZN", 943, 2),
        new Iso4217Definition("NAD", 516, 2), new Iso4217Definition("NGN", 566, 2), new Iso4217Definition("NIO", 558, 2),
        new Iso4217Definition("NOK", 578, 2), new Iso4217Definition("NPR", 524, 2), new Iso4217Definition("NZD", 554, 2),
        new Iso4217Definition("OMR", 512, 3), new Iso4217Definition("PAB", 590, 2), new Iso4217Definition("PEN", 604, 2),
        new Iso4217Definition("PGK", 598, 2), new Iso4217Definition("PHP", 608, 2), new Iso4217Definition("PKR", 586, 2),
        new Iso4217Definition("PLN", 985, 2), new Iso4217Definition("PYG", 600, 0), new Iso4217Definition("QAR", 634, 2),
        new Iso4217Definition("RON", 946, 2), new Iso4217Definition("RSD", 941, 2), new Iso4217Definition("RUB", 643, 2),
        new Iso4217Definition("RWF", 646, 0), new Iso4217Definition("SAR", 682, 2), new Iso4217Definition("SBD", 90, 2),
        new Iso4217Definition("SCR", 690, 2), new Iso4217Definition("SDG", 938, 2), new Iso4217Definition("SEK", 752, 2),
        new Iso4217Definition("SGD", 702, 2), new Iso4217Definition("SHP", 654, 2), new Iso4217Definition("SLL", 694, 0),
        new Iso4217Definition("SOS", 706, 2), new Iso4217Definition("SRD", 968, 2), new Iso4217Definition("SSP", 728, 2),
        new Iso4217Definition("STD", 678, 0), new Iso4217Definition("SYP", 760, 2), new Iso4217Definition("SZL", 748, 2),
        new Iso4217Definition("THB", 764, 2), new Iso4217Definition("TJS", 972, 2), new Iso4217Definition("TMT", 934, 2),
        new Iso4217Definition("TND", 788, 3), new Iso4217Definition("TOP", 776, 2), new Iso4217Definition("TRY", 949, 2),
        new Iso4217Definition("TTD", 780, 2), new Iso4217Definition("TWD", 901, 2), new Iso4217Definition("TZS", 834, 2),
        new Iso4217Definition("UAH", 980, 2), new Iso4217Definition("UGX", 800, 2), new Iso4217Definition("USD", 840, 2),
        new Iso4217Definition("USN", 997, 2), new Iso4217Definition("USS", 998, 2), new Iso4217Definition("UYI", 940, 0),
        new Iso4217Definition("UYU", 858, 2), new Iso4217Definition("UZS", 860, 2), new Iso4217Definition("VEF", 937, 2),
        new Iso4217Definition("VND", 704, 0), new Iso4217Definition("VUV", 548, 0), new Iso4217Definition("WST", 882, 2),
        new Iso4217Definition("XAF", 950, 0), new Iso4217Definition("XCD", 951, 2), new Iso4217Definition("XOF", 952, 0),
        new Iso4217Definition("XPF", 953, 0), new Iso4217Definition("YER", 886, 2), new Iso4217Definition("ZAR", 710, 2),
        new Iso4217Definition("ZMW", 967, 2)
    };

    }
}
