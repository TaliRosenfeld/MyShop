﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record productDTO(int? Id, string? Name, string? Description, double? Price, string? Image, string? CategoryName);
    public record productwithoutidDTO(string? Name, string? Description, double? Price, string? Image, string? CategoryName);

}
