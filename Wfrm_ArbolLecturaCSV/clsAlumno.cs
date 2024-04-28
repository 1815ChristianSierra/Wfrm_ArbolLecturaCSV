using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wfrm_ArbolLecturaCSV
{
    public class clsAlumno : IntfcComparador
    {
        public string lStrCarnetAlumno { get; set; }
        public string lStrNombreAlumno {  get; set; }
        public string lStrCorreoAlumno { get; set; }
        public int lIntParcial1Alumno { get; set; }
        public int lIntParcial2Alumno { get; set; }
        public int lIntZonaAlumno { get; set; }
        public int lIntFinalAlumno { get; set; }
        public int lIntTotalAlumno { get; set; }
        public clsAlumno(string vStrCarnet, string vStrNombre, string vStrCorreo, int vIntParcial1, int vIntParcial2, int vIntZona, int vIntFinal, int vIntTotal) 
        {
            this.lStrCarnetAlumno = vStrCarnet;
            this.lStrNombreAlumno = vStrNombre;
            this.lStrCorreoAlumno = vStrCorreo;
            this.lIntParcial1Alumno = vIntParcial1;
            this.lIntParcial2Alumno = vIntParcial2;
            this.lIntZonaAlumno = vIntZona;
            this.lIntFinalAlumno = vIntFinal;
            this.lIntTotalAlumno = vIntTotal;
        }

        public bool igualQue(object carnet)
        {
            clsAlumno lMiAlumno = (clsAlumno)carnet;
            if (lStrCarnetAlumno.CompareTo(lMiAlumno.lStrCarnetAlumno) == 0)
                return true;
            else
                return false;
        }

        public bool menorQue(object carnet)
        {
            clsAlumno lMiAlumno = (clsAlumno)carnet;
            if (lStrCarnetAlumno.CompareTo(lMiAlumno.lStrCarnetAlumno) < 0)
                return true;
            else
                return false;
        }

        public bool menorIgualQue(object carnet)
        {
            clsAlumno lMiAlumno = (clsAlumno)carnet;
            if (lStrCarnetAlumno.CompareTo(lMiAlumno.lStrCarnetAlumno) <= 0)
                return true;
            else
                return false;
        }

        public bool mayorQue(object carnet)
        {
            clsAlumno lMiAlumno = (clsAlumno)carnet;
            if (lStrCarnetAlumno.CompareTo(lMiAlumno.lStrCarnetAlumno) > 0)
                return true;
            else
                return false;
        }

        public bool mayorIgualQue(object carnet)
        {
            clsAlumno lMiAlumno = (clsAlumno)carnet;
            if (lStrCarnetAlumno.CompareTo(lMiAlumno.lStrCarnetAlumno) >= 0)
                return true;
            else
                return false;

        }
    }
}
