using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PatientSummaryRecord.Models;
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
		public IEnumerable<PatientDto> Get(int id)
		{
			throw new NotImplementedException();
		}
	}
}
