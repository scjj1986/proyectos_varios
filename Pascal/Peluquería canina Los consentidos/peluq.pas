uses crt;
type
    can= record//registro que almacenar� cada mascota que se atienda al d�a
         cedula_amo: integer;//variable entera que referencia la cedula del due�o de la mascota
         nombre_mascota,raza_mascota: string; //variables tipo string que referencian nombre y raza de la mascota respectivamente
         shower,haircut,nails: boolean; //variables booleanas que dan referencia al ba�ado, corte de pelo y arreglo de u�as respectivamente
         total: integer; //variable entera referente al total a pagar dependiendo de los tratamientos que se le preste a la mascota
     end;
     clientes= array [1..5] of can;//arreglo de registro "can"
var
cli: clientes;
num,numero,err,i:integer;
cadena:string;
procedure atender; //procedimiento para atender a las mascotas en el dia
begin
    writeln('Ingrese la cantidad de mascotas a atender:');
    readln (cadena);//Se pide y lee la cantidad de mascotas que van a atender
    val (cadena, num, err); //se convierte a entero el valor reci�n ingresado
    while (err<>0) or (num<1) or (num>5) do
    begin;
         writeln('Error. El valor debe ser numerico entre 1 y 5. Ingrese nuevamente la cantidad de mascotas a atender:');
         readln (cadena);//Se pide y lee la cantidad de mascotas que van a atender
         val (cadena, num, err); //se convierte a entero el valor reci�n ingresado
    end;
    clrscr;
    for i:=1 to num do //se atienden las mascotan una por una a trav�s de un ciclo repetitivo
    begin
       writeln ('*Cliente n� ',i);
       writeln ();
       writeln (' Cedula del due�o: ');
       readln (cadena);//Se pide y lee la cedula del due�o
       val (cadena, numero, err); //se convierte a entero el valor reci�n ingresado
       while (err<>0) do
       begin;
         writeln(' Error. El valor debe ser numerico. Ingrese nuevamente dicho valor:');
         readln (cadena);//Se pide y lee la cedula del due�o
         val (cadena, num, err); //se convierte a entero el valor reci�n ingresado
       end;
       cli[i].cedula_amo:=numero;//se guarda el valor de la c�dula del due�o en el registro
       writeln (' Nombre de la mascota:');
       readln (cli[i].nombre_mascota);
       writeln (' Raza de la mascota:');
       readln (cli[i].raza_mascota); //se piden y se guardan el nombre y la raza de la mascota en sus respectivos campos del registro
       cli[i].total:=0;
       writeln (' Desea que a su mascota le realicen un ba�ado (s/n)?');
       readln (cadena); //se le pregunta al usuario si desea un ba�ado para su mascota
       while (cadena<>'s') and (cadena<>'S') and (cadena<>'n') and (cadena<>'N') do //validaci�n de opci�n
       begin
           writeln (' Opcion incorrecta. Ingrese nuevamente dicha opcion: ');
           readln (cadena);
       end;
       if (cadena='s') or (cadena='S') then  //si dijo que si
       begin
          cli[i].shower:=true;  //al campo shower, se le asigna verdadero
          cli[i].total:=cli[i].total+50;  //y se le suma al total a cancelar la tarifa del ba�ado
       end
       else
       begin
           cli[i].shower:=false; //si dijo que no, se le asigna falso a shower
       end;
       writeln (' Desea que a su mascota le realicen un corte de pelo (s/n)?'); //se le pregunta al usuario si desea un corte de pelo para su mascota
       readln (cadena);
       while (cadena<>'s') and (cadena<>'S') and (cadena<>'n') and (cadena<>'N') do //validaci�n de opci�n
       begin
           writeln (' Opcion incorrecta. Ingrese nuevamente dicha opcion: ');
           readln (cadena);
       end;
       if (cadena='s') or (cadena='S') then  //si dijo que si
       begin
          cli[i].haircut:=true; //al campo haircut, se le asigna verdadero
          cli[i].total:=cli[i].total+100; //y se le suma al total a cancelar la tarifa del corte de pelo
       end
       else
       begin
           cli[i].haircut:=false;  //si dijo que no, se le asigna falso a haircut
       end;
       writeln (' Desea que a su mascota le realicen un arreglo de u�as (s/n)?'); //se le pregunta al usuario si desea un arreglo de u�as para su mascota
       readln (cadena);
       while (cadena<>'s') and (cadena<>'S') and (cadena<>'n') and (cadena<>'N') do  //validaci�n de opci�n
       begin
           writeln (' Opcion incorrecta. Ingrese nuevamente dicha opcion: ');
           readln (cadena);
       end;
       if (cadena='s') or (cadena='S') then   //si dijo que si
       begin
          cli[i].nails:=true;  //al campo nails, se le asigna verdadero
          cli[i].total:=cli[i].total+80; //y se le suma al total a cancelar la tarifa del arreglo de u�as
       end
       else
       begin
           cli[i].nails:=false; //si dijo que no, se le asigna falso a nails
       end;
       writeln ('Total a cancelar: ',cli[i].total);
       writeln ('Presione Enter para continuar:');
       readln ();
       clrscr;
    end;
end;

procedure tratamientos; //procedimiento para calcular cu�tos tratamientos se han aplicado al dia
var
   shower,haircut,nails:integer;//contadores de los tratamientos de ba�ado, corte de pelo y arreglo de u�as
begin
     shower:=0;
     haircut:=0;
     nails:=0;//se inicializan las variables
     for i:=1 to num do //se recorre el arreglo de registro hasta la cantidad de atendidos
     begin
         if cli[i].shower=true then //si se le ha aplicado un ba�ado a la mascota en turno
         begin
             shower:=shower+1; //si incrementa en uno el contador de ba�ados
         end;
         if cli[i].haircut=true then  //si se le ha aplicado un corte de pelo a la mascota en turno
         begin
             haircut:=haircut+1; //si incrementa en uno el contador de cortes de pelo
         end;
         if cli[i].nails=true then //si se le ha aplicado un arreglo de u�as a la mascota en turno
         begin
             nails:=nails+1; //si incrementa en uno el contador de arreglo de u�as
         end;
     end;
     //se muestra por pantalla el total de cada tratamiento
     writeln('*Cantidad de ba�ados: ',shower);
     writeln('*Cantidad de cortes de pelo: ',haircut);
     writeln('*Cantidad de arreglos de u�as: ',nails);
end;

function total: integer; //funci�n entera qeu arroja el total generado en el d�a
var
   aux:integer; //variable entera que ayuda a calcular el total
begin
    aux:=0;  //se incializa la variable
    for i:=1 to num do //se recorre los registros que contienen las mascotas atendidas
    begin
        aux:=aux+cli[i].total; //el total a cancelar de cada registro, lo va acumulando la variable aux
    end;
    total:=aux; //y el valor definitivo de aux, lo asigna a la funci�n
end;
procedure listado; //procedimiento para imprimir por pantalla el listado de las mascotas atendida en el dia
var
   aux:integer;
begin
    writeln ('Listado de atendidos en el dia. ');
    for i:=1 to num do //se recorre el registro en donde est�n almacenada la data de las mascotas
    begin
        writeln();
        writeln ('*Cliente nr. ',i);
        writeln (' Cedula del due�o: ',cli[i].cedula_amo);
        writeln (' Nombre mascota: ',cli[i].nombre_mascota);
        writeln (' Raza mascota: ',cli[i].raza_mascota);
        writeln (' -Tratamientos:');
        aux:=0;
        if cli[i].shower=true then
        begin
            writeln ('  Ba�ado: 50 Bs.');
            aux:=aux+50;
        end;
        if cli[i].haircut=true then
        begin
            writeln ('  Corte de pelo: 100 Bs.');
            aux:=aux+100;
        end;
        if cli[i].nails=true then
        begin
            writeln ('  Arreglo de u�as: 80 Bs.');
            aux:=aux+80;
        end;
        writeln ();
        writeln (' Total cancelado: ', aux,' Bs.');
        writeln ();
    end;
end;
begin  //algoritmo principal
   writeln ('Bienvenidos a la peluqueria canina "Los Consentidos"');
   writeln();
   atender;
   writeln ('A continuacion, se mostrara la cantidad de tratamientos realizados en el dia. Presione Enter para visualizar dicho reporte:');
   readln();
   clrscr;
   tratamientos;
   writeln();
   writeln ('A continuacion, se mostrara el total generado en el dia. Presione Enter para visualizar dicho reporte:');
   readln();
   clrscr;
   writeln ('Total generado en el dia: ',total,' Bs.');
   writeln();
   writeln ('A continuacion, se mostrara el listado de las mascotas atendidas en el dia. Presione Enter para visualizar dicho reporte:');
   readln();
   clrscr;
   listado;
   writeln ('presione Enter para salir de la aplicacion');
   readln();
end.
