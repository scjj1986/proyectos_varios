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
public class AgregarAlumno extends javax.swing.JFrame {
    String carrera,asignatura,codigo,seccion;
    /**
     * Creates new form AgregarAlumno
     */
    public AgregarAlumno(String carr,String asign,String cod,String sec) {
        initComponents();
        carrera=carr;
        asignatura=asign;
        codigo=cod;
        seccion=sec;
        String texto,texto2,texto3,texto4;
        texto="*Carrera: "+carrera;
        texto2=" Materia: "+asign;
        texto3=" Código: "+cod;
        texto4=" Sección: "+sec;
        EtqCarrera.setText(texto);
        EtqMateria.setText(texto2);
        EtqCodigo.setText(texto3);
        EtqSeccion.setText(texto4);
        setSize(624,497);
        setResizable(false);
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
        EtqInscripcion = new javax.swing.JLabel();
        EtqCarrera = new javax.swing.JLabel();
        EtqMateria = new javax.swing.JLabel();
        EtqCodigo = new javax.swing.JLabel();
        EtqSeccion = new javax.swing.JLabel();
        jSeparator1 = new javax.swing.JSeparator();
        EtqCedula = new javax.swing.JLabel();
        EtqNombre = new javax.swing.JLabel();
        EtqDireccion = new javax.swing.JLabel();
        EtqApellido = new javax.swing.JLabel();
        txtCedula = new javax.swing.JTextField();
        txtNombre = new javax.swing.JTextField();
        txtApellido = new javax.swing.JTextField();
        txtDireccion = new javax.swing.JTextField();
        BotonGuardar = new javax.swing.JButton();
        BotonRegresar = new javax.swing.JButton();
        jSeparator2 = new javax.swing.JSeparator();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Agregar Alumno");
        setResizable(false);
        addWindowListener(new java.awt.event.WindowAdapter() {
            public void windowOpened(java.awt.event.WindowEvent evt) {
                formWindowOpened(evt);
            }
        });

        PanelBanner.setPreferredSize(new java.awt.Dimension(604, 130));

        javax.swing.GroupLayout PanelBannerLayout = new javax.swing.GroupLayout(PanelBanner);
        PanelBanner.setLayout(PanelBannerLayout);
        PanelBannerLayout.setHorizontalGroup(
            PanelBannerLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 0, Short.MAX_VALUE)
        );
        PanelBannerLayout.setVerticalGroup(
            PanelBannerLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 130, Short.MAX_VALUE)
        );

        PanelCuerpo.setBackground(new java.awt.Color(255, 255, 255));

        EtqInscripcion.setFont(new java.awt.Font("Lucida Console", 1, 16)); // NOI18N
        EtqInscripcion.setText("INSCRIPCIÓN DE ALUMNO");
        EtqInscripcion.setToolTipText("");

        EtqCarrera.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqCarrera.setText("INSCRIPCIÓN DE ALUMNO");
        EtqCarrera.setToolTipText("");

        EtqMateria.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqMateria.setText("INSCRIPCIÓN DE ALUMNO");
        EtqMateria.setToolTipText("");

        EtqCodigo.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqCodigo.setText("INSCRIPCIÓN DE ALUMNO");
        EtqCodigo.setToolTipText("");

        EtqSeccion.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqSeccion.setText("INSCRIPCIÓN DE ALUMNO");
        EtqSeccion.setToolTipText("");

        EtqCedula.setFont(new java.awt.Font("Lucida Console", 0, 14)); // NOI18N
        EtqCedula.setText("*Cédula");

        EtqNombre.setFont(new java.awt.Font("Lucida Console", 0, 14)); // NOI18N
        EtqNombre.setText("*Nombre");

        EtqDireccion.setFont(new java.awt.Font("Lucida Console", 0, 14)); // NOI18N
        EtqDireccion.setText("*Direccion");

        EtqApellido.setFont(new java.awt.Font("Lucida Console", 0, 14)); // NOI18N
        EtqApellido.setText("*Apellido");

        txtCedula.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtCedulaActionPerformed(evt);
            }
        });
        txtCedula.addFocusListener(new java.awt.event.FocusAdapter() {
            public void focusLost(java.awt.event.FocusEvent evt) {
                txtCedulaFocusLost(evt);
            }
        });
        txtCedula.addInputMethodListener(new java.awt.event.InputMethodListener() {
            public void caretPositionChanged(java.awt.event.InputMethodEvent evt) {
            }
            public void inputMethodTextChanged(java.awt.event.InputMethodEvent evt) {
                txtCedulaInputMethodTextChanged(evt);
            }
        });
        txtCedula.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtCedulaKeyTyped(evt);
            }
        });

        txtNombre.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtNombreActionPerformed(evt);
            }
        });
        txtNombre.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyPressed(java.awt.event.KeyEvent evt) {
                txtNombreKeyPressed(evt);
            }
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtNombreKeyTyped(evt);
            }
        });

        txtApellido.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtApellidoActionPerformed(evt);
            }
        });
        txtApellido.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtApellidoKeyTyped(evt);
            }
        });

        txtDireccion.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtDireccionActionPerformed(evt);
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

        javax.swing.GroupLayout PanelCuerpoLayout = new javax.swing.GroupLayout(PanelCuerpo);
        PanelCuerpo.setLayout(PanelCuerpoLayout);
        PanelCuerpoLayout.setHorizontalGroup(
            PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(PanelCuerpoLayout.createSequentialGroup()
                        .addGap(179, 179, 179)
                        .addComponent(EtqInscripcion))
                    .addGroup(PanelCuerpoLayout.createSequentialGroup()
                        .addContainerGap()
                        .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(EtqSeccion, javax.swing.GroupLayout.PREFERRED_SIZE, 205, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(EtqCodigo, javax.swing.GroupLayout.PREFERRED_SIZE, 205, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(EtqMateria, javax.swing.GroupLayout.PREFERRED_SIZE, 205, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(EtqCarrera, javax.swing.GroupLayout.PREFERRED_SIZE, 205, javax.swing.GroupLayout.PREFERRED_SIZE))))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelCuerpoLayout.createSequentialGroup()
                .addContainerGap()
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jSeparator1, javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(jSeparator2, javax.swing.GroupLayout.Alignment.TRAILING))
                .addContainerGap())
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelCuerpoLayout.createSequentialGroup()
                .addGap(0, 101, Short.MAX_VALUE)
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelCuerpoLayout.createSequentialGroup()
                        .addComponent(EtqApellido)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(txtApellido, javax.swing.GroupLayout.PREFERRED_SIZE, 131, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelCuerpoLayout.createSequentialGroup()
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(EtqCedula, javax.swing.GroupLayout.PREFERRED_SIZE, 63, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(txtCedula, javax.swing.GroupLayout.PREFERRED_SIZE, 74, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(56, 56, 56)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelCuerpoLayout.createSequentialGroup()
                        .addComponent(EtqDireccion)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(txtDireccion, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelCuerpoLayout.createSequentialGroup()
                        .addGap(21, 21, 21)
                        .addComponent(EtqNombre, javax.swing.GroupLayout.PREFERRED_SIZE, 61, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(txtNombre, javax.swing.GroupLayout.PREFERRED_SIZE, 148, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addGap(58, 58, 58))
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelCuerpoLayout.createSequentialGroup()
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(BotonGuardar, javax.swing.GroupLayout.PREFERRED_SIZE, 92, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addComponent(BotonRegresar, javax.swing.GroupLayout.PREFERRED_SIZE, 90, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(201, 201, 201))
        );
        PanelCuerpoLayout.setVerticalGroup(
            PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(EtqInscripcion)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(jSeparator2, javax.swing.GroupLayout.PREFERRED_SIZE, 10, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addComponent(EtqCarrera)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(EtqMateria)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(EtqCodigo)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(EtqSeccion)
                .addGap(18, 18, 18)
                .addComponent(jSeparator1, javax.swing.GroupLayout.PREFERRED_SIZE, 10, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(txtCedula, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(EtqCedula)
                    .addComponent(EtqNombre)
                    .addComponent(txtNombre, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(EtqApellido)
                    .addComponent(EtqDireccion)
                    .addComponent(txtApellido, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(txtDireccion, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(31, 31, 31)
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(BotonRegresar, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(BotonGuardar, javax.swing.GroupLayout.PREFERRED_SIZE, 31, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(34, 34, 34))
        );

        javax.swing.GroupLayout PanelVentanaLayout = new javax.swing.GroupLayout(PanelVentana);
        PanelVentana.setLayout(PanelVentanaLayout);
        PanelVentanaLayout.setHorizontalGroup(
            PanelVentanaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelVentanaLayout.createSequentialGroup()
                .addContainerGap()
                .addGroup(PanelVentanaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(PanelCuerpo, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(PanelBanner, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addContainerGap())
        );
        PanelVentanaLayout.setVerticalGroup(
            PanelVentanaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelVentanaLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(PanelBanner, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(PanelCuerpo, javax.swing.GroupLayout.PREFERRED_SIZE, 318, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
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

    private void txtDireccionActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtDireccionActionPerformed
        
    }//GEN-LAST:event_txtDireccionActionPerformed

    private void BotonRegresarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_BotonRegresarActionPerformed
        ListadoAlumnos la= new ListadoAlumnos(carrera,asignatura,codigo,seccion);
        la.setVisible(true);
        dispose();
    }//GEN-LAST:event_BotonRegresarActionPerformed

    private void BotonGuardarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_BotonGuardarActionPerformed
        
        
        lista_profesor lp= new lista_profesor();
        lista_inscritos li=new lista_inscritos();
        try{
            if ((txtNombre.getText().equals("")) || (txtCedula.getText().equals("")) || (txtApellido.getText().equals("")) || (txtDireccion.getText().equals("")))
            {
                
                Mensaje.showMessageDialog(this,"No puede dejar campos vacíos","Error",Mensaje.ERROR_MESSAGE);
            }
            else if (lp.cedularepetida(txtCedula.getText()))
            {
            
                Mensaje.showMessageDialog(this,"La cédula ingresada coincide con la de algún profesor. Intente con otro valor.","Error",Mensaje.ERROR_MESSAGE);
            }
            else if (li.inscritorepetido(codigo,txtCedula.getText()))
            {
                Mensaje.showMessageDialog(this,"La cédula ingresada coincide con la de algún alumno inscrito en esta materia. Intente con otro valor.","Error",Mensaje.ERROR_MESSAGE);
            
            }
            else
            {
                inscribe ins= new inscribe(codigo,txtCedula.getText(),seccion);
                li.guardarinscrito(ins);
                lista_alumno la=new lista_alumno();
                if (!la.cedularepetida(txtCedula.getText()))
                {
                    alumno al=new alumno(txtCedula.getText(),txtNombre.getText().toUpperCase(),txtApellido.getText().toUpperCase(),txtDireccion.getText().toUpperCase());
                    la.guardaralumno(al);
                }
                else{
                
                    la.actualizaralumno(txtCedula.getText(),txtNombre.getText().toUpperCase(),txtApellido.getText().toUpperCase(),txtDireccion.getText().toUpperCase());
                    
                
                }
                lista_seccion ls= new lista_seccion();
                ls.incrementaralumno(codigo, seccion);
                Mensaje.showMessageDialog(null,"Datos almacenados exitosamente.","Info",Mensaje.INFORMATION_MESSAGE);
                txtNombre.setText("");
                txtCedula.setText("");
                txtApellido.setText("");
                txtDireccion.setText("");
            }
    
    
        }
        catch (IOException ex) {
            System.out.println(ex);
            }catch (ClassNotFoundException ex) {
               System.out.println(ex);
            }
    }//GEN-LAST:event_BotonGuardarActionPerformed

    private void txtNombreKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtNombreKeyTyped
        char c= evt.getKeyChar();
        if (((c<'a') || (c>'z')) && ((c<'A') || (c>'Z')) && (c!=' ')) evt.consume();
    }//GEN-LAST:event_txtNombreKeyTyped

    private void txtApellidoKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtApellidoKeyTyped
        char c= evt.getKeyChar();
        if (((c<'a') || (c>'z')) && ((c<'A') || (c>'Z')) && (c!=' ')) evt.consume();
    }//GEN-LAST:event_txtApellidoKeyTyped

    private void txtCedulaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtCedulaActionPerformed
        
    }//GEN-LAST:event_txtCedulaActionPerformed

    private void txtCedulaKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtCedulaKeyTyped
        
        
        char c= evt.getKeyChar();
        if ((c<'0') || (c>'9'))
        {evt.consume();
        
        }
    }//GEN-LAST:event_txtCedulaKeyTyped

    private void txtNombreActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtNombreActionPerformed
        
    }//GEN-LAST:event_txtNombreActionPerformed

    private void txtApellidoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtApellidoActionPerformed
        
    }//GEN-LAST:event_txtApellidoActionPerformed

    private void txtNombreKeyPressed(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtNombreKeyPressed
        
    }//GEN-LAST:event_txtNombreKeyPressed

    private void txtCedulaInputMethodTextChanged(java.awt.event.InputMethodEvent evt) {//GEN-FIRST:event_txtCedulaInputMethodTextChanged
        
    }//GEN-LAST:event_txtCedulaInputMethodTextChanged

    private void txtCedulaFocusLost(java.awt.event.FocusEvent evt) {//GEN-FIRST:event_txtCedulaFocusLost
        try{
                        ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("alumno.obj"));
                        alumno aux= (alumno)entrada.readObject();
                        entrada.close();
                        while (aux!=null)
                        {
                            if(aux.cedula.equals(txtCedula.getText()))
                            {
                                txtNombre.setText(aux.nombre);
                                txtApellido.setText(aux.apellido);
                                txtDireccion.setText(aux.direccion);
                            }
                            aux=aux.sig;
                        
                        }
        
        }
        catch (IOException ex) {
        System.out.println(ex);
        }catch (ClassNotFoundException ex) {
               System.out.println(ex);
        }
    }//GEN-LAST:event_txtCedulaFocusLost

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
            java.util.logging.Logger.getLogger(AgregarAlumno.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(AgregarAlumno.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(AgregarAlumno.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(AgregarAlumno.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton BotonGuardar;
    private javax.swing.JButton BotonRegresar;
    private javax.swing.JLabel EtqApellido;
    private javax.swing.JLabel EtqCarrera;
    private javax.swing.JLabel EtqCedula;
    private javax.swing.JLabel EtqCodigo;
    private javax.swing.JLabel EtqDireccion;
    private javax.swing.JLabel EtqInscripcion;
    private javax.swing.JLabel EtqMateria;
    private javax.swing.JLabel EtqNombre;
    private javax.swing.JLabel EtqSeccion;
    private javax.swing.JOptionPane Mensaje;
    private javax.swing.JPanel PanelBanner;
    private javax.swing.JPanel PanelCuerpo;
    private javax.swing.JPanel PanelVentana;
    private javax.swing.JSeparator jSeparator1;
    private javax.swing.JSeparator jSeparator2;
    private javax.swing.JTextField txtApellido;
    private javax.swing.JTextField txtCedula;
    private javax.swing.JTextField txtDireccion;
    private javax.swing.JTextField txtNombre;
    // End of variables declaration//GEN-END:variables
}
