# DotNet CLI
### Bunun yerine VS kullanmak daha mant�kl�
`Dotnet [komutlar]` �eklinde kullan�l�r. Yani Dotnet ile ba�lamak zorunda

`dotnet help` -> komut listesi

`dotnet new` yazarak �ablon listesini alabilirsiniz.
![Dotnet new terminal sonucu](./dotnet_new.png)

`dotnet new [proje tipi] --name [proje ad�]` -> proje olu�urma komutu

`dotnet new [proje tipi] --name [proje ad�] --force` -> proje olu�urma komutu. E�er proje �nceden varsa �zerine yazar.

`dotnet restore` -> proje kapsam�ndaki ara�lar� veya k�t�phaneleri geri y�kler. (?)

`dotnet build` -> .exe ve .dll ��kt�lar� verir. �ncesinde restore i�lemi yapar.

`dotnet publish` -> yay�nlama i�lemi (?)

`dotnet run` -> projeyi �al��t�r�r.

`dotnet run --no-build` -> uygulamay� derlemeden son derlenmi� hali ile �al��t�r�r

`dotnet add package` -> nuget paket y�klemesi sa�lar.

`dotnet add reference` -> proje referans� eklemeyi sa�lar

`dotnet remove package` ->  paket kald�rmay� sa�lar

`dotnet remove reference` -> referans kald�rmay� sa�lar

`dotnet list reference` -> referanslar� listeler





















