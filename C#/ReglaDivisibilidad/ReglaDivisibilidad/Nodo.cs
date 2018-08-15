
using System;

namespace ReglaDivisibilidad
{
	/// <summary>
	/// Description of Nodo.
	/// </summary>
	public class Nodo
	{
		
		public String numero;
		public Nodo sig;
		public Nodo(String valor)
		{
			numero=valor;
			sig=null;
		}
	}
}
