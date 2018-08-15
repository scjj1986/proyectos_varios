VERSION 5.00
Object = "{67397AA1-7FB1-11D0-B148-00A0C922E820}#6.0#0"; "MSADODC.OCX"
Object = "{CDE57A40-8B86-11D0-B3C6-00A0C90AEA82}#1.0#0"; "MSDATGRD.OCX"
Begin VB.Form ListadoFuncionario 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Listado de Funcionarios"
   ClientHeight    =   6480
   ClientLeft      =   150
   ClientTop       =   480
   ClientWidth     =   10665
   Icon            =   "ListadoFuncionario.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   Picture         =   "ListadoFuncionario.frx":08CA
   ScaleHeight     =   6480
   ScaleWidth      =   10665
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton btnNuevoFuncionario 
      Caption         =   "Registrar Funcionario"
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
      Left            =   1320
      Picture         =   "ListadoFuncionario.frx":B830
      Style           =   1  'Graphical
      TabIndex        =   6
      Top             =   5280
      Width           =   1455
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
      Height          =   975
      Left            =   8040
      Picture         =   "ListadoFuncionario.frx":C0FA
      Style           =   1  'Graphical
      TabIndex        =   5
      Top             =   5280
      Width           =   1455
   End
   Begin VB.CommandButton btnListadoExpediente 
      Caption         =   "Listado Expedientes"
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
      Left            =   6360
      Picture         =   "ListadoFuncionario.frx":C9C4
      Style           =   1  'Graphical
      TabIndex        =   4
      Top             =   5280
      Width           =   1455
   End
   Begin VB.CommandButton btnEliminarFuncionario 
      Caption         =   "Eliminar Funcionario"
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
      Left            =   4680
      Picture         =   "ListadoFuncionario.frx":D28E
      Style           =   1  'Graphical
      TabIndex        =   3
      Top             =   5280
      Width           =   1455
   End
   Begin VB.CommandButton btnEditarFuncionario 
      Caption         =   "Editar Funcionario"
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
      Left            =   3000
      Picture         =   "ListadoFuncionario.frx":DB58
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   5280
      Width           =   1455
   End
   Begin MSAdodcLib.Adodc RegistrosFuncionarios 
      Height          =   375
      Left            =   3720
      Top             =   4680
      Width           =   3135
      _ExtentX        =   5530
      _ExtentY        =   661
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   2
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
      Connect         =   $"ListadoFuncionario.frx":E422
      OLEDBString     =   $"ListadoFuncionario.frx":E4D6
      OLEDBFile       =   ""
      DataSourceName  =   ""
      OtherAttributes =   ""
      UserName        =   ""
      Password        =   ""
      RecordSource    =   "Funcionario"
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
   Begin MSDataGridLib.DataGrid Tabla 
      Bindings        =   "ListadoFuncionario.frx":E58A
      Height          =   2895
      Left            =   120
      TabIndex        =   1
      Top             =   1560
      Width           =   10335
      _ExtentX        =   18230
      _ExtentY        =   5106
      _Version        =   393216
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
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "LISTADO DE FUNCIONARIOS"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   20.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2640
      TabIndex        =   0
      Top             =   720
      Width           =   5295
   End
End
Attribute VB_Name = "ListadoFuncionario"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim resultado As Integer
Dim Conexion As ADODB.Connection
Dim Registros As ADODB.Recordset
Dim consulta As String
Dim strcon As String
Dim rd As Recordset
Dim db As Database



Private Sub btnEditarFuncionario_Click()
    EditarFuncionario.id = Tabla.Columns(0).Text
    EditarFuncionario.txtCedula.Text = Tabla.Columns(1).Text
    EditarFuncionario.cedula = Tabla.Columns(1).Text
    EditarFuncionario.txtNombre.Text = Tabla.Columns(2).Text
    EditarFuncionario.txtApellido.Text = Tabla.Columns(3).Text
    EditarFuncionario.txtFechaNacimiento.Text = Tabla.Columns(4).Text
    EditarFuncionario.txtLugarNacimiento.Text = Tabla.Columns(5).Text
    EditarFuncionario.cmbEstadoCivil.Text = Tabla.Columns(6).Text
    EditarFuncionario.txtGradoInstruccion.Text = Tabla.Columns(7).Text
    EditarFuncionario.txtRango.Text = Tabla.Columns(8).Text
    EditarFuncionario.txtFechaIngreso.Text = Tabla.Columns(9).Text
    EditarFuncionario.txtEstacionPolicial.Text = Tabla.Columns(10).Text
    EditarFuncionario.txtDireccion.Text = Tabla.Columns(11).Text
    EditarFuncionario.Show
    Unload Me
End Sub

Private Sub btnEliminarFuncionario_Click()
    resultado = MsgBox("Al eliminar este funcionario, estará eliminando sus expedientes. Desea continuar?", vbOKCancel, "CONFIRMACION")

    If resultado = vbOK Then
        strcon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb);"
        Set Conexion = New ADODB.Connection
        Conexion.Open strcon
        consulta = "SELECT * FROM Funcionario WHERE cedula=" & Tabla.Columns(1).Text
        Set Registros = New ADODB.Recordset
        Registros.Open consulta, Conexion
        If Not Registros.EOF Or Not Registros.BOF Then
            Set Registros = New ADODB.Recordset
            consulta = "DELETE FROM Expediente WHERE CedulaFuncionario=" & Tabla.Columns(1).Text
            Registros.Open consulta, Conexion
            RegistrosFuncionarios.Recordset.Delete
            MsgBox ("Funcionario eliminado satisfactoriamente")
        End If
        Set Registros = Nothing
        Conexion.Close
    End If
End Sub

Private Sub btnListadoExpediente_Click()
    strcon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb);"
    Set Conexion = New ADODB.Connection
    Conexion.Open strcon
    consulta = "SELECT * FROM Expediente WHERE CedulaFuncionario=" & Tabla.Columns(1).Text
    
    Set Registros = New ADODB.Recordset
    Registros.Open consulta, Conexion
    If Not Registros.EOF Then
    
        ListadoExpedientesF.ControlLista.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;data source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb"

        ListadoExpedientesF.ControlLista.RecordSource = "SELECT * FROM Expediente WHERE CedulaFuncionario=" & Tabla.Columns(1).Text
        
        ListadoExpedientesF.ControlLista.Refresh
        
        ListadoExpedientesF.Tabla.Col = 0
        
        ListadoExpedientesF.Tabla.Row = 0
        
    End If
    Conexion.Close
    ListadoExpedientesF.cedula = Tabla.Columns(1).Text
    ListadoExpedientesF.etqCedula.Caption = ListadoExpedientesF.etqCedula.Caption & Tabla.Columns(1).Text
    ListadoExpedientesF.nombre = Tabla.Columns(2).Text
    ListadoExpedientesF.etqNombre.Caption = ListadoExpedientesF.etqNombre.Caption & Tabla.Columns(2).Text
    ListadoExpedientesF.apellido = Tabla.Columns(3).Text
    ListadoExpedientesF.etqApellido.Caption = ListadoExpedientesF.etqApellido.Caption & Tabla.Columns(3).Text
    ListadoExpedientesF.gradoi = Tabla.Columns(7).Text
    ListadoExpedientesF.etqGradoInstruccion.Caption = ListadoExpedientesF.etqGradoInstruccion.Caption & Tabla.Columns(7).Text
    ListadoExpedientesF.rango = Tabla.Columns(8).Text
    ListadoExpedientesF.etqRango.Caption = ListadoExpedientesF.etqRango.Caption & Tabla.Columns(8).Text
    ListadoExpedientesF.estacionp = Tabla.Columns(10).Text
    ListadoExpedientesF.etqEstacionPolicial.Caption = ListadoExpedientesF.etqEstacionPolicial.Caption & Tabla.Columns(10).Text
    ListadoExpedientesF.Show
    Unload Me
End Sub

Private Sub Salir_Click(Index As Integer)
    resultado = MsgBox("Desea salir de la aplicación?", vbOKCancel, "CONFIRMACION")

    If resultado = vbOK Then
        End
    End If
End Sub


Private Sub btnRegresar_Click()
    Inicio.Show
    Unload Me
End Sub

Private Sub btnNuevoFuncionario_Click()
    NuevoFuncionario.Show
    Unload Me
End Sub
