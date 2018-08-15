USES crt;
type
arr= array[1..36] of string;

var
opc: string;
salir_apl:boolean;
num,err,ind_univ,ind_a,ind_b,ind_c,ind_res:integer;
(*
num y err: para la conversión a entero a partir de un valor de tipo cadena
ind_univ,ind_a,ind_b,ind_c e ind_res: que dicen la cantidad de elementos que contienen el conjunto universo,a,b,c y resultado respectivamente

*)
elementos,universo,a,b,c,resultado: arr;  //todos los conjuntos

procedure inicializar; //procedimiento para incializar el arreglo de elementos
begin
    elementos[1]:='0';elementos[2]:='1';elementos[3]:='2';elementos[4]:='3';elementos[5]:='4';elementos[6]:='5';elementos[7]:='6';elementos[8]:='7';elementos[9]:='8';elementos[10]:='9';
    elementos[11]:='A';elementos[12]:='B';elementos[13]:='C';elementos[14]:='D';elementos[15]:='E';elementos[16]:='F';elementos[17]:='G';elementos[18]:='H';elementos[19]:='I';elementos[20]:='J';
    elementos[21]:='K';elementos[22]:='L';elementos[23]:='M';elementos[24]:='N';elementos[25]:='O';elementos[26]:='P';elementos[27]:='Q';elementos[28]:='R';elementos[29]:='S';elementos[30]:='T';
    elementos[31]:='U';elementos[32]:='V';elementos[33]:='W';elementos[34]:='X';elementos[35]:='Y';elementos[36]:='Z';
end;

function busqueda(elementos:arr;valor:string):boolean;
var
   aux:boolean;
   i:integer;
begin
    aux:=false;
    for i:=1 to 36 do
    begin
        if elementos[i]=valor then
        begin
            aux:=true;
        end;
    end;
    busqueda:=aux;//y la función devuelve el valor de aux
end;

function repetido(arreglo:arr;valor:string;ind:integer):boolean;//función booleana que verifica si hay una coincidencia en un arreglo en relación a un valor determinado
var
   i:integer;
   aux:boolean;
begin
    aux:=false;
    i:=1;
    while (i<ind) do //se recorre el arreglo hasta ind, donde ind nos dice la cantidad de posisciones que ocupa un arreglo en específico
    begin
        if (arreglo[i]=valor) then //si coincide...
        begin
            aux:=true; //aux se le asigna verdadero
        end;
        i:=i+1;
    end;
    repetido:=aux; //la función devuelve el valor de aux
end;
procedure mostrarconjunto(arreg:arr;ind:integer); //procedimiento para mostrar todos los valores de un conjunto determinado
var
   i:integer;
begin
    for i:=1 to ind do
    begin
        write(arreg[i]);
        if (i<>ind) then
        begin
             write('-');
        end;
    end;
end;
procedure ingresar_universo; //procedimiento para igresar os valores del conjunto universo
var
   valor:string;
   i,j:integer;
   interr:boolean;
begin
    writeln('Ingrese la cantidad de elementos que conformara el universo (Min. 5, Max. 36)');
    readln(valor);//se pide la cantidad de valores
    val (valor,ind_univ,err);//aquí se convierte a entero el valor previamente capturado
    while (err<>0) or (ind_univ<5) or (ind_univ>36) do //minetras que exista un error en dicha conversión o el valor se encuentra fuera de rango (5 y 36)
    begin
        writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 5 y 36. Ingrese nuevamente dicho valor');
        readln(valor);
        val (valor,ind_univ,err);//...se pide de nuevo el valor y se realiza la conversión a entero
    end;
    i:=1;
    while (i<=ind_univ) do//mientras para ir llenando uno a uno los elementos del conjunto universo
    begin
        writeln('Ingrese el valor nr. ',i);
        readln(valor);
        valor:=UpCase(valor);//se ingresa el valor y se convierte a mayúscula
        while NOT busqueda(elementos,valor) or (repetido(universo,valor,i)) do//mientras que dicho valor no se encuentre en el arreglo principal o ya fue ingresado en el universo...
        begin
             writeln('Error, valor no encontrado o ya fue ingresado en el conjunto universo. Ingrese nuevamente dicho valor nr. ',i);
             readln(valor);
             valor:=UpCase(valor); //se pide nuevamente el valor
        end;
        universo[i]:=valor;//una vez validado el valor se guarda en el universo
        interr:=false;//a interr se le asigna falso para proceder al proceso de ordenación burbuja
        while (interr=false) do
        begin
            interr:=true;//al ingresar a la interación, a interr se le asigna verdadero
            for j:=1 to i-1 do
            begin
                if (universo[j]>universo[j+1]) then//si el valor de la posición actual es mayor al de la siguiente...
                begin
                   valor:=universo[j];
                   universo[j]:=universo[j+1];
                   universo[j+1]:=valor;
                   interr:=false;//se realiza un intercambio de valores y a interr se le asigna false para otra iteración
                end
            end;
        end;//Nota: esta iteración culmina cuando interr es verdadero, es decir, ya cuando todos los elementos del arreglo estén ordenados de menor a mayor
        i:=i+1;
    end;
    writeln('Y asi queda el conjunto universo: ');
    mostrarconjunto(universo,ind_univ);//se muestra el conjunto universo
end;
procedure union_ab;//procedimiento para implementar la unión entre los conjuntos a y b(dicha unión será almacenada en el arreglo resultado), una vez ingresados los valores por el usuario
var
   i:integer;
   aux:string;
   interr:boolean;
begin
    for i:=1 to ind_a do //se recorre el conjunto a
    begin
         if (not repetido(resultado,a[i],ind_res)) then //si el valor no se encuentra en resultado
         begin
             resultado[ind_res]:=a[i];
             ind_res:=ind_res+1;//se ingresa en resultado y se incrementa en 1 su índice indice
         end;
    end;
    for i:=1 to ind_b do //lo mismo se realiza con el conjunto b
    begin
         if (not repetido(resultado,b[i],ind_res)) then
         begin
             resultado[ind_res]:=b[i];
             ind_res:=ind_res+1;
         end;
    end;
    ind_res:=ind_res-1;
    i:=1;
    interr:=false;
    while (interr=false) do  //burbuja con el resultado...
    begin
         interr:=true;
         for i:=1 to ind_res-1 do
         begin
           if (resultado[i]>resultado[i+1]) then
           begin
                aux:=resultado[i];
                resultado[i]:=resultado[i+1];
                resultado[i+1]:=aux;
                interr:=false;
           end;
         end;
    end;
end;
procedure interseccion_ab;//procedimiento que verifica los elementos coincidentes en a y b (dichas coincidencias se guardan en resultado), una vez ingresados los valores por el usuario
var
   i,j:integer;
   enc:boolean;
begin
     ind_res:=0;
     for i:=1 to ind_a do//recorrido del conjunto a
     begin
         enc:=false; //enc por defecto se le asigna falso para inciar la búsqueda
         for j:=1 to ind_b do //recorrido del conjunto b
         begin
             if a[i]=b[j] then//si hay coincidencia
             begin
                 enc:=true;
             end;
         end;
         if enc then//cuando enc es verdadero, quiere decir que hubo una coincidencia
         begin
             ind_res:=ind_res+1;
             resultado[ind_res]:=a[i];//se le asigna a resultado el valor coincidente
         end;
     end;
end;
procedure interseccion_abc;//procedimiento que verifica los elementos coincidentes en a,b y c (dichas coincidencias se guardan en resultado), una vez ingresados los valores por el usuario
var
   i,j,k:integer;
begin
     ind_res:=0;
     for i:=1 to ind_a do //recorrido de a
     begin
         k:=0;
         for j:=1 to ind_b do
         begin
             if a[i]=b[j] then //si coinicide a con b
             begin
                 k:=k+1; //a k le sumo 1
             end;
         end;
         for j:=1 to ind_c do
         begin
             if a[i]=c[j] then//si coinicide a con c
             begin
                 k:=k+1;//a k le sumo 1
             end;
         end;
         if k=2 then// cuando k vale 2, implica que coincidió que el valor de a coincidió con alguno delb y del c, y por ende....
         begin
             ind_res:=ind_res+1;
             resultado[ind_res]:=a[i];//se guarda el valor en resultado
         end;
     end;
end;
procedure union_abc;//similar al procedimiento union_ab, con la diferecia de la inclusión del conjunto c
var
   i:integer;
   aux:string;
   interr:boolean;
begin
    for i:=1 to ind_a do
    begin
         if (not repetido(resultado,a[i],ind_res)) then
         begin
             resultado[ind_res]:=a[i];
             ind_res:=ind_res+1;
         end;
    end;
    for i:=1 to ind_b do
    begin
         if (not repetido(resultado,b[i],ind_res)) then
         begin
             resultado[ind_res]:=b[i];
             ind_res:=ind_res+1;
         end;
    end;
    for i:=1 to ind_c do
    begin
         if (not repetido(resultado,c[i],ind_res)) then
         begin
             resultado[ind_res]:=c[i];
             ind_res:=ind_res+1;
         end;
    end;
    ind_res:=ind_res-1;
    i:=1;
    interr:=false;
    while (interr=false) do
    begin
         interr:=true;
         for i:=1 to ind_res-1 do
         begin
           if (resultado[i]>resultado[i+1]) then
           begin
                aux:=resultado[i];
                resultado[i]:=resultado[i+1];
                resultado[i+1]:=aux;
                interr:=false;
           end;
         end;
    end;
end;
procedure llenarconjunto(var conj:arr;var ind:integer);//procedimiento similar al ingresar_universo para llenar los datos de un conjunto específico (a, b ó c)
var
   valor:string;
   i,j:integer;
   interr:boolean;
begin
       i:=1;
       while (i<=ind) do
       begin
        writeln('Ingrese el valor nr. ',i);
        readln(valor);
        valor:=UpCase(valor);
        while NOT busqueda(universo,valor) or (repetido(conj,valor,i)) do
        begin
             writeln('Error, valor no encontrado en el conjunto universo o ya fue ingresado en el conjunto. Ingrese nuevamente dicho valor nr. ',i);
             readln(valor);
             valor:=UpCase(valor);
        end;
        conj[i]:=valor;
        interr:=false;
        while (interr=false) do
        begin
            interr:=true;
            j:=1;
            while j<i do
            begin
                if (conj[j]>conj[j+1]) then
                begin
                   valor:=conj[j];
                   conj[j]:=conj[j+1];
                   conj[j+1]:=valor;
                   interr:=false;
                end;
                j:=j+1;
            end;
         end;
         i:=i+1;
        end;
end;
procedure union;//procedimiento para implementar al unión de conjuntos
var
   valor:string;
begin
    ingresar_universo;//se ingresa el universo
    writeln();
    writeln('A continuacion teclee "a", si desee realizar la union con 2 conjuntos, o "b" si lo desea con 3:');
    readln(valor);
    valor:=UpCase(valor);
    while (valor<>'A') and (valor<>'B') do//validar ingreso de opción
    begin
        writeln('Opcion incorrecta. Ingrese nuevamente dicho valor.');
        readln(valor);
        valor:=UpCase(valor);
    end;
    if (valor='A') then //si desea trabajar con 2 conjuntos...
    begin
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "A" (Min. 1, Max. ',ind_univ,').');
       readln(valor);
       val (valor,ind_a,err);//se pide la cantidad de conjuntos de a y se transforma a entero
       while (err<>0) or (ind_a<1) or (ind_univ<ind_a) do //mientras que haya un error en la conversión o el número está fuera de rango (menor que 1 o mayor que la cantidad de valores del universo)...
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_a,err); //nuevamente se pide el valor para su respectiva conversión a entero
       end;
       llenarconjunto(a,ind_a);//se llena el conjunto a
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "B" (Min. 1, Max. ',ind_univ,').');//lo mismo para el b
       readln(valor);
       val (valor,ind_b,err);
       while (err<>0) or (ind_b<1) or (ind_univ<ind_b) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_b,err);
       end;
       llenarconjunto(b,ind_b);
        ind_res:=1;
        union_ab;//una vez obtenidos los conjuntos, se invoca el procedimiento union_ab
        write('*Conjunto "A": ');
        mostrarconjunto(a,ind_a);
        writeln();
        write('*Conjunto "B": ');
        mostrarconjunto(b,ind_b);
        writeln();
        write('*Union entre "A" y "B": ');
        mostrarconjunto(resultado,ind_res);
        writeln();
        //se muestra conjunto a y b, y su unión
    end
    else //si se van a trabajar con 3 conjuntos....
    begin
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "A" (Min. 1, Max. ',ind_univ,').'); //conjunto a
       readln(valor);
       val (valor,ind_a,err);
       while (err<>0) or (ind_a<1) or (ind_univ<ind_a) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_a,err);
       end;
       llenarconjunto(a,ind_a);
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "B" (Min. 1, Max. ',ind_univ,').');  //conjunto b
       readln(valor);
       val (valor,ind_b,err);
       while (err<>0) or (ind_b<1) or (ind_univ<ind_b) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_b,err);
       end;
       llenarconjunto(b,ind_b);
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "C" (Min. 1, Max. ',ind_univ,').'); //conjunto c
       readln(valor);
       val (valor,ind_c,err);
       while (err<>0) or (ind_c<1) or (ind_univ<ind_c) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_c,err);
       end;
       llenarconjunto(c,ind_c);
        ind_res:=1;
        union_abc; //una vez obtenidos los tres conjuntos, se invoca el procedimiento union_abc
        write('*Conjunto "A": ');
        mostrarconjunto(a,ind_a);
        writeln();
        write('*Conjunto "B": ');
        mostrarconjunto(b,ind_b);
        writeln();
        write('*Conjunto "C": ');
        mostrarconjunto(c,ind_c);
        writeln();
        write('*Union entre "A", "B" y "C": ');
        mostrarconjunto(resultado,ind_res);
        writeln();
        //se muestra conjunto a ,b y c, y su unión
    end;
end;
procedure complemento;//procedimiento que permite determinar el complemento de un conjunto
var
   valor:string;
   i,j:integer;
   enc:boolean;
begin
    ingresar_universo;
    writeln();
    writeln('Ingrese la cantidad de elementos que conformara el conjunto a complementar (Min. 1, Max. ',ind_univ,').');//conjunto a complementar
    readln(valor);
    val (valor,ind_a,err);
    while (err<>0) or (ind_a<1) or (ind_univ<ind_a) do
    begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_a,err);
    end;
    llenarconjunto(a,ind_a);//se llena el conjunto
    writeln();
    writeln('*Conjunto "A": ');
    mostrarconjunto(a,ind_a); // se muestra dicho conjunto
    writeln();
    ind_res:=0;
    for i:=1 to ind_univ do // iteración para proceder a comparar los elementos del universo que no coincidan con a
    begin
         enc:=false;
        for j:=1 to ind_a do //recorrido
        begin
             if universo[i]=a[j] then
             begin
                 enc:=true;
             end;
        end;
        if not enc then//si no hubo coincidencia
        begin
            ind_res:=ind_res+1;
            resultado[ind_res]:=universo[i];//se guarda el valor en resultado
        end;
    end;
    writeln('*Complemento del Conjunto "A": ');
    if ind_res<>0 then //si hay valores en el conjunto resultado....
    begin
       mostrarconjunto(resultado,ind_res); //...se muestra dicho conjunto
    end
    else //...de lo contrario arroja el siguiente mensaje:
    begin
        writeln('Conjunto vacio, lo que quiere decir que dicho conjunto no posee complemento en relacion al conjunto universo.');
    end;
    writeln();
end;
procedure interseccion;//similar al conjunto pero con la diferencia que se invoca los procedimientos interseccion_ab e interseccion_abc
var
   valor:string;
begin
    ingresar_universo;
    writeln();
    writeln('A continuacion teclee "a", si desee realizar la interseccion con 2 conjuntos, o "b" si lo desea con 3:');
    readln(valor);
    valor:=UpCase(valor);
    while (valor<>'A') and (valor<>'B') do
    begin
        writeln('Opcion incorrecta. Ingrese nuevamente dicho valor.');
        readln(valor);
        valor:=UpCase(valor);
    end;
    if (valor='A') then
    begin
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "A" (Min. 1, Max. ',ind_univ,').');
       readln(valor);
       val (valor,ind_a,err);
       while (err<>0) or (ind_a<1) or (ind_univ<ind_a) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_a,err);
       end;
       llenarconjunto(a,ind_a);
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "B" (Min. 1, Max. ',ind_univ,').');
       readln(valor);
       val (valor,ind_b,err);
       while (err<>0) or (ind_b<1) or (ind_univ<ind_b) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_b,err);
       end;
       llenarconjunto(b,ind_b);
        ind_res:=0;
        interseccion_ab;
        write('*Conjunto "A": ');
        mostrarconjunto(a,ind_a);
        writeln();
        write('*Conjunto "B": ');
        mostrarconjunto(b,ind_b);
        writeln();
        write('*Interseccion entre "A" y "B": ');
        if ind_res<>0 then
        begin
             mostrarconjunto(resultado,ind_res);
        end
        else
        begin
            writeln('Conjunto vacio. Lo que quiere decir que no existe interseccion entre los conjuntos "A" y "B"');
        end;
        writeln();
    end
    else
    begin
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "A" (Min. 1, Max. ',ind_univ,').');
       readln(valor);
       val (valor,ind_a,err);
       while (err<>0) or (ind_a<1) or (ind_univ<ind_a) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_a,err);
       end;
       llenarconjunto(a,ind_a);
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "B" (Min. 1, Max. ',ind_univ,').');
       readln(valor);
       val (valor,ind_b,err);
       while (err<>0) or (ind_b<1) or (ind_univ<ind_b) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_b,err);
       end;
       llenarconjunto(b,ind_b);
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "C" (Min. 1, Max. ',ind_univ,').');
       readln(valor);
       val (valor,ind_c,err);
       while (err<>0) or (ind_c<1) or (ind_univ<ind_c) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_c,err);
       end;
       llenarconjunto(c,ind_c);
        ind_res:=0;
        interseccion_abc;
        write('*Conjunto "A": ');
        mostrarconjunto(a,ind_a);
        writeln();
        write('*Conjunto "B": ');
        mostrarconjunto(b,ind_b);
        writeln();
        write('*Conjunto "C": ');
        mostrarconjunto(c,ind_c);
        writeln();
        write('*Interseccion entre "A", "B" y "C": ');
        if ind_res<>0 then
        begin
             mostrarconjunto(resultado,ind_res);
        end
        else
        begin
            writeln('Conjunto vacio. Lo que quiere decir que no existe interseccion entre los conjuntos "A", "B" y "C"');
        end;
        writeln();
    end;
end;
procedure diferencia; //procedimiento que calcula los elementos del conjunto a que no están en b
var
   i,j:integer;
   enc:boolean;
   valor:string;
begin
    ingresar_universo;
    writeln('Ingrese la cantidad de elementos que conformara el conjunto "A" (Min. 1, Max. ',ind_univ,').');//conjunto a
    readln(valor);
    val (valor,ind_a,err);
    while (err<>0) or (ind_a<1) or (ind_univ<ind_a) do
    begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_a,err);
    end;
    llenarconjunto(a,ind_a);
    writeln('Ingrese la cantidad de elementos que conformara el conjunto "B" (Min. 1, Max. ',ind_univ,').'); //conjunto b
    readln(valor);
    val (valor,ind_b,err);
    while (err<>0) or (ind_b<1) or (ind_univ<ind_b) do
    begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_b,err);
    end;
    llenarconjunto(b,ind_b);
    write('*Conjunto "A": ');
    mostrarconjunto(a,ind_a);
    writeln();
    write('*Conjunto "B": ');
    mostrarconjunto(b,ind_b);
    writeln();
    //se muestran conjuntos a y b
    ind_res:=0;
    for i:=1 to ind_a do //se recorre a
    begin
         enc:=false;
        for j:=1 to ind_b do //se recorre b
        begin
             if a[i]=b[j] then
             begin
                 enc:=true;
             end;
        end;
        if not enc then //si no hubo coincidencia
        begin
            ind_res:=ind_res+1;
            resultado[ind_res]:=a[i]; //se guarda en resultado
        end;
    end;
    write('*Diferencia entre los conjuntos "A" y "B": ');
    if ind_res<>0 then//si hay elementos en resultado
    begin
         mostrarconjunto(resultado,ind_res);
         writeln();
    end
    else //de lo contrario, se imprime este mensaje
    begin
         writeln('No existe diferencia ya que "A" es subconjunto de "B"');
    end;
end;
procedure dif_sim; //procedimiento para determinar la diferencia entre los conjuntos
var
   i,j:integer;
   enc,interr:boolean;
   valor:string;
begin
   ingresar_universo;//datos del universo
    writeln();
    writeln('A continuacion teclee "a", si desee realizar la diferencia simetrica con 2 conjuntos, o "b" si lo desea con 3:');
    readln(valor);
    valor:=UpCase(valor);
    while (valor<>'A') and (valor<>'B') do
    begin
        writeln('Opcion incorrecta. Ingrese nuevamente dicho valor.');
        readln(valor);
        valor:=UpCase(valor);
    end;
    if (valor='A') then //si se trabaja con 2 conjuntos
    begin
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "A" (Min. 1, Max. ',ind_univ,').'); //conjunto a
       readln(valor);
       val (valor,ind_a,err);
       while (err<>0) or (ind_a<1) or (ind_univ<ind_a) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_a,err);
       end;
       llenarconjunto(a,ind_a);
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "B" (Min. 1, Max. ',ind_univ,').'); //conjunto
       readln(valor);
       val (valor,ind_b,err);
       while (err<>0) or (ind_b<1) or (ind_univ<ind_b) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_b,err);
       end;
       llenarconjunto(b,ind_b);
        write('*Conjunto "A": ');
        mostrarconjunto(a,ind_a);
        writeln();
        write('*Conjunto "B": ');
        mostrarconjunto(b,ind_b);
        writeln();
        //se muestran conjuntos a y b
        ind_res:=0;
        for i:=1 to ind_a do  //se recorre a para comparar cada valor de a con todos los de b
        begin
            enc:=false;
            for j:=1 to ind_b do//se recorre b
            begin
                if a[i]=b[j] then
                begin
                    enc:=true
                end;
            end;
            if not enc then//si el valor de a, no está en b
            begin
                ind_res:=ind_res+1;
                resultado[ind_res]:=a[i]; //se guarda en resultado
            end;
        end;
        for i:=1 to ind_b do  //se recorre b para comparar cada valor de b con todos los de a
        begin
            enc:=false;
            for j:=1 to ind_a do //se recorre a
            begin
                if a[j]=b[i] then
                begin
                    enc:=true
                end;
            end;
            if not enc then //si el valor de b, no está en a
            begin
                ind_res:=ind_res+1;
                resultado[ind_res]:=b[i];//se guarda en resultado
            end;
        end;
        i:=1;
       while (i<=ind_res) and (ind_res<>0) do  //método de ordenación burbuja para el conjunto resultado
       begin
        interr:=false;
        while (interr=false) do
        begin
            interr:=true;
            j:=1;
            while j<i do
            begin
                if (resultado[j]>resultado[j+1]) then
                begin
                   valor:=resultado[j];
                   resultado[j]:=resultado[j+1];
                   resultado[j+1]:=valor;
                   interr:=false;
                end;
                j:=j+1;
            end;
         end;
         i:=i+1;
        end;
        write('*Diferencia simetrica entre "A" y "B": ');
        if ind_res<>0 then //si hay elementos en resultado
        begin
             mostrarconjunto(resultado,ind_res);
        end
        else //si no los hay...
        begin
            writeln('Conjunto vacio. Lo que quiere decir que no existe diferencia simetrica entre los conjuntos "A" y "B"');
        end;
        writeln();
    end
    else //si se desea trabajar con tres conjuntos...
    begin
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "A" (Min. 1, Max. ',ind_univ,').');//conjunto a
       readln(valor);
       val (valor,ind_a,err);
       while (err<>0) or (ind_a<1) or (ind_univ<ind_a) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_a,err);
       end;
       llenarconjunto(a,ind_a);
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "B" (Min. 1, Max. ',ind_univ,').');  //conjunto b
       readln(valor);
       val (valor,ind_b,err);
       while (err<>0) or (ind_b<1) or (ind_univ<ind_b) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_b,err);
       end;
       llenarconjunto(b,ind_b);
       writeln('Ingrese la cantidad de elementos que conformara el conjunto "C" (Min. 1, Max. ',ind_univ,').'); //conjunto c
       readln(valor);
       val (valor,ind_c,err);
       while (err<>0) or (ind_c<1) or (ind_univ<ind_c) do
       begin
         writeln('Error. La cantidad de elementos debe ser numerica y oscilar entre 1 y ',ind_univ,'. Ingrese nuevamente dicho valor.');
         readln(valor);
         val (valor,ind_c,err);
       end;
       llenarconjunto(c,ind_c);
        ind_res:=0;
        for i:=1 to ind_a do //se recorre a para comparar con b y c
        begin
            enc:=false;
            for j:=1 to ind_b do //recorrido de b
            begin
                if a[i]=b[j] then
                begin
                    enc:=true
                end;
            end;
            for j:=1 to ind_c do  //recorrido de c
            begin
                if a[i]=c[j] then
                begin
                    enc:=true
                end;
            end;
            if not enc then //si no hubo coincidencia..
            begin
                ind_res:=ind_res+1;
                resultado[ind_res]:=a[i];//se guarda en resultado
            end;
        end;
        for i:=1 to ind_b do //se recorre b para comparar con a y c
        begin
            enc:=false;
            for j:=1 to ind_a do //se recorre a
            begin
                if b[i]=a[j] then
                begin
                    enc:=true
                end;
            end;
            for j:=1 to ind_c do //se recorre c
            begin
                if b[i]=c[j] then
                begin
                    enc:=true
                end;
            end;
            if not enc then//si no hubo coincidencia..
            begin
                ind_res:=ind_res+1;
                resultado[ind_res]:=b[i];//se guarda en resultado
            end;
        end;
        for i:=1 to ind_c do //se recorre c para comparar con a y b
        begin
            enc:=false;
            for j:=1 to ind_a do //se recorre a
            begin
                if c[i]=a[j] then
                begin
                    enc:=true
                end;
            end;
            for j:=1 to ind_b do //se recorre b
            begin
                if c[i]=b[j] then
                begin
                    enc:=true
                end;
            end;
            if not enc then //si no hubo coincidencia
            begin
                ind_res:=ind_res+1;
                resultado[ind_res]:=c[i]; //se guarda en resultado
            end;
        end;
        i:=1;
       while (i<=ind_res) and (ind_res<>0) do //burbuja con el conjunto resultado
       begin
        interr:=false;
        while (interr=false) do
        begin
            interr:=true;
            j:=1;
            while j<i do
            begin
                if (resultado[j]>resultado[j+1]) then
                begin
                   valor:=resultado[j];
                   resultado[j]:=resultado[j+1];
                   resultado[j+1]:=valor;
                   interr:=false;
                end;
                j:=j+1;
            end;
         end;
         i:=i+1;
        end;
        write('*Conjunto "A": ');
        mostrarconjunto(a,ind_a);
        writeln();
        write('*Conjunto "B": ');
        mostrarconjunto(b,ind_b);
        writeln();
        write('*Conjunto "C": ');
        mostrarconjunto(c,ind_c);
        writeln();
        //se muestran conjunto a, b y c
        write('*Diferencia simetrica entre "A", "B" y "C": ');
        if ind_res<>0 then// si hay elementos en el conjunto resultado
        begin
             mostrarconjunto(resultado,ind_res);

        end
        else //si no hay elementos..
        begin
            writeln('Conjunto vacio. Lo que quiere decir que no existe interseccion entre los conjuntos "A", "B" y "C"');
        end;
        writeln();
    end;
end;
function factorial(valor:integer):integer; // función de tipo entero que calcula el factorial de un número
var
   i,aux:integer;
begin
     i:=valor;// a i se le asigna el valor pasado por parámetro para empezar con la iteración
     aux:=1; //valor por defecto
     while (i>1) do //mientras que va multilpicando aux hasta que llegue i a 1
     begin
         aux:=aux*i; //se multiplica aux por i
         i:=i-1; //se decrementa i
     end;
     factorial:=aux; //y el valor final de aux, se le asigna a la función
end;
procedure variacion;  //procedimiento que calcula la variación
var
   tmpstr:string;
   m,n,error,resultado:integer;
begin
     writeln('Ingrese el valor de "m"');
     readln(tmpstr);
     val(tmpstr,m,error); //valor de m
     while (error<>0) or (m<=0) or (m>=13) do  //si hubo un error o el valor está fuera de rango (menor que 0 o mayor que 12)...
     begin
         writeln('Error. El valor de "m" debe ser numerico entre 1 y 12. ingrese nuevamente dicho valor');//se pide la columna
         readln(tmpstr);
         val(tmpstr,m,error); //se vuelve a solicitar el valor de m
     end;
     writeln('Ingrese el valor de "n"');//se pide el valor de n
     readln(tmpstr);
     val(tmpstr,n,error);
     while (error<>0) or (n<=0) or (m<n) do //validación de n
     begin
         writeln('Error. El valor de "n" debe ser numerico y menor o igual que "m". ingrese nuevamente dicho valor');//se pide la columna
         readln(tmpstr);
         val(tmpstr,n,error);
     end;
     writeln('Formula: (',m,'!)/(',m,'-',n,')!');//se imprime la fórmula
     resultado:=factorial(m) div factorial(m-n); //se calcula la variación
     writeln('Resultado: ',resultado); //y se imprime el resultado
end;
procedure combinacion;
var
   tmpstr:string;
   m,n,error,resultado:integer;
begin
     writeln('Ingrese el valor de "m"'); //valor de m
     readln(tmpstr);
     val(tmpstr,m,error);
     while (error<>0) or (m<=0) or (m>=13) do
     begin
         writeln('Error. El valor de "m" debe ser numerico entre 1 y 12. ingrese nuevamente dicho valor');//se pide la columna
         readln(tmpstr);
         val(tmpstr,m,error);
     end;
     writeln('Ingrese el valor de "n"');//valor de n
     readln(tmpstr);
     val(tmpstr,n,error);
     while (error<>0) or (n<=0) or (m<n) do
     begin
         writeln('Error. El valor de "n" debe ser numerico y menor o igual que "m". ingrese nuevamente dicho valor');//se pide la columna
         readln(tmpstr);
         val(tmpstr,n,error);
     end;
     //fórmula, cálculo y resultado
     writeln('Formula: (',m,'!)/(',n,'!*(',m,'-',n,')!)');
     resultado:=factorial(m) div( factorial(n)*factorial(m-n));
     writeln('Resultado: ',resultado);
end;
procedure permutacion;
var
   tmpstr:string;
   n,error,resultado:integer;
begin
     writeln('Ingrese el valor de "n"');//valor de n
     readln(tmpstr);
     val(tmpstr,n,error);
     while (error<>0) or (n<=0) or (n>=13) do
     begin
         writeln('Error. El valor de "m" debe ser numerico entre 1 y 12. ingrese nuevamente dicho valor');//se pide la columna
         readln(tmpstr);
         val(tmpstr,n,error);
     end;
     //fórmula, cálculo y resultado
     writeln('Formula: ',n,'!');
     resultado:=factorial(n);
     writeln('Resultado: ',resultado);
end;
begin //principal
     salir_apl:=false; //Se le asigna falso a "salir_apl" para que pueda entrar en la iteración de la aplicación
     inicializar;
     writeln('Bienvenidos al programa que realiza metodos de conteo y operaciones de conjuntos');
     writeln();
     while salir_apl=false do //Mientras esté en la iteración de la aplicación
     begin
        writeln('Menu de Opciones: '); //Se le muestra el abanico de opciones
        writeln();
        writeln('1- Si desea calcular variacion.');
        writeln('2- Si desea calcular combinacion.');
        writeln('3- Si desea calcular permutacion.');
        writeln('4- Si desea realizar un complemento de un conjunto.');
        writeln('5- Si desea realizar una union entre conjuntos.');
        writeln('6- Si desea realizar una interseccion entre conjuntos.');
        writeln('7- Si desea realizar una diferencia entre conjuntos.');
        writeln('8- Si desea realizar una diferencia simetrica entre conjuntos.');
        readln(opc);
        while (opc<>'1') and (opc<>'2') and (opc<>'3') and (opc<>'4') and (opc<>'5') and (opc<>'6') and (opc<>'7') and (opc<>'8') do //Mientras ingrese opción inválida...
        begin
           writeln('Error al leer dato de entrada. Ingrese nuevamente la opcion correcta: ');
           readln(opc);
        end;
        val (opc,num,err);//Se convierte a entero la opción ingresada por el usuario para un mejor manejo de datos
        case num of
        1:  variacion;
        2:  combinacion;
        3:  permutacion;
        4:  complemento;
        5:  union;
        6: interseccion;
        7: diferencia;
        8: dif_sim;
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
