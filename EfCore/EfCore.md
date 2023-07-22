# EF Core

* [Db First](###dbfirst)
* [Code First](###codefirst)
* [Query Tags](###query-tags)
* [Global Query Filters](###global-query-filters)
* [IQuesyable ve IEnumerable](###iquesyable-ve-ienumerable)
* [Deferrend Execution](###deferrend-execution)
* [Sorgular](###sorgular)
* [Sorgu Kalitesi](###sorgu-kalitesi)
* [ExecuteUpdate ve ExecuteDelete ��lemleri](###executeupdate-ve-executedelete)
* [Kay�t alma](###kayit-alma)
* [Configs](###configs)
* [Eager Loading](###eager-loading)
* [Configleri Ayr� Kaydetme](###configleri-ayri-kaydetme)
* [Kal�t�msal Durumlar](###kalitimsal-durumlar)
* [Kar���k Notlar](###karisik-notlar)

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

sorgunun ili�kisel di�er tablolardan eklenmesine `�ager loading` denir. 







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


















