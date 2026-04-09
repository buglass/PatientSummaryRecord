using Microsoft.EntityFrameworkCore;
using PatientSummaryRecord.Models;

namespace PatientSummaryRecord.Services
{
	public class PatientRecordContext : DbContext
	{
		public PatientRecordContext(DbContextOptions<PatientRecordContext> options)
			: base(options)
		{
		}

		public DbSet<PatientDto> Items
		{
			get;
		}
	}
}
