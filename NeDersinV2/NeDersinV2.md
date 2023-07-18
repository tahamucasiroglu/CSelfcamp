# NeDersinV2


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





Yap�lacaklar

1-) survey i�in IsEnd kontrol�n� querystring yap
2-) ping i�in olan methoda gelen istekleri middleware ile direk en ba�ta geri d�nd�r bu sayede adamlar en do�ru pingi �l�s�nler.




