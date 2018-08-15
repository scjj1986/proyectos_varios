package Clases;

import java.sql.*;

public class BaseDatos {
Connection conn = null;
Statement s;
ResultSet rs;
public String bd = "serviciocomunitario";
public String login = "root";
public String password = "1234";
public String url = "jdbc:mysql://localhost/"+bd;
    public void conectar() {
    
        try {
        Class.forName("org.gjt.mm.mysql.Driver");
        conn = DriverManager.getConnection(url, login, password);
        s = conn.createStatement(); 
            
        }
        catch(SQLException ex) {
        System.out.println("Hubo un problema al intentar conectarse con la base de datos "+url);
        }
        catch(ClassNotFoundException ex) {
        System.out.println(ex);
        }
    }
    
    public void desconectar(){
        
        try {
            
            //rs.close();
            s.close();
            conn.close();
        }
        catch(SQLException ex) {
        System.out.println(ex);
        }
    
    }
   
    public boolean usuario_no_encontrado(String nick,String pass){
    
        conectar();
        boolean aux=false;
        try {
        if (conn != null)
        {
            rs = s.executeQuery ("select * from usuario where nick='"+nick+"' and contrasena='"+pass+"'");
        if (rs.next()) 
        { 
            aux=true;
        }
        }
        }
        catch(SQLException ex) {
        System.out.println("Hubo un problema al intentar conectarse con la base de datos "+url);
        }
        desconectar();
        return aux;
    
    }
    
    public boolean cuo_repetido (String ano, String semestre){
    
        conectar();
        boolean aux=false;
        try {
        if (conn != null)
        {
        s = conn.createStatement(); 
        rs = s.executeQuery ("select * from cuo where ano='"+ano+"' and semestre='"+semestre+"'");
        if(rs.next()) 
        { 
            aux=true; 
        }
        }
        }
        catch(SQLException ex) {
        System.out.println("Hubo un problema al intentar conectarse con la base de datos "+url);
        }
        desconectar();
        return aux;
    
    
    
    }
    
    public int n_tuplas(String consulta){
        conectar();
        int cont=0;
        try {
        if (conn != null)
        {
        s = conn.createStatement(); 
        rs = s.executeQuery (consulta);
        while (rs.next()) 
        { 
            cont++; 
        }
        }
        }
        catch(SQLException ex) {
        System.out.println("Hubo un problema al intentar conectarse con la base de datos "+url);
        }
        desconectar();
        return cont;
    }
    
    public void obtener_tuplas(String consulta,String usuario[][], int c){
        conectar();
        int i,j;
        i=0;
        try {
            if (conn != null)
            {
                s = conn.createStatement(); 
                rs = s.executeQuery (consulta);
                while (rs.next()) 
                { 
                    for (j=0; j<c; j++){
                        usuario[i][j]=rs.getString (j+1);
                    }
                    i++;
                }
            }
        }
        catch(SQLException ex) {
        System.out.println("Hubo un problema al intentar conectarse con la base de datos "+url);
        }
        desconectar();
    }
    public void consulta(String consulta){
        conectar();
        
        try {
        if (conn != null)
        {
        s = conn.createStatement(); 
        s.execute(consulta);
        }
        }
        catch(SQLException ex) {
        System.out.println("Problema al intentar conectarse con la base de datos "+url);
        }
        desconectar();
    }
}