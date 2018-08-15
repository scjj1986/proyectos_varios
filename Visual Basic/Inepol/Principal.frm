VERSION 5.00
Begin VB.Form Principal 
   BackColor       =   &H80000002&
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "SISTEORDP"
   ClientHeight    =   4965
   ClientLeft      =   150
   ClientTop       =   480
   ClientWidth     =   8310
   Icon            =   "Principal.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   Picture         =   "Principal.frx":08CA
   ScaleHeight     =   4965
   ScaleWidth      =   8310
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton btnIngresar 
      Caption         =   "Ingresar"
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
      Picture         =   "Principal.frx":B830
      Style           =   1  'Graphical
      TabIndex        =   6
      Top             =   3840
      Width           =   1455
   End
   Begin VB.TextBox txtContrasena 
      Height          =   285
      Left            =   3960
      TabIndex        =   5
      Top             =   3240
      Width           =   1935
   End
   Begin VB.TextBox txtUsuario 
      Height          =   285
      Left            =   3960
      TabIndex        =   3
      Top             =   2760
      Width           =   1935
   End
   Begin VB.PictureBox Picture1 
      Height          =   1575
      Left            =   3360
      Picture         =   "Principal.frx":C0FA
      ScaleHeight     =   1515
      ScaleWidth      =   1395
      TabIndex        =   1
      Top             =   840
      Width           =   1455
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "Contrase#a:"
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
      Left            =   2280
      TabIndex        =   4
      Top             =   3240
      Width           =   1695
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "Usuario:"
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
      Left            =   2760
      TabIndex        =   2
      Top             =   2760
      Width           =   1335
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "SISTEMA DE ADMINISTRACIÓN DE EXPEDIENTES"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   18
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   8295
   End
End
Attribute VB_Name = "Principal"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Conexion As ADODB.Connection
Dim Registros, Registros2 As ADODB.Recordset
Dim consulta As String
Dim strcon As String


Private Sub Nuevo_Click(Index As Integer)
    NuevoFuncionario.Show
    Unload Me
End Sub


Private Sub Expediente_Click(Index As Integer)
    ExpedienteMes.Show
    Unload Me
End Sub



Private Sub ListadoF_Click(Index As Integer)
    ListadoFuncionario.Show
    Unload Me
End Sub

Private Sub NuevoF_Click(Index As Integer)
    NuevoFuncionario.Show
    Unload Me
End Sub

Private Sub Salir_Click(Index As Integer)
    End
End Sub

Private Sub btnIngresar_Click()
    If txtUsuario.Text = "" Or txtContrasena.Text = "" Then
        MsgBox ("No puede dejar campos vacíos")
    Else
        strcon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb; Server.MapPath(C:\Users\salazar\Documents\Documentos S.C.J.J\Aplicaciones\Visual Basic\Inepol\Base De Datos\Inepol.mdb);"
        Set Conexion = New ADODB.Connection
        Conexion.Open strcon
        consulta = "SELECT * FROM Usuario WHERE Nombre='" & txtUsuario.Text & "' And Contrasena='" & txtContrasena.Text & "'"
        Set Registros = New ADODB.Recordset
        Registros.Open consulta, Conexion
        If Registros.EOF Or Registros.BOF Then
            MsgBox ("Usuario o contrase#a incorrectos. Intente de nuevo")
        Else
            
            Inicio.Show
            Unload Me
        End If
        Set Registros = Nothing
        Conexion.Close
    
    End If
End Sub
