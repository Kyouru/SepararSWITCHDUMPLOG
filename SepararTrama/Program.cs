using System;
using System.Collections.Generic;
using System.Data;
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
            dt.Columns.Add("STFWD Descripcion");
            dt.Columns.Add("Primary Account Number");
            dt.Columns.Add("Processing Code");
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
            longitud[7] = 0;
            longitud[8] = 19;
            longitud[9] = 6;
            longitud[10] = 12;
            longitud[11] = 12;
            longitud[12] = 12;
            longitud[13] = 4;
            longitud[14] = 6;
            longitud[15] = 8;
            longitud[16] = 8;
            longitud[17] = 6;
            longitud[18] = 6;
            longitud[19] = 4;
            longitud[20] = 4;
            longitud[21] = 4;
            longitud[22] = 4;
            longitud[23] = 4;
            longitud[24] = 4;
            longitud[25] = 3;
            longitud[26] = 3;
            longitud[27] = 2;
            longitud[28] = 9;
            longitud[29] = 9;
            longitud[30] = 11;
            longitud[31] = 11;
            longitud[32] = 37;
            longitud[33] = 12;
            longitud[34] = 6;
            longitud[35] = 3;
            longitud[36] = 8;
            longitud[37] = 40;
            longitud[38] = 3;
            longitud[39] = 3;
            longitud[40] = 3;
            longitud[41] = 4;
            longitud[42] = 6;
            longitud[43] = 4;
            longitud[44] = 6;
            longitud[45] = 11;
            longitud[46] = 11;
            longitud[47] = 12;
            longitud[48] = 12;
            longitud[49] = 9;
            longitud[50] = 9;
            longitud[51] = 25;
            longitud[52] = 11;
            longitud[53] = 29;
            longitud[54] = 29;
            longitud[55] = 2;
            longitud[56] = 20;
            longitud[57] = 3;
            longitud[58] = 3;
            longitud[59] = 2;
            longitud[60] = 9;
            longitud[61] = 22;
            longitud[62] = 15;
            //longitud[62] = 2;

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
                        if (i == 13)
                        {
                            dr[i] = "=\"" + lineas[j].Substring(pos + 2, 2) + "/" + lineas[j].Substring(pos, 2) + "/" + fecha.ToString("yyyy") + "\"";
                        }
                        else if (i == 10 || i == 11 || i == 12)
                        {
                            dr[i] = "=\"" + (Double.Parse(lineas[j].Substring(pos, longitud[i]))/100).ToString("#,###,##0.00") + "\"";
                        }
                        else if (i == 14 || i == 18)
                        {
                            dr[i] = "=\"" + lineas[j].Substring(pos, 2) + ":" + lineas[j].Substring(pos + 2, 2) + ":" + lineas[j].Substring(pos + 4, 2) + "\"";
                        }
                        else if (i == 19 || i == 21 || i == 22 || i == 23)
                        {
                            dr[i] = "=\"" + lineas[j].Substring(pos + 2, 2) + "/" + lineas[j].Substring(pos, 2) + "\"";
                        }
                        else if (i == 8)
                        {
                            dr[i] = "=\"" + lineas[j].Substring(pos + 3, longitud[i] - 3) + "\"";
                        }
                        else if (i == 20)
                        {
                            dr[i] = "=\"" + lineas[j].Substring(pos, 2) + "/" + lineas[j].Substring(pos + 2, 2) + "\"";
                        }
                        else if (i == 7)
                        {
                            if (lineas[j].Substring(15, 1) == "C")
                            {
                                dr[i] = "=\"Institución respondió\"";
                            }
                            else
                            {
                                dr[i] = "=\"UNIBANCA respondió\"";
                            }
                        }
                        else
                        {
                            dr[i] = "=\"" + lineas[j].Substring(pos, longitud[i]) + "\"";
                        }
                        pos += longitud[i];
                    }
                    //TramaCompleta
                    dr[63] = lineas[j];
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

    }
}
