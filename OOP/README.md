# OOP

* [Ref Readonly Return Field D�n���](###ref-readonly-return-field)
* [In�t Field](###init)
* [Deconstruct Yap�s�](###deconstruct)
* [Static Constructor Methodu](###static-constructor)
* [Class vs Struct Tipleri](###class-vs-struct-tipleri)
* [Interface](###interface)

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


### Interface



normalde `interface`'ler bir iskeletti fakat yeni `C#`'da art�k `interface`'ler sadec `method` isimleri de�il art�k `method` g�vdeside almakta ve bu g�vdeli `method`'lar� `s�n�f`'lar�n i�inde belirtmek zorunda de�il. 
```
interface Topla
{
	void Toplama(int x, int y)
	{
		Console.WriteLine(x+y);
	}
}

class Sinif : Topla
{
	
}
```
Normalde `Sinif` k�sm�nda hata vermesi gerekirken vermez ��nk� `method`'un g�vdesi var.

<br>














































