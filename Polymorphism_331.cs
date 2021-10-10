using System;

    public class KomisiKaryawan
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
                    throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(PenjualanKotor)} harus >= 0");
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
                    throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(TingkatKomisi)} harus > 0 dan < 1");
                }
                tingkatKomisi = value;
            }
        }
        public virtual decimal Pendapatan() => TingkatKomisi * PenjualanKotor;
        public override string ToString() =>
            $"Komisi Karyawan: {NamaDepan} {NamaBelakang}\n" +
            $"Nomor Ktp: {NomorKtp}\n" +
            $"Penjualan Kotor: {PenjualanKotor:C}\n" +
            $"Tingkat Komisi: {TingkatKomisi:F2}";
    }
    public class GajiPokokTambahanKomisiKaryawan : KomisiKaryawan
    {
        private decimal gajiPokok;
        public GajiPokokTambahanKomisiKaryawan(string namaDepan, string namaBelakang,
            string nomorKtp, decimal penjualanKotor,
            decimal tingkatKomisi, decimal gajiPokok)
            : base(namaDepan, namaBelakang, nomorKtp,
                penjualanKotor, tingkatKomisi)
        {
            GajiPokok = gajiPokok;
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
                    throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(GajiPokok)} harus >=0");
                }
                gajiPokok = value;
            }
        }
        public override decimal Pendapatan() => GajiPokok + base.Pendapatan();
        public override string ToString() =>
            $"Gaji Pokok dari {base.ToString()}\ngaji pokok: {GajiPokok:C}";
    }
class TesPolymorphism
{
    static void Main()
    {
        var komisiKaryawan = new KomisiKaryawan("Sue", "Jones", "222-22-2222", 10000.00M, .06M);

        var gajiPokokTambahanKomisiKaryawan = new GajiPokokTambahanKomisiKaryawan("Bob", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);

        Console.WriteLine("Panggil Metode ToString dan Pendapatan Komisi Karyawan " +
            "dengan referensi kelas dasar ke objek kelas dasar\n");
        Console.WriteLine(komisiKaryawan.ToString());
        Console.WriteLine($"pendapatan: {komisiKaryawan.Pendapatan()}\n");

        Console.WriteLine("Panggil ToString GajiPokokTambahanKomisiKaryawan dan " +
            "Metode pendapatan dengan referensi kelas turunan ke " +
            "objek kelas turunan\n");
        Console.WriteLine(gajiPokokTambahanKomisiKaryawan.ToString());
        Console.WriteLine($"pendapatan: { gajiPokokTambahanKomisiKaryawan.Pendapatan()}\n");

        KomisiKaryawan komisiKaryawan2 = gajiPokokTambahanKomisiKaryawan;
        Console.WriteLine("Panggil ToString dan Pendapatan Karyawan GajiPokokTambahanKomisiKaryawan" +
            "metode dengan referensi kelas dasar ke objek kelas turunan");
        Console.WriteLine(komisiKaryawan2.ToString());
        Console.WriteLine($"pendapatan: {gajiPokokTambahanKomisiKaryawan.Pendapatan()}\n");

    }
}

