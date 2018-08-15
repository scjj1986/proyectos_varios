uses crt;
type

rutas= array [1..8,1..2] of string;
tarifas= array [1..8,1..4] of real;
pasajero= record
     nombre,apellido,ci_pas,tipo,correo,tlf,solo,ruta,itin:string;
     edad:integer;
     tarifa,eu,yn,ak,otr_rec,total:real;
end;
var
pas:pasajero;
//pasaj: file of pasajero;
rut:rutas;
tar:tarifas;
salir:boolean;
opcion,opcion2,edad: string;
opc,opc2,err:integer;

procedure inicializar_rutas; //procedimiento para almacenar todas las rutas que ofrecerá la aerolínea, dicha data se guardará en el arreglo 'rut'
begin
     rut[1][1]:='PORLAMAR'; rut[1][2]:='CARACAS';
     rut[2][1]:='CARACAS'; rut[2][2]:='PORLAMAR';
     rut[3][1]:='CARACAS'; rut[3][2]:='EL VIGIA';
     rut[4][1]:='EL VIGIA'; rut[4][2]:='CARACAS';
     rut[5][1]:='PORLAMAR'; rut[1][2]:='VALENCIA';
     rut[6][1]:='VALENCIA'; rut[6][2]:='PORLAMAR';
     rut[7][1]:='CARACAS'; rut[7][2]:='ARUBA';
     rut[8][1]:='ARUBA'; rut[8][2]:='CARACAS';

end;

procedure inicializar_tarifas; //procedimiento para almacenar todas las tarifas correspondiente a cada ruta que ofrecerá la aerolínea, dicha informacion se guardará en el arreglo 'tar'
(*
Ejemplo: las tarifas de la fila 2 del arreglo 'tar', corresponderá a los datos guardados en la fila 2 del arreglo 'rut', es decir, que esas tarifas corresponde a la ruta "CARACAS-PORLAMAR"
*)

begin
    tar[1][1]:=371.52; tar[1][2]:=125.76; tar[1][3]:=185.76; tar[1][4]:=270.00;
    tar[2][1]:=401.24; tar[2][2]:=132.41; tar[2][3]:=200.62; tar[2][4]:=292.50;
    tar[3][1]:=438.56; tar[3][2]:=144.72; tar[3][3]:=218.59; tar[3][4]:=318.69;
    tar[4][1]:=468.28; tar[4][2]:=154.53; tar[4][3]:=233.41; tar[4][4]:=340.30;
    tar[5][1]:=315.25; tar[5][2]:=104.03; tar[5][3]:=157.13; tar[5][4]:=229.09;
    tar[6][1]:=344.97; tar[6][2]:=113.84; tar[6][3]:=171.95; tar[6][4]:=250.70;
    tar[7][1]:=715.95; tar[7][2]:=375.95; tar[7][3]:=357.98; tar[7][4]:=000.00;
    tar[8][1]:=742.87; tar[8][2]:=390.08; tar[8][3]:=371.43; tar[8][4]:=000.00;
end;

(*function ced_pas_rep (cedula:string): boolean;
var
   encontrado:boolean;
begin
   assign (pasaj,'pasajeros.dat');
   reset (pasaj);//Se abre y se coloca en el primer registro dicho archivo
   encontrado:=false;//se inicializa con falso antes de empezar la búsqueda
   while not (EOF(pasaj)) do //Se recorre todos los registros
   begin
       read(pasaj,lin_pas);//Se lee el registro actual
       if lin_pas.ci_pas=cedula then //si el campo 'cedula' del registro actual, coincide con la variable pasada por parámetro...
       begin
          encontrado:=true; //se le asigna verdadero
       end;
   end;
   close (pasaj); //Se cierra el archivo
   ced_pas_rep:=encontrado;//lo que tenga la variable 'encontrado', se le asigna a la función
end;*)
procedure datos_personales;
begin
    writeln ('Tipo de Pasajero: ');
    writeln ('1) Regular');
    writeln ('2) Tercera Edad');
    writeln ('3) Menor de Edad');
    writeln ('4) Estudiante');
    readln (opcion2);
    while (opcion2<>'1') and (opcion2<>'2') and (opcion2<>'3') and (opcion2<>'4') do
    begin
         writeln ('Opcion incorrecta. Ingrese nuevamente dicho valor.');
         readln (opcion2);
    end;
    val (opcion2,opc2,err);
    writeln ('Ingrese edad: ');
    readln (edad);
    val (edad,pas.edad,err);
    while ( (opcion2='1') and ( (err<>0) or (pas.edad<18) or (pas.edad>59) ) )  do
    begin
         writeln ('Para el pasajero Regular, la edad debe ser un valor numerico que oscile entre 18 y 59. Ingrese nuevamente la edad: ');
         readln (edad);
         val (edad,pas.edad,err);
    end;
    while ( (opcion2='2') and ( (err<>0) or (pas.edad<60) ) )  do
    begin
         writeln ('Para el pasajero de la Tercera Edad, la edad debe ser un valor numerico mayor o igual a 60. Ingrese nuevamente la edad: ');
         readln (edad);
         val (edad,pas.edad,err);
    end;
    while ( (opcion2='3') and ( (err<>0) or (pas.edad<3) or (pas.edad>18) ) )  do
    begin
         writeln ('Para el pasajero Menor de Edad, la edad debe ser un valor numerico que oscile entre 3 y 17. Ingrese nuevamente la edad: ');
         readln (edad);
         val (edad,pas.edad,err);
    end;
    while ( (opcion2='4') and ( (err<>0) or (pas.edad<18) or (pas.edad>24) ) )  do
    begin
         writeln ('Para el pasajero  de tipo Estudiante, la edad debe ser un valor numerico que oscile entre 18 y 24. Ingrese nuevamente la edad: ');
         readln (edad);
         val (edad,pas.edad,err);
    end;
    writeln ('Ingrese Cedula o pasaporte: ');
    readln (pas.ci_pas);
    writeln ('Nombre:');
    readln (pas.nombre);
    writeln ('Apellido');
    readln (pas.apellido);
    writeln ('Telefono:');
    readln (pas.tlf);
    writeln ('E-Mail:');
    readln (pas.correo);
    if (opcion2='1') then
    begin
         pas.tipo:='REGULAR';
    end
    else if (opcion2<>'2') then
    begin
         pas.tipo:='TERCERA EDAD';
    end
    else if (opcion2='3') then
    begin
         pas.tipo:='MENOR DE EDAD';
         writeln ('Viene solo? s/n.');
         readln (pas.solo);
         while (pas.solo<>'s') and (pas.solo<>'S') and (pas.solo<>'n') and (pas.solo<>'N') do
         begin
              writeln ('Opcion incorrecta. Ingrese nuevamente dicho valor');
              readln (pas.solo);
         end;
    end
    else
    begin
        pas.tipo:='ESTUDIANTE';
    end;
end;

procedure reservar;
begin
    pas.tarifa:=000.00;
    pas.eu:=000.00;
    pas.ak:=000.00;
    pas.yn:=000.00;
    pas.otr_rec:=000.00;
    datos_personales;
    writeln ('Seleccione el tipo de itinerario: ');
    writeln ('1) Ida');
    writeln ('2) Ida y Vuelta');
    writeln ('3) Multiples Destinos');
    readln (opcion);
    while (opcion<>'1') and (opcion<>'2') and (opcion<>'3') do
    begin
         writeln ('Opcion incorrecta. Ingrese nuevamente dicho valor.');
         readln (opcion);
    end;
    val (opcion,opc,err);
    if (opc=1) then
    begin
       pas.itin:='IDA';
       writeln ('Elija el destino: ');
       writeln ('1) PORLAMAR-CARACAS');
       writeln ('2) CARACAS-PORLAMAR');
       writeln ('3) CARACAS-EL VIGIA');
       writeln ('4) EL VIGIA-CARACAS');
       writeln ('5) PORLAMAR-VALENCIA');
       writeln ('6) VALENCIA-PORLAMAR');
       writeln ('7) CARACAS-ARUBA');
       writeln ('8) ARUBA-CARACAS');
       readln (opcion2);
       while (opcion2<>'1') and (opcion2<>'2') and (opcion2<>'3') and (opcion2<>'4') and (opcion2<>'5') and (opcion2<>'6') and (opcion2<>'7') and (opcion2<>'8') do
       begin
            writeln ('Opcion incorrecta. Ingrese nuevamente dicho valor.');
            readln (opcion2);
       end;
       val (opcion2,opc,err);
       writeln (opc);
       pas.ruta:=rut[opc][1]+'-'+rut[opc][2];
       pas.tarifa:=tar[opc][opc2];
       pas.eu:=tar[opc][opc2]/100;
       if (pas.solo='s') or (pas.solo='S') then
       begin
           pas.otr_rec:=tar[opc][opc2]/4;
       end;
       if (opcion2<>'1') and (opcion2<>'5') then
       begin
           pas.yn:=pas.tarifa*8/100;
       end;
       if (opcion2<>'8') and (opcion2<>'7') then  //Si se eligió ruta nacional
       begin
           if (opcion2='1') or (opcion2='2') or (opcion2='3') or (opcion2='4') then
           begin
                pas.ak:=45.00;
           end;

       end
       else
       begin

            pas.ak:=225.00;
       end;
    end;
    writeln ('Cotizacion:');
    writeln();
    writeln('1)Datos Personales del Pasajero:');
    writeln('  *Tipo: ',pas.tipo);
    writeln('  *Nombre: ',pas.nombre);
    writeln('  *Apellido: ',pas.apellido);
    writeln('  *Edad: ',pas.edad);
    writeln('  *E-mail: ',pas.correo);
    writeln('  *Telefono: ',pas.tlf);
    writeln();
    writeln('2)Datos del Viaje:');
    writeln('  *Tipo de Itinerario: ',pas.itin);
    writeln('  *Ruta: ',pas.ruta);
    writeln();
    writeln('3)Tarifa e impuestos:');
    writeln('  *Costo de la Ruta: ',pas.tarifa:3:2, ' Bs.');
    writeln('  *Impuesto Turistico "EU" (1% del costo de la ruta): ',pas.eu:3:2, ' Bs.');
    writeln('  *Impuesto al Valor Agregado "YN" (8% del costo de la ruta en caso ): ',pas.yn:3:2, ' Bs.');
    writeln('  *Tasa de Salida Aeroportuaria "AK" : ',pas.ak:3:2, ' Bs.');
    writeln('  *Otros Recargos (Para menores de edad que viajan solos) : ',pas.otr_rec:3:2, ' Bs.');
    pas.total:=pas.tarifa+pas.eu+pas.yn+pas.ak+pas.otr_rec;
    writeln('  *Total a Cancelar: ',pas.total:3:2, ' Bs.');
    writeln();


end;

begin
   //crear_archivo;
   writeln('-------->> CRIOLLISIMA AIRLINES (Aerolinea Regional de Bajo Costo) <<----------');
   salir:=false;
   inicializar_rutas;
   inicializar_tarifas;
   while (NOT salir) do
   begin
       writeln ('Opciones:');
       writeln ('1) Reservar');
       writeln ('2) Salir del programa');
       readln (opcion);
       while (opcion<>'1') and (opcion<>'2') do
       begin
           writeln ('Opcion incorrecta. Ingrese nuevamente dicho valor.');
           readln (opcion);
       end;
       val (opcion,opc,err);
       case opc of
            1: reservar;
       end;

   end;

end.
