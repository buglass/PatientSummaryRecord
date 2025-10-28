using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PatientSummaryRecord.Models;

namespace PatientSummaryRecord.Controllers
{
	[Route("Patients")]
	[ApiController]
	public class PatientRecordController
	{
		[HttpGet("{id}")]
		public IEnumerable<PatientDto> Get(int id)
		{
			throw new NotImplementedException();
		}
	}
}
