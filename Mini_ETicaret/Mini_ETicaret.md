# [Buradaki](https://www.youtube.com/watch?v=th__PLvBxZI&list=PLQVXoXFVVtp1DFmoTL4cPTWEWiqndKexZ) Eðitim notudur.

# E-Ticaret sitesi c# api ve Angular var ama Angularý ile Þuan Uðraþmam Api Kýsmýna Bakacaðým. 


### Backend

`Onion Architecture` kullanarak geliþtirilecek. Daha az baðýmlýlýk saðlayacak.

<br>

Öncelikle Proje Dosyalarýný resimdeki gibi hazýrladýk.
![Resim Yok](GithubDocuments/ProjeGörünümü.png)
Þimdi projelerin referanslarýný yani eriþimlerini ayarlamamýz gerekiyor.
![Resim Yok](GithubDocuments/ProjeBaðýmlýlýklarý.png)
artýk proje referanslarýda eklendi

<br>

Projeyi sildim. Angular olduðu için sadece biraz baþýný izleyip bilgi almaya karar verdim. Angular þuan ihtiyaç dýðý o yüzden bu proje çok kaliteli olmasýna raðmen bende fazla olacak.
O yüzden ilerde ya burayý güncellerim ilerde yada yeni repoda notlarý atarým

<br>

### Generic Repository Design Pattern

birden fazla veritabaný kullanýmýnda `Generic Repository Design Pattern` yaklaþýmýný kullanmalýyýz. `Generic Repository Design Pattern` yaklaþýmýnda `genericler` ve `interfaceler` aracýlýðý ile istenilen durumlarý ayýrýrýz. Ne demek istedim. Temelden alýrsak yazma ve okuma iþlemlerini ayýrarak yazma iþlemlerini `EfCore` ile okuma iþlemlerini `dapper` ile yapabilirsin. Ne iþime yarar dersen biraz daha hýz katabilir.
<br>
bu sadece okuma ve yazma olarak deðil. Örnek veriyorum `loglarý` `ADO.NET` ile kaydedersin. Bunu yapmak zorunda deðilsin ama bunlarý yapmaya temel hazýrlamak zorundasýn bana göre.

<br>

<hr>

Eðer takip istemiyorsan `AsNoTracking()` kullanýlýr. Bu bence api projelerinde `default` olarak `AsNoTracking()` olmalý.
<br>


### CORS Politikasi

Evrensel iletiþimde `json` formatý kullanýlýr. <br>
`builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()))`<br>
þimdi bu þekilde `api`'de `Program.cs` dosyasýna ekleme yaptýðýnýzda gelen geçene izin verirsiniz. burada diyorsunuz ki herhangi bir `header`, herhangi bir `method` ve herhangi bir `origin` ile bana gelebilirler.
<br>
`builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:0000", "https://localhost:0000").AllowAnyMethod().AllowAnyHeader()))`<br>
þeklinde hazýrlarsak sadece belirtilen adres ile atýlan isteklere apimiz istek verir hatta headerda bearer token ile üyelerin istekleride eklenebilir bu sayede güvenlik saðlarýz.<br>

`app.AddCors()` ile bunu sonradan eklemeniz lazým `app`'te<br>


### Validation filter

`IAsyncActioFilter` aracýlýðý ile `action`'a gelen istekleri kontrol edebilriiz.



### Identity








































































