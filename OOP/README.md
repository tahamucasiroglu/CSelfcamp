# OOP

* [Ref Readonly Return Field D�n���](###ref-readonly-return-field)
* [In�t Field](###init)
* [Deconstruct Yap�s�](###deconstruct)
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

yukar�daki gibi `field` i�inde referans olarak d�nd�rme yap�labilmekte.

### In�t

�lk de�er atamas� sonras� `property`'nin de�i�memesini sa�lar. 


### Deconstruct
```
public void Deconstructor(out string.... out int)
{
}
```
yukar�daki �ekilde d��ar� ��karmay� sa�lar.

`var (x,y) = SINIF;` <br>
�eklinde kullan�l�r.

### Static Constructor

```
class MyClass
{
	public MyClass(){}

	static MyClass(){}
}
```
`static MyClass(){}` nesne `ilk kez` �retilirken �al���r.<br>
`public MyClass(){}` nesne her �retili�inde �al���r.


### Class vs Struct Tipleri

* `struct` de�er tipidir. `class` referans tipidir. <br>
Temeli bu kalanlar�n hepsi bu kavramdan dolay� ortaya ��kar. En az�ndan benim g�rd�klerim. `class` daha performansl�. 



















































