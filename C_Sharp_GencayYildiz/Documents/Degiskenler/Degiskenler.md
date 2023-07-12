# De�i�kenler

- [IsPrimitive](###isprimitive)
- [De�i�kenlerin A��klamas�](###degiskenlerin-aciklamasi)
- [Tuple](###tuple)
- [var ve dynamic keyword'leri](###var-ve-dynamic)
- [Tur D�n�s�m�](###tur-donusumu)






### IsPrimitive

Saf t�r m�? demektir. Saf t�r derken ise e�er ba�ka tiplerden olu�turuluyorsa bu tip `primitive`
de�il demektir. �rne�in decimal arkada intlerden olu�turulmakta oldu�u i�in false cevab�n� d�ner.
[Peki Ne i�imize yarar.](./BilememKarde�.md)

<pre><code class='language-cs'>public void Main()
{
	Console.WriteLine(typeof(decimal).IsPrimitive);
	Console.WriteLine(typeof(int).IsPrimitive);
	Console.WriteLine(typeof(byte).IsPrimitive);
}</code></pre>
![Resim yok](./Isprimitive.png)

### Degiskenlerin Aciklamasi

| T�r     | A��klama | Aral�k
| ---      | ---       |
| Bool     | Do�ru veya Yanl��. Olmak veya olmamak hepsi bu |0-1 (True- False)|
| char     | karakter tutar | 16 bit Unicode |
| sbyte    | Pozitif veya negatif aral�kta k�sa say� tutar | -128 - 127 |
| byte     | sadece pozitif tam say� | 0 - 255 |
| short    | Pozitif veya negatif olarak 16 bit tutar | -32_768 - 32767 aras�|
| ushort   | sadece pozitif olarak 16 bit tutar  | 0 - 65_535 aras� |
| int      | Pozitif veya negatif 32 bit tutar | -2_147_483_648 - 2_147_483_647 aras�  |
| uint     | sadece pozitif 32 bit tutar | 0 - 4_294_967_295 |
| long     | Pozitif veya negatif 64 bit say�| -9_223_372_036_854_775_808 ile 9_223_372_036_854_775_807 aras� |
| ulong    | sadece pozitif 64 bit tutar | 0 ile 18_446_744_073_709_551_615 aras� |
| float    | virg�ll� say� tutar | [Aral�k ��in Buraya git](https://learn.microsoft.com/tr-tr/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types) |
| double   | daha geni� virg�ll� say� tutar        | [Aral�k ��in Buraya git](https://learn.microsoft.com/tr-tr/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types) |
| decimal  | ondal�k say� 128 bit | [Aral�k ��in Buraya git](https://learn.microsoft.com/tr-tr/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types) |

Ki�isel Not: Bunlar�n bu kadar �ok olma sebebi performansta �nemli olmas� olabilid�ince ihtiyac�m�z olan� kullanmak laz�m.

### Tuple

i�ine ayn� anda birden fazla obje alan bir t�rd�r. Buradaki int veya
stringleri kendi s�n�flar�n�zla da de�i�tirebilirsiniz.

<pre><code class='language-cs'>public void Main()
{
        (int a, string b, double c) customType = (1, "ahmet", 3.14);
        
        Console.WriteLine(customType);
        Console.WriteLine(customType.a);
        Console.WriteLine(customType.b);
        Console.WriteLine(customType.c);

        customType = (2, "taha", 2.72);

        Console.WriteLine(customType);
        Console.WriteLine(customType.a);
        Console.WriteLine(customType.b);
        Console.WriteLine(customType.c);
}</code></pre>

![Resim yok](./tuple.png)


### var ve dynamic

`var` de�eri geli�tirme a�amas�nda al�r. `dynamic` ise derleme s�ras�nda tipi al�r.

`dynamic` ile tan�mlanan bir de�i�kende tip de�i�imi m�mk�nd�r. 

<pre><code class='language-cs'>public void Main()
{
    dynamic tip = 3;
    Console.WriteLine(tip.ToString() + " " + tip.GetType());
    tip = "Ahmet";
    Console.WriteLine(tip.ToString() + " " + tip.GetType());
}</code></pre>

![Resim Yok](./TipDegisimi.png)

* T�r� bilinmeyen uzak verileri kar��lamada kullan�labilir.


### Tur Donusumu

`bilin�siz d�n���m` = ``` byte a = 10; short veri = a;``` -> bilin�siz d�n���md�r derleyici otomatik yapar
`bilin�li d�n���m` = ``` short a = 10000; byte veri = (byte)a;``` -> bilin�li d�n���mde burada siz belirtmedik�e d�n��t�rmez. Sizin `bilin�li` olarak yazman�z laz�m.

`check` = bilin�li d�n���mde veri kayb� varsa hata f�rlat�lmas�n� sa�lar
`uncheck` = bilin�li d�n���m s�ras�nda veri kayb� varsa �nemsemeden devam et demek

`is` -> `is` ile tip kontrol� yap�labilir. x `is` bool gibi true ise bool'dur









