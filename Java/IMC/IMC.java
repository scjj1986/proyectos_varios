import java.io.*;

public class IMC{
	static class paciente{
	String cedula,nombre;
	float altura, peso;
	public void calcular_imc()
	{
		float imc;
		imc = peso /(altura*altura);
		System.out.println("El imc del paciente es: "+imc);
	}
	
	public void modificar_datos() throws Exception
	{
		BufferedReader teclado = new BufferedReader (new InputStreamReader(System.in));
		System.out.print("Ingrese el nuevo peso: ");
		peso= Float.parseFloat(teclado.readLine());
		System.out.print("Ingrese la nueva altura: ");
		altura= Float.parseFloat(teclado.readLine());		
	}
}
	
	public static void main(String[] args) throws Exception
	{
		paciente ind_co;
		byte opc;
		ind_co = new paciente();
		BufferedReader teclado = new BufferedReader (new InputStreamReader(System.in));
		System.out.print("Ingrese el nombre del pac: ");
		ind_co.nombre= teclado.readLine();
		System.out.print("Ingrese la cedula del pac: ");
		ind_co.cedula= teclado.readLine();
		System.out.print("Ingrese la altura: ");
		ind_co.altura= Float.parseFloat(teclado.readLine());
		System.out.print("Ingrese el peso: ");
		ind_co.peso= Float.parseFloat(teclado.readLine());
		do{
			System.out.println("MENU");
			System.out.println("1. Calcular el IMC");
			System.out.println("2. Modificar datos");
			System.out.println("3. Salir del programa");
			System.out.print("Ingrese opcion: ");
			opc= Byte.parseByte(teclado.readLine());
			switch (opc)
			{
				case 1: ind_co.calcular_imc();
				break;
				case 2: ind_co.modificar_datos();
				break;
			}	
		}while(opc!=3);
	}
}
