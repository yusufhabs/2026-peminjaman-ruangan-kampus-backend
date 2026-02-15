# Changelog

Semua perubahan penting pada project ini didokumentasikan di file ini.
Format mengacu pada [Keep a Changelog](https://keepachangelog.com/en/1.0.0/)
dan project ini menggunakan [Semantic Versioning](https://semver.org/).

### Added
- Inisialisasi project ASP.NET Core Web API
- Model Peminjaman dengan field lengkap
- CRUD endpoint untuk entitas Peminjaman
- Implementasi soft delete menggunakan field DeletedAt
- Validasi input menggunakan DataAnnotations
- Fitur pencarian berdasarkan nama peminjam dan nomor ruangan
- Manajemen status peminjaman (menunggu/disetujui/ditolak)
- Konfigurasi MySQL menggunakan Pomelo EF Core
- Swagger UI untuk dokumentasi API
- File .gitignore dan .env.example