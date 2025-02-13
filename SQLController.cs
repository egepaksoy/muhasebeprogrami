using System;
using System.Data.SQLite;


namespace ProgramLibrary
{
    public class SQLController
    {
        private readonly string connectionString;

        public SQLController(string dbPath)
        {
            connectionString = $"Data Source={dbPath};Version=3;";
        }

        public string NewStok(string urunAdi, int urunAdedi, double urunFiyati, string faturaNo, string urunAlisTipi)
        {
            // stok kaydetme
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

        public List<List<String>> GetStok()
        {
            List<List<String>> StokElemanlari = new List<List<String>>();
            
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = $"SELECT * FROM Stok";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StokElemanlari.Add([reader["id"].ToString(), reader["urun_adi"].ToString(), reader["adet"].ToString(), reader["fiyat"].ToString()]);
                        }
                    }
                }
            }

            if (StokElemanlari.Count > 0)
                return StokElemanlari;
            return null;
        }

        public List<string> GetStok(string urun_adi)
        {
            List<string> StokBilgileri = null; // Başlangıçta null
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Stok WHERE urun_adi = @urun_adi";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@urun_adi", urun_adi); // Parametre kullanımı

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Eğer veri varsa
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
    }
}
