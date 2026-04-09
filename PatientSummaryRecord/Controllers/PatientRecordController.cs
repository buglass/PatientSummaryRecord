using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientSummaryRecord.Services;

namespace PatientSummaryRecord.Controllers
{
	[Route("patients")]
	[ApiController]
	public class PatientRecordController
	{
		private readonly IPatientRecordRepository _patientRecordRepository;
		private readonly ILogger<PatientRecordController> _logger;

		public PatientRecordController(
			IPatientRecordRepository patientRecordRepository,
			ILogger<PatientRecordController> logger
		) {
			_patientRecordRepository = patientRecordRepository;
			_logger = logger;
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			try
			{
				return
					_patientRecordRepository.PatientRecordExists(id)
					? new OkObjectResult(_patientRecordRepository.GetPatientRecord(id))
					: (ActionResult)new NotFoundResult();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Could not get patient ID {id}: {ex.Message}");
				return new StatusCodeResult(500);
			}
		}
	}
}
