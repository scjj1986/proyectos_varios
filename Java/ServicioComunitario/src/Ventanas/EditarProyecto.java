/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Ventanas;

import Clases.*;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.text.*;
import java.util.Date;

public class EditarProyecto extends javax.swing.JFrame {
    DefaultTableModel modelo,modelo2;
    BaseDatos bd;
    String fechainicio;
    String consulta,consulta2;
    String tuplas [][],tuplas2[][];
    String linea[];
    int i;
    public String id,nm;
    /**
     * Creates new form IniciarSesion
     */
    public EditarProyecto(String nombre, String cuo, String carrera, String tutor) {
        this.setResizable(false);
        initComponents();
        nm=nombre;
        modelo = new DefaultTableModel();
        this.tblProfesor.setModel(modelo);
        modelo.addColumn("CEDULA");
        modelo.addColumn("NOMBRE");
        modelo.addColumn("APELLIDO");
        modelo2 = new DefaultTableModel();
        this.tblAlumno.setModel(modelo2);
        modelo2.addColumn("CEDULA");
        modelo2.addColumn("NOMBRE");
        modelo2.addColumn("APELLIDO");
        modelo2.addColumn("SEMESTRE");
        bd= new BaseDatos();
        cmbCuo.addItem(cuo);
        consulta= "SELECT * from cuo ORDER BY year DESC";
        tuplas = new String [bd.n_tuplas(consulta)][2];
        bd.obtener_tuplas(consulta, tuplas, 2);
        for (i=0;i<bd.n_tuplas(consulta); i++){
            this.cmbCuo.addItem(tuplas[i][0]+"-"+tuplas[i][1]);
        
        }
        cmbCarrera.addItem(carrera);
        consulta= "SELECT * from carrera ORDER BY nombre";
        tuplas = new String [bd.n_tuplas(consulta)][1];
        bd.obtener_tuplas(consulta, tuplas, 1);
        for (i=0;i<bd.n_tuplas(consulta); i++){
            cmbCarrera.addItem(tuplas[i][0]);
        
        }
        txtCedulaP.setEnabled(true);
        txtNombreP.setEnabled(true);
        txtNombre.setText(nombre);
        consulta= "SELECT * from proyecto WHERE nombre='"+nombre+"'";
        if (bd.n_tuplas(consulta)>0){

            tuplas = new String [bd.n_tuplas(consulta)][10];
            bd.obtener_tuplas(consulta,tuplas,10);
            id=tuplas[0][0];
            fechainicio=tuplas[0][8];
            linea= new String [4];
            consulta2= "SElECT * FROM tutor WHERE ve='"+tuplas[0][3].substring(0,2)+"'AND cedula='"+tuplas[0][3].substring(2,tuplas[0][3].length())+"'";
            tuplas2= new String [bd.n_tuplas(consulta2)][5];
            bd.obtener_tuplas(consulta2,tuplas2,5);
            txtCedulaP.setText(tuplas2[0][1]+tuplas2[0][2]);
            txtNombreP.setText(tuplas2[0][3]+" "+tuplas2[0][4]);
            consulta2= "SElECT * FROM tutor WHERE ve='"+tuplas[0][4].substring(0,2)+"'AND cedula='"+tuplas[0][4].substring(2,tuplas[0][4].length())+"'";
            tuplas2= new String [bd.n_tuplas(consulta2)][6];
            bd.obtener_tuplas(consulta2,tuplas2,6);
            cmbCedTut.addItem(tuplas2[0][1]);
            cmbCedTut.addItem("V-");
            cmbCedTut.addItem("E-");
            txtCedTut.setText(tuplas2[0][2]);
            txtNombrTut.setText(tuplas2[0][3]);
            txtApeTut.setText(tuplas2[0][4]);
            txtTlfTut.setText(tuplas2[0][5]);
            dchFechaInicio.setDate(obtenerfecha());
            cmbTipoProyecto.addItem(tuplas[0][7]);
            cmbTipoProyecto.addItem("UNEFA va a la escuela");
            cmbTipoProyecto.addItem("UNEFA va a la comunidad");
            cmbTipoProyecto.addItem("UNEFA va a los centros penitenciarios");
            cmbTipoProyecto.addItem("Enmarcado al programa TODAS LAS MANOS A LA SIEMBRA"); 
            //dchFechaInicio.setDate(tuplas[0][8]);

        }
        txtCedulaP.setEnabled(false);
        txtNombreP.setEnabled(false);
        txtNombre.setText(nombre);
        consulta= "SELECT * from realiza WHERE nombreproyecto='"+nombre+"'";
        tuplas = new String [bd.n_tuplas(consulta)][2];
        if (bd.n_tuplas(consulta)>0){

            tuplas= new String [bd.n_tuplas(consulta)][2];
            bd.obtener_tuplas(consulta,tuplas,2);
            for (int i=0; i<bd.n_tuplas(consulta); i++){

                linea= new String [4];
                consulta2= "SElECT * FROM alumno WHERE ve='"+tuplas[i][1].substring(0,2)+"'AND cedula='"+tuplas[i][1].substring(2,tuplas[i][1].length())+"'";
                tuplas2= new String [bd.n_tuplas(consulta2)][6];
                bd.obtener_tuplas(consulta2,tuplas2,6);
                linea[0]=tuplas[i][1];
                linea[1]=tuplas2[0][3];
                linea[2]=tuplas2[0][4];
                linea[3]=tuplas2[0][5];
                modelo2.addRow(linea);

            }
        }
    }
    
    public Date obtenerfecha(){
        Date fecha=null;
        SimpleDateFormat formatoDelTexto = new SimpleDateFormat("dd/MM/yyyy");
        try{
            fecha = formatoDelTexto.parse(fechainicio);
        
        }
        catch (ParseException ex){
        
            ex.printStackTrace();
        }
        return fecha;
    
    
    
    }
    
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabel5 = new javax.swing.JLabel();
        Mensaje = new javax.swing.JOptionPane();
        PanelVentana = new javax.swing.JPanel();
        PanelBanner = new javax.swing.JPanel();
        jLabel1 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        jLabel7 = new javax.swing.JLabel();
        jLabel8 = new javax.swing.JLabel();
        jScrollPane5 = new javax.swing.JScrollPane();
        jPanel1 = new javax.swing.JPanel();
        jLabel6 = new javax.swing.JLabel();
        PanelEditar = new javax.swing.JPanel();
        jLabel9 = new javax.swing.JLabel();
        cmbCuo = new javax.swing.JComboBox();
        jLabel10 = new javax.swing.JLabel();
        cmbCarrera = new javax.swing.JComboBox();
        jLabel11 = new javax.swing.JLabel();
        jLabel12 = new javax.swing.JLabel();
        cmbBuscar = new javax.swing.JComboBox();
        jLabel13 = new javax.swing.JLabel();
        txtValor = new javax.swing.JTextField();
        jScrollPane1 = new javax.swing.JScrollPane();
        tblAlumno = new javax.swing.JTable();
        btnElegir = new javax.swing.JButton();
        jLabel14 = new javax.swing.JLabel();
        jLabel15 = new javax.swing.JLabel();
        jScrollPane2 = new javax.swing.JScrollPane();
        tblProfesor = new javax.swing.JTable();
        jLabel16 = new javax.swing.JLabel();
        txtCedula = new javax.swing.JTextField();
        jLabel17 = new javax.swing.JLabel();
        txtNombr = new javax.swing.JTextField();
        jLabel19 = new javax.swing.JLabel();
        txtApellido = new javax.swing.JTextField();
        jLabel20 = new javax.swing.JLabel();
        txtSemestre = new javax.swing.JTextField();
        btnAgregar = new javax.swing.JButton();
        jLabel18 = new javax.swing.JLabel();
        jLabel21 = new javax.swing.JLabel();
        jScrollPane3 = new javax.swing.JScrollPane();
        txtNombre = new javax.swing.JTextArea();
        jLabel22 = new javax.swing.JLabel();
        btnEliminar = new javax.swing.JButton();
        jSeparator1 = new javax.swing.JSeparator();
        btnGuardar = new javax.swing.JButton();
        btnSalir = new javax.swing.JButton();
        cmbCedula = new javax.swing.JComboBox();
        txtCedulaP = new javax.swing.JTextField();
        txtNombreP = new javax.swing.JTextField();
        jLabel23 = new javax.swing.JLabel();
        dchFechaInicio = new com.toedter.calendar.JDateChooser();
        jLabel24 = new javax.swing.JLabel();
        cmbTipoProyecto = new javax.swing.JComboBox();
        jLabel25 = new javax.swing.JLabel();
        jLabel26 = new javax.swing.JLabel();
        cmbCedTut = new javax.swing.JComboBox();
        txtCedTut = new javax.swing.JTextField();
        txtNombrTut = new javax.swing.JTextField();
        jLabel27 = new javax.swing.JLabel();
        jLabel28 = new javax.swing.JLabel();
        txtApeTut = new javax.swing.JTextField();
        jLabel29 = new javax.swing.JLabel();
        txtTlfTut = new javax.swing.JTextField();

        jLabel5.setFont(new java.awt.Font("Times New Roman", 1, 18)); // NOI18N
        jLabel5.setText("UNIVERSIDAD NACIONAL EXPERIMENTAL POLITÉCNICA");

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Agregar Proyecto");
        setPreferredSize(new java.awt.Dimension(620, 700));
        setResizable(false);
        addWindowListener(new java.awt.event.WindowAdapter() {
            public void windowOpened(java.awt.event.WindowEvent evt) {
                formWindowOpened(evt);
            }
        });

        PanelVentana.setPreferredSize(new java.awt.Dimension(620, 423));

        jLabel1.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel1.setText("REPÚBLICA BOLIVARIANA DE VENEZUELA");

        jLabel3.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel3.setText("MINISTERIO DEL PODER POPULAR PARA LA DEFENSA");

        jLabel4.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel4.setText("UNIVERSIDAD NACIONAL EXPERIMENTAL POLITÉCNICA");

        jLabel7.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel7.setText("DE LA FUERZA ARMADA BOLIVARIANA");

        jLabel8.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel8.setText("NÚCLEO NUEVA ESPARTA");

        javax.swing.GroupLayout PanelBannerLayout = new javax.swing.GroupLayout(PanelBanner);
        PanelBanner.setLayout(PanelBannerLayout);
        PanelBannerLayout.setHorizontalGroup(
            PanelBannerLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelBannerLayout.createSequentialGroup()
                .addGap(107, 107, 107)
                .addGroup(PanelBannerLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelBannerLayout.createSequentialGroup()
                        .addComponent(jLabel3)
                        .addGap(9, 9, 9))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelBannerLayout.createSequentialGroup()
                        .addComponent(jLabel7)
                        .addGap(57, 57, 57))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelBannerLayout.createSequentialGroup()
                        .addComponent(jLabel1)
                        .addGap(51, 51, 51))
                    .addComponent(jLabel4, javax.swing.GroupLayout.Alignment.TRAILING)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelBannerLayout.createSequentialGroup()
                        .addComponent(jLabel8)
                        .addGap(99, 99, 99)))
                .addContainerGap(110, Short.MAX_VALUE))
        );
        PanelBannerLayout.setVerticalGroup(
            PanelBannerLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelBannerLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel1, javax.swing.GroupLayout.PREFERRED_SIZE, 27, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(1, 1, 1)
                .addComponent(jLabel3, javax.swing.GroupLayout.PREFERRED_SIZE, 22, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jLabel4, javax.swing.GroupLayout.PREFERRED_SIZE, 22, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jLabel7, javax.swing.GroupLayout.PREFERRED_SIZE, 17, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(jLabel8)
                .addContainerGap(43, Short.MAX_VALUE))
        );

        jPanel1.setBackground(new java.awt.Color(255, 255, 255));
        jPanel1.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(105, 113, 191), 3));
        jPanel1.setPreferredSize(new java.awt.Dimension(600, 1250));

        jLabel6.setFont(new java.awt.Font("Times New Roman", 1, 16)); // NOI18N
        jLabel6.setText("1) CUO:");

        PanelEditar.setBackground(new java.awt.Color(255, 255, 255));
        PanelEditar.setPreferredSize(new java.awt.Dimension(50, 50));

        javax.swing.GroupLayout PanelEditarLayout = new javax.swing.GroupLayout(PanelEditar);
        PanelEditar.setLayout(PanelEditarLayout);
        PanelEditarLayout.setHorizontalGroup(
            PanelEditarLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 50, Short.MAX_VALUE)
        );
        PanelEditarLayout.setVerticalGroup(
            PanelEditarLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 50, Short.MAX_VALUE)
        );

        jLabel9.setFont(new java.awt.Font("Times New Roman", 1, 18)); // NOI18N
        jLabel9.setText("EDITAR PROYECTO");

        jLabel10.setFont(new java.awt.Font("Times New Roman", 1, 16)); // NOI18N
        jLabel10.setText("2) CARRERA:");

        jLabel11.setFont(new java.awt.Font("Times New Roman", 1, 16)); // NOI18N
        jLabel11.setText("3) TUTOR ACADÉMICO:");

        jLabel12.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel12.setText("* Buscar por:");

        cmbBuscar.setModel(new javax.swing.DefaultComboBoxModel(new String[] { "Cédula", "Nombre", "Apellido" }));

        jLabel13.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel13.setText("* Ingrese valor:");

        txtValor.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyPressed(java.awt.event.KeyEvent evt) {
                txtValorKeyPressed(evt);
            }
        });

        tblAlumno.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {
                "CÉDULA", "NOMBRE", "APELLIDO", "SEMESTRE"
            }
        ));
        jScrollPane1.setViewportView(tblAlumno);

        btnElegir.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Imagenes/elegir.jpg"))); // NOI18N
        btnElegir.setText(" Elegir Profesor");
        btnElegir.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnElegirActionPerformed(evt);
            }
        });

        jLabel14.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel14.setText("*Cédula:");

        jLabel15.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel15.setText("*Nombre:");

        tblProfesor.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {
                "CÉDULA", "NOMBRE", "APELLIDO"
            }
        ));
        jScrollPane2.setViewportView(tblProfesor);

        jLabel16.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel16.setText("*Cédula:");

        txtCedula.addFocusListener(new java.awt.event.FocusAdapter() {
            public void focusLost(java.awt.event.FocusEvent evt) {
                txtCedulaFocusLost(evt);
            }
        });
        txtCedula.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtCedulaKeyTyped(evt);
            }
        });

        jLabel17.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel17.setText("*Nombre:");

        txtNombr.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtNombrKeyTyped(evt);
            }
        });

        jLabel19.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel19.setText("*Apellido:");

        txtApellido.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtApellidoKeyTyped(evt);
            }
        });

        jLabel20.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel20.setText("*Semestre:");

        txtSemestre.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtSemestreKeyTyped(evt);
            }
        });

        btnAgregar.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Imagenes/Agregarpeq.jpg"))); // NOI18N
        btnAgregar.setText(" Agregar a lista");
        btnAgregar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnAgregarActionPerformed(evt);
            }
        });

        jLabel18.setFont(new java.awt.Font("Times New Roman", 1, 16)); // NOI18N
        jLabel18.setText("6) FECHA DE INICIO:");

        jLabel21.setFont(new java.awt.Font("Times New Roman", 1, 16)); // NOI18N
        jLabel21.setText("8) ESTUDIANTES:");

        txtNombre.setColumns(20);
        txtNombre.setRows(5);
        jScrollPane3.setViewportView(txtNombre);

        jLabel22.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel22.setText("DATOS DEL TUTOR SELECCIONADO:");

        btnEliminar.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Imagenes/Eliminarpeq.jpg"))); // NOI18N
        btnEliminar.setText(" Eliminar de lista");
        btnEliminar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnEliminarActionPerformed(evt);
            }
        });

        btnGuardar.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Imagenes/guardar.jpg"))); // NOI18N
        btnGuardar.setText("Guardar");
        btnGuardar.setBorder(null);
        btnGuardar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnGuardarActionPerformed(evt);
            }
        });

        btnSalir.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Imagenes/volver.jpg"))); // NOI18N
        btnSalir.setText("Volver");
        btnSalir.setActionCommand(" Volver");
        btnSalir.setBorder(null);
        btnSalir.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnSalirActionPerformed(evt);
            }
        });

        cmbCedula.setModel(new javax.swing.DefaultComboBoxModel(new String[] { "V-", "E-" }));
        cmbCedula.addFocusListener(new java.awt.event.FocusAdapter() {
            public void focusLost(java.awt.event.FocusEvent evt) {
                cmbCedulaFocusLost(evt);
            }
        });

        txtCedulaP.setEnabled(false);

        txtNombreP.setEnabled(false);

        jLabel23.setFont(new java.awt.Font("Times New Roman", 1, 16)); // NOI18N
        jLabel23.setText("5) NOMBRE:");

        jLabel24.setFont(new java.awt.Font("Times New Roman", 1, 16)); // NOI18N
        jLabel24.setText("7) TIPO:");

        jLabel25.setFont(new java.awt.Font("Times New Roman", 1, 16)); // NOI18N
        jLabel25.setText("4) TUTOR COMUNITARIO:");

        jLabel26.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel26.setText("*Cédula:");

        cmbCedTut.addFocusListener(new java.awt.event.FocusAdapter() {
            public void focusLost(java.awt.event.FocusEvent evt) {
                cmbCedTutFocusLost(evt);
            }
        });

        txtCedTut.addFocusListener(new java.awt.event.FocusAdapter() {
            public void focusLost(java.awt.event.FocusEvent evt) {
                txtCedTutFocusLost(evt);
            }
        });
        txtCedTut.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtCedTutKeyTyped(evt);
            }
        });

        txtNombrTut.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtNombrTutKeyTyped(evt);
            }
        });

        jLabel27.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel27.setText("*Nombre:");

        jLabel28.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel28.setText("*Apellido:");

        txtApeTut.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtApeTutKeyTyped(evt);
            }
        });

        jLabel29.setFont(new java.awt.Font("Times New Roman", 1, 14)); // NOI18N
        jLabel29.setText("*Teléfono:");

        txtTlfTut.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtTlfTutKeyTyped(evt);
            }
        });

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addGap(27, 27, 27)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addComponent(jLabel17)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(txtNombr, javax.swing.GroupLayout.PREFERRED_SIZE, 103, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(0, 0, Short.MAX_VALUE))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addComponent(jLabel13)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                        .addComponent(txtValor, javax.swing.GroupLayout.PREFERRED_SIZE, 123, javax.swing.GroupLayout.PREFERRED_SIZE))
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addGap(24, 24, 24)
                                        .addComponent(jLabel12)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(cmbBuscar, javax.swing.GroupLayout.PREFERRED_SIZE, 121, javax.swing.GroupLayout.PREFERRED_SIZE)))
                                .addGap(18, 18, 18)
                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(jLabel22, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addComponent(jLabel14, javax.swing.GroupLayout.PREFERRED_SIZE, 60, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(txtCedulaP, javax.swing.GroupLayout.PREFERRED_SIZE, 86, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addGap(0, 0, Short.MAX_VALUE))))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 299, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(0, 0, Short.MAX_VALUE)))
                        .addContainerGap())
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel11)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(jLabel6)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(cmbCuo, javax.swing.GroupLayout.PREFERRED_SIZE, 125, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(47, 47, 47)
                                .addComponent(jLabel10, javax.swing.GroupLayout.PREFERRED_SIZE, 102, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(cmbCarrera, javax.swing.GroupLayout.PREFERRED_SIZE, 157, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(btnAgregar)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(btnEliminar))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 231, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(18, 18, 18)
                                .addComponent(jLabel15)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(txtNombreP, javax.swing.GroupLayout.PREFERRED_SIZE, 183, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGap(10, 10, 10)
                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addComponent(jLabel18)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(dchFechaInicio, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addGroup(jPanel1Layout.createSequentialGroup()
                                                .addComponent(jLabel24)
                                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                .addComponent(cmbTipoProyecto, javax.swing.GroupLayout.PREFERRED_SIZE, 361, javax.swing.GroupLayout.PREFERRED_SIZE))
                                            .addGroup(jPanel1Layout.createSequentialGroup()
                                                .addComponent(jLabel29)
                                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                .addComponent(txtTlfTut, javax.swing.GroupLayout.PREFERRED_SIZE, 90, javax.swing.GroupLayout.PREFERRED_SIZE))
                                            .addComponent(jLabel21)
                                            .addGroup(jPanel1Layout.createSequentialGroup()
                                                .addComponent(jLabel16)
                                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                .addComponent(cmbCedula, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                                .addGap(4, 4, 4)
                                                .addComponent(txtCedula, javax.swing.GroupLayout.PREFERRED_SIZE, 103, javax.swing.GroupLayout.PREFERRED_SIZE)))
                                        .addGap(0, 0, Short.MAX_VALUE))
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addGroup(jPanel1Layout.createSequentialGroup()
                                                .addGap(4, 4, 4)
                                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                                        .addGap(6, 6, 6)
                                                        .addComponent(jLabel26)
                                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                        .addComponent(cmbCedTut, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                                        .addGap(4, 4, 4)
                                                        .addComponent(txtCedTut, javax.swing.GroupLayout.PREFERRED_SIZE, 103, javax.swing.GroupLayout.PREFERRED_SIZE))
                                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                                            .addComponent(jLabel27)
                                                            .addComponent(jLabel28))
                                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                                            .addComponent(txtApeTut, javax.swing.GroupLayout.PREFERRED_SIZE, 134, javax.swing.GroupLayout.PREFERRED_SIZE)
                                                            .addComponent(txtNombrTut, javax.swing.GroupLayout.PREFERRED_SIZE, 103, javax.swing.GroupLayout.PREFERRED_SIZE)))))
                                            .addComponent(jLabel25))
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                        .addComponent(jLabel23)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(jScrollPane3, javax.swing.GroupLayout.PREFERRED_SIZE, 157, javax.swing.GroupLayout.PREFERRED_SIZE)))))
                        .addGap(34, 34, 34))))
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGap(193, 193, 193)
                        .addComponent(PanelEditar, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(jLabel9))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(jSeparator1, javax.swing.GroupLayout.PREFERRED_SIZE, 574, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGap(30, 30, 30)
                        .addComponent(jLabel19)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(txtApellido, javax.swing.GroupLayout.PREFERRED_SIZE, 134, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGap(75, 75, 75)
                        .addComponent(btnElegir))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGap(24, 24, 24)
                        .addComponent(jLabel20)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(txtSemestre, javax.swing.GroupLayout.PREFERRED_SIZE, 30, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap())
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanel1Layout.createSequentialGroup()
                .addGap(0, 0, Short.MAX_VALUE)
                .addComponent(btnGuardar, javax.swing.GroupLayout.PREFERRED_SIZE, 85, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addComponent(btnSalir, javax.swing.GroupLayout.PREFERRED_SIZE, 90, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(197, 197, 197))
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(PanelEditar, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel9))
                .addGap(29, 29, 29)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(cmbCuo, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel6)
                    .addComponent(jLabel10)
                    .addComponent(cmbCarrera, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(44, 44, 44)
                .addComponent(jLabel11)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(jLabel22)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(jLabel12)
                            .addComponent(cmbBuscar, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(4, 4, 4)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                        .addComponent(txtCedulaP, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addComponent(jLabel14))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(jLabel13)
                            .addComponent(txtValor, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(3, 3, 3)))
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGap(3, 3, 3)
                        .addComponent(txtNombreP, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addComponent(jLabel15)
                    .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 93, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(btnElegir, javax.swing.GroupLayout.PREFERRED_SIZE, 33, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(47, 47, 47)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addComponent(jLabel25)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(txtCedTut, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jLabel26)
                            .addComponent(cmbCedTut, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(txtNombrTut, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jLabel27))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(txtApeTut, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jLabel28)))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGap(1, 1, 1)
                                .addComponent(jLabel23))
                            .addComponent(jScrollPane3, javax.swing.GroupLayout.PREFERRED_SIZE, 105, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(0, 0, Short.MAX_VALUE)))
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel29)
                    .addComponent(txtTlfTut, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(33, 33, 33)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jLabel18)
                    .addComponent(dchFechaInicio, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(44, 44, 44)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel24)
                    .addComponent(cmbTipoProyecto, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(47, 47, 47)
                .addComponent(jLabel21)
                .addGap(18, 18, 18)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(txtCedula, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel16)
                    .addComponent(cmbCedula, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(txtNombr, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel17))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(txtApellido, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel19))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel20)
                    .addComponent(txtSemestre, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 110, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btnEliminar)
                    .addComponent(btnAgregar))
                .addGap(29, 29, 29)
                .addComponent(jSeparator1, javax.swing.GroupLayout.PREFERRED_SIZE, 12, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(btnGuardar, javax.swing.GroupLayout.PREFERRED_SIZE, 38, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(btnSalir, javax.swing.GroupLayout.PREFERRED_SIZE, 36, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(227, 227, 227))
        );

        jScrollPane5.setViewportView(jPanel1);

        javax.swing.GroupLayout PanelVentanaLayout = new javax.swing.GroupLayout(PanelVentana);
        PanelVentana.setLayout(PanelVentanaLayout);
        PanelVentanaLayout.setHorizontalGroup(
            PanelVentanaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, PanelVentanaLayout.createSequentialGroup()
                .addContainerGap()
                .addGroup(PanelVentanaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(jScrollPane5, javax.swing.GroupLayout.PREFERRED_SIZE, 0, Short.MAX_VALUE)
                    .addComponent(PanelBanner, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addContainerGap())
        );
        PanelVentanaLayout.setVerticalGroup(
            PanelVentanaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelVentanaLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(PanelBanner, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollPane5, javax.swing.GroupLayout.DEFAULT_SIZE, 489, Short.MAX_VALUE)
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
            .addComponent(PanelVentana, javax.swing.GroupLayout.DEFAULT_SIZE, 700, Short.MAX_VALUE)
        );

        PanelVentana.getAccessibleContext().setAccessibleName("");

        getAccessibleContext().setAccessibleParent(this);

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void formWindowOpened(java.awt.event.WindowEvent evt) {//GEN-FIRST:event_formWindowOpened
         FondoVentana p = new FondoVentana();
         PanelVentana.add(p);           
         PanelVentana.repaint();
         FondoBanner p2 = new FondoBanner();
         PanelBanner.add(p2);           
         PanelBanner.repaint();
         ImagenEditar p3 = new ImagenEditar();
         PanelEditar.add(p3);           
         PanelEditar.repaint();
         
    }//GEN-LAST:event_formWindowOpened

    private void txtValorKeyPressed(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtValorKeyPressed
        tblProfesor.removeAll();

        modelo = new DefaultTableModel();

        this.tblProfesor.setModel(modelo);

        modelo.addColumn("CEDULA");

        modelo.addColumn("NOMBRE");

        modelo.addColumn("APELLIDO");

        if (cmbBuscar.getSelectedItem().toString().equals("Cédula")){

            consulta="SELECT * FROM tutor WHERE tipo='ACADEMICO' AND ( cedula='"+txtValor.getText()+"' OR cedula LIKE '%"+txtValor.getText()+"%' OR cedula LIKE '"+txtValor.getText()+"%' OR cedula LIKE '%"+txtValor.getText()+"') ORDER BY cedula ASC";

        }
        else if (cmbBuscar.getSelectedItem().toString().equals("Nombre")){

            consulta="SELECT * FROM tutor WHERE tipo='ACADEMICO' AND ( nombre='"+txtValor.getText()+"' OR nombre LIKE '%"+txtValor.getText()+"%' OR nombre LIKE '"+txtValor.getText()+"%' OR nombre LIKE '%"+txtValor.getText()+"') ORDER BY nombre ASC";

        }
        else{

            consulta="SELECT * FROM tutor WHERE tipo='ACADEMICO' AND ( apellido='"+txtValor.getText()+"' OR apellido LIKE '%"+txtValor.getText()+"%' OR apellido LIKE '"+txtValor.getText()+"%' OR apellido LIKE '%"+txtValor.getText()+"') ORDER BY apellido ASC";

        }

        bd= new BaseDatos();

        if (bd.n_tuplas(consulta)>0){

            tuplas= new String [bd.n_tuplas(consulta)][5];
            bd.obtener_tuplas(consulta,tuplas,5);
            for (int i=0; i<bd.n_tuplas(consulta); i++){

                linea= new String [3];
                linea[0]= tuplas[i][1]+tuplas[i][2];
                linea[1]= tuplas[i][3];
                linea[2]= tuplas[i][4];
                modelo.addRow(linea);

            }
        }
    }//GEN-LAST:event_txtValorKeyPressed

    private void btnElegirActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnElegirActionPerformed
        int fila=tblProfesor.getSelectedRow();
        if (fila<0){

            Mensaje.showMessageDialog(this,"No se ha elegido ningún profesor.","Error",Mensaje.ERROR_MESSAGE);

        }
        else{

            txtCedulaP.setEnabled(true);
            txtNombreP.setEnabled(true);
            txtCedulaP.setText(modelo.getValueAt(fila, 0).toString());
            txtNombreP.setText(modelo.getValueAt(fila, 1).toString()+" "+modelo.getValueAt(fila, 2).toString());
            txtCedulaP.setEnabled(false);
            txtNombreP.setEnabled(false);
        }
    }//GEN-LAST:event_btnElegirActionPerformed

    private void txtCedulaFocusLost(java.awt.event.FocusEvent evt) {//GEN-FIRST:event_txtCedulaFocusLost
        consulta="SELECT * FROM alumno WHERE ve='"+cmbCedula.getSelectedItem().toString()+"' AND cedula='"+txtCedula.getText()+"'";
        bd= new BaseDatos();
        if (bd.n_tuplas(consulta)>0){

            tuplas= new String[bd.n_tuplas(consulta)][6];
            bd.obtener_tuplas(consulta, tuplas, 6);
            txtNombr.setText(tuplas[0][3]);
            txtApellido.setText(tuplas[0][4]);
            txtSemestre.setText(tuplas[0][5]);

        }
    }//GEN-LAST:event_txtCedulaFocusLost

    private void txtCedulaKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtCedulaKeyTyped
        char c= evt.getKeyChar();
        if ((c<'0') || (c>'9'))
        {evt.consume();}
    }//GEN-LAST:event_txtCedulaKeyTyped

    private void txtNombrKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtNombrKeyTyped
        char c= evt.getKeyChar();
        if (((c<'a') || (c>'z')) && ((c<'A') || (c>'Z')) && (c!=' ')) evt.consume();
    }//GEN-LAST:event_txtNombrKeyTyped

    private void txtApellidoKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtApellidoKeyTyped
        char c= evt.getKeyChar();
        if (((c<'a') || (c>'z')) && ((c<'A') || (c>'Z')) && (c!=' ')) evt.consume();
    }//GEN-LAST:event_txtApellidoKeyTyped

    private void txtSemestreKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtSemestreKeyTyped
        char c= evt.getKeyChar();
        if ((c<'0') || (c>'9'))
        {evt.consume();}
    }//GEN-LAST:event_txtSemestreKeyTyped

    public String obtenerfecha2(){
        String valor="";
        try{
            
            Date fecha = dchFechaInicio.getDate();
            SimpleDateFormat fch = new SimpleDateFormat(dchFechaInicio.getDateFormatString());
            valor=String.valueOf(fch.format(fecha));
        
        }
        catch (NullPointerException ex){
        valor="";
        return valor;
        }
        return valor;
    
    
    
    }
    
    
    private void btnAgregarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnAgregarActionPerformed
        consulta = "SELECT * FROM tutor WHERE tipo='ACADEMICO' AND ve='"+cmbCedula.getSelectedItem().toString()+"' AND cedula='"+txtCedula.getText().toString()+"'";

        bd= new BaseDatos();
        if (txtCedula.getText().equals("") || txtNombr.getText().equals("") || txtApellido.getText().equals("") || txtSemestre.getText().equals("")){

            Mensaje.showMessageDialog(this,"No puede dejar campos vacíos para el estudiante a agregar.","Error",Mensaje.ERROR_MESSAGE);

        }
        else if (bd.n_tuplas(consulta)>0){

            Mensaje.showMessageDialog(this,"La cédula corresponde con la de algún profesor registrado en la base de datos.","Error",Mensaje.ERROR_MESSAGE);
            txtCedula.setText("");
            txtNombr.setText("");
            txtApellido.setText("");
            txtSemestre.setText("");

        }
        else if(repetido()){

            Mensaje.showMessageDialog(this,"La cédula ingresada corresponde con la de un alumno ingresado en la tabla.","Error",Mensaje.ERROR_MESSAGE);
            txtCedula.setText("");
            txtNombr.setText("");
            txtApellido.setText("");
            txtSemestre.setText("");

        }
        else if(repetido2()){

            Mensaje.showMessageDialog(this,"La cédula ingresada corresponde con la de un alumno que está en espera o fue aprobado.","Error",Mensaje.ERROR_MESSAGE);
            txtCedula.setText("");
            txtNombr.setText("");
            txtApellido.setText("");
            txtSemestre.setText("");

        }
        else{

            linea= new String [4];
            linea[0]= cmbCedula.getSelectedItem().toString()+txtCedula.getText().toString();
            linea[1]= txtNombr.getText().toUpperCase();
            linea[2]= txtApellido.getText().toUpperCase();
            linea[3]= txtSemestre.getText();
            modelo2.addRow(linea);
            txtCedula.setText("");
            txtNombr.setText("");
            txtApellido.setText("");
            txtSemestre.setText("");
        }
    }//GEN-LAST:event_btnAgregarActionPerformed

    private void btnEliminarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnEliminarActionPerformed
        int fila=tblAlumno.getSelectedRow();
        if (fila<0){

            Mensaje.showMessageDialog(this,"No se ha elegido ningún alumno.","Error",Mensaje.ERROR_MESSAGE);

        }
        else{

            modelo2.removeRow(fila);

        }
    }//GEN-LAST:event_btnEliminarActionPerformed

    private void btnGuardarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnGuardarActionPerformed
        BaseDatos bd = new BaseDatos();
        txtCedulaP.setEnabled(true);
        String consulta="select * from proyecto where id<>'"+id+"' AND nombre='"+txtNombre.getText().toUpperCase()+"'";
        if ( (cmbCuo.getSelectedItem().toString().equals("Seleccione..."))  || (cmbCarrera.getSelectedItem().toString().equals("Seleccione..."))  || (cmbTipoProyecto.getSelectedItem().toString().equals("Seleccione..."))  ||     (txtCedulaP.getText().equals("")) || (txtNombre.getText().equals("")) || (txtNombrTut.getText().equals("")) || (txtApeTut.getText().equals("")) || (txtCedTut.getText().equals("")) || (txtTlfTut.getText().equals(""))     )  {

            Mensaje.showMessageDialog(this,"No puede dejar campos vacíos","Error",Mensaje.ERROR_MESSAGE);

        }
        else if (obtenerfecha2().equals("")){
        
            Mensaje.showMessageDialog(this,"Fecha de inicio inválida. Intente de nuevo","Error",Mensaje.ERROR_MESSAGE);
            
        }
        else if (txtCedulaP.getText().equals(cmbCedTut.getSelectedItem().toString()+txtCedTut.getText())){

            Mensaje.showMessageDialog(this,"La cédula de ambos tutores coinciden. Intente de nuevo","Error",Mensaje.ERROR_MESSAGE);

        }
        else if ((tblAlumno.getRowCount()<2) || (tblAlumno.getRowCount()>6)){

            Mensaje.showMessageDialog(this,"El rango de estudiantes inscritos, debe oscilar entre 2 y 6","Error",Mensaje.ERROR_MESSAGE);

        }
        else if (bd.n_tuplas(consulta)>0){

            Mensaje.showMessageDialog(this,"Proyecto repetido. Intente de nuevo.","Error",Mensaje.ERROR_MESSAGE);
        }
        else{
            consulta="DELETE FROM realiza WHERE nombreproyecto='"+nm+"'";
            bd.consulta(consulta);
            consulta="UPDATE proyecto SET fechainicio='"+obtenerfecha2()+"', ncuo='"+cmbCuo.getSelectedItem().toString()+"', nombre='"+txtNombre.getText().toUpperCase()+"', cedtutoracademico='"+txtCedulaP.getText()+"', cedtutorcomunitario='"+cmbCedTut.getSelectedItem().toString()+txtCedTut.getText()+"',carrera='"+cmbCarrera.getSelectedItem().toString()+"', tipo='"+cmbTipoProyecto.getSelectedItem().toString().toUpperCase()+"' WHERE id='"+id+"'";
            bd.consulta(consulta);
            consulta="SELECT * FROM tutor WHERE ve='"+cmbCedTut.getSelectedItem().toString()+"' AND cedula='"+txtCedTut.getText()+"' AND tipo='COMUNITARIO'";
            if (bd.n_tuplas(consulta)==0){
                consulta="INSERT into tutor (ve,cedula,nombre,apellido,telefono,tipo)  values('"+cmbCedTut.getSelectedItem().toString()+"','"+txtCedTut.getText()+"','"+txtNombrTut.getText().toUpperCase()+"','"+txtApeTut.getText().toUpperCase()+"','"+txtTlfTut.getText()+"','COMUNITARIO')";
            }
            else{

                consulta="UPDATE tutor SET nombre='"+txtNombrTut.getText().toUpperCase()+"', apellido='"+txtApeTut.getText().toUpperCase()+"', telefono='"+txtTlfTut.getText()+"' WHERE ve='"+cmbCedTut.getSelectedItem().toString()+"' AND cedula='"+txtCedTut.getText()+"'";
            }
            bd.consulta(consulta);
            for (i=0; i<tblAlumno.getRowCount(); i++){

                consulta="INSERT into realiza (nombreproyecto,cedalumno)  values('"+txtNombre.getText().toUpperCase()+"','"+modelo2.getValueAt(i,0).toString()+"')";
                bd.consulta(consulta);
                consulta="SELECT * FROM alumno WHERE ve='"+modelo2.getValueAt(i,0).toString().substring(0, 2)+"' AND cedula='"+modelo2.getValueAt(i,0).toString().substring(2,modelo2.getValueAt(i,0).toString().length())+"'";
                if (bd.n_tuplas(consulta)==0){
                    consulta="INSERT into alumno (ve,cedula,nombre,apellido,semestre)  values('"+modelo2.getValueAt(i,0).toString().substring(0, 2)+"','"+modelo2.getValueAt(i,0).toString().substring(2,modelo2.getValueAt(i,0).toString().length())+"','"+modelo2.getValueAt(i,1).toString().toUpperCase()+"','"+modelo2.getValueAt(i,2).toString().toUpperCase()+"','"+modelo2.getValueAt(i,3).toString()+"')";
                }
                else{

                    consulta="UPDATE alumno SET nombre='"+modelo2.getValueAt(i,1).toString().toUpperCase()+"', apellido='"+modelo2.getValueAt(i,2).toString().toUpperCase()+"', semestre='"+modelo2.getValueAt(i,3).toString().toUpperCase()+"' WHERE ve='"+modelo2.getValueAt(i,0).toString().substring(0, 2)+"' AND cedula='"+modelo2.getValueAt(i,0).toString().substring(2,modelo2.getValueAt(i,0).toString().length())+"'";
                }
                bd.consulta(consulta);

            }

            Mensaje.showMessageDialog(this,"Datos guardados satisfactoriamente.","Info",Mensaje.INFORMATION_MESSAGE);
            ListadoProyecto lp=new ListadoProyecto();
            lp.setVisible(true);
            dispose();
        }
        txtCedulaP.setEnabled(false);
    }//GEN-LAST:event_btnGuardarActionPerformed

    private void btnSalirActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnSalirActionPerformed
        ListadoProyecto lp=new ListadoProyecto();
        lp.setVisible(true);
        dispose();
    }//GEN-LAST:event_btnSalirActionPerformed

    private void cmbCedulaFocusLost(java.awt.event.FocusEvent evt) {//GEN-FIRST:event_cmbCedulaFocusLost
        consulta="SELECT * FROM alumno WHERE ve='"+cmbCedula.getSelectedItem().toString()+"' AND cedula='"+txtCedula.getText()+"'";
        bd= new BaseDatos();
        if (bd.n_tuplas(consulta)>0){

            tuplas= new String[bd.n_tuplas(consulta)][7];
            bd.obtener_tuplas(consulta, tuplas, 7);
            txtNombr.setText(tuplas[0][3]);
            txtApellido.setText(tuplas[0][4]);
            txtSemestre.setText(tuplas[0][5]);

        }
    }//GEN-LAST:event_cmbCedulaFocusLost

    private void cmbCedTutFocusLost(java.awt.event.FocusEvent evt) {//GEN-FIRST:event_cmbCedTutFocusLost
        consulta="SELECT * FROM tutor WHERE ve='"+cmbCedTut.getSelectedItem().toString()+"' AND cedula='"+txtCedTut.getText()+"' AND tipo='COMUNITARIO'";
        bd= new BaseDatos();
        if (bd.n_tuplas(consulta)>0){

            tuplas= new String[bd.n_tuplas(consulta)][6];
            bd.obtener_tuplas(consulta, tuplas, 6);
            txtNombrTut.setText(tuplas[0][3]);
            txtApeTut.setText(tuplas[0][4]);
            txtTlfTut.setText(tuplas[0][5]);

        }
    }//GEN-LAST:event_cmbCedTutFocusLost

    private void txtCedTutFocusLost(java.awt.event.FocusEvent evt) {//GEN-FIRST:event_txtCedTutFocusLost
        consulta="SELECT * FROM tutor WHERE ve='"+cmbCedTut.getSelectedItem().toString()+"' AND cedula='"+txtCedTut.getText()+"' AND tipo='COMUNITARIO'";
        bd= new BaseDatos();
        if (bd.n_tuplas(consulta)>0){

            tuplas= new String[bd.n_tuplas(consulta)][6];
            bd.obtener_tuplas(consulta, tuplas, 6);
            txtNombrTut.setText(tuplas[0][3]);
            txtApeTut.setText(tuplas[0][4]);
            txtTlfTut.setText(tuplas[0][5]);

        }
    }//GEN-LAST:event_txtCedTutFocusLost

    private void txtCedTutKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtCedTutKeyTyped
        char c= evt.getKeyChar();
        if ((c<'0') || (c>'9'))
        {evt.consume();}
    }//GEN-LAST:event_txtCedTutKeyTyped

    private void txtNombrTutKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtNombrTutKeyTyped
        char c= evt.getKeyChar();
        if (((c<'a') || (c>'z')) && ((c<'A') || (c>'Z')) && (c!=' ')) evt.consume();
    }//GEN-LAST:event_txtNombrTutKeyTyped

    private void txtApeTutKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtApeTutKeyTyped
        char c= evt.getKeyChar();
        if (((c<'a') || (c>'z')) && ((c<'A') || (c>'Z')) && (c!=' ')) evt.consume();
    }//GEN-LAST:event_txtApeTutKeyTyped

    private void txtTlfTutKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtTlfTutKeyTyped
        char c= evt.getKeyChar();
        if ((c<'0') || (c>'9'))
        {evt.consume();}
    }//GEN-LAST:event_txtTlfTutKeyTyped

    public boolean repetido(){
    
        boolean aux=false;
        
        if (tblAlumno.getRowCount()>0){
        
            for (i=0; i<tblAlumno.getRowCount(); i++){
            
                if (modelo2.getValueAt(i,0).toString().equals(cmbCedula.getSelectedItem().toString()+txtCedula.getText().toString())){
                
                    aux=true;
                
                }
            
            
            }
        }
        return aux;
    }
    
    public boolean repetido2(){
        boolean aux=false;
        consulta="SELECT nombre,nombreproyecto,estado FROM proyecto,realiza WHERE nombre=nombreproyecto AND cedalumno='"+cmbCedula.getSelectedItem().toString()+txtCedula.getText().toString()+"'";
        bd= new BaseDatos();
        if (bd.n_tuplas(consulta)>0){
            tuplas= new String[bd.n_tuplas(consulta)][3];
            bd.obtener_tuplas(consulta, tuplas, 3);
        
            for (i=0; i<bd.n_tuplas(consulta); i++){
            
                if ((tuplas[i][2].equals("ESPERA")) || (tuplas[i][2].equals("APROBADO"))){
            
            
                       aux=true;
            
                }
            
            }
        
        }
           
        return aux;
    
    
    }
    
    
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
            java.util.logging.Logger.getLogger(IniciarSesion.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(IniciarSesion.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(IniciarSesion.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(IniciarSesion.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
            }
        });
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JOptionPane Mensaje;
    private javax.swing.JPanel PanelBanner;
    private javax.swing.JPanel PanelEditar;
    private javax.swing.JPanel PanelVentana;
    private javax.swing.JButton btnAgregar;
    private javax.swing.JButton btnElegir;
    private javax.swing.JButton btnEliminar;
    private javax.swing.JButton btnGuardar;
    private javax.swing.JButton btnSalir;
    private javax.swing.JComboBox cmbBuscar;
    private javax.swing.JComboBox cmbCarrera;
    private javax.swing.JComboBox cmbCedTut;
    private javax.swing.JComboBox cmbCedula;
    private javax.swing.JComboBox cmbCuo;
    private javax.swing.JComboBox cmbTipoProyecto;
    private com.toedter.calendar.JDateChooser dchFechaInicio;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel10;
    private javax.swing.JLabel jLabel11;
    private javax.swing.JLabel jLabel12;
    private javax.swing.JLabel jLabel13;
    private javax.swing.JLabel jLabel14;
    private javax.swing.JLabel jLabel15;
    private javax.swing.JLabel jLabel16;
    private javax.swing.JLabel jLabel17;
    private javax.swing.JLabel jLabel18;
    private javax.swing.JLabel jLabel19;
    private javax.swing.JLabel jLabel20;
    private javax.swing.JLabel jLabel21;
    private javax.swing.JLabel jLabel22;
    private javax.swing.JLabel jLabel23;
    private javax.swing.JLabel jLabel24;
    private javax.swing.JLabel jLabel25;
    private javax.swing.JLabel jLabel26;
    private javax.swing.JLabel jLabel27;
    private javax.swing.JLabel jLabel28;
    private javax.swing.JLabel jLabel29;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JLabel jLabel7;
    private javax.swing.JLabel jLabel8;
    private javax.swing.JLabel jLabel9;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private javax.swing.JScrollPane jScrollPane5;
    private javax.swing.JSeparator jSeparator1;
    private javax.swing.JTable tblAlumno;
    private javax.swing.JTable tblProfesor;
    private javax.swing.JTextField txtApeTut;
    private javax.swing.JTextField txtApellido;
    private javax.swing.JTextField txtCedTut;
    private javax.swing.JTextField txtCedula;
    private javax.swing.JTextField txtCedulaP;
    private javax.swing.JTextField txtNombr;
    private javax.swing.JTextField txtNombrTut;
    private javax.swing.JTextArea txtNombre;
    private javax.swing.JTextField txtNombreP;
    private javax.swing.JTextField txtSemestre;
    private javax.swing.JTextField txtTlfTut;
    private javax.swing.JTextField txtValor;
    // End of variables declaration//GEN-END:variables
}
