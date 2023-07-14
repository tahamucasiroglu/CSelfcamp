# EF Core

* [Db First](###dbfirst)
* [Code First](###codefirst)
* [Query Tags](###query-tags)
* [Global Query Filters](###global-query-filters)
* [Sorgu Kalitesi](###sorgu-kalitesi)
* [ExecuteUpdate ve ExecuteDelete ��lemleri](###executeupdate-ve-executedelete)
* [Kay�t alma](###kayit-alma)


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




















