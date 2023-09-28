<!--/Başlık-->
<div align = "center">
  <h1>
    E - KÜTÜPHANE OTOMASYONU
  </h1>
</div>
<!--//Başlık-->

<!--/İlk Paragraf-->
<div align = "justify">
  <p>
    Bu proje soğan mimaririsi içerisinde Asp.NET Core 6.0 Model View Controller mimarisi kullanılarak geliştirilmektedir. Otomasyon içerisinde kitap ekleme, silme, güncelleme,
    kitap arama v.b. uygulamalar bulunduracak olup, kullanıcılar tarafından kullanılabilmektedir. Temel ihtiyaçları karşılayacak olan giriş yapma, kayıt olma, şifremi unuttum
    gibi işlemler de bulunduracaktır.
  </p>
	<div align = "center">
		<img src = "/Presentation/Archieves.Kutuphane/wwwroot/images/Project.png"/>
	</div>
  <br />
  <p>
    Yapı içerisinde aktif halde google autho api 'si bulunup, bazı diğer işlemlerinde api 'leştirilmesi planlanmaktadır.
  </p>
  <br />
  <p>
    Projenin ilk yüklenme tarihi 13.09.2023 olup, v1.0 olarak adlandırılacaktır. Gelişmeler güncellemeler halinde aktarıldıktan sonra ise yeni versiyonlar halinde isimlendirilmeye
    devam edilecektir.
  </p>
	<br />
	<p>
		İlk stabil versiyonun eldesi V1.10 ile olmuştur. Bu sürüm ile proje, ArchievesDb veritabanında bulunan Books tablosundaki kitapları çekerek BookController 'daki Index IActionResult 'u
		aracılığıyla Book > Index.cshtml razor sayfasına listeliyor. Sayfa dahilinde bulunması planlanan maksimum sayıdaki kitap sayısı henüz ayarlanmadı. Dolayısıyla çok sayıda kitabın
		olması durumu tüm kitapları yüklemeyi gerektireceğinden mantıklı ve verimli bir seçim olmayacaktır.
	</p>
	<p>
		Aynı zamanda BookDetails.cshtml razor sayfası aracılığıyla seçilmiş olan kitabın detaylarını içeren farklı bir sayfayı oluşturup, bu sayfaya yeniden ArchievesDb veritabanında bulunan
		Comments tablosundaki yorumları çekerek CommentListByBookId aracılığıyla ViewComponent kullanılarak listeliyor.
	</p>
	<p>
		Yeniden v1.10 sürümünde Anasayfa, Kitaplar, Hakkında, İletişim, Giriş Yap ve Kayıt Ol sayfalarına geçiş yapmak mümkündür. Bu sayfalar arasından Hakkında, İletişim, Giriş Yap ve Kayıt Ol
		sayfaları veritabanına işleme veya veritabanından kontrol işlemleri yapmamaktadır.
	</p>
	<br />
	<p>
		...
	</p>
  <br />
  <p>
		<i>
    Aktif halde bulunan güncel proje, çalıştırılma noktalarında hatalar fırlatma ihtimaline sahiptir. Tam (optimize) sürüm çıkmadan çalışma sırasında alınacak hatalar oldukça
    normaldir.
		</i>
  </p>
</div>
<!--//İlk Paragraf-->
  
<!--/Güncellemeler-->
<div align = "justify">
  <h2 align = "center">🪐 GÜNCELLEMELER 🪐</h2>
  <ul>
    <li>v1.0  Projenin GitHub 'a yüklenmesi.</li>
    <li>v1.1  Projenin aktif aşamasında kullanılmayan komutlarım yorumlaştırılması.</li>
    <li>v1.2  Repository, Service and Interface (Application) katmanına interface 'lerin eklenmesi.</li>
    <li>v1.3  Repository, Service and Interface (Application) katmanına service 'lerin eklenmesi.</li>
    <li>v1.4  Domain katmanına güncelleme.</li>
    <li>v1.5  Repository, Service and Interface (Application) katmanına güncelleme.</li>
    <li>v1.6  Persistance katmanına context eklenmesi.</li>
    <li>v1.7  Persistance katmanına güncelleme.</li>
    <li>v1.8  Persistance katmanına concrete, repository ve efrepository eklenmesi.</li>
    <li>v1.9	Presentation katmanına güncelleme.</li>
		<li>v1.10	Tüm projeye genel bir güncelleme ile stabil çalışan proje eldesi.</li>
		<br />
		<li>v2.0	Presentation katmanına güncelleme.</li>
		<li>v2.1	Tüm projeye genel bir güncelleme ve kayıt olma eklenmesi.</li>
		<li>v2.2	Domain katmanına güncelleme.</li>
		<li>v2.3	Presentation katmanına güncelleme.</li>
		<li>v2.4	Tüm projeye genel bir güncelleme ve bug / namespace düzenlemeleri.</li>
		<li>v2.5	Presentation katmanına güncelleme (Abone olma özelliği ile e - posta kaydı yapabilme).</li>
	  <li>v2.6	Presentation katmanına güncelleme (Giriş yap fonksiyonlarına iyileştirme ve kimlik doğrulama işlemleri)</li>
		<li>v2.7	Presentation katmanına güncelleme (Admin paneli, yeni kitaplar ve genel bir güncelleme)</li>
		<li>v2.8	Presentation katmanına güncelleme (Yorum yapma altyapısında köklü değişiklik ve genel bir güncelleme)</li>
  </ul>
</div>
<!--//Güncellemeler-->

<!--/İkinci Paragraf-->
<div align = "center">
  <h2>🪐 KULLANILAN TEKNOLOJİLER 🪐</h2>
</div>
<div align = "center">
	<a target = "_blank"><img alt = "C#" src = "https://img.shields.io/badge/-C%23-3776AB?style=flat-square&logo=c-sharp&logoColor=white" align = "middle" height = "25"></a>
	<a target = "_blank"><img alt = "C#" src = "https://img.shields.io/badge/-CSS-3776AB?style=flat-square&logo=css3&logoColor=white" align = "middle" height = "25"></a>
	<a target = "_blank"><img alt = "C#" src = "https://img.shields.io/badge/-HTML%205-3776AB?style=flat-square&logo=html5&logoColor=white" align = "middle" height = "25"></a>
	<a target = "_blank"><img alt = "C#" src = "https://img.shields.io/badge/-Javascript-3776AB?style=flat-square&logo=javascript&logoColor=white" align = "middle" height = "25"></a>
</div>
<!--//İkinci Paragraf-->

<!--/Üçüncü Paragraf-->
<div align = "center">
  <h2>🪐 KULLANILAN EDİTÖRLER 🪐</h2>
</div>
<div align = "center">
	<a target = "_blank"><img alt = "Visual Studio" src = "https://img.shields.io/badge/-Visual%20Studio-3776AB?style=flat-square&logo=visual-studio&logoColor=white" align = "middle" height = "25"></a>
	<a target = "_blank"><img alt = "Visual Studio Code" src = "https://img.shields.io/badge/-Visual%20Studio%20Code-3776AB?style=flat-square&logo=visual-studio-code&logoColor=white" align = "middle" height = "25"></a>
</div>
<!--//Üçüncü Paragraf-->

<!--/Dördüncü Paragraf-->
<div align = "center">
  <h2>🪐 SOSYAL MEDYA 🪐</h2>
</div>
<div align = "center">
	<a href = "https://www.twitch.tv/deofhell" target = "_blank"><img alt = "Twitch" src = "https://img.shields.io/badge/-Twitch-3776AB?style=flat-square&logo=twitch&logoColor=white" align = "middle" height = "25"></a>
	<a href = "https://www.youtube.com/@headclef" target = "_blank"><img alt = "Youtube" src = "https://img.shields.io/badge/-Youtube-3776AB?style=flat-square&logo=youtube&logoColor=white" align = "middle" height = "25"></a>
</div>
<div align = "center">
	<a target = "_blank"><img alt = "Discord" src = "https://img.shields.io/badge/-headclef%239871-3776AB?style=flat-square&logo=discord&logoColor=white" align = "middle" height = "25"></a>
	<a href = "https://www.facebook.com/headcleFT/" target = "_blank"><img alt = "Facebook" src = "https://img.shields.io/badge/-Facebook-3776AB?style=flat-square&logo=facebook&logoColor=white" align = "middle" height = "25"></a>
	<a href = "https://www.instagram.com/headclef/" target = "_blank"><img alt = "Instagram" src = "https://img.shields.io/badge/-Instagram-3776AB?style=flat-square&logo=instagram&logoColor=white" align = "middle" height = "25"></a>
</div>
<div align = "center">
	<a href = "https://www.hackerrank.com/elbisetakim" target = "_blank"><img alt = "Hackerrank" src = "https://img.shields.io/badge/-Hackerrank-3776AB?style=flat-square&logo=hackerrank&logoColor=white" align = "middle" height = "25"></a>
	<a href = "https://github.com/headclef" target = "_blank"><img alt = "Github" src = "https://img.shields.io/badge/-Github-3776AB?style=flat-square&logo=github&logoColor=white" align = "middle" height = "25"></a>
</div>
<!--//Dördüncü Paragraf-->

<!--/Beşinci Paragraf-->
<div align = "center">
  <h2>🪐 İLETİŞİM 🪐</h2>
</div>
<div align = "center">
	<a href = "https://www.linkedin.com/in/furkantural" target = "_blank"><img alt = "LinkedIn" src = "https://img.shields.io/badge/-LinkedIn-3776AB?style=flat-square&logo=Linkedin&logoColor=white" align = "middle" height = "25"></a>
	<a target = "_blank"><img alt = "E - Mail" src= "https://img.shields.io/badge/-furkanturalofficial@outlook.com-3776AB?style=flat-square&logo=microsoft-outlook&logoColor=white" align = "middle" height = "25"></a>
</div>
<!--//Beşinci Paragraf-->
