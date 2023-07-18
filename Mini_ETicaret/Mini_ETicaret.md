# [Buradaki](https://www.youtube.com/watch?v=th__PLvBxZI&list=PLQVXoXFVVtp1DFmoTL4cPTWEWiqndKexZ) E�itim notudur.

# E-Ticaret sitesi c# api ve Angular var ama Angular� ile �uan U�ra�mam Api K�sm�na Bakaca��m. 


### Backend

`Onion Architecture` kullanarak geli�tirilecek. Daha az ba��ml�l�k sa�layacak.

<br>

�ncelikle Proje Dosyalar�n� resimdeki gibi haz�rlad�k.
![Resim Yok](GithubDocuments/ProjeG�r�n�m�.png)
�imdi projelerin referanslar�n� yani eri�imlerini ayarlamam�z gerekiyor.
![Resim Yok](GithubDocuments/ProjeBa��ml�l�klar�.png)
art�k proje referanslar�da eklendi

<br>

Projeyi sildim. Angular oldu�u i�in sadece biraz ba��n� izleyip bilgi almaya karar verdim. Angular �uan ihtiya� d��� o y�zden bu proje �ok kaliteli olmas�na ra�men bende fazla olacak.
O y�zden ilerde ya buray� g�ncellerim ilerde yada yeni repoda notlar� atar�m

<br>

### Generic Repository Design Pattern

birden fazla veritaban� kullan�m�nda `Generic Repository Design Pattern` yakla��m�n� kullanmal�y�z. `Generic Repository Design Pattern` yakla��m�nda `genericler` ve `interfaceler` arac�l��� ile istenilen durumlar� ay�r�r�z. Ne demek istedim. Temelden al�rsak yazma ve okuma i�lemlerini ay�rarak yazma i�lemlerini `EfCore` ile okuma i�lemlerini `dapper` ile yapabilirsin. Ne i�ime yarar dersen biraz daha h�z katabilir.
<br>
bu sadece okuma ve yazma olarak de�il. �rnek veriyorum `loglar�` `ADO.NET` ile kaydedersin. Bunu yapmak zorunda de�ilsin ama bunlar� yapmaya temel haz�rlamak zorundas�n bana g�re.

<br>

<hr>

E�er takip istemiyorsan `AsNoTracking()` kullan�l�r. Bu bence api projelerinde `default` olarak `AsNoTracking()` olmal�.
<br>


### CORS Politikasi

Evrensel ileti�imde `json` format� kullan�l�r. <br>
`builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()))`<br>
�imdi bu �ekilde `api`'de `Program.cs` dosyas�na ekleme yapt���n�zda gelen ge�ene izin verirsiniz. burada diyorsunuz ki herhangi bir `header`, herhangi bir `method` ve herhangi bir `origin` ile bana gelebilirler.
<br>
`builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:0000", "https://localhost:0000").AllowAnyMethod().AllowAnyHeader()))`<br>
�eklinde haz�rlarsak sadece belirtilen adres ile at�lan isteklere apimiz istek verir hatta headerda bearer token ile �yelerin istekleride eklenebilir bu sayede g�venlik sa�lar�z.<br>

`app.AddCors()` ile bunu sonradan eklemeniz laz�m `app`'te<br>


### Validation filter

`IAsyncActioFilter` arac�l��� ile `action`'a gelen istekleri kontrol edebilriiz.



### Identity








































































