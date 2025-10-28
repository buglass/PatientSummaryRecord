using Microsoft.AspNetCore.Mvc;
using Moq;
using PatientSummaryRecord.Controllers;
using PatientSummaryRecord.Models;
using PatientSummaryRecord.Services;
using System.Linq;
using System;
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

			var repository = new Mock<IPatientRecordRepository>();
			repository.Setup(r => r.SelectById(patientId)).Returns(new[] { expectedData });

			var actual = new PatientRecordController(repository.Object).Get(patientId);

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
			repository.Setup(r => r.SelectById(patientId)).Returns(Enumerable.Empty<PatientDto>);

			var actual = new PatientRecordController(repository.Object).Get(patientId);

			Assert.IsType<NotFoundResult>(actual);
			var notFoundResult = (NotFoundResult)actual;
			Assert.Equal(expectedStatusCode, notFoundResult.StatusCode);
		}

		[Fact]
		public void MultiplePatientsThrowsException()
		{
			const int patientId = 1;

			var repository = new Mock<IPatientRecordRepository>();
			repository.Setup(r => r.SelectById(patientId)).Returns(
				new[]
				{
					new PatientDto
					{
						Id = patientId,
						NHSNumber = "12341234",
						Name = "patient one",
						DateOfBirth = new System.DateTime(2020, 01, 31),
						GPPractice = "North Bank"
					},
					new PatientDto
					{
						Id = patientId,
						NHSNumber = "88888888",
						Name = "patient two",
						DateOfBirth = new System.DateTime(1920, 01, 31),
						GPPractice = "South Bank"
					},
				}
			);

			Assert.Throws<InvalidOperationException>(() =>
				new PatientRecordController(repository.Object).Get(patientId)
			);
		}
	}
}
