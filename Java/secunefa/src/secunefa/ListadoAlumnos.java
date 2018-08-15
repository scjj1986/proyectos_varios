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

public class ListadoAlumnos extends javax.swing.JFrame {

    String carrera,asignatura,codigo,seccion;
    DefaultTableModel modelo;
    
    public ListadoAlumnos(String carr,String asign,String codasign,String sec) {
        initComponents();
        carrera=carr;
        asignatura=asign;
        codigo=codasign;
        seccion=sec;
        String texto,texto2,texto3,texto4;
        texto="*Carrera: "+carrera;
        texto2=" Materia: "+asign;
        texto3=" Código: "+codasign;
        texto4=" Sección: "+sec;
        EtqCarrera.setText(texto);
        EtqMateria.setText(texto2);
        EtqCodigo.setText(texto3);
        EtqSeccion.setText(texto4);
        setSize(624,524);
        setResizable(false);
        lista_seccion ls= new lista_seccion();
        try{
        
            if (ls.existearchivo("seccion.obj"))
            {
                modelo= new DefaultTableModel();
                modelo.addColumn("Cédula");
                modelo.addColumn("Nombre");
                modelo.addColumn("Apellido");
                modelo.addColumn("Dirección");
                modelo.addColumn("Nota");
                this.TablaAlumnos.setModel(modelo);
                inscribe aux;
                alumno aux2;
                ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("inscritos.obj"));
                ObjectInputStream entrada2;
                aux=(inscribe) entrada.readObject();
                entrada.close();
                String []datos= new String[5];
                while (aux!=null)
                {
                    if ((aux.codigomateria.equals(codigo))&& (aux.seccion.equals(seccion)))
                    {
                        entrada2=new ObjectInputStream(new FileInputStream("alumno.obj"));
                        aux2=(alumno) entrada2.readObject();
                        entrada2.close();
                        while (aux2!=null)
                        {
                            if(aux.cedulaalumno.equals(aux2.cedula))
                            {
                                datos[0]=aux2.cedula;
                                datos[1]=aux2.nombre;
                                datos[2]=aux2.apellido;
                                datos[3]=aux2.direccion;
                                datos[4]=Integer.toString(aux.nota);
                                modelo.addRow(datos);
                            
                            }
                            aux2=aux2.sig;
                        
                        }
                        
                    
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
        EtqListadoAlumnos = new javax.swing.JLabel();
        EtqCodigo = new javax.swing.JLabel();
        EtqCarrera = new javax.swing.JLabel();
        EtqMateria = new javax.swing.JLabel();
        EtqSeccion = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        TablaAlumnos = new javax.swing.JTable();
        BotonAgregarAlumno = new javax.swing.JButton();
        BotonAsignarNota = new javax.swing.JButton();
        BotonRegresar = new javax.swing.JButton();
        jSeparator1 = new javax.swing.JSeparator();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Listado de Alumnos");
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

        EtqListadoAlumnos.setFont(new java.awt.Font("Lucida Console", 1, 16)); // NOI18N
        EtqListadoAlumnos.setText("LISTADO DE ALUMNOS");

        EtqCodigo.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqCodigo.setText("LISTADO DE ALUMNOS");

        EtqCarrera.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqCarrera.setText("LISTADO DE ALUMNOS");

        EtqMateria.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqMateria.setText("LISTADO DE ALUMNOS");

        EtqSeccion.setFont(new java.awt.Font("Lucida Console", 1, 14)); // NOI18N
        EtqSeccion.setText("LISTADO DE ALUMNOS");

        TablaAlumnos.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {},
                {},
                {},
                {}
            },
            new String [] {

            }
        ));
        jScrollPane1.setViewportView(TablaAlumnos);

        BotonAgregarAlumno.setText("Nuevo Alumno");
        BotonAgregarAlumno.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                BotonAgregarAlumnoActionPerformed(evt);
            }
        });

        BotonAsignarNota.setText("Asignar Nota");
        BotonAsignarNota.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                BotonAsignarNotaActionPerformed(evt);
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
                .addGap(110, 110, 110)
                .addComponent(BotonAgregarAlumno, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addComponent(BotonAsignarNota, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addComponent(BotonRegresar, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(0, 0, Short.MAX_VALUE))
            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(PanelCuerpoLayout.createSequentialGroup()
                        .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                                .addGap(198, 198, 198)
                                .addComponent(EtqListadoAlumnos))
                            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                                .addContainerGap()
                                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                                    .addComponent(EtqCodigo, javax.swing.GroupLayout.PREFERRED_SIZE, 529, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(EtqCarrera, javax.swing.GroupLayout.PREFERRED_SIZE, 529, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(EtqMateria, javax.swing.GroupLayout.PREFERRED_SIZE, 529, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(EtqSeccion, javax.swing.GroupLayout.PREFERRED_SIZE, 529, javax.swing.GroupLayout.PREFERRED_SIZE))))
                        .addGap(0, 55, Short.MAX_VALUE))
                    .addGroup(PanelCuerpoLayout.createSequentialGroup()
                        .addContainerGap()
                        .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jSeparator1, javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(jScrollPane1))))
                .addContainerGap())
        );
        PanelCuerpoLayout.setVerticalGroup(
            PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelCuerpoLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(EtqListadoAlumnos, javax.swing.GroupLayout.PREFERRED_SIZE, 23, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jSeparator1, javax.swing.GroupLayout.PREFERRED_SIZE, 10, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(8, 8, 8)
                .addComponent(EtqCarrera, javax.swing.GroupLayout.PREFERRED_SIZE, 24, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(EtqMateria, javax.swing.GroupLayout.PREFERRED_SIZE, 24, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(EtqCodigo, javax.swing.GroupLayout.PREFERRED_SIZE, 24, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(EtqSeccion, javax.swing.GroupLayout.PREFERRED_SIZE, 24, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 110, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 41, Short.MAX_VALUE)
                .addGroup(PanelCuerpoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(BotonAsignarNota, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 33, Short.MAX_VALUE)
                    .addComponent(BotonAgregarAlumno, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(BotonRegresar, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addContainerGap())
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
        ListadoSecciones ls= new ListadoSecciones(carrera, asignatura, codigo);
        ls.setVisible(true);
        dispose();
    }//GEN-LAST:event_BotonRegresarActionPerformed

    private void BotonAgregarAlumnoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_BotonAgregarAlumnoActionPerformed
        AgregarAlumno aa= new AgregarAlumno(carrera,asignatura,codigo,seccion);
        aa.setVisible(true);
        dispose();
    }//GEN-LAST:event_BotonAgregarAlumnoActionPerformed

    private void BotonAsignarNotaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_BotonAsignarNotaActionPerformed
        int fila=TablaAlumnos.getSelectedRow();
        if (fila<0)
        {
            Mensaje.showMessageDialog(this,"No ha seleccionado el alumno. Intente de nuevo.","Error",Mensaje.ERROR_MESSAGE);
        
        }
        else{
            String ced=modelo.getValueAt(fila, 0).toString();
            AsignarNota an= new AsignarNota (carrera,asignatura,codigo,seccion,ced);
            an.setVisible(true);
            dispose();
        }
    }//GEN-LAST:event_BotonAsignarNotaActionPerformed

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
            java.util.logging.Logger.getLogger(ListadoAlumnos.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(ListadoAlumnos.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(ListadoAlumnos.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(ListadoAlumnos.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton BotonAgregarAlumno;
    private javax.swing.JButton BotonAsignarNota;
    private javax.swing.JButton BotonRegresar;
    private javax.swing.JLabel EtqCarrera;
    private javax.swing.JLabel EtqCodigo;
    private javax.swing.JLabel EtqListadoAlumnos;
    private javax.swing.JLabel EtqMateria;
    private javax.swing.JLabel EtqSeccion;
    private javax.swing.JOptionPane Mensaje;
    private javax.swing.JPanel PanelBanner;
    private javax.swing.JPanel PanelCuerpo;
    private javax.swing.JPanel PanelVentana;
    private javax.swing.JTable TablaAlumnos;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JSeparator jSeparator1;
    // End of variables declaration//GEN-END:variables
}