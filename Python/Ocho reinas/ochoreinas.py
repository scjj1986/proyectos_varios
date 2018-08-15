




import sys
import os
import random
import math


# ------ Variables Globales ----------

tablero=list()#arrego que simula el tablero del ajedrez
reinas=list()#arreglo de reinas
combinaciones=list()#arreglo que almacena las 40320 combinaciones de reinas desplegadas en el tablero
soluciones=list()#arreglo que almacena las soluciones
n_reinas=0#variable que contabiliza las cantidad de reinas, con respecto al arreglo de reinas

# ---------- Procedimiento y funciones -----------------

def inicializar_tablero(i): #Función para inicializar el tablero en casillas vacías
    global tablero
    for i in range (8):
        filas=[" "] * 8
        tablero.append(filas)
    return tablero    

def dibujar_tablero(i): #Procedimiento para mostrar la distribución de las reinas en el tablero
    global tablero
    for i in range (8):
        print (" ",tablero[i])
        print()
        

def columna_repetida(valor,i): #Función para verificar si hay coincidencia de reinas en una columna dada
    global reinas
    for i in range(len(reinas)):
        if reinas[i]==valor:
            return True
    return False


def generar_combinacion(j,i):#función que genera un arreglo de las posiciones de las reinas para ser evaluado
    if j<8:
        valor = random.randrange(8)#Se genera el numero aleatorio que sería la posición de la reina en una columna del tablero (del 0 al 7)
        while columna_repetida(valor,0):#Se verifica que no hayan elementos repetidos en el arreglo, es decir, que no coincidan las reinas en una misma columna del tablero, de ser así...
            valor = random.randrange(8)#Se vuelve a generar otro número aleatorio
        reinas.append(valor)#Una vez comprobado que es irrepetible el valor, se procede a guardar dicho elemento en el arreglo de reinas
        return generar_combinacion(j+1,i)
    return reinas


def pra_diagonal(x,y):#Función de la primera búsqueda en diagonal para localizar amenazas entre reinas
    if x<0 or x>7 or y<0 or y>7:#Una vez finalizado el desplazamiento diagonal o no hay casillas por verificar...
        return True# ... la subrutina retorna verdad
    elif tablero[x][y]=="Y":#Si encuentra una reina...
        return False# ... la subrutina retorna falso
    else:#Si la celda está vacía, procede a seguir buscando por medio de una llamada recursiva
        return pra_diagonal(x+1,y+1)

def sda_diagonal(x,y):#Función de la segunda búsqueda en diagonal (sólo cambia el decremento en 1 en x)
    if x<0 or x>7 or y<0 or y>7:
        return True
    elif tablero[x][y]=="Y":
        return False
    else:
        return sda_diagonal(x-1,y+1)

def tra_diagonal(x,y):#Función de la tercera búsqueda en diagonal (sólo cambia el decremento en 1 en x e y)
    if x<0 or x>7 or y<0 or y>7:
        return True
    elif tablero[x][y]=="Y":
        return False
    else:
        return tra_diagonal(x-1,y-1)

def cta_diagonal(x,y):#Función de la cuarta búsqueda en diagonal (sólo cambia el decremento en 1 en y)
    if x<0 or x>7 or y<0 or y>7:
        return True
    elif tablero[x][y]=="Y":
        return False
    else:
        return cta_diagonal(x+1,y-1)
        

def combinacion_exitosa():#Función que verifica si en una combinación de reinas en un arreglo, se amenazan entre sí
    global n_reinas
    global tablero
    global reinas
    n_reinas=0
    encontrado=True#Por defecto se considera que no hay amenazas
    tablero=list()
    tablero = inicializar_tablero(0)
    for x in range (8):#Recorrido del arreglo de reinas
        if reinas[x]!=-1:#De haber una reina..
            n_reinas=n_reinas+1#Se incrementa en 1 el contador de reinas
            y=reinas[x]#Se obtiene el valor de la columna de la reina a evaluar 
            if pra_diagonal(x,y)==False:#Si en el primer recorrido diagonal se encontró una reina
                encontrado=False#...Se encontró una amenaza, y se le asigna falso
            elif sda_diagonal(x,y)==False:#O en el segundo..
                encontrado=False#...Se encontró una amenaza, y se le asigna falso
            elif tra_diagonal(x,y)==False:#O en el tercero
                encontrado=False#...Se encontró una amenaza, y se le asigna falso
            elif cta_diagonal(x,y)==False:#O en el cuarto
                encontrado=False#...Se encontró una amenaza, y se le asigna falso
            tablero[x][y]="Y"#Se dibuja en el tablero la posición de la reina a evaluar
    if n_reinas==0:#Por defecto se considera fallido cuando no hay reinas en el tablero
        return False
    else:
        return encontrado


def combinacion_repetida():#Función que verifica si una combinacion generada del arreglo de reinas, se encuentra en el arreglo de combinaciones
    global combinaciones
    for i in range(len(combinaciones)):#Recorrido en el arreglo de combinaciones
        if combinaciones[i]==reinas:#De haber una concidencia...
            return True#Retorna verdadero
    return False#Retorna falso si la combinación generada no se encuentra en las combinaciones

def BuscarUnaSolucion(i):#Función recursiva que encuentra 1 de las 92 soluciones posibles
    #Variables globales
    global combinaciones
    global reinas
    global tablero
    global soluciones
    #Fin variables
    if i<40320:#Se recorre todas las combinaciones
        reinas=list()#Inicializar el arreglo de reinas
        reinas=generar_combinacion(0,0)#Generar la combinación aleotoria
        while combinacion_repetida():#Iteramos hasta que se genere una combinación que no sea repetida
            reinas=list()#Inicializar el arreglo de reinas
            reinas=generar_combinacion(0,0)#generar una combinación
        combinaciones.append(reinas)#Se guarda dicha combinación en el arreglo de combinaciones
        if combinacion_exitosa():#Si la combinación es una solución...
            soluciones.append(reinas)#Se guarda la combinación en el arreglo de soluciones
            return True#Devuelve verdadero la función
        return BuscarUnaSolucion(i+1)#De no hallar, se invoca a si misma para buscar la siguiente iteración
    return False

def BuscarTodasSoluciones(i):#Procedimiento recursivo que encuentra las 92 soluciones
    #Variables globales
    global combinaciones
    global reinas
    global soluciones
    global n_soluciones
    global tablero
    #Variables globales
    if i<40320:#REcorrido de las 40320 combinaciones
        reinas=list()#Inicializar el arreglo de reinas
        reinas=generar_combinacion(0,0)#generar una combinación aleatoria
        while combinacion_repetida():#Iteramos hasta que se genere una combinación que no sea repetida
            reinas=list()
            reinas=generar_combinacion(0,0)
        combinaciones.append(reinas)#Se guarda dicha combinación en el arreglo de combinaciones
        if combinacion_exitosa():#Si la combinación es una solución...
            soluciones.append(reinas)#Se guarda la solución en dicho arreglo
            print ("------------------------ Solución # ",len(soluciones)," ------------------------")#Se muestra detalladamente la solución
            detalles_combinacion()
            print ("-----------------------------------------------------")
            teclado=input("Presione Enter para continuar...")
        tablero=list()
        tablero=inicializar_tablero(0)#Limpiar tablero
        BuscarTodasSoluciones(i+1)#Se busca otra solución

def detalles_combinacion():#Muestra los detalles de una combinación específica 
    print("*Detalles de la combinación de reinas ",reinas)
    if combinacion_exitosa():#Resultado, si fue exitos o no
        print(" Resultado: Exitoso")
    else:
        print(" Resultado: Fallido")
    print(" Número de reinas: ",n_reinas)#Cantidad de reinas
    print (" Distribución de las reinas en el tablero:")#Se colocan las reinas en el tablero
    print()
    i=0
    dibujar_tablero(i)



#---------- ALGORITMO PRINCIPAL ----------------------------------#
    
tablero=list()
tablero = inicializar_tablero(0)
salir=False
sys.setrecursionlimit(1000000000)
print ("Bienvenido a la aplicación de las ocho (8) reinas")#Bienvenida a la aplicación
while salir==False:#bucle para gestionar la salida del programa
    print("Opciones:")#menú de opciones
    print("")
    print("1) Para ver los resultados de los arreglos de prueba")
    print("2) Para hallar una solución")
    print("3) Para hallar todas las soluciones")
    print("4) Para salir de la aplicación")
    teclado=input("")
    while teclado!="1" and teclado!="2" and teclado!="3" and teclado!="4":#Validación
        teclado=input("Error. Teclee una opción correcta")
    if teclado=="1":#De ser la opción 1, se evalúan las 3 combinaciones de prueba
        reinas=list()
        reinas=[5, 3, 6, 0, 2, 4, 1, 7]#Carga del primer arreglo de reinas
        detalles_combinacion()#Se verifica si es una solución
        teclado=input("Presione Enter para continuar...")
        reinas=list()
        reinas=[1,-1,2,-1,7,-1,0,3]#Carga del segundo arreglo de reinas
        detalles_combinacion()#Se verifica si es una solución
        teclado=input("Presione Enter para continuar...")
        reinas=list()
        reinas=[-1,-1,-1,-1,-1,-1,-1,-1]#Carga del tercer arreglo de reinas
        detalles_combinacion()#Se verifica si es una solución
        tablero=list()
        tablero=inicializar_tablero(0)#Limpiar tablero
    elif teclado=="2":#De ser la opción 2, se busca una solución al azar
        combinaciones=list()
        if BuscarUnaSolucion(0):#Una vez encontrada la solución...
            detalles_combinacion()#Se muestra por pantalla
        tablero=list()
        tablero=inicializar_tablero(0)#Limpiar tablero
    elif teclado=="3":
        combinaciones=list()
        soluciones=list()#Inicialización del arreglo de soluciones y combinaciones
        BuscarTodasSoluciones(0)#Búsqueda de todas las soluciones
        tablero=list()
        tablero=inicializar_tablero(0)#Limpiar tablero
    elif teclado=="4":#Salir del programa
        salir=True
    teclado=input("Presione Enter para continuar...")




