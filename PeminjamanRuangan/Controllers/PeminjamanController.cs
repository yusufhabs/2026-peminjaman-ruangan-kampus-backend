using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeminjamanRuangan.Data;
using PeminjamanRuangan.DTOs;
using PeminjamanRuangan.Models;

namespace PeminjamanRuangan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeminjamanController : ControllerBase
    {
        private readonly AppDbContext _db;

        public PeminjamanController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/peminjaman
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string? search)
        {
            var query = _db.Peminjamans.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(p =>
                    p.NamaPeminjam.Contains(search) ||
                    p.NomorRuangan.Contains(search));

            return Ok(await query.ToListAsync());
        }

        // GET: api/peminjaman/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Show(int id)
        {
            var peminjaman = await _db.Peminjamans.FindAsync(id);
            if (peminjaman == null)
                return NotFound(new { message = "Data tidak ditemukan" });

            return Ok(peminjaman);
        }

        // POST: api/peminjaman
        [HttpPost]
        public async Task<IActionResult> Store([FromBody] PeminjamanDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var peminjaman = new Peminjaman
            {
                NamaPeminjam = dto.NamaPeminjam,
                NomorRuangan = dto.NomorRuangan,
                TanggalPinjam = dto.TanggalPinjam,
                TanggalKembali = dto.TanggalKembali,
                Keperluan = dto.Keperluan,
                Status = dto.Status
            };

            _db.Peminjamans.Add(peminjaman);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Show), new { id = peminjaman.Id }, peminjaman);
        }

        // PUT: api/peminjaman/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PeminjamanDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var peminjaman = await _db.Peminjamans.FindAsync(id);
            if (peminjaman == null)
                return NotFound(new { message = "Data tidak ditemukan" });

            peminjaman.NamaPeminjam = dto.NamaPeminjam;
            peminjaman.NomorRuangan = dto.NomorRuangan;
            peminjaman.TanggalPinjam = dto.TanggalPinjam;
            peminjaman.TanggalKembali = dto.TanggalKembali;
            peminjaman.Keperluan = dto.Keperluan;
            peminjaman.Status = dto.Status;

            await _db.SaveChangesAsync();
            return Ok(peminjaman);
        }

        // DELETE: api/peminjaman/5 (Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var peminjaman = await _db.Peminjamans.FindAsync(id);
            if (peminjaman == null)
                return NotFound(new { message = "Data tidak ditemukan" });

            peminjaman.DeletedAt = DateTime.Now;
            await _db.SaveChangesAsync();

            return Ok(new { message = "Data berhasil dihapus" });
        }

        // PATCH: api/peminjaman/5/status
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var peminjaman = await _db.Peminjamans.FindAsync(id);
            if (peminjaman == null)
                return NotFound(new { message = "Data tidak ditemukan" });

            var validStatus = new[] { "menunggu", "disetujui", "ditolak" };
            if (!validStatus.Contains(status))
                return BadRequest(new { message = "Status tidak valid" });

            peminjaman.Status = status;
            await _db.SaveChangesAsync();

            return Ok(peminjaman);
        }
    }
}