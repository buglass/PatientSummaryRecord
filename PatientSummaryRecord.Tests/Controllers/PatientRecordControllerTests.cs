using Microsoft.AspNetCore.Mvc;
using PatientSummaryRecord.Controllers;
using PatientSummaryRecord.Models;
using Xunit;

namespace PatientSummaryRecord.Tests.Controllers
{
	public class PatientRecordControllerTests
	{
		[Fact]
		public void ExistentPatientReturns200WithRecord()
		{
			const int patientId = 1;
			const int expectedStatusCode = 200;
			var expectedData = new PatientDto
			{
				Id = patientId,
				NHSNumber = "12345678",
				Name = "mock",
				DateOfBirth = new System.DateTime(2020, 01, 31),
				GPPractice = "North Bank"
			};

			var actual = new PatientRecordController().Get(patientId);

			Assert.IsType<OkObjectResult>(actual);
			var okResult = (OkObjectResult)actual;
			Assert.Equal(expectedStatusCode, okResult.StatusCode);
			Assert.Equal(expectedData, okResult.Value);
		}

		[Fact]
		public void NonExistentPatientReturns404()
		{
			const int patientId = 1;
			const int expectedStatusCode = 404;

			var actual = new PatientRecordController().Get(patientId);

			Assert.IsType<NotFoundResult>(actual);
			var notFoundResult = (NotFoundResult)actual;
			Assert.Equal(expectedStatusCode, notFoundResult.StatusCode);
		}
	}
}
