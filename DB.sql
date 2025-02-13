CREATE TABLE "Cariler" (
  "id" integer PRIMARY KEY,
  "ad_soyad" varchar,
  "telefon" phone,
  "adres" text,
  "borc_bakiye" integer
);

CREATE TABLE "Kasalar" (
  "id" integer PRIMARY KEY,
  "kasa_adi" varchar,
  "bakiye" integer
);

CREATE TABLE "Stok" (
  "id" integer PRIMARY KEY,
  "urun_adi" varchar,
  "adet" integer,
  "fiyat" integer
);

CREATE TABLE "Satislar" (
  "id" integer PRIMARY KEY,
  "cari_id" integer,
  "urun_id" integer,
  "kasa_id" ingeter,
  "adet" integer,
  "toplam_tutar" integer,
  "tarih" timestamp,
  "odeme_tipi" varchar
);

CREATE TABLE "Taksitler" (
  "id" integer PRIMARY KEY,
  "cari_id" integer,
  "toplam_tutar" integer,
  "ilk_odeme" timestamp,
  "kalan_tutar" integer,
  "taksit_sayisi" integer,
  "vade_tipi" text
);

CREATE TABLE "Odemeler" (
  "id" integer PRIMARY KEY,
  "taksit_id" integer,
  "odeme_miktari" integer,
  "odeme_tarihi" timestamp
);

ALTER TABLE "Cariler" ADD FOREIGN KEY ("id") REFERENCES "Satislar" ("cari_id");

ALTER TABLE "Kasalar" ADD FOREIGN KEY ("id") REFERENCES "Satislar" ("kasa_id");

ALTER TABLE "Stok" ADD FOREIGN KEY ("id") REFERENCES "Satislar" ("urun_id");

ALTER TABLE "Cariler" ADD FOREIGN KEY ("id") REFERENCES "Taksitler" ("cari_id");

ALTER TABLE "Taksitler" ADD FOREIGN KEY ("id") REFERENCES "Odemeler" ("taksit_id");
