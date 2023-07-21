# NeDersinV2


Turkcell projesi sonrasý öðrenmeye devam için yeniden yapma. 
<br>

#### Amaç olabildiðince `az paket` kullanarak saf `.net` ile bir api hazýrlamak.

Domain <- Application <- Infrastructure <- Service <- Presentation <- Browser
<br>

<hr>

> Domain = Entity sýnýflarýnýn projesi, Return için hazýrlanan model
<hr>

> Application = sabit, static ve view modeller ayrýca baþka þeyler genel olarak proje genelinde kullanýalcaklar.
<hr>

> Infrasructure = Filter, attribute gibi sorgu methodlarý olan sýnýf ve Persistence projesi ile de context ve repository sýnýflarý
<hr>

> Service = repositoryleri kulanan servisler ve ekstralar olursa
<hr>

> Presentation = Web Api olacak.
<hr>

> Browser = flutter ile hýzlýca bir web ui yapmak.
<hr>

plan bu þekilde

-*-*
VM lerdeki sealed larý kaldýrarak içine collectionlarý koy ve tekte anketi içlerine soru cevap ne varsa göemerek eklemeyi dene
-*-*


Performans notlarý
* Toplu eklemede `AddRange` kullanýn. Tek bir deðer eklemede `SaveChanges` 140 ms civarý sürerken 100 deðer eklemede 147 ms civarý sürmekte. Tablo baðlýlýklarý ve kolon sayýsý gibi þeylerde, hatta tablodaki veri sayýsý ile deðiþir ama toplu ekleme her zaman daha iyi


Yapýlacaklar

1-) survey için IsEnd kontrolünü querystring yap
2-) ping için olan methoda gelen istekleri middleware ile direk en baþta geri döndür bu sayede adamlar en doðru pingi ölçsünler.




