VERSION 5.00
Object = "{67397AA1-7FB1-11D0-B148-00A0C922E820}#6.0#0"; "MSADODC.OCX"
Object = "{CDE57A40-8B86-11D0-B3C6-00A0C90AEA82}#1.0#0"; "MSDATGRD.OCX"
Begin VB.Form ListadoExpedientesF 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Listado de Expedientes por Funcionario"
   ClientHeight    =   8895
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   9495
   Icon            =   "ListadoExpedientesF.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   Picture         =   "ListadoExpedientesF.frx":08CA
   ScaleHeight     =   8895
   ScaleWidth      =   9495
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
      Height          =   975
      Left            =   6480
      Picture         =   "ListadoExpedientesF.frx":B830
      Style           =   1  'Graphical
      TabIndex        =   13
      Top             =   7800
      Width           =   1455
   End
   Begin VB.CommandButton btnEliminarExpediente 
      Caption         =   "Eliminar Expediente"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   -1  'True
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Left            =   4800
      Picture         =   "ListadoExpedientesF.frx":C0FA
      Style           =   1  'Graphical
      TabIndex        =   12
      Top             =   7800
      Width           =   1455
   End
   Begin VB.CommandButton btnEditarexpediente 
      Caption         =   "Editar Expediente"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   -1  'True
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Left            =   3120
      Picture         =   "ListadoExpedientesF.frx":C9C4
      Style           =   1  'Graphical
      TabIndex        =   11
      Top             =   7800
      Width           =   1455
   End
   Begin MSAdodcLib.Adodc ControlLista 
      Height          =   375
      Left            =   3480
      Top             =   7200
      Width           =   2415
      _ExtentX        =   4260
      _ExtentY        =   661
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   8
      CursorOptions   =   0
      CacheSize       =   50
      MaxRecords      =   0
      BOFAction       =   0
      EOFAction       =   0
      ConnectStringType=   1
      Appearance      =   1
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      Orientation     =   0
      Enabled         =   -1
      Connect         =   ""
      OLEDBString     =   ""
      OLEDBFile       =   ""
      DataSourceName  =   ""
      OtherAttributes =   ""
      UserName        =   ""
      Password        =   ""
      RecordSource    =   ""
      Caption         =   ""
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _Version        =   393216
   End
   Begin VB.CommandButton btnAgregarExpediente 
      Caption         =   "Agregar Expediente"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   -1  'True
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Left            =   1440
      Picture         =   "ListadoExpedientesF.frx":D28E
      Style           =   1  'Graphical
      TabIndex        =   10
      Top             =   7800
      Width           =   1455
   End
   Begin MSDataGridLib.DataGrid Tabla 
      Bindings        =   "ListadoExpedientesF.frx":DB58
      Height          =   1575
      Left            =   120
      TabIndex        =   8
      Top             =   5400
      Width           =   9255
      _ExtentX        =   16325
      _ExtentY        =   2778
      _Version        =   393216
      AllowUpdate     =   0   'False
      HeadLines       =   1
      RowHeight       =   15
      BeginProperty HeadFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ColumnCount     =   2
      BeginProperty Column00 
         DataField       =   ""
         Caption         =   ""
         BeginProperty DataFormat {6D835690-900B-11D0-9484-00A0C91110ED} 
            Type            =   0
            Format          =   ""
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   8202
            SubFormatType   =   0
         EndProperty
      EndProperty
      BeginProperty Column01 
         DataField       =   ""
         Caption         =   ""
         BeginProperty DataFormat {6D835690-900B-11D0-9484-00A0C91110ED} 
            Type            =   0
            Format          =   ""
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   8202
            SubFormatType   =   0
         EndProperty
      EndProperty
      SplitCount      =   1
      BeginProperty Split0 
         BeginProperty Column00 
         EndProperty
         BeginProperty Column01 
         EndProperty
      EndProperty
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "Listado de Expedientes"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   120
      TabIndex        =   9
      Top             =   4920
      Width           =   4095
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   9360
      Y1              =   4680
      Y2              =   4680
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
      Left            =   240
      TabIndex        =   7
      Top             =   1680
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
      Left            =   3120
      TabIndex        =   6
      Top             =   1680
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
      Left            =   6120
      TabIndex        =   5
      Top             =   1680
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
      Left            =   240
      TabIndex        =   4
      Top             =   3000
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
      Left            =   3120
      TabIndex        =   3
      Top             =   3000
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
      Left            =   6120
      TabIndex        =   2
      Top             =   3000
      Width           =   3015
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "Datos del Funcionario"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   120
      TabIndex        =   1
      Top             =   1080
      Width           =   4095
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   9360
      Y1              =   840
      Y2              =   840
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "LISTADO DE EXPEDIENTES POR FUNCIONARIO"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   20.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   480
      TabIndex        =   0
      Top             =   240
      Width           =   8895
   End
End
Attribute VB_Name = "ListadoExpedientesF"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public cedula, nombre, apellido, gradoi, rango, estacionp As String
Dim resultado As Integer
Dim Conexion As ADODB.Connection
Dim Registros As ADODB.Recordset
Dim consulta As String
Dim strcon As String






Private Sub btnAgregarExpediente_Click()
    AgregarExpediente.cedula = cedula
    AgregarExpediente.etqCedula.Caption = AgregarExpediente.etqCedula.Caption & cedula
    AgregarExpediente.nombre = nombre
    AgregarExpediente.etqNombre.Caption = AgregarExpediente.etqNombre.Caption & nombre
    AgregarExpediente.apellido = apellido
    AgregarExpediente.etqApellido.Caption = AgregarExpediente.etqApellido.Caption & apellido
    AgregarExpediente.gradoi = gradoi
    AgregarExpediente.etqGradoInstruccion.Caption = AgregarExpediente.etqGradoInstruccion.Caption & gradoi
    AgregarExpediente.rango = rango
    AgregarExpediente.etqRango.Caption = AgregarExpediente.etqRango.Caption & rango
    AgregarExpediente.estacionp = estacionp
    AgregarExpediente.etqEstacionPolicial.Caption = AgregarExpediente.etqEstacionPolicial.Caption & estacionp
    AgregarExpediente.Show
    Unload Me
End Sub

Private Sub btnEditarexpediente_Click()
    EditarExpediente.codigo = Tabla.Columns(0).Text
    EditarExpediente.txtFecha.Text = Tabla.Columns(1).Text
    EditarExpediente.txtDescripcion.Text = Tabla.Columns(2).Text
    EditarExpediente.txtCausa.Text = Tabla.Columns(4).Text
    EditarExpediente.cmbStatus.Text = Tabla.Columns(5).Text
    EditarExpediente.txtOCAP.Text = Tabla.Columns(6).Text
    EditarExpediente.txtDecision.Text = Tabla.Columns(7).Text
    
    EditarExpediente.cedula = cedula
    EditarExpediente.etqCedula.Caption = EditarExpediente.etqCedula.Caption & cedula
    EditarExpediente.nombre = nombre
    EditarExpediente.etqNombre.Caption = EditarExpediente.etqNombre.Caption & nombre
    EditarExpediente.apellido = apellido
    EditarExpediente.etqApellido.Caption = EditarExpediente.etqApellido.Caption & apellido
    EditarExpediente.gradoi = gradoi
    EditarExpediente.etqGradoInstruccion.Caption = EditarExpediente.etqGradoInstruccion.Caption & gradoi
    EditarExpediente.rango = rango
    EditarExpediente.etqRango.Caption = EditarExpediente.etqRango.Caption & rango
    EditarExpediente.estacionp = estacionp
    EditarExpediente.etqEstacionPolicial.Caption = EditarExpediente.etqEstacionPolicial.Caption & estacionp
    
    EditarExpediente.Show
    Unload Me
End Sub



Private Sub btnRegresar_Click()
    ListadoFuncionario.Show
    Unload Me
End Sub

Private Sub btnEliminarExpediente_Click()
    resultado = MsgBox("Está seguro que desea eliminar el expediente" & Tabla.Columns(0).Text & "?", vbOKCancel, "CONFIRMACION")

    If resultado = vbOK Then
        strcon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb);"
        Set Conexion = New ADODB.Connection
        Conexion.Open strcon
        consulta = "SELECT * FROM Expediente WHERE Codigo='" & Tabla.Columns(0).Text & "'"
        Set Registros = New ADODB.Recordset
        Registros.Open consulta, Conexion
        If Not Registros.EOF Or Not Registros.BOF Then
            ControlLista.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;data source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb"

            consulta = "DELETE FROM Expediente WHERE Codigo='" & Tabla.Columns(0).Text & "'"
            Set Registros = New ADODB.Recordset
            Registros.Open consulta, Conexion
            ControlLista.RecordSource = "SELECT * FROM Expediente WHERE CedulaFuncionario=" & cedula & "AND Codigo<>'" & Tabla.Columns(0).Text & "'"
            
            ControlLista.Refresh
            
            Tabla.Col = 0
            
            Tabla.Row = 0
            MsgBox ("Expediente eliminado satisfactoriamente")
        End If
        Set Registros = Nothing
        Conexion.Close
    End If
End Sub
