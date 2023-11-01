using OfficeOpenXml;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Xml.Linq;

namespace Convert
{
    public partial class Form1 : Form
    {

        string rutaArchivo;
        string rutaArchivoMapeo;

        List<string> listaElementosDesCifrar;
        List<TextoEstructura> listaTextoEstructura;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFDExcel.ShowDialog() == DialogResult.OK)
            {
                rutaArchivoMapeo = openFDExcel.FileName;

                ElementosCifrar(rutaArchivoMapeo);
                if (listaElementosDesCifrar.Count > 0)
                {
                    MessageBox.Show("Carga de esquema exitoso", "Esquema listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
                //foreach (string item in listaElementosDesCifrar)
                //{
                //    //Console.WriteLine(item);
                //    Debug.WriteLine(item);
                //}

            }
        }

        void ElementosCifrar(string rutaEsquema)
        {

            try
            {
                // Abre el archivo de texto para lectura
                using (StreamReader sr = new StreamReader(rutaEsquema))
                {
                    string linea;

                    TextoEstructura oEstructura;
                    listaTextoEstructura = new List<TextoEstructura>();
                    listaElementosDesCifrar = new List<string>();
                    // Lee y muestra cada línea del archivo
                    while ((linea = sr.ReadLine()) != null)
                    {
                        oEstructura = new TextoEstructura();
                        string[] estructura = linea.Split(';');
                        oEstructura.Elemento = estructura[0];
                        oEstructura.Mascara = estructura[1];
                        oEstructura.Valor = estructura[2];
                        listaTextoEstructura.Add(oEstructura);
                    }

                    var elementos = listaTextoEstructura.GroupBy(x => x.Elemento)
                                         .Select(group => group.First());

                    foreach (TextoEstructura item in elementos)
                    {
                        listaElementosDesCifrar.Add(item.Elemento);
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando elementos {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void button1_Click(object sender, EventArgs e)
        {

            if (openFd.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = openFd.FileName;

                await Task.Run(() =>
                {

                    buscarElmento(rutaArchivo);

                });

                MessageBox.Show("El proceso de descifrado de XML finalizó favor verificar", "Fin del proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //LeerXML(rutaArchivo);

            }

        }

        string? mapearValorCifrado(string valorCifrado, string Elemento)
        {
            string? retornarDecifrado = null;
            var mapeoDatosElemento = listaTextoEstructura.Where(x => x.Elemento == Elemento);
            foreach (TextoEstructura item in mapeoDatosElemento)
            {

                if (valorCifrado.ToUpper().Trim() == item.Mascara.ToUpper().Trim())
                {
                    retornarDecifrado = item.Valor.Trim();
                    break;
                }
            }

            return retornarDecifrado;
        }

        void buscarElmento(string filePath)
        {
            try
            {
                // Carga el archivo XML
                XDocument doc = XDocument.Load(filePath);

                int conteoNoCifrados = 0;
                int conteoCifrados = 0;

                foreach (string ElementosXML in listaElementosDesCifrar)
                {
                    // Realiza una consulta LINQ para buscar todos los elementos con el nombre deseado
                    var elementos = doc.Descendants(ElementosXML);

                    if (elementos.Any())
                    {
                        int registro = 1;
                        string leyenda = string.Empty;

                        foreach (var elemento in elementos)
                        {
                            string textoCifrado = elemento.Value;
                            string? textoDescifrado = mapearValorCifrado(textoCifrado, ElementosXML);
                            if (textoDescifrado != null)
                            {
                                elemento.Value = textoDescifrado;
                                leyenda = $"Registro #{registro} en el elemento {ElementosXML}, se decifra {textoCifrado} por el valor {textoDescifrado}";

                                this.Invoke((Action)(() =>
                                {
                                    conteoCifrados++;
                                    label2.Text = $"Cantidad de elementos descifrados {conteoCifrados}";
                                    listBox2.Items.Add(leyenda);
                                }));

                            }
                            else
                            {
                                leyenda = $"Registro #{registro} en el elemento {ElementosXML}, no se decifra {textoCifrado}";

                                this.Invoke((Action)(() =>
                                {
                                    conteoNoCifrados++;
                                    label1.Text = $"Cantidad de elementos NO descifrados {conteoNoCifrados}";
                                    listBox1.Items.Add(leyenda);
                                }));
                            }

                            registro++;


                        }

                        doc.Save(filePath);
                    }
                    else
                    {
                        Console.WriteLine($"No se encontraron elementos con el nombre IdDeudor.");
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo XML: " + ex.Message);
            }
        }





    }
}