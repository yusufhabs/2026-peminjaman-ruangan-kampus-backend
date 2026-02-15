using System.ComponentModel.DataAnnotations;

namespace PeminjamanRuangan.DTOs
{
    public class PeminjamanDto
    {
        [Required(ErrorMessage = "Nama peminjam wajib diisi")]
        public string NamaPeminjam { get; set; } = "";

        [Required(ErrorMessage = "Nomor ruangan wajib diisi")]
        public string NomorRuangan { get; set; } = "";

        [Required(ErrorMessage = "Tanggal pinjam wajib diisi")]
        public DateTime TanggalPinjam { get; set; }

        [Required(ErrorMessage = "Tanggal kembali wajib diisi")]
        public DateTime TanggalKembali { get; set; }

        public string Keperluan { get; set; } = "";

        public string Status { get; set; } = "menunggu";
    }
}