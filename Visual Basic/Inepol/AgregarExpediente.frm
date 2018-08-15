VERSION 5.00
Begin VB.Form AgregarExpediente 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Agregar Expediente "
   ClientHeight    =   8880
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   9975
   Icon            =   "AgregarExpediente.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   Picture         =   "AgregarExpediente.frx":08CA
   ScaleHeight     =   8880
   ScaleWidth      =   9975
   StartUpPosition =   3  'Windows Default
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
      Picture         =   "AgregarExpediente.frx":B830
      Style           =   1  'Graphical
      TabIndex        =   22
      Top             =   7800
      Width           =   1215
   End
   Begin VB.TextBox txtDecision 
      Height          =   285
      Left            =   6600
      TabIndex        =   19
      Top             =   7080
      Width           =   1575
   End
   Begin VB.TextBox txtOCAP 
      Height          =   285
      Left            =   2880
      TabIndex        =   18
      Top             =   7080
      Width           =   1215
   End
   Begin VB.ComboBox cmbStatus 
      Height          =   315
      ItemData        =   "AgregarExpediente.frx":C0FA
      Left            =   2880
      List            =   "AgregarExpediente.frx":C104
      Style           =   2  'Dropdown List
      TabIndex        =   17
      Top             =   6480
      Width           =   1335
   End
   Begin VB.TextBox txtCausa 
      Height          =   285
      Left            =   2880
      TabIndex        =   14
      Top             =   5880
      Width           =   1575
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
      Picture         =   "AgregarExpediente.frx":C11A
      Style           =   1  'Graphical
      TabIndex        =   13
      Top             =   7800
      Width           =   1335
   End
   Begin VB.TextBox txtDescripcion 
      Height          =   1125
      Left            =   6600
      MaxLength       =   255
      MultiLine       =   -1  'True
      TabIndex        =   12
      Top             =   5040
      Width           =   3135
   End
   Begin VB.TextBox txtFecha 
      Height          =   285
      Left            =   2880
      TabIndex        =   10
      Top             =   5040
      Width           =   1575
   End
   Begin VB.Label Label9 
      BackStyle       =   0  'Transparent
      Caption         =   "*Decisi�n: "
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
      Left            =   5280
      TabIndex        =   21
      Top             =   7080
      Width           =   1335
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
      TabIndex        =   20
      Top             =   7080
      Width           =   1455
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
      TabIndex        =   16
      Top             =   6480
      Width           =   1095
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
      TabIndex        =   15
      Top             =   5880
      Width           =   975
   End
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "*Descripci�n: "
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
      Left            =   4800
      TabIndex        =   11
      Top             =   5040
      Width           =   1815
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
      TabIndex        =   9
      Top             =   5040
      Width           =   2775
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
      TabIndex        =   8
      Top             =   4560
      Width           =   4215
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   9840
      Y1              =   4440
      Y2              =   4440
   End
   Begin VB.Label etqEstacionPolicial 
      BackStyle       =   0  'Transparent
      Caption         =   "*Estaci�n Policial: "
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
      Left            =   6120
      TabIndex        =   7
      Top             =   2760
      Width           =   3015
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
      Left            =   3120
      TabIndex        =   6
      Top             =   2760
      Width           =   2775
   End
   Begin VB.Label etqGradoInstruccion 
      BackStyle       =   0  'Transparent
      Caption         =   "*Grado de Instrucci�n: "
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
      Left            =   240
      TabIndex        =   5
      Top             =   2760
      Width           =   2655
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
      Left            =   6120
      TabIndex        =   4
      Top             =   1440
      Width           =   3015
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
      Left            =   3120
      TabIndex        =   3
      Top             =   1440
      Width           =   2775
   End
   Begin VB.Label etqCedula 
      BackStyle       =   0  'Transparent
      Caption         =   "*C�dula: "
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
      Left            =   240
      TabIndex        =   2
      Top             =   1440
      Width           =   2655
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
      Left            =   240
      TabIndex        =   1
      Top             =   960
      Width           =   4215
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   9840
      Y1              =   840
      Y2              =   840
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "AGREGAR EXPEDIENTE"
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
      TabIndex        =   0
      Top             =   240
      Width           =   4095
   End
End
Attribute VB_Name = "AgregarExpediente"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public cedula, nombre, apellido, gradoi, rango, estacionp As String
Dim Conexion As ADODB.Connection
Dim Registros, Registros2 As ADODB.Recordset
Dim consulta As String
Dim strcon As String
Dim subc, codig As String
Dim contador As Integer


Private Sub btnGuardar_Click()

    strcon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb);"
    
    Set Conexion = New ADODB.Connection
    Conexion.Open strcon
    If txtCausa.Text = "" Or txtDescripcion = "" Or txtOCAP.Text = "" Or Not IsDate(txtFecha.Text) Or txtDecision.Text = "" Or cmbStatus.Text = "" Then
        MsgBox ("Error en campos de texto. Intente nuevamente")
    
    Else
        consulta = "SELECT * FROM Expediente WHERE OCAP=" & txtOCAP.Text
        Set Registros = New ADODB.Recordset
        Registros.Open consulta, Conexion
        If Not Registros.EOF And Not Registros.BOF Then
            MsgBox ("El n�mero OCAP ingresado coincide con el de un expediente registrado en la base de datos.")
            Set Registros = Nothing
            
        Else
            Set Registros = New ADODB.Recordset
            Set Registros2 = New ADODB.Recordset
            subc = Mid(txtFecha.Text, 7, 11)
            consulta = "SELECT * FROM Expediente WHERE Codigo LIKE '%" & subc & "'"
            Registros.Open consulta, Conexion
            contador = 0
            While Not Registros.EOF
                contador = contador + 1
                Registros.MoveNext
            Wend
            Set Registros = New ADODB.Recordset
            contador = contador + 1
            codig = "ORDP-" & contador & "-" & subc
            consulta = "SELECT * FROM Expediente WHERE Codigo ='" & codig & "'"
            Registros.Open consulta, Conexion
            While Not Registros.EOF
                Set Registros = New ADODB.Recordset
                contador = contador + 1
                codig = "ORDP-" & contador & "-" & subc
                consulta = "SELECT * FROM Expediente WHERE Codigo ='" & codig & "'"
                Registros.Open consulta, Conexion
            Wend
            Set Registros = New ADODB.Recordset
            consulta = "INSERT INTO Expediente (Codigo,Fecha,Descripcion,CedulaFuncionario,Causa,Status,Ocap,Decision) VALUES ('" & codig & "','" & txtFecha & "','" & txtDescripcion.Text & "','" & cedula & "','" & txtCausa.Text & "','" & cmbStatus.Text & "','" & txtOCAP.Text & "','" & txtDecision.Text & "')"
            Registros2.Open consulta, Conexion
            MsgBox ("Datos almacenados exitosamente. C�digo del nuevo expediente: " & codig)
            
            
            
            consulta = "SELECT * FROM Expediente WHERE CedulaFuncionario=" & cedula
    
            Set Registros2 = New ADODB.Recordset
            Registros2.Open consulta, Conexion
            If Not Registros2.EOF Then
            
                ListadoExpedientesF.ControlLista.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;data source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb"
        
                ListadoExpedientesF.ControlLista.RecordSource = "SELECT * FROM Expediente WHERE CedulaFuncionario=" & cedula
                
                ListadoExpedientesF.ControlLista.Refresh
                
                ListadoExpedientesF.Tabla.Col = 0
                
                ListadoExpedientesF.Tabla.Row = 0
                
                'ListadoExpedientesF.Tabla.Text = ListadoExpedientesF.ControlLista.Recordset.Fields("Codigo")
                
                
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
    ListadoExpedientesF.Show
    Unload Me
End Sub



Private Sub txtOCAP_KeyPress(KeyAscii As Integer)
    Select Case KeyAscii
        Case 48 To 57   ' Permite los d�gitos
        Case 8      ' Permite el car�cter de retroceso
        Case Else
            KeyAscii = 0
            Beep
    End Select
End Sub
