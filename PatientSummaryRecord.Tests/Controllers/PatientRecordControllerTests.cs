using Microsoft.AspNetCore.Mvc;
using Moq;
using PatientSummaryRecord.Controllers;
using PatientSummaryRecord.Models;
using PatientSummaryRecord.Services;
using System;
using Xunit;
using Microsoft.Extensions.Logging;

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
				DateOfBirth = new DateTime(2020, 01, 31),
				GPPractice = "North Bank"
			};

			var repository = new Mock<IPatientRecordRepository>();
			repository.Setup(r => r.PatientRecordExists(patientId)).Returns(true);
			repository.Setup(r => r.GetPatientRecord(patientId)).Returns(expectedData);

			var actual = new PatientRecordController(
				repository.Object,
				new Mock<ILogger<PatientRecordController>>().Object
			)
			.Get(patientId);

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

			var repository = new Mock<IPatientRecordRepository>();
			repository.Setup(r => r.PatientRecordExists(patientId)).Returns(false);

			var actual = new PatientRecordController(
				repository.Object,
				new Mock<ILogger<PatientRecordController>>().Object
			)
			.Get(patientId);

			Assert.IsType<NotFoundResult>(actual);
			var notFoundResult = (NotFoundResult)actual;
			Assert.Equal(expectedStatusCode, notFoundResult.StatusCode);
		}

		[Fact]
		public void AnyErrorReturns500()
		{
			const int patientId = 1;
			const int expectedStatusCode = 500;

			var repository = new Mock<IPatientRecordRepository>();
			repository.Setup(r => r.PatientRecordExists(patientId)).Returns(true);
			repository.Setup(r => r.GetPatientRecord(patientId)).Throws(new Exception());

			var actual = new PatientRecordController(
				repository.Object,
				new Mock<ILogger<PatientRecordController>>().Object
			).Get(patientId);

			Assert.IsType<StatusCodeResult>(actual);
			var statusCodeResult = (StatusCodeResult)actual;
			Assert.Equal(expectedStatusCode, statusCodeResult.StatusCode);
		}
	}
}
