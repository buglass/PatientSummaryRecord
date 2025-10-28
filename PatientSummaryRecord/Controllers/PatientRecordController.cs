using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PatientSummaryRecord.Models;
using PatientSummaryRecord.Services;

namespace PatientSummaryRecord.Controllers
{
	[Route("patients")]
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
			IEnumerable<PatientDto> patients = _patientRecordRepository.SelectById(id);
			return patients.Any()
				? new OkObjectResult(patients.Single())
				: (ActionResult)new NotFoundResult();
		}
	}
}
