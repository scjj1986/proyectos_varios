package archivo4;

public class lista implements java.io.Serializable{
    String info;
    lista sig;
    public lista(String valor) {
        this.info=valor;
        this.sig=null;
    }
  }

