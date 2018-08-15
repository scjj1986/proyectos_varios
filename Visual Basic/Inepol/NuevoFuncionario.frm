VERSION 5.00
Begin VB.Form NuevoFuncionario 
   BackColor       =   &H000000FF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Nuevo Funcionario"
   ClientHeight    =   7995
   ClientLeft      =   150
   ClientTop       =   480
   ClientWidth     =   6990
   Icon            =   "NuevoFuncionario.frx":0000
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   Picture         =   "NuevoFuncionario.frx":08CA
   ScaleHeight     =   7995
   ScaleWidth      =   6990
   StartUpPosition =   3  'Windows Default
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
      Left            =   3720
      Picture         =   "NuevoFuncionario.frx":B830
      Style           =   1  'Graphical
      TabIndex        =   24
      Top             =   6960
      Width           =   975
   End
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
      Left            =   2400
      Picture         =   "NuevoFuncionario.frx":C0FA
      Style           =   1  'Graphical
      TabIndex        =   23
      Top             =   6960
      Width           =   975
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
      Left            =   3480
      TabIndex        =   21
      Top             =   6240
      Width           =   3255
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
      Left            =   3480
      TabIndex        =   19
      Top             =   5760
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
      Left            =   3480
      TabIndex        =   17
      Top             =   5280
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
      Left            =   3480
      TabIndex        =   15
      Top             =   4800
      Width           =   1815
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
      Left            =   3480
      TabIndex        =   13
      Top             =   4320
      Width           =   1815
   End
   Begin VB.ComboBox cmbEstadoCivil 
      DataField       =   "l"
      Height          =   315
      ItemData        =   "NuevoFuncionario.frx":C9C4
      Left            =   3480
      List            =   "NuevoFuncionario.frx":C9D1
      Style           =   2  'Dropdown List
      TabIndex        =   12
      Top             =   3840
      Width           =   1575
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
      Left            =   3480
      TabIndex        =   9
      Top             =   3360
      Width           =   2895
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
      Left            =   3480
      TabIndex        =   7
      Top             =   2880
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
      Left            =   3480
      TabIndex        =   5
      Top             =   2400
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
      Left            =   3480
      TabIndex        =   3
      Top             =   1920
      Width           =   1815
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
      Left            =   3480
      TabIndex        =   2
      Top             =   1440
      Width           =   1815
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
      Left            =   1800
      TabIndex        =   22
      Top             =   6240
      Width           =   1695
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
      Left            =   600
      TabIndex        =   20
      Top             =   5760
      Width           =   2895
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
      Left            =   720
      TabIndex        =   18
      Top             =   5280
      Width           =   2775
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
      Left            =   2400
      TabIndex        =   16
      Top             =   4800
      Width           =   1095
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
      Left            =   120
      TabIndex        =   14
      Top             =   4320
      Width           =   3375
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
      Left            =   1320
      TabIndex        =   11
      Top             =   3840
      Width           =   2175
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
      Left            =   240
      TabIndex        =   10
      Top             =   3360
      Width           =   3255
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
      Left            =   240
      TabIndex        =   8
      Top             =   2880
      Width           =   3255
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
      Left            =   1920
      TabIndex        =   6
      Top             =   2400
      Width           =   1455
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
      Left            =   2160
      TabIndex        =   4
      Top             =   1920
      Width           =   1215
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
      Left            =   2160
      TabIndex        =   1
      Top             =   1440
      Width           =   1215
   End
   Begin VB.Label etqRegistro 
      Appearance      =   0  'Flat
      BackColor       =   &H80000006&
      BackStyle       =   0  'Transparent
      Caption         =   "REGISTRO DE NUEVO FUNCIONARIO"
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
      Left            =   240
      TabIndex        =   0
      Top             =   600
      Width           =   6855
   End
End
Attribute VB_Name = "NuevoFuncionario"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Conexion As ADODB.Connection
Dim Registros As ADODB.Recordset
Dim encontrado As Boolean
Dim consulta As String
Dim strcon As String
Dim resultado As Integer


Private Sub btnGuardar_Click()

    strcon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb);"
    
    Set Conexion = New ADODB.Connection
    Conexion.Open strcon
    If txtCedula.Text = "" Or txtNombre.Text = "" Or txtApellido.Text = "" Or Not IsDate(txtFechaNacimiento.Text) Or txtLugarNacimiento.Text = "" Or cmbEstadoCivil.Text = "" Or txtGradoInstruccion.Text = "" Or txtRango.Text = "" Or Not IsDate(txtFechaIngreso.Text) Or txtEstacionPolicial.Text = "" Or txtDireccion.Text = "" Then
        MsgBox ("Error en campos de texto. Intente nuevamente")
    
    Else
        consulta = "SELECT * FROM Funcionario WHERE cedula=" & txtCedula.Text
        Set Registros = New ADODB.Recordset
        Registros.Open consulta, Conexion
        If Not Registros.EOF And Not Registros.BOF Then
            MsgBox ("La cédula ingresada coincide con la de un funcionario registrado en la base de datos.")
            Set Registros = Nothing
            
        Else
            Set Registros = New ADODB.Recordset
            consulta = "INSERT INTO Funcionario (Cedula,Nombre,Apellido,FechaNacimiento,LugarNacimiento,EstadoCivil,GradoInstruccion,Rango,FechaIngreso,EstacionPolicial,Direccion) VALUES ('" & txtCedula.Text & "','" & txtNombre.Text & "','" & txtApellido.Text & "','" & txtFechaNacimiento.Text & "','" & txtLugarNacimiento.Text & "','" & cmbEstadoCivil.Text & "','" & txtGradoInstruccion.Text & "','" & txtRango.Text & "','" & txtFechaIngreso.Text & "','" & txtEstacionPolicial.Text & "','" & txtDireccion.Text & "')"
            Registros.Open consulta, Conexion
            MsgBox ("Datos almacenados exitosamente")
            Set Registros = Nothing
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
