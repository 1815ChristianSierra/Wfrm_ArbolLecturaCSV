using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wfrm_ArbolLecturaCSV
{
    class clsArbolBinarioBusqueda : clsArbolBinario
    {
        public int gIntSaltos;

        public clsArbolBinarioBusqueda() : base()
        {
        }

        public clsArbolBinarioBusqueda(clsABNodo nodo) : base(nodo)
        {
        }

        public clsABNodo buscar(Object buscado)
        {
            IntfcComparador dato;
            dato = (IntfcComparador)buscado;
            if (raiz == null)
                return null;
            else
                return buscar(raizArbol(), dato);
        }

        protected clsABNodo buscar(clsABNodo raizSub, IntfcComparador buscado)
        {
            if (raizSub == null)
                return null;
            else if (buscado.igualQue(raizSub.valorNodo()))
                return raiz;
            else if (buscado.menorQue(raizSub.valorNodo()))
                return buscar(raizSub.subarbolIzdo(), buscado);
            else
                return buscar(raizSub.subarbolDcho(), buscado);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buscado"></param>
        /// <returns></returns>
        public clsABNodo buscarIterativo(Object buscado)
        {
            IntfcComparador dato;
            bool encontrado = false;
            clsABNodo raizSub = raiz;
            dato = (IntfcComparador)buscado;
            while (!encontrado && raizSub != null)
            {
                if (dato.igualQue(raizSub.valorNodo()))
                    encontrado = true;
                else if (dato.menorQue(raizSub.valorNodo()))
                    raizSub = raizSub.subarbolIzdo();
                else
                    raizSub = raizSub.subarbolDcho();
                //gIntSaltos++;
            }
            return raizSub;
        }

        public void insertar(Object valor)
        {
            IntfcComparador dato;
            dato = (IntfcComparador)valor;
            raiz = insertar(raiz, dato);
        }

        //método interno para realizar la operación
        protected clsABNodo insertar(clsABNodo raizSub, IntfcComparador dato)
        {
            if (raizSub == null)
                raizSub = new clsABNodo(dato);
            else if (dato.menorQue(raizSub.valorNodo()))
            {
                clsABNodo iz;
                iz = insertar(raizSub.subarbolIzdo(), dato);
                raizSub.ramaIzdo(iz);
            }
            else if (dato.mayorQue(raizSub.valorNodo()))
            {
                clsABNodo dr;
                dr = insertar(raizSub.subarbolDcho(), dato);
                raizSub.ramaDcho(dr);
            }
            else throw new Exception("Nodo duplicado");
            return raizSub;
        }

        public void eliminar(Object valor)
        {
            IntfcComparador dato;
            dato = (IntfcComparador)valor;
            raiz = eliminar(raiz, dato);
        }

        //método interno para realizar la operación
        protected clsABNodo eliminar(clsABNodo raizSub, IntfcComparador dato)
        {
            if (raizSub == null)
                throw new Exception("No encontrado el nodo con la clave");
            else if (dato.menorQue(raizSub.valorNodo()))
            {
                clsABNodo iz;
                iz = eliminar(raizSub.subarbolIzdo(), dato);
                raizSub.ramaIzdo(iz);
            }
            else if (dato.mayorQue(raizSub.valorNodo()))
            {
                clsABNodo dr;
                dr = eliminar(raizSub.subarbolDcho(), dato);
                raizSub.ramaDcho(dr);
            }
            else // Nodo encontrado
            {
                clsABNodo q;
                q = raizSub; // nodo a quitar del árbol
                if (q.subarbolIzdo() == null)
                    raizSub = q.subarbolDcho();
                else if (q.subarbolDcho() == null)
                    raizSub = q.subarbolIzdo();
                else
                { // tiene rama izquierda y derecha
                    q = reemplazar(q);
                }
                q = null;
            }
            return raizSub;
        }

        // método interno para susutituir por el mayor de los menores
        private clsABNodo reemplazar(clsABNodo act)
        {
            clsABNodo a, p;
            p = act;
            a = act.subarbolIzdo(); // rama de nodos menores
            while (a.subarbolDcho() != null)
            {
                p = a;
                a = a.subarbolDcho();
            }
            act.nuevoValor(a.valorNodo());
            if (p == act)
                p.ramaIzdo(a.subarbolIzdo());
            else
                p.ramaDcho(a.subarbolIzdo());
            return a;
        }
    }
}
