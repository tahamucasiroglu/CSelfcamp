# Genel Konular

* [`Async Main` Y�ntemin](#async-main)
* [Aramalarda `Tupple` ile �oklu Se�enekler](#tupple)
* [Ba�lang�� ve Biti� Olan ��lemleri Kolayla�t�ran `Range` Tipi](#range)
* [Partiallar](#partial)
* [Native Int](#nint)
* [Paragraf String](#paragraf-string)
* [Span ve memory](#span-ve-memory)
* [Regular Expressions](#regular-expressions)<br>
&nbsp; &nbsp; &nbsp; &nbsp; > [^ Operat�r�](#regular-expressions)<br>
&nbsp; &nbsp; &nbsp; &nbsp; > [\\ Operat�r�](#regular-expressions)<br>
&nbsp; &nbsp; &nbsp; &nbsp; > [+ Operat�r�](#regular-expressions)<br>
&nbsp; &nbsp; &nbsp; &nbsp; > [| Operat�r�](#regular-expressions)<br>
&nbsp; &nbsp; &nbsp; &nbsp; > [\{ n \} Operatoru](#regular-expressions)<br>
&nbsp; &nbsp; &nbsp; &nbsp; > [? Operat�r�](#regular-expressions)<br>


### Async Main

```
static void Main()
static void Main(string[])
static int Main()
static int Main(string[])
```
Test etmedim ama [Buradan](https://github.com/dotnet/csharplang/blob/main/proposals/csharp-7.1/async-main.md#detailed-design) Okudu�uma g�re `main` methodu `C#7.1`'den beri Async olarak a�a��daki gibi kullan�labilmekteymi�.
```
static Task Main()
static Task<int> Main()
static Task Main(string[])
static Task<int> Main(string[])
```



### Tupple

[Burada](https://github.com/dotnet/csharplang/blob/main/proposals/csharp-7.1/infer-tuple-names.md#infer-tuple-names-aka-tuple-projection-initializers) yaz�lana g�re ve orada verdi�i koda g�re siz arama yaparken tek de�i�kene zorunlu demeyeylim ama genel olarak mecbur kalman�z� ��zmekte.
<br>
```
// "c" and "result" have element names "f1" and "f2"
var result = list.Select(c => (c.f1, c.f2)).Where(t => t.f2 == 1); 
```

�rnek kodda g�r�ld��� gibi sadece iki veri i�in �ekme yap�lmakta. Bu sayede DTO sistemi de�i�ir.



### Range

Ben bunu �ok sevdim. [�lk Geli�ini okumak i�in t�klay�n](https://github.com/dotnet/csharplang/blob/main/proposals/csharp-8.0/ranges.cs) Burada g�sterildi�inin yan�nda art�k `Range` tipine 0 dan 100 e g�ndermek `0..100` ile ifade edilir bu �ok kolay ve biraz `Python`'ca olmu� :D



### Partial

[Buradan](https://github.com/dotnet/csharplang/blob/main/proposals/csharp-9.0/extending-partial-methods.md) bakarsan�z `partial` sadece s�n�f� de�il methodlar�da kapsar ve bu sayede art�k kimin eli kimin cebinde bilemezsiniz.

### Nint

[Buradan](https://github.com/dotnet/csharplang/blob/main/proposals/csharp-9.0/native-integers.md) bkarasan�z asl�nda �ok maliyetli oldu�unu g�receksiniz.
<br>
`Native` olmas�ndan dolay� doan�ma g�re �ekillenmesi �ok iyi fakat resimdende g�rece�iniz gibi bende 64 bit olarak �al���yor bunun yerine 64 bit kullansam daha iyi ki o kadar b�y�k say�lara ihtiyac�m yok.
![Resim Yok](./uint.png)


### Paragraf String

[Buradan](https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/raw-string-literal.md) anlat�ma gidebilirsiinz.<br>
Normalde hat�rlad���m kadar� ile �ok sat�rl� `string` yoktu `C#11` de gelen �zelliklerde g�rd�m �imdi ve g�zel gelmi�.
`""" paragraflar """` �eklinde kulan�m� var. Ayr�ca ba��na `$$` koyarakta i�eride de `{{value}}` ile veri tipini g�mebilirsiniz.


Biraz �nce ��rendim ki bu i�lemi `@` ile de yapabiliyormu�uz. Yani siz<br>
```
string paragraf = @"
asd
asd
asd
asd
";
```
�eklinde �ok sat�rl� string yapabiliyormu�sunuz.

```
Console.WriteLine(@$"
{a}
{b}
{c}
");
```
bu �ekilde de de�i�kenleri g�mebilirsiniz.


### Span ve Memory
Bunlar�n maliyeti y�ksek terimler.<br>
`Span` ramde istenilen yeri tutmay� sa�lar. `ReadOnlySpan` ise ramde istenilen yeri okumay� sa�lar. `Span` `ref struct` oalrak tasarlanm�� bir `struct`'t�r. `Memory` `span`'�n daha serbest t�r�d�r.   



### Regular Expressions

[Regex i�in T�kla](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-7.0)<br>
[geeksforgeeks](https://www.geeksforgeeks.org/what-is-regular-expression-in-c-sharp/)<br>
En k�sa yol ise ChatGPT'ye yazd�rmak :D
#### ^ Operatoru

Sat�r ba��n�n istenilen ifadede ba�lanmas�n� sa�lar.<br>

`^9` => �stenilen metin `9` ile ba�lamak **zorundad�r**. <br>

#### \ Operatoru

Belirli Karakter gruplar�n� i�ermesini istersek kullan�r�z.<br>


`\D` => Rakam olmayan demek.<br>
`\d` => Rakam demek.<br>
`\W` => Alfanumeric olmamas� demek.<br>
`\w` => alfanumeric olmas� demek.<br>
`\S` => Boluk olmamas� gerekti�ini belirtir.<br>
`\s` => Bo�luk olmas� gerekti�ini belirtir.<br>
<hr>
`\B` => Kelimenin ba��nda yada sonunda olmamas� gerekenler belirtilir.<br>
`\b` => Kelime belirtilen karakter dizisi ile sonlan�r.<br>

#### + Operatoru

Belirli gruptaki karakterlerden bir yada daha fazla olmas�n� istiyorsan kullan�rs��n.
<br>

`^9\d+\s` => 9 ile ba�layan arada herhangi bir say� olan son karakteri bo�luk olmayan demek.<br>

#### | Operatoru

birden fazla karakter grubundan bir yada bir ka��n�n ilgili yerde olabilece�ini belirtmek istiyorsan kullan�r�z<br>

`a|b|c` => ba� harfi a yada b yada c olan

#### \{ n \} Operatoru

sabit say�da karakterin olmas� isteniyorsa `{adet}` �eklinde verilmeli<br>

Telefon numaram�z olsun. Kontrol i�in `regex` yazmak istedik diyelim.<br>
`\d\d\d-\d\d\d-\d\d-\d\d` => bunun gibi xxx-xxx-xx-xx format� yerine Tekrar oldu�u i�in<br>
`\d{3}-\d{3}-\d{2}-\d{2}` => uzunluk ayn� olabilir ama daha rahat anla��l�r oldu.<br>

#### ? Operatoru

�n�ne geldi�i karakterin en az s�f�r en fazla bir kere olmas�n� belirtir.<br>
`B?A` => burada i�inde bir kere yada hi� `B` olan ve `A` ile biten kelime demek<br>

#### [n] Operatoru

aral�k belirtir. �rne�in<br>
`[a-e]` => a-e aras�nda harfler olmal� demek<br>
`[1-5]` => 1-5 aras� say�lar demek



