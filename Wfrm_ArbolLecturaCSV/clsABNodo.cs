using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wfrm_ArbolLecturaCSV
{
    class clsABNodo
    {
        protected Object dato;
        protected clsABNodo izdo;
        protected clsABNodo dcho;

        /// <summary>
        /// Método Constructor del nodo el cual recibe un valor y asign
        /// asigna nulos a los hijos
        /// </summary>
        /// <param name="valor">hhhhhhhhhhhhh</param>
        public clsABNodo(Object valor)
        {
            dato = valor;
            izdo = dcho = null;
        }

        public clsABNodo(clsABNodo ramaIzdo, Object valor, clsABNodo ramaDcho)
        {
            this.dato = valor;
            izdo = ramaIzdo;
            dcho = ramaDcho;
        }

        // operaciones de acceso
        public Object valorNodo()
        {
            return dato;
        }

        public clsABNodo subarbolIzdo() { return izdo; }
        public clsABNodo subarbolDcho() { return dcho; }

        public void nuevoValor(Object d)
        {
            dato = d;
        }

        public void ramaIzdo(clsABNodo n) { izdo = n; }
        public void ramaDcho(clsABNodo n) { dcho = n; }
        public string visitar()
        {
            return dato.ToString();
        }
    }
}
