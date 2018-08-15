USES crt;
var
frase: string;
procedure aeiou;
var
a,e,i,o,u,cont:integer;//variables enteras para contar las vocales y gestionar el recorrido de la frase
begin
    a:=0;
    e:=0;
    i:=0;
    o:=0;
    u:=0;
    cont:=0;
    for cont:=1 to length(frase) do
    begin
        if (frase[cont]='a') or (frase[cont]='A') then//si es a
        begin
           a:=a+1;
        end
        else if (frase[cont]='e') or (frase[cont]='E') then //si es e
        begin
           e:=e+1;
        end
        else if (frase[cont]='i') or (frase[cont]='I') then  //si es i
        begin
           i:=i+1;
        end
        else if (frase[cont]='o') or (frase[cont]='O') then  //si es o
        begin
           o:=o+1;
        end
        else if (frase[cont]='u') or (frase[cont]='U') then  //si es u
        begin
           u:=u+1;
        end;
    end;
    writeln ('*Cantidad de letras "a": ',a);
    writeln ('*Cantidad de letras "e": ',e);
    writeln ('*Cantidad de letras "i": ',i);
    writeln ('*Cantidad de letras "o": ',o);
    writeln ('*Cantidad de letras "u": ',u);
end;
function n_pal: integer;
var
ini_pal: boolean;
i,total: integer;
begin
     i:=1;
     total:=0;
     ini_pal:=false;
     for i:=1 to length(frase) do  //se recorre la frase
     begin
        if frase[i]<>' ' then  //si el caracter es distinto de espacio
        begin
           ini_pal:=true; //se asigna verdadero ini_pal, para asegurar que hay una palabra por procesar
        end
        else if (frase[i]=' ') and (ini_pal=true) then  //si es espacio y hay una palabra por procesar
        begin
             ini_pal:=false; //se asigna falso ini_pal, para asegurar que no queda palabra por procesar
             total:=total+1; //se incrementa en uno el contador de palabras
        end;
     end;
     if ini_pal=true then  //si hay una palabra por procesar
     begin
         total:=total+1; //se incrementa en uno el contador de palabras
     end;
     n_pal:=total; //a la función se le asigna el contador de palabras
end;
begin
  writeln ('Ingrese la frase:');
  readln (frase);
  writeln ('Frase: ',frase);
  aeiou;
  writeln ('*Cantidad de palabras: ',n_pal);
  writeln ('Presione la tecla Enter para salir: ');
  readln();
end.
