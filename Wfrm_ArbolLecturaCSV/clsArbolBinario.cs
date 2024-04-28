using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wfrm_ArbolLecturaCSV
{
    class clsArbolBinario
    {
        protected clsABNodo raiz;

        public clsArbolBinario()
        {
            raiz = null;
        }

        public clsArbolBinario(clsABNodo raiz)
        {
            this.raiz = raiz;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public clsABNodo raizArbol()
        {
            return raiz;
        }

        /// <summary>
        /// Comprueba el estatus del árbol
        /// </summary>
        /// <returns></returns>
        bool esVacio()
        {
            return raiz == null;
        }

        public static clsABNodo nuevoArbol(clsABNodo ramaIzqda, Object dato, clsABNodo ramaDrcha)
        {
            return new clsABNodo(ramaIzqda, dato, ramaDrcha);
        }


        //binario en preorden
        public static string preorden(clsABNodo r)
        {
            if (r != null)
            {
                return r.visitar() + preorden(r.subarbolIzdo()) +
                    preorden(r.subarbolDcho());
            }
            return "";
        }

        // Recorrido de un árbol binario en inorden
        public static string inorden(clsABNodo r)
        {
            if (r != null)
            {
                return inorden(r.subarbolIzdo())
                    + r.visitar() + inorden(r.subarbolDcho());
            }
            return "";
        }

        // Recorrido de un árbol binario en postorden
        public static string postorden(clsABNodo r)
        {
            if (r != null)
            {
                return postorden(r.subarbolIzdo()) + postorden(r.subarbolDcho()) + r.visitar();
            }
            return "";
        }

        //Devuelve el número de nodos que tiene el árbol
        public static int numNodos(clsABNodo raiz)
        {
            if (raiz == null)
                return 0;
            else
                return 1 + numNodos(raiz.subarbolIzdo()) +
                numNodos(raiz.subarbolDcho());
        }
    }
}
