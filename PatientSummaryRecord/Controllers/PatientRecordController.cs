using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PatientSummaryRecord.Services;

namespace PatientSummaryRecord.Controllers
{
	[Route("Patients")]
	[ApiController]
	public class PatientRecordController
	{
		private readonly IPatientRecordRepository _patientRecordRepository;

		public PatientRecordController(IPatientRecordRepository patientRecordRepository)
		{
			_patientRecordRepository = patientRecordRepository;
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			try {
				return new OkObjectResult(_patientRecordRepository.SelectById(id).Single());
			} catch (ArgumentNullException) {
				return new NotFoundResult();
			}
		}
	}
}
