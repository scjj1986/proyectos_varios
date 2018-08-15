uses crt;
type
    pelicula=record
      codigo,nombre,genero,clasificacion,descripcion,duracion,copias:string;
     end;

    cliente=record
      cedula,nombre,apellido,codigo_pelicula,day,month,year:string;
    end;
var
  pel,cli,pel2,cli2:text;
  peli:pelicula;
  clie:cliente;
  salir,validar:boolean;
  opcion,linea,linea2,cadena,cadena2:string;
  n_linea,numero,numero2,error,indice,indice2,indice3:integer;
function codigo_repetido:boolean;
var
   aux:boolean;
   i,j,cont,cont2:integer;
begin
   assign (pel,'peliculas.txt');
   reset (pel);
   aux:=false;
   n_linea:=1;
   while not eof (pel) do
   begin
       readln (pel,linea);
       i:=9;
       j:=1;
       cont:=0;
       cont2:=0;
       while (linea[i+1]<>'|') do
       begin
          if (linea[i]=peli.codigo[j]) then
          begin
               cont:=cont+1;
          end;
          i:=i+1;
          j:=j+1;
          cont2:=cont2+1;
       end;
       if cont=cont2 then
       begin
           aux:=true;
           i:=i+11;
           cadena:='';
           while (linea[i+1]<>'|') do
           begin
                cadena:=cadena+linea[i];
                i:=i+1;
           end;
       end;
       if aux=false then
       begin
           n_linea:=n_linea+1;
       end;
   end;
   close (pel);
   codigo_repetido:=aux;
end;
procedure respaldar_pelicula;
begin
    assign (pel,'peliculas.txt');
    assign (pel2,'peliculas_backup.txt');
    rewrite (pel2);
    reset (pel);
    while not eof (pel) do
    begin
        readln (pel,linea);
        append (pel2);
        writeln(pel2,linea);
        close (pel2);
    end;
    close (pel);
end;
procedure respaldar_cliente;
begin
    assign (cli,'clientes.txt');
    assign (cli2,'clientes_backup.txt');
    rewrite (cli2);
    reset (cli);
    while not eof (cli) do
    begin
        readln (cli,linea);
        append (cli2);
        writeln(cli2,linea);
        close (cli2);
    end;
    close (cli);
end;
procedure agregar_pelicula;
var
   i:integer;
begin
     clrscr;
    writeln ('*Ingrese el codigo');
    readln(peli.codigo);
    for i:=1 to length(peli.codigo) do
    begin
       peli.codigo[i]:=UPCASE(peli.codigo[i]);
    end;
    while (pos('|',peli.codigo)<>0) do
    begin
         writeln ('Error en la entrada de datos. Ingrese nuevamente el codigo');
         readln(peli.codigo);
         for i:=1 to length(peli.codigo) do
         begin
              peli.codigo[i]:=UPCASE(peli.codigo[i]);
         end;
    end;
    if (codigo_repetido=false) then
    begin

        writeln ('*Ingrese el nombre');
        readln(peli.nombre);
        for i:=1 to length(peli.nombre) do
        begin
             peli.nombre[i]:=UPCASE(peli.nombre[i]);
        end;
        writeln ('*Ingrese el genero');
        readln(peli.genero);
        for i:=1 to length(peli.genero) do
        begin
             peli.genero[i]:=UPCASE(peli.genero[i]);
        end;
        writeln ('*Ingrese la clasificacion (A,B,C ó D):');
        readln(peli.clasificacion);
        for i:=1 to length(peli.clasificacion) do
        begin
             peli.clasificacion[i]:=UPCASE(peli.clasificacion[i]);
        end;
        while (peli.clasificacion<>'A') and (peli.clasificacion<>'B') and (peli.clasificacion<>'C') and (peli.clasificacion<>'D') do
        begin
             writeln ('Opcion invalida, ingrese la opcion correcta:');
             readln(peli.clasificacion);
             for i:=1 to length(peli.clasificacion) do
             begin
                  peli.clasificacion[i]:=UPCASE(peli.clasificacion[i]);
             end;
        end;
        writeln ('*Ingrese la descripcion:');
        readln(peli.descripcion);
        for i:=1 to length(peli.descripcion) do
        begin
             peli.descripcion[i]:=UPCASE(peli.descripcion[i]);
        end;
        while length(peli.descripcion)>300 do
        begin
             writeln ('La descripcion no debe sobrepasar de los 300 caracteres. Ingrese nuevamente la descripcion:');
             readln(peli.descripcion);
             for i:=1 to length(peli.descripcion) do
             begin
                  peli.descripcion[i]:=UPCASE(peli.descripcion[i]);
                  writeln (peli.descripcion[i]);
             end;
        end;
        numero:=1;
        writeln ('*Ingrese la duracion (min.)');
        readln(peli.duracion);
        val (peli.duracion,numero,error);
        while (error<>0) or (numero=0) do
        begin
          numero:=1;
          writeln ('El valor de be ser numerico y mayor que 0. Ingrese nuevamente dicho valor');
          readln(peli.duracion);
          val (peli.duracion,numero,error);
        end;
        writeln ('Ingrese la cantidad de copias.');
        readln(peli.copias);
        val (peli.copias,numero,error);
        while (error<>0)  do
        begin
          numero:=1;
          writeln ('El valor debe ser numerico. Ingrese nuevamente dicho valor');
          readln(peli.copias);
          val (peli.copias,numero,error);
        end;
        linea:='Codigo: '+peli.codigo+' | '+'Nombre: '+peli.nombre+' | '+'Genero: '+peli.genero+' | '+'Clasificacion: '+peli.clasificacion+' | '+'Descripcion: '+peli.descripcion+' | '+'Duracion (min.): '+peli.duracion+' | '+'Nr. de copias: '+peli.copias;
        assign (pel,'peliculas.txt');
        reset (pel);
        append (pel);
        writeln (pel,linea);
        close (pel);
    end
    else
    begin
        writeln ('El codigo ingresado corresponde a una pelicula registrada, de nombre: ',cadena,'.');
        writeln ('Ingrese la cantidad de copias a agregar.');
        readln(peli.copias);
        numero:=1;
        val (peli.copias,numero,error);
        while (error<>0) or (numero=0) do
        begin
          numero:=1;
          writeln ('El valor debe ser numerico y mayor que 0. Ingrese nuevamente dicho valor');
          readln(peli.copias);
          val (peli.copias,numero,error);
        end;
        respaldar_pelicula;
        assign (pel2,'peliculas_backup.txt');
        reset (pel2);
        assign (pel,'peliculas.txt');
        reset (pel);
        rewrite (pel);
        indice:=1;
        while not eof (pel2) do
        begin
            readln (pel2,linea);
            if (indice=n_linea) then
            begin
                indice2:=pos ('Nr. de copias:',linea);
                indice2:=indice2+15;
                indice3:=indice2;
                cadena:='';
                while indice3<=length(linea) do
                begin
                    cadena:=cadena+linea[indice3];
                    indice3:=indice3+1;
                end;
                writeln (cadena);
                val (cadena,numero2,error);
                numero2:=numero2+numero;
                delete (linea,indice2,indice3-indice2);
                str (numero2,cadena);
                linea:=linea+cadena;
            end;
            append (pel);
            writeln (pel,linea);
            close (pel);
            indice:=indice+1;
        end;
        close (pel2);
    end;
end;
function cedula_repetida:boolean;
var
   aux:boolean;
   i,j,cont,cont2:integer;
begin
   assign (cli,'clientes.txt');
   reset (cli);
   aux:=false;
   n_linea:=1;
   while not eof (cli) do
   begin
       readln (cli,linea);
       i:=9;
       j:=1;
       cont:=0;
       cont2:=0;
       while (linea[i+1]<>'|') do
       begin
          if (linea[i]=clie.cedula[j]) then
          begin
               cont:=cont+1;
          end;
          i:=i+1;
          j:=j+1;
          cont2:=cont2+1;
       end;
       if cont=cont2 then
       begin
           aux:=true;
       end;
       if aux=false then
       begin
           n_linea:=n_linea+1;
       end;
   end;
   close (cli);
   cedula_repetida:=aux;
end;

procedure ingresar_fecha(var day:string;var month:string;var year:string);//procedimento para el ingreso de fecha, el cual almacenará dicha fecha ingresada por el usuario
begin
    writeln ('Ingrese el a#o :');
    readln (year); //Se pide y lee el año, cuyo dato se guarda en la variable 'year'
    val (year,numero,error); //Se convierte el valor de la variable 'year' a entero y se almacena en la tercera posicion del arreglo pasado por parámetro
    while (error<>0) or (numero<1) do //Mientras que no sea numerico o menor que 1
    begin
       writeln ('Dato invalido. Ingrese nuevamente el a#o :');
       readln (year);
       val (year,numero,error); //Se pedirá y leerá dicho valor nuevamente
    end;
    writeln ('Ingrese el numero de mes (del 1 al 12)');
    readln (month); //Se pide y lee el mes, cuyo dato se guarda en la variable 'month'
    val (month,numero,error);//Se convierte el valor de la variable 'month' a entero y se almacena en la segunda posicion del arreglo pasado por parámetro
    while (error<>0) or (numero<1) or (numero>12) do //Mientras que no sea numerico o menor que 1 o mayor que 12...
    begin
       writeln ('El mes debe ser numerico y que oscile entre 1 y 12. Ingrese nuevamente el mes:');
       readln (month);
       val (month,numero,error);//Se pedirá y leerá dicho valor nuevamente
    end;
    writeln ('ingrese el numero del dia');
    readln (day);//Se pide y lee el día, cuyo dato se guarda en la variable 'day'
    val (day,numero,error);//Se convierte el valor de la variable 'day' a entero y se almacena en la primera posicion del arreglo pasado por parámetro
    if (month='1') or (month='3') or (month='5') or (month='7') or (month='8') or (month='10') or (month='12') then //Rango del 1 al 31 dependiendo del mes
    begin
        while (error<>0) or (numero<1) or (numero>31) do //mientras no sea numerico el día y está fuera de rango....
        begin
             writeln ('El dia debe ser numerico y que oscile entre 1 y 31. Ingrese nuevamente el dia:');
             readln (day);
             val (day,numero,error);
        end;
    end
    else if (month='4') or (month='6') or (month='9') or (month='11') then //Rango del 1 al 30 dependiendo del mes
    begin
         while (error<>0) or (numero<1) or (numero>30) do //mientras no sea numerico el día y está fuera de rango....
        begin
             writeln ('El dia debe ser numerico y que oscile entre 1 y 30. Ingrese nuevamente el dia:');
             readln (day);
             val (day,numero,error);
        end;
    end
    else if (month='2') then //Rango del 1 al 28 dependiendo del mes y que no sea bisiesto
    begin
         while (error<>0) or (numero<1) or (numero>28) do //mientras no sea numerico el día y está fuera de rango....
        begin
             writeln ('El dia debe ser numerico y que oscile entre 1 y 28. Ingrese nuevamente el dia:');
             readln (day);
             val (day,numero,error);
        end;
    end;
end;

procedure agregar_cliente;
var
i:integer;
begin
    clrscr;
    writeln ('Cedula del cliente');
    readln (clie.cedula);
    val (clie.cedula,numero,error);
    while (error<>0) and (numero=0) do
    begin
        writeln ('La cantidad debe ser numerica y mayor que 0. Ingrese nuevamente dicho valor');
        readln (clie.cedula);
        val (clie.cedula,numero,error);
    end;
    if (cedula_repetida=false) then
    begin
         writeln ('*Nombre:');
         readln (clie.nombre);
         for i:=1 to length(clie.nombre) do
         begin
             clie.nombre[i]:=UPCASE(clie.nombre[i]);
         end;
         writeln ('*Apellido:');
         readln (clie.apellido);
         for i:=1 to length(clie.apellido) do
         begin
             clie.apellido[i]:=UPCASE(clie.apellido[i]);
         end;
    end
    else
    begin
        writeln();
        assign (cli,'clientes.txt');
        reset (cli);
        numero:=1;
        while not eof (cli) do
        begin
             readln (cli,linea);
             if (numero=n_linea) then
             begin
                  numero2:=pos ('Apellido:',linea);
                  numero2:=numero2+10;
                  while linea[numero2]<>'|' do
                  begin
                      numero2:=numero2+1;
                  end;
                  numero2:=numero2-1;
                  cadena:=copy (linea,1,numero2);
             end;
             numero:=numero+1;
        end;
        close (cli);
        numero2:=1;
        writeln ('Datos de la persona:');
        writeln ();
        while (numero2<=length(cadena)) do
        begin
            writeln ();
            write('*');
            while (cadena[numero2+1]<>'|') do
            begin
                 write(cadena[numero2]);
                 numero2:=numero2+1;
            end;
            numero2:=numero2+3;
            writeln ();
            write(' ');
            while (cadena[numero2+1]<>'|') do
            begin
                 write(cadena[numero2]);
                 numero2:=numero2+1;
            end;
            numero2:=numero2+3;
            writeln ();
            write(' ');
            while (numero2<=length(cadena)) do
            begin
                 write(cadena[numero2]);
                 numero2:=numero2+1;
            end;
        end;
        cadena2:=cadena;
    end;
    writeln();
    assign(pel,'peliculas.txt');
    reset (pel);
    writeln();
    writeln ('Peliculas disponibles: ');
    numero2:=0;
    while not eof(pel) do
    begin
         readln (pel,linea);
         i:=length (linea);
         cadena:='';
         numero:=0;
         while (linea[i]<>' ') do
         begin
              cadena:=cadena+linea[i];
              i:=i-1;
         end;
         val (cadena,numero,error);
         if (numero<>0) then
         begin
              i:=1;
              numero2:=1;
              writeln ();
              write('*');
              while (linea[i+1]<>'|') do
              begin
                   write(linea[i]);
                   i:=i+1;
              end;
              i:=i+3;
              writeln ();
              write(' ');
              while (linea[i+1]<>'|') do
              begin
                   write(linea[i]);
                   i:=i+1;
              end;
              writeln ();
         end;
    end;
    close (pel);
    if (numero2<>0) then
    begin
         validar:=false;
         writeln ();
         writeln ('Ingrese el codigo de la pelicula a alquilar:');
         readln(peli.codigo);
         for i:=1 to length(peli.codigo) do
         begin
              peli.codigo[i]:=UPCASE(peli.codigo[i]);
         end;
         while  validar=false do
         begin
              validar:=true;
              if  (codigo_repetido=false) then
              begin
                        writeln('Codigo no encontrado. Ingrese nuemavente dicho valor:');
                   readln(peli.codigo);
                   for i:=1 to length(peli.codigo) do
                   begin
                        peli.codigo[i]:=UPCASE(peli.codigo[i]);
                   end;
                   validar:=false;
              end
              else
              begin
                   assign(pel,'peliculas.txt');
                   reset (pel);
                   numero:=1;
                   while not eof(pel) do
                   begin
                        readln(pel,linea);
                        if (numero=n_linea) and (linea[length(linea)]='0') and (linea[length(linea)-1]=' ') then
                        begin
                             writeln ('Codigo no encontrado. Ingrese nuemavente dicho valor:');
                             readln(peli.codigo);
                             for i:=1 to length(peli.codigo) do
                             begin
                                  peli.codigo[i]:=UPCASE(peli.codigo[i]);
                             end;
                             validar:=false;
                        end;
                             numero:=numero+1;
                   end;
                   close (pel);
              end;
         end;
         clie.codigo_pelicula:=peli.codigo;
         respaldar_pelicula;
         assign (pel,'peliculas.txt');
         reset (pel);
         assign (pel2,'peliculas_backup.txt');
         reset (pel2);
         rewrite (pel);
         numero:=1;
         while not eof(pel2) do
         begin
                   readln (pel2,linea);
              if (numero=n_linea) then
              begin
                   cadena:='';
                   numero2:=length(linea);
                   while (linea [numero2]<>' ') do
                   begin
                        cadena:=linea[numero2]+cadena;
                        numero2:=numero2-1;
                   end;
                   val (cadena,numero2,error);
                   numero2:=numero2-1;
                   while (linea[length(linea)]<>' ') do
                   begin
                        delete(linea,length(linea),1);
                   end;
                   str(numero2,cadena);
                   linea:=linea+cadena;
              end;
              append (pel);
              writeln (pel,linea);
              close (pel);
              numero:=numero+1;
         end;
         close(pel2);
         writeln ('Fecha de alquiler: ');
         ingresar_fecha (clie.day,clie.month,clie.year);
         if (pos('Cedula:',cadena2))=0 then
         begin
             linea:='Cedula: '+clie.cedula+' | '+'Nombre: '+clie.nombre+' | '+'Apellido: '+clie.apellido+' | '+'Fecha de alquiler: '+clie.day+'/'+clie.month+'/'+clie.year+' | Codigo de la pelicula: '+clie.codigo_pelicula;
         end
         else
         begin
             linea:=cadena2+' | '+'Fecha de alquiler: '+clie.day+'/'+clie.month+'/'+clie.year+' | Codigo de la pelicula: '+clie.codigo_pelicula;
         end;
         assign (cli,'clientes.txt');
         reset (cli);
         append (cli);
         writeln (cli,linea);
         close (cli);
         writeln('Registro guardado satisfactoriamente');
    end
    else
    begin
         writeln ('Lo sentimos, no hay peliculas disponibles');
    end;

end;
procedure devolver_pelicula;
var
aux:boolean;
cont,cont2,i,j:integer;
begin
     clrscr;
     writeln ('Ingrese cedula de la persona:');
     readln (clie.cedula);
     for i:=1 to length(clie.cedula) do
     begin
          clie.cedula[i]:=UPCASE(clie.cedula[i]);
     end;
     writeln ('Ingrese codigo de la pelicula:');
     readln (clie.codigo_pelicula);
     for i:=1 to length(clie.codigo_pelicula) do
     begin
          clie.codigo_pelicula[i]:=UPCASE(clie.codigo_pelicula[i]);
     end;
     peli.codigo:=clie.codigo_pelicula;
     aux:=false;
     if (cedula_repetida=false) then
     begin
             writeln ('Cedula no encontrada.');
             aux:=false;
     end
     else
     begin
             respaldar_cliente;
             assign (cli,'clientes.txt');
             reset (cli);
             rewrite(cli);
             assign (cli2,'clientes_backup.txt');
             reset (cli2);
             n_linea:=1;
             while not eof (cli2) do
             begin
                  readln (cli2,linea2);
                  i:=9;
                  j:=1;
                  cont:=0;
                  cont2:=0;
                  while (linea2[i+1]<>'|') do
                  begin
                       if (linea2[i]=clie.cedula[j]) then
                       begin
                            cont:=cont+1;
                       end;
                       i:=i+1;
                       j:=j+1;
                       cont2:=cont2+1;
                  end;
                  if cont=cont2 then
                  begin
                       numero:=length(linea2);
                       cadena:='';
                       while linea2[numero]<>' ' do
                       begin
                            cadena:=linea2[numero]+cadena;
                            numero:=numero-1;
                       end;
                       if clie.codigo_pelicula<>cadena then
                       begin
                           append(cli);
                           writeln (cli,linea2);
                           close(cli);

                       end
                       else if codigo_repetido=true then
                       begin
                            aux:=true;
                            respaldar_pelicula;
                            assign (pel,'peliculas.txt');
                            reset (pel);
                            rewrite(pel);
                            assign (pel2,'peliculas_backup.txt');
                            reset (pel2);
                            numero:=1;
                            while not eof(pel2) do
                            begin
                                 readln (pel2,linea);
                                 if (numero=n_linea) then
                                 begin
                                      cadena:='';
                                      numero2:=length(linea);
                                      while (linea [numero2]<>' ') do
                                      begin
                                           cadena:=linea[numero2]+cadena;
                                           numero2:=numero2-1;
                                      end;
                                      val (cadena,numero2,error);
                                      numero2:=numero2+1;
                                      while (linea[length(linea)]<>' ') do
                                      begin
                                           delete(linea,length(linea),1);
                                      end;
                                      str(numero2,cadena);
                                      linea:=linea+cadena;
                                 end;
                                 append (pel);
                                 writeln (pel,linea);
                                 close (pel);
                                 numero:=numero+1;
                            end;
                            close(pel2);
                       end;
                  end
                  else
                  begin
                       append(cli);
                       writeln (cli,linea2);
                       close(cli);
                  end;
             end;
             close (cli2);
             if aux=false then
             begin
                 writeln ('Codigo no encontrado.');
             end
             else
             begin
                 writeln ('Pelicula devuelta satisfactoriamente');
             end;
          end;
end;
procedure borrar_pelicula;
var
i:integer;
aux:boolean;
begin
    clrscr;
    assign(pel,'peliculas.txt');
    reset (pel);
    writeln ('Lista de peliculas: ');
    numero2:=0;
    while not eof(pel) do
    begin
         readln (pel,linea);
         i:=1;
         numero2:=1;
         writeln ();
         write('*');
         while (linea[i+1]<>'|') do
         begin
              write(linea[i]);
              i:=i+1;
         end;
         i:=i+3;
         writeln ();
         write(' ');
         while (linea[i+1]<>'|') do
         begin
              write(linea[i]);
              i:=i+1;
         end;
         writeln ();
    end;
     close (pel);
     writeln();
     writeln ('Ingrese codigo de la pelicula a eliminar:');
     readln (clie.codigo_pelicula);
     for i:=1 to length(clie.codigo_pelicula) do
     begin
          clie.codigo_pelicula[i]:=UPCASE(clie.codigo_pelicula[i]);
     end;
     peli.codigo:=clie.codigo_pelicula;
     if codigo_repetido=false then
     begin
         writeln ('Codigo no encontrado');
     end
     else
     begin
          assign(cli,'clientes.txt');
          reset (cli);
          aux:=false;
          while not eof (cli) do
          begin
              readln(cli,linea);
              cadena:='';
              numero:=pos ('Codigo de la pelicula',linea);
              numero:=numero+23;
              while numero<=length(linea) do
              begin
                   cadena:=cadena+linea[numero];
                   numero:=numero+1;

              end;
              if (peli.codigo=cadena) then
              begin
                  aux:=true;
                  writeln ('No se puede eliminar la pelicula porque actualmente esta en uso.');
              end;
          end;
          close (cli);
          if aux=false then
          begin
              respaldar_pelicula;
              assign (pel,'peliculas.txt');
              reset(pel);
              rewrite(pel);
              assign (pel2,'peliculas_backup.txt');
              reset(pel2);
              numero:=1;
              while not eof (pel2) do
              begin
                  readln (pel2,linea);
                  if numero<>n_linea then
                  begin
                       append(pel);
                       writeln(pel,linea);
                       close (pel);
                  end;
                  numero:=numero+1;
              end;
              close (pel2);
              writeln ('Pelicula borrada satisfactoriamente.');

          end;

     end;
end;

procedure buscar_pelicula;
var
i:integer;
begin
     writeln ('Ingrese codigo de la pelicula a buscar:');
     readln (peli.codigo);
     for i:=1 to length(peli.codigo) do
     begin
          peli.codigo[i]:=UPCASE(peli.codigo[i]);
     end;
     if codigo_repetido=false then
     begin
         writeln ('Codigo no encontrado');

     end
     else
     begin
         assign (pel,'peliculas.txt');
         reset(pel);
         numero:=1;
         while not eof (pel) do
         begin
             readln (pel,linea);
             if (numero=n_linea) then
             begin
                 i:=1;
                 writeln ();
                 write('Datos de la pelicula:');
                 writeln ();
                 write('*');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 i:=i+3;
                 writeln ();
                 write(' ');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 writeln ();
                 i:=i+3;
                 write(' ');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 writeln ();
                 i:=i+3;
                 write(' ');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 writeln ();
                 i:=i+3;
                 write(' ');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 writeln ();
                 i:=i+3;
                 write(' ');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 numero2:=length(linea);
                 cadena:='';
                 while (linea[numero2]<>' ') do
                 begin
                     cadena:=linea[numero2]+cadena;
                     numero2:=numero2-1;
                 end;
                 val(cadena,numero2,error);
             end;
             numero:=numero+1;
         end;
         close (pel);
         assign (cli,'clientes.txt');
         reset(cli);
         i:=0;
         while not eof (cli) do
         begin
             readln (cli,linea);
             cadena:='';
             numero:=length (linea);
             while linea[numero]<>' ' do
             begin
                 cadena:=linea[numero]+cadena;
                 numero:=numero-1;
             end;
             if peli.codigo=cadena then
             begin
                 i:=i+1;
             end
         end;
         close (cli);
         writeln();
         writeln(' Nr. ejemplares disponibles: ',numero2);
         writeln(' Nr. ejemplares alquilados: ',i);
         writeln(' Total ejemplares registrados: ',numero2+i);
     end;
end;

procedure buscar_genero;
var
   genero:string;
   i:integer;
   aux:boolean;
begin
    clrscr;
    writeln ('Ingrese el genero:');
    readln (genero);
    for i:=1 to length(genero) do
    begin
          genero[i]:=UPCASE(genero[i]);
    end;
    assign (pel,'peliculas.txt');
    reset(pel);
    aux:=false;
    writeln ();
    writeln ('Peliculas relacionadas con el genero ',genero,':');
    writeln();
    while not eof (pel) do
    begin
         readln(pel,linea);
         i:=pos ('Genero: ',linea);
         i:=i+8;
         cadena:='';
         while linea[i+1]<>'|' do
         begin
              cadena:=cadena+linea[i];
              i:=i+1;

         end;
         if (genero=cadena) then
         begin
                 aux:=true;
                 i:=1;
                 writeln();
                 write('*');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 i:=i+3;
                 writeln ();
                 write(' ');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 i:=i+3;
                 while (linea[i+1]<>'|') do
                 begin
                      i:=i+1;
                 end;
                 writeln ();
                 i:=i+3;
                 write(' ');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 writeln ();
                 i:=i+3;
                 write(' ');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 writeln ();
                 i:=i+3;
                 write(' ');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 writeln();

         end;
    end;
    close (pel);
    writeln();
    if aux=false then
    begin
        writeln('Genero no encontrado:');
    end;
end;

procedure listado_alquiladas;
var
   aux:boolean;
   i:integer;
begin
    clrscr;
    assign (cli,'clientes.txt');
    reset (cli);
    writeln('Peliculas alquiladas:');
    writeln();
    aux:=false;
    while not eof (cli) do
    begin
         readln(cli,linea);
         cadena:='';
         numero:=pos ('Codigo de la pelicula',linea);
         numero:=numero+23;
         while numero<=length(linea) do
         begin
              cadena:=cadena+linea[numero];
              numero:=numero+1;
         end;
         peli.codigo:=cadena;
         if codigo_repetido=true then
         begin
             assign (pel,'peliculas.txt');
             reset (pel);
             numero:=1;
             while not eof (pel) do
             begin
                  readln(pel,linea2);
                  if (numero=n_linea) then
                  begin

                       aux:=true;
                       i:=1;
                       writeln();
                       write('*');
                       while (linea2[i+1]<>'|') do
                       begin
                            write(linea2[i]);
                            i:=i+1;
                       end;
                       i:=i+3;
                       writeln ();
                       write(' ');
                       while (linea2[i+1]<>'|') do
                       begin
                            write(linea2[i]);
                            i:=i+1;
                       end;
                       writeln ();
                       i:=i+3;
                       write(' ');
                       while (linea2[i+1]<>'|') do
                       begin
                            write(linea2[i]);
                            i:=i+1;
                       end;
                       writeln ();
                       i:=i+3;
                       write(' ');
                       while (linea2[i+1]<>'|') do
                       begin
                            write(linea2[i]);
                            i:=i+1;
                       end;
                       writeln ();
                       i:=i+3;
                       write(' ');
                       while (linea2[i+1]<>'|') do
                       begin
                            write(linea2[i]);
                            i:=i+1;
                       end;
                       writeln();
                       i:=i+3;
                       write(' ');
                       while (linea2[i+1]<>'|') do
                       begin
                            write(linea2[i]);
                            i:=i+1;
                       end;
                       writeln();

                  end;
                  numero:=numero+1;
             end;
             close(pel);
         end;
    end;
    close(cli);
    writeln();
    if aux=false then
    begin
        writeln ('No hay peliculas alquiladas');
    end;
end;
procedure masd3dias;
var
day,month,year:string;
nm,nm2,nm3,nm4,nm5,nm6:integer;
i:integer;
aux:boolean;
begin
     clrscr;
     writeln('Ingrese la fecha actual:');
     ingresar_fecha(day,month,year);
     val(day,nm,error);
     val(month,nm2,error);
     val(year,nm3,error);
     assign (cli,'clientes.txt');
     reset (cli);
     writeln();
     writeln ('Listado de las peliculas alquiladas de mas de tres (3) dias: ');
     writeln();
     aux:=false;
     while not eof (cli) do
     begin
         readln(cli,linea);
         i:=pos ('Fecha de alquiler:',linea);
         i:=i+19;
         day:='';
         while (linea[i]<>'/') do
         begin
             day:=day+linea[i];
             i:=i+1
         end;
         val(day,nm4,error);
         i:=i+1;
         month:='';
         while (linea[i]<>'/') do
         begin
             month:=month+linea[i];
             i:=i+1
         end;
         val(month,nm5,error);
         i:=i+1;
         year:='';
         while (linea[i]<>' ') do
         begin
             year:=year+linea[i];
             i:=i+1
         end;
         val(year,nm6,error);
         if (nm3>nm6) or ((nm3=nm6) and (nm2>nm5)) or ((nm3=nm6) and (nm2=nm5) and (nm-nm4>=4)) then
         begin
                 aux:=true;
                 i:=1;
                 write('*');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 i:=i+3;
                 writeln ();
                 write(' ');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 i:=i+2;
                 writeln ();
                 write(' ');
                 while (linea[i+1]<>'|') do
                 begin
                      i:=i+1;
                      write(linea[i]);
                 end;
                 writeln ();
                 i:=i+3;
                 write(' ');
                 while (linea[i+1]<>'|') do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 writeln ();
                 i:=i+3;
                 write(' ');
                 while (i<=length(linea)) do
                 begin
                      write(linea[i]);
                      i:=i+1;
                 end;
                 writeln();
                 writeln();
         end;

     end;
     close (cli);
     if (aux=false) then
     begin
         writeln ('No se encontraron coincidencias');
     end;
     writeln();
end;

procedure crear_archivos;
begin
    assign (pel,'peliculas.txt');
    {$I-} 
    reset (pel);
    {$I+}
    if (ioresult<>0) then
    begin
         rewrite (pel)
    end;
    close (pel);
    assign (cli,'clientes.txt');
    {$I-} 
    reset (cli);
    {$I+}
    if (ioresult<>0) then
    begin
         rewrite (cli)
    end;
    close (cli);
end;
begin
   crear_archivos;
   salir:=false;
   writeln();
   writeln('############## Aplicacion SUPERCINE. #############');
   writeln('Menu Principal.');
   writeln();
   while (salir=false) do
   begin
       writeln('Opciones: ');
       writeln('1) Agregar pelicula.');
       writeln('2) Ingresar cliente.');
       writeln('3) Devolver una pelicula.');
       writeln('4) Borrar pelicula.');
       writeln('5) Buscar pelicula.');
       writeln('6) Listado de peliculas por genero.');
       writeln('7) Listado de peliculas alquiladas.');
       writeln('8) Listado de clientes que tengan mas de tres dias con una pelicula alquilada.');
       readln(opcion);
       while (opcion<>'1') and (opcion<>'2') and (opcion<>'3') and (opcion<>'4') and (opcion<>'5') and (opcion<>'6') and (opcion<>'7') and (opcion<>'8') do //Mientras ingrese opcionión inválida...
       begin
            writeln('Error al leer dato de entrada. Ingrese nuevamente la opcionion correcta: ');
            readln(opcion);
       end;
       if (opcion='1') then
       begin
            agregar_pelicula;
       end
       else if opcion=('2') then
       begin
            agregar_cliente;
       end
       else if opcion=('3') then
       begin
            devolver_pelicula;

       end
       else if opcion=('4') then
       begin
            borrar_pelicula;
       end
       else if opcion=('5') then
       begin
            buscar_pelicula;
       end
       else if opcion=('6') then
       begin
            buscar_genero;
       end
       else if opcion=('7') then
       begin
            listado_alquiladas;
       end
       else if opcion=('8') then
       begin
            masd3dias;
       end;
       writeln('Desea salir de la aplicacion? s/n');//Se le pregunta al usuario, si desea salir del programa
       readln(opcion);
       while (opcion<>'s') and (opcion<>'S') and (opcion<>'n') and (opcion<>'N') do //Mientras la opción sea inválida
       begin
         writeln('Opcion invalida, ingrese la opcion correcta.');
         readln(opcion);
       end;
       if (opcion='s') or (opcion='S')then //Si el usuario quiere salir...
       begin
        salir:=TRUE;// A la variable "salir" se le asigna verdadero para que pueda salir de la iteración
       end;
       clrscr;
   end;


end.
