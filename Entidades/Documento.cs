using System;
using System.Text;
using System.Drawing;

/*
	COSAS QUE LE FALTAN:
	-probar en avanzar dato si haciendo +1 al enum avanza
*/

/// La Clase abstracta "Documento" es la clase padre de "Mapa" y "libro" que sirve como base para estas. Crea las configuraciones que se van a usar en cada una.

namespace Entidades
{
	public abstract class Documento
	{
		int anio;
		string autor;
		string barcode;
		Paso estado = Paso.Inicio;
		string numNormalizado;
		string titulo;

		public enum Paso { Error, Inicio, Distribuido, EnEscaner, EnRevision, Terminado }

		public Documento(int anio, string autor, string barcode, string numNormalizado, string titulo)
		{
			this.anio = anio;
			this.autor = autor;
			this.barcode = barcode;
			this.numNormalizado = numNormalizado;
			this.titulo = titulo;
			/*
			Paso pasoValido = this.CheckEstado(estado);

			if(pasoValido == Paso.Error)
			{
				throw new ArgumentException("EL PASO SELECCIONADO NO EXISTE :P ");
			}
			else
			{
				this.estado = pasoValido;
			}
			*/
		}
        /*
        private Paso CheckEstado(string paso)
        {
			Paso retorno;
			Paso.TryParse(paso, out retorno);
			Console.WriteLine(retorno);
			return retorno;
        }
		*/

        public int Anio
		{
			get => this.anio;
		}

		public string Autor
		{
			get => this.autor;
		}

		public string Barcode
		{
			get => this.barcode;
		}

		public Paso Estado
		{
			get => this.estado;
		}

		protected string NumNormalizado
		{
			get => this.numNormalizado;
		}

		public string Titulo
		{
			get => this.titulo;
		}

        public bool AvanzarEstado()
        {
            if (estado == Paso.Inicio)
            {
				this.estado = Paso.Distribuido;
            }
            else if (estado == Paso.Distribuido)
            {
                this.estado = Paso.EnEscaner;
            }
            else if (estado == Paso.EnEscaner)
            {
                this.estado = Paso.EnRevision;
            }
            else if (estado == Paso.EnRevision)
            {
                this.estado = Paso.Terminado;
            }
            else if (estado == Paso.Terminado)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine($"Título: {this.titulo}.");
            retorno.AppendLine($"Autor: {this.autor}.");
            retorno.AppendLine($"Año: {this.anio}.");
            retorno.AppendLine($"Barcode: {this.barcode}.");
            retorno.AppendLine($"Estado: {this.estado}.");
            return retorno.ToString();
        }
    }
}