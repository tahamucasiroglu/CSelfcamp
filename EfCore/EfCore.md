# EF Core

* [Db First](#dbfirst)
* [Code First](#codefirst)
* [Query Tags](#query-tags)
* [Global Query Filters](#global-query-filters)
* [IQuesyable ve IEnumerable](#iquesyable-ve-ienumerable)
* [Deferrend Execution](#deferrend-execution)
* [Sorgular](#sorgular)
* [Sorgu Kalitesi](#sorgu-kalitesi)
* [ExecuteUpdate ve ExecuteDelete Ýþlemleri](#executeupdate-ve-executedelete)
* [Kayýt alma](#kayit-alma)
* [Configs](#configs)
* [Eager Loading](#eager-loading)
* [Explicit Loading](#explicit-loading)
* [Lazy loading](#lazy-loading)
* [View Yapýsý](#view-yapisi)
* [Stored Procedure](#stored-procedure)
* [Scalar ve Inline Functions](#scalar-ve-inline-functions)
* [Configleri Ayrý Kaydetme](#configleri-ayri-kaydetme)
* [Kalýtýmsal Durumlar](#kalitimsal-durumlar)
   * [TPH Table Per Hierarchy](#tph-table-per-hierarchy)
   * [TPT Table Per Type](#tpt-table-per-type)
   * [TPC Table Per Concrete Type](#tpc-table-per-concrete-type)
* [DB Islemleri](#db-islemleri)
* [Logging](#logging)
* [Karýþýk Notlar](#karisik-notlar)

### DbFirst

`DbFirst` demek var olan veritabanýna proje üretmeye veya projede önce veritabanýný inþaa etme yaklaþýmýna denir. <br>
`DbFirst` yaklýþýmýnda veritabanýný ef core ile projeye dahil etmek için database kýsmýnda <br> 
`dotnet ef dbcontext scaffold 'Server=(localdb)\MSSQLLocalDB; Database=Northwind; Trusted_Connection=True;' Microsoft.EntityFrameworkCore.SqlServer` 
<br>
denklemi için `dotnet ef dbcontext scaffold 'Server=[vreitabanýnýnýn olduðu yerin adý]; Database=[veritabaný adý]; [baðlantý durumu direk güven veya id þifre verilebilir];' [veritabaný paketi]`
<br>
sonrasýnda ise resimdeki gibi tabloalr dahil olur.
![Resim Yok](./EfCorescaffold.png)

### CodeFirst

`CodeFirst` için yazmayacam çünkü **BANA GÖRE** var olan veritabanýna proje yapýlmadýkça kullanýlmamalý. Sebebi ise tipleme ve ayarlamalarýn hem `ssms`'da daha kolay olmasý hemde katmanlama için. Yani veritabaný ile sorunlu ekip veritabaný için üretilmiþ geliþtirme ortamýnda geliþtirme yapsýn. `Efcore` yerine dapper kullanasým gelse veritabancýlar ne yapacak acaba `codefirst`'te :D.


### Query Tags 

`Ef Core` ile generate edilen sorgulara açýklama eklememizi saðlayan özelliktir.<br>
`await context.Persons.ToListAsync()` <br>
loglamalarda bu sorgu yanýnda açýklama görmek isterseniz.<br>
`await context.Persons.TagWith("açýklama").ToListAsync()` <br>
yada <br>
`await context.Persons.TagWith("açýklama1").TagWith("açýklama2").ToListAsync()` <br>
yada <br>
`await context.Persons.TagWith("açýklama1").Where(p => p.Id > 5).TagWith("açýklama2").ToListAsync()` <br>
<br>
`TagWithCallSite` kullanýrsan kodun dosya konumunuda verir.


### Global Query Filters

Çoklu yerde kullanmayý saðlayan global `filtre`'ler kullanmayý saðlar.<br>
`Entitiy`'lerin ayarlamalarýnýn yapýldýðý kýsýmda tanýmlanýr.<br>
`modelBuilder.Entity<Person>().HasQueryFilter(p => p.IsAlive)`<br>
yukarýdaki örnekte global filtre tanýmlayarak artýk her insan tablosu sorgulandýðýnda `IsAlive` deðeri `true` olanlarda arama yapcak. <br>
eðer bunu sonradan kullanmadan sorgulamak istersek.<br>
`context.Persons.IgnoreQueryFilters().methodlar..`<br>
þelinde ön tanýmlý filtreleri iptal edebilirsiinz.

### IQuesyable ve IEnumerable
`IQueryable` sorguya karþýlýk gelir. Efcore üzerinde yapýlmýþ sorgunun execute edilmemiþ hali demektir.
<br>
`IEnumerable` ise execute edilmiþ memorydeki halidir.

### Deferrend Execution 
yaptýðýn sorgularda parametre deðerleri sonradan deðiþirse ve sen sorguyu sonradan execute edersen güncel parametreye göre sorgu çeker. örneðin

![Resim Yok](deferrend_execution.png)

burada id yi 5 ten büyük deðil 200 den biyik olanlarý getirir.

### Sorgular

`ThenBy` -> orderby sorgusunu çoðaltmak için kullanýlýr.<br>
`OrderByDescending` -> orderby in tersi büyükten küçüðe yani<br>
`ThenByDescending` -> ek olarak tersine sorgula<br>
`Any` -> sorgu sonucu veri geliyor mu gelmiyor mu <br>
`All` -> tüm veriler þarta uyarsa true döner aksi halde false<br>
`GroupBy` -> gruplar adý üzerinde verilen duruma göre gruplar<br>

### Change Tracker

`SaveChangesAsync(false)` þeklinde kullanýmda kaydedilen verilerin takibi devam eder.


### Sorgu Kalitesi

#### 1
`IQueryable` ile `IEnumerable` ayrýmýnýn yapýlmasý
<br>
Eðer `IEnumarable` ile yapmak istersen `context.Entity.AsEnumarable().methodlar` þeklinde ilerlenir.
<br>
tercih `IQueryable`

#### 2
`Select` methodu ile gerekli kolonu getirerek maliyeti azaltabilirisin.
<br>


#### 3
`result`'ý limitle. tablodaki verileri alýrken limitleyin.<br>
`context.Persons.ToList()` yerine<br>
`context.Persons.Take(sayý).ToList()` ile daha saðlýklý iþ olur. tabloda bilyonlarca veri varsa hepsini çekmeye gerek yok.
<br>

#### 4
`asenkron yani async` tercih edin.

### ExecuteUpdate ve ExecuteDelete

bunlar sayesinde toplu güncelleme ve silmede kolaylýk ve performans geldi. efcore 7 özelliði


### Kayit Alma
[Burada](https://learn.microsoft.com/tr-tr/ef/core/performance/performance-diagnosis?tabs=simple-logging%2Cload-entities) Burada anlatýlana göre eðer sorgularý kontrol etmek isterseniz yani program sýrasýnda veritabanýna gönderilen sorgularý kontrol etmek isterseniz. <br>

```
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder
        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True")
        .LogTo(Console.WriteLine, LogLevel.Information);
}
```
þekline `.LogTo` methodundan yararlanabilirsiniz. bu `Konsol`'a info ve üstü bilgileri basar. [`Query Tags`](###query-tags) kullanarakta bunlara bilgi gömebilirisiniz. 


### Configs


modelBuilder.Model.GetEntityTypes(); ile entitlerin tiplerini liste halinde alabilirisn<br>

`ToTable` -> üretilecek tablonun adýný belirler <br>

`HasColumnName` - `HasColumnType` - `HasColumnOrder` -> ile kolon isim tip ve sýra ayarlamasý yapabilirisin. <br>

`ForeignKey` -> tabloda baþka tablo adý + Id varsa kendi oto ayarlar ama manuel istersen bununla baðlantý ismini tanýmlarsýn.
```
modelBuilder.Entity<Person>()
    .HasOne(p => p.Department)
    .WithMany(d => d.Persons)
    .HasForeignKey(p => p.Id);
```
þeklinde tanýmlama ile tanýmlanabilir.
<br>

`Ignore` -> Tüm propertyler kolon olarak eklenir. bazen property lazým olur ama tabloya koymayacaksýn o zaman bunu kullanýrsýn. ` entity<person>().ýgnore(p=>p.asdasd) ` <br>

`HasKey` -> Efcore da default olarak Id tanýmlýlar key oalrak tanýmlanýýr. bunu kendi istediðini vermek için Key kulanýlýr. eðer tabloda primary key yoksa hata verir. 

`IsRowVersion` -> versiyon tutar. byte[] tipimnde tutulur. `entity<person>().property(p=>p.asdasd).IsRowVersion();` <br>

`IsRequired` -> deðerin girilmesini zorunlu olduðunu ifade eder. <br>

`HasMaxLength` -> string deðerlerin uzunluðunu belirtir. property sonrasý kullanýlýr.<br>

`HasPrecision(5,3)` -> sayýlarýn virgül öncesi ve sonrasý uzunluklarýný belirler. <br>

`IsUnicode` -> kolon içerisinde unicode karakter varsa kullanýlýr.<br>

`HasComment` -> kolonlara açýklamalar ekler.<br>

`IsConcurrencyToken` -> verinin bütünlüðünü kontrol eder. `Property` sonrasý kullanýlýr.<br>

`Composite key` -> tabloda birden fazla kolon `primarykey` yapýlmak istenirse kullanýlýr. `entity<person>.HasKey(key1,key2,key3)` verilir. <br>

`HasDefaultSchema` -> `[dbo]` þeklinde olan default þemalarý ezmeyi saðlar. <br>

`HasDefaultValue` -> `property` sonrasý kullanýlýr. property e default value atanýr. <br>

`HasDefaultValueSql` -> `property` sonrasý kullanýlýr. property e default value atanýr. deðer sql olarak atanýr. sql de atanýr yani tarih için datetime  deðil getdate() olur. sadece bu deðil bu arada direk sql komutuda olur. sadece fonsiyon olarak vermen lazým.<br>

`HasComputedColumnSql` -> birden fazla kolonu belirli hesaplamalar ile tek kolona baðlama diyebiliriz. name ve surname i full name ile kolona yazdýrma gibi düþün. tabi bu ýgnore bir property ile yapmak daha iyi db den bir property az çekilir bve tutulur ek performans<br>

`HasConstraintName` -> constraint isimlerini baskýlar. foreing key isimlerini filan ayarlarsýn <br>

`HasData` -> seed lemede kullanýlýr. hazýr veri hazýrlar.<br>

`HasDiscriminator` -> entityler arasý kalýtýmda kullanýlýr. miras alan tiplerin ayrýmýnda kullanýlýr default olarak string türünde isimleri tutar sonrasýnda has value ile tiplere özel deðer atarsýn.<br>

`HasNoKey` ->  primarykey kolonu olmak zorunda ama yoksa bunu belirtmelisin bununla yoksa hata alýrýsýn.<br>

`HasQueryFilter` ->  bununla sorgularýn hepsinde uygulanacak sorgu eklenir mesela silindimi diye bir deðerde false getirmek istersen burada belirtirsin baþka yerde uygulamazsýn. Burada verip üstüne sorguda bir daha yazarsan performans kaybý olunur. <br>

`Identity` -> otomatik artan demektir. bir tabloda tek bir tane olabilir. bir kolon olabilir.

`HasIndex()` -> sorgularda performans arttýrýmý saðlar. FK, PK ve AK olan kolonlar otomatik indexlenir.(index aramalarda kullanacaðýný belirterek o kolonun arama için optimize olmasýný saðlýyor diye anladým.) farklý kolona index atamak için `entitiy<T>().HasIndex(x => new {x.asdasd, x.asdasd, x.asdasd,....})`  sonuna `.IsUnique()` koyarsan benzersiz dersin ve performansý arttýrýrsýn. `HasFilter()` kullanýrsan sonuna indexlemede filtreleme yapar. ayrýca sona `IncludeProperties` ile ilerde sorgulamada kullanabileceðin verileri söylersen bunlarýda tyabloya yandan ekler ve ilerde kullandýðýnda boþ yere maliyeti yükseltmez <br>

`HasSequence` -> Identity gibi veri atar ama sürekli artandan ziyade ayarlanabilir. Fakat Db ler için farklý tanýmlanýr dikkat ediþlmeli. <br>
![Resim Yok](./sequence.png)
sequence veritabanýna baðlý identity ise tabloya baðlý. identity diskten veri alýrken sequence ramden alýr daha hýzlýdýr. sequence tablo dýþý olduðu için ayný sequence farklý yerde kullanýlabilir.

### Eager Loading

sorgunun iliþkisel diðer tablolardan eklenmesine `eager loading` denir. PArça parça veri eklenmesini saðlar.
`Include` veya `ThenInclude` ile eklemedir kýsaca. 
<br>
örneðin `A`, `B` ve `C` tablolarý olsun. A -> B -> C þeklinde baðlarý olsun. Siz `Include` ile eklerken `A`'ya `C`'yi eklemek istersen.
```
A.Include(x => x.B);
A.Include(x => x.B.C);
```
Demenle 
`A.Include(x => x.B.C);` bu ayný þey zaten burada `C`'ye `B` üzerinden gittiði için onuda ekler.
þimdi burada hepsi tekil kabul ederdik ama `B`'nin içinde `C` `ICollection` þeklinde tutulsaydý bunu `ThenInclude` ile çözeriz.
```
A.Include(x => x.B);
A.ThenInclude(x => x.C);
```
þeklinde `ThenInclude` ile bir önceki `ICollection` tipindeki `Include` iþlemine tekrar `Include` yapmayý saðlar.
<br>
Sorgulama süreçlernde `Include` yaparken filtreleme imkaný saðlanmaktadýr kulanýmý ise  `Include(x => x.Sýnýf.Where(Þart))` þeklinde olmakta. 

her tablo sorgusunda `Include` yapýlacaksa bunu otomatik yaptýrabiliriz. 
`modelBuilder.Entity<T>().NAvigation(e => e.eklenme).AutoInclude();`
<br>


### Explicit Loading

[Eager Loading](#eager-loading) tüm gelen tüm  verilere ekleme yapmaktaydý. Bu yöntemde ise verilerden istenilenlere ekleme yapmayý saðlamakta. Örneðin `User` tablosundan yaþý 35 üstü olanlarýn diðer tabloda bulunan deneyim bilgilerini çekeceksen. Önce yaþý 35 üstü olan `User`'larý getirir sonra bunlara geçimiþi eklersin. Maliyeti azaltýrsýn. 

```
var emp = await context.Employees.FistOrDefaultAsync(e => e.Id == 2);
await context.Entry(emp).Referance(e => e.Region).LoadAsync(); -> veriye ekleme yapar.
```
eðer `emp` tek deðil `ICollection` ise o zaman `await context.Entry(emp).Collection(e => e.Region).LoadAsync();` þeklinde ekleriz.


### Lazy loading


ilgili `Include` ihtiyacýnda veritabanýna sorgu yapýlýr. Bunun için `Microsoft.EntityFrameworkCore.Proxies` kütüphanesi eklenmelidir. Sonra `OnConfiguring` içinde   `optionsBuilder.UserLazyLoadingProxies();` demek gereklidir.
Eðer proxy ler üzeriden lazy loading gerçekleþtirilecekse tablo deðiþkenleri `virtual` olarak iþaretli olmalý. 
<br>
Proxy desteklemeyen yerlerde manuel lazy loading yapýlabilir. `Microsoft.EntityFrameworkCore.Abstraction` kurarak `ILazyLoading` ile yaparýz. Her Entityde bir boþ bir tanede `ILAzyLoading` alan ctor açýlýr. ILazyLoading kullanýlarak referans deðerlere `get => lazyLoading.Load(this, ref yüklenecekDeðiþken);` olarak manuel beliritlir. manuel lazyloadinglerde virtual iþaretlemelere gerek yoktur. Bunun dertli yaný A ve B tablolarý arasýnda sadece A da belirtsen olmuyor A da B yi Bde A yý belirten lazým.  
<br>
delegate ilede LAzyLoading yapýlýr. Avantajý kütüphanelere baðýmlý deðil. Dezavantajý çok uðraþtýrýcý. Anlatmaya üþendim bakarsýn [buradan](https://learn.microsoft.com/en-us/ef/core/querying/related-data/lazy)
<br>
`N+1` diye bir sorun var burada. yine `A -> B -> C` þeklinde baðýmlý tablolar olsun. Sen A'dan B'yi çekersin tek sorgu ile tamam. Üzerine C'yi çektiðinde Cbir liste ise ve sen bunu Foreach içinde kullanýyorsan yada bir döngüde kullanýyorsan her döngüde tekrar sorgu atar. Örneðin 1000 tane eleman olan tablodan son 10 elemaný döngü ile ekrana basarken. `Console.WriteLinr(A.B.C.Name)` gibi bir iþlemin varsa her ekrana basmada veritabnýndan tekrar cc tablosunun elemanlarý çekilir. burada Take ile halledilir ama `LazyLoading`'de sorgulara eriþimde sorgular tekrarlanýr buda maliyetli


### View Yapisi

genelde raporlama için kullanýlýr. Hazýr sorgular gibi düþünülebilir. Boþ `migration` oluþturulur. `Up` içinde  `migrationBuilder` üzerinden `.Sql()` fonksiyonu ile içine sql komutu yazýlýr `@""` yapýsý ile çoklu satýr kullanýlabilir. Sonra `Down` içinde komutun geri silinmeside eklenmelidir ki biri database de geri gitme yaptýðýnda eklenen view silinisin. sonra migration yapýlýr. View e uygun bir `Entity` Sýnýfý yapýlýr. `DbSet` ile `contet`'e eklenir. Sonra `modelBuilder` içinde `.ToView()` ile view adý verilir. `HasNoKey` ile belirtilir.   


### Stored Procedure

View gibi buda elle eklenir. Bakmadým sonrasýna 


### Scalar ve Inline Functions

Geriye deðer döndüren sql tabanýnda çalýþan fonksiyonlara `scaler` fonksyon denir. 
<br>
```
Create Function getPersonTotalPrice(@personId Int)
    Returns Int
As
Begin
    Declare @TotalPrice Int
    Select @TotalPrice = sum(o.Price) from person p
    Join Orders o 
        On p.PersonId = O.PersonId
    where p.PersonId = 3
    return @TotalPrice
End
```
þeklindeki bir sorguyu öncekiler gibi `migrations` içine direk gömeriz. `migrationsBuilder.Sql(sql sorgusu)` þeklinde hazýrlanýr. Bunu contexte tanýtmak için sql sorgusuna uyumlu bir fonksiyon tanýmlanýr. bunu modelbuilder içinde `HasDbFunction` ile tanýmlanýr. orada tanýmlamalar yapýlýr (üþendim yazmaya ihtiyaç halinde imkaný bil lazým olunca bakarýn) sorguda ise from person in context.persons where context.getperson... .tolist þeklinde yapýlýr.
<br>

Inlýne ise geriye tablo döner. geçtim buralarý tablo dönen sql fonksiyonlarýna inline fonksiyonlar deniyor ona göre araþtýr.



### Configleri Ayri Kaydetme

Entityler de ayar uygulamamýzý saðlayan sýnýf olan `IEntityTypeConfiguration<T>` ile ayrý yerde ayarlamalarý yaparak `modelbuilder` kýsmýný þiþirmeyiz.

### Kalitimsal Durumlar

entitylerin birbirinden miras almasý veya baþka yerlerden miras almasý mesela her tabloda Id varsa bunu Entity sýnýfýndan biras veririz her yere.

#### TPH Table Per Hierarchy

tablo baþýna hiyerarþi demek. Burada kalýtým ile birbirine baðlý entitiler tek bir tabloda birleþtirilir. Ayrýmlarý için `Discriminator` kullanýlýr.





#### TPT Table Per Type

her entity için tablo oluþturur ve üst sýnýfý ile birebir iliþki oluþturur.
`TPH` ile ayný yapýya sahip farký `modelbuilder` içinde tablolara aynýda olsa `totable` ile isim vermek
`modelbilder.entity<(Abstract olan entity)>().UseTptMappingStrategy()` de varmýþ ama denemek lazým







#### TPC Table Per Concrete Type

Ef Core 7 de geldi. Soyut türlere tablo üretmez. Abstractlara tablo oluþturmaz yani. Fakat abstract tabloda bulunan elemanlarý somutlarýn hepsine ekler.
bunda ise `TPT`'den daha kolay þekilde `modelbilder.entity<(Abstract olan entity)>().UseTcpMappingStrategy()`

   



### DB Islemleri

* `BeginTrabsaction` -> context.database.begintransaction(); ile alýnarak ayarlamalar yapýlarak özelleþtirmeler yapýlabilir.
* `CommitTransaction` -> çalýþmalarý commit eder.
* `RollbackTransaction` -> 
* `CanConnect` -> db ye baðlandý mý? bool türünde döner
* `EnsureCreate` -> tasarlanan db yi veritabanýnda üretir. migration kullanmaz. 
* `EnsureDelete` -> veritabanýný siler
* `GenerateCreateScript` -> context ile üretilen db nin sql scriptini verir. 
* `ExecuteSql` -> formatlanma türünde string alarak sql komutunu çalýþtýrý. Execute tipi olarak temel 3 tip add update deletedir.
* `ExecuteSqlRaw` -> direk string alýr
* `SqlQuery` -> artýk kullanýlmýyor. dbset üzerinden fromsql kullanýlýyor fakat eriþilebilir ama desteði yok. arada kullanýlacak select li sorgularda kullanlýr.
* `SqlQueryRaw` -> formatsýz düz stringle çalýþaný
* `GetMigrations` -> migrationslarý liste halinde döner 
* `GetAppliedMigrations` -> migrationlarýn veritabanýn auygulananlarýný döndürür.
* `GetPendingMigrations` -> uygulanmayanlarý döndürür
* `Migrate` -> migrations larý runtime da migrate eder.
* `OpenConnection` -> manuel db baðlantýsý açar
* `CloseConnection` -> manuel kapatýr
* `GetConnectionString` -> baðlantý stringini verir güvenlik için bunu program aþamasýnda almak **bana göre** mantýklý deðil
* `GetDbConnection` -> ef corun kullandýðý ado.net in connection nesnesini verir
* `SetDbConnection` -> buda getirileni setler
* `ProviderName` -> db için kullanýlan nuget paketi verir.

### Logging

`onconfiguring` içinde `optionsBuilder.LogTo(Console.WriteLine)` þeklinde en basit hali ile efcore a loglarý konsola yaz diyorsun.
`optionsBuilder.LogTo(message => Debug.WriteLine(message))` ile ayrý debug penceresinden görebilirisn.
<br>
`StreamWriter log = new("logs.txt", append: true);` sonra logto içine göm
bunu sonra kapatmayý unutma `.EnableSensivityDatalog` böyle bir þey var verileride logluyor. ama güvenlik zafiyetidir.
`.enabledetailerrors` ile hatalarda ayrýntýlýarý alabilirsin.

<br>

`microsoft.extensions.logging` gibi kütüphanelerde kullanýlarak sorgu loglarý ve diðer þeyleri özelleþtirebilriisn. 

<br>

[Query Tags](#query-tags) altarnatifidir.







### Karisik Notlar
``` 
kendime not yorum ekle böyle
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Blog>()
        .Property(b => b.Url)
        .HasComment("The URL of the blog");
}


start date gibi þeyleri hasvalue ile yap

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Blog>()
        .Property(b => b.Created)
        .HasDefaultValueSql("getdate()");
}

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Blog>()
        .Property(b => b.Rating)
        .HasDefaultValue(3);
}


hazýrda belli verileri birleþtirerek tutmak 

modelBuilder.Entity<Person>()
    .Property(p => p.DisplayName)
    .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");

```

* entitylerde aðlarý ile ekleme yaparken kullanabilmek için ctor ile baþlangýçta alma yapýlablir.

* entitylerde get setleerde field özelliðini deðiþtirebilirsin

* field and property access -> filed yada propertyleri kullanýp kullanmamasýný ayarlayabileceðimiz özelliktir. 

* shadow property -> db de olan kolonu entity içinde tanýmlamamadýr. mesela createDate sabit olacaðý için entityde konulmaz.


















