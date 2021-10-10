using System;

    public class GajiPokokTambahanKomisiKaryawan
    {
        public string NamaDepan { get; }
        public string NamaBelakang { get; }
        public string NomorKtp { get; }
        private decimal penjualanKotor;
        private decimal tingkatKomisi;
        private decimal gajiPokok;

        public GajiPokokTambahanKomisiKaryawan(string namaDepan, string namaBelakang, string nomorKtp, decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomorKtp = nomorKtp;
            PenjualanKotor = penjualanKotor;
            TingkatKomisi = tingkatKomisi;
            GajiPokok = gajiPokok;
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
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(PenjualanKotor)} harus >=0");
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
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(TingkatKomisi)} harus > 0 dan < 1");
                }
                tingkatKomisi = value;
            }
        }
        public decimal GajiPokok
        {
            get
            {
                return gajiPokok;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(GajiPokok)} harus >=0");
                }
                gajiPokok = value;
            }
        }
        public decimal Pendapatan() => gajiPokok + (tingkatKomisi * penjualanKotor);

        public override string ToString() =>
            $"Gaji pokok Karyawan: {NamaDepan} {NamaBelakang}\n" +
            $"Nomor Ktp: {NomorKtp}\n" +
            $"Penjualan kotor: {penjualanKotor:C}\n" +
            $"Tingkat komisi: {tingkatKomisi:F2}\n" +
            $"Gaji pokok: {gajiPokok:C}";
    }
class TesGajiPokokTambahanKomisiKaryawan
{
    static void Main()
    {
        var karyawan = new GajiPokokTambahanKomisiKaryawan("Bob", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);

        Console.WriteLine("Informasi karyawan diperoleh dari properti dan metode: \n");
        Console.WriteLine($"Nama depan adalah {karyawan.NamaDepan}");
        Console.WriteLine($"Nama belakang adalah {karyawan.NamaBelakang}");
        Console.WriteLine($"Nomor KTP adalah {karyawan.NomorKtp}");
        Console.WriteLine($"Penjualan kotor adalah {karyawan.PenjualanKotor:C}");
        Console.WriteLine($"Tingkat komisi adalah {karyawan.TingkatKomisi:F2}");
        Console.WriteLine($"Pendapatan adalah {karyawan.Pendapatan():C}");
        Console.WriteLine($"Gaji pokok adalah {karyawan.GajiPokok:C}");
        Console.WriteLine();

        karyawan.GajiPokok = 1000.00M;

        Console.WriteLine("Informasi karyawan yang diperbarui diperoleh dari ToString:\n");
        Console.WriteLine(karyawan);
        Console.WriteLine($"Pendapatan: {karyawan.Pendapatan():C}");
    }
}

