using System.Collections.Generic;
using PatientSummaryRecord.Models;

namespace PatientSummaryRecord.Services
{
	public interface IPatientRecordRepository
	{
		IEnumerable<PatientDto> SelectById(int id);
	}
}
