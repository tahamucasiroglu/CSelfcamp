# Pattern Maching

* [Type Pattern](###type-pattern)
* [Custom Pattern](###custom-pattern)
* [Var Pattern](###var-pattern)
* [Recursive Pattern](###recursive-pattern)
* [Simple Type Pattern](###simple-type-pattern)
* [Relational Pattern](###relational-pattern)

### Type Pattern

`is` tipin kar��la�t�rmas�n� yapar<br>
```
if(x is string)
{
	string xx = x as string;
}
```
gibi yapar. �imdi burada `xx` zaten if i�inde kullan�labilir sadece bu y�ntemi kolayla�t�rmak i�in kodu a�a��daki gibi yapabiliriz.<br>

```
if(x is string xx)
{
	
}
```

bu sayede direk if i�inde e�er `x` string ise onu `xx` olarak if i�inde ata diyoruz.<br>


Bu pattern sadece `if` i�inde �al��maz.<br>
```bool result = x is string o;```<br>
ile e�er `x` `string` ise `result` `true` olur ve `x` in de�eri `string` tipindeki `o` ya aktar�l�r. <br>
Fakat �nemli bir �art var. `o` `nullable` bir tip olmaktad�r. Bu niye `if` i�inde �nemsenmez zaten orada `null` de�ilse `if` i�inde kullan�l�r. <br>




### Custom Pattern

```
if(x is 15)
{
}
```

�eklinde `==` i�lemi yapmam�z� sa�lar. Daha k�sa kod sa�lar.<br>
Genellikle denk ise bir kod toplulu�u �al��acaksa clean kod sa�lar.<br>


### Var Pattern

[Type Pattern](###type-pattern) k�sm�nda k�sa kullan�m vard�. <br>
```
if(x is string xx){}
```

`var pattern` ise

```
if(x is var xx){}
```

�eklinde kullan�l�r. Fark� ise x ne olursa olsun al�r. Ne gelirse gelsin al�r.<br>
T�r `runtime`'da derlenir.<br>



``` Kod 1: var x = "asdasdas"; ``` <br>
``` Kod 2: if(x is var a)  ```

�rne�in yukar�daki kodda `Kod 1` `derleme` zaman�nda �al���r. `Kod 2` `runtime` zaman�nda �al���r. <br>

Bu pattern sadece `if` i�inde �al��maz.<br>
[Type Pattern](###type-pattern)'de g�sterildi�i gibi burada da if d���ndak�i kullan�m� mevcuttur.<br>
```bool result = x is var o;```<br>

`result` her zaman `true` olacak ve `o` her zaman bir `nullable` tip olacak. 



### Recursive Pattern

```
ICloneable instance;
switch(instance)
{
	case sqlConnection connection:
		connection.ConnectionString = "server;Db...";
		break;
	case sqlCommand command when (command.Connection.IsConnect):
		command.CommandText = "asdasdas";
		break;
	case null: break;
}
```

`when` ile ko�ullu �artlar eklenebiliyordu. `case null` ile bir nevi `default` kullan�m� sa�lan�r.<br>
`interface` ile �oklu yap� g�nderilebilir.<br>


### Simple Type Pattern

```
object obj = new Person();
switch(obj)
{
	case Person p:
		//kodlar\\
		break;
}
```

Yukar�daki kodda t�r k�yaslamas� yapmak i�inde kullan�l�rd�. Art�k bunu

```
object obj = new Person();
switch(obj)
{
	case Person:
		//kodlar\\
		break;
}
```

�eklinde `p` olmadanda yapabiliriz bu sayede gereksiz atamalar olmaz ve sadece t�r k�yaslamas� oldu�u daha rahat anla��l�r.<br>


### Relational Pattern

`<, >, <=, >=,` gibi kar��la�t�rma ifadelerini `switch case` i�erisinde kullan�lmas�n� sa�lar.

```
switch(maa�)
{
	< 5000 => "5000 tl den az maa� al�yor";
}
```




