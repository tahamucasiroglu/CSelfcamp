# Donguler

Ard���k i�lemler i�in kullan�l�r.

* [For D�ng�s�](#for-dongusu)
* [While D�ng�s�](#while-dongusu)
* [Do While D�ng�s�](#do-while-dongusu)
* [Foreach D�ng�s�](#foreach-dongusu)



### For Dongusu

```
for(de�i�ken; �art; de�i�ken aritmeti�i)
{
	kodlar
}
```

`for(int i = 0; i < 100; i++)`<br>
`for(int i = 0; i < 100; i += 3)`<br>
`int i = 0; for(; i < 100; i++)`<br>
`int i = 0; for(i = 10; i < 100; i++)`<br>
`int i = 0; for(; i < 100;){i++;} `<br>
`string ad = "Ahmet"; for(int i = 0; ad == "Ahmet"; i += 3)` Ad Ahmet olana kadar d�ner <br>
`for(;;)` -> sonsuz<br>
`for(int i = 0; ;i++)` -> sonsuz<br>
`for(int i = 0, j = 0, k = 10; ;i++)`
`for(int i = 0, j = 0, k = 10; i < 10 || j < 5 && k == 15 ;i++, j--, k+=3)`

yukar�daki �rnekler sa�ma gelebilir tek tek a��klamaya ��endim fakat yukar�daki �rneklerin hepsi �al���yor.(yanl�� yazmad�ysam derleyicide de�il direk burada yazd�m.)
<br>
Bunlardan size yabanc� gelen varsa deenmeniz faydal� olacak.

Ayr�ca i� i�e olu�turdu�unda 

```
for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 100; j++)
    {
        Console.WriteLine(i.ToString() + " - " + j.ToString());
    }
}
```
Bu kodu a�a��daki gibi yazabilirisin
```
for (int k = 0; k < 10000; k++)
{
    int i = k / 100;
    int j = k % 100;
    Console.WriteLine(i.ToString() + " - " + j.ToString());
}
```

ve daha da iyisi bu kodu a�a��daki gibide yazabilirisin
```
for (int k = 0, i=k/100, j= k % 100; k < 10000; k++, i = k / 100, j = k % 100)
{
    Console.WriteLine(i.ToString() + " - " + j.ToString());
}
```

Hepsinin sonucu ayn� ��kacak. Bana gire `for` d�ng�lerin kral�d�r.


### While Dongusu

```
while(durum)
{
	kodlar
}
```

durum `true` ise d�ner `false` ise durur.

`Ki�isel Not:` e�er durumda denklik varsa say�larda yani durumumuz `a == 30` ise bunu `a >= 30` olarak yaz. Bu sayede her zmaan birer birer artt�rmayaca��n i�in `30`'u atlarsa yinede while sonlan�r.


### Do while Dongusu

```
do{
	kodlar
} while(durum)
```

�nce `kodu` �al��t�r�r. sonra `duruma` bakar. `Durum` `false` olsa bile kod bir kere �al���r.




### Foreach Dongusu

�z�nde d�ng� de�il iterasyondur. verilen liste veya dizi tipine g�re �al���r.
<br>
`foreach(var item in dizi)` �eklinde kullan�l�r.




















































































































