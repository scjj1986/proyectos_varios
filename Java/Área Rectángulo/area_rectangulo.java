import java.io.*;


public class area_rectangulo
{
	static class rectangulo{
	float ancho, largo;
	public void calcular_area(){
		float area;
		area = ancho*largo;
		System.out.println("El area del rectangulo es: "+area);
	}
}
	
	public static void main(String[] args) throws Exception{
		rectangulo rectan;
		rectan = new rectangulo();
		BufferedReader teclado = new BufferedReader (new InputStreamReader(System.in));
		System.out.print("Ingrese Ancho: ");
		rectan.ancho= Float.parseFloat(teclado.readLine());
		System.out.print("Ingrese Largo: ");
		rectan.largo= Float.parseFloat(teclado.readLine());
		rectan.calcular_area();
	}
}
	