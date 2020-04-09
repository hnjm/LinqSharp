﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinqSharp.Data.Test
{
    [Flags]
    public enum EState
    {
        Default = 0,
        StateA = 1,
        StateB = 2,
        StateC = 4,
    }

    public class FreeModel : IEntity<FreeModel>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public EState State { get; set; }

    }
}