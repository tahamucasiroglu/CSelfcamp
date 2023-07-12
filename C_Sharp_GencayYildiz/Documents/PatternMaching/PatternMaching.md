# Pattern Maching

* [Type Pattern](###type-pattern)
* [Custom Pattern](###custom-pattern)
* [Var Pattern](###var-pattern)
* [Recursive Pattern](###recursive-pattern)
* [Simple Type Pattern](###simple-type-pattern)
* [Relational Pattern](###relational-pattern)

### Type Pattern

`is` tipin karþýlaþtýrmasýný yapar<br>
```
if(x is string)
{
	string xx = x as string;
}
```
gibi yapar. þimdi burada `xx` zaten if içinde kullanýlabilir sadece bu yöntemi kolaylaþtýrmak için kodu aþaðýdaki gibi yapabiliriz.<br>

```
if(x is string xx)
{
	
}
```

bu sayede direk if içinde eðer `x` string ise onu `xx` olarak if içinde ata diyoruz.<br>


Bu pattern sadece `if` içinde çalýþmaz.<br>
```bool result = x is string o;```<br>
ile eðer `x` `string` ise `result` `true` olur ve `x` in deðeri `string` tipindeki `o` ya aktarýlýr. <br>
Fakat önemli bir þart var. `o` `nullable` bir tip olmaktadýr. Bu niye `if` içinde önemsenmez zaten orada `null` deðilse `if` içinde kullanýlýr. <br>




### Custom Pattern

```
if(x is 15)
{
}
```

þeklinde `==` iþlemi yapmamýzý saðlar. Daha kýsa kod saðlar.<br>
Genellikle denk ise bir kod topluluðu çalýþacaksa clean kod saðlar.<br>


### Var Pattern

[Type Pattern](###type-pattern) kýsmýnda kýsa kullaným vardý. <br>
```
if(x is string xx){}
```

`var pattern` ise

```
if(x is var xx){}
```

þeklinde kullanýlýr. Farký ise x ne olursa olsun alýr. Ne gelirse gelsin alýr.<br>
Tür `runtime`'da derlenir.<br>



``` Kod 1: var x = "asdasdas"; ``` <br>
``` Kod 2: if(x is var a)  ```

örneðin yukarýdaki kodda `Kod 1` `derleme` zamanýnda çalýþýr. `Kod 2` `runtime` zamanýnda çalýþýr. <br>

Bu pattern sadece `if` içinde çalýþmaz.<br>
[Type Pattern](###type-pattern)'de gösterildiði gibi burada da if dýþýndakþi kullanýmý mevcuttur.<br>
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

`when` ile koþullu þartlar eklenebiliyordu. `case null` ile bir nevi `default` kullanýmý saðlanýr.<br>
`interface` ile çoklu yapý gönderilebilir.<br>


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

Yukarýdaki kodda tür kýyaslamasý yapmak içinde kullanýlýrdý. Artýk bunu

```
object obj = new Person();
switch(obj)
{
	case Person:
		//kodlar\\
		break;
}
```

Þeklinde `p` olmadanda yapabiliriz bu sayede gereksiz atamalar olmaz ve sadece tür kýyaslamasý olduðu daha rahat anlaþýlýr.<br>


### Relational Pattern

`<, >, <=, >=,` gibi karþýlaþtýrma ifadelerini `switch case` içerisinde kullanýlmasýný saðlar.

```
switch(maaþ)
{
	< 5000 => "5000 tl den az maaþ alýyor";
}
```




