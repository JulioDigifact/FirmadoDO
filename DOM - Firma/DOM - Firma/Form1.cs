using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json.Nodes;
using System.Xml;
using dom.digifact.com.FEConstruct;
using Newtonsoft.Json;

namespace DOM___Firma
{
    public partial class Form1 : Form
    {
        public X509Certificate2 certificado;
        public string ambiente = "1";
        string path = @"C:\Users\julio.cifuentes\Downloads\310109496104 (2).p12";
        string pass = "2501";
        //string path = @"C:\Users\julio.cifuentes\OneDrive\Documents\NUC Transformer\COSTA RICA FE\firma productivo\310289141813.p12";
        //string pass = "2014";
        string b64Cert = "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";
        string b64pass = "Squareone2015";
        string certPath = "";
        string certPass = "";
        string token = "";

        public Form1()
        {
            InitializeComponent();
            CargarCertificado(path, pass);
            //cargarCertificadoB64();
            CargarDatos();
            //firmarDocs();
            //firmarDocsEspecial();
            //ExportarCertificado(); // para obtener el certificado en base64
            //TestDLL_DO();
            //buscarYGenerarQuery();
            //ExportarCertPanama();
        }

        public void cargarCertificadoB64()
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(b64Cert);
                this.certificado = new X509Certificate2(bytes, b64pass);

                label4.Text = "Status: Certificado cargado correctamente";
                label4.ForeColor = Color.Green;
            }
            catch (Exception e)
            {
                label4.Text = "Status: Error al cargar el certificado";
                label4.ForeColor = Color.Red;
            }
        }

        public void ExportarCertificado()
        {
            var certificate = new X509Certificate2(path, pass);
            // Get the public key from the certificate
            //var publicKey = certificate.GetPublicKey();
            // Get the encoded certificate data (DER format)
            //var encodedCert = certificate.GetRawCertData();
            // Convert the encoded certificate data to Base64 for display or transmission
            //var base64Cert = Convert.ToBase64String(encodedCert);
            string datosAGuardar = "";
            datosAGuardar += string.Format("Subject: {0}\n", certificate.Subject);
            datosAGuardar += string.Format("SubjectName: {0}\n", certificate.SubjectName.Name);
            datosAGuardar += string.Format("ValidFrom: {0}\n", certificate.NotBefore.ToString("yyyy-MM-dd HH:mm:ss"));
            datosAGuardar += string.Format("ValidTo: {0}\n", certificate.NotAfter.ToString("yyyy-MM-dd HH:mm:ss"));
            datosAGuardar += string.Format("Clave Certificado: {0}\n", pass);
            Chilkat.BinData bd = new Chilkat.BinData();
            bool success1 = bd.LoadFile(path);
            datosAGuardar += string.Format("Certificado: {0}\n", bd.GetEncoded("base64"));
            //string pfxbase = bd.GetEncoded("base64");
            string rutaArchivo = string.Format(@"C:\Users\julio.cifuentes\Downloads\certificadob64_{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss"));
            File.WriteAllText(rutaArchivo, datosAGuardar);
        }

        public void ExportarCertPanama()
        {
            string b6444 = "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";
            string passs = "Oa1ks82&";
            // convertir base64 a arreglo de bytes
            byte[] bytes = System.Convert.FromBase64String(b6444);

            var certificate = new X509Certificate2(bytes, passs);
            // Get the public key from the certificate
            var publicKey = certificate.GetPublicKey();
            // Get the encoded certificate data (DER format)
            var encodedCert = certificate.GetRawCertData();
            // Convert the encoded certificate data to Base64 for display or transmission
            var base64Cert = Convert.ToBase64String(encodedCert);

        }

        public void CargarDatos()
        {
            Dictionary<int, string> datos = new Dictionary<int, string>
            {
                { 1, "Pre-certificacion" },
                { 2, "Certificacion" },
                { 3, "Productivo" }
            };

            comboBox1.DataSource = new BindingSource(datos, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarCertificado(string path, string pass)
        {
            try
            {
                Chilkat.BinData bd = new Chilkat.BinData();
                bool success1 = bd.LoadFile(path);
                string pfxbase = bd.GetEncoded("base64");

               certificado = new X509Certificate2(path, pass);
                //string certificadob64 = Convert.ToBase64String(certificado.RawData);
                //var base64cert = Convert.ToBase64String(encodedCert);
                //string rutaArchivo = @"C:\Users\julio.cifuentes\Desktop\BACKUP\NUC Transformer\REPUBLICA DOMINICANA FE\Certificado\certificadob64.txt";
                //File.WriteAllText(rutaArchivo, pfxbase);

                label4.Text = "Status: Certificado cargado correctamente";
                label4.ForeColor = Color.Green;
            }
            catch (Exception e)
            {
                label4.Text = "Status: Error al cargar el certificado";
                label4.ForeColor = Color.Red;
            }

        }

        public XmlDocument firmarXML(XmlDocument xmlDoc, X509Certificate2 cert)
        {
            var llavePrivada = cert.GetRSAPrivateKey();
            SignedXml xmlFirmado = new SignedXml(xmlDoc);
            xmlFirmado.SigningKey = llavePrivada;
            Reference reference = new Reference();
            reference.Uri = "";
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform(true);
            reference.AddTransform(env);

            xmlFirmado.AddReference(reference);

            // creamos un keyInfo object
            KeyInfo keyInfo = new KeyInfo();
            KeyInfoX509Data clause = new KeyInfoX509Data();
            // opcionalmente se podria agregar el Subject del certificado
            // clause.AddSubjectName(cert.Subject)
            clause.AddCertificate(cert);
            keyInfo.AddClause(clause);

            xmlFirmado.KeyInfo = keyInfo;
            xmlFirmado.ComputeSignature();
            XmlElement xmlFirmaDigital = xmlFirmado.GetXml();

            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlFirmaDigital, true));
            return xmlDoc;
        }

        public string firmarXML2(string location, string xmlNativo)
        {
            string gen_beh = "CompactSignedXml";
            Chilkat.Global glob = new Chilkat.Global();
            glob.UnlockBundle("DGFACT.CB4112020_k84dzybP1R6x");

            Chilkat.Cert cert = new Chilkat.Cert();
            Chilkat.Pfx pfx = new Chilkat.Pfx();
            bool success = pfx.LoadPfxFile(path, pass);
            if (!success) { return ""; }

            cert = pfx.GetCert(0);

            Chilkat.StringBuilder sbXml = new Chilkat.StringBuilder();
            success = sbXml.Append(xmlNativo);

            Chilkat.XmlDSigGen gen = new Chilkat.XmlDSigGen();

            gen.SigLocation = location;

            gen.SigNamespacePrefix = "";
            //gen.SignedInfoCanonAlg = "EXCL_C14N";
            gen.SignedInfoCanonAlg = "EXCL_C14N_WithComments";
            gen.SignedInfoDigestMethod = "sha256";

            Chilkat.Xml xml = new Chilkat.Xml();
            xml.Tag = "xades:QualifyingProperties";
            xml.AddAttribute("xmlns:xades", "http://uri.etsi.org/01903/v1.3.2#");
            xml.UpdateChildContent("xades:SignedProperties|xades:SignedSignatureProperties|xades:SigningTime", "TO BE GENERATED BY CHILKAT");
            xml.UpdateAttrAt("xades:SignedProperties|xades:SignedSignatureProperties|xades:SigningCertificate|xades:Cert|xades:CertDigest|ds:DigestMethod", true, "Algorithm", "http://www.w3.org/2001/04/xmlenc#sha256");
            xml.UpdateChildContent("xades:SignedProperties|xades:SignedSignatureProperties|xades:SigningCertificate|xades:Cert|xades:CertDigest|ds:DigestValue", "TO BE GENERATED BY CHILKAT");
            xml.UpdateChildContent("xades:SignedProperties|xades:SignedSignatureProperties|xades:SigningCertificate|xades:Cert|xades:IssuerSerial|ds:X509IssuerName", "TO BE GENERATED BY CHILKAT");
            xml.UpdateChildContent("xades:SignedProperties|xades:SignedSignatureProperties|xades:SigningCertificate|xades:Cert|xades:IssuerSerial|ds:X509SerialNumber", "TO BE GENERATED BY CHILKAT");
            //////xml.UpdateChildContent("xades:SignedProperties|xades:SignedSignatureProperties|xades:SignaturePolicyIdentifier|xades:SignaturePolicyId|xades:SigPolicyId|xades:Identifier", "https://portal.sat.gob.gt/portal/descarga/6524/factura-electronica-fel/25559/gt-documento-0-1-0.pdf");
            /////xml.UpdateChildContent("xades:SignedProperties|xades:SignedSignatureProperties|xades:SignaturePolicyIdentifier|xades:SignaturePolicyId|xades:SigPolicyId|xades:Description", "");
            ////xml.UpdateAttrAt("xades:SignedProperties|xades:SignedSignatureProperties|xades:SignaturePolicyIdentifier|xades:SignaturePolicyId|xades:SigPolicyHash|ds:DigestMethod", true, "Algorithm", "http://www.w3.org/2001/04/xmlenc#sha256");
            ////xml.UpdateChildContent("xades:SignedProperties|xades:SignedSignatureProperties|xades:SignaturePolicyIdentifier|xades:SignaturePolicyId|xades:SigPolicyHash|ds:DigestValue", "NmI5Njk1ZThkNzI0MmIzMGJmZDAyNDc4YjUwNzkzODM2NTBiOWUxNTBkMmI2YjgzYzZjM2I5NTZlNDQ4OWQzMQ==");
            //xml.UpdateAttrAt("xades:SignedProperties|xades:SignedDataObjectProperties|xades:DataObjectFormat", true, "ObjectReference", "#Reference-" + uuidDATOSEMISIONREFERENCE);
            xml.UpdateChildContent("xades:SignedProperties|xades:SignedDataObjectProperties|xades:DataObjectFormat|xades:MimeType", "text/xml");
            xml.UpdateChildContent("xades:SignedProperties|xades:SignedDataObjectProperties|xades:DataObjectFormat|xades:Encoding", "UTF-8");

            gen.AddSameDocRef("", "sha256", "EXCL_C14N", "", "");

            gen.Behaviors = gen_beh;
            success = gen.SetX509Cert(cert, true);
            if (!success)
            {
                return "";
            }
            // Provide the KeyInfo information.
            gen.KeyInfoType = "X509Data";
            gen.X509Type = "Certificate";

            gen.Behaviors = gen_beh;

            success = gen.CreateXmlDSigSb(sbXml);
            if (!success) { return ""; }

            string firmado = sbXml.GetAsString();
            return firmado;

        }

        public void TestDLL_DO()
        {
            dom.digifact.com.FEConstruct.FE_OPERACIONES.GET_ANECF_XML xmlANECF = new dom.digifact.com.FEConstruct.FE_OPERACIONES.GET_ANECF_XML();
            dom.digifact.com.FEConstruct.FE_CLASES.ANECF.DATOS_ENCABEZADO datosEncabezado = new dom.digifact.com.FEConstruct.FE_CLASES.ANECF.DATOS_ENCABEZADO();
            List<dom.digifact.com.FEConstruct.FE_CLASES.ANECF.DATOS_ANULACION> listaDatosAnulacion = new List<dom.digifact.com.FEConstruct.FE_CLASES.ANECF.DATOS_ANULACION>();
            // DATOS GENERALES
            datosEncabezado.FechaHoraAnulacion = DateTime.Now;
            datosEncabezado.RncEmisor = "132752155";
            datosEncabezado.Version = "1.0";
            // DATOS DE ANULACION
            dom.digifact.com.FEConstruct.FE_CLASES.ANECF.DATOS_ANULACION datoAnulacion1 = new dom.digifact.com.FEConstruct.FE_CLASES.ANECF.DATOS_ANULACION();
            datoAnulacion1.Lineas = new List<string>
            {
                "1"
            }; // lista de lineas ??
            datoAnulacion1.TipoeCF = "32";
            datoAnulacion1.Secuencias = new List<dom.digifact.com.FEConstruct.FE_CLASES.ANECF.DATOS_SECUENCIAS>
            {
                new dom.digifact.com.FEConstruct.FE_CLASES.ANECF.DATOS_SECUENCIAS
                {
                    Desde = "E310000000001",
                    Hasta = "E310000000010"
                },
                new dom.digifact.com.FEConstruct.FE_CLASES.ANECF.DATOS_SECUENCIAS
                {
                    Desde = "E310000000015",
                    Hasta = "E310000000020"
                }
            };

            listaDatosAnulacion.Add(datoAnulacion1);

            string xml = xmlANECF.GET_ANECF(datosEncabezado, listaDatosAnulacion);
            if (xmlANECF.LastError != "") {  }
        }

        /// <summary>
        /// firma y crea el script para guardar en base de datos
        /// </summary>
        public void firmarDocs()
        {
            string b64Payless = "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";
            string passPayless = "Retail2024";

            // leer archivo csv donde estara en base64 cada xml
            byte[] bytes = Convert.FromBase64String(b64Payless);
            this.certificado = new X509Certificate2(bytes, passPayless);

            string rutaCsv = "C:\\Users\\julio.cifuentes\\Documents\\DO Varios\\firmar 20240702\\";
            string fileName = "archivo";
            var lines = File.ReadAllLines(rutaCsv + fileName + ".csv");

            //string resultados = "";
            string sqlQuery = "";

            foreach (var line in lines)
            {
                /**
                * pos 0 -> staxid
                * pos 1 -> documentGUID
                * pos 2 -> signed xml modificado
                */
                var stringArr = line.Split(",");
                string xmlPuro = Encoding.UTF8.GetString(Convert.FromBase64String(stringArr[2]));
                string firmado = firmarXMLString(xmlPuro);
                var bytes2 = System.Text.Encoding.UTF8.GetBytes(firmado);
                string signedB64 = System.Convert.ToBase64String(bytes2);

                sqlQuery += String.Format("update FeStore2024_06.dbo.store set signedxml = '{0}' where staxid = '{1}' and documentguid = '{2}'\n", signedB64, stringArr[0], stringArr[1]);
            }
            string repName = "report_" + fileName;
            //File.WriteAllText(rutaCsv + repName + ".csv", resultados);
            File.WriteAllText(rutaCsv + repName + ".sql", sqlQuery);
        }




        /// <summary>
        /// firma y certifica documentos al asmx
        /// usado para cambiar el codigo de encf, modificar el xml y firmar nuevamente para certificar otra vez
        /// </summary>
        public void firmarDocsEspecial()
        {
            string b64Payless = "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";
            string passPayless = "carolin5684";

            // leer archivo csv donde estara en base64 cada xml
            byte[] bytes = Convert.FromBase64String(b64Payless);
            this.certificado = new X509Certificate2(bytes, passPayless);

            string rutaCsv = "C:\\Users\\julio.cifuentes\\OneDrive\\Documents\\DO Varios\\Refirmado de docs\\20250129\\";
            string fileName = "archivo4";
            var lines = File.ReadAllLines(rutaCsv + fileName + ".csv");
            string Requestor = "9E964600-CDCD-4598-B2BD-04E2C480C6D2";
            string Entity = "112002152";
            string Username = "112002152";

            string resultados = "";
            string sqlQuery = "";

            foreach(var line in lines)
            {
                /**
                * pos 0 -> secuencia antigua
                * pos 1 -> secuencia nueva
                * pos 2 -> signed xml modificado
                * pos 3 -> fechamodificado ??? no viene, revisar el csv
                */
                var stringArr = line.Split(",");
                string xmlPuro = Encoding.UTF8.GetString(Convert.FromBase64String(stringArr[2]));
                string nuevaSec = stringArr[1];
                //string firmado = firmarXMLString(xmlPuro);
                string firmado = firmarXMLStringEspecialFecha(xmlPuro, stringArr[3]);
                var bytes2 = System.Text.Encoding.UTF8.GetBytes(firmado);
                string signedB64 = System.Convert.ToBase64String(bytes2);

                // enviar a ASMX directamente ?
                FEWSDO.FEWSFRONTSoapClient conexion = new FEWSDO.FEWSFRONTSoapClient(FEWSDO.FEWSFRONTSoapClient.EndpointConfiguration.FEWSFRONTSoap12, "https://cert.digifact.com.do/Fewsfront.asmx");
                FEWSDO.TransactionTag tag = new FEWSDO.TransactionTag();

                tag = conexion.RequestTransactionAsync(Requestor, "CERTIFICATE_FE", "DO", Entity, Requestor, Username, firmado, "", "").Result;

                if (tag.Response.Result)
                {
                    resultados += String.Format("{0},{1},{2},{3}\n", tag.Response.Code, nuevaSec, tag.Response.Identifier.DocumentGUID.ToUpper(), tag.Response.Description);
                    sqlQuery += String.Format("update [FeStore2023_12_02].[dbo].[tempFIXNCF_04] set ESTADO = '{0}', SIGNEDXMLMODIFICADO='{1}' where ESEC = '{2}'\n", "PROCESADO", signedB64, stringArr[0]);
                }
                else
                {
                    resultados += String.Format("{0},{1},{2},{3}\n", tag.Response.Code, nuevaSec, "", tag.Response.Data.Replace("\n", ""));
                    sqlQuery += String.Format("update [FeStore2023_12_02].[dbo].[tempFIXNCF_04] set ESTADO = '{0}', SIGNEDXMLMODIFICADO='{1}' where ESEC = '{2}'\n", "RECHAZADO", signedB64, stringArr[0]);
                    //sqlQuery += String.Format("update [FeStore2023_12_02].[dbo].[tempFIXNCF_02] set ESTADO = '{0}' where ESEC = '{1}'\n", "RECHAZADO", stringArr[0]);
                }
            }
            string repName = "report_"+fileName;
            File.WriteAllText(rutaCsv + repName + ".csv", resultados);
            File.WriteAllText(rutaCsv + repName + ".sql", sqlQuery);
        }


        public void buscarYGenerarQuery()
        {
            // leer cada archivo xml que se encuentra en una carpeta y obtener el valor de eNCF, luego generar un update para cambiar el valor de eNCF
            string ruta = "C:\\Users\\julio.cifuentes\\OneDrive - Digifact\\Documents\\DO Varios\\XML_reenviados_dgii\\132522885\\";
            string[] files = Directory.GetFiles(ruta, "*.xml");
            string sqlQuery = "";
            foreach (string file in files)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);
                var nodoENCF = xmlDoc.SelectSingleNode("/ECF/Encabezado/IdDoc/eNCF");
                var staxid = xmlDoc.SelectSingleNode("/ECF/Encabezado/Emisor/RNCEmisor");
                string authnumber = nodoENCF.InnerText;
                string rnc = staxid.InnerText;
                
                // convertir xml a base64
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(xmlDoc.OuterXml);
                string xmlbase64 = System.Convert.ToBase64String(bytes);
                string updateQuery = String.Format("update [FeStore2025_03].[dbo].[Store] set SignedXML = '{0}' where STaxid = '{1}' and Authnumber = '{2}';\n", xmlbase64, rnc, authnumber);
                sqlQuery += updateQuery;
            }
            File.WriteAllText(ruta + "query.sql", sqlQuery);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && certificado != null)
            {
                string cadena = richTextBox1.Text.Replace("\v", "");
                richTextBox1.Text = firmarXMLString(cadena);
                //string firmado = firmarXML2(sigLocation, xmlDoc.OuterXml);
                //richTextBox1.Text = firmado;
            }
            else
            {
                MessageBox.Show("Agregar texto del xml a firmar o verificar ruta del certificado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        public string firmarXMLString(string xml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            var child = xmlDoc.DocumentElement;
            if (child == null) { return ""; }
            string sigLocation = child.Name;
            var nodoECF = xmlDoc.SelectSingleNode("/ECF");
            sigLocation = "ECF";
            if (nodoECF != null)
            {
                var nodoFechaHoraFirma = xmlDoc.SelectSingleNode("/ECF/FechaHoraFirma");
                if (nodoFechaHoraFirma == null)
                {
                    XmlNode root = xmlDoc.DocumentElement;
                    XmlElement elem = xmlDoc.CreateElement("FechaHoraFirma");
                    elem.InnerText = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    root.AppendChild(elem);
                }
                else
                {
                    nodoFechaHoraFirma.InnerText = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                }
                //else { sigLocation = nodoECF.Name; }

                // quitar nodo signature si existe
                var nodoSignature = nodoECF.LastChild;
                if (nodoSignature != null) 
                {
                    nodoECF.RemoveChild(nodoSignature);
                }
                
                string pruebaXML = xmlDoc.OuterXml;
            }

            xmlDoc = firmarXML(xmlDoc, certificado);
            return xmlDoc.OuterXml;
        }

        /// <summary>
        /// metodo para modificar y firmar notas de credito el 2025-01-15
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="modificarNC"></param>
        /// <returns></returns>
        public string firmarXMLStringEspecial(string xml, string nuevaSecuencia)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            var child = xmlDoc.DocumentElement;
            if (child == null) { return ""; }
            string sigLocation = child.Name;
            var nodoECF = xmlDoc.SelectSingleNode("/ECF");
            sigLocation = "ECF";
            if (nodoECF != null)
            {
                var nodoFechaHoraFirma = xmlDoc.SelectSingleNode("/ECF/FechaHoraFirma");
                if (nodoFechaHoraFirma == null)
                {
                    XmlNode root = xmlDoc.DocumentElement;
                    XmlElement elem = xmlDoc.CreateElement("FechaHoraFirma");
                    elem.InnerText = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    root.AppendChild(elem);
                }
                else
                {
                    nodoFechaHoraFirma.InnerText = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                }
                //else { sigLocation = nodoECF.Name; }

                // modificar datos de nota de credito
                var nodoENCFModificado = xmlDoc.SelectSingleNode("/ECF/Encabezado/IdDoc/eNCF");
                nodoENCFModificado.InnerText = nuevaSecuencia;
                // obtener el nodo ubicado en /ECF/InformacionReferencia/CodigoModificacion
                var nodoCodigoModificacion = xmlDoc.SelectSingleNode("/ECF/InformacionReferencia/CodigoModificacion");
                //var nodoCodigoModificacion = xmlDoc.SelectSingleNode("/ECF/InformacionReferencia/CodigoModificacion");
                nodoCodigoModificacion.InnerText = "3";


                // quitar nodo signature si existe
                var nodoSignature = nodoECF.LastChild;
                if (nodoSignature != null)
                {
                    nodoECF.RemoveChild(nodoSignature);
                }

                string pruebaXML = xmlDoc.OuterXml;
            }

            xmlDoc = firmarXML(xmlDoc, certificado);
            return xmlDoc.OuterXml;
        }


        public string firmarXMLStringEspecialFecha(string xml, string fechaemisionref)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            var child = xmlDoc.DocumentElement;
            if (child == null) { return ""; }
            string sigLocation = child.Name;
            var nodoECF = xmlDoc.SelectSingleNode("/ECF");
            sigLocation = "ECF";
            if (nodoECF != null)
            {
                var nodoFechaHoraFirma = xmlDoc.SelectSingleNode("/ECF/FechaHoraFirma");
                if (nodoFechaHoraFirma == null)
                {
                    XmlNode root = xmlDoc.DocumentElement;
                    XmlElement elem = xmlDoc.CreateElement("FechaHoraFirma");
                    elem.InnerText = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    root.AppendChild(elem);
                }
                else
                {
                    nodoFechaHoraFirma.InnerText = "25-11-2025 16:05:57";//DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                }
                //else { sigLocation = nodoECF.Name; }

                // obtener el nodo ubicado en /ECF/InformacionReferencia/CodigoModificacion
                var nodoCodigoModificacion = xmlDoc.SelectSingleNode("/ECF/InformacionReferencia/FechaNCFModificado");
                //var nodoCodigoModificacion = xmlDoc.SelectSingleNode("/ECF/InformacionReferencia/CodigoModificacion");
                
                DateTime.TryParse(fechaemisionref, out DateTime fechaNCFModificado);
                nodoCodigoModificacion.InnerText = fechaNCFModificado.ToString("dd-MM-yyyy");


                // quitar nodo signature si existe
                var nodoSignature = nodoECF.LastChild;
                if (nodoSignature != null)
                {
                    nodoECF.RemoveChild(nodoSignature);
                }

                string pruebaXML = xmlDoc.OuterXml;
            }

            xmlDoc = firmarXML(xmlDoc, certificado);
            return xmlDoc.OuterXml;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            openFileDialog1.DefaultExt = "xml";
            openFileDialog1.Filter = "Archivo XML (.xml)|*.xml";
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();

            string rutaArchivo = openFileDialog1.FileName;
            if (!File.Exists(rutaArchivo)) { MessageBox.Show("No se ha seleccionado el archivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string fileContent = File.ReadAllText(rutaArchivo);
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(fileContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer archivo, " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            xmlDoc = firmarXML(xmlDoc, this.certificado);

            richTextBox1.Text = xmlDoc.OuterXml;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string xmlSemilla = ObtenerSemilla();
            if (xmlSemilla == "") { MessageBox.Show("Error al obtener XML semilla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlSemilla);
            XmlDocument xmlSemillaFirmado = firmarXML(xmlDoc, this.certificado);
            string semillaFirmado = xmlSemillaFirmado.OuterXml;

            ValidarSemilla(semillaFirmado);
        }


        public string ObtenerSemilla()
        {
            string tipoAmbiente;
            if (this.ambiente == "2") { tipoAmbiente = "CerteCF"; }
            else if (this.ambiente == "3") { tipoAmbiente = "eCF"; }
            else { tipoAmbiente = "TesteCF"; }
            string url = String.Format("https://eCF.dgii.gov.do/{0}/Autenticacion/api/Autenticacion/Semilla", tipoAmbiente);

            HttpClient httpClient = new HttpClient();
            var result = httpClient.GetAsync(url).Result;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string xml = result.Content.ReadAsStringAsync().Result;
                return xml;
            }
            else
            {
                return "";
            }
        }

        public void ValidarSemilla(string semillaFirmada)
        {
            string tipoAmbiente;
            if (this.ambiente == "2") { tipoAmbiente = "CerteCF"; }
            else if (this.ambiente == "3") { tipoAmbiente = "eCF"; }
            else { tipoAmbiente = "TesteCF"; }
            string url = String.Format("https://eCF.dgii.gov.do/{0}/Autenticacion/api/Autenticacion/ValidarSemilla", tipoAmbiente);

            var fileContent = new ByteArrayContent(Encoding.ASCII.GetBytes(semillaFirmada));
            //fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/xml");
            var content = new MultipartFormDataContent();
            content.Add(fileContent, "xml", "token.xml");

            HttpClient httpClient = new HttpClient();
            var response = httpClient.PostAsync(url, content).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                if (responseContent == null)
                {
                    MessageBox.Show("Error al leer respuesta de validar semillar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                JsonNode json = JsonObject.Parse(responseContent);
                richTextBox2.Text = json.ToJsonString(new System.Text.Json.JsonSerializerOptions() { WriteIndented = true });
                this.token = json["token"].ToString();
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ambiente = comboBox1.SelectedValue.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // obtener la cadena del richTextBox1 y cargarlo como un XML
            // cargar un xml
            XmlDocument xmlDoc = new XmlDocument();
            string contenido = richTextBox1.Text;
            xmlDoc.LoadXml(contenido);

            // obtener nodo /ECF/Encabezado/IdDoc/eNCF
            var nodoENCF = xmlDoc.SelectSingleNode("/ECF/Encabezado/IdDoc/eNCF");

            DLL_DO_DGII.DLL_DO_DGII consumosDGII = new DLL_DO_DGII.DLL_DO_DGII();

            var resu = consumosDGII.RECEPCION_DGII(DLL_DO_DGII.TIPO_AMBIENTE.PRE_CERTIFICACION, richTextBox1.Text, "132752155", nodoENCF.InnerText, this.token);
            Stopwatch time = new Stopwatch();
            time.Start();
            if (resu.CodigoHttp == 200)
            {
                // consultar n veces hasta que responda, ingresarlo en un ciclo y tomar el tiempo de cuanto se tarda hasta que tenga respuesta
                bool noEncontrado = true;
                while (noEncontrado)
                {
                    var consultaResultado = consumosDGII.CONSULTA_RESULTADO(DLL_DO_DGII.TIPO_AMBIENTE.PRE_CERTIFICACION, resu.ResultRecepcion.trackID, this.token);
                    if (consultaResultado.CodigoHttp == 200)
                    {
                        var json = JsonConvert.SerializeObject(consultaResultado.ResultConsultaResultado, Newtonsoft.Json.Formatting.Indented);
                        time.Stop();
                        // calcular el tiempo en segundos
                        TimeSpan ts = time.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                        noEncontrado = false;
                        richTextBox2.Text = json + "  " +  elapsedTime;
                    }
                }
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog2.DefaultExt = "p12";
            openFileDialog2.Filter = "Certificado (.p12)|*.p12";
            openFileDialog2.Multiselect = false;
            openFileDialog2.ShowDialog();

            this.certPath = openFileDialog2.FileName;
            if (!File.Exists(this.certPath)) { MessageBox.Show("No se ha seleccionado el archivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            MessageBox.Show("Archivo cargado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
        }

        // crear evento para cuando se cambie el texto del textbox
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            this.certPass = txtCertPass.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CargarCertificado(this.certPath, this.certPass);
        }
    }
}