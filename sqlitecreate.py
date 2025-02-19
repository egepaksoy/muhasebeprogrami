import sqlite3

# SQLite veritabanına bağlan
conn = sqlite3.connect("muhasebe.db")
cursor = conn.cursor()

cursor.execute("""
DROP TABLE IF EXISTS Cariler
""")
cursor.execute("""
DROP TABLE IF EXISTS Kasalar
""")
cursor.execute("""
DROP TABLE IF EXISTS Stok
""")
cursor.execute("""
DROP TABLE IF EXISTS Stok_Hareketleri
""")
cursor.execute("""
DROP TABLE IF EXISTS Satislar
""")
cursor.execute("""
DROP TABLE IF EXISTS Taksitler
""")
cursor.execute("""
DROP TABLE IF EXISTS Odemeler
""")

# Tabloları oluştur
cursor.execute("""
CREATE TABLE IF NOT EXISTS Cariler (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    ad_soyad VARCHAR NOT NULL,
    telefon TEXT,
    adres TEXT,
    borc_bakiye INTEGER DEFAULT 0
)
""")

cursor.execute("""
CREATE TABLE IF NOT EXISTS Kasalar (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    kasa_adi VARCHAR NOT NULL,
    bakiye INTEGER DEFAULT 0
)
""")

cursor.execute("""
CREATE TABLE IF NOT EXISTS Stok (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    urun_adi VARCHAR NOT NULL,
    adet INTEGER DEFAULT 0,
    fiyat INTEGER NOT NULL
)
""")

cursor.execute("""
CREATE TABLE IF NOT EXISTS Stok_Hareketleri (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    urun_id INTEGER NOT NULL,
    hareket_tipi TEXT CHECK(hareket_tipi IN ('sayim', 'alim')),
    miktar INTEGER NOT NULL,
    fatura_no TEXT,
    tarih TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)
""")

cursor.execute("""
CREATE TABLE IF NOT EXISTS Satislar (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    cari_id INTEGER NOT NULL,
    urun_id INTEGER NOT NULL,
    kasa_id INTEGER NOT NULL,
    adet INTEGER NOT NULL,
    toplam_tutar INTEGER NOT NULL,
    tarih TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    odeme_tipi VARCHAR CHECK(odeme_tipi IN ('pesin', 'taksit'))
)
""")

cursor.execute("""
CREATE TABLE IF NOT EXISTS Taksitler (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    satis_id INTEGER NOT NULL,
    cari_id INTEGER NOT NULL,
    toplam_tutar INTEGER NOT NULL,
    ilk_odeme TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    kalan_tutar INTEGER NOT NULL,
    taksit_sayisi INTEGER NOT NULL,
	aylik_odeme_miktari FLOAT NOT NULL,
    vade_tipi TEXT CHECK(vade_tipi IN ('aylik', 'haftalik')),
	aktif BOOLEAN DEFAULT TRUE
)
""")

cursor.execute("""
CREATE TABLE IF NOT EXISTS Odemeler (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    taksit_id INTEGER NOT NULL,
    odeme_miktari INTEGER NOT NULL,
    odeme_tarihi TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)
""")

# Değişiklikleri kaydet ve bağlantıyı kapat
conn.commit()
conn.close()

print("Veritabanı ve tablolar oluşturuldu.")
