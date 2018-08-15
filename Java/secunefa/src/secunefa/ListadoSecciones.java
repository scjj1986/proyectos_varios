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


public class ListadoSecciones extends javax.swing.JFrame {
    String nombrecarrera,codigo,asignatura;
    DefaultTableModel modelo;
    

    /**
     * Creates new form ListadoSecciones
     */
    public ListadoSecciones(String carrera, String asign, String cod) {
        initComponents();
        nombrecarrera=carrera;
        codigo=cod;
        asignatura=asign;
        String texto,texto2,texto3;
        texto="*Carrera: "+carrera;
        texto2=" Materia: "+asign;
        texto3=" Código: "+cod;
        EtqCarrera.setText(texto);
        EtqMateria.setText(texto2);
        EtqCodigo.setText(texto3);
        setSize(624,423);
        setResizable(false);
        lista_seccion ls= new lista_seccion();
        try{
        
            if (ls.existearchivo("seccion.obj"))
            {
                modelo= new DefaultTableModel();
                modelo.addColumn("Número");
                modelo.addColumn("Profesor");
                modelo.addColumn("Alumnos");
                this.TablaSecciones.setModel(modelo);
                seccion aux;
                profesor aux2;
                ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("seccion.obj"));
                ObjectInputStream entrada2;
                aux=(seccion) entrada.readObject();
                entrada.close();
                String []datos= new String[3];
                while (aux!=null)
                {
                    if (aux.codigomateria.equals(codigo))
                    {
                        datos[0]=aux.numero;
                        entrada2=new ObjectInputStream(new FileInputStream("profesor.obj"));
                        aux2=(profesor) entrada2.readObject();
                        while (aux2!=null)
                        {
                            if(aux.cedulaprofesor.equals(aux2.cedula))
                            {
                                datos[1]=aux2.nombre+" "+aux2.apellido;
                            
                            }
                            aux2=aux2.sig;
                        
                        }
                        datos[2]=Integer.toString(aux.alumnos);
                        modelo.addRow(datos);
                    
                    }
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

    
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        Mensaje = new javax.swing.JOptionPane();
        PanelVentana = new javax.swing.JPanel();
        PanelBanner = new javax.swing.JPanel();
        PanelCuerpo = new javax.swing.JPanel();
        EtqListadoSecciones = new javax.swing.JLabel();
        EtqCarrera = new javax.swing.JLabel();
        EtqMateria = new javax.swing.JLabel();
        EtqCodigo = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        TablaSecciones = new javax.swing.JTable();
        BotonVerAlumnos = new javax.swing.JButton();
        BotonRegresar = new javax.swing.JButton();
        BotonNuevaSeccion = new javax.swing.JButton();
        jSeparator1 = new javax.swing.JSeparator();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Listado de Secciones");
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
            .addGap(0, 0, Short.MAX_VALUE)
        );
        PanelBannerLayout.setVerticalGroup(
            PanelBannerLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 130, Short.MAX_VALUE)
        );

        PanelCuerpo.setBackground(new java.awt.Color(255, 255, 255));

        EtqListadoSecciones.setFont(new java.awt.Font("Lucida Console", 1, 16)); // NOI18N
        EtqListadoSecciones.setText("LISTADO DE SECCIONES");

        EtqCarrera.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqCarrera.setText("jLabel1");

        EtqMateria.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqMateria.setText("jLabel1");

        EtqCodigo.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqCodigo.setText("jLabel1");

        TablaSecciones.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {},
                {},
                {},
                {}
            },
            new String [] {

            }
        ));
        jScrollPane1.setViewportView(TablaSecciones);

        BotonVerAlumnos.setText("Ver Alumnos");
        BotonVerAlumnos.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                BotonVerAlumnosActionPerformed(evt);
            }
        });

        BotonRegresar.setText("Regresar");
        BotonRegresar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                BotonRegresarActionPerformed(evt);
            }
        });

        BotonNuevaSeccion.setText("Nueva Sección");
        BotonNuevaSeccion.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                BotonNuevaSeccionActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout PanelCuerpoLayout = new javax.swing.GroupLayout(PanelCuerpo);
        PanelCuerpo.setLayout(PanelCuerpoLayout);
        PanelCuerpoLayout.setHorizontalGroup(
            PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                .addContainerGap()
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(EtqCarrera, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(EtqCodigo, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(EtqMateria, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(jSeparator1, javax.swing.GroupLayout.Alignment.TRAILING))
                .addContainerGap())
            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                .addGap(192, 192, 192)
                .addComponent(EtqListadoSecciones)
                .addContainerGap())
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelCuerpoLayout.createSequentialGroup()
                .addContainerGap(113, Short.MAX_VALUE)
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelCuerpoLayout.createSequentialGroup()
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 279, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(160, 160, 160))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelCuerpoLayout.createSequentialGroup()
                        .addComponent(BotonNuevaSeccion, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(18, 18, 18)
                        .addComponent(BotonVerAlumnos, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(18, 18, 18)
                        .addComponent(BotonRegresar, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(95, 95, 95))))
        );
        PanelCuerpoLayout.setVerticalGroup(
            PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(EtqListadoSecciones)
                .addGap(2, 2, 2)
                .addComponent(jSeparator1, javax.swing.GroupLayout.PREFERRED_SIZE, 10, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(EtqCarrera)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(EtqMateria)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(EtqCodigo)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 88, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(BotonVerAlumnos, javax.swing.GroupLayout.PREFERRED_SIZE, 31, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(BotonRegresar, javax.swing.GroupLayout.PREFERRED_SIZE, 31, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(BotonNuevaSeccion, javax.swing.GroupLayout.PREFERRED_SIZE, 31, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(22, Short.MAX_VALUE))
        );

        javax.swing.GroupLayout PanelVentanaLayout = new javax.swing.GroupLayout(PanelVentana);
        PanelVentana.setLayout(PanelVentanaLayout);
        PanelVentanaLayout.setHorizontalGroup(
            PanelVentanaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelVentanaLayout.createSequentialGroup()
                .addContainerGap()
                .addGroup(PanelVentanaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(PanelCuerpo, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(PanelBanner, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addContainerGap())
        );
        PanelVentanaLayout.setVerticalGroup(
            PanelVentanaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelVentanaLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(PanelBanner, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(PanelCuerpo, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap())
        );

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(PanelVentana, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(PanelVentana, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
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
        ListadoMaterias lm= new ListadoMaterias(nombrecarrera);
        lm.setVisible(true);
        dispose();
    }//GEN-LAST:event_BotonRegresarActionPerformed

    private void BotonNuevaSeccionActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_BotonNuevaSeccionActionPerformed
        AgregarSeccion as= new AgregarSeccion (nombrecarrera,asignatura,codigo);
        as.setVisible(true);
        dispose();
    }//GEN-LAST:event_BotonNuevaSeccionActionPerformed

    private void BotonVerAlumnosActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_BotonVerAlumnosActionPerformed
        int fila=TablaSecciones.getSelectedRow();
        if (fila<0)
        {
            Mensaje.showMessageDialog(this,"No ha seleccionado la sección. Intente de nuevo.","Error",Mensaje.ERROR_MESSAGE);
        
        }
        else{
            String sc= modelo.getValueAt(fila, 0).toString();
            ListadoAlumnos la= new ListadoAlumnos(nombrecarrera,asignatura,codigo,sc);
            la.setVisible(true);
            dispose();
        }
    }//GEN-LAST:event_BotonVerAlumnosActionPerformed

    
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
            java.util.logging.Logger.getLogger(ListadoSecciones.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(ListadoSecciones.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(ListadoSecciones.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(ListadoSecciones.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton BotonNuevaSeccion;
    private javax.swing.JButton BotonRegresar;
    private javax.swing.JButton BotonVerAlumnos;
    private javax.swing.JLabel EtqCarrera;
    private javax.swing.JLabel EtqCodigo;
    private javax.swing.JLabel EtqListadoSecciones;
    private javax.swing.JLabel EtqMateria;
    private javax.swing.JOptionPane Mensaje;
    private javax.swing.JPanel PanelBanner;
    private javax.swing.JPanel PanelCuerpo;
    private javax.swing.JPanel PanelVentana;
    private javax.swing.JTable TablaSecciones;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JSeparator jSeparator1;
    // End of variables declaration//GEN-END:variables
}
