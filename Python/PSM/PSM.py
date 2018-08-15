#                                           Proyecto PSM
#Realizado por: Br. Juan Salazar
#C.I.=17846688
#Asignnatura:Lenguajes de programacion; sec. "34"
#Software utilizado: Python version 3.0.1


#------------Librerias para generar el archivo de salida xml---------------#
from xml.dom import *
import sys
from xml.sax.saxutils import XMLGenerator
from xml.sax.xmlreader import AttributesNSImpl
from xml.dom import minidom
#===========================================================================#
        
        
#-----------------------funcion booleana que determina si una cadena es numerica-----------------------#
def isint(cad):
    num=0
    try:
        num= int(cad)
    except:
        return False
    return True

#======================================================================================================#

#-----------------funcion booleana si en una cadena no existen caracteres numericos--------------------#

def noint (cad):
    i=0
    j=0
    for i in range(0,len(cad)):
        try:
            num=int(cad[i])
        except:
            j+=1 
    if j==len(cad):
        return True
    return False

#=======================================================================================================#

#------funcion para extraer o desapilar un nodo de mystack, para ser agregado a una pila auxiliar-------#

def desapilar(mystack,auxstack):
    nodo=mystack.pop()
    auxstack.append(nodo)

#=======================================================================================================#



#--------------funcion para extraer el contenido de un archivo de texto especifico---------------------#

def extraer(archivo,files,npal):
    try: #excepcion en caso de que no exista un archivo de texto
        f = open(archivo) #Se abre el archivo con el nombre de la variable "archivo" pasada por parametro
        npal=0
        for line in f.readlines(): #se va recorriendo el archivo linea a linea
            line=line.upper()#se transforma a mayuscula el contenido de cada linea
            if line.endswith("\n"):#para eliminar el simbolo de enter
                li2=line[:-1]#se elimina aqui
            else:
                li2=line
            npal=npal + len(li2.split())#para llevar el control de las palabras en caso de un archivo vacio
            if npal!=0:
                files.append(li2)#se agrega cada linea en una posicion de la lista files
        f.close() #se cierra el archivo
        if npal==0:#si no hay palabras
            print("================================================================================")
            print("                                    "+archivo)
            print("Error, Archivo "+archivo+" vacio")#quiere decir que el archivo esta vacio
    except:
        files = []

#======================================================================================================#




#-----funcion para verificar la sintaxis de un archivo de texto especifico, contenido en la lista files------#

def sintax(files,archivo):
    inicio=False
    j=0
    print("================================================================================")
    print("                                    "+archivo)
    for i in range(0,len(files)):#se recorre linea por linea en la lista files
        lines=files[i].split()#Se fragmenta en palabras el contenido de una posicion de la lista files, para que estas palabras sean almacenadas en la lista lines
        if len(lines)!=0:#si la linea no esta vacia
            if len(lines)==6:#si tiene 6 palabras(exclusivo para la declaracion de la pila)
                if lines[0]!="STACK" or lines[1]!="SIZE" or lines[2]!="FROM" or lines[4]!="TO":#si no cumple con lo de STACK SIZE FROM TO en sus respectivas posiciones
                    print("Error Linea %d =>Error de sintaxis"%(i+1))
                    return False
                elif isint(lines[3])==False or isint(lines[5])==False:#si los valores en la declaracion de la pila no son munericos
                    print("Error Linea %d =>Asignacion incorrecta de la pila"%(i+1))
                    return False
                elif int(lines[3])>int(lines[5]):#Si el valor inicial es mayor que el tope
                    print("Error en Linea %d =>Error de sintaxis: El tamaño inicial no puede ser mayor que el tamaño final de la pila"%(i+1))
                    return False
                elif int(lines[3])+1==int(lines[5]):#para evitar trabajar con pilas de tamaño 1
                    print("Error en Linea %d =>Tamaño pequeño de pila"%(i+1))
                    return False
                elif i==len(files)-1:#si esta es la ultima linea
                    print("Error en Linea %d =>Error de sintaxis:Instruccion END no localizada"%(i+1))
                    return False
                elif inicio==True:#si se vuelve a declarar la pila
                    print("Error en Linea %d =>Pila redeclarada"%(i+1))
                    return False                  
                else:
                    inicio=True
                    posinic=i
            elif len(lines)==3:#si tiene 3 palabras(exclusivo para la insercion de elementos en la pila)
                if lines[0]!="PUSH":#si la primera palabra no es PUSH
                    print("Error en Linea %d =>Error de sintaxis"%(i+1))
                    return False
                elif noint(lines[1])==False:#si el nombre del regisrto de activacion posee caracteres numericos
                    print("Error en Linea %d =>Declaracion incorrecta del RA"%(i+1))
                    return False
                elif len(lines[2])<=2:#Si la asignacion del registro de activacion posee 2 caracteres("()", "(1", "a)", "13", etc)
                    print("Error en Linea %d =>Asignacion incorrecta del RA"%(i+1))
                    return False
                elif lines[2][0]!="(" or lines[2][len(lines[2])-1]!=")":#si falta(n) parentesis
                    print("Error en Linea %d =>Asignacion incorrecta del RA"%(i+1))
                    return False                 
                elif isint(lines[2][1:-1])==False:#si el valor del registro de activacion(truncando los parentesis)no es una cadena de numeros
                    print("Error en Linea %d =>Asignacion incorrecta del RA"%(i+1))
                    return False
                elif int(lines[2][1:-1])<=0:#si el valor del registro de activacion(truncando los parentesis) es menor o igual a cero
                    print("Error en Linea %d =>Error de sintaxis:Asignacion incorrecta del RA"%(i+1))
                    return False
                elif inicio==False:#si no se ha declarado la pila
                    print("Error en Linea %d =>Error de sintaxis:Pila no declarada"%(i+1))
                    return False                
                elif i==len(files)-1:#si es la ultima linea
                    print("Error en Linea %d =>Error de sintaxis:Instruccion END no localizada"%(i+1))
                    return False
            elif len(lines)==1:#si tiene 1 palabra(para POP y END)
                if lines[0]!="POP" and lines[0]!="END":#si la palabra es distinta a POP y END
                    print("Error en Linea %d =>Error de sintaxis"%(i+1))
                    return False
                elif lines[0]=="POP":#si es POP
                    if inicio==False:#si no se declaro la pila
                        print("Error en Linea %d =>Error de sintaxis: Pila no declarada"%(i+1))
                        return False
                    elif i==len(files)-1:#si es la ultima linea
                        print("Error en Linea %d =>Error de sintaxis:Instruccion END no localizada"%(i+1))
                        return False
                elif lines[0]=="END":#si es END
                    if inicio==False:#si no se declaro la pila
                        print("Error en Linea %d =>Error de sintaxis: Pila no declarada"%(i+1))
                        return False
                    elif posinic+1==i:
                        print("Error en Linea %d =>Error: Pila sin instruccion"%(i+1))
                        return False
                    else:
                        return True
            else:#si es otra cantidad de palabras, se debe mostrar error
                print("Error en Linea %d =>Error de sintaxis"%(i+1))
                return False
        elif i==len(files)-1:#En caso de que la ultima linea sea un espacio en blanco
            print("Error en Linea %d =>Error de sintaxis:Instruccion END no localizada"%(i+1))
            return False
    return True 

#=======================================================================================================================#

class Mystack: #esta es mi pila
    node=[]
    def apilar(self,ra):
        Mystack.node.append(ra)

    def desapilar(self):
        valor=Mystack.node.pop()
        return valor
        

#-------------------funcion para ejecutar un archivo de texto dado, contenido en la lista files-------------------------#
                    
def exe(files,archivo,mystack): 
    nlin=0 #variable entera que contara las lineas procesadas
    inic=0 #indicara la posicion de inicio de la pila
    fin=0 #indicara la posicion final de la pila
    actual=0 #indicara la posicion actual de la pila
    libre=0 #indicara la posicion libre de la pila
    mx=0 #indicara la cantidad maxima de espacios ocupados de la pila
    acum=0 #variable que ayudara a calcular la cantidad maxima de espacios ocupados de la pila 
    lra=[] #Lista de listas que contendra en cada posicion de todos los registros de activacion que intervinieron en la pila con la cantidad total de espacios que le fueron asignados 
    ra=[] #Lista que guarda el nombre de un registro de activacion dado con su valor especifico
    lpush=[] #lista de listas que guardara en cada posicion todos los registros que fueron insertados en la pila
    npop=0 #indica la cantidad de expulsiones presentes en la ejecucion del programa
    lib=[] #guarda la secuencia de valores del apuntador libre durante la ejecucion
    act=['NULL'] #guarda la secuencia de valores del apuntador libre durante la ejecucion, se inicializa en NULL
    for i in range(0,len(files)): #se recorre linea por linea en la lista files
        lines=files[i].split() #Se fragmenta en palabras el contenido de una posicion de la lista files, para que estas palabras sean almacenadas en la lista lines
        if files[i]!="": #si no hay lineas vacias
            if lines[0]=="STACK": #si la primera palabra es STACK
                nlin+=1 #autoincremento numero de lineas
                inic=int(lines[3])#asigno posicion inicial
                fin=int (lines[5]) #asigno posicion final
                libre=inic #inicializo el puntero libre
                lib.append(str(libre))#guardo la secuencia de valores del puntero libre como cadena en la lista lib
            elif lines[0]=="PUSH": #si la primera palabra es push
                if libre+int(lines[2][1:-1])-1>fin: #se verifica si el elemento que se va a insertar,no se puede montar en la pila
                    print("Linea (%d)=>Desbordamiento de la pila  "%(i+1))
                elif libre+int(lines[2][1:-1])-1==fin: #En caso de que no quede espacios libres
                    nlin+=1 #autoincremento numero de lineas
                    actual=libre#actual le asigno libre
                    libre=fin+1#en este caso se al puntero libre se le asigna el final mas 1
                    act.append(str(actual)) #guardo la secuencia de valores del puntero actual como cadena en la lista lib
                    lib.append("NULL") #como la pila esta llena, el puntero libre queda en nulo
                    num=int(lines[2][1:-1])#se truncan los parentesis, y se convierte en un entero para ser guardado en una variable entera
                    acum+=int(lines[2][1:-1])#se incrementa la variable acum
                    mx=acum #como es la posicion maxima, a max se le asigna acum
                    ra=[lines[1],num]#registro de activacion en donde se guarda el nombre y su valor munerico
                    mystack.apilar(ra) #se apila en mystack
                    if len(lra)!=0:#si ya existen registros de activacion
                        enc=False
                        for j in range(0,len(lra)):#metodo de busqueda de registros de activacion en la lista lra
                            if lra[j][0]==ra[0]: #si se encuentra el registro de activacion en la lista
                                lra[j][1]+=ra[1] #se suma su valor mas lo que tiene la lista ra
                                enc=True
                        if enc==False:#si no se encontro, se asigna a la lista
                           lra.append(ra)
                    else:#si la lista esta vacia
                        lra.append(ra)
                    ra=[lines[1],num,actual,libre]#registro que se almacenara en las listas de asignaciones lpush
                    lpush.append(ra)#se inserta en lpush
                else:#si hay espacio para insertar el elemento en la pila
                    libre=libre+int(lines[2][1:-1])#a libre se le asigna el mismo mas el valor del registro de activacion que se va a introducir
                    acum+=int(lines[2][1:-1])#al igual que acum
                    if acum>mx:#si acum es mayor que mx
                        mx=acum #a mx se le asigma acum
                    lib.append(str(libre))#se agrega el nuevo valor de libre en lib
                    actual=libre-int(lines[2][1:-1])#se renueva el puntero actual
                    act.append(str(actual))#ahora se coloca en act
                    num=int(lines[2][1:-1])#se truncan los parentesis, y se convierte en un entero para ser guardado en una variable entera
                    ra=[lines[1],num]#registro de activacion en donde se guarda el nombre y su valor munerico
                    if len(lra)!=0:#si ya existen registros de activacion
                        enc=False
                        for j in range(0,len(lra)):#metodo de busqueda de registros de activacion en la lista lra
                            if lra[j][0]==ra[0]: #si se encuentra el registro de activacion en la lista
                                lra[j][1]+=ra[1] #se suma su valor mas lo que tiene la lista ra
                                enc=True
                        if enc==False:#si no se encontro, se asigna a la lista
                           lra.append(ra)
                    else:#si la lista esta vacia
                        lra.append(ra)
                    ra=[lines[1],num,actual,libre]#registro que se almacenara en las listas de asignaciones lpush
                    lpush.append(ra) #se inserta en lpush
                    ra=[lines[1],num]
                    mystack.apilar(ra) #se apila en mystack
                    nlin=nlin+1 #se autoincrementa el numero de lineas procesadas
            elif lines[0]=="POP": #si la primera linea es POP
                if mystack.node==[]:#si la pila esta vacia
                    print("Desbordamiento negativo linea (%d)=> instruccion POP en pila vacia"%(i+1))
                else:
                    ra=mystack.desapilar()#se desapila en mystack y el elemento desapilado se guarda en ra
                    npop=npop+1 #se autoimcrementa npop
                    libre=libre-ra[1]#a libre se le resta el valor del elemento que se acaba de sacar
                    acum-=ra[1]#a acum tambien se le resta el valor del elemento que se acaba de sacar 
                    lib.append(str(libre))#se agrega el nuevo valor de libre en lib
                    if(libre==inic):#si la pila quedo vacia
                        act.append("NULL")
                    else:#sino
                        top=len(mystack.node)-1#posicion tope de la pila
                        actual=actual-int(mystack.node[top][1]) #a actual se le resta el valor del registro que se encuentra en el tope de la pila 
                        act.append(str(actual))#se coloca el nuevo valor del puntero actual                  
                    nlin+=1 #se autoincrementa el numero de lineas procesadas
            elif lines[0]=="END":#si la linea es END
                nlin+=1 #se autoincrementa el numero de lineas procesadas
                writexml(lines,act,lib,lpush,mystack,archivo,lra,nlin,mx,npop)#se invoca la funcion de escribir en el archivo xml
                
                
#========================================================================================================================#        
                    
#--funcion para crear el archivo xml y escribir en el mismo los resultados de los archivos de texto previamente procesados--#

def writexml(lines,act,lib,lpush,mystack,archivo,lra,nlin,mx,npop):
    xmlexit= open ('PSM.xml','w')#Objeto que crea y modifica el archivo PSM.xml
    archtx="archivo_"+archivo #aqui se forma nombre de una etiqueta
    arch=principal.createElement(archtx)#se crea la etiqueta arch
    lin=principal.createElement("lineas")#se crea la etiqueta lineas
    nl=principal.createTextNode(str(nlin))#se crea el texto de una etiqueta, pasando como argumento nlin en cadena
    pila=principal.createElement("pila")#se crea la etiqueta pila
    Lib=principal.createElement("libre")#se crea la etiqueta libre
    val=principal.createElement("valor")#se crea la etiqueta valor
    valtx=principal.createTextNode(str(lib[len(lib)-1]))#se crea el texto de una etiqueta, pasando como argumento el ultimo valor de la lista lib
    sec=principal.createElement("secuencia")#se crea la etiqueta secuencia
    Act=principal.createElement("actual")#se crea la etiqueta actual
    principal.lastChild.appendChild(arch)#se agrega la etiqueta archivo como hija de PSM
    arch.appendChild(lin)#se agrega la etiqueta lineas como hija de archivo
    lin.appendChild(nl)#se agrega el texto como hijo de lineas
    arch.appendChild(pila)#se agrega la etiqueta pila como hija de archivo
    pila.appendChild(Lib)#se agrega la etiqueta libre como hija de pila
    Lib.appendChild(val)#se agrega la etiqueta valor como hija de libre
    val.appendChild(valtx)#se agrega valtx como hija de valor
    Lib.appendChild(sec)#se agrega la etiqueta secuencia como hija de libre
    cadlib=""
    for j in range (0,len(lib)):#iteracion para concatenar todo el contenido de la lista lib en cadlib
        if j==0:
            cadlib=lib[j]
        else:
            cadlib=cadlib+"-"+lib[j]
    sectx=principal.createTextNode(cadlib)#se crea un nodo de texto, pasando como argumento cadlib
    sec.appendChild(sectx)#se agrega sectx como hija de secuencia
    pila.appendChild(Act)##se agrega la etiqueta actual como hija de pila
    val=principal.createElement("valor")#se crea la etiqueta valor
    Act.appendChild(val)#se agrega la etiqueta valor como hija de actual
    valtx=principal.createTextNode(str(act[len(act)-1]))#se crea un nodo de texto, pasando como argumento,el contenido la ultima posicion de la listaact
    val.appendChild(valtx)#se agrega valtx como hija de valor
    sec=principal.createElement("secuencia")#se crea la etiqueta secuencia
    Act.appendChild(sec)#se agrega la etiqueta secuencia como hija de actual
    cadact=""
    for j in range (0,len(act)):#iteracion para concatenar todo el contenido de la lista lib en una cadena
        if j==0:
            cadact=act[j]
        else:
            cadact=cadact+"-"+act[j]
    sectx=principal.createTextNode(cadact)#se crea un nodo de texto, pasando como argumento cadact
    sec.appendChild(sectx)#se agrega sectx como hija de secuencia
    Fin=principal.createElement("final")#se crea la etiqueta final
    pila.appendChild(Fin)#se agrega final como hija de pila
    cadfin=""
    if mystack.node==[]:#si la pila quedo vacia
        cadfin="EMPTY"
    else:#si no
        j=0
        auxstack=Mystack()#pila auxiliar
        while mystack.node!=[]:#esto es para desapilar mystack y apilar en auxstack
            ra=mystack.desapilar()
        while auxstack.node!=[]:#aqui se desapila auxstack
            ra=auxstack.desapilar()
            cadnum=str(ra[1])#se convierte en cadena el valor del registro que se acaba de extraer en auxstack
            if j==0:#para concatenar la secuencia de los elementos que quedaron en la pila al terminar la ejecucuion que se va a guardar en cadfin
                cadfin=ra[0]+"("+cadnum+")"
            else:
                cadfin=cadfin+"-"+ra[0]+"("+cadnum+")"
            j+=1
    txtfn=principal.createTextNode(cadfin)#se crea el nodo de texto pasando por parametro cadfin
    Fin.appendChild(txtfn)#se agrega el nodo de texto como hijo de final
    Max=principal.createElement("max")#se crea la etiqueta max
    pila.appendChild(Max)#se agrega max como hija de pila
    mxtx=principal.createTextNode(str(mx))#se crea un nodo de texto con la vaiable mx convertida en cadena
    Max.appendChild(mxtx)#se agrega el nodo de texto como hijo de max
    Asign=principal.createElement("asignaciones")#se crea la etiqueta asignaciones
    pila.appendChild(Asign)#se agrega asignaciones como hija de pila
    if lpush==[]:#si no se pudo introducir ningun registro de activacion en la pila
        asgtxt=principal.createTextNode("NO SE INTRODUJO NINGUN REGISTRO DE ACTIVACION EN LA PILA")
        Asign.appendChild(asgtxt)#En la etiqueta asignaciones se le coloca: "NO SE INTRODUJO NINGUN REGISTRO DE ACTIVACION EN LA PILA"
    else:#si no
        for j in range(0,len(lpush)):#se recorre la lista
            k=j+1
            cadnum=str(k)
            nr=principal.createElement("_"+cadnum+"_")#se crea la etiqueta nr
            Asign.appendChild(nr)#se agrega la etiqueta nr como hija de asignaciones
            cadact=str(lpush[j][2])#posicion inicial de un elemento de lpush
            cadlib=str(lpush[j][3]-1)#posicion final de un elemento de lpush
            cadtot=lpush[j][0]+"("+cadact+"-"+cadlib+")"#aqui se va concatenando en cadtot un registro de activacion con su posicion inicial y su posicion final
            asgtxt=principal.createTextNode(cadtot)#Se crea el nodo de texto pasando de argumento cadtot
            nr.appendChild(asgtxt)#Se agrega el nodo de texto como hijo de nr
    RAs=principal.createElement("RAs")#se crea la etiqueta RAs
    arch.appendChild(RAs)#se agrega la etiqueta RAs como hija de archivo
    if lpush==[]:#si no se pudo introducir ningun registro de activacion en la pila
        asgtxt=principal.createTextNode("NO SE INTRODUJO NINGUN REGISTRO DE ACTIVACION EN LA PILA")
        Asign.appendChild(asgtxt)#En la etiqueta asignaciones se le coloca: "NO SE INTRODUJO NINGUN REGISTRO DE ACTIVACION EN LA PILA"
    else:#si no       
        for i in range (0,len(lra)):#para recorrer la lista de los registros de activacion con sus valores totales asignados de me,oria
            RA=principal.createElement(lra[i][0])#se crea la etiqueta RA el nombre del elemento arrojado por lra
            RAs.appendChild(RA)#se agrega la etiqueta RA como hija de RAs
            ratx=principal.createTextNode(str(lra[i][1]))#se crea un nodo de texto, pasando por parametro el valor numerico de ese registro de activacion, pero convertido en cadena
            RA.appendChild(ratx)#El nodo de texto se agrega como hijo de RA                    
    push=principal.createElement("total_PUSH")#se crea la etiqueta total_PUSH
    arch.appendChild(push)#se agrega la etiqueta total_PUSH como hija de archivo
    pushtx=principal.createTextNode(str(len(lpush)))#se crea un nodo de texto, con la cantidad de push realizados en la ejecucion del archivo, pero convertido en cadena
    push.appendChild(pushtx)#se agrega el pushtx como hijo de total_PUSH
    pop=principal.createElement("total_POP")#se crea la etiqueta total_POP
    arch.appendChild(pop)#se agrega la etiqueta total_POP como hija de archivo
    poptx=principal.createTextNode(str(npop))#se crea un nodo de texto, con la cantidad de pop realizados en la ejecucion del archivo, pero convertido en cadena
    pop.appendChild(poptx)#se agrega el pushtx como hijo de total_PUSH
    principal.toprettyxml()
    xmlexit.write(principal.toprettyxml())
    xmlexit.close()

#===========================================================================================================#                
                
g = XMLGenerator(sys.stdout, 'utf-8')
xmldoc = getDOMImplementation()
principal = xmldoc.createDocument('', 'PSM', '')
print("                            Archivos procesados")
for i in range(1,101):#para procesar una cantidad dada de archivos d texto
    archivo ='PSM' + str(i) +'.txt' #aqui se crea el nombre del archivo de texto que se va a interpretar, cuyo nombre se guardara en la variable "archivo"        
    files=[]
    npal=0
    extraer(archivo,files,npal)#se llama a la funcion de extraer
    if files!=[]:
        if sintax(files,archivo)==True:#si la sintaxis esta bien
            mystack=Mystack()#Lista que se comportara como una pila,en donde en cada posicion contendra otra lista que se guardara el nombre el registro de activacion y su valor
            exe(files,archivo,mystack)
            print("Archivo procesado con exito")
