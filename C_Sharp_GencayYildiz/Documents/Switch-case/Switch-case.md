# Switch Case

`Switch-Case` ile kullan�m anlat�m� ypamayacam baz� genel d��� teknikleri yazaca��m<br>

* [When](###when-sarti)
* [Goto](###goto)
* [Switch Experssions](###switch-experssions)


### When sarti

```
switch (fiyat){

	case 100 when .......: break;

}
```

when ko�uluda sa�lan�yorsa �al���r.<br>


### Goto
Turkay Hocam cok pek sevmez :) <br>
caseler aras� atlamay� sa�lar<br>

```
switch (fiyatBilgisi){

	case 100: goto case 200; //Console.WriteLine("300'den k���k"); break;
	case 200: Console.WriteLine("300'den k���k"); break;
	case 300: Console.WriteLine("300"); break;
	case 400: Console.WriteLine("300'den b�y�k"); break;
	case 500: goto case 400;  //Console.WriteLine("300'den b�y�k"); break;
}
```

�imdi sa�ma oldu ama mant�k �� say� 300 ise 300 yada duruma g�re ��kt� veren switch yap�s� var diyelim
ben 400 veya 500 de ayn� �eyi yazacaksam. yak�n olan 400 e durumu yazar�m 500 de erim ki 400 e git. bu sayede az ve �z kod yazar�m. 
buradaki goto farkl� biraz ama programlamada direk goto kullanmak harbiden s�k�nt�l�.


### Switch Experssions

string mesaj = ""

```
switch(g�nler)
{
	case 0: mesaj = "pazartesi"; break;
	case 1: mesaj = "sal�"; break;
	case 2: mesaj = "�ar�amba"; break;
	case 3: mesaj = "per�embe"; break;
	case 4: mesaj = "cuma"; break;
	case 5: mesaj = "cumartesi"; break;
	case 6: mesaj = "pazar"; break;
}
```

bu kullan�m� `expressions` ile 

```
switch(g�nler)
{
	0 => "pazartesi"; 
	1 => "sal�";
	2 => "�ar�amba";
	3 => "per�embe";
	4 => "cuma";
	5 => "cumartesi";
	6 => "pazar";
}
```

buna d�n��t�r�r ve gereksiz breakler case s�n�rlamalar� kalkar ama yine ayn� sat�r say�s�nda kod diyorsan�z. Fazladan yaz�lan gereksiz brekleri g�rm�yorsan�z size ba�ka projede yazd���m kodu g�stermek isterim. bu kodu ne if else nede normal switch bu kadar k�sa yazamazd�. tek sat�r if belki yapard� ama okunurluk 0 olurdu.

```
        public IReturnModel<IEnumerable<TEntity>> GetAll<Tout>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, Tout>>? order = null, bool reserve = false)
        {
#pragma warning disable CS8604 // Olas� null ba�vuru ba��ms�z de�i�keni.
            IEnumerable<TEntity>? result = (filter == null, order == null, reserve) switch
            {
                (true, true, true) => context.Set<TEntity>().AsNoTracking().Reverse(),
                (true, true, false) => context.Set<TEntity>().AsNoTracking(),
                (true, false, true) => context.Set<TEntity>().AsNoTracking().OrderBy(order).Reverse(),
                (true, false, false) => context.Set<TEntity>().AsNoTracking().OrderBy(order),
                (false, true, true) => context.Set<TEntity>().AsNoTracking().Where(filter).Reverse(),
                (false, true, false) => context.Set<TEntity>().AsNoTracking().Where(filter),
                (false, false, true) => context.Set<TEntity>().AsNoTracking().Where(filter).OrderBy(order).Reverse(),
                (false, false, false) => context.Set<TEntity>().AsNoTracking().Where(filter).OrderBy(order)
            };
#pragma warning restore CS8604 // Olas� null ba�vuru ba��ms�z de�i�keni.
```

When komutu burada da �al���r

![Resim Yok](./switch.png)


okunurluk i�in a�a��daki gibi yap�l�r m� yap�l�r ama kod a��r� uzar bu sebep ile akl�n�zda olsun

![resim yok](./switch2.png)


```
public class Student
{
    public string name;
    public string surname;
    public string alan;
}

Student student = new Student() { name = "Taha", surname = "M�casiro�lu", alan = "Say�sal" };
string anadersi = student switch
{
    { alan: "Say�sal" } => "Matematik",
    { alan: "S�zel" } => "T�k�e",
    { alan: "E�it-A��rl�k" } => "Matematik ve T�rk�e"
};
```

�stteki kodda ise bir s�n�f i�inde yer alan de�i�kenlere g�re nas�l geri d�n�� ayarlanca�� g�sterilmekte bu kullan�mda de�i�ken oldu ama get ve setlerle oynanarak fonsiyon sonu�lar� ile bile atama yap�l�r baya genelle�tirici bir �ey


















