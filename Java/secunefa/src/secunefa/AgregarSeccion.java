/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package secunefa;
import javax.swing.table.*;
import Clases.*;
import java.awt.*; 
import java.io.*;
import javax.swing.*;
/**
 *
 * @author salazar
 */
public class AgregarSeccion extends javax.swing.JFrame {
    String nombrecarrera,codigo,asignatura;

    /**
     * Creates new form AgregarSeccion
     */
    public AgregarSeccion(String carr, String mat,String cod) {
        initComponents();
        setSize(624,434);
        setResizable(false);
        nombrecarrera=carr;
        codigo=cod;
        asignatura=mat;
        String texto,texto2,texto3;
        texto="*Carrera: "+carr;
        texto2=" Materia: "+mat;
        texto3=" Código: "+cod;
        EtqCarrera.setText(texto);
        EtqMateria.setText(texto2);
        EtqCodigo.setText(texto3);
        lista_profesor lp= new lista_profesor();
        try{
        
            if (lp.existearchivo("profesor.obj"))
            {
                
                ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("profesor.obj"));
                profesor aux=(profesor) entrada.readObject();
                entrada.close();
                String nombrecompleto="";
                while (aux!=null)
                {
                    nombrecompleto=aux.nombre+" "+aux.apellido;
                    ComboProfesores.addItem(nombrecompleto);
                    aux=aux.sig;
                }
            }
        }
        catch (IOException ex) {
        System.out.println(ex);
        }catch (ClassNotFoundException ex) {
               System.out.println(ex);
        }
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        Mensaje = new javax.swing.JOptionPane();
        PanelVentana = new javax.swing.JPanel();
        PanelBanner = new javax.swing.JPanel();
        PanelCuerpo = new javax.swing.JPanel();
        EtqAgregarSeccion = new javax.swing.JLabel();
        EtqCarrera = new javax.swing.JLabel();
        EtqMateria = new javax.swing.JLabel();
        EtqCodigo = new javax.swing.JLabel();
        EtqNSeccion = new javax.swing.JLabel();
        txtSeccion = new javax.swing.JTextField();
        BotonGuardar = new javax.swing.JButton();
        BotonRegresar = new javax.swing.JButton();
        EtqProfesor = new javax.swing.JLabel();
        ComboProfesores = new javax.swing.JComboBox();
        jSeparator1 = new javax.swing.JSeparator();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Agregar Seccion");
        setResizable(false);
        addWindowListener(new java.awt.event.WindowAdapter() {
            public void windowOpened(java.awt.event.WindowEvent evt) {
                formWindowOpened(evt);
            }
        });

        javax.swing.GroupLayout PanelBannerLayout = new javax.swing.GroupLayout(PanelBanner);
        PanelBanner.setLayout(PanelBannerLayout);
        PanelBannerLayout.setHorizontalGroup(
            PanelBannerLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 604, Short.MAX_VALUE)
        );
        PanelBannerLayout.setVerticalGroup(
            PanelBannerLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 130, Short.MAX_VALUE)
        );

        PanelCuerpo.setBackground(new java.awt.Color(255, 255, 255));

        EtqAgregarSeccion.setFont(new java.awt.Font("Lucida Console", 1, 16)); // NOI18N
        EtqAgregarSeccion.setText("AGREGAR SECCIÓN");

        EtqCarrera.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqCarrera.setText("jLabel1");

        EtqMateria.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqMateria.setText("jLabel1");

        EtqCodigo.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqCodigo.setText("jLabel1");

        EtqNSeccion.setFont(new java.awt.Font("Lucida Console", 0, 14)); // NOI18N
        EtqNSeccion.setText("*Número:");

        txtSeccion.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtSeccionKeyTyped(evt);
            }
        });

        BotonGuardar.setText("Guardar");
        BotonGuardar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                BotonGuardarActionPerformed(evt);
            }
        });

        BotonRegresar.setText("Regresar");
        BotonRegresar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                BotonRegresarActionPerformed(evt);
            }
        });

        EtqProfesor.setFont(new java.awt.Font("Lucida Console", 0, 14)); // NOI18N
        EtqProfesor.setText("*Profesor:");

        ComboProfesores.setModel(new javax.swing.DefaultComboBoxModel(new String[] { "Seleccione..." }));

        javax.swing.GroupLayout PanelCuerpoLayout = new javax.swing.GroupLayout(PanelCuerpo);
        PanelCuerpo.setLayout(PanelCuerpoLayout);
        PanelCuerpoLayout.setHorizontalGroup(
            PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(PanelCuerpoLayout.createSequentialGroup()
                        .addGap(211, 211, 211)
                        .addComponent(EtqAgregarSeccion, javax.swing.GroupLayout.PREFERRED_SIZE, 174, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(0, 209, Short.MAX_VALUE))
                    .addGroup(PanelCuerpoLayout.createSequentialGroup()
                        .addContainerGap()
                        .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                                .addGap(10, 10, 10)
                                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                    .addComponent(EtqMateria, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                    .addComponent(EtqCarrera, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                    .addComponent(EtqCodigo, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.PREFERRED_SIZE, 438, javax.swing.GroupLayout.PREFERRED_SIZE))
                                .addGap(0, 0, Short.MAX_VALUE))
                            .addComponent(jSeparator1))))
                .addContainerGap())
            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                .addGap(190, 190, 190)
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(PanelCuerpoLayout.createSequentialGroup()
                        .addComponent(BotonGuardar, javax.swing.GroupLayout.PREFERRED_SIZE, 97, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(28, 28, 28)
                        .addComponent(BotonRegresar, javax.swing.GroupLayout.PREFERRED_SIZE, 97, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(PanelCuerpoLayout.createSequentialGroup()
                        .addGap(26, 26, 26)
                        .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(EtqProfesor)
                            .addComponent(EtqNSeccion))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(txtSeccion, javax.swing.GroupLayout.PREFERRED_SIZE, 68, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(ComboProfesores, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 25, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        PanelCuerpoLayout.setVerticalGroup(
            PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(EtqAgregarSeccion)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(jSeparator1, javax.swing.GroupLayout.PREFERRED_SIZE, 10, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(EtqCarrera)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(EtqMateria)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(EtqCodigo)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 30, Short.MAX_VALUE)
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(EtqNSeccion)
                    .addComponent(txtSeccion, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(EtqProfesor)
                    .addComponent(ComboProfesores, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(BotonGuardar, javax.swing.GroupLayout.PREFERRED_SIZE, 31, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(BotonRegresar, javax.swing.GroupLayout.PREFERRED_SIZE, 32, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap())
        );

        javax.swing.GroupLayout PanelVentanaLayout = new javax.swing.GroupLayout(PanelVentana);
        PanelVentana.setLayout(PanelVentanaLayout);
        PanelVentanaLayout.setHorizontalGroup(
            PanelVentanaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelVentanaLayout.createSequentialGroup()
                .addContainerGap()
                .addGroup(PanelVentanaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(PanelBanner, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(PanelCuerpo, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addContainerGap())
        );
        PanelVentanaLayout.setVerticalGroup(
            PanelVentanaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelVentanaLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(PanelBanner, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(PanelCuerpo, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addContainerGap())
        );

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(PanelVentana, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(PanelVentana, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void formWindowOpened(java.awt.event.WindowEvent evt) {//GEN-FIRST:event_formWindowOpened
         FondoVentanas p = new FondoVentanas();
         PanelVentana.add(p);           
         PanelVentana.repaint();
         FondoBanner p2 = new FondoBanner();
         PanelBanner.add(p2);           
         PanelBanner.repaint();
    }//GEN-LAST:event_formWindowOpened

    private void BotonRegresarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_BotonRegresarActionPerformed
        ListadoSecciones ls= new ListadoSecciones(nombrecarrera,asignatura,codigo);
        ls.setVisible(true);
        dispose();
    }//GEN-LAST:event_BotonRegresarActionPerformed

    private void BotonGuardarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_BotonGuardarActionPerformed
        lista_seccion ls=new lista_seccion();
        int item=ComboProfesores.getSelectedIndex();
        try{
            
            if (txtSeccion.getText().equals(""))
            {
                Mensaje.showMessageDialog(this,"No puede dejar campos vacíos","Error",Mensaje.ERROR_MESSAGE);
            }
            else if(ls.seccionrepetida(codigo,txtSeccion.getText()))
            {
                Mensaje.showMessageDialog(this,"El número de sección "+txtSeccion.getText()+" ya fue ingresado en esta materia. Intente de nuevo.","Cédula Repetida",Mensaje.ERROR_MESSAGE);
            
            
            }
            else if(item==0){
            
                Mensaje.showMessageDialog(this,"Elija el profesor","Error",Mensaje.ERROR_MESSAGE);
            
            }
            else
            {
                ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("profesor.obj"));
                profesor aux=(profesor) entrada.readObject();
                entrada.close();
                int i=0;
                String cedp="";
                while (aux!=null)
                {
                    i++;
                    if (i==item)
                    {
                        cedp=aux.cedula;
                    }
                    aux=aux.sig;
                }
                seccion sec= new seccion(codigo,txtSeccion.getText(),cedp);
                ls.guardarseccion(sec);
                lista_materia lm= new lista_materia();
                lm.incrementarseccion(codigo);
                Mensaje.showMessageDialog(null,"Datos almacenados exitosamente.","Info",Mensaje.INFORMATION_MESSAGE);
                txtSeccion.setText("");
            }
        
        }catch (IOException ex) {
            System.out.println(ex);
            }catch (ClassNotFoundException ex) {
               System.out.println(ex);
            }
    }//GEN-LAST:event_BotonGuardarActionPerformed

    private void txtSeccionKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtSeccionKeyTyped
        char c= evt.getKeyChar();
        if ((c<'0') || (c>'9')) evt.consume();
    }//GEN-LAST:event_txtSeccionKeyTyped

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(AgregarSeccion.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(AgregarSeccion.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(AgregarSeccion.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(AgregarSeccion.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton BotonGuardar;
    private javax.swing.JButton BotonRegresar;
    private javax.swing.JComboBox ComboProfesores;
    private javax.swing.JLabel EtqAgregarSeccion;
    private javax.swing.JLabel EtqCarrera;
    private javax.swing.JLabel EtqCodigo;
    private javax.swing.JLabel EtqMateria;
    private javax.swing.JLabel EtqNSeccion;
    private javax.swing.JLabel EtqProfesor;
    private javax.swing.JOptionPane Mensaje;
    private javax.swing.JPanel PanelBanner;
    private javax.swing.JPanel PanelCuerpo;
    private javax.swing.JPanel PanelVentana;
    private javax.swing.JSeparator jSeparator1;
    private javax.swing.JTextField txtSeccion;
    // End of variables declaration//GEN-END:variables
}