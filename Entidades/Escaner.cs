using System;
using System.Text;
using System.Drawing;
using static Entidades.Documento;

/*
	COSAS QUE LE FALTAN:
*/

/// La clase Escaner se encarga de crear una lista de objetos.

namespace Entidades
{
    public class Escaner
    {
        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;

        public enum Departamento { nulo, mapoteca, procesosTecnicos }
        public enum TipoDoc { libro, mapa }

        public Escaner(string marca, TipoDoc tipo)
        {
            this.listaDocumentos = new List<Documento>();
            this.marca = marca;

            if (tipo == TipoDoc.libro)
            {
                this.tipo = tipo;
                this.locacion = Departamento.procesosTecnicos;
            }
            else if (tipo == TipoDoc.mapa)
            {
                this.tipo = tipo;
                this.locacion = Departamento.mapoteca;
            }
            else
            {
                this.locacion = Departamento.nulo;
                //throw new ArgumentException("EL TIPO SELECCIONADO NO EXISTE :P ");
            }
        }
        public bool CambiarEstadoDocumento(Documento d)
        {
            return d.AvanzarEstado();
        }

        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno = false;
            foreach (Documento doc in e.listaDocumentos)
            {
                if (d.GetType() == doc.GetType())
                {
                    if (d.GetType() == typeof(Libro))
                    {
                        Libro libro1 = (Libro)doc;
                        Libro libro2 = (Libro)d;
                        if (libro1 == libro2)
                        {
                            retorno = true;
                        }
                    }
                    else if (d.GetType() == typeof(Mapa))
                    {
                        Mapa mapa1 = (Mapa)doc;
                        Mapa mapa2 = (Mapa)d;
                        if (mapa1 == mapa2)
                        {
                            retorno = true;
                        }
                    }
                }
            }
            return retorno;
        }

        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        public static bool operator +(Escaner escaner, Documento documento)
        {
            bool retorno = false;
            if(documento.Estado == Paso.Inicio && escaner != documento)
            {
                escaner.listaDocumentos.Add(documento);
                retorno = true;
            }
            return retorno;
        }

        public List<Documento> ListaDocumentos
        {
            get => this.listaDocumentos;
        }

        public Departamento Locacion
        {
            get => this.locacion;
        }

        public string Marca
        {
            get => this.marca;
        }

        public TipoDoc Tipo
        {
            get => this.tipo;
        }
    }
}

