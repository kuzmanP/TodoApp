﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Person
{
    public record CreatePersonDto(string FirstName, string LastName, DateOnly DateOfBirth, string? JobTitle);
}