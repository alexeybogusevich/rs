﻿using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class StudyType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<StudySubtype> StudySubtypes { get; set; }
    }
}
