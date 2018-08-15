program cuatroenlinea;

USES crt;

type

  tablero= array [1..6,1..7] of char; //Arreglo en donde se jugará "Cuatro en Línea"

var
  tab:tablero;
  tot_jug,gan,gan2, num,err: integer;//"tot_jug": Variable que contabilizará las partidas jugadas. "gan" y "gan2": Contarán la cantidad de partidas ganadas del jugador 1 y 2 respectivamente. "num" y "err": variables usadas en el principal para la conversion de un valor de tipo cadena a entero
  salir_apl: boolean;//Variable booleana para controlar cuándo culminará la aplicación
  nom_jug1,nom_jug2,opc: string;//"nom_jug1" y "nom_jug": Guardan los nombres de jugador 1 y 2 respectivamente. "opc": contendrá la opción ingresada por el usuario, la cual es solicitada en el principal

procedure estadisticas; //procedimiento para mostrar las estadisticas generales de las partidas jugadas
begin
    clrscr;
    if tot_jug=0 then //Si no se han jugado partidas....
    begin
      writeln('No se han jugado partidas');
    end
    else //De lo contrario, se muestra el listado
    begin
    writeln('Estadisticas generales del juego:');
    writeln();
    writeln('Total de Partidas Jugadas: ',tot_jug);
    writeln();
    writeln('*Jugador 1');
    writeln(' Nombre: ',nom_jug1);
    writeln(' Partidas Ganadas: ',gan);
    writeln(' Empates: ',tot_jug-(gan+gan2)); //Los empates son el resultado de la resta entre el total de partidas jugadas y la suma de las ganadas de los 2 jugadores
    writeln(' Partidas Perdidas: ',gan2);  //Las partidas perdidas de un jugador evidentemente es igual a las ganadas del otro jugador
    writeln();
    writeln('*Jugador 2');
    writeln(' Nombre: ',nom_jug2);
    writeln(' Partidas Ganadas: ',gan2);
    writeln(' Empates: ',tot_jug-(gan+gan2));//Los empates son el resultado de la resta entre el total de partidas jugadas y la suma de las ganadas de los 2 jugadores
    writeln(' Partidas Perdidas: ',gan);  //Las partidas perdidas de un jugador evidentemente es igual a las ganadas del otro jugador
    writeln();
    end;
end;

procedure limpiar_tablero(var tb: tablero); //procedimiento para inicializar el tablero, es decir, asignarle el caracter ' ' a cada posición del mismo. Será invocado al momento de iniciar una partida de "Cuatro en Línea"
   var
      x,y: integer;
   begin
        for x := 1 to 6 do
        begin
             for y := 1 to 7 do
             begin
                  tb[x,y]:= ' ';
             end;
         end;
   end;

procedure dibujar_tablero(tb: tablero); //procedimiento para mostrar por pantalla el tablero para que los jugadores tengan una visión de las fichas colocadas y por colocar
var
   x,y: integer;
begin
   writeln('Tablero del juego');
      writeln();
      writeln('#############################');//Dibujando el tablero
      for x:= 1 to 6 do
      begin
         for y:= 1 to 7 do
         begin
            write('# ');
            write(tb[x,y]);
            write(' ');
         end;
         write('#');
         writeln();
         writeln('#############################');
      end;
end;

function tablero_lleno(tb:tablero): boolean; //funcion booleana que verificará si hay o no, espacio disponible en el tablero para colocar fichas
var
   x,y, cont: integer;
begin
    cont:=0; //contador de celdas no disponibles
    for x:= 1 to 6 do
    begin
        for y:= 1 to 7 do
        begin
            if tb[x,y]<> ' ' then //si este espacio no esta disponible....
            begin
                cont:=cont+1; //lo contabiliza
            end;
        end;
    end;
    if cont=42 then //Como el tablero tiene 42 celdas, y el contador de celdas no disponibles es igual a dicha cantidad...
    begin
       tablero_lleno:=true;
    end
    else //si quedan celdas disponibles
    begin
       tablero_lleno:=false;
    end;
end;

function encontrar_ganador (x,y:integer;tb:tablero):boolean; //Funcion para encontrar ganador en el turno (se pasa por parametro el tablero y las variables "x" e "y" que contienen la posición del tablero en donde el jugador en turno colocó su ficha)

var
  i,j,Acons,Bcons:integer; //"i" y "j": recorren filas y columnas del tablero respectivamente. "Acons" y "Bcons": variables que contabilizan en el tablero las consecusiones de las fichas 'A' y 'B' respectivamente
  encontrado:boolean; //variable que verificará si existe 4 o mas consecusiones en direccion horizontal, vertical y diagonal en el tablero
begin
   Acons:=0;
   Bcons:=0;
   encontrado:=false; //Se inicializan las variables de consecusión y se coloca a la variable encontrado 'false'
   for j:= 1 to 7 do //'For' para recorrer toda la fila correspondiente a la ingresada por el jugador en turno
   begin
      if tb[x,j]='A' then // Si es 'A'
      begin
          Acons:=Acons+1;//Se autoincrementa "Acons"
          Bcons:=0;//Por cada consecución de 'A', se le asigna a la variable "Bcons" 0
      end
      else if tb[x,j]='B' then  // Si es 'B'
      begin
          Bcons:=Bcons+1; //Se autoincrementa "Bcons"
          Acons:=0; //Por cada consecución de 'B', se le asigna a la variable "Acons" 0
      end;
      if (Acons>=4) or (Bcons>=4) then //Si las dos variables ó una de ellas es mayor o igual que 4. es decir, que exista 4 consecusiones de 'B' o 'A'
      begin
           encontrado:=true;//Se le asigna verdadero a "encontrado"
      end;
      if tb[x,j]=' ' then //Si se encuentra un espacio en el recorrido
      begin
           Acons:=0;
           Bcons:=0;//Se deben inicializar las variables "Acons" y "Bcons"
      end;
   end;
   Acons:=0;
   Bcons:=0;//Se inicializan las variables de consecusión
   for i:= 1 to 6 do //'For' para recorrer toda la columna correspondiente a la ingresada por el jugador en turno
   begin
      if tb[i,y]='A' then //Si es 'A'
      begin
        Acons:=Acons+1;//Se autoincrementa "Acons"
        Bcons:=0; //Por cada consecución de 'A', se le asigna a la variable "Bcons" 0
      end
      else if tb[i,y]='B' then // Si es 'B'
      begin
         Bcons:=Bcons+1;//Se autoincrementa "Bcons"
         Acons:=0;   //Por cada consecución de 'B', se le asigna a la variable "Acons" 0
      end;
      if (Acons>=4) or (Bcons>=4) then//Si las dos variables ó una de ellas es mayor o igual que 4. es decir, que exista 4 consecusiones de 'B' o 'A'
      begin
           encontrado:=true; //Se le asigna verdadero a "encontrado"
      end;
      if tb[i,y]=' ' then //Si se encuentra un espacio en el recorrido
      begin
           Acons:=0;
           Bcons:=0;//Se deben inicializar las variables "Acons" y "Bcons"
      end;
   end;
   Acons:=0;
   Bcons:=0;//Se inicializan las variables de consecusión
   i:=x;
   j:=y;//A las variables "i" e "j" se les asignan los valores que contienen las variables "x" e "y" respectivamente, éstas últimas almacenan la posición del tablero en donde colocó su ficha, el jugador de turno
   while (i>1) and (j>1) do //'while' para dirigirnos de manera diagonal hasta quedar en la primera columna y/o primera fila para empezar el recorrido
   begin
       i:=i-1;
       j:=j-1;
   end;
   while (j<=7) and (i<=6) do //Recorrido diagonal de arriba hacia abajo, hasta llegar a uno de los extremos del tablero
   begin
      if tb[i,j]='A' then //Si es 'A'
      begin
        Acons:=Acons+1;//Se autoincrementa "Acons"
        Bcons:=0; //Por cada consecución de 'A', se le asigna a la variable "Bcons" 0
      end
      else if tb[i,j]='B' then //Si es 'B'
      begin
         Bcons:=Bcons+1; //Se autoincrementa "Bcons"
         Acons:=0;  //Por cada consecución de 'B', se le asigna a la variable "Acons" 0
      end;
      if (Acons>=4) or (Bcons>=4) then //Si las dos variables ó una de ellas es mayor o igual que 4. es decir, que exista 4 consecusiones de 'B' o 'A'
      begin
           encontrado:=true; //Se le asigna verdadero a "encontrado"
      end;

      if tb[i,j]=' ' then //Si se encuentra un espacio en el recorrido
      begin
           Acons:=0;
           Bcons:=0;//Se deben inicializar las variables "Acons" y "Bcons"
      end;
      i:=i+1;
      j:=j+1;
   end;
   Acons:=0;
   Bcons:=0;//Se inicializan las variables de consecusión
   i:=x;
   j:=y;//A las variables "i" e "j" se les asignan los valores que contienen las variables "x" e "y" respectivamente, éstas últimas almacenan la posición del tablero en donde colocó su ficha, el jugador de turno
   while (i<7) and (j>1) do //'while' para dirigirnos de manera diagonal hasta quedar en la primera columna y/o última fila para empezar el recorrido
   begin
       i:=i+1;
       j:=j-1;
   end;

   while (j<=7) and (i>=1) do //Recorrido diagonal de abajo hacia arriba, hasta llegar a uno de los extremos del tablero
   begin
      if tb[i,j]='A' then //Si es 'A'
      begin
        Acons:=Acons+1;//Se autoincrementa "Acons"
        Bcons:=0; //Por cada consecución de 'A', se le asigna a la variable "Bcons" 0
      end
      else if tb[i,j]='B' then //Si es 'B'
      begin
         Bcons:=Bcons+1; //Se autoincrementa "Bcons"
         Acons:=0;  //Por cada consecución de 'B', se le asigna a la variable "Acons" 0
      end;
      if (Acons>=4) or (Bcons>=4) then //Si las dos variables ó una de ellas es mayor o igual que 4. es decir, que exista 4 consecusiones de 'B' o 'A'
      begin
           encontrado:=true; //Se le asigna verdadero a "encontrado"
      end;

      if tb[i,j]=' ' then //Si se encuentra un espacio en el recorrido
      begin
           Acons:=0;
           Bcons:=0;//Se deben inicializar las variables "Acons" y "Bcons"
      end;
      i:=i-1;
      j:=j+1;
   end;
   encontrar_ganador:=encontrado; //El valor que contenga la variable "encontrado", después de los 4 recorridos (horizantal, vertical y diagonales hacia arriba y hacia abajo), se le asignará a la función
end;

procedure perfil_jug1; //Procedimiento para modificar el nombre del jugador 1

begin
    clrscr;
    writeln('Perfil Jugador 1'); //Datos del jugador 1
    writeln('Nombre actual de jugador 1: ',nom_jug1);
    writeln();
    writeln('Ingrese el nuevo nombre del jugador 1: ');
    readln(nom_jug1);
    writeln();
    while nom_jug1 = nom_jug2 do //Validación para que no sean repetidos los nombres de los jugadores
    begin

        writeln('Nombre repetido, ingrese nuevamente el nombre del jugador 1: ');
        readln(nom_jug1);
    end;
    writeln('El nombre del jugador 1 fue guardado exitosamente');
end;

procedure perfil_jug2; //Procedimiento para modificar el nombre del jugador 2

begin
    clrscr;
    writeln('Perfil Jugador 2'); //Datos del jugador 2
    writeln('Nombre actual de jugador 2: ',nom_jug2);
    writeln();
    writeln('Ingrese el nuevo nombre del jugador 2: ');
    readln(nom_jug2);
    writeln();
    while nom_jug1 = nom_jug2 do //Validación para que no sean repetidos los nombres de los jugadores
    begin

        writeln('Nombre repetido, ingrese nuevamente el nombre del jugador 2: ');
        readln(nom_jug2);

    end;
    writeln('El nombre del jugador 2 fue guardado exitosamente');
end;


procedure jugar;//procedimiento para jugar "Cuatro el Línea"

var


   tmpstr,opcion: string; //"tmpstr": para conversión de cadena a entero. "opcion": guarda la opción que ingresará el usuario si desea jugar otra partida
   x,y,cont_turn,error: integer; //"x" e "y": variables que almacenarán la fila y columna (respectivamente), que ingresará el jugador en turno. "cont_turn": variable que indicará cuál jugador está de turno para colocar su ficha respectiva. "error": usada en la conversión de cadena a entero
   salir_partida,validar_turno,disp: boolean; //Variable booleana para controlar si el usuario desea jugar otra partida una vez culminada la misma

begin

    limpiar_tablero (tab);//se inicializa el tablero para jugar
    gotoxy(1,1);
    salir_partida:=FALSE;
    cont_turn:=0;//inicializacion de variables
    while salir_partida = FALSE do  //Mientras se este jugando....
    begin

      clrscr();
      dibujar_tablero(tab); //se muestra el tablero
      writeln();
      cont_turn:=cont_turn+1; //se incrementa en uno el contador de turnos
      cont_turn:= cont_turn mod 2;//funcion mod
      if cont_turn = 1 then //si es par
      begin
         writeln('Turno del jugador de nombre: ',nom_jug1);//juega jugador 1
      end
      else// si no, juega el 2do
      begin
         writeln('Turno del jugador de nombre: ',nom_jug2);
      end;

      writeln('Ingrese el numero de la columna (del 1 al 7)');//se pide la columna
      readln(tmpstr);
      val(tmpstr, y, error);//Se lee el valor ingresado por el usuario y se transforma dicho valor a entero
      validar_turno:=false;
      while validar_turno = false do //'while' para validar turno, es decir, que no ingrese valores no numéricos ni números fuera del rango de las columnas del tablero(mayor que 7 y menor que 1). Adicionalmente, en caso de que la columna no haya espacio disponible para colocar fichas
      begin
          while (error<>0) or (y<=0) or (y>=8)  do //Mientras el valor no es numerico o está fuera de rango.....
          begin
              writeln('Error, el numero de la columna debe ser un numero que oscile entre 1 y 7.Ingrese nuevamente dicho valor');
              readln(tmpstr);
              val(tmpstr, y, error);
          end;
          disp:=false;
          x:=6;
          while (x>=1) and (disp=false) do  //Se recorre de abajo a arriba, la columna ingresada por el jugador de turno
          begin
             if tab[x,y]=' ' then //Si está disponible
             begin
                 disp:=true;
                 if cont_turn = 1 then //Si está de turno el jugador 1
                 begin
                      tab[x,y]:= 'A';
                 end
                 else // Si no
                 begin
                      tab[x,y]:= 'B';
                 end;

             end
             else//si no
             begin
                 x:=x-1; //se verifica la siguiente
             end;
          end;
          if (disp=false) then //Si no se encontro disponibilidad...
          begin
              writeln('Error. no puede colocar mas fichas en esta columna. Ingrese nuevamente el numero de la columna (del 1 al 7).');
              readln(tmpstr);
              val(tmpstr, y, error);
          end;
          validar_turno:=disp;//Dependieno del valor de "disp", se le asigna a "validar_turno"

      end;
      if encontrar_ganador(x,y,tab)=true then //Si el jugador de turno, logró las conseusiones
      begin
          clrscr();
          dibujar_tablero(tab);//Se muestra el tablero para que se pueda ver la consecusión ganadora
          writeln();
          writeln('Fin de la partida');
          tot_jug:=tot_jug+1; //Se incrementa en uno las partidas jugadas
          if cont_turn = 1 then //Se muestra quién ganó
          begin
               writeln('Jugador Ganador: ',nom_jug1);
                gan:=gan+1; //Si ganó el jugador 1, se incrementa en 1 gan
          end
          else
          begin
               writeln('Jugador Ganador: ',nom_jug2);
               gan2:=gan2+1; //Si ganó el jugador 2, se incrementa en 1 gan2
          end;
          writeln('Desea jugar otra partida? s/n');//Se le pregunta al usuario, si desea jugar otra partida
          readln(opcion);
          while (opcion<>'s') and (opcion<>'S') and (opcion<>'n') and (opcion<>'N') do //Mientras la opción sea inválida
          begin
              writeln('Opcion invalida, ingrese la opcion correcta.');
              readln(opcion);
          end;
          if (opcion='n') or (opcion='N') then //Si no quiere jugar más...
          begin
              salir_partida:=TRUE; //a "salir_partida" se le asigna verdadero para que pueda salir de la iteración de las partidas
          end;
          cont_turn:=0; //Se inicializa el contador de turnos
          limpiar_tablero (tab); //Se limpia el tablero
          clrscr;
      end
      else if tablero_lleno(tab)=true then //Si no se encontró ganador y hay tablero lleno....
      begin
          clrscr();
          dibujar_tablero(tab);//se muestra por pantalla el tablero lleno
          tot_jug:=tot_jug+1;//Se incrementa en uno, las partidas jugadas
          writeln('Tablero lleno. No se puede colocar mas fichas. Hay un empate.');
          writeln('Desea jugar otra partida? s/n'); //Se le pregunta al usuario, si desea jugar otra partida
          readln(opcion);
          while (opcion<>'s') and (opcion<>'S') and (opcion<>'n') and (opcion<>'N') do  //Mientras la opción sea inválida
          begin
              writeln('Opcion invalida, ingrese la opcion correcta.');
              readln(opcion);
          end;
          if (opcion='n') or (opcion='N') then //Si no quiere jugar más...
          begin
              salir_partida:=TRUE; //a "salir_partida" se le asigna verdadero para que pueda salir de la iteración de las partidas
          end;
          cont_turn:=0; //Se inicializa el contador de turnos
          limpiar_tablero (tab); //Se limpia el tablero
          clrscr;
      end;
   end;

end;

begin //principal
     tot_jug:=0;
     gan:=0;
     gan2:=0;//Se inicializan las variables "tot_jug", "gan" y "gan2"
     salir_apl:=false; //Se le asigna falso a "salir_apl" para que pueda entrar en la iteración de la aplicación
     nom_jug1:='Jugador1';
     nom_jug2:='Jugador2';//Valores por defecto a las variables "nom_jug1" y "nom_jug2"
     writeln('Bienvenidos al juego "Cuatro en linea"');
     writeln();
     while salir_apl=false do //Mientras esté en la iteración de la aplicación
     begin

        writeln('Menu de Opciones: '); //Se le muestra el abanico de opciones
        writeln();
        writeln('1- Actualizar perfil de Jugador 1.');
        writeln('2- Actualizar perfil de Jugador 2.');
        writeln('3- Jugar.');
        writeln('4- Estadisticas Generales.');
        readln(opc);
        while (opc<>'1') and (opc<>'2') and (opc<>'3') and (opc<>'4') do //Mientras ingrese opción inválida...
        begin
           writeln('Error al leer dato de entrada. Ingrese nuevamente la opcion correcta: ');
           readln(opc);
        end;
        val (opc,num,err);//Se convierte a entero la opción ingresada por el usuario para un mejor manejo de datos
        case num of
        1:  perfil_jug1;//si eligió '1', se invoca el método para actualizar el perfil del jugador 1
        2:  perfil_jug2;//si eligió '2', se invoca el método para actualizar el perfil del jugador 2
        3:  jugar; //si eligió '3', se invoca el método de jugar
        4: estadisticas;// si invoca el método de las estadisticas
        end;
        writeln('Desea salir de la aplicacion? s/n');//Se le pregunta al usuario, si desea salir del programa
        readln(opc);
        while (opc<>'s') and (opc<>'S') and (opc<>'n') and (opc<>'N') do //Mientras la opción sea inválida
        begin
           writeln('Opcion invalida, ingrese la opcion correcta.');
           readln(opc);
        end;
        if (opc='s') or (opc='S') then //Si el usuario quiere salir...
        begin
           salir_apl:=TRUE;// A la variable "salir_apl" se le asigna verdadero para que pueda salir de la iteración
        end;
        clrscr;

     end;

end.
