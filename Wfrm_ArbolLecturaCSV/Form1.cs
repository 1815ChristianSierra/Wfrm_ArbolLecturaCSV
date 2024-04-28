namespace Wfrm_ArbolLecturaCSV
{
    public partial class Form1 : Form
    {
        /*NOMBRE: CHRISTIAN ALEXANDER SIERRA ELIAS
       *CARNET: 0900221815
       *CURSO: PROGRAMACION3
       *SECCION: A
       *CATEDRATICO: MICHAEL ASTURIAS
       *LABORATORIO LECTUA ARCHIVO CSV Y SALTOS, ARBOLES BINARIOS DE BUSQUEDAS VS ARBOLES AVL
       */

        clsArbolBinarioBusqueda gObjMiArbolBusqueda;
        clsArbolAVL gObjMiarbolAvl;

        public Form1()
        {
            InitializeComponent();
            gObjMiarbolAvl = new clsArbolAVL();
            gObjMiArbolBusqueda = new clsArbolBinarioBusqueda();
            Cargar();
        }

        public void Cargar()
        {
            int lIntContador = 0;
            string lStrLinea;

            System.IO.StreamReader fArchivo = new System.IO.StreamReader("DatosEstudiantes.csv");

            Char lChrDelimitador = ';';
            while ((lStrLinea = fArchivo.ReadLine()) != null)
            {
                if (lIntContador > 0)
                {
                    String[] SubCadena = lStrLinea.Split(lChrDelimitador);
                    clsAlumno ObjEstudiante = new clsAlumno(
                        SubCadena[0],
                        SubCadena[1],
                        SubCadena[2],
                        Convert.ToInt32(SubCadena[3]),
                        Convert.ToInt32(SubCadena[4]),
                        Convert.ToInt32(SubCadena[5]),
                        Convert.ToInt32(SubCadena[6]),
                        Convert.ToInt32(SubCadena[7]));
                    gObjMiarbolAvl.insertar(ObjEstudiante);
                    gObjMiArbolBusqueda.insertar(ObjEstudiante);
                    lIntContador++;
                }
                else
                {
                    lIntContador++;
                }
            }
            fArchivo.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            clsAlumno lMiAlumnoBuscar = new clsAlumno(txtBuscar.Text, "", "", 0, 0, 0, 0, 0);
            lMiAlumnoBuscar = (clsAlumno)gObjMiArbolBusqueda.buscarIterativo(lMiAlumnoBuscar).valorNodo();

            txtCarnet.Text = lMiAlumnoBuscar.lStrCarnetAlumno;
            txtNombre.Text = lMiAlumnoBuscar.lStrNombreAlumno;
            txtCorreo.Text = lMiAlumnoBuscar.lStrCorreoAlumno;
            txtParcial1.Text = lMiAlumnoBuscar.lIntParcial1Alumno.ToString();
            txtParcial2.Text = lMiAlumnoBuscar.lIntParcial2Alumno.ToString();
            txtZona.Text = lMiAlumnoBuscar.lIntZonaAlumno.ToString();
            txtTotal.Text = lMiAlumnoBuscar.lIntTotalAlumno.ToString();

            clsAlumno lMiAlumnoAVL = new clsAlumno(txtBuscar.Text, "", "", 0, 0, 0, 0, 0);
            lMiAlumnoAVL = (clsAlumno)gObjMiarbolAvl.buscarIterativo(lMiAlumnoAVL).valorNodo();

            txtCarnetAVL.Text = lMiAlumnoAVL.lStrCarnetAlumno;
            txtNombreAVL.Text = lMiAlumnoAVL.lStrNombreAlumno;
            txtCorreoAVL.Text = lMiAlumnoAVL.lStrCorreoAlumno;
            txtParcial1AVL.Text = lMiAlumnoAVL.lIntParcial1Alumno.ToString();
            txtParcial2AVL.Text = lMiAlumnoAVL.lIntParcial2Alumno.ToString();
            txtZonaAVL.Text = lMiAlumnoAVL.lIntZonaAlumno.ToString();
            txtTotalAVL.Text = lMiAlumnoAVL.lIntTotalAlumno.ToString();
            MessageBox.Show("ALUMNO ENCONTRADO."+ " SALTOS BUSQUEDA: " + gObjMiArbolBusqueda.gIntSaltos + " SALTOS AVL: " + gObjMiarbolAvl.gIntSaltos, "ATENCION");
        }
    }
}
