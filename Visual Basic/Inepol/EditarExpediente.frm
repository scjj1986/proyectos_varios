VERSION 5.00
Begin VB.Form EditarExpediente 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Editar Expediente"
   ClientHeight    =   8760
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   10005
   Icon            =   "EditarExpediente.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   Picture         =   "EditarExpediente.frx":08CA
   ScaleHeight     =   8760
   ScaleWidth      =   10005
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox txtFecha 
      Height          =   285
      Left            =   2880
      TabIndex        =   15
      Top             =   4920
      Width           =   1575
   End
   Begin VB.TextBox txtDescripcion 
      Height          =   1125
      Left            =   6720
      MaxLength       =   255
      MultiLine       =   -1  'True
      TabIndex        =   14
      Top             =   4920
      Width           =   3135
   End
   Begin VB.CommandButton btnGuardar 
      Caption         =   "Guardar"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   -1  'True
         Strikethrough   =   0   'False
      EndProperty
      Height          =   855
      Left            =   3360
      Picture         =   "EditarExpediente.frx":B830
      Style           =   1  'Graphical
      TabIndex        =   13
      Top             =   7680
      Width           =   1335
   End
   Begin VB.TextBox txtCausa 
      Height          =   285
      Left            =   2880
      TabIndex        =   12
      Top             =   5760
      Width           =   1575
   End
   Begin VB.ComboBox cmbStatus 
      Height          =   315
      ItemData        =   "EditarExpediente.frx":C0FA
      Left            =   2880
      List            =   "EditarExpediente.frx":C104
      TabIndex        =   11
      Text            =   "cmbStatus"
      Top             =   6360
      Width           =   1335
   End
   Begin VB.TextBox txtOCAP 
      Height          =   285
      Left            =   2880
      TabIndex        =   10
      Top             =   6960
      Width           =   1215
   End
   Begin VB.TextBox txtDecision 
      Height          =   285
      Left            =   6720
      TabIndex        =   9
      Top             =   6960
      Width           =   1575
   End
   Begin VB.CommandButton btnRegresar 
      Caption         =   "Regresar"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   -1  'True
         Strikethrough   =   0   'False
      EndProperty
      Height          =   855
      Left            =   5160
      Picture         =   "EditarExpediente.frx":C11A
      Style           =   1  'Graphical
      TabIndex        =   8
      Top             =   7680
      Width           =   1215
   End
   Begin VB.Line Line3 
      X1              =   120
      X2              =   9840
      Y1              =   4320
      Y2              =   4320
   End
   Begin VB.Line Line2 
      X1              =   0
      X2              =   9720
      Y1              =   0
      Y2              =   0
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "Datos del Expediente:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   120
      TabIndex        =   22
      Top             =   4440
      Width           =   4215
   End
   Begin VB.Label Label4 
      BackStyle       =   0  'Transparent
      Caption         =   "*Fecha (dd/mm/yyyy): "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   120
      TabIndex        =   21
      Top             =   4920
      Width           =   2775
   End
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "*Descripción: "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   4920
      TabIndex        =   20
      Top             =   4920
      Width           =   1815
   End
   Begin VB.Label Label6 
      BackStyle       =   0  'Transparent
      Caption         =   "*Causa: "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1920
      TabIndex        =   19
      Top             =   5760
      Width           =   975
   End
   Begin VB.Label Label7 
      BackStyle       =   0  'Transparent
      Caption         =   "*Status: "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1800
      TabIndex        =   18
      Top             =   6360
      Width           =   1095
   End
   Begin VB.Label Label8 
      BackStyle       =   0  'Transparent
      Caption         =   "*Nr. OCAP: "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1560
      TabIndex        =   17
      Top             =   6960
      Width           =   1455
   End
   Begin VB.Label Label9 
      BackStyle       =   0  'Transparent
      Caption         =   "*Decisión: "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   5400
      TabIndex        =   16
      Top             =   6960
      Width           =   1335
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "EDITAR EXPEDIENTE"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   20.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   2760
      TabIndex        =   7
      Top             =   120
      Width           =   4095
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   9840
      Y1              =   720
      Y2              =   720
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "Datos del Funcionario:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   120
      TabIndex        =   6
      Top             =   840
      Width           =   4215
   End
   Begin VB.Label etqCedula 
      BackStyle       =   0  'Transparent
      Caption         =   "*Cédula: "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Left            =   120
      TabIndex        =   5
      Top             =   1320
      Width           =   2655
   End
   Begin VB.Label etqNombre 
      BackStyle       =   0  'Transparent
      Caption         =   "*Nombre: "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1095
      Left            =   3000
      TabIndex        =   4
      Top             =   1320
      Width           =   2775
   End
   Begin VB.Label etqApellido 
      BackStyle       =   0  'Transparent
      Caption         =   "*Apellido: "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1095
      Left            =   6000
      TabIndex        =   3
      Top             =   1320
      Width           =   3015
   End
   Begin VB.Label etqGradoInstruccion 
      BackStyle       =   0  'Transparent
      Caption         =   "*Grado de Instrucción: "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1335
      Left            =   120
      TabIndex        =   2
      Top             =   2640
      Width           =   2655
   End
   Begin VB.Label etqRango 
      BackStyle       =   0  'Transparent
      Caption         =   "*Rango: "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1335
      Left            =   3000
      TabIndex        =   1
      Top             =   2640
      Width           =   2775
   End
   Begin VB.Label etqEstacionPolicial 
      BackStyle       =   0  'Transparent
      Caption         =   "*Estación Policial: "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1335
      Left            =   6000
      TabIndex        =   0
      Top             =   2640
      Width           =   3015
   End
End
Attribute VB_Name = "EditarExpediente"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public cedula, nombre, apellido, gradoi, rango, estacionp As String
Public codigo As String
Dim Conexion As ADODB.Connection
Dim Registros As ADODB.Recordset
Dim consulta As String
Dim strcon As String

Private Sub btnGuardar_Click()
    strcon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb);"
    
    Set Conexion = New ADODB.Connection
    Conexion.Open strcon
    If txtCausa.Text = "" Or txtDescripcion = "" Or txtOCAP.Text = "" Or Not IsDate(txtFecha.Text) Or txtDecision.Text = "" Or cmbStatus.Text = "" Then
        MsgBox ("Error en campos de texto. Intente nuevamente")
    
    Else
        consulta = "SELECT * FROM Expediente WHERE Ocap=" & txtOCAP.Text & "AND Codigo<>'" & codigo & "'"
        Set Registros = New ADODB.Recordset
        Registros.Open consulta, Conexion
        If Not Registros.EOF And Not Registros.BOF Then
            MsgBox ("El número OCAP ingresado coincide con otro expediente registrado en la base de datos.")
            Set Registros = Nothing
            
        Else
            Set Registros2 = New ADODB.Recordset
            consulta = "UPDATE Expediente SET Fecha='" & txtFecha.Text & "',Descripcion='" & txtDescripcion.Text & "',Status='" & cmbStatus.Text & "',Ocap='" & txtOCAP.Text & "',Causa='" & txtCausa.Text & "',Decision='" & txtDecision.Text & "' WHERE Codigo='" & codigo & "'"
            Registros2.Open consulta, Conexion
            
            MsgBox ("Datos almacenados exitosamente.")
            Set Registros2 = Nothing
            
            consulta = "SELECT * FROM Expediente WHERE CedulaFuncionario=" & cedula
    
            Set Registros2 = New ADODB.Recordset
            Registros2.Open consulta, Conexion
            If Not Registros2.EOF Then
            
                ListadoExpedientesF.ControlLista.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;data source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb"
        
                ListadoExpedientesF.ControlLista.RecordSource = "SELECT * FROM Expediente WHERE CedulaFuncionario=" & cedula
                
                ListadoExpedientesF.ControlLista.Refresh
                
                ListadoExpedientesF.Tabla.Col = 0
                
                ListadoExpedientesF.Tabla.Row = 0
                
                
            End If
            ListadoExpedientesF.cedula = cedula
            ListadoExpedientesF.etqCedula.Caption = ListadoExpedientesF.etqCedula.Caption & cedula
            ListadoExpedientesF.nombre = nombre
            ListadoExpedientesF.etqNombre.Caption = ListadoExpedientesF.etqNombre.Caption & nombre
            ListadoExpedientesF.apellido = apellido
            ListadoExpedientesF.etqApellido.Caption = ListadoExpedientesF.etqApellido.Caption & apellido
            ListadoExpedientesF.gradoi = gradoi
            ListadoExpedientesF.etqGradoInstruccion.Caption = ListadoExpedientesF.etqGradoInstruccion.Caption & gradoi
            ListadoExpedientesF.rango = rango
            ListadoExpedientesF.etqRango.Caption = ListadoExpedientesF.etqRango.Caption & rango
            ListadoExpedientesF.estacionp = estacionp
            ListadoExpedientesF.etqEstacionPolicial.Caption = ListadoExpedientesF.etqEstacionPolicial.Caption & estacionp
            ListadoExpedientesF.Show
            Unload Me
        End If
    End If
    Conexion.Close
End Sub

Private Sub btnRegresar_Click()
    strcon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb);"
    Set Conexion = New ADODB.Connection
    Conexion.Open strcon
    consulta = "SELECT * FROM Expediente WHERE CedulaFuncionario=" & cedula
    
    Set Registros = New ADODB.Recordset
    Registros.Open consulta, Conexion
    If Not Registros.EOF Then
    
        ListadoExpedientesF.ControlLista.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;data source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb"

        ListadoExpedientesF.ControlLista.RecordSource = "SELECT * FROM Expediente WHERE CedulaFuncionario=" & cedula
        
        ListadoExpedientesF.ControlLista.Refresh
        
        ListadoExpedientesF.Tabla.Col = 0
        
        ListadoExpedientesF.Tabla.Row = 0
        
        'ListadoExpedientesF.Tabla.Text = ListadoExpedientesF.ControlLista.Recordset.Fields("Codigo")
        
        
    End If
    Conexion.Close
    ListadoExpedientesF.cedula = cedula
    ListadoExpedientesF.etqCedula.Caption = ListadoExpedientesF.etqCedula.Caption & cedula
    ListadoExpedientesF.nombre = nombre
    ListadoExpedientesF.etqNombre.Caption = ListadoExpedientesF.etqNombre.Caption & nombre
    ListadoExpedientesF.apellido = apellido
    ListadoExpedientesF.etqApellido.Caption = ListadoExpedientesF.etqApellido.Caption & apellido
    ListadoExpedientesF.gradoi = gradoi
    ListadoExpedientesF.etqGradoInstruccion.Caption = ListadoExpedientesF.etqGradoInstruccion.Caption & gradoi
    ListadoExpedientesF.rango = rango
    ListadoExpedientesF.etqRango.Caption = ListadoExpedientesF.etqRango.Caption & rango
    ListadoExpedientesF.estacionp = estacionp
    ListadoExpedientesF.etqEstacionPolicial.Caption = ListadoExpedientesF.etqEstacionPolicial.Caption & estacionp
    ListadoExpedientesF.Show
    Unload Me
End Sub

Private Sub txtOCAP_KeyPress(KeyAscii As Integer)
    Select Case KeyAscii
        Case 48 To 57   ' Permite los dígitos
        Case 8      ' Permite el carácter de retroceso
        Case Else
            KeyAscii = 0
            Beep
    End Select
End Sub
