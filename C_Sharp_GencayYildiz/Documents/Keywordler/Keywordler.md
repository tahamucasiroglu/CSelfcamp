# Keywordler

[T�m Keywordler i�in t�klay�n.](https://learn.microsoft.com/tr-tr/dotnet/csharp/language-reference/keywords/)<br>
Keywordler Programlama dilinin temelidir.<br>



* [Explicit ve Implicit](###explicit-ve-implicit)
* [Checked](###checked)
* [Extern ](###extern )
* [Lock](###lock)
* [Params](###params)
* [Ref](###ref)
* [Stackalloc](###stackalloc)
* [Unsafe ](###unsafe )
* [Sealed](###sealed)
* [Volatile](###volatile)
* [File](###file)
* [Patial](###patial)
* [Record](###record)



### Explicit ve Implicit
C#11 ile gelmi� m�thi� bir �zellik. 
Microsoft'un kendi sitesinde verdi�i koda bakarsak.
```
1  using System;
2  
3  public readonly struct Digit
4  {
5      private readonly byte digit;
6  
7      public Digit(byte digit)
8      {
9          if (digit > 9)
10         {
11             throw new ArgumentOutOfRangeException(nameof(digit), "Digit cannot be greater than nine.");
12         }
13         this.digit = digit;
14     }
15 
16     public static implicit operator byte(Digit d) => d.digit;
17     public static explicit operator Digit(byte b) => new Digit(b);
18 
19     public override string ToString() => $"{digit}";
20 }
21 
22 public static class UserDefinedConversions
23 {
24     public static void Main()
25     {
26         var d = new Digit(7);
27 
28         byte number = d;
29         Console.WriteLine(number);  // output: 7
30 
31         Digit digit = (Digit)number;
32         Console.WriteLine(digit);  // output: 7
33     }
34 }
```

Burada `16.` ve `17.` sat�rlar bizim meselemiz. `16.` sat�rda normalde `double` ile `int` aras�nda otomatik ger�ekle�en `implicit` d�n���m�n� burada manuel vermi� oluyoruz. Sebebi ise bunu program anlayamaz. K�saca diyoruz ki e�er biri bu s�n�f� `byte` yapmak isterse buras� a�l���r ve buradaki de�er d�ner. Kodumuzda bu de�er `digit` de�i�kenidir.<br>
`17.` sat�r da tam tersi. E�er biri `byte` t�r�nden bizim `Digit` s�n�f�n� �retmek isterse `17.` sat�r �al���r. Bize gelen de�eri istedi�imiz i�lemler sonras� `Digit` tipi d�necek �ekilde ayarlar�z bu sayede `byte` tipinden `digit` tipine d�n���m� otomatikle�tirmi� oluruz.<br>
Dersen ki ben bununla ne yapay�m. `Mapping` kavram�n� duymu�sunuzdur. Duymad�ysan�zda okumaya devam edin. `Mapping` kavram�ndan �retilen [`AutoMapper`](https://github.com/AutoMapper/AutoMapper) k�t�phanesi genelde web uygulamalar�nda kullan�l�r. Temel amac� s�n�flar� birbirine d�n��t�rmektir. 

```
CreateMap<AddAnswerRequestDTO, Answer>().ReverseMap();
CreateMap<AddAnswerTypeRequestDTO, AnswerType>().ReverseMap();
CreateMap<AddAnswerValueRequestDTO, AnswerValue>().ReverseMap();
CreateMap<AddQuestionRequestDTO, Question>().ReverseMap();
CreateMap<AddResponseRequestDTO, Response>().ReverseMap();
CreateMap<AddSurveyRatingRequestDTO, SurveyRating>().ReverseMap();
CreateMap<AddSurveyRequestDTO, Survey>()
    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => Guid.NewGuid()))
    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.Now))
    .ForMember(dest => dest.IsEnd, opt => opt.MapFrom(src => false))
    .ReverseMap();
CreateMap<AddUserRequestDTO, User>()
    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password.ToSha256()))
    .ForMember(dest => dest.UserStatusId, opt => opt.MapFrom(src => 3))
    .ReverseMap();
CreateMap<AddUserStatusRequestDTO, UserStatus>().ReverseMap();
```

�rne�in yukar�da s�n�flar�n de�i�ken adlar� ayn� oldu�u i�in bir birine ba�lamam gerek yok [`AutoMapper`](https://github.com/AutoMapper/AutoMapper) hepsini otomatik yap�yor. Sadece kodda baz� de�erleri d�n���mde atamak istersem yada �ifreleri `kripto`layarak atamak istersem �zel oalrak belirtmem laz�m. [`AutoMapper`](https://github.com/AutoMapper/AutoMapper)'�n dezavantajlar� yok mu var. En basiti ek bir paket ek bir `IMapper` ad� alt�nda her yere mapper g�ndermek gerekmekte. Bunlardan dolay� i�leri kendimiz yapmak istersek her �ey kontrol�m�zde olsun dersek.
<br>
`Explicit ve Implicit` methodlarla kendimiz tan�mlar�z. Burada `byte` ile g�sterildi�i i�in �imdi dedi�im yap�lamaz fakat e�er kendi kodumdan g�sterdi�im �rnekteki gibi bir d�n���m eklemek ister isek bir d�zende bunu yapmal�y�z. Yani iki s�n�f olsun elimizde `A` ve `B` ben bu iki kendi �retti�im s�n�f� birbirlerine d�n��t�recek isem her s�n�fta sadece `explicit` method olmal�. Buna `byte - int - string` gibi m�dehale edilemeyen tipler dahil de�ildir. Peki neden? Daha �nce g�rmediniz muhtemelen bunu ��nk� kendi fikrim. Bunun tek sebebi `Clean Code` i�in, e�er her s�n�f sadecce kendine geri d�n���m� �retir ise yani `explicit` olarak �retirse. Siz sonradan bir de�i�iklik yapmak istedi�inizde nereye gidece�inizi nokta at��� bilebilirsiniz.
�rne�in;<br>
`A1` - `B1` - `C1` - `D1` - `E1`<br>
`A2` - `B2` - `C2` - `D2` - `E2`<br>
 S�n�flar� olsun. S�n�flarda `1`ler ve `2`ler kendi aralar�nda d�n��ebilsin. Siz kodda bir yerlerde bunu kullan�rken bir �zellik eklemek istediniz. Mesela `C1`'den `C2`'ye d�n���mde `Console.WriteLine()` eklemek istediniz. Normalde 2 yere bakman�z laz�m. `C1`'de `implicit` mi yapt�n yoksa `C2`'de `explicit` mi? E�er benim dedi�im uygulan�r ise `int - string ` gibi `struct` t�rlerde m�dahale olmad��� i�in onlarda `implicit` kalan t�m d�n���mlerde `explicit` kullan�l�r. Bu sayede siz direk `C2`'ye bakman�z gerekti�ini bilirsiniz. �ok gerekli g�z�kmesede bunlar yaz�l�ma sanatsal dokunu�lar katan detaylar olmakta. <br>
Bu arada bunlar� kodlamakta zorluk �ekiyorsan�z. `explicit` de `exp` size `export`'u temsil eder buda `ihracat` demek. Yani oldu�u s�n�f� d��ar� g�nderir. Mant�k d��� kodlama isterseniz. `implicit`'te `imp` biraz `in`'e benzer oda i�ine bulundu�u s�n�f� al�r. <br> K�saca d�n���mleri bu halde k�sa ve net tutabilir performans sa�layabilir ve d��a ba��ml�l��� yok edebbilirsiniz.  [`AutoMapper`](https://github.com/AutoMapper/AutoMapper) bir g�n kapan�rsa sizin umrunuzda olmaz :D
<br>
son olarak `D1` ile `int` aras� d�n���m isterseniz. Bu durumda `D1`'e `implicit` edeceksiniz evet ama ba�ka se�ene�iniz olmad��� i�inde direk yerini bileceksiniz.

<br>
<br>


### Checked
[Githup .md si i�in t�klay�n](https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/checked-user-defined-operators.md)
<br>
k�saca normalde `bit` ta�malar� i�in `check` ve `uncheck` vard�. Buda bunun operat�r halidir.
<br>
Microsoftta verilen koda bakarsak
```
public record struct Point(int X, int Y)
{
    public static Point operator checked +(Point left, Point right)
    {
        checked
        {
            return new Point(left.X + right.X, left.Y + right.Y);
        }
    }
    
    public static Point operator +(Point left, Point right)
    {
        return new Point(left.X + right.X, left.Y + right.Y);
    }
}
```

Ne anl�yoruz hi�bir �ey :D. �ki adet `+ operat�r�` var. Farklar� ise `checked` `keyword`'�. Asl�nda olay basit siz toplama i�lemi kullan�rken e�er a�a��daki gibi `checked` i�ine al�rsan�z. Bunu `checked` olan toplama operat�r�ne sokar ve bu sayede orada ayr� bir kontrol yap�labilir. E�er `unchecked` i�inde yaparsan�z bu sefer `checked` olmayan `operat�r` ile i�lemi yapar. A�a��daki resimlerde olaylar a��klanm��t�r.

>- Resim 1


![resim yok](checked1.png)

>- Resim 2

![resim yok](checked2.png)

>- Resim 3

![resim yok](checked3.png)

>- Resim 4

![resim yok](checked4.png)


### Extern 

Bunu ayr�nt�l� anlatamam ��nk� daha �nce `.dll` veya ek programlarla �al��mad�m. Nedense `c++`'da bunu kullnad�m gibi hat�rl�yorum fakat `C#` i�in ara�t�rd���mda hi� tan�d�k gelmedi. <br>
�imdi olay �u siziz kontrol edemedi�iniz veya derleyicide kod olarak olmayan yani d��ar�dan bir nevi `api` gibi istek atarak ileti�im kurdu�unuz `.exe` veya `.dll` gibi bir dosyan�z var kabul edelim. Senaryomuzuda ��yle �ekillendirirsek. <br>
`Api` ile ileti�im kuran bir `.dll` olsun. Her ihtiyac�n�z� arkada��n�za s�yl�yorsunuz ve `.dll` ye ekliyor. Bir s�re sonra versiyonlar ilerliyor. Sizin bir sorununuz oldu ve son versiyonda �ncekilerde �al��an `method` hata verdi. Arkada��n�zda tatilde a�m�yor telefonu tabi. Sizde kald�n�z ortada. Tam umutsuzlu�a d��ecekken akl�n�za hemen `extern` geliyor. (Reklam gibi oldu)
<br>
`/r:apiDllV1 = api.dll`
<br>
`/r:apiDllV2 = api2.dll`
<br>
`extern` ile `api=api.dll` olarak �ekti�in `api`'yi biraz elleyerek
<br>
`extern apiDllV1;`
<br>
`extern apiDllV2;`
<br>
yapars�n. Sonrada bunlar�
<br>
`using apiV1 = apiDllV1::Namespace.Api;`
<br>
`using apiv2 = apiDllV2::Namespace.Api;`
<br>

Burada `extern` ile ayn� i�i yapan farkl� versiyon program oldu�unu belirttik. Yapmasakta olur muydu bence olurdu. dedi�im gibi deneyemedim bence diyebilirim. Yine bence mutlaka performans olarak katk�s� vard�r.



### Lock

Bunuda test edemedim fakat a��r�k ullan��l� bir �ey. [Microsoft'tan okumak i�in t�kla](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock)<br>
Mant�k �ok basit `thread` gibi bir nesneye ayn� anda birden fazla yerden eri�im olabiliyorsa ve bu eri�ilen nesne �nemli ise onu `lock` ile orada kitliyoruz ve biz serbest b�rakana kadar orada kal�yor.
<br>
microsoft sitesindeki kodda `balance` de�erini `lock` ile kitleyerek o s�ra `balance`'a m�dahale edilmesini �nl�yor. Asl�nda g�venlik i�inde �ok yararl�. `thread` d��� kullan�mada uygun. `Performans�` kesin etkiler bence. onada dikkat edilmeli.<br>


### Params

`Params` ile `methoda` s�n�r olmaks�z�n istedi�iniz kadar, daha do�rusu g�nderildi�i kadar veri alabilirisiniz.

<br>

```
public static void UseParams(params int[] list)
public static void UseParams2(params object[] list)
```

<br>

Yukar�da ikiside tip olarak fakrl� olsada say� olarak ne verildiyse onu al�r. Bu nerede i�e yarar mesela `Add` diye fonsiyon varsa g�nderirsin `params int[] list`'i gelen ne varsa toplars�n d�nd�r�rs�n. Eri�im i�in `list[index]` �eklinde eri�im mevcut. 

### Ref

`ref` `keyword`'� ile normalde listelerde olan methodda veri de�i�iminin d��ar�da da olmas�n� normal tekil verilerde de sa�lar�z. 
<br>
Microsoft sitesindeki koda bakarsak.
```
void Method(ref int refArgument)
{
    refArgument = refArgument + 44;
}

int number = 1;
Method(ref number);
Console.WriteLine(number);
// Output: 45
```

Normalde `int` de�eri de�i�mez ve ��kt� `1` olurdu fakat burada `45` olmakta buda `ref` eki ile sa�lanmakta.



### Stackalloc 

G�r�nce `C`'deki `malloc` geldi akl�ma. Bunlar zevkli �eyler ama �uan bununla e�lenecek vaktim yok maalesef. 
<br>
[microsoft kayna�� i�in t�kla](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/stackalloc)
<br>
[Stackalloc array initializers](https://github.com/dotnet/csharplang/blob/52b90748d1ebab0268468eb5dc8e954bc98c2834/proposals/csharp-7.3/stackalloc-array-initializers.md)
<br>
[Permit stackalloc in nested contexts](https://github.com/dotnet/csharplang/blob/52b90748d1ebab0268468eb5dc8e954bc98c2834/proposals/csharp-8.0/nested-stackalloc.md)
<br>
Buralardan bakarak ara�t�rabilirsiniz.

### Unsafe 

[Stackalloc](###stackalloc) gibi `pointer`'larla u�ra��l�rken methodun g�venli�inin zay�f oldu�unu s�ylemek i�in kullan�l�r. A��k�as� bunu denemedim o y�zden tam olarak a��klad���mdan emin de�ilim. 
<br>
[Microsoft sitesi](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/unsafe)
[Github Reposu](https://github.com/dotnet/csharpstandard/blob/standard-v6/standard/unsafe-code.md#22-unsafe-code)




### Sealed

Bir s�n�f�n miras vermemesini istiyorsan�z `sealed` ile i�aretlemeniz gerekli �rne�in;<br>
```
class A {}
sealed class B : A {} -> art�k miras veremez
class C : B -> hata verir
```
bu kadar derin bir olay� yok. Yani **benim bildi�im** yok

### Volatile

[Lock](###lock) k�sm�nda anlatt���m�z mant���n tam tersi. `volatile` ile i�aretlenen bir alan�n ayn� anda y�r�t�len birden �ok kod par�ac��� taraf�ndan de�i�tirilebilece�ini belirtir. 100 `thread`'de ayn� anda buna de�er g�nderebilir yani. Bir nevi [`Race Condation`](https://medium.com/@gokhansengun/race-condition-nedir-ve-nas%C4%B1l-%C3%B6nlenir-174e9ba3f567) durumlar�n� engellemek i�in oldu�unu anlad�m.[Ek bilgi i�in](https://medium.com/@gokhansengun/semaphore-mutex-ve-spinlock-nedir-ve-ne-i%C5%9Fe-yarar-ba552a17c03#:~:text=Farkl%C4%B1%20Thread'ler%20taraf%C4%B1ndan%20payla%C5%9F%C4%B1lan,b%C3%B6lgesi%20Critical%20Section%20olarak%20adland%C4%B1r%C4%B1l%C4%B1r.)  


### File

�imdi `ayn� namespace` i�erisinde `farkl� dosyalarda` bulunan `ayn� isimli class`'lar normalde hata vermekteydi. Fakat `file` ile bu serbest kald�. Ayr�nt�ya girersek<br>
```
//Ahmet1.cs
namespace Kodlar.Dosya1
{
    class Ahmet {  }
}

//Ahmet2.cs
namespace Kodlar.Dosya1
{
    class Ahmet {  }
}
```

normalde bunlar hata verir ki �stteki kodda hata verir. Farkl� dosyalarda olmas� `C#`'�n umrunda de�il. Daha do�rusu de�ildi.
<br>
�imdu buraya `file` eklersek

```
//Ahmet1.cs
namespace Kodlar.Dosya1
{
    file class Ahmet {  }
}

//Ahmet2.cs
namespace Kodlar.Dosya1
{
    class Ahmet {  }
}
```
Art�k hata almazs�n�z ve i�lemleri yapars�n�z.
<br>
Peki s�n�flar�n farkl� m�? = Evet iki s�n�fta farkl� isimli s�n�f gibi d���n.
<br>
Birine `file` desen olur ��nk� iki tane 5 tane olsayd� 4'�ne `file` demek gerekecekti. Hepsine desende olur.

### Patial

[File](###file) gibidir. Biraz fark� var. �imdi bizim baz� s�n�flar�m�z var bu s�n�flar binlerce sat�r koddan olu�uyor. �rne�in Okul s�n�f� olsun 5000 sat�r kod. Tek yerde �ok kod var. Sa�olsun bizi d���n�p `patial` ekini getirmi�ler. Olaya ge�ersek. okul s�n�f�ndaki 5000 sat�r�n<br> 
1000 sat�r� ��renci kodlar� <br>
1000 sat�r� ��retmen kodlar� <br>
1000 sat�r� okul kodlar� <br>
1000 sat�r� para kodlar� <br>
1000 sat�r� veli kodlar� <br>
olsun sall�yoz soonu�ta<br>
normalde neydi okul s�n�f� = 5000 sat�r koddu art�k de�i�ti <br>
`Okul/Okul.cs Dosyasondan  class Okul = 5000 kod` <br>
bunu d�n��t�r�yoruz<br>
`Okul/Okul��renci.cs Dosyasondan   partial class Okul = 1000 kod` <br>
`Okul/Okul��retmen.cs Dosyasondan  partial class Okul = 1000 kod` <br>
`Okul/OkulOkul.cs Dosyasondan      partial class Okul = 1000 kod` <br>
`Okul/OkulPara.cs Dosyasondan      partial class Okul = 1000 kod` <br>
`Okul/OkulVeli.cs Dosyasondan      partial class Okul = 1000 kod` <br>
mant�k �u sen art�k `partial` �n eki ile `ayn� namespace` i�erisinde `farkl� dosyalarda ayn� s�n�f�` tan�mlars�n. Fakat bunlar yine tek sayfadaki 5000 sat�rl�k kod gibi davran�r. Bu sayade geli�im ve d�zen daha rahat olur. Genel s�n�f�n�z varsa ve i�erisinde farkl� alanlar varsa `partial` ile ay�rmak g�zel g�z�kmeye yard�mc� olabilir. 
<br>
sadece `class` m�? Hemen s�yleyeyim hay�r. `Fonksiyon`larda da oluyor. :D


### Record

Bir s�n�f�n�z varsa ve bu s�n�f olu�tuktan sonra de�i�meyecek ise `record` ile i�aretlersiniz. Bu sayede performans art��� oldu�u gibi yanl��l�kla de�i�mesinide �nleriz. 
<br>
bir s�r� y�ntemi var tekte g�sterelim. senaryo �u `Id:int Name:string IsActive:bool` tutan s�n�f laz�m. 

```
Y�ntem 1:
public record Person(int Id, string Name, bool IsActive);

Y�ntem 2:
public record Person
{
    int Id { get; init; }
    string Name { get; init; }
    bool IsActive { get; init; }
    public Person(int Id, string Name, bool IsActive)
    {
        this.Id = �d;
        this.Name = name;
        this.IsActive = IsActive;
    }
}
```

Burada `Y�ntem 2`'de `init` deme sebebimiz e�er `set` deseydik `record`'un anlam� kalmazd�. `init` ile sadece kurucu methoddan de�er verecem demek oluyor�.





