﻿using System;
using System.Text;
using System.Drawing;

/// La clase informes solo esta constituida de matoddos los cuales se encargan de mostrar los diferentes ojetos instanciados.

namespace Entidades
{
	public static class Informes
	{
		private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extencion, out int cantidad, out string resumen)
		{
			int contador = 0;
			int auxExtencion = 0;
			StringBuilder texto = new StringBuilder();

			foreach (Documento doc in e.ListaDocumentos)
			{
				if(doc.Estado == estado)
				{
					if(doc is Mapa mapa)
					{
                        auxExtencion += mapa.Superficie;
						contador += 1;
						texto.Append(mapa.ToString());
                    }
					else if(doc is Libro libro)
					{
						auxExtencion += libro.NumPaginas;
                        contador += 1;
                        texto.Append(libro.ToString());
                    }
				}
			}
            extencion = auxExtencion;
			cantidad = contador;
			resumen = texto.ToString();
        }

		public static void MostrarDistribuidos(Escaner e, out int extencion, out int cantidad, out string resumen)
		{
			MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extencion, out cantidad, out resumen);
		}

        public static void MostrarEnEscaner(Escaner e, out int extencion, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extencion, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extencion, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extencion, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extencion, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extencion, out cantidad, out resumen);
        }
    }
}

