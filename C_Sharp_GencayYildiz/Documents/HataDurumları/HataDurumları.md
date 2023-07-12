# Hata Durumlari

3 tür hata vardýr.

* [Derleyici / Söz Dizimi Hatalarý](###derleyici-hatasi)
* [Runtime / Çalýþma Zamaný Hatalarý](###runtime-hatasi)
* [Try-Catch](###try-catch)
* [Mantýksal Hatalarý](###mantiksal-hata)


### Derleyici Hatasi

En kolay tespit edilen hata. Direk derleyicide bulunur. Kelime veya söz dizimi yazým hatalarýnda ortaya çýkar. 
<br>
`int a = 4;` yerine `inta = 4;` demek gibi


### Runtime Hatasi

Eðer kod çalýþýrken hata alýyorsanýz bu türde hata alýrsýnýz. 
```
int age = Convert.ToInt32(Console.ReadLine());
```

örneðin burada yaþýnýzý girin dedik. Ýnsanlar  `15-25-35` giridiði zaman sorun yok fakat biri gitti `asd` girdi. Ýþte o zaman `asd` bir sayý veya rakam olmadýðý için çeviremeyecek ve hata fýrlatacak. Bu hatada programýn çökmesine sebep olacak.

### Try-Catch

Programýn çalýþma sýrasýnda oluþan hatalarý kullanýcýya fark ettirmeden hatalarý yönetmeyi saðlar.
<br>

normal kullaným için nette araþtýrýn.
```
try
{
	kodlar
}
catch(DivideByZeroException e)
{
	sýfýra bölme hatasý kodu
}
catch(FormatException e)
{
	format hatasý kodu
}
catch(Exception e)
{
	önceki hatalar haricindeki tüm hatalarýn kodu
}

```

þeklinde çoklu `catch` kullanýlabilir.
<br>

```
try
{
	kodlar
}
catch(DivideByZeroException e)
{
	sýfýra bölme hatasý kodu
}
catch(FormatException e)
{
	format hatasý kodu
}
catch(Exception e)
{
	önceki hatalar haricindeki tüm hatalarýn kodu
}
finally
{
	try yada catchlerden birine girerese çalýþýr burasý. Hatalý hatasýz çalýþtýrýr.
}
```

þeklinde `finally` kullanýlabilir.
<br>

```
try
{
	kodlar
}
catch(DivideByZeroException e) when(koþul)
{
	sýfýra bölme hatasý kodu
}
catch(FormatException e)
{
	format hatasý kodu
}
catch(Exception e)
{
	önceki hatalar haricindeki tüm hatalarýn kodu
}
finally
{
	try yada catchlerden birine girerese çalýþýr burasý. Hatalý hatasýz çalýþtýrýr.
}
```

þeklinde `when` ile koþullu `catch` kullanýlabilir. Bu örnekte saçma oldu ama iþte `a > 5000` ise þu `DivideByZeroException`'ý çalýþtýr deðilse bu denebilir.
<br>



### Mantiksal Hata

Mantýksal hatalar adý üzerinde mantýk hatasýdýr. Kod çalýþýr. Hata fýrlatýlmaz. Sonuç istenilen deðildir. Burada genellikle algoritmik tasarým veya kodlama da düþünce hatasý olabilir.
<br>
Saçma ama siz `kare` alan fonsiyonda yanlýþlýkla `kök` alan iþlem yaparsanýz. Herþey doðru çalýþýr ama `4` verdiðinizde `16` beklerken size `2` verir.































































