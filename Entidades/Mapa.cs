using System;
using System.Text;
using System.Drawing;

/*
	COSAS QUE LE FALTAN:
*/

/// La clase Mapa va a crear un abjeto que guarde las caracteristicas que conforman un mapa y podra evaluar si es igual a otro.

namespace Entidades
{
	public class Mapa : Documento
	{
		int alto;
		int ancho;

		public Mapa(string titulo, int anio, string autor,string numNormalizado, string barcode, int alto, int ancho)
			: base(anio, autor, barcode, titulo, numNormalizado)
        {
			this.alto = alto;
			this.ancho = ancho;
		}

		public int Alto
		{
			get => this.alto;
		}

		public int Ancho
		{
			get => this.ancho;
		}

		public int Superficie
		{
			get => this.ancho * this.alto;
		}

        public static bool operator ==(Mapa M1, Mapa M2)
        {
            return M1.Barcode == M2.Barcode || (M1.Titulo == M2.Titulo && M1.Autor == M2.Autor && M1.Anio == M2.Anio && M1.Superficie == M2.Superficie);
        }

        public static bool operator !=(Mapa M1, Mapa M2)
        {
            return !(M1 == M2);
        }

        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.Append(base.ToString());
            texto.AppendLine($"");
            texto.AppendLine($"Superficie: {this.alto} * {this.ancho} = {Superficie} cm2");
            return texto.ToString();
        }
    }
}