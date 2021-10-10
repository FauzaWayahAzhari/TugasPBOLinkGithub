using System;
using System.Collections.Generic;

public interface Hutang
{
    decimal DapatkanJumlahPembayaran();
}
public class Faktur : Hutang
{
    public string BagianNomor { get; }
    public string BagianDeskripsi { get; }
    private int kuantitas;
    private decimal hargaPerBarang;

    public Faktur(string bagianNomor, string bagianDeskripsi, int kuantitas, decimal hargaPerBarang)
    {
        BagianNomor = bagianNomor;
        BagianDeskripsi = bagianDeskripsi;
        Kuantitas = kuantitas;
        HargaPerBarang = hargaPerBarang;
    }
    public int Kuantitas
    {
        get
        {
            return kuantitas;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Kuantitas)} harus >= 0");
            }
            kuantitas = value;
        }
    }
    public decimal HargaPerBarang
    {
        get
        {
            return hargaPerBarang;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(HargaPerBarang)} harus >= 0");
            }
            hargaPerBarang = value;
        }
    }
    public override string ToString() =>
        $"Faktur:\nbagian nomor: {BagianNomor} ({BagianDeskripsi})\n" +
        $"Kuantitas: {Kuantitas}\nharga per barang: {HargaPerBarang:C}";
    public decimal DapatkanJumlahPembayaran() => Kuantitas * HargaPerBarang;
}
public abstract class Karyawan : Hutang
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
    public decimal DapatkanJumlahPembayaran() => Pendapatan();
}
    public class GajiKaryawan : Karyawan
{
    private decimal gajiMingguan;
    public GajiKaryawan(string namaDepan, string namaBelakang, string nomorKtp, decimal gajiMingguan)
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
    public override string ToString() => $"Gaji Karyawan: {base.ToString()}\n" +
        $"GajiMingguan: {GajiMingguan:C}";
}
class TesInterfaceHutang
{
    static void Main()
    {
        var Objekhutang = new List<Hutang>() {
                new Faktur("01234", "kursi", 2, 375.00M),
                new Faktur("56789", "ban", 4, 79.95M),
                new GajiKaryawan("John", "Smith", "111-11-1111", 800.00M),
                new GajiKaryawan("Lisa", "Barnes", "888-88-8888", 1200.00M)};

        Console.WriteLine("Faktur dan Karyawan diproses secara polimorfik:\n");
        foreach (var hutang in Objekhutang)
        {
            Console.WriteLine($"{hutang}");
            Console.WriteLine($"Jatuh tempo pembayaran: {hutang.DapatkanJumlahPembayaran():C}\n");
        }
    }
}




