using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BicyclePartPicker.Models;

namespace BicyclePartPicker.Data
{
    public class BicyclePartPickerContext : DbContext
    {
        public BicyclePartPickerContext (DbContextOptions<BicyclePartPickerContext> options)
            : base(options)
        {
        }

        public DbSet<BicyclePartPicker.Models.Bicycle> Bicycle { get; set; } = default!;
        public DbSet<BicyclePartPicker.Models.BottomBracket> BottomBracket { get; set; } = default!;
    }
}
