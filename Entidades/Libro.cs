using System;
using System.Text;
using System.Drawing;

/*
	COSAS QUE LE FALTAN:
*/

/// La clase libro va a crear un abjeto que guarde las caracteristicas que conforman un libro y podra evaluar si es igual a otro.

namespace Entidades
{
	public class Libro : Documento
	{
        int numeroDePag;

        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numeroDePag)
			: base(anio, autor, barcode, numNormalizado, titulo)
		{
			this.numeroDePag = numeroDePag;
		}

		public string ISBN
		{
			get => this.NumNormalizado;
		}

		public int NumeroDePag
		{
			get => this.numeroDePag;
		}

		public static bool operator ==(Libro I1, Libro I2)
		{
			return (I1.Titulo == I2.Titulo && I1.Autor == I2.Autor) || I1.ISBN == I2.ISBN || I1.Barcode == I2.Barcode;
		}

        public static bool operator !=(Libro I1, Libro I2)
        {
			return !(I1 == I2);
        }

        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.Append(base.ToString());
            texto.AppendLine($"");
            texto.AppendLine($"ISBN: {this.NumNormalizado}.");
            texto.AppendLine($"Núm. Páginas: {this.numeroDePag}");
            return texto.ToString();
        }

    }
}