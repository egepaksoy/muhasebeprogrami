using Muhasebe_Programı;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using static System.Data.Entity.Infrastructure.Design.Executor;


namespace ProgramLibrary
{
    public class SQLController
    {
        private readonly string connectionString;

        public SQLController(string dbPath)
        {
            connectionString = $"Data Source={dbPath};Version=3;";
        }

        public SQLController()
        {
            connectionString = $"Data Source=D:\\PROJELER\\Muhasebe Programı\\muhasebe.db; Version=3;";
        }

        public string NewCari(string cariAdi, string cariTelefonu, string cariAdresi)
        {
            long cariId;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string stokSQL = "INSERT INTO Cariler(ad_soyad, telefon, adres) VALUES (@ad_soyad, @telefon, @adres)";

                    using (SQLiteCommand cmd = new SQLiteCommand(stokSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad_soyad", cariAdi);
                        cmd.Parameters.AddWithValue("@telefon", cariTelefonu);
                        cmd.Parameters.AddWithValue("@adres", cariAdresi);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT last_insert_rowid();";
                        cariId = (long)cmd.ExecuteScalar();
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return cariId.ToString();
        }

        public string UpdateCari(long cariId, string cariAdi, string cariTelefonu, string cariAdresi)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string stokSQL = "UPDATE Cariler SET ad_soyad=@cariAdi, telefon=@cariTelefonu, adres=@cariAdresi WHERE id=@cari_id";

                    using (SQLiteCommand cmd = new SQLiteCommand(stokSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@cari_id", cariId);
                        cmd.Parameters.AddWithValue("@cariAdi", cariAdi);
                        cmd.Parameters.AddWithValue("@cariTelefonu", cariTelefonu);
                        cmd.Parameters.AddWithValue("@cariAdresi", cariAdresi);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return null;
        }

        public List<string> GetCari(string cariAdi)
        {
            List<string> CariBilgileri = null;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Cariler WHERE ad_soyad = @cari_adi";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@cari_adi", cariAdi);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CariBilgileri = new List<string>
                            {
                                reader["id"].ToString(),
                                reader["ad_soyad"].ToString(),
                                reader["telefon"].ToString(),
                                reader["adres"].ToString()
                            };
                        }
                    }
                }
            }
            return CariBilgileri;
        }

        public List<string> GetCari(long cariId)
        {
            List<string> CariBilgileri = null;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Cariler WHERE id = @cari_id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@cari_id", cariId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CariBilgileri = new List<string>
                            {
                                reader["id"].ToString(),
                                reader["ad_soyad"].ToString(),
                                reader["telefon"].ToString(),
                                reader["adres"].ToString()
                            };
                        }
                    }
                }
            }
            return CariBilgileri;
        }

        public List<string> LoadCariler()
        {
            List<String> Cariler = new List<String>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = $"SELECT ad_soyad FROM Cariler";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cariler.Add(reader["ad_soyad"].ToString());
                        }
                    }
                }
            }

            if (Cariler.Count > 0)
                return Cariler;
            return null;
        }

        public bool DeleteCari(long cari_id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = $"DELETE FROM Cariler WHERE id = @cari_id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@cari_id", cari_id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        return false;
                    else
                        return true;
                }
            }
        }

        public string NewKasa(string kasaAdi, double bakiye)
        {
            long kasaId;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string stokSQL = "INSERT INTO Kasalar(kasa_adi, bakiye) VALUES (@kasa_adi, @bakiye)";

                    using (SQLiteCommand cmd = new SQLiteCommand(stokSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@kasa_adi", kasaAdi);
                        cmd.Parameters.AddWithValue("@bakiye", bakiye);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT last_insert_rowid();";
                        kasaId = (long)cmd.ExecuteScalar();
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return kasaId.ToString();
        }

        public string UpdateKasa(long KasaId, string KasaAdi, double KasaBakiye)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string stokSQL = "UPDATE Kasalar SET kasa_adi=@kasa_adi, bakiye=@bakiye WHERE id=@kasa_id";

                    using (SQLiteCommand cmd = new SQLiteCommand(stokSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@kasa_id", KasaId);
                        cmd.Parameters.AddWithValue("@kasa_adi", KasaAdi);
                        cmd.Parameters.AddWithValue("@bakiye", KasaBakiye);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return null;
        }

        public string SatisKasa(long KasaId, double YeniBakiye)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string stokSQL = "UPDATE Kasalar SET bakiye=@bakiye WHERE id=@kasa_id";

                    using (SQLiteCommand cmd = new SQLiteCommand(stokSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@kasa_id", KasaId);
                        cmd.Parameters.AddWithValue("@bakiye", YeniBakiye);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return null;
        }

        public List<string> GetKasa(string kasaAdi)
        {
            List<string> KasaBilgileri = null;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Kasalar WHERE kasa_adi = @kasa_adi";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kasa_adi", kasaAdi);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            KasaBilgileri = new List<string>
                            {
                                reader["id"].ToString(),
                                reader["kasa_adi"].ToString(),
                                reader["bakiye"].ToString()
                            };
                        }
                    }
                }
            }
            return KasaBilgileri;
        }

        public List<string> GetKasa(long kasaId)
        {
            List<string> KasaBilgileri = null;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Kasalar WHERE id = @kasa_id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kasa_id", kasaId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            KasaBilgileri = new List<string>
                            {
                                reader["id"].ToString(),
                                reader["kasa_adi"].ToString(),
                                reader["bakiye"].ToString()
                            };
                        }
                    }
                }
            }
            return KasaBilgileri;
        }

        public List<string> LoadKasalar()
        {
            List<String> KasaElemanlari = new List<String>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = $"SELECT kasa_adi FROM Kasalar";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KasaElemanlari.Add(reader["kasa_adi"].ToString());
                        }
                    }
                }
            }

            if (KasaElemanlari.Count > 0)
                return KasaElemanlari;
            return null;
        }

        public bool DeleteKasa(long kasa_id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = $"DELETE FROM Kasalar WHERE id = @kasa_id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kasa_id", kasa_id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        return false;
                    else
                        return true;
                }
            }
        }

        public string NewStok(string urunAdi, int urunAdedi, double urunFiyati, string faturaNo, string urunAlisTipi)
        {
            long urunId;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string stokSQL = "INSERT INTO Stok(urun_adi, adet, fiyat) VALUES (@urun_adi, @adet, @fiyat)";

                    using (SQLiteCommand cmd = new SQLiteCommand(stokSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@urun_adi", urunAdi);
                        cmd.Parameters.AddWithValue("@adet", urunAdedi);
                        cmd.Parameters.AddWithValue("@fiyat", urunFiyati);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT last_insert_rowid();";
                        urunId = (long)cmd.ExecuteScalar();
                    }

                    string hareketSQL = "INSERT INTO Stok_Hareketleri(urun_id, hareket_tipi, miktar, fatura_no, tarih) VALUES (@urun_id, @hareket_tipi, @miktar, @fatura_no, @tarih)";

                    using (SQLiteCommand cmd = new SQLiteCommand(hareketSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@urun_id", urunId);
                        cmd.Parameters.AddWithValue("@hareket_tipi", urunAlisTipi);
                        cmd.Parameters.AddWithValue("@miktar", urunAdedi);
                        cmd.Parameters.AddWithValue("@fatura_no", faturaNo);
                        cmd.Parameters.AddWithValue("@tarih", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return urunId.ToString();
        }

        public string UpdateStok(long urunId, string urunAdi, int urunAdedi, double urunFiyati, string faturaNo, string urunAlisTipi)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string stokSQL = "UPDATE Stok SET urun_adi=@urun_adi, adet=@adet, fiyat=@fiyat WHERE id=@urun_id";

                    using (SQLiteCommand cmd = new SQLiteCommand(stokSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@urun_id", urunId);
                        cmd.Parameters.AddWithValue("@urun_adi", urunAdi);
                        cmd.Parameters.AddWithValue("@adet", urunAdedi);
                        cmd.Parameters.AddWithValue("@fiyat", urunFiyati);
                        cmd.ExecuteNonQuery();
                    }

                    string hareketSQL = "INSERT INTO Stok_Hareketleri(urun_id, hareket_tipi, miktar, fatura_no, tarih) VALUES (@urun_id, @hareket_tipi, @miktar, @fatura_no, @tarih)";

                    using (SQLiteCommand cmd = new SQLiteCommand(hareketSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@urun_id", urunId);
                        cmd.Parameters.AddWithValue("@hareket_tipi", urunAlisTipi);
                        cmd.Parameters.AddWithValue("@miktar", urunAdedi);
                        cmd.Parameters.AddWithValue("@fatura_no", faturaNo);
                        cmd.Parameters.AddWithValue("@tarih", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return null;
        }

        public string SatisStok(long urunId, int urunAdedi)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string stokSQL = "UPDATE Stok SET adet=@adet WHERE id=@urun_id";

                    using (SQLiteCommand cmd = new SQLiteCommand(stokSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@urun_id", urunId);
                        cmd.Parameters.AddWithValue("@adet", urunAdedi);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return null;
        }

        public List<string> GetStok(string urun_adi)
        {
            List<string> StokBilgileri = null;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Stok WHERE urun_adi = @urun_adi";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@urun_adi", urun_adi);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            StokBilgileri = new List<string>
                            {
                                reader["id"].ToString(),
                                reader["urun_adi"].ToString(),
                                reader["adet"].ToString(),
                                reader["fiyat"].ToString()
                            };
                        }
                    }
                }
            }
            return StokBilgileri;
        }

        public List<string> GetStok(long urunId)
        {
            List<string> StokBilgileri = null;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Stok WHERE id = @urun_id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@urun_id", urunId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            StokBilgileri = new List<string>
                            {
                                reader["id"].ToString(),
                                reader["urun_adi"].ToString(),
                                reader["adet"].ToString(),
                                reader["fiyat"].ToString()
                            };
                        }
                    }
                }
            }
            return StokBilgileri;
        }

        public List<string> LoadStoklar()
        {
            List<String> StokElemanlari = new List<String>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = $"SELECT urun_adi FROM Stok";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StokElemanlari.Add(reader["urun_adi"].ToString());
                        }
                    }
                }
            }

            if (StokElemanlari.Count > 0)
                return StokElemanlari;
            return null;
        }

        public bool DeleteStok(long stok_id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = $"DELETE FROM Stok WHERE id = @stok_id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@stok_id", stok_id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        return false;
                    else
                        return true;
                }
            }
        }

        public string NewSatis(long cariId, long urunId, long kasaId, int adet, double toplamTutar, string odemeTuru)
        {
            long satisId;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    if (odemeTuru.ToLower() == "nakit")
                        odemeTuru = "pesin";
                    else if (odemeTuru.ToLower() == "taksit")
                        odemeTuru = "taksit";
                    else
                        return "Ödeme türü yanlış";

                    conn.Open();
                    string stokSQL = "INSERT INTO Satislar(cari_id, urun_id, kasa_id, adet, toplam_tutar, odeme_tipi) VALUES (@cari_id, @urun_id, @kasa_id, @adet, @toplam_tutar, @odeme_tipi)";

                    using (SQLiteCommand cmd = new SQLiteCommand(stokSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@cari_id", cariId);
                        cmd.Parameters.AddWithValue("@urun_id", urunId);
                        cmd.Parameters.AddWithValue("@kasa_id", kasaId);
                        cmd.Parameters.AddWithValue("@adet", adet);
                        cmd.Parameters.AddWithValue("@toplam_tutar", toplamTutar);
                        cmd.Parameters.AddWithValue("@odeme_tipi", odemeTuru);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT last_insert_rowid();";
                        satisId = (long)cmd.ExecuteScalar();
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return satisId.ToString();
        }

        public List<string> GetSatis(long satisId)
        {
            List<string> Satis = null;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Satislar WHERE id = @satis_id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@satis_id", satisId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Satis = new List<string>
                            {
                                reader["id"].ToString(),
                                reader["cari_id"].ToString(),
                                reader["urun_id"].ToString(),
                                reader["kasa_id"].ToString(),
                                reader["adet"].ToString(),
                                reader["toplam_tutar"].ToString(),
                                reader["tarih"].ToString(),
                                reader["odeme_tipi"].ToString()
                            };
                        }
                    }
                }
            }
            return Satis;
        }

        public List<List<string>> GetCariSatislari(long cariId)
        {
            List<List<string>> Satislar = new List<List<string>>();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Satislar WHERE cari_id = @cari_id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@cari_id", cariId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Satislar.Add(new List<string>
                            {
                                reader["id"].ToString(),
                                reader["cari_id"].ToString(),
                                reader["urun_id"].ToString(),
                                reader["kasa_id"].ToString(),
                                reader["adet"].ToString(),
                                reader["toplam_tutar"].ToString(),
                                reader["tarih"].ToString(),
                                reader["odeme_tipi"].ToString()
                            });
                        }
                    }
                }
            }

            if (Satislar.Count > 0)
                return Satislar;
            return null;
        }

        public List<List<string>> LoadSatislar()
        {
            List<List<string>> Satislar = new List<List<string>>();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Satislar";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Satislar.Add(new List<string>
                            {
                                reader["id"].ToString(),
                                reader["cari_id"].ToString(),
                                reader["urun_id"].ToString(),
                                reader["kasa_id"].ToString(),
                                reader["adet"].ToString(),
                                reader["toplam_tutar"].ToString(),
                                reader["tarih"].ToString(),
                                reader["odeme_tipi"].ToString()
                            });
                        }
                    }
                }
            }
            if (Satislar.Count > 0)
                return Satislar;
            return null;
        }

        public string NewTaksit(long satisId, long cariId, double toplamTutar, string odemeTarihleri, double kalanTutar, int taksitSayisi, double aylikOdemeMiktari, string vadeTipi)
        {
            long taksitId;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string stokSQL = "INSERT INTO Taksitler(satis_id, cari_id, toplam_tutar, odeme_tarihleri, kalan_tutar, taksit_sayisi, aylik_odeme_miktari, vade_tipi) VALUES (@satis_id, @cari_id, @toplam_tutar, @odeme_tarihleri, @kalan_tutar, @taksit_sayisi, @aylik_odeme_miktari, @vade_tipi)";

                    using (SQLiteCommand cmd = new SQLiteCommand(stokSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@satis_id", satisId);
                        cmd.Parameters.AddWithValue("@cari_id", cariId);
                        cmd.Parameters.AddWithValue("@toplam_tutar", toplamTutar);
                        cmd.Parameters.AddWithValue("@odeme_tarihleri", odemeTarihleri);
                        cmd.Parameters.AddWithValue("@kalan_tutar", kalanTutar);
                        cmd.Parameters.AddWithValue("@taksit_sayisi", taksitSayisi);
                        cmd.Parameters.AddWithValue("@aylik_odeme_miktari", aylikOdemeMiktari);
                        cmd.Parameters.AddWithValue("@vade_tipi", vadeTipi);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT last_insert_rowid();";
                        taksitId = (long)cmd.ExecuteScalar();
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return taksitId.ToString();
        }

        public List<List<string>> GetTaksit(string cariAdi)
        {
            List<List<string>> TaksitBilgileri = new List<List<string>>();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                long cariId = Convert.ToInt64(this.GetCari(cariAdi)[0]);

                conn.Open();
                string sql = "SELECT * FROM Taksitler WHERE cari_id = @cari_id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@cari_id", cariId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaksitBilgileri.Add(new List<string>
                            {
                                reader["id"].ToString(),
                                reader["satis_id"].ToString(),
                                reader["cari_id"].ToString(),
                                reader["toplam_tutar"].ToString(),
                                reader["odeme_tarihleri"].ToString(),
                                reader["odenen_tutarlar"].ToString(),
                                reader["kalan_tutar"].ToString(),
                                reader["taksit_sayisi"].ToString(),
                                reader["aylik_odeme_miktari"].ToString(),
                                reader["vade_tipi"].ToString(),
                                reader["aktif"].ToString()
                            });
                        }
                    }
                }
            }
            if (TaksitBilgileri.Count > 0)
                return TaksitBilgileri;
            return null;
        }

        public List<string> GetTaksit(long taksitId)
        {
            List<string> TaksitBilgileri = null;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Taksitler WHERE id = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", taksitId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TaksitBilgileri = new List<string>
                            {
                                reader["id"].ToString(),
                                reader["satis_id"].ToString(),
                                reader["cari_id"].ToString(),
                                reader["toplam_tutar"].ToString(),
                                reader["odeme_tarihleri"].ToString(),
                                reader["odenen_tutarlar"].ToString(),
                                reader["kalan_tutar"].ToString(),
                                reader["taksit_sayisi"].ToString(),
                                reader["aylik_odeme_miktari"].ToString(),
                                reader["vade_tipi"].ToString(),
                                reader["aktif"].ToString()
                            };
                        }
                    }
                }
            }
            return TaksitBilgileri;
        }

        public List<List<string>> GetCariTaksitleri(long cariId)
        {
            List<List<string>> TaksitlerBilgileri = new List<List<string>>();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Taksitler WHERE cari_id = @cari_id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@cari_id", cariId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaksitlerBilgileri.Add(new List<string>
                            {
                                reader["id"].ToString(),
                                reader["satis_id"].ToString(),
                                reader["cari_id"].ToString(),
                                reader["toplam_tutar"].ToString(),
                                reader["odeme_tarihleri"].ToString(),
                                reader["odenen_tutarlar"].ToString(),
                                reader["kalan_tutar"].ToString(),
                                reader["taksit_sayisi"].ToString(),
                                reader["aylik_odeme_miktari"].ToString(),
                                reader["vade_tipi"].ToString(),
                                reader["aktif"].ToString()
                            });
                        }
                    }
                }
            }
            if (TaksitlerBilgileri.Count > 0)
                return TaksitlerBilgileri;
            return null;
        }

        public List<List<string>> LoadTaksitler(bool aktif)
        {
            List<List<string>> TaksitBilgileri = new List<List<string>>();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Taksitler WHERE aktif=@aktif";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@aktif", aktif);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaksitBilgileri.Add(new List<string>
                            {
                                reader["id"].ToString(),
                                reader["satis_id"].ToString(),
                                reader["cari_id"].ToString(),
                                reader["toplam_tutar"].ToString(),
                                reader["odeme_tarihleri"].ToString(),
                                reader["odenen_tutarlar"].ToString(),
                                reader["kalan_tutar"].ToString(),
                                reader["taksit_sayisi"].ToString(),
                                reader["aylik_odeme_miktari"].ToString(),
                                reader["vade_tipi"].ToString(),
                                reader["aktif"].ToString()
                            });
                        }
                    }
                }
            }
            if (TaksitBilgileri.Count > 0)
                return TaksitBilgileri;
            return null;
        }

        public string TaksitOde(long taksitId, double odemeMiktari, DateTime odemeTarihi)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    List<string> taksit = this.GetTaksit(taksitId);

                    string odenenTutarlar = taksit[5] + $"{odemeMiktari}/";
                    double kalanTutar = Convert.ToDouble(taksit[6]) - odemeMiktari;

                    string stokSQL = "UPDATE Taksitler SET odenen_tutarlar=@odenen_tutarlar, kalan_tutar=@kalan_tutar WHERE id=@taksit_id";

                    using (SQLiteCommand cmd = new SQLiteCommand(stokSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@taksit_id", taksitId);
                        cmd.Parameters.AddWithValue("@odenen_tutarlar", odenenTutarlar);
                        cmd.Parameters.AddWithValue("@kalan_tutar", kalanTutar);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return null;
        }

        public bool DeleteTaksit(long taksitId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = $"DELETE FROM Taksitler WHERE id = @taksit_id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@taksit_id", taksitId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        return false;
                    else
                        return true;
                }
            }
        }
    }
}
