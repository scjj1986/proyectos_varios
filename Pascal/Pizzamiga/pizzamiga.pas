program pizzamiga;

uses crt;

type

    fecha= array [1..3] of integer; //arreglo para manejar fechas
    hora= array [1..2] of integer;  //arreglo para el manejo de hora
    minutos_loc=array[1..3] of integer;  // arreglo para el manejo de los minutos de la localidad

    solicitud = record  //Registro para los pedidos
        num,desc,monto,monto_ini: integer;
        fecha_solic:fecha;
        hora_ped: hora;
        hora_entr: hora;
        est_entr: string;
        min_entr: integer;
        nomb_loc,ced_cli:string;
    end;

    cliente = record  //Registro para los clientes
        cedula,nombre,apellido,direccion: string;
    end;

    localidad = record //Registro para las localidades
        nombre: string;
        tiempo1,tiempo2,tiempo3: integer;
    end;

var
   solic:solicitud; //variable para leer y/o grabar algún registro en el archivo 'pedidos.dat'
   solici: file of solicitud; //variable para el manejo del archivo 'redidos.dat'
   clien,lin_cli:cliente;  //variables para leer y/o grabar algún registro en el archivo 'clientes.dat'
   client: file of cliente; //variable para el manejo del archivo 'clientes.dat'
   local,lin_local:localidad; //variables para leer y/o grabar algún registro en el archivo 'localidades.dat'
   locali:file of localidad;//variable para el manejo del archivo 'localidades.dat'
   min_loc:minutos_loc; //variable del arreglo declarado 'minutos_loc' para el manejo de los minutos de cada localidad
   hoy,fch:fecha;  //variable del arreglo declarado 'fecha' para manipular las fechas
   apert,cierre: boolean; //variables booleanas que manejan la apertura y cierre de cada jornada
   opc:string; //variable que guarda la opción ingresada por el usuario en el menú principal
   num,err:integer; //variables usadas para la conversion de un valor de tipo 'string' a entero
   salir_apl:boolean; //Variable booleana para controlar cuándo culminará la aplicación

function localidad_rep(nombre:string): boolean;//funcion booleana que verifica si coinciden un valor pasado por parámetro en dicha función y algún nombre de la localidad en el archivo 'localidades.dat'

var
   encontrado:boolean;//variable para asignarle du valor a la función, una vez terminada la búsqueda en el archivo

begin
   assign (locali,'localidades.dat');
   reset (locali);//Se abre y se coloca en el primer registro dicho archivo
   encontrado:=false;//se inicializa con falso antes de empezar la búsqueda
   while not (EOF(locali)) do //Se recorre todos los registros
   begin
       read(locali,lin_local);//Se lee el registro actual
       if lin_local.nombre=nombre then //si el campo 'nombre' del registro actual, coincide con la variable pasada por parámetro...
       begin
          encontrado:=true; //se le asigna verdadero
       end;
   end;
   close (locali); //Se cierra el archivo
   localidad_rep:=encontrado;//lo que tenga la variable 'encontrado', se le asigna a la función
end;


function validar_min_loc: boolean;//función booleana que verifica si los minutos ingresados por el usuario sean númericos y mayores que 0
begin
   if (err<>0) or (num<=0) then  //si no son numéricos y menores o iguales que 0 ..
   begin
        validar_min_loc:=false; //se le asigna falso a la función...
   end
   else //, de lo contrario....
   begin
        validar_min_loc:=true; //se le asigna verdadero
   end;
end;

procedure mostrar_localidades; //procedimiento que muestra todos los registros de las localidades con sus campos correspondientes, dichos datos están guardados en 'localidades.dat'

begin
   assign (locali,'localidades.dat');
   reset (locali);//Apertura del archivo 'localidades.dat'
   writeln('Listado de las localidades registradas: ');
   writeln();
   while not (EOF(locali)) do//se recorre el archivo y se muestra cada registro del mismo con sus respectivo campos
   begin
       read(locali,lin_local);
       write();
       writeln(' *Nombre: ',lin_local.nombre);
       writeln('  Tiempo nr. 1 (min): ',lin_local.tiempo1);
       writeln('  Tiempo nr. 2 (min): ',lin_local.tiempo2);
       writeln('  Tiempo nr. 3 (min): ',lin_local.tiempo3);
       writeln();
   end;
   if ((filesize(locali))=0) then //si el archivo está vacío...
   begin
       writeln('No hay localidades registradas en el archivo');
   end;
   close (locali);//se cierra el archivo
end;

procedure modificar_loc; //Procedimiento para modificar los campos 'tiempo1','tiempo2' y 'tiempo3' en uno de los registros almacenados en el archivo 'localidades.dat'
var

   validar:boolean;
   aux_min:string;

begin

   clrscr;
   mostrar_localidades;
   assign (locali,'localidades.dat');
   reset (locali); //Se abre el archivo
   if ((filesize(locali))<>0) then //si el archivo no está vacío...
   begin
   writeln('Nombre de la localidad a modificar:'); // se solicita el nombre de la localidad a modificar
   readln(local.nombre); //se lee la misma
   while localidad_rep(local.nombre)=false do //si no existe coincidencia alguna....
   begin
        writeln('Nombre de localidad no encontrado, ingrese nuevamente dicho nombre');//...se le notifica al usuario que ingrese nuevamente el nombre de la localidad
        readln(local.nombre); //se vuelve a leer la misma
   end;
   while not (EOF(locali)) do //Se recorre el archivo
   begin
      read(locali,lin_local); //se lee el registro actual
      if lin_local.nombre=local.nombre then //si coincide el nombre ingresado....
      begin
         writeln('tiempo nr. 1 (min):'); //se solicita el tiempo 1
         readln(aux_min);//se lee el dato
         val (aux_min,local.tiempo1,err); //se convierte el dato recien ingresado a 'integer' y se guarda en la variable 'local.tiempo1'
         while validar_min_loc=false do  //Mientras el dato ingresado, no cumpla con las validaciones estipuladas en la funcion
         begin
              writeln('Error. El valor debe ser numerico mayor a 0. Ingrese nuevamente dicho valor');
              readln(aux_min);
              val (aux_min,local.tiempo1,err); //Seguirá en esta iteración hasta que la cumpla
         end;
         min_loc[1]:=local.tiempo1; //El valor recién ingresado, se le asigna a la primera posicion del arreglo 'min_loc', el cual servirá de apoyo para ordenar los minutos de menor a mayor
         writeln('tiempo nr. 2 (min):');//se solicita el tiempo 2
         readln(aux_min);//se lee el dato
         val (aux_min,local.tiempo2,err); //se convierte el dato recien ingresado a 'integer' y se guarda en la variable 'tiempo2'
         validar:=false;
         while validar=false do //iteración para manejar 2 validaciones que serán descitas seguidamente:.......
         begin
              while validar_min_loc=false do //1) validar que sea entero mayor que 0
              begin
                   writeln('Error. El valor debe ser numerico mayor a 0. Ingrese nuevamente dicho valor: ');
                   readln(aux_min);
                   val (aux_min,local.tiempo2,err);
              end;
              min_loc[2]:=local.tiempo2;//El valor recién ingresado, se le asigna a la segunda posicion del arreglo 'min_loc', el cual servirá de apoyo para ordenar los minutos de menor a mayor
              if min_loc[1]=min_loc[2] then //2)Que no sean iguales tiempo1 y tiempo2, si lo son....
              begin
                   writeln('Error. Cada tiempo asignado a una localidad, debe ser distinto a los demas. Ingrese nuevamente dicho valor: ');
                   readln(aux_min);
                   val (aux_min,local.tiempo2,err);//Se vuelve a leer el tiempo 2
              end
              else //si son distintos...
              begin
                   validar:=true; //a la variable 'validar' se le asigna 'falso' para que pueda salir de la iteración previamente descrita
              end;
         end;
         min_loc[2]:=local.tiempo2; //El valor recién ingresado, se le asigna a la segunda posicion del arreglo 'min_loc'.
         if min_loc[1]>min_loc[2] then  //Si el segundo tiempo es menor que el primero
         begin
              num:=min_loc[2];
              min_loc[2]:=min_loc[1];
              min_loc[1]:=num;
              local.tiempo1:=min_loc[1];
              local.tiempo2:=min_loc[2];//Tanto al registro 'local' como al arreglo 'min_loc', se les orrdenan los tiempos de menor a mayor
         end;
         writeln('tiempo nr. 3 (min):'); //Se pide el tiempo 3
         readln(aux_min);// se lee el dato
         val (aux_min,local.tiempo3,err);//se convierte el dato recien ingresado a 'integer' y se guarda en la variable 'tiempo3'
         validar:=false;
         while validar=false do //Para el tiempo 3 se toma en cuenta también la misma iteración aplicada al tiempo 2....
         begin
              while validar_min_loc=false do
              begin
                   writeln('Error. El valor debe ser numerico mayor a 0. Ingrese nuevamente dicho valor: ');
                   readln(aux_min);
                   val (aux_min,local.tiempo3,err);
              end;
              min_loc[3]:=local.tiempo3;
              if (min_loc[3]=min_loc[2]) or (min_loc[3]=min_loc[1])  then //..la pequeña diferencia radica en que hay que comparar adicionalmente con el tiempo2
              begin
                   writeln('Error. Cada tiempo asignado a una localidad, debe ser distinto a los demas. Ingrese nuevamente dicho valor: ');
                   readln(aux_min);
                   val (aux_min,local.tiempo3,err);
              end
              else
              begin
                   validar:=true;
              end;
         end;
         min_loc[3]:=local.tiempo3;//El valor recién ingresado, se le asigna a la tercera posicion del arreglo 'min_loc'.
         if min_loc[3]<min_loc[1] then //si el tiempo 3 es menor que el 1....
         begin
              num:=min_loc[3];
              min_loc[3]:=min_loc[2];
              min_loc[2]:=min_loc[1];
              min_loc[1]:=num;
              local.tiempo3:=min_loc[3];
              local.tiempo2:=min_loc[2];
              local.tiempo1:=min_loc[1]; //Tanto al registro 'local' como al arreglo 'min_loc', se les orrdenan los tiempos de menor a mayor
         end
         else if min_loc[3]<min_loc[2] then //si el tiempo 3 es mayor que el 1, pero menor que el 2....
         begin
              num:=min_loc[3];
              min_loc[3]:=min_loc[2];
              min_loc[2]:=num;
              local.tiempo3:=min_loc[3];
              local.tiempo2:=min_loc[2]; //Tanto al registro 'local' como al arreglo 'min_loc', se les orrdenan los tiempos de menor a mayor
         end;
         seek(locali,filepos(locali)-1); //Se coloca el puntero de los registros a la posición en donde vamos a modificar
         write(locali,local); //Se sobreescribe el registro con los datos ingresados previamente
      end;
   end;
   end;
   close (locali);//Se cierra el archivo
end;



procedure agregar_loc; //procedimiento para agregar una nueva localidad
var

   validar:boolean;
   aux_min:string;

begin
   clrscr;
   writeln('Nombre de la localidad'); // se solicita el nombre de la localidad
   readln(local.nombre); //se lee la misma
   while localidad_rep(local.nombre)=true do //si existe alguna coincidencia....
   begin
        writeln('Nombre de localidad repetido, ingrese nuevamente dicho nombre');//...se le notifica al usuario que ingrese nuevamente el nombre de la localidad
        readln(local.nombre); //se vuelve a leer la misma
   end;
   writeln('tiempo nr. 1 (min):'); //se solicita el tiempo 1
   readln(aux_min);//se lee el dato
   val (aux_min,local.tiempo1,err); //se convierte el dato recien ingresado a 'integer' y se guarda en la variable 'local.tiempo1'
   while validar_min_loc=false do  //Mientras el dato ingresado, no cumpla con las validaciones estipuladas en la funcion
   begin
        writeln('Error. El valor debe ser numerico mayor a 0. Ingrese nuevamente dicho valor');
        readln(aux_min);
        val (aux_min,local.tiempo1,err); //Seguirá en esta iteración hasta que la cumpla
   end;
   min_loc[1]:=local.tiempo1; //El valor recién ingresado, se le asigna a la primera posicion del arreglo 'min_loc', el cual servirá de apoyo para ordenar los minutos de menor a mayor
   writeln('tiempo nr. 2 (min):');//se solicita el tiempo 2
   readln(aux_min);//se lee el dato
   val (aux_min,local.tiempo2,err); //se convierte el dato recien ingresado a 'integer' y se guarda en la variable 'tiempo2'
   validar:=false;
   while validar=false do //iteración para manejar 2 validaciones que serán descitas seguidamente:.......
   begin
        while validar_min_loc=false do //1) validar que sea entero mayor que 0
        begin
             writeln('Error. El valor debe ser numerico mayor a 0. Ingrese nuevamente dicho valor: ');
             readln(aux_min);
             val (aux_min,local.tiempo2,err);
        end;
        min_loc[2]:=local.tiempo2;//El valor recién ingresado, se le asigna a la segunda posicion del arreglo 'min_loc', el cual servirá de apoyo para ordenar los minutos de menor a mayor
        if min_loc[1]=min_loc[2] then //2)Que no sean iguales tiempo1 y tiempo2, si lo son....
        begin
             writeln('Error. Cada tiempo asignado a una localidad, debe ser distinto a los demas. Ingrese nuevamente dicho valor: ');
             readln(aux_min);
             val (aux_min,local.tiempo2,err);//Se vuelve a leer el tiempo 2
        end
        else //si son distintos...
        begin
             validar:=true; //a la variable 'validar' se le asigna 'falso' para que pueda salir de la iteración previamente descrita
        end;
   end;
   min_loc[2]:=local.tiempo2; //El valor recién ingresado, se le asigna a la segunda posicion del arreglo 'min_loc'.
   if min_loc[1]>min_loc[2] then  //Si el segundo tiempo es menor que el primero
   begin
        num:=min_loc[2];
        min_loc[2]:=min_loc[1];
        min_loc[1]:=num;
        local.tiempo1:=min_loc[1];
        local.tiempo2:=min_loc[2];//Tanto al registro 'local' como al arreglo 'min_loc', se les orrdenan los tiempos de menor a mayor
   end;
   writeln('tiempo nr. 3 (min):'); //Se pide el tiempo 3
   readln(aux_min);// se lee el dato
   val (aux_min,local.tiempo3,err);//se convierte el dato recien ingresado a 'integer' y se guarda en la variable 'tiempo3'
   validar:=false;
   while validar=false do //Para el tiempo 3 se toma en cuenta también la misma iteración aplicada al tiempo 2....
   begin
        while validar_min_loc=false do
        begin
             writeln('Error. El valor debe ser numerico mayor a 0. Ingrese nuevamente dicho valor: ');
             readln(aux_min);
             val (aux_min,local.tiempo3,err);
        end;
        min_loc[3]:=local.tiempo3;
        if (min_loc[3]=min_loc[2]) or (min_loc[3]=min_loc[1])  then //..la pequeña diferencia radica en que hay que comparar adicionalmente con el tiempo2
        begin
             writeln('Error. Cada tiempo asignado a una localidad, debe ser distinto a los demas. Ingrese nuevamente dicho valor: ');
             readln(aux_min);
             val (aux_min,local.tiempo3,err);
        end
        else
        begin
             validar:=true;
        end;
   end;
   min_loc[3]:=local.tiempo3;//El valor recién ingresado, se le asigna a la tercera posicion del arreglo 'min_loc'.
   if min_loc[3]<min_loc[1] then //si el tiempo 3 es menor que el 1....
   begin
        num:=min_loc[3];
        min_loc[3]:=min_loc[2];
        min_loc[2]:=min_loc[1];
        min_loc[1]:=num;
        local.tiempo3:=min_loc[3];
        local.tiempo2:=min_loc[2];
        local.tiempo1:=min_loc[1]; //Tanto al registro 'local' como al arreglo 'min_loc', se les orrdenan los tiempos de menor a mayor
   end
   else if min_loc[3]<min_loc[2] then //si el tiempo 3 es mayor que el 1, pero menor que el 2....
   begin
        num:=min_loc[3];
        min_loc[3]:=min_loc[2];
        min_loc[2]:=num;
        local.tiempo3:=min_loc[3];
        local.tiempo2:=min_loc[2]; //Tanto al registro 'local' como al arreglo 'min_loc', se les orrdenan los tiempos de menor a mayor
   end;
   assign (locali,'localidades.dat');
   reset (locali); //Se abre el archivo
   seek(locali,filesize(locali));//Se coloca el puntero en la ultima posicion del archivo
   write(locali,local); //Se graba el nuevo registro
   close (locali); // Se cierra el archivo

end;

function num_reg_ped: integer; //Cuenta la cantidad de registro que contiene el archivo 'pedidos.dat'
var
   cont:integer;
begin
   assign (solici,'pedidos.dat');
   reset (solici);//Se abre el archivo
   cont:=filesize(solici); //En la variable 'cont', se guarda la cantidad de registros de dicho archivo
   close (solici); //Se cierra el archivo
   num_reg_ped:=cont //Se le asigna a la funcion, el valor de 'cont'
end;

procedure ingresar_fecha(var hoy:fecha);//procedimento para el ingreso de fecha, pasando por parámetro un arreglo de enteros, el cual almacenará dicha fecha ingresada por el usuario
var
   day,month,year:string; //Variables auxiliares para la conversión a enteros

begin
    writeln ('Ingrese el a#o :');
    readln (year); //Se pide y lee el año, cuyo dato se guarda en la variable 'year'
    val (year,hoy[3],err); //Se convierte el valor de la variable 'year' a entero y se almacena en la tercera posicion del arreglo pasado por parámetro
    while (err<>0) or (hoy[3]<1) do //Mientras que no sea numerico o menor que 1
    begin
       writeln ('Dato invalido. Ingrese nuevamente el a#o :');
       readln (year);
       val (year,hoy[3],err); //Se pedirá y leerá dicho valor nuevamente
    end;
    writeln ('Ingrese el numero de mes (del 1 al 12)');
    readln (month); //Se pide y lee el mes, cuyo dato se guarda en la variable 'month'
    val (month,hoy[2],err);//Se convierte el valor de la variable 'month' a entero y se almacena en la segunda posicion del arreglo pasado por parámetro
    while (err<>0) or (hoy[2]<1) or (hoy[2]>12) do //Mientras que no sea numerico o menor que 1 o mayor que 12...
    begin
       writeln ('El mes debe ser numerico y que oscile entre 1 y 12. Ingrese nuevamente el mes:');
       readln (month);
       val (month,hoy[2],err);//Se pedirá y leerá dicho valor nuevamente
    end;
    writeln ('ingrese el numero del dia');
    readln (day);//Se pide y lee el día, cuyo dato se guarda en la variable 'day'
    val (day,hoy[1],err);//Se convierte el valor de la variable 'day' a entero y se almacena en la primera posicion del arreglo pasado por parámetro
    (*
    Para validar el numero del día(tercera posición arreglo pasado por parámetro), es primordial tomar en cuenta
    el valor del mes(segunda posición arreglo pasado por parámetro) y el del año (primera posición arreglo pasado
    por parámetro) si es bisiesto (divisible entre 4). Dependieno de lo dicho anteriormente, se establece el rango
    permitido del día

    *)
    if (month='1') or (month='3') or (month='5') or (month='7') or (month='8') or (month='10') or (month='12') then //Rango del 1 al 31 dependiendo del mes
    begin
        while (err<>0) or (hoy[1]<1) or (hoy[1]>31) do //mientras no sea numerico el día y está fuera de rango....
        begin
             writeln ('El dia debe ser numerico y que oscile entre 1 y 31. Ingrese nuevamente el dia:');
             readln (day);
             val (day,hoy[1],err);
        end;
    end
    else if (month='4') or (month='6') or (month='9') or (month='11') then //Rango del 1 al 30 dependiendo del mes
    begin
         while (err<>0) or (hoy[1]<1) or (hoy[1]>30) do //mientras no sea numerico el día y está fuera de rango....
        begin
             writeln ('El dia debe ser numerico y que oscile entre 1 y 30. Ingrese nuevamente el dia:');
             readln (day);
             val (day,hoy[1],err);
        end;
    end
    else if (month='2') and (hoy[3] mod 4<>0) then //Rango del 1 al 28 dependiendo del mes y que no sea bisiesto
    begin
         while (err<>0) or (hoy[1]<1) or (hoy[1]>28) do //mientras no sea numerico el día y está fuera de rango....
        begin
             writeln ('El dia debe ser numerico y que oscile entre 1 y 28. Ingrese nuevamente el dia:');
             readln (day);
             val (day,hoy[1],err);
        end;
    end
    else //si el año es bisiesto y el mes es 2
    begin
         while (err<>0) or (hoy[1]<1) or (hoy[1]>29) do //mientras no sea numerico el día y está fuera de rango....
        begin
             writeln ('El dia debe ser numerico y que oscile entre 1 y 29. Ingrese nuevamente el dia:');
             readln (day);
             val (day,hoy[1],err);
        end;
    end;
end;

procedure ingresar_hora(var hra: hora); //Procedimento para el ingreso de fecha, pasando por parámetro un arreglo de enteros, el cual almacenará dicha hora ingresada por el usuario
var
   hr,min:string; //Variables para la entrada de datos

begin
   writeln ('Ingrese la hora (Formato Militar; 0 a 23)');
   readln(hr);//Se pide la hora y se guarda en la variable 'hr'
   val (hr,hra[1],err); //Se convierte a entero el valor de la variable 'hr' y se guarda en la primera posición del arreglo pasado por parámetro
   while (err<>0) or (hra[1]<0) or (hra[1]>23) do //mientras el valor recién ingresado no sea numérico o fuera de rango de hora (0 a 23)
   begin
       writeln ('El valor debe ser numerico y oscilar entre 0 y 23. Ingrese nuevamente la hora');
       readln(hr);
       val (hr,hra[1],err); //Se pide nuevamente el valor para ser evaluado
   end;
   writeln ('Ingrese los minutos (de 0 a 59)');
   readln(min); //Se piden los minutos y se guarda en la variable 'min'
   val (min,hra[2],err); //Se convierte a entero el valor de la variable 'min' y se guarda en la segunda posición del arreglo pasado por parámetro
   while (err<>0) or (hra[2]<0) or (hra[2]>59) do //mientras el valor recién ingresado no sea numérico o fuera de rango de minutos (0 a 59)
   
   begin
       writeln ('El valor debe ser numerico y oscilar entre 0 y 59. Ingrese nuevamente la hora');
       readln(min);
       val (min,hra[2],err);//Se pide nuevamente el valor para ser evaluado
   end;
end;


procedure registrar_pedido; //Procedimiento para registrar un nuevo pedido
var

   encontrado:boolean; //variable usada para la busqueda de clientes a partir de la cedula en el archivo 'clientes.dat'

   var aux_cad: string; //variable usada para la conversion a enteros

begin
   clrscr;
   writeln ('Cedula del cliente');
   readln (solic.ced_cli); //Se pide la cédula del cliente y se procesa en el campo 'ced_cli' del registro a guardar
   val (solic.ced_cli,num,err); //Se convierte el valor recién ingresado a entero, dicho resultado será almacenado en en la variable 'num'
   while err<>0 do //mientras la cedula no sea numérica
   begin
       writeln('Error, la cedula debe ser un valor numerico. Ingrese nuevamente la cedula');
       readln (solic.ced_cli);
       val (solic.ced_cli,num,err);//Se pide y se procesa nuevamente la cédula del cliente
   end;
   assign(client,'clientes.dat');
   reset (client);//Se abre el archivo 'clientes.dat' para verificar si hay un registro que en su campo 'cedula' coincida con el recién ingresado
   encontrado:=false; //Se inicializa 'falso' antes de llevar a cabo la búsqueda
   while not (EOF(client)) do //Se recorre el archivo...
   begin
        read(client,lin_cli);
        if lin_cli.cedula=solic.ced_cli then  //Si hubo coincidencia
        begin
            encontrado:=true;
            //Simplemente se muestra
            writeln ('Nombre: ',lin_cli.nombre);
            writeln ('Apellido: ',lin_cli.apellido);
            writeln ('Direccion: ',lin_cli.direccion);

        end;
   end;
   close (client);//Se cierra el archivo
   if (encontrado=false) then //Si no hubo coincidencias, es necesario solicitar el resto de los datos del cliente, para guardarlos en el archivo 'clientes.dat'
   begin
      clien.cedula:=solic.ced_cli; //Se le asigna al campo 'cedula' del nuevo registro que se va a guardar en el achivo, la cédula recién ingresada
      writeln('Nombre del cliente');
      readln(clien.nombre);
      writeln('Apellido del cliente');
      readln(clien.apellido);
      writeln('Direccion del cliente');
      readln(clien.direccion);//Se pide y se lee el resto de los datos en sus campos correspondientes del registro a guardar en el archivo
      assign(client,'clientes.dat');
      reset (client);
      seek (client,filesize(client)); //Se abre nuevamente el archivo 'clientes.dat', y se coloca el puntero de registros, en la última posición
      write (client,clien);// Se graba el nuevo registro en el archivo
      close (client); //Se cierra el archivo
   end;
   writeln ('Localidad en donde sera entregado el pedido');
   readln (solic.nomb_loc);//Se pide la localidad y se guarda en el campo correspondiente del registro que se va a grabar
   while (localidad_rep(solic.nomb_loc)=false) do //si el dato recién ingresado no concuerda con los guardados en el archivo 'localidades.dat'
   begin
       writeln('Error. Localidad no encontrada, ingrese nuevamente la localidad');
       readln (solic.nomb_loc); //Se pide nuevamente y se guarda para ser evaluado
   end;
   solic.num:=num_reg_ped+1; //Para asignarle un valor clave al pedido, es necesario contar el número de registros del archivos 'pedidos.dat', dicha cantidad se calcula invocando la funcion 'num_reg_ped'. Una vez obtenida la cantidad, se le suma 1 y dicho resultado se guarda en el número de pedido correspondiente al campo del registro que se va a almacenar en el archivo 'pedidos.dat'
   (*
   Evidentemente, la fecha de solicitud es la misma que la fecha actual
   por consiguiente, se le asigna al arreglo 'fecha_solic' el registro a guardar, los valores de
   sus posiciones respectivas del arreglo 'hoy'

   *)

   solic.fecha_solic[1]:=hoy[1];
   solic.fecha_solic[2]:=hoy[2];
   solic.fecha_solic[3]:=hoy[3];
   writeln ('Hora de solicitud');
   ingresar_hora(solic.hora_ped);//Se pide la hora de solicitud, por lo tanto se invoca el procedimiento 'ingresar_hora', pasando por parámetro el arreglo 'hora_ped' del registro a guardar en el archivo
   solic.est_entr:='En Espera';//Por cada pedido, al campo 'est_entr' del registro a guardar en el archivo, se le asignará el valor 'En Espera' por defecto
   solic.desc:=0;
   solic.hora_entr[1]:=0;
   solic.hora_entr[2]:=0;
   solic.min_entr:=0;
   writeln ('Monto del pedido (Bs.):');
   readln(aux_cad); //Se pide el monto del pedido y se guarda en la variable 'aux_cad'
   val (aux_cad,solic.monto_ini,err);//Se convierte el valor de la variable 'aux_cad', cuyo resultado se guarda en el campo 'monto_ini' del registro a guardar en el archivo
   while (err<>0) or (solic.monto_ini<=0) do //Si el ato recién ingresado no es numérico y menor que 1
   begin
       writeln('Error, el monto debe ser un numero mayor que 0. Ingrese nuevamente dicho numero');
       readln(aux_cad);
   val (aux_cad,solic.monto_ini,err);//Se pide nuevamente el dato y se vuelve a evaluar
   end;
   solic.monto:=0;
   writeln ('Su solicitud fue guardada de manera satisfactoria');
   writeln ();
   writeln ('Datos del Pedido: ');//Se imprimen por pantalla los datos pertinentes al pedido que será almacenado
   writeln ();
   writeln(' Numero del pedido: ',solic.num);
   writeln(' Localidad : ',solic.nomb_loc);
   writeln(' Cedula del cliente: ',solic.ced_cli);
   assign(client,'clientes.dat');
   reset (client);
   while not (EOF(client)) do
   begin
        read(client,lin_cli);
        if lin_cli.cedula=solic.ced_cli then
        begin
             writeln (' Nombre del Cliente: ',lin_cli.nombre);
             writeln (' Apellido del Cliente: ',lin_cli.apellido);
             writeln (' Direccion del Cliente: ',lin_cli.direccion);
        end;
    end;
    close (client);
   writeln(' Fecha de solicitud: ',solic.fecha_solic[1],'/',solic.fecha_solic[2],'/',solic.fecha_solic[3]);
   writeln(' Hora de solicitud: ',solic.hora_ped[1],'hr:',solic.hora_ped[2],'min');
   writeln(' Monto del Pedido (Bs.): ',solic.monto_ini);
   assign(solici,'pedidos.dat');
   reset (solici);
   seek (solici, filesize(solici));
   write (solici,solic);
   close (solici);
end;

procedure listado_espera(var espera: boolean); //procedimiento que imprime un listado de aquellos pedidos que no han sido entregado aún, se pasa por parámetro una variable booleana, la cual indicará si hay solicitudes en espera

begin
   assign (solici,'pedidos.dat');
   reset (solici); //Se abre el archivo de pedidos
   espera:=false;  //Al valor pasado por parámetro se le asigna 'falso'
   while not(EOF(solici)) do  // Se recorre el archivo
   begin
      read(solici,solic);
      if (solic.est_entr='En Espera') and (hoy[1]=solic.fecha_solic[1]) and (hoy[2]=solic.fecha_solic[2]) and (hoy[3]=solic.fecha_solic[3]) then //Si están en espera...
      begin
        espera:=true;
        writeln('*Numero del pedido: ',solic.num);
        writeln(' Localidad : ',solic.nomb_loc);
        writeln(' Cedula del cliente: ',solic.ced_cli);
        assign(client,'clientes.dat');
        reset (client); //Se abre también el archivo para clientes para mostrar los datos del cliente
        while not (EOF(client)) do
        begin
             read(client,lin_cli);
             if lin_cli.cedula=solic.ced_cli then //Si coincide el campo 'ced_cli' del registro en espera con el campo 'campo' del registro de cliente recié leído
             begin
                  writeln (' Nombre del Cliente: ',lin_cli.nombre);
                  writeln (' Apellido del Cliente: ',lin_cli.apellido);
                  writeln (' Direccion del Cliente: ',lin_cli.direccion);

             end;
        end;
        close (client); //Se cierra el archivo de clientes
        writeln(' Fecha de solicitud: ',solic.fecha_solic[1],'/',solic.fecha_solic[2],'/',solic.fecha_solic[3]);
        writeln(' Hora de solicitud: ',solic.hora_ped[1],'hrs.:',solic.hora_ped[2],'min.');
        writeln(' Monto del Pedido (Bs.): ',solic.monto_ini);
     end;
   end;
   close (solici);//Se cierra el archivo de pedidos
end;

function encontrar_ped: boolean; //función booleana que busca en el campo 'num' de todos los registros en el archivo 'pedidos' en relación a un numero ingresado por el usuario
var

   encontrado:boolean; //variable booleana auxiliar, cuyo valor se le asignará a la función
begin
   assign (solici,'pedidos.dat');
   reset (solici); //Se abre el archivo de pedidos
   encontrado:=false;
   while not(EOF(solici)) do //Se recorre dicho archivo
   begin
      read(solici,solic); //Se lee el registro actual
      if (solic.num=num) and (solic.est_entr='En Espera') then  //Si el numero coincide y el pedido está en espera
      begin
        encontrado:=true; //a 'encontrado' se le asigna 'verdadero'
     end;
   end;
   close (solici);//se cierra el archivo
   encontrar_ped:=encontrado;//A la función se le asigna el valor de 'encontrado'
end;

function validar_horas: boolean; //Función para validar las horas de solicitud y entrega de los pedidos en el archivo 'pedidos.dat'
var
   resultado:boolean; //variable booleana auxiliar, cuyo valor se le asignará a la función

begin
    resultado:=true;
    if (solic.hora_ped[1]>solic.hora_entr[1]) then //Si la hora de solicitud del pedido (posición 1 del arreglo), es mayor a la hora de entrega (posición 1 del arreglo)
    begin
      resultado:=false; // a 'resultado' se le asigna 'falso'
    end
    else if (solic.hora_ped[1]=solic.hora_entr[1]) and (solic.hora_ped[2]>=solic.hora_entr[2]) then //si son iguales las horas de solicitud y entrega (posición 1) y los minutos de solicitud es mayor o igual que los minutos de entrega (posición 2 el arreglo)
    begin
      resultado:=false; // a 'resultado' se le asigna 'falso'
    end
    else if (solic.hora_ped[2]>=solic.hora_entr[2]) then  //si concuerdan las horas previamente dichas, se procede a comparar las horas de solicitud y entrega (posicion 1), si la de solicitud es mayor que la de entrega...
    begin
       solic.min_entr:=60-(solic.hora_ped[2]-solic.hora_entr[2]);//se calculan los minutos que tardó en entregarse la solicitud
    end
    else //si es mayor la hora de entrega que la hora de solicitud (posicion 1)
    begin
       solic.min_entr:=(60*(solic.hora_entr[1]-solic.hora_ped[1]))-(solic.hora_ped[2]-solic.hora_entr[2]);//se calculan los minutos de entrega de esta manera
    end;
    validar_horas:=resultado; //A la función se le asigna el valor de 'resultado'

end;

procedure asignar_entrega; //Procedimiento para asignar una entrega a un pedido en espera
var
   valor:string;//Variable útil para conversion a entero
   espera:boolean;//variable booleana que determinará si existen pedidos en espera en el archivo 'pedidos.dat'
begin
    writeln('Listado de pedidos en espera: ');
    listado_espera(espera);//Se invoca el procedimiento 'listado_espera'
    if (espera=false) then //si no hay pedidos en espera...
    begin
       writeln('No hay pedidos en espera');
    end
    else //De haber pedidos en espera
    begin

      writeln ('Ingrese el numero de pedido que desee asignarle la entrega');
      readln(valor); //Se le pide al usuario el número del pedido que desee asignarle la entrega, dicho valor será guardado en la variable 'valor'
      val (valor, num, err); //Se convierte a entero, el valor de la variable 'valor', dicha conversión será almacenada en la variable entera 'num'
      while (err<>0) or (encontrar_ped=false) do  //Mientras que el valor ingresado no sea numérico o no se encuentre en el archivo 'pedidos.dat'
      begin
       writeln ('Numero no encontrado. ingrese nuevamente dicho numero');
       readln(valor);
       val (valor, num, err); //Se procede a leer nuevamente el número del pedido para ser evaluado
      end;
      assign (solici,'pedidos.dat');
      reset (solici);//Se abre el archivo de pedidos
      while not(EOF(solici)) do //Se recorre el archivo
      begin
           read(solici,solic);//se lee el registro actual del archivo
           if solic.num=num then //si coincide conel número ingresado por el usuario
           begin
                writeln ('Ingrese la hora de entrega');
                ingresar_hora(solic.hora_entr);//solicito la hora de entrega, a través de la invocación del método 'ingresar_hora'
                while (validar_horas=false) do //Mientras que no se cumplan las validaciones de las horas de solicitud y entrega, a través del método 'validar_horas'
                begin
                     writeln ('La hora de entrega no concuerda con la hora de solicitud, ingrese nuevamente la fecha de entrega');
                     ingresar_hora(solic.hora_entr); //Nuevamente se pide la hora de entrega
                end;
                solic.est_entr:='Entregado'; //Al registro a modificar, se le asigna al campo 'est_entr' en valor de 'Entregado'
                assign(locali,'localidades.dat');
                reset (locali); //Se abre el archivo 'localidades.dat' para determinar los descuentos en relación a la localidad de donde se entrega el pedido y la relación entre el tiempo de entrega y los tiempos estipulados de dicha localidad
                while not (EOF(locali)) do //Se recorre el archivo de las localidades
                begin
                     read(locali,local);
                     if local.nombre=solic.nomb_loc then //si coincide el nombre de la localidad del registro del archivo 'pedidos.dat' con el del registro del archivo 'localidades.dat'
                     begin
                          if (solic.min_entr>local.tiempo1) and (solic.min_entr<=local.tiempo2) then //si el minuto de entrega es mayor que el tiempo 1 y menor e igual que el tiempo 2
                          begin
                               solic.desc:= solic.monto_ini div 5; //Se le asigna al campo 'desc' del registro de pedidos, el 20% del monto del pedido
                          end
                          else if (solic.min_entr>local.tiempo2) and (solic.min_entr<=local.tiempo3) then //si el minuto de entrega es mayor que el tiempo 2 y menor e igual que el tiempo 3
                          begin
                               solic.desc:= solic.monto_ini div 2; //Se le asigna al campo 'desc' del registro de pedidos, el 50% del monto del pedido
                          end
                          else if(solic.min_entr>local.tiempo3) then  //Si el minuto de entrega, es mayor al tiempo 3
                          begin
                               solic.desc:=solic.monto_ini;  //Se le asigna al campo 'desc' del registro de pedidos, el monto del pedido

                          end;
                          solic.monto:=solic.monto_ini-solic.desc; //Se le asigna al campo 'monto' del registro de pedidos, el monto del pedido menos el descuento

                     end;
               end;
               writeln();
               writeln('Monto del pedido (Bs.): ',solic.monto_ini);
               writeln('Hora de solicitud: ',solic.hora_ped[1],':',solic.hora_ped[2]);
               writeln('Hora de entrega: ',solic.hora_entr[1],':',solic.hora_entr[2]);
               writeln('Minutos de entrega: ',solic.min_entr);
               writeln ('Descuento (Bs.)',solic.desc);
               writeln('Monto Final (Bs.): ',solic.monto);//Se muestra los datos relevantes de la entrega del pedido
               close (locali); //Se cierra el archivo 'localidades.dat'
               seek(solici,filepos(solici)-1);
               write(solici,solic); //Se guarda la información de la entrega
            end;
        end;
        close (solici);//Se cierra el archivo 'pedidos.dat'
    end;

    writeln ('Entrega realizada de manera satisfactoria');
end;

function fecha_rep: boolean; //función booleana que se encarga de verificar si la fecha de apertura coincide con alguna en el archivo 'pedidos.dat'
var
   encontrado:boolean; //variable booleana auxiliar, cuyo valor se le asignará a la función

begin
   assign (solici,'pedidos.dat');
   reset(solici); //Se abre el archivo de pedidos
   encontrado:=false; //Se incializa la variable 'encontrado'
   while not(EOF(solici)) do //Se recorre el archivo
   begin
       read(solici,solic); //Se lee la línea del registro actual
       if (filesize(solici)>0) and (solic.fecha_solic[1]=hoy[1]) and (solic.fecha_solic[2]=hoy[2]) and (solic.fecha_solic[3]=hoy[3]) then //Si existe alguna cioncidencia de fechas
       begin
           encontrado:=true; //A 'encontrado' se le asigna 'verdadero'
       end;
   end;
   close(solici);//Se cierra el archivo
   fecha_rep:=encontrado; //A la función se le asigna el valor de 'encontrado'
end;

procedure aperturar; //Procedimiento para aperturar la jornada

begin

  clrscr;
  if apert=false then //Si no se ha aperturado...
  begin
       writeln ('A continuacion debera ingresar la fecha actual');
       ingresar_fecha(hoy);//Se solicita la fecha actual
       while fecha_rep do //Si la fecha actual, coincide con alguna de los registros del archivo 'pedidos.dat'
       begin
         writeln ('La fecha ingresada, coincide con algun registro en el archivo de pedidos. Ingrese nuevamente la fecha actual');
         ingresar_fecha(hoy); //Se solicita la fecha actual de nuevo, para ser evaluada
       end;
       apert:=true;//A la variable que maneja las aperturas, se le asigna 'verdadero'
       cierre:=false; //A 'cierre' se le asigna 'falso'
  end
  else//si ya está aperturada la jornada...
  begin
       writeln ('La jornada de hoy ya fue aperturada');
  end;

end;
procedure reporte_fecha(hoy:fecha); //Procedimiento que muestra el total en ventas, el total en descuentos y el total pagado a partir de una fecha en especifíco, dicha consulta se realiza en el archivo 'pedidos.dat'
var
   tot_vend,tot_desc: integer; //Variables que contabilizarán el total vendido y el total en descuentos respectivamente

begin
   clrscr;
   assign (solici,'pedidos.dat');
   reset (solici);// Se abre el archivo e pedidos
   tot_vend:=0;
   tot_desc:=0; //Se inicializan las variables enteras
   while not (EOF(solici)) do //Se recorre el archivo
   begin
       read(solici,solic);  //Se lee el registro actual
       if (solic.fecha_solic[1]=hoy[1]) and (solic.fecha_solic[2]=hoy[2]) and (solic.fecha_solic[3]=hoy[3]) and (solic.est_entr='Entregado') then  //Si coincide con la fecha del registro del archivo y su estado es entregado...
       begin
           tot_vend:=tot_vend+solic.monto_ini;
           tot_desc:=tot_desc+solic.desc;//Se contabilizan los montos en ventas y descuentos en esa fecha
       end;
   end;
   close (solici);//Se cierra el archivo
   //Se muestran por pantalla total en ventas, total en desuentos y total pagado respectivamente
   writeln('*Total en ventas (Bs.): ',tot_vend);
   writeln('*Total en descuento (Bs.): ',tot_desc);
   writeln('*Total pagado (Bs.): ',tot_vend-tot_desc);
end;

procedure reporte_localidad; //Procedimiento que muestra el total en ventas, el total en descuentos y el total pagado a partir de una localidad en especifíco, dicha consulta se realiza en el archivo 'pedidos.dat'
var

   nomb_loc:string; //variable que guarda el nombre de la localidad a consultar
   tot_vend,tot_desc:integer;  //Variables que contabilizarán el total vendido y el total en descuentos respectivamente

begin
   clrscr;
   assign (solici,'pedidos.dat');
   reset (solici);//Se abre el archivo 'pedidos.dat'
   tot_vend:=0;
   tot_desc:=0;
   writeln ('Ingrese el nombre de la localidad a consultar');
   readln (nomb_loc);//Se lee el nombre de la localidad a consultar
   while (localidad_rep(nomb_loc)=false) do  //Mientras que no se encuentra el nombre de la localidad
   begin
       writeln ('Nombre de localidad no encontrada. Ingrese nuevamente dicho nombre');
       readln (nomb_loc); //Se solicita de nuevo el nombre de la localidad
   end;
   while not (EOF(solici)) do //Se recorre el archivo
   begin
       read(solici,solic);//Se lee el registro actual
       if (solic.nomb_loc=nomb_loc) and (solic.est_entr='Entregado') then //Si coincide con el nombre de la localidad del registro del archivo y su estado es entregado...
       begin
            tot_vend:=tot_vend+solic.monto_ini;
            tot_desc:=tot_desc+solic.desc;//Se contabilizan los montos en ventas y descuentos en esa fecha
       end;

   end;
   close (solici);//Se cierra el archivo
   //Se muestran por pantalla total en ventas, total en desuentos y total pagado respectivamente
   writeln ('Datos generales de la localidad "',nomb_loc,'"');
   writeln();
   writeln('*Total en ventas (Bs.): ',tot_vend);
   writeln('*Total en descuento (Bs.): ',tot_desc);
   writeln('*Total pagado (Bs.): ',tot_vend-tot_desc);
end;
procedure cerrar;// proceimiento para cerrar la jornada
var

   salir_jorn:boolean;//variable booleana que determina si existen pedidos en espera dentro el archivo
begin

     if cierre=true then //Si la jornada ya fue cerrada
     begin
       writeln ('La jornada de hoy ya fue cerrada');
     end
     else //si no está cerrada
     begin
        assign(solici,'pedidos.dat');
        reset (solici); //se abre el archivo 'pedidos.dat'
        salir_jorn:=true;//Inicializar variable 'salir_jorn'
        while (not (EOF(solici))) do //Se recorre el archivo
        begin
            read (solici,solic); //Se lee el registro actual
            if (hoy[1]=solic.fecha_solic[1]) and (hoy[2]=solic.fecha_solic[2]) and (hoy[3]=solic.fecha_solic[3]) and (solic.est_entr='En Espera') then  //si quedaron pedidos en espera
            begin
                writeln ('No se puede realizar el cierre hasta que se terminen de entregar los pedidos pendientes en este dia');
                salir_jorn:=false; //A 'salir_jorn' le asigno 'falso'
            end;
        end;
        close (solici);
        if (salir_jorn=true) then //Si no se encontraron pedidos en espera
        begin
            //Se notifica el cierre
            writeln ('La jornada de hoy fue cerrada satisfactoriamente');
            writeln ('Datos Generales del dia de hoy');
            writeln();
            reporte_fecha(hoy);//Se genera el reporte del día de hoy
            cierre:=true; //A 'cierre' le asigno 'veradero'
            apert:=false;//A 'apert' le asigno 'falso'
        end;
     end;
end;

procedure crear_archivos; //Procedimiento para crear los archivos 'localidades.dat', 'clientes.dat' y 'pedidos.dat'

begin
    assign (locali,'localidades.dat');
    Reset(locali);
    if (ioresult<>0) then //Si el archivo 'localidades.dat' no existe....
    begin
         rewrite (locali); //Se crea
    end;
    close (locali);
    assign (client,'clientes.dat');
    Reset(client);
    if (ioresult<>0) then //Si el archivo 'clientes.dat' no existe....
    begin
         rewrite (client); //Se crea
    end;
    close (client);
    assign (solici,'pedidos.dat');
    Reset(solici);
    if (ioresult<>0) then //Si el archivo 'pedidos.dat' no existe....
    begin
         rewrite (solici); //Se crea
    end;
    close (solici);

end;

begin
  crear_archivos; //Creación e archivos de datos
  salir_apl:=false;
  apert:=false;
  cierre:=true;//Inicializar variables de la iteración del menú, de apertura y cierre
  writeln('Bienvenidos al programa "PIZZAMIGA"');
  while salir_apl=false do
  begin
     writeln();
     writeln('Menu Principal.');
     writeln();
     writeln('Opciones: ');
     writeln('1) Si desea realizar la apertura del dia. ');
     writeln('2) Si desea registrar una localidad. ');
     writeln('3) Si desea modificar una localidad. ');
     writeln('4) Si desea registrar un nuevo pedido. ');
     writeln('5) Si desea realizar una entrega de un pedido especifico. ');
     writeln('6) Si desea realizar el cierre del dia. ');
     writeln('7) Si desea mostrar el listado de localidades. ');
     writeln('8) Si desea mostrar el reporte de ingresos por fecha. ');
     writeln('9) Si desea mostrar el reporte de ingresos por localidad. ');
     readln(opc); //Se lee la opción ingresada
     while (opc<>'1') and (opc<>'2') and (opc<>'3') and (opc<>'4') and (opc<>'5') and (opc<>'6') and (opc<>'7') and (opc<>'8') and (opc<>'9') do //Mientras ingrese opción inválida...
     begin
        writeln('Error al leer dato de entrada. Ingrese nuevamente la opcion correcta: ');
        readln(opc);
     end;
     val (opc,num,err);
     case num of
        1:  aperturar;//si eligió '1', se invoca el procedimiento 'aperturar'
        2:  agregar_loc; //si eligió '2', se invoca el procedimiento 'agregar_loc'
        3: modificar_loc; //si eligió '3', se invoca el procedimiento 'moificar_loc'
        4: if (apert=false) then  //si eligió '4', y no se ha aperturado la jornada
            begin
                 writeln('Es necesario aperturar el dia para realizar esta accion');
            end
            else //si se aperturó
            begin
                 registrar_pedido; // se invoca el procedimiento 'registrar_pedido'
            end;
        5: if (apert=false) then  //si eligió '5', y no se ha aperturado la jornada
            begin
                 writeln('Es necesario aperturar el dia para realizar esta accion');
            end
            else if (num_reg_ped=0) then //si se ha aperturado la jornada y no hay registros en el archivo 'pedidos.dat'
            begin
               writeln('No se encontraron pedidos pendientes');
            end
            else//Si hay pedidos pendientes...
            begin
                 asignar_entrega; // se invoca el procedimiento 'asignar_entrega'
            end;
        6: cerrar; //si eligió '6', se invoca el procedimiento 'cerrar'
        7: mostrar_localidades; //si eligió '7', se invoca el procedimiento 'mostrar_localidades'
        8:begin //si eligió '8'
               ingresar_fecha(fch); //Se pide la fecha
               writeln ('Datos generales de la fecha ',fch[1],'/',fch[2],'/',fch[3]);
               writeln();
               reporte_fecha(fch);//se realiza el reporte
          end;

        9: reporte_localidad;  //si eligió '9', se invoca el procedimiento 'reporte_localidad

     end;
     writeln('Desea salir de la aplicacion? s/n');//Se le pregunta al usuario, si desea salir del programa
     readln(opc);
     while (opc<>'s') and (opc<>'S') and (opc<>'n') and (opc<>'N') do //Mientras la opción sea inválida
     begin
         writeln('Opcion invalida, ingrese la opcion correcta.');
         readln(opc);
     end;
     if ((opc='s') or (opc='S')) and (cierre=true) then //Si el usuario quiere salir...
     begin
        salir_apl:=TRUE;// A la variable "salir_apl" se le asigna verdadero para que pueda salir de la iteración
     end
     else if ((opc='s') or (opc='S')) and (cierre=false) then //si esea salir del programa y aún no se ha cerrado la jornada
     begin
          writeln ('Lo sentimos. No puede salir mientras no se cierre la jornada de hoy');
     end;
   end;
end.
