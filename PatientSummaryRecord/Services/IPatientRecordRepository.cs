using PatientSummaryRecord.Models;

namespace PatientSummaryRecord.Services
{
	public interface IPatientRecordRepository
	{
		bool PatientRecordExists(int id);
		PatientDto GetPatientRecord(int id);
	}
}
