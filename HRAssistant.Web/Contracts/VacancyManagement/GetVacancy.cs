﻿using System;
using HRAssistant.Web.Infrastructure.CQRS;

namespace HRAssistant.Web.Contracts.VacancyManagement
{
    public sealed class GetVacancy : IQuery<GetVacancyResult>
    {
        public Guid? VacancyId { get; set; }
    }
}
