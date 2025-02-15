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
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    long urun_id;
                    conn.Open();
                    string stokSQL = "INSERT INTO Stok(urun_adi, adet, fiyat) VALUES (@urun_adi, @adet, @fiyat)";

                    using (SQLiteCommand cmd = new SQLiteCommand(stokSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@urun_adi", urunAdi);
                        cmd.Parameters.AddWithValue("@adet", urunAdedi);
                        cmd.Parameters.AddWithValue("@fiyat", urunFiyati);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT last_insert_rowid();";
                        urun_id = (long)cmd.ExecuteScalar();
                    }

                    string hareketSQL = "INSERT INTO Stok_Hareketleri(urun_id, hareket_tipi, miktar, fatura_no, tarih) VALUES (@urun_id, @hareket_tipi, @miktar, @fatura_no, @tarih)";

                    using (SQLiteCommand cmd = new SQLiteCommand(hareketSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@urun_id", urun_id);
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
    }
}
