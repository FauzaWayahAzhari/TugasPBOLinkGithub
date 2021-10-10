using System;
using System.Collections.Generic;

public abstract class Karyawan
{
    public string NamaDepan { get; }
    public string NamaBelakang { get; }
    public string NomorKtp { get; }
    public Karyawan(string namaDepan, string namaBelakang, string nomorKtp)
    {
        NamaDepan = namaDepan;
        NamaBelakang = namaBelakang;
        NomorKtp = nomorKtp;
    }
    public override string ToString() => $"{NamaDepan} {NamaBelakang}\n" +
        $"Nomor Ktp: {NomorKtp}";
    public abstract decimal Pendapatan();
}
public class GajiKaryawan : Karyawan
{
    private decimal gajiMingguan;
    public GajiKaryawan(string namaDepan, string namaBelakang,
        string nomorKtp, decimal gajiMingguan)
        : base(namaDepan, namaBelakang, nomorKtp)
    {
        GajiMingguan = gajiMingguan;
    }
    public decimal GajiMingguan
    {
        get
        {
            return gajiMingguan;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(GajiMingguan)} harus >= 0");
            }
            gajiMingguan = value;
        }
    }
    public override decimal Pendapatan() => GajiMingguan;
    public override string ToString() =>
        $"Gaji Karyawan: {base.ToString()}\n" +
        $"Gaji Mingguan: {GajiMingguan:C}";
}
public class KaryawanPerJam : Karyawan
{
    private decimal gaji;
    private decimal jam;

    public KaryawanPerJam(string namaDepan, string namaBelakang,
        string nomorKtp, decimal gajiPerJam,
        decimal jamKerja)
        : base(namaDepan, namaBelakang, nomorKtp)
    {
        Gaji = gajiPerJam;
        Jam = jamKerja;
    }
    public decimal Gaji
    {
        get
        {
            return gaji;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Gaji)} harus >=0");
            }
            gaji = value;
        }
    }
    public decimal Jam
    {
        get
        {
            return jam;
        }
        set
        {
            if (value < 0 || value > 168)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Jam)} harus >= 0 dan <= 168");
            }
            jam = value;
        }
    }
    public override decimal Pendapatan()
    {
        if (Jam <= 40)
        {
            return Gaji * Jam;
        }
        else
        {
            return (40 * Gaji) + ((Jam - 40) * Gaji * 1.5M);
        }
    }
    public override string ToString() =>
        $"Karyawan Per Jam: {base.ToString()}\n" +
        $"Gaji Per Jam: {Gaji:C}\nJam kerja: {Jam:F2}";
}
public class KomisiKaryawan : Karyawan
{
    private decimal penjualanKotor;
    private decimal tingkatKomisi;

    public KomisiKaryawan(string namaDepan, string namaBelakang,
        string nomorKtp, decimal penjualanKotor,
        decimal tingkatKomisi)
        : base(namaDepan, namaBelakang, nomorKtp)
    {
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
                    value, $"{nameof(PenjualanKotor)} harus >=0");
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
                    value, $"{nameof(TingkatKomisi)} harus > 0 dan <1");
            }
            tingkatKomisi = value;
        }
    }
    public override decimal Pendapatan() => TingkatKomisi * PenjualanKotor;
    public override string ToString() =>
        $"Komisi Karyawan: {base.ToString()}\n" +
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
                    value, $"{nameof(GajiPokok)} harus >= 0");
            }
            gajiPokok = value;
        }
    }
    public override decimal Pendapatan() => GajiPokok + base.Pendapatan();
    public override string ToString() =>
        $"Gaji Pokok {base.ToString()}\nGaji Pokok: {GajiPokok:C}";
}
class TesSistemPenggajian
{
    static void Main()
    {
        var gajiKaryawan = new GajiKaryawan("John", "Smith", "111-11-1111", 800.00M);
        var karyawanPerJam = new KaryawanPerJam("Karen", "Price", "222-22-2222", 16.75M, 40.0M);
        var komisiKaryawan = new KomisiKaryawan("Sue", "Jones", "333-33-3333", 10000.00M, .06M);
        var gajiPokokTambahanKomisiKaryawan = new GajiPokokTambahanKomisiKaryawan("Bob", "Lewis", "444-44-4444", 5000.00M, .04M, 300.00M);

        Console.WriteLine("Karyawan diproses satu per satu:\n");
        Console.WriteLine($"{gajiKaryawan}\n diperoleh: " +
            $"{gajiKaryawan.Pendapatan():C}\n");
        Console.WriteLine($"{karyawanPerJam}\n diperoleh: {karyawanPerJam.Pendapatan():C}\n");
        Console.WriteLine($"{komisiKaryawan}\n diperoleh: " +
            $"{komisiKaryawan.Pendapatan():C}\n");
        Console.WriteLine($"{gajiPokokTambahanKomisiKaryawan}\n diperoleh: " +
            $"{gajiPokokTambahanKomisiKaryawan.Pendapatan():C}\n");

        var karyawan = new List<Karyawan>() {gajiKaryawan,
            karyawanPerJam, komisiKaryawan, gajiPokokTambahanKomisiKaryawan};

        Console.WriteLine("Karyawan diproses secara polimorfik:\n");

        foreach (var karyawanSaatIni in karyawan)
        {
            Console.WriteLine(karyawanSaatIni);

            if (karyawanSaatIni is GajiPokokTambahanKomisiKaryawan)
            {
                var Karyawann = (GajiPokokTambahanKomisiKaryawan)karyawanSaatIni;

                Karyawann.GajiPokok *= 1.10M;
                Console.WriteLine("Gaji pokok baru dengan kenaikan 10% adalah: " +
                    $"{Karyawann.GajiPokok:C}");
            }
            Console.WriteLine($"Pendapatan: {karyawanSaatIni.Pendapatan():C}\n");
        }
        for (int j = 0; j < karyawan.Count; j++)
        {
            Console.WriteLine($"Karyawan {j} adalah {karyawan[j].GetType()}");
        }
    }
}

