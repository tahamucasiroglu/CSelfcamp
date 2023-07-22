# Donguler

Ardýþýk iþlemler için kullanýlýr.

* [For Döngüsü](#for-dongusu)
* [While Döngüsü](#while-dongusu)
* [Do While Döngüsü](#do-while-dongusu)
* [Foreach Döngüsü](#foreach-dongusu)



### For Dongusu

```
for(deðiþken; þart; deðiþken aritmetiði)
{
	kodlar
}
```

`for(int i = 0; i < 100; i++)`<br>
`for(int i = 0; i < 100; i += 3)`<br>
`int i = 0; for(; i < 100; i++)`<br>
`int i = 0; for(i = 10; i < 100; i++)`<br>
`int i = 0; for(; i < 100;){i++;} `<br>
`string ad = "Ahmet"; for(int i = 0; ad == "Ahmet"; i += 3)` Ad Ahmet olana kadar döner <br>
`for(;;)` -> sonsuz<br>
`for(int i = 0; ;i++)` -> sonsuz<br>
`for(int i = 0, j = 0, k = 10; ;i++)`
`for(int i = 0, j = 0, k = 10; i < 10 || j < 5 && k == 15 ;i++, j--, k+=3)`

yukarýdaki örnekler saçma gelebilir tek tek açýklamaya üþendim fakat yukarýdaki örneklerin hepsi çalýþýyor.(yanlýþ yazmadýysam derleyicide deðil direk burada yazdým.)
<br>
Bunlardan size yabancý gelen varsa deenmeniz faydalý olacak.

Ayrýca iç içe oluþturduðunda 

```
for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 100; j++)
    {
        Console.WriteLine(i.ToString() + " - " + j.ToString());
    }
}
```
Bu kodu aþaðýdaki gibi yazabilirisin
```
for (int k = 0; k < 10000; k++)
{
    int i = k / 100;
    int j = k % 100;
    Console.WriteLine(i.ToString() + " - " + j.ToString());
}
```

ve daha da iyisi bu kodu aþaðýdaki gibide yazabilirisin
```
for (int k = 0, i=k/100, j= k % 100; k < 10000; k++, i = k / 100, j = k % 100)
{
    Console.WriteLine(i.ToString() + " - " + j.ToString());
}
```

Hepsinin sonucu ayný çýkacak. Bana gire `for` döngülerin kralýdýr.


### While Dongusu

```
while(durum)
{
	kodlar
}
```

durum `true` ise döner `false` ise durur.

`Kiþisel Not:` eðer durumda denklik varsa sayýlarda yani durumumuz `a == 30` ise bunu `a >= 30` olarak yaz. Bu sayede her zmaan birer birer arttýrmayacaðýn için `30`'u atlarsa yinede while sonlanýr.


### Do while Dongusu

```
do{
	kodlar
} while(durum)
```

önce `kodu` çalýþtýrýr. sonra `duruma` bakar. `Durum` `false` olsa bile kod bir kere çalýþýr.




### Foreach Dongusu

özünde döngü deðil iterasyondur. verilen liste veya dizi tipine göre çalýþýr.
<br>
`foreach(var item in dizi)` þeklinde kullanýlýr.




















































































































