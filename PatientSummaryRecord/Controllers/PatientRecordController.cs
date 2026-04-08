using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientSummaryRecord.Models;
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
				IEnumerable<PatientDto> patients = _patientRecordRepository.SelectById(id);
				return patients.Any()
					? new OkObjectResult(patients.Single())
					: (ActionResult)new NotFoundResult();
			} catch (Exception ex) {
				_logger.LogError($"Could not get patient ID {id}: {ex.Message}");
				return new StatusCodeResult(500);
			}
		}
	}
}
