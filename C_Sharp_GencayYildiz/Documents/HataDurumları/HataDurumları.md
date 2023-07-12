# Hata Durumlari

3 t�r hata vard�r.

* [Derleyici / S�z Dizimi Hatalar�](###derleyici-hatasi)
* [Runtime / �al��ma Zaman� Hatalar�](###runtime-hatasi)
* [Try-Catch](###try-catch)
* [Mant�ksal Hatalar�](###mantiksal-hata)


### Derleyici Hatasi

En kolay tespit edilen hata. Direk derleyicide bulunur. Kelime veya s�z dizimi yaz�m hatalar�nda ortaya ��kar. 
<br>
`int a = 4;` yerine `inta = 4;` demek gibi


### Runtime Hatasi

E�er kod �al���rken hata al�yorsan�z bu t�rde hata al�rs�n�z. 
```
int age = Convert.ToInt32(Console.ReadLine());
```

�rne�in burada ya��n�z� girin dedik. �nsanlar  `15-25-35` giridi�i zaman sorun yok fakat biri gitti `asd` girdi. ��te o zaman `asd` bir say� veya rakam olmad��� i�in �eviremeyecek ve hata f�rlatacak. Bu hatada program�n ��kmesine sebep olacak.

### Try-Catch

Program�n �al��ma s�ras�nda olu�an hatalar� kullan�c�ya fark ettirmeden hatalar� y�netmeyi sa�lar.
<br>

normal kullan�m i�in nette ara�t�r�n.
```
try
{
	kodlar
}
catch(DivideByZeroException e)
{
	s�f�ra b�lme hatas� kodu
}
catch(FormatException e)
{
	format hatas� kodu
}
catch(Exception e)
{
	�nceki hatalar haricindeki t�m hatalar�n kodu
}

```

�eklinde �oklu `catch` kullan�labilir.
<br>

```
try
{
	kodlar
}
catch(DivideByZeroException e)
{
	s�f�ra b�lme hatas� kodu
}
catch(FormatException e)
{
	format hatas� kodu
}
catch(Exception e)
{
	�nceki hatalar haricindeki t�m hatalar�n kodu
}
finally
{
	try yada catchlerden birine girerese �al���r buras�. Hatal� hatas�z �al��t�r�r.
}
```

�eklinde `finally` kullan�labilir.
<br>

```
try
{
	kodlar
}
catch(DivideByZeroException e) when(ko�ul)
{
	s�f�ra b�lme hatas� kodu
}
catch(FormatException e)
{
	format hatas� kodu
}
catch(Exception e)
{
	�nceki hatalar haricindeki t�m hatalar�n kodu
}
finally
{
	try yada catchlerden birine girerese �al���r buras�. Hatal� hatas�z �al��t�r�r.
}
```

�eklinde `when` ile ko�ullu `catch` kullan�labilir. Bu �rnekte sa�ma oldu ama i�te `a > 5000` ise �u `DivideByZeroException`'� �al��t�r de�ilse bu denebilir.
<br>



### Mantiksal Hata

Mant�ksal hatalar ad� �zerinde mant�k hatas�d�r. Kod �al���r. Hata f�rlat�lmaz. Sonu� istenilen de�ildir. Burada genellikle algoritmik tasar�m veya kodlama da d���nce hatas� olabilir.
<br>
Sa�ma ama siz `kare` alan fonsiyonda yanl��l�kla `k�k` alan i�lem yaparsan�z. Her�ey do�ru �al���r ama `4` verdi�inizde `16` beklerken size `2` verir.































































