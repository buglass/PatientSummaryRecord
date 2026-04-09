using System.Linq;
using PatientSummaryRecord.Models;

namespace PatientSummaryRecord.Services
{
	public class PatientRecordRepository : IPatientRecordRepository
	{
		private readonly PatientRecordContext _context;

		public PatientRecordRepository(PatientRecordContext context)
		{
			_context = context;
		}

		public bool PatientRecordExists(int id)
		{
			return _context.Items.Any(item => item.Id == id);
		}

		public PatientDto GetPatientRecord(int id)
		{
			return _context.Items.Find(id);
		}
	}
}
