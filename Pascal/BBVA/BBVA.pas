uses crt;
type
    provinet=record//registro que almacenar� cada empleado
        cedula,servicio:integer;
        nombre,sucursal,cargo:string;
        sueldo:real;
    end;
    provincial=array[1..100] of provinet;//arreglo de registro, que guarda m�ximo 100 empleados
var
bbva:provincial;//declaraci�n del arreglo de registros
i,j,numero,error:integer;
cadena:string;
decim:real;
salir,validar:boolean;
function repetido:boolean;//funci�n booleana para validar que la cedula en la inserci�n de un empleado, no est� repetida
var
   encontrado:boolean;
begin
    encontrado:=false;//le asignamos a encontrado false por defecto, antes de iniciar la b�squeda
    for i:=1 to 100 do//empezamos la b�squeda, recorriendo todo el arreglo
    begin
        if numero=bbva[i].cedula then//si hubo coincidencia...
        begin
            encontrado:=true;//..a encontrado le asignamos true
        end;
    end;
    repetido:=encontrado;//por �ltimo a la funci�n le asignamos el valor de encontrado
end;
procedure ingresar_empleado;//procedimiento para ingresar un empleado
begin

    clrscr;
    writeln('Ingrese cedula:');//se pide c�dula
    readln(cadena);
    val (cadena,numero,error);//se convierte a entero
    validar:=false;
    while not validar do//fragmento de c�digo para validar la c�dula (num�rica e irrepetible en el arreglo)
    begin
        while error<>0 do//mientras que no sea num�rica
        begin
            writeln('El valor debe ser numerico. Ingrese nuevamente la cedula:');
            readln(cadena);
            val (cadena,numero,error);
        end;
        validar:=true;
        if (repetido) or (numero=0) then//ahora si est� repetida
        begin
            writeln('El valor debe ser irrepetible y mayor que cero. Ingrese nuevamente la cedula:');
            readln(cadena);
            val (cadena,numero,error);
            validar:=false;//Se vuelve a pedir la c�dula y a validar se le asigna false, para otra iteraci�n
        end;
    end;
    i:=1;
    while i<=100 do//Ciclo iterativo para verificar en que posici�n del arreglo vamos a guardar el nuevo registro
    begin
        if bbva[i].cedula=0 then//por defecto el valor de la cedula es 0, lo que implica que est� disponible esa posici�n
        begin
            j:=i;//se gusrda esa posici�n en j
            i:=101;
        end;
        i:=i+1;
    end;
    bbva[j].cedula:=numero;
    writeln('Nombre del empleado');//nombre del empleado
    readln(bbva[j].nombre);
    writeln ('Sucursal en donde trabaja: ');//sucursal en donde trabaja con las opciones
    writeln();
    writeln ('1) Si trabaja en Santiago Mari�o');
    writeln ('2) Si trabaja en la Av. 4 de Mayo');
    writeln ('3) Si trabaja en Sambil Margarita');
    writeln ('4) Si trabaja en Paraguachi');
    readln(cadena);
    while (cadena<>'1') and (cadena<>'2') and (cadena<>'3') and (cadena<>'4') do//ciclo para validar opcion correcta
    begin
         writeln ('Opcion incorrecta. Ingrese nuevamente dicho valor');
         readln(cadena);
    end;
    //Dependiendo de la opci�n que haya elegido, se le asigna la sucursal
    if cadena='1' then
    begin
       bbva[j].sucursal:='SANTIAGO MARI�O';
    end
    else if cadena='2' then
    begin
       bbva[j].sucursal:='AV. 4 DE MAYO';
    end
    else if cadena='3' then
    begin
       bbva[j].sucursal:='SAMBIL MARGARITA';
    end
    else
    begin
       bbva[j].sucursal:='PARAGUACHI';
    end;
    writeln ('A�os de servicio en la empresa:');//a�os de servicio
    readln(cadena);
    val(cadena,numero,error);
    while error<>0 do//mientras que no sea num�rico el valor
    begin
         writeln('El valor debe ser numerico. Ingrese nuevamente el valor:');
         readln(cadena);
         val (cadena,numero,error);
    end;
    bbva[j].servicio:=numero;
    writeln('Sueldo (Bs.):');
    readln(cadena);
    val (cadena,decim,error);
    while error<>0 do//mientras que no sea num�rico
    begin
         writeln('El valor debe ser numerico. Ingrese nuevamente el valor:');
         readln(cadena);
         val (cadena,decim,error);
    end;
    bbva[j].sueldo:=decim;
    writeln('Cargo que desempe�a actualmente:');
    readln(bbva[j].cargo);
end;
procedure buscar_empleado;//procedimiento para buscar un empleado en especifico
var
   encontrado:boolean;
begin
    clrscr;
    writeln('Cedula del empleado:');//se pide la cedula y luego se valida de que sea num�rica
    readln(cadena);
    val (cadena,numero,error);
    while (error<>0) and (numero=0) do
    begin
        writeln('La c�dula debe ser numerica y mayor que 0. Ingrese nuevamente dicho valor:');
        readln(cadena);
        val (cadena,numero,error);
    end;
    encontrado:=false;
    for i:=1 to 100 do //se recorre todo el arreglo
    begin
        if bbva[i].cedula=numero then//si se encontr�, se muestra los datos y a la variable encontrado, se le asigna true, como constancia que hubo coincidencia
        begin
            encontrado:=true;
            writeln('Datos coincidentes con la cedula "',numero,'"');
            writeln('*Nombre: ',bbva[i].nombre);
            writeln('*Cargo: ',bbva[i].cargo);
            writeln('*Sucursal en donde trabaja: ',bbva[i].sucursal);
            writeln('*A�os de servicio: ',bbva[i].servicio);
            writeln('*Sueldo (Bs.): ',bbva[i].sueldo:3:2);
        end;
    end;
    if not encontrado then//si no se encontr� coincidencia, se env�a un mensaje
    begin
        writeln('La cedula ingresada no se encuentra en la base de datos');
    end;
end;

procedure eliminar_empleado; //procedimiento para eliminar un empleado en espec�fico
var
   encontrado:boolean;
begin
    clrscr;
    writeln('Cedula del empleado:');//se pide la c�dula y se valida que sea num�rica
    readln(cadena);
    val (cadena,numero,error);
    while (error<>0) and (numero=0) do
    begin
        writeln('La c�dula debe ser numerica y mayor que 0. Ingrese nuevamente dicho valor:');
        readln(cadena);
        val (cadena,numero,error);
    end;
    encontrado:=false;
    for i:=1 to 100 do //se recorre el arreglo
    begin
        if bbva[i].cedula=numero then//si se encuentra, lo que se hace es inicializar ese registro ese registro, dado que no se puede eliminar l�gicamente ese registro
        begin
            encontrado:=true;
            bbva[i].cedula:=0;
            bbva[i].nombre:='';
            bbva[i].cargo:='';
            bbva[i].sucursal:='';
            bbva[i].servicio:=0;
            bbva[i].sueldo:=000.00;
            writeln('Proceso de eliminacion exitoso');
        end;
    end;
    if not encontrado then //si no hubo coincidencia
    begin
        writeln('La cedula ingresada no se encuentra en la base de datos');
    end;
end;

procedure mayor;//procedimiento para calcular la sucursal que m�s paga a sus empleados
var
san_mar,_4demay,sambil,paragua,num:real;
mayor:string;
begin
    clrscr;
    num:=0.00;
    san_mar:=0.00;
    _4demay:=0.00;
    sambil:=0.00;
    paragua:=0.00;
    mayor:='';
    for i:=1 to 100 do//se recorre el arreglo
    begin
        if bbva[i].cedula<>0 then//si esa posici�n, hay un empleado registrado
        begin
            //Dependiendo de la sucursal a la que pertenezca, se le suma el sueldo
            if bbva[i].sucursal='PARAGUACHI' then
            begin
                 paragua:=paragua+bbva[i].sueldo;
            end
            else if bbva[i].sucursal='SAMBIL MARGARITA' then
            begin
                 sambil:=sambil+bbva[i].sueldo;
            end
            else if bbva[i].sucursal='AV. 4 DE MAYO' then
            begin
                 _4demay:=_4demay+bbva[i].sueldo;
            end
            else
            begin
                 san_mar:=san_mar+bbva[i].sueldo;
            end;
            //dependiendo de cual sea la sucursal que pague m�s, se le asigna mayor, el nombre de dicha sucursal
            if san_mar>num then
            begin
                 num:=san_mar;
                 mayor:='SANTIAGO MARINO';
            end
            else if sambil>num then
            begin
                 num:=sambil;
                 mayor:='SAMBIL';
            end
            else if _4demay>num then
            begin
                 num:=_4demay;
                 mayor:='AV. 4 DE MAYO';
            end
            else if paragua>num then
            begin
                 num:=paragua;
                 mayor:='PARAGUACHI';
            end;

        end;
    end;
    if (num>0.00) then
    begin
         writeln('La sucursal del BBVA que interviene mas en los pagos de sus empleados, es la que se ubica en "',mayor,'" con un total de ',num:3:2,' Bs.');
    end
    else
    begin
         writeln('No hay empleados registrados en la base de datos');
    end;
end;

begin
   writeln('-------->> B.B.V.A. Banco Provincial (Adelante) <<----------');
   salir:=false;
   while (NOT salir) do//iteraci�n
   begin
       writeln ('Opciones:');
       writeln ('1) Insertar un empleado');
       writeln ('2) Determinar la sucursal que interviene en el pago de sueldos de sus empleados');
       writeln ('3) Buscar un empleado en especifico');
       writeln('4) Eliminar un empleado en especifico');
       readln (cadena);
       while (cadena<>'1') and (cadena<>'2') and (cadena<>'3') and (cadena<>'4') do
       begin
           writeln ('Opcion incorrecta. Ingrese nuevamente dicho valor.');
           readln (cadena);
       end;
       val (cadena,numero,error);
       case numero of
            1: ingresar_empleado;
            2: mayor;
            3: buscar_empleado;
            4: eliminar_empleado;
       end;
       writeln('Desea salir de la aplicacion? s/n');//Se le pregunta al usuario, si desea salir del programa
        readln(cadena);
        while (cadena<>'s') and (cadena<>'S') and (cadena<>'n') and (cadena<>'N') do //Mientras la opci�n sea inv�lida
        begin
           writeln('Opcion invalida, ingrese la opcion correcta.');
           readln(cadena);
        end;
        if (cadena='s') or (cadena='S') then //Si el usuario quiere salir...
        begin
           salir:=TRUE;// A la variable salir se le asigna verdadero para que pueda salir de la iteraci�n
        end;
        clrscr;
   end;
end.
