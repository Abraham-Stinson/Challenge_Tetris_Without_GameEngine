# Tetris: No-Engine Challenge (C# & WPF)

Bu proje, Unity veya Unreal Engine gibi hazır oyun motorları **kullanılmadan**, tamamen **C# ve WPF (Windows Presentation Foundation)** ile sıfırdan geliştirilmiş bir klasik Tetris klonudur. 

Oyun dünyasına ve mekaniklerine aşina bir geliştirici olarak bu projeyi yapmaktaki temel amacım; fizik, çarpışma (collision) ve oyun döngüsü (game loop) gibi hazır motorların arka planda hallettiği sistemleri **temel programlama ve OOP (Nesne Yönelimli Programlama) mantığıyla** kendim inşa etmekti.

## 🚀 Öne Çıkan Özellikler

* **Oyun Motoru Yok:** Herhangi bir dış kütüphane veya oyun motoru kullanılmadı. Tüm oyun mantığı ham C# ile yazıldı.
* **Gelişmiş Blok Sistemi:** 7 farklı klasik Tetromino (I, J, L, O, S, T, Z) matris üzerinde matematiksel olarak döndürülür ve konumlandırılır.
* **Modern Tetris Mekanikleri:** * **Hard Drop (Anında İndirme):** Bloğu anında en alta yapıştırma.
  * **Hold (Blok Saklama):** Mevcut bloğu sonradan kullanmak üzere yedekte tutma veya değiştirme.
* **Skor ve Kayıt Sistemi:** Temizlenen satır sayısına göre katlanarak artan skor hesaplaması ve en yüksek skorun (High Score) yerel bir `.txt` dosyasında kalıcı olarak tutulması.
* **UI ve Event Mimarisi:** Arka plandaki `GameState` (oyun durumu) güncellendiğinde, UI'ın (Kullanıcı Arayüzü) sadece gerekli durumlarda tepki vermesini sağlayan Event (Action) tabanlı mimari.

## 🎮 Kontroller

* ⬅️ **Sol Ok:** Bloğu sola kaydırır.
* ➡️ **Sağ Ok:** Bloğu sağa kaydırır.
* ⬇️ **Aşağı Ok:** Bloğu hızlı indirir (Soft Drop).
* ⬆️ **Yukarı Ok:** Bloğu saat yönünde döndürür (Rotate).
* **Space (Boşluk):** Bloğu anında en alta yerleştirir (Hard Drop).
* **C Tuşu:** Elindeki bloğu saklar veya saklı olan blokla değiştirir (Hold).

## 🛠️ Mimari & Kullanılan Teknolojiler

* **Dil:** C#
* **Arayüz (UI):** WPF / XAML (.NET 8.0)
* **Design Pattern / Mimari:** * Oyun mantığı ile kullanıcı arayüzü (UI) birbirinden tamamen izole edilmiştir.
  * `GameState`: Oyunun kurallarını, matris durumunu ve blok kuyruğunu yöneten "Beyin" sınıfı.
  * Çarpışma Tespiti (Collision Detection): Blokların pozisyonlarının `10x22`'lik Grid (Matris) sınırları içinde kalıp kalmadığını ve diğer bloklarla çakışıp çakışmadığını denetleyen özel fonksiyonlar.

## 📦 Kurulum ve Çalıştırma

1. Bu depoyu bilgisayarınıza klonlayın:
   ```bash
   git clone [https://github.com/Abraham-Stinson/Challenge_Tetris_Without_GameEngine.git](https://github.com/Abraham-Stinson/Challenge_Tetris_Without_GameEngine.git)
   
Projeyi Visual Studio (2022 önerilir) ile açın.

2.sln dosyasını çalıştırın.

3.Gerekli .NET 8.0 SDK'larının kurulu olduğundan emin olun ve projeyi Build edip başlatın.

4.Bu proje, temel yazılım mimarisi ve algoritma pratiği yapmak amacıyla geliştirilmiştir.