USES crt;
type
    conjunto= array[1..5] of string;
    auxlog= array[1..5] of boolean;

    ptrcomb=^comb;
    ptrconj=^conj;

    conj=record//Registro para almacenar cada valor del subconjunto generado por la aplicación
        valor:string;
        sig:ptrconj;
    end;
    comb=record //Registro para almacenar subconjunto generado por la aplicación
        sig:ptrcomb;
        conj:ptrconj;
    end;
var
   cj:conjunto;
   ax:auxlog;
   elementos,i,err:integer;
   lcomb,auxcomb,nuevocomb:ptrcomb;
   auxconj,nuevoconj:ptrconj;
   salir:boolean;
   opcion:string;

function factorial( num : integer) : integer;  //función recursiva para calcular el factorial de un número
begin
  if num = 0 then
    factorial := 1
  else
    factorial := num * factorial( num-1 );
end;

Function Potencia ( x,n:integer ) : integer; //funcion que calcula una potencia
Var
i:integer;
pot:integer;
Begin
pot:=1;
If n>0 Then
For i:=1 to n do
pot:=pot*x;
Potencia:=pot;
End;

function numerico (cadena: string; var numero:integer):boolean; //funcion que evalua si una cadena de caracteres es numerica
begin
    val (cadena,numero,err);
    if  err<>0 then
    begin
        numerico:=false;
    end
    else
    begin
        numerico:=true;
    end;
end;

procedure insertarconj(var lcomb:ptrcomb; nuevoconj:ptrconj);//procedimiento para almacenar un valor en un subconjunto generado por la aplicación
begin
    if lcomb^.conj=nil then
    begin
         lcomb^.conj:=nuevoconj;
    end
    else
    begin
         auxconj:=lcomb^.conj;
         while auxconj^.sig<>nil do
         begin
              auxconj:=auxconj^.sig;
         end;
         auxconj^.sig:=nuevoconj;
    end;
end;

procedure insertarcomb(var lcomb:ptrcomb; nuevocomb:ptrcomb);//procedimiento para almacenar un subconjunto generado por la aplicación
begin
       if lcomb=nil then
       begin
            lcomb:=nuevocomb;
       end
       else
       begin
            auxcomb:=lcomb;
            while auxcomb^.sig<>nil do
            begin
                 auxcomb:=auxcomb^.sig;
            end;
            auxcomb^.sig:=nuevocomb;
       end;
end;

procedure eliminarcomb;//procedimiento para inicializar la lista de subconjuntos
var
   borracomb:ptrcomb;
   borraconj:ptrconj;
begin
   while lcomb<>nil  do
   begin
       borracomb:=lcomb;
       while lcomb^.conj<>nil  do
       begin
           borraconj:=lcomb^.conj;
           lcomb^.conj:=lcomb^.conj^.sig;
           dispose (borraconj);
       end;
       lcomb:=lcomb^.sig;
       dispose (borracomb);
   end;
end;

function permrepetida(c:conjunto;elementos:integer): boolean; //funcion booleana para evitar las repeticiones en los subconjuntos (sólo para las permutas)
var encontrado:boolean;
    j,k:integer;
begin
      auxcomb:=lcomb;
      encontrado:=false;
      while auxcomb<>nil do
      begin
        auxconj:=auxcomb^.conj;
        j:=0;
        k:=0;
        while auxconj<>nil do
        begin
            k:=k+1;
            if auxconj^.valor=c[k] then
            begin
               j:=j+1;
            end;
            auxconj:=auxconj^.sig;
        end;
        if j=elementos then
        begin
          encontrado:=true;
        end;
        auxcomb:=auxcomb^.sig;
      end;
      permrepetida:=encontrado;
end;

function combrepetida(c:conjunto;elementos:integer): boolean; //funcion booleana para evitar las repeticiones en los subconjuntos (sólo para las combinaciones)
var encontrado:boolean;
    j,k:integer;
begin
      auxcomb:=lcomb;
      encontrado:=false;
      while auxcomb<>nil do
      begin
        j:=0;
        for k:=1 to elementos do
        begin
             auxconj:=auxcomb^.conj;
             while auxconj<>nil do
             begin
                  if (auxconj^.valor=c[k]) then
                  begin
                       j:=j+1;
                  end;
                  auxconj:=auxconj^.sig;
              end;
         end;
        if j=elementos then
        begin
          encontrado:=true;
        end;
        auxcomb:=auxcomb^.sig;
      end;
      combrepetida:=encontrado;
end;

procedure  persinrep;//procedimiento que genera los subconjuntos permutados sin repetición a partir de un conjunto ingresado por el usuario
var valor,i:integer;
    c:conjunto;
begin
   salir:=false;
   while salir=false do
   begin
      for i:=1 to elementos do
      begin
           ax[i]:=false;
      end;
      new (nuevocomb);
      nuevocomb^.sig:=nil;
      nuevocomb^.conj:=nil;
      for i:=1 to elementos do
      begin
           valor:=random(elementos)+1;
           while ax[valor]=true do
           begin
                valor:=random(elementos)+1;
           end;
           ax[valor]:=true;
           c[i]:=cj[valor];
           new (nuevoconj);
           nuevoconj^.sig:=nil;
           nuevoconj^.valor:=cj[valor];
           insertarconj(nuevocomb,nuevoconj);
      end;
      salir:=false;
      if permrepetida(c,elementos)=false then
      begin
          salir:=true;
          insertarcomb(lcomb,nuevocomb);
      end;
  end;
end;

procedure perconrep;//procedimiento que genera los subconjuntos permutados con repetición a partir de un conjunto ingresado por el usuario y por los elementos a tomar de dicho conjunto
var
   i,j,n,valor:integer;
   cadena:string;
   c:conjunto;
begin
    writeln ('Ingrese la cantidad de elementos a tomar del conjunto (max. ',elementos,'):');
    readln (cadena);
    while (numerico(cadena,n)=false) or (n=0) or (n>elementos) do
    begin
        writeln ('La cantidad de elementos a tomar debe ser numerica y no mayor que ',elementos,'. Intente de nuevo:');
        readln (cadena);
    end;
    writeln ('Total de permutas con repeticion: ',Potencia(elementos,n));
    if Potencia(elementos,n)>50 then
    begin
        writeln ('No se pueden mostrar los subconjuntos, dado que la cantidad de permutas es mayor a 50');
    end
    else
    begin
        for i:=1 to Potencia(elementos,n) do
        begin
           salir:=false;
           while salir=false do
           begin
                new (nuevocomb);
                nuevocomb^.sig:=nil;
                nuevocomb^.conj:=nil;
                for j:=1 to n do
                begin
                     valor:=random(elementos)+1;
                     c[j]:=cj[valor];
                     new (nuevoconj);
                     nuevoconj^.sig:=nil;
                     nuevoconj^.valor:=cj[valor];
                     insertarconj(nuevocomb,nuevoconj);
                end;
                if permrepetida(c,n)=false then
                begin
                    salir:=true;
                    insertarcomb(lcomb,nuevocomb);
                end;
           end;
        end;
    end;
end;

procedure combsinrep;//procedimiento que genera los subconjuntos combinados sin repetición a partir de un conjunto ingresado por el usuario y por los elementos a tomar de dicho conjunto
var
   i,j,n,valor:integer;
   cadena:string;
   c:conjunto;
begin
    writeln ('Ingrese la cantidad de elementos a tomar del conjunto (max. ',elementos,'):');
    readln (cadena);
    while (numerico(cadena,n)=false) or (n=0) or (n>elementos) do
    begin
        writeln ('La cantidad de elementos a tomar debe ser numerica y no mayor que ',elementos,'. Intente de nuevo:');
        readln (cadena);
    end;
    writeln ('Total de combinaciones sin repeticion: ',factorial(elementos)div(factorial(n)*factorial(elementos-n)));
    if factorial(elementos)div(factorial(n)*factorial(elementos-n))>50 then
    begin
        writeln ('No se pueden mostrar los subconjuntos, dado que la cantidad de permutas es mayor a 50');
    end
    else
    begin
        for i:=1 to factorial(elementos)div(factorial(n)*factorial(elementos-n)) do
        begin
           salir:=false;
           while salir=false do
           begin
                for j:=1 to elementos do
                begin
                     ax[j]:=false;
                end;
                new (nuevocomb);
                nuevocomb^.sig:=nil;
                nuevocomb^.conj:=nil;
                for j:=1 to n do
                begin
                     valor:=random(elementos)+1;
                     while ax[valor]=true do
                     begin
                          valor:=random(elementos)+1;
                     end;
                     ax[valor]:=true;
                     c[j]:=cj[valor];
                     new (nuevoconj);
                     nuevoconj^.sig:=nil;
                     nuevoconj^.valor:=cj[valor];
                     insertarconj(nuevocomb,nuevoconj);
                end;
                if combrepetida(c,n)=false then
                begin
                    salir:=true;
                    insertarcomb(lcomb,nuevocomb);
                end;
           end;
        end;
    end;
end;

procedure mostrarcomb;//procedimiento para mostrar los subconjuntos generados
begin
    auxcomb:=lcomb;
    while auxcomb<>nil do
    begin
        auxconj:=auxcomb^.conj;
        while auxconj<>nil do
        begin
            write(auxconj^.valor,' ');
            auxconj:=auxconj^.sig;
        end;
        writeln();
        auxcomb:=auxcomb^.sig;
    end;
end;

procedure recopilarconj;//procedimiento en donde el usuario ingresa el conjunto principal
var cadena:string;
    j:integer;
    encontrado:boolean;
begin
    writeln ('Ingrese la cantidad de elementos que contendra el conjunto (Max. 5)');
    readln (cadena);
    while (numerico(cadena,elementos)=false) or (elementos<=0) or (elementos>6) do
    begin
         writeln ('La cantidad de elementos del conjunto debe ser numerico y oscilar entre 1 y 5. Intente de nuevo:');
         readln (cadena);
    end;
    for i:=1 to elementos do
    begin
         writeln ('Ingrese el valor del elemento nr ',i,':');
         readln (cadena);
         if i>1 then
         begin
             salir:=false;
             while salir=false do
             begin
                 salir:=true;
                 encontrado:=false;

                 for j:=1 to i-1 do
                 begin
                     if (cj[i]=cj[j]) then
                     begin
                         encontrado:=true;
                     end;
                 end;
                 if encontrado=true then
                 begin
                     salir:=false;
                     writeln ('Valor repetido. Intente de nuevo:');
                     readln (cadena);
                 end;
             end;
         end;
         cj[i]:=cadena;
    end;

end;

begin//principal
     lcomb:=nil;
     randomize;
     writeln ('Bienvenidos al programa COMBO-PERMUTA');
     salir:=false;
     while salir=false do
     begin
          writeln ('Menu de opciones:');
          writeln ('1) Si desea la permuta de conjuntos sin repeticion');
          writeln ('2) Si desea la permuta de conjuntos con repeticion');
          writeln ('3) Si desea la combinacion de conjuntos sin repeticion');
          readln (opcion);
          while (opcion<>'1') and (opcion<>'2') and (opcion<>'3') do
          begin
               writeln ('Opcion incorrecta. Intente de nuevo:');
               readln (opcion);
          end;
          eliminarcomb;
          if opcion='1' then
          begin
              recopilarconj;
              writeln ('Total de permutaciones: ',factorial(elementos));
              if factorial(elementos)>50 then
              begin
                   writeln ('No se pueden mostrar los subconjuntos, debido a que la cantidad de permutas generadas es superior a 50');
              end
              else
              begin
                  for i:=1 to factorial(elementos) do
                  begin
                       persinrep;
                  end;
                  mostrarcomb;
              end;
          end
          else if opcion='2' then
          begin
              recopilarconj;
              perconrep;
              mostrarcomb;
          end
          else if opcion='3' then
          begin
              recopilarconj;
              combsinrep;
              mostrarcomb;
          end;
          salir:=false;
          writeln('Desea salir de la aplicacion? s/n');
          readln(opcion);
          while (opcion<>'s') and (opcion<>'S') and (opcion<>'n') and (opcion<>'N') do
          begin
              writeln('Opcion invalida, ingrese la opcion correcta.');
              readln(opcion);
          end;
          if ((opcion='s') or (opcion='S')) then
          begin
               salir:=true;
          end;
     end;
end.
