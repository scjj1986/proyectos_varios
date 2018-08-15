VERSION 5.00
Begin VB.Form EditarFuncionario 
   Caption         =   "Editar Funcionario"
   ClientHeight    =   7455
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   7455
   Icon            =   "EditarFuncionario.frx":0000
   LinkTopic       =   "Form1"
   Picture         =   "EditarFuncionario.frx":08CA
   ScaleHeight     =   7455
   ScaleWidth      =   7455
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton btnGuardar 
      BackColor       =   &H00FFFFFF&
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
      Height          =   735
      Left            =   2640
      Picture         =   "EditarFuncionario.frx":B830
      Style           =   1  'Graphical
      TabIndex        =   24
      Top             =   6360
      Width           =   975
   End
   Begin VB.CommandButton btnRegresar 
      BackColor       =   &H00FFFFFF&
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
      Height          =   735
      Left            =   3960
      Picture         =   "EditarFuncionario.frx":C0FA
      Style           =   1  'Graphical
      TabIndex        =   23
      Top             =   6360
      Width           =   975
   End
   Begin VB.ComboBox cmbEstadoCivil 
      DataField       =   "l"
      Height          =   315
      ItemData        =   "EditarFuncionario.frx":C9C4
      Left            =   3600
      List            =   "EditarFuncionario.frx":C9D1
      TabIndex        =   16
      Text            =   "Seleccione..."
      Top             =   3360
      Width           =   1575
   End
   Begin VB.TextBox txtGradoInstruccion 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0;(0)"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   8202
         SubFormatType   =   1
      EndProperty
      Height          =   285
      Left            =   3600
      TabIndex        =   15
      Top             =   3840
      Width           =   1815
   End
   Begin VB.TextBox txtRango 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0;(0)"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   8202
         SubFormatType   =   1
      EndProperty
      Height          =   285
      Left            =   3600
      TabIndex        =   14
      Top             =   4320
      Width           =   1815
   End
   Begin VB.TextBox txtFechaIngreso 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0;(0)"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   8202
         SubFormatType   =   1
      EndProperty
      Height          =   285
      Left            =   3600
      TabIndex        =   13
      Top             =   4800
      Width           =   1815
   End
   Begin VB.TextBox txtEstacionPolicial 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0;(0)"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   8202
         SubFormatType   =   1
      EndProperty
      Height          =   285
      Left            =   3600
      TabIndex        =   12
      Top             =   5280
      Width           =   1815
   End
   Begin VB.TextBox txtDireccion 
      DataField       =   "Direccion"
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0;(0)"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   8202
         SubFormatType   =   1
      EndProperty
      DataSource      =   "BaseDatos"
      Height          =   285
      Left            =   3600
      TabIndex        =   11
      Top             =   5760
      Width           =   3255
   End
   Begin VB.TextBox txtCedula 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0;(0)"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   8202
         SubFormatType   =   1
      EndProperty
      DataSource      =   "BaseDatos"
      Height          =   285
      Left            =   3600
      TabIndex        =   4
      Top             =   960
      Width           =   1815
   End
   Begin VB.TextBox txtNombre 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0;(0)"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   8202
         SubFormatType   =   1
      EndProperty
      Height          =   285
      Left            =   3600
      TabIndex        =   3
      Top             =   1440
      Width           =   1815
   End
   Begin VB.TextBox txtApellido 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0;(0)"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   8202
         SubFormatType   =   1
      EndProperty
      Height          =   285
      Left            =   3600
      TabIndex        =   2
      Top             =   1920
      Width           =   1815
   End
   Begin VB.TextBox txtFechaNacimiento 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0;(0)"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   8202
         SubFormatType   =   1
      EndProperty
      Height          =   285
      Left            =   3600
      TabIndex        =   1
      Top             =   2400
      Width           =   1815
   End
   Begin VB.TextBox txtLugarNacimiento 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0;(0)"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   8202
         SubFormatType   =   1
      EndProperty
      Height          =   285
      Left            =   3600
      TabIndex        =   0
      Top             =   2880
      Width           =   2895
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "*Estado Civil:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   1440
      TabIndex        =   22
      Top             =   3360
      Width           =   2175
   End
   Begin VB.Label Label4 
      BackStyle       =   0  'Transparent
      Caption         =   "*Grado de Instrucción:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   240
      TabIndex        =   21
      Top             =   3840
      Width           =   3375
   End
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "*Rango:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2520
      TabIndex        =   20
      Top             =   4320
      Width           =   1095
   End
   Begin VB.Label Label6 
      BackStyle       =   0  'Transparent
      Caption         =   "*Fecha de Ingreso:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   840
      TabIndex        =   19
      Top             =   4800
      Width           =   2775
   End
   Begin VB.Label Label7 
      BackStyle       =   0  'Transparent
      Caption         =   "*Estación Policial:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   720
      TabIndex        =   18
      Top             =   5280
      Width           =   2895
   End
   Begin VB.Label Label8 
      BackStyle       =   0  'Transparent
      Caption         =   "*Dirección:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   1920
      TabIndex        =   17
      Top             =   5760
      Width           =   1695
   End
   Begin VB.Label etqRegistro 
      Appearance      =   0  'Flat
      BackColor       =   &H80000006&
      BackStyle       =   0  'Transparent
      Caption         =   "DATOS DEL FUNCIONARIO"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   20.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   735
      Left            =   1320
      TabIndex        =   10
      Top             =   120
      Width           =   5055
   End
   Begin VB.Label etqCedula 
      BackStyle       =   0  'Transparent
      Caption         =   "*Cédula:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   2280
      TabIndex        =   9
      Top             =   960
      Width           =   1215
   End
   Begin VB.Label etqNombre 
      BackStyle       =   0  'Transparent
      Caption         =   "*Nombre:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   2280
      TabIndex        =   8
      Top             =   1440
      Width           =   1215
   End
   Begin VB.Label etqApellido 
      BackStyle       =   0  'Transparent
      Caption         =   "*Apellido:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2040
      TabIndex        =   7
      Top             =   1920
      Width           =   1455
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "*Fecha de Nacimiento:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   360
      TabIndex        =   6
      Top             =   2400
      Width           =   3255
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "*Lugar de Nacimiento:"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   360
      TabIndex        =   5
      Top             =   2880
      Width           =   3255
   End
End
Attribute VB_Name = "EditarFuncionario"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public id As String
Public cedula As String



Private Sub btnGuardar_Click()

    strcon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb);"
    
    Set Conexion = New ADODB.Connection
    Conexion.Open strcon
    If txtCedula.Text = "" Or txtNombre.Text = "" Or txtApellido.Text = "" Or Not IsDate(txtFechaNacimiento.Text) Or txtLugarNacimiento.Text = "" Or cmbEstadoCivil.Text = "" Or txtGradoInstruccion.Text = "" Or txtRango.Text = "" Or Not IsDate(txtFechaIngreso.Text) Or txtEstacionPolicial.Text = "" Or txtDireccion.Text = "" Then
        MsgBox ("Error en campos de texto. Intente nuevamente")
    
    Else
        consulta = "SELECT * FROM Funcionario WHERE cedula=" & txtCedula.Text & "AND id<>" & id
        Set Registros = New ADODB.Recordset
        Registros.Open consulta, Conexion
        If Not Registros.EOF And Not Registros.BOF Then
            MsgBox ("La cédula ingresada coincide con la de un funcionario registrado en la base de datos.")
            Set Registros = Nothing
            
        Else
            Set Registros = New ADODB.Recordset
            consulta = "UPDATE Funcionario SET Cedula='" & txtCedula.Text & "',Nombre='" & txtNombre.Text & "',Apellido='" & txtApellido.Text & "',FechaNacimiento='" & txtFechaNacimiento.Text & "',LugarNacimiento='" & txtLugarNacimiento.Text & "',EstadoCivil='" & cmbEstadoCivil.Text & "',GradoInstruccion='" & txtGradoInstruccion.Text & "',Rango='" & txtRango.Text & "',FechaIngreso='" & txtFechaIngreso.Text & "',EstacionPolicial='" & txtEstacionPolicial.Text & "',Direccion='" & txtDireccion.Text & "' WHERE id=" & id
            Registros.Open consulta, Conexion
            Set Registros = Nothing
            Set Registros = New ADODB.Recordset
            consulta = "UPDATE Expediente SET CedulaFuncionario='" & txtCedula.Text & "' WHERE CedulaFuncionario=" & cedula
            Registros.Open consulta, Conexion
            Set Registros = Nothing
            MsgBox ("Datos almacenados exitosamente")
            ListadoFuncionario.Show
            Unload Me
        End If
    End If
    Conexion.Close
    
End Sub

Private Sub btnRegresar_Click()
    ListadoFuncionario.Show
    Unload Me
End Sub

Private Sub txtApellido_KeyPress(KeyAscii As Integer)
    Select Case KeyAscii
        Case 65 To 90   ' Mayusculas
        Case 97 To 122 'Minusculas
        Case 8      ' Permite el carácter de retroceso
        Case 32
        Case Else
            KeyAscii = 0
            Beep
    End Select
End Sub

Private Sub txtCedula_KeyPress(KeyAscii As Integer)
    Select Case KeyAscii
        Case 48 To 57   ' Permite los dígitos
        Case 8      ' Permite el carácter de retroceso
        Case Else
            KeyAscii = 0
            Beep
    End Select
End Sub



Private Sub txtLugarNacimiento_KeyPress(KeyAscii As Integer)
    Select Case KeyAscii
        Case 65 To 90   ' Mayusculas
        Case 97 To 122 'Minusculas
        Case 8      ' Permite el carácter de retroceso
        Case 32
        Case Else
            KeyAscii = 0
            Beep
    End Select

End Sub

Private Sub txtNombre_KeyPress(KeyAscii As Integer)
    Select Case KeyAscii
        Case 65 To 90   ' Mayusculas
        Case 97 To 122 'Minusculas
        Case 8      ' Permite el carácter de retroceso
        Case 32
        Case Else
            KeyAscii = 0
            Beep
    End Select
End Sub
