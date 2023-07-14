# OOP

* [Ref Readonly Return Field Dönüþü](###ref-readonly-return-field)
* [Inýt Field](###init)
* [Deconstruct Yapýsý](###deconstruct)
* [Static Constructor Methodu](###static-constructor)
* [Class vs Struct Tipleri](###class-vs-struct-tipleri)


### Ref Readonly Return Field

```
class MyClass
{
	string name = "Ahmet Taha";
	public ref readonly string Name => ref name; 
}
```

yukarýdaki gibi `field` içinde referans olarak döndürme yapýlabilmekte.

### Inýt

Ýlk deðer atamasý sonrasý `property`'nin deðiþmemesini saðlar. 


### Deconstruct
```
public void Deconstructor(out string.... out int)
{
}
```
yukarýdaki þekilde dýþarý çýkarmayý saðlar.

`var (x,y) = SINIF;` <br>
þeklinde kullanýlýr.

### Static Constructor

```
class MyClass
{
	public MyClass(){}

	static MyClass(){}
}
```
`static MyClass(){}` nesne `ilk kez` üretilirken çalýþýr.<br>
`public MyClass(){}` nesne her üretiliþinde çalýþýr.


### Class vs Struct Tipleri

* `struct` deðer tipidir. `class` referans tipidir. <br>
Temeli bu kalanlarýn hepsi bu kavramdan dolayý ortaya çýkar. En azýndan benim gördüklerim. `class` daha performanslý. 



















































