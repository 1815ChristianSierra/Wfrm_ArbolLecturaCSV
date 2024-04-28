using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wfrm_ArbolLecturaCSV
{
    class clsArbolAVL
    {
        public int gIntSaltos;
        protected clsNodoAVL raiz;

        public clsArbolAVL()
        {
            raiz = null;
        }

        public clsNodoAVL raizArbol()
        {
            return raiz;
        }



        private clsNodoAVL rotacionII(clsNodoAVL n, clsNodoAVL n1)
        {
            n.ramaIzdo(n1.subarbolDcho());
            n1.ramaDcho(n);
            // actualización de los factores de equilibrio
            if (n1.fe == -1) // se cumple en la inserción
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = -1;
                n1.fe = 1;
            }
            return n1;
        }


        private clsNodoAVL rotacionDD(clsNodoAVL n, clsNodoAVL n1)
        {
            n.ramaDcho(n1.subarbolIzdo());
            n1.ramaIzdo(n);
            // actualización de los factores de equilibrio
            if (n1.fe == +1) // se cumple en la inserción
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = +1;
                n1.fe = -1;
            }
            return n1;
        }


        private clsNodoAVL rotacionID(clsNodoAVL n, clsNodoAVL n1)
        {
            clsNodoAVL n2;
            n2 = (clsNodoAVL)n1.subarbolDcho();
            n.ramaIzdo(n2.subarbolDcho());
            n2.ramaDcho(n);
            n1.ramaDcho(n2.subarbolIzdo());
            n2.ramaIzdo(n1);
            // actualización de los factores de equilibrio
            if (n2.fe == +1)
                n1.fe = -1;
            else
                n1.fe = 0;
            if (n2.fe == -1)
                n.fe = 1;
            else
                n.fe = 0;
            n2.fe = 0;
            return n2;
        }

        private clsNodoAVL rotacionDI(clsNodoAVL n, clsNodoAVL n1)
        {
            clsNodoAVL n2;
            n2 = (clsNodoAVL)n1.subarbolIzdo();
            n.ramaDcho(n2.subarbolIzdo());
            n2.ramaIzdo(n);
            n1.ramaIzdo(n2.subarbolDcho());
            n2.ramaDcho(n1);
            // actualización de los factores de equilibrio
            if (n2.fe == +1)
                n.fe = -1;
            else
                n.fe = 0;
            if (n2.fe == -1)
                n1.fe = 1;
            else
                n1.fe = 0;
            n2.fe = 0;
            return n2;
        }



        public void insertar(Object valor)//throws Exception
        {
            IntfcComparador dato;
            clsLogica h = new clsLogica(false); // intercambia un valor booleano
            dato = (IntfcComparador)valor;
            raiz = insertarAvl(raiz, dato, h);
        }



        private clsNodoAVL insertarAvl(clsNodoAVL raiz, IntfcComparador dt, clsLogica h)
        //throws Exception
        {
            clsNodoAVL n1;
            if (raiz == null)
            {
                raiz = new clsNodoAVL(dt);
                h.setLogical(true);
            }
            else if (dt.menorQue(raiz.valorNodo()))
            {
                clsNodoAVL iz;
                iz = insertarAvl((clsNodoAVL)raiz.subarbolIzdo(), dt, h);
                raiz.ramaIzdo(iz);
                // regreso por los nodos del camino de búsqueda
                if (h.booleanValue())
                {
                    // decrementa el fe por aumentar la altura de rama izquierda
                    switch (raiz.fe)
                    {
                        case 1:
                            raiz.fe = 0;
                            h.setLogical(false);
                            break;
                        case 0:
                            raiz.fe = -1;
                            break;
                        case -1: // aplicar rotación a la izquierda
                            n1 = (clsNodoAVL)raiz.subarbolIzdo();
                            if (n1.fe == -1)
                                raiz = rotacionII(raiz, n1);
                            else
                                raiz = rotacionID(raiz, n1);
                            h.setLogical(false);
                            break;
                    }
                }
            }
            else if (dt.mayorQue(raiz.valorNodo()))
            {
                clsNodoAVL dr;
                dr = insertarAvl((clsNodoAVL)raiz.subarbolDcho(), dt, h);
                raiz.ramaDcho(dr);
                // regreso por los nodos del camino de búsqueda
                if (h.booleanValue())
                {
                    // incrementa el fe por aumentar la altura de rama izquierda
                    switch (raiz.fe)
                    {
                        case 1: // aplicar rotación a la derecha
                            n1 = (clsNodoAVL)raiz.subarbolDcho();
                            if (n1.fe == +1)
                                raiz = rotacionDD(raiz, n1);
                            else
                                raiz = rotacionDI(raiz, n1);
                            h.setLogical(false);
                            break;
                        case 0:
                            raiz.fe = +1;
                            break;
                        case -1:
                            raiz.fe = 0;
                            h.setLogical(false);
                            break;
                    }
                }
            }
            else
                throw new Exception("No puede haber claves repetidas ");
            return raiz;
        }

        public void eliminar(Object valor) //throws Exception
        {
            IntfcComparador dato;
            dato = (IntfcComparador)valor;
            clsLogica flag = new clsLogica(false);
            raiz = borrarAvl(raiz, dato, flag);
        }


        private clsNodoAVL borrarAvl(clsNodoAVL r, IntfcComparador clave, clsLogica cambiaAltura) //throws Exception
        {
            if (r == null)
            {
                throw new Exception(" Nodo no encontrado ");
            }
            else if (clave.menorQue(r.valorNodo()))
            {
                clsNodoAVL iz;
                iz = borrarAvl((clsNodoAVL)r.subarbolIzdo(), clave, cambiaAltura);
                r.ramaIzdo(iz);
                if (cambiaAltura.booleanValue())
                    r = equilibrar1(r, cambiaAltura);
            }
            else if (clave.mayorQue(r.valorNodo()))
            {
                clsNodoAVL dr;
                dr = borrarAvl((clsNodoAVL)r.subarbolDcho(), clave, cambiaAltura);
                r.ramaDcho(dr);
                if (cambiaAltura.booleanValue())
                    r = equilibrar2(r, cambiaAltura);
            }
            else // Nodo encontrado
            {
                clsNodoAVL q;
                q = r; // nodo a quitar del árbol
                if (q.subarbolIzdo() == null)
                {
                    r = (clsNodoAVL)q.subarbolDcho();
                    cambiaAltura.setLogical(true);
                }
                else if (q.subarbolDcho() == null)
                {
                    r = (clsNodoAVL)q.subarbolIzdo();
                    cambiaAltura.setLogical(true);
                }
                else
                { // tiene rama izquierda y derecha
                    clsNodoAVL iz;
                    iz = reemplazar(r, (clsNodoAVL)r.subarbolIzdo(), cambiaAltura);
                    r.ramaIzdo(iz);
                    if (cambiaAltura.booleanValue())
                        r = equilibrar1(r, cambiaAltura);
                }
                q = null;
            }
            return r;
        }


        private clsNodoAVL reemplazar(clsNodoAVL n, clsNodoAVL act, clsLogica cambiaAltura)
        {
            if (act.subarbolDcho() != null)
            {
                clsNodoAVL d;
                d = reemplazar(n, (clsNodoAVL)act.subarbolDcho(), cambiaAltura);
                act.ramaDcho(d);
                if (cambiaAltura.booleanValue())
                    act = equilibrar2(act, cambiaAltura);
            }
            else
            {
                n.nuevoValor(act.valorNodo());
                n = act;
                act = (clsNodoAVL)act.subarbolIzdo();
                n = null;
                cambiaAltura.setLogical(true);
            }
            return act;
        }

        private clsNodoAVL equilibrar1(clsNodoAVL n, clsLogica cambiaAltura)
        {
            clsNodoAVL n1;
            switch (n.fe)
            {
                case -1:
                    n.fe = 0;
                    break;
                case 0:
                    n.fe = 1;
                    cambiaAltura.setLogical(false);
                    break;
                case +1: //se aplicar un tipo de rotación derecha
                    n1 = (clsNodoAVL)n.subarbolDcho();
                    if (n1.fe >= 0)
                    {
                        if (n1.fe == 0) //la altura no vuelve a disminuir
                            cambiaAltura.setLogical(false);
                        n = rotacionDD(n, n1);
                    }
                    else
                        n = rotacionDI(n, n1);
                    break;
            }
            return n;
        }

        private clsNodoAVL equilibrar2(clsNodoAVL n, clsLogica cambiaAltura)
        {
            clsNodoAVL n1;
            switch (n.fe)
            {
                case -1: // Se aplica un tipo de rotación izquierda
                    n1 = (clsNodoAVL)n.subarbolIzdo();
                    if (n1.fe <= 0)
                    {
                        if (n1.fe == 0)
                            cambiaAltura.setLogical(false);
                        n = rotacionII(n, n1);
                    }
                    else
                        n = rotacionID(n, n1);
                    break;
                case 0:
                    n.fe = -1;
                    cambiaAltura.setLogical(false);
                    break;
                case +1:
                    n.fe = 0;
                    break;
            }
            return n;
        }

        /////////////////////////////////
        /// <summary>
        /// Comprueba el estatus del árbol
        /// </summary>
        /// <returns></returns>
        bool esVacio()
        {
            return raiz == null;
        }

        public static clsNodoAVL nuevoArbol(clsNodoAVL ramaIzqda, Object dato, clsNodoAVL ramaDrcha)
        {
            return new clsNodoAVL(dato, ramaIzqda, ramaDrcha);
        }


        //binario en preorden
        public static string preorden(clsABNodo r)
        {
            if (r != null)
            {
                return r.visitar() + preorden(r.subarbolIzdo()) + preorden(r.subarbolDcho());
            }
            return "";
        }

        // Recorrido de un árbol binario en inorden
        public static string inorden(clsABNodo r)
        {
            if (r != null)
            {
                return inorden(r.subarbolIzdo()) + r.visitar() + inorden(r.subarbolDcho());
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

        public clsNodoAVL buscarIterativo(Object buscado)
        {
            IntfcComparador dato;
            Boolean encontrado = false;
            clsNodoAVL raizSub = raiz;
            dato = (IntfcComparador)buscado;
            while (!encontrado && raizSub != null)
            {
                if (dato.igualQue(raizSub.valorNodo()))
                    encontrado = true;
                else if (dato.menorQue(raizSub.valorNodo()))
                    raizSub = (clsNodoAVL)raizSub.subarbolIzdo();
                else
                    raizSub = (clsNodoAVL)raizSub.subarbolDcho();
                // Incrementing search steps
                gIntSaltos++;
            }
            return raizSub;
        }
    }
}
