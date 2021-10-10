using System;
    
    public class KomisiKaryawan : Object
    {
        public string NamaDepan { get; }
        public string NamaBelakang { get; }
        public string NomorKtp { get; }
        private decimal penjualanKotor;
        private decimal tingkatKomisi;

        public KomisiKaryawan(string namaDepan, string namaBelakang, string nomorKtp, decimal penjualanKotor, decimal tingkatKomisi)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomorKtp = nomorKtp;
            PenjualanKotor = penjualanKotor;
            TingkatKomisi = tingkatKomisi;
        }
        public decimal PenjualanKotor
        {
            get
            {
                return penjualanKotor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(PenjualanKotor)} must be >=0 ");
                }
                penjualanKotor = value;
            }
        }
        public decimal TingkatKomisi
        {
            get
            {
                return tingkatKomisi;
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(TingkatKomisi)} must be > 0 and < 1");
                }
                tingkatKomisi = value;
            }
        }
        public decimal Pendapatan() => tingkatKomisi * penjualanKotor;
        public override string ToString() =>
            $"komisi karyawan : {NamaDepan} {NamaBelakang}\n" +
            $"nomor ktp : {NomorKtp}\n" +
            $"penjualan kotor : {penjualanKotor:C}\n" +
            $"tingkat komisi : {tingkatKomisi:F2}";
    }
class TesKomisiKaryawan
{
    static void Main(string[] args)
    {
        var karyawan = new KomisiKaryawan("Sue", "Jones", "222-22-2222", 10000.00M, .06M);

        Console.WriteLine("Informasi karyawan diperoleh dengan properti dan metode:\n");
        Console.WriteLine($"Nama depan adalah {karyawan.NamaDepan}");
        Console.WriteLine($"Nama belakang adalah {karyawan.NamaBelakang}");
        Console.WriteLine($"Nomor Ktp adalah {karyawan.NomorKtp}");
        Console.WriteLine($"Penjualan kotor adalah {karyawan.PenjualanKotor:C}");
        Console.WriteLine($"Tingkat komisi adalah {karyawan.TingkatKomisi:F2}");
        Console.WriteLine($"Pendapatan adalah {karyawan.Pendapatan():C}");

        karyawan.PenjualanKotor = 5000.00M;
        karyawan.TingkatKomisi = .1M;

        Console.WriteLine("\nInformasi karyawan yang diperbarui diperoleh dari ToString:\n");
        Console.WriteLine(karyawan);
        Console.WriteLine($"pendapatan: {karyawan.Pendapatan():C}");
    }
}
