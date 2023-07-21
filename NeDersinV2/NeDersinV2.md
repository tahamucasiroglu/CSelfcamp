# NeDersinV2
<br>

## proje yar�da b�rak�ld�. staj i�in ba�ka projeye ba�lnad�. buna sonra d�nerim belkide muhtemelen d�nmem


Turkcell projesi sonras� ��renmeye devam i�in yeniden yapma. 
<br>

#### Ama� olabildi�ince `az paket` kullanarak saf `.net` ile bir api haz�rlamak.

Domain <- Application <- Infrastructure <- Service <- Presentation <- Browser
<br>

<hr>

> Domain = Entity s�n�flar�n�n projesi, Return i�in haz�rlanan model
<hr>

> Application = sabit, static ve view modeller ayr�ca ba�ka �eyler genel olarak proje genelinde kullan�alcaklar.
<hr>

> Infrasructure = Filter, attribute gibi sorgu methodlar� olan s�n�f ve Persistence projesi ile de context ve repository s�n�flar�
<hr>

> Service = repositoryleri kulanan servisler ve ekstralar olursa
<hr>

> Presentation = Web Api olacak.
<hr>

> Browser = flutter ile h�zl�ca bir web ui yapmak.
<hr>

plan bu �ekilde

-*-*
VM lerdeki sealed lar� kald�rarak i�ine collectionlar� koy ve tekte anketi i�lerine soru cevap ne varsa g�emerek eklemeyi dene
-*-*


Performans notlar�
* Toplu eklemede `AddRange` kullan�n. Tek bir de�er eklemede `SaveChanges` 140 ms civar� s�rerken 100 de�er eklemede 147 ms civar� s�rmekte. Tablo ba�l�l�klar� ve kolon say�s� gibi �eylerde, hatta tablodaki veri say�s� ile de�i�ir ama toplu ekleme her zaman daha iyi


Yap�lacaklar
*** seeding k�sm�n� optimize et 
1-) survey i�in IsEnd kontrol�n� querystring yap
2-) ping i�in olan methoda gelen istekleri middleware ile direk en ba�ta geri d�nd�r bu sayede adamlar en do�ru pingi �l�s�nler.
3-) string kontrollerde regex yap
4-) �oklu tablolardaki u�ra�lar� sil viewlar� ke�fettik
5-) JWT ekle
6-) istatistik k�sm�nda view � ��z�nce yap
7-) UI'i apiye ba��ml� yap. arkaplan rengi gibi �eyler apiden gelsin. hatta sayfay� apiden �ekebilir.(fantezi)
8-) db yi zorla




