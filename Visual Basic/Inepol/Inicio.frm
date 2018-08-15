VERSION 5.00
Begin VB.Form Inicio 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Inicio"
   ClientHeight    =   8940
   ClientLeft      =   150
   ClientTop       =   780
   ClientWidth     =   6945
   Icon            =   "Inicio.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   Picture         =   "Inicio.frx":08CA
   ScaleHeight     =   8940
   ScaleWidth      =   6945
   StartUpPosition =   3  'Windows Default
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "INEPOL - EDO. NUEVA ESPARTA"
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1680
      TabIndex        =   2
      Top             =   1080
      Width           =   3855
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "DE EXPEDIENTES "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2520
      TabIndex        =   1
      Top             =   720
      Width           =   1935
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "SISTEMA DE ADMINISTRACIÓN "
      BeginProperty Font 
         Name            =   "Consolas"
         Size            =   12.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1800
      TabIndex        =   0
      Top             =   360
      Width           =   3375
   End
   Begin VB.Menu Func 
      Caption         =   "Funcionarios"
   End
   Begin VB.Menu ExpMes 
      Caption         =   "Expedientes por Mes"
   End
   Begin VB.Menu Us 
      Caption         =   "Usuario"
      Begin VB.Menu Edit 
         Caption         =   "Editar"
      End
      Begin VB.Menu Cerr 
         Caption         =   "Cerrar Sesión"
      End
   End
End
Attribute VB_Name = "Inicio"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub ExpMes_Click()
    ExpedienteMes.Show
    Unload Me
End Sub

Private Sub Func_Click()
    ListadoFuncionario.Show
    Unload Me
End Sub
