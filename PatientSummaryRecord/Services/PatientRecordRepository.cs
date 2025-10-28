using System.Collections.Generic;
using System.Linq;
using PatientSummaryRecord.Models;

namespace PatientSummaryRecord.Services
{
	public class PatientRecordRepository : IPatientRecordRepository
	{
		public IEnumerable<PatientDto> SelectById(int id)
		{
			return new[]
			{
				new PatientDto
				{
					Id = 1,
					NHSNumber = "1234",
					Name = "Mr. Buggington",
					DateOfBirth = new System.DateTime(2020, 01, 31),
					GPPractice = "North Bank"
				},
				new PatientDto
				{
					Id = 2,
					NHSNumber = "88888888",
					Name = "Mrs. Bugsworth",
					DateOfBirth = new System.DateTime(1920, 01, 31),
					GPPractice = "South Bank"
				},
				new PatientDto
				{
					Id = 3,
					NHSNumber = "98432",
					Name = "Duggee",
					DateOfBirth = new System.DateTime(1982, 08, 02),
					GPPractice = "Squirrel Club"
				},
				new PatientDto
				{
					Id = 4,
					NHSNumber = "53",
					Name = "Roly",
					DateOfBirth = new System.DateTime(1990, 07, 29),
					GPPractice = "POTATO!"
				},
				new PatientDto
				{
					Id = 5,
					NHSNumber = "111",
					Name = "Treble One",
					DateOfBirth = new System.DateTime(1917, 08, 01),
					GPPractice = "Lossiemouth"
				},
			}.Where(patient => patient.Id == id);
		}
	}
}
