# EF Core

* [Db First](#dbfirst)
* [Code First](#codefirst)
* [Query Tags](#query-tags)
* [Global Query Filters](#global-query-filters)
* [IQuesyable ve IEnumerable](#iquesyable-ve-ienumerable)
* [Deferrend Execution](#deferrend-execution)
* [Sorgular](#sorgular)
* [Sorgu Kalitesi](#sorgu-kalitesi)
* [ExecuteUpdate ve ExecuteDelete ��lemleri](#executeupdate-ve-executedelete)
* [Kay�t alma](#kayit-alma)
* [Configs](#configs)
* [Eager Loading](#eager-loading)
* [Explicit Loading](#explicit-loading)
* [Lazy loading](#lazy-loading)
* [View Yap�s�](#view-yapisi)
* [Stored Procedure](#stored-procedure)
* [Scalar ve Inline Functions](#scalar-ve-inline-functions)
* [Configleri Ayr� Kaydetme](#configleri-ayri-kaydetme)
* [Kal�t�msal Durumlar](#kalitimsal-durumlar)
   * [TPH Table Per Hierarchy](#tph-table-per-hierarchy)
   * [TPT Table Per Type](#tpt-table-per-type)
   * [TPC Table Per Concrete Type](#tpc-table-per-concrete-type)
* [DB Islemleri](#db-islemleri)
* [Logging](#logging)
* [Kar���k Notlar](#karisik-notlar)

### DbFirst

`DbFirst` demek var olan veritaban�na proje �retmeye veya projede �nce veritaban�n� in�aa etme yakla��m�na denir. <br>
`DbFirst` yakl���m�nda veritaban�n� ef core ile projeye dahil etmek i�in database k�sm�nda <br> 
`dotnet ef dbcontext scaffold 'Server=(localdb)\MSSQLLocalDB; Database=Northwind; Trusted_Connection=True;' Microsoft.EntityFrameworkCore.SqlServer` 
<br>
denklemi i�in `dotnet ef dbcontext scaffold 'Server=[vreitaban�n�n�n oldu�u yerin ad�]; Database=[veritaban� ad�]; [ba�lant� durumu direk g�ven veya id �ifre verilebilir];' [veritaban� paketi]`
<br>
sonras�nda ise resimdeki gibi tabloalr dahil olur.
![Resim Yok](./EfCorescaffold.png)

### CodeFirst

`CodeFirst` i�in yazmayacam ��nk� **BANA G�RE** var olan veritaban�na proje yap�lmad�k�a kullan�lmamal�. Sebebi ise tipleme ve ayarlamalar�n hem `ssms`'da daha kolay olmas� hemde katmanlama i�in. Yani veritaban� ile sorunlu ekip veritaban� i�in �retilmi� geli�tirme ortam�nda geli�tirme yaps�n. `Efcore` yerine dapper kullanas�m gelse veritabanc�lar ne yapacak acaba `codefirst`'te :D.


### Query Tags 

`Ef Core` ile generate edilen sorgulara a��klama eklememizi sa�layan �zelliktir.<br>
`await context.Persons.ToListAsync()` <br>
loglamalarda bu sorgu yan�nda a��klama g�rmek isterseniz.<br>
`await context.Persons.TagWith("a��klama").ToListAsync()` <br>
yada <br>
`await context.Persons.TagWith("a��klama1").TagWith("a��klama2").ToListAsync()` <br>
yada <br>
`await context.Persons.TagWith("a��klama1").Where(p => p.Id > 5).TagWith("a��klama2").ToListAsync()` <br>
<br>
`TagWithCallSite` kullan�rsan kodun dosya konumunuda verir.


### Global Query Filters

�oklu yerde kullanmay� sa�layan global `filtre`'ler kullanmay� sa�lar.<br>
`Entitiy`'lerin ayarlamalar�n�n yap�ld��� k�s�mda tan�mlan�r.<br>
`modelBuilder.Entity<Person>().HasQueryFilter(p => p.IsAlive)`<br>
yukar�daki �rnekte global filtre tan�mlayarak art�k her insan tablosu sorguland���nda `IsAlive` de�eri `true` olanlarda arama yapcak. <br>
e�er bunu sonradan kullanmadan sorgulamak istersek.<br>
`context.Persons.IgnoreQueryFilters().methodlar..`<br>
�elinde �n tan�ml� filtreleri iptal edebilirsiinz.

### IQuesyable ve IEnumerable
`IQueryable` sorguya kar��l�k gelir. Efcore �zerinde yap�lm�� sorgunun execute edilmemi� hali demektir.
<br>
`IEnumerable` ise execute edilmi� memorydeki halidir.

### Deferrend Execution 
yapt���n sorgularda parametre de�erleri sonradan de�i�irse ve sen sorguyu sonradan execute edersen g�ncel parametreye g�re sorgu �eker. �rne�in

![Resim Yok](deferrend_execution.png)

burada id yi 5 ten b�y�k de�il 200 den biyik olanlar� getirir.

### Sorgular

`ThenBy` -> orderby sorgusunu �o�altmak i�in kullan�l�r.<br>
`OrderByDescending` -> orderby in tersi b�y�kten k����e yani<br>
`ThenByDescending` -> ek olarak tersine sorgula<br>
`Any` -> sorgu sonucu veri geliyor mu gelmiyor mu <br>
`All` -> t�m veriler �arta uyarsa true d�ner aksi halde false<br>
`GroupBy` -> gruplar ad� �zerinde verilen duruma g�re gruplar<br>

### Change Tracker

`SaveChangesAsync(false)` �eklinde kullan�mda kaydedilen verilerin takibi devam eder.


### Sorgu Kalitesi

#### 1
`IQueryable` ile `IEnumerable` ayr�m�n�n yap�lmas�
<br>
E�er `IEnumarable` ile yapmak istersen `context.Entity.AsEnumarable().methodlar` �eklinde ilerlenir.
<br>
tercih `IQueryable`

#### 2
`Select` methodu ile gerekli kolonu getirerek maliyeti azaltabilirisin.
<br>


#### 3
`result`'� limitle. tablodaki verileri al�rken limitleyin.<br>
`context.Persons.ToList()` yerine<br>
`context.Persons.Take(say�).ToList()` ile daha sa�l�kl� i� olur. tabloda bilyonlarca veri varsa hepsini �ekmeye gerek yok.
<br>

#### 4
`asenkron yani async` tercih edin.

### ExecuteUpdate ve ExecuteDelete

bunlar sayesinde toplu g�ncelleme ve silmede kolayl�k ve performans geldi. efcore 7 �zelli�i


### Kayit Alma
[Burada](https://learn.microsoft.com/tr-tr/ef/core/performance/performance-diagnosis?tabs=simple-logging%2Cload-entities) Burada anlat�lana g�re e�er sorgular� kontrol etmek isterseniz yani program s�ras�nda veritaban�na g�nderilen sorgular� kontrol etmek isterseniz. <br>

```
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder
        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True")
        .LogTo(Console.WriteLine, LogLevel.Information);
}
```
�ekline `.LogTo` methodundan yararlanabilirsiniz. bu `Konsol`'a info ve �st� bilgileri basar. [`Query Tags`](###query-tags) kullanarakta bunlara bilgi g�mebilirisiniz. 


### Configs


modelBuilder.Model.GetEntityTypes(); ile entitlerin tiplerini liste halinde alabilirisn<br>

`ToTable` -> �retilecek tablonun ad�n� belirler <br>

`HasColumnName` - `HasColumnType` - `HasColumnOrder` -> ile kolon isim tip ve s�ra ayarlamas� yapabilirisin. <br>

`ForeignKey` -> tabloda ba�ka tablo ad� + Id varsa kendi oto ayarlar ama manuel istersen bununla ba�lant� ismini tan�mlars�n.
```
modelBuilder.Entity<Person>()
    .HasOne(p => p.Department)
    .WithMany(d => d.Persons)
    .HasForeignKey(p => p.Id);
```
�eklinde tan�mlama ile tan�mlanabilir.
<br>

`Ignore` -> T�m propertyler kolon olarak eklenir. bazen property laz�m olur ama tabloya koymayacaks�n o zaman bunu kullan�rs�n. ` entity<person>().�gnore(p=>p.asdasd) ` <br>

`HasKey` -> Efcore da default olarak Id tan�ml�lar key oalrak tan�mlan��r. bunu kendi istedi�ini vermek i�in Key kulan�l�r. e�er tabloda primary key yoksa hata verir. 

`IsRowVersion` -> versiyon tutar. byte[] tipimnde tutulur. `entity<person>().property(p=>p.asdasd).IsRowVersion();` <br>

`IsRequired` -> de�erin girilmesini zorunlu oldu�unu ifade eder. <br>

`HasMaxLength` -> string de�erlerin uzunlu�unu belirtir. property sonras� kullan�l�r.<br>

`HasPrecision(5,3)` -> say�lar�n virg�l �ncesi ve sonras� uzunluklar�n� belirler. <br>

`IsUnicode` -> kolon i�erisinde unicode karakter varsa kullan�l�r.<br>

`HasComment` -> kolonlara a��klamalar ekler.<br>

`IsConcurrencyToken` -> verinin b�t�nl���n� kontrol eder. `Property` sonras� kullan�l�r.<br>

`Composite key` -> tabloda birden fazla kolon `primarykey` yap�lmak istenirse kullan�l�r. `entity<person>.HasKey(key1,key2,key3)` verilir. <br>

`HasDefaultSchema` -> `[dbo]` �eklinde olan default �emalar� ezmeyi sa�lar. <br>

`HasDefaultValue` -> `property` sonras� kullan�l�r. property e default value atan�r. <br>

`HasDefaultValueSql` -> `property` sonras� kullan�l�r. property e default value atan�r. de�er sql olarak atan�r. sql de atan�r yani tarih i�in datetime  de�il getdate() olur. sadece bu de�il bu arada direk sql komutuda olur. sadece fonsiyon olarak vermen laz�m.<br>

`HasComputedColumnSql` -> birden fazla kolonu belirli hesaplamalar ile tek kolona ba�lama diyebiliriz. name ve surname i full name ile kolona yazd�rma gibi d���n. tabi bu �gnore bir property ile yapmak daha iyi db den bir property az �ekilir bve tutulur ek performans<br>

`HasConstraintName` -> constraint isimlerini bask�lar. foreing key isimlerini filan ayarlars�n <br>

`HasData` -> seed lemede kullan�l�r. haz�r veri haz�rlar.<br>

`HasDiscriminator` -> entityler aras� kal�t�mda kullan�l�r. miras alan tiplerin ayr�m�nda kullan�l�r default olarak string t�r�nde isimleri tutar sonras�nda has value ile tiplere �zel de�er atars�n.<br>

`HasNoKey` ->  primarykey kolonu olmak zorunda ama yoksa bunu belirtmelisin bununla yoksa hata al�r�s�n.<br>

`HasQueryFilter` ->  bununla sorgular�n hepsinde uygulanacak sorgu eklenir mesela silindimi diye bir de�erde false getirmek istersen burada belirtirsin ba�ka yerde uygulamazs�n. Burada verip �st�ne sorguda bir daha yazarsan performans kayb� olunur. <br>

`Identity` -> otomatik artan demektir. bir tabloda tek bir tane olabilir. bir kolon olabilir.

`HasIndex()` -> sorgularda performans artt�r�m� sa�lar. FK, PK ve AK olan kolonlar otomatik indexlenir.(index aramalarda kullanaca��n� belirterek o kolonun arama i�in optimize olmas�n� sa�l�yor diye anlad�m.) farkl� kolona index atamak i�in `entitiy<T>().HasIndex(x => new {x.asdasd, x.asdasd, x.asdasd,....})`  sonuna `.IsUnique()` koyarsan benzersiz dersin ve performans� artt�r�rs�n. `HasFilter()` kullan�rsan sonuna indexlemede filtreleme yapar. ayr�ca sona `IncludeProperties` ile ilerde sorgulamada kullanabilece�in verileri s�ylersen bunlar�da tyabloya yandan ekler ve ilerde kulland���nda bo� yere maliyeti y�kseltmez <br>

`HasSequence` -> Identity gibi veri atar ama s�rekli artandan ziyade ayarlanabilir. Fakat Db ler i�in farkl� tan�mlan�r dikkat edi�lmeli. <br>
![Resim Yok](./sequence.png)
sequence veritaban�na ba�l� identity ise tabloya ba�l�. identity diskten veri al�rken sequence ramden al�r daha h�zl�d�r. sequence tablo d��� oldu�u i�in ayn� sequence farkl� yerde kullan�labilir.

### Eager Loading

sorgunun ili�kisel di�er tablolardan eklenmesine `eager loading` denir. PAr�a par�a veri eklenmesini sa�lar.
`Include` veya `ThenInclude` ile eklemedir k�saca. 
<br>
�rne�in `A`, `B` ve `C` tablolar� olsun. A -> B -> C �eklinde ba�lar� olsun. Siz `Include` ile eklerken `A`'ya `C`'yi eklemek istersen.
```
A.Include(x => x.B);
A.Include(x => x.B.C);
```
Demenle 
`A.Include(x => x.B.C);` bu ayn� �ey zaten burada `C`'ye `B` �zerinden gitti�i i�in onuda ekler.
�imdi burada hepsi tekil kabul ederdik ama `B`'nin i�inde `C` `ICollection` �eklinde tutulsayd� bunu `ThenInclude` ile ��zeriz.
```
A.Include(x => x.B);
A.ThenInclude(x => x.C);
```
�eklinde `ThenInclude` ile bir �nceki `ICollection` tipindeki `Include` i�lemine tekrar `Include` yapmay� sa�lar.
<br>
Sorgulama s�re�lernde `Include` yaparken filtreleme imkan� sa�lanmaktad�r kulan�m� ise  `Include(x => x.S�n�f.Where(�art))` �eklinde olmakta. 

her tablo sorgusunda `Include` yap�lacaksa bunu otomatik yapt�rabiliriz. 
`modelBuilder.Entity<T>().NAvigation(e => e.eklenme).AutoInclude();`
<br>


### Explicit Loading

[Eager Loading](#eager-loading) t�m gelen t�m  verilere ekleme yapmaktayd�. Bu y�ntemde ise verilerden istenilenlere ekleme yapmay� sa�lamakta. �rne�in `User` tablosundan ya�� 35 �st� olanlar�n di�er tabloda bulunan deneyim bilgilerini �ekeceksen. �nce ya�� 35 �st� olan `User`'lar� getirir sonra bunlara ge�imi�i eklersin. Maliyeti azalt�rs�n. 

```
var emp = await context.Employees.FistOrDefaultAsync(e => e.Id == 2);
await context.Entry(emp).Referance(e => e.Region).LoadAsync(); -> veriye ekleme yapar.
```
e�er `emp` tek de�il `ICollection` ise o zaman `await context.Entry(emp).Collection(e => e.Region).LoadAsync();` �eklinde ekleriz.


### Lazy loading


ilgili `Include` ihtiyac�nda veritaban�na sorgu yap�l�r. Bunun i�in `Microsoft.EntityFrameworkCore.Proxies` k�t�phanesi eklenmelidir. Sonra `OnConfiguring` i�inde   `optionsBuilder.UserLazyLoadingProxies();` demek gereklidir.
E�er proxy ler �zeriden lazy loading ger�ekle�tirilecekse tablo de�i�kenleri `virtual` olarak i�aretli olmal�. 
<br>
Proxy desteklemeyen yerlerde manuel lazy loading yap�labilir. `Microsoft.EntityFrameworkCore.Abstraction` kurarak `ILazyLoading` ile yapar�z. Her Entityde bir bo� bir tanede `ILAzyLoading` alan ctor a��l�r. ILazyLoading kullan�larak referans de�erlere `get => lazyLoading.Load(this, ref y�klenecekDe�i�ken);` olarak manuel beliritlir. manuel lazyloadinglerde virtual i�aretlemelere gerek yoktur. Bunun dertli yan� A ve B tablolar� aras�nda sadece A da belirtsen olmuyor A da B yi Bde A y� belirten laz�m.  
<br>
delegate ilede LAzyLoading yap�l�r. Avantaj� k�t�phanelere ba��ml� de�il. Dezavantaj� �ok u�ra�t�r�c�. Anlatmaya ��endim bakars�n [buradan](https://learn.microsoft.com/en-us/ef/core/querying/related-data/lazy)
<br>
`N+1` diye bir sorun var burada. yine `A -> B -> C` �eklinde ba��ml� tablolar olsun. Sen A'dan B'yi �ekersin tek sorgu ile tamam. �zerine C'yi �ekti�inde Cbir liste ise ve sen bunu Foreach i�inde kullan�yorsan yada bir d�ng�de kullan�yorsan her d�ng�de tekrar sorgu atar. �rne�in 1000 tane eleman olan tablodan son 10 eleman� d�ng� ile ekrana basarken. `Console.WriteLinr(A.B.C.Name)` gibi bir i�lemin varsa her ekrana basmada veritabn�ndan tekrar cc tablosunun elemanlar� �ekilir. burada Take ile halledilir ama `LazyLoading`'de sorgulara eri�imde sorgular tekrarlan�r buda maliyetli


### View Yapisi

genelde raporlama i�in kullan�l�r. Haz�r sorgular gibi d���n�lebilir. Bo� `migration` olu�turulur. `Up` i�inde  `migrationBuilder` �zerinden `.Sql()` fonksiyonu ile i�ine sql komutu yaz�l�r `@""` yap�s� ile �oklu sat�r kullan�labilir. Sonra `Down` i�inde komutun geri silinmeside eklenmelidir ki biri database de geri gitme yapt���nda eklenen view silinisin. sonra migration yap�l�r. View e uygun bir `Entity` S�n�f� yap�l�r. `DbSet` ile `contet`'e eklenir. Sonra `modelBuilder` i�inde `.ToView()` ile view ad� verilir. `HasNoKey` ile belirtilir.   


### Stored Procedure

View gibi buda elle eklenir. Bakmad�m sonras�na 


### Scalar ve Inline Functions

Geriye de�er d�nd�ren sql taban�nda �al��an fonksiyonlara `scaler` fonksyon denir. 
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
�eklindeki bir sorguyu �ncekiler gibi `migrations` i�ine direk g�meriz. `migrationsBuilder.Sql(sql sorgusu)` �eklinde haz�rlan�r. Bunu contexte tan�tmak i�in sql sorgusuna uyumlu bir fonksiyon tan�mlan�r. bunu modelbuilder i�inde `HasDbFunction` ile tan�mlan�r. orada tan�mlamalar yap�l�r (��endim yazmaya ihtiya� halinde imkan� bil laz�m olunca bakar�n) sorguda ise from person in context.persons where context.getperson... .tolist �eklinde yap�l�r.
<br>

Inl�ne ise geriye tablo d�ner. ge�tim buralar� tablo d�nen sql fonksiyonlar�na inline fonksiyonlar deniyor ona g�re ara�t�r.



### Configleri Ayri Kaydetme

Entityler de ayar uygulamam�z� sa�layan s�n�f olan `IEntityTypeConfiguration<T>` ile ayr� yerde ayarlamalar� yaparak `modelbuilder` k�sm�n� �i�irmeyiz.

### Kalitimsal Durumlar

entitylerin birbirinden miras almas� veya ba�ka yerlerden miras almas� mesela her tabloda Id varsa bunu Entity s�n�f�ndan biras veririz her yere.

#### TPH Table Per Hierarchy

tablo ba��na hiyerar�i demek. Burada kal�t�m ile birbirine ba�l� entitiler tek bir tabloda birle�tirilir. Ayr�mlar� i�in `Discriminator` kullan�l�r.





#### TPT Table Per Type

her entity i�in tablo olu�turur ve �st s�n�f� ile birebir ili�ki olu�turur.
`TPH` ile ayn� yap�ya sahip fark� `modelbuilder` i�inde tablolara ayn�da olsa `totable` ile isim vermek
`modelbilder.entity<(Abstract olan entity)>().UseTptMappingStrategy()` de varm�� ama denemek laz�m







#### TPC Table Per Concrete Type

Ef Core 7 de geldi. Soyut t�rlere tablo �retmez. Abstractlara tablo olu�turmaz yani. Fakat abstract tabloda bulunan elemanlar� somutlar�n hepsine ekler.
bunda ise `TPT`'den daha kolay �ekilde `modelbilder.entity<(Abstract olan entity)>().UseTcpMappingStrategy()`

   



### DB Islemleri

* `BeginTrabsaction` -> context.database.begintransaction(); ile al�narak ayarlamalar yap�larak �zelle�tirmeler yap�labilir.
* `CommitTransaction` -> �al��malar� commit eder.
* `RollbackTransaction` -> 
* `CanConnect` -> db ye ba�land� m�? bool t�r�nde d�ner
* `EnsureCreate` -> tasarlanan db yi veritaban�nda �retir. migration kullanmaz. 
* `EnsureDelete` -> veritaban�n� siler
* `GenerateCreateScript` -> context ile �retilen db nin sql scriptini verir. 
* `ExecuteSql` -> formatlanma t�r�nde string alarak sql komutunu �al��t�r�. Execute tipi olarak temel 3 tip add update deletedir.
* `ExecuteSqlRaw` -> direk string al�r
* `SqlQuery` -> art�k kullan�lm�yor. dbset �zerinden fromsql kullan�l�yor fakat eri�ilebilir ama deste�i yok. arada kullan�lacak select li sorgularda kullanl�r.
* `SqlQueryRaw` -> formats�z d�z stringle �al��an�
* `GetMigrations` -> migrationslar� liste halinde d�ner 
* `GetAppliedMigrations` -> migrationlar�n veritaban�n auygulananlar�n� d�nd�r�r.
* `GetPendingMigrations` -> uygulanmayanlar� d�nd�r�r
* `Migrate` -> migrations lar� runtime da migrate eder.
* `OpenConnection` -> manuel db ba�lant�s� a�ar
* `CloseConnection` -> manuel kapat�r
* `GetConnectionString` -> ba�lant� stringini verir g�venlik i�in bunu program a�amas�nda almak **bana g�re** mant�kl� de�il
* `GetDbConnection` -> ef corun kulland��� ado.net in connection nesnesini verir
* `SetDbConnection` -> buda getirileni setler
* `ProviderName` -> db i�in kullan�lan nuget paketi verir.

### Logging

`onconfiguring` i�inde `optionsBuilder.LogTo(Console.WriteLine)` �eklinde en basit hali ile efcore a loglar� konsola yaz diyorsun.
`optionsBuilder.LogTo(message => Debug.WriteLine(message))` ile ayr� debug penceresinden g�rebilirisn.
<br>
`StreamWriter log = new("logs.txt", append: true);` sonra logto i�ine g�m
bunu sonra kapatmay� unutma `.EnableSensivityDatalog` b�yle bir �ey var verileride logluyor. ama g�venlik zafiyetidir.
`.enabledetailerrors` ile hatalarda ayr�nt�l�ar� alabilirsin.

<br>

`microsoft.extensions.logging` gibi k�t�phanelerde kullan�larak sorgu loglar� ve di�er �eyleri �zelle�tirebilriisn. 

<br>

[Query Tags](#query-tags) altarnatifidir.







### Karisik Notlar
``` 
kendime not yorum ekle b�yle
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Blog>()
        .Property(b => b.Url)
        .HasComment("The URL of the blog");
}


start date gibi �eyleri hasvalue ile yap

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


haz�rda belli verileri birle�tirerek tutmak 

modelBuilder.Entity<Person>()
    .Property(p => p.DisplayName)
    .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");

```

* entitylerde a�lar� ile ekleme yaparken kullanabilmek i�in ctor ile ba�lang��ta alma yap�lablir.

* entitylerde get setleerde field �zelli�ini de�i�tirebilirsin

* field and property access -> filed yada propertyleri kullan�p kullanmamas�n� ayarlayabilece�imiz �zelliktir. 

* shadow property -> db de olan kolonu entity i�inde tan�mlamamad�r. mesela createDate sabit olaca�� i�in entityde konulmaz.


















