using BicyclePartPicker.Data;
using Microsoft.EntityFrameworkCore;

namespace BicyclePartPicker.Models
{
    public class SeedData
    {
        public static void Initialization(IServiceProvider serviceProvider)
        {
            using (var context = new BicyclePartPickerContext(serviceProvider.GetRequiredService<DbContextOptions<BicyclePartPickerContext>>()))
            {

                // Remove everything for now
                if (context.Bicycle.Any() || context.BottomBracket.Any())
                {
                    foreach (var entity in context.BottomBracket)
                    {
                        context.BottomBracket.Remove(entity);
                    }
                    foreach (var entity in context.Bicycle)
                    {
                        context.Bicycle.Remove(entity);
                    }
                }

                List<BottomBracket> bottomBrackets;
                /*if (!context.BottomBracket.Any())
                {*/
                    bottomBrackets = new List<BottomBracket>
                    {
                        new BottomBracket { Brand = "SRAM", Name = "BSA & Italian Threaded DUB", bBType = "Threaded" },
                        new BottomBracket { Brand = "SRAM", Name = "T47 DUB", bBType = "Threaded" },
                        new BottomBracket { Brand = "Shimano", Name = "Dura-Ace & XTR Outboard", bBType = "Threaded" },
                        new BottomBracket { Brand = "Shimano", Name = "Ultegra BBR60 & Deore XT MT800 Outboard", bBType = "Threaded" }
                    };
                /*}
                else
                {
                    bottomBrackets = context.BottomBracket.ToList();
                }*/

                List<Bicycle> bicycles = new List<Bicycle>();
               /* if (!context.Bicycle.Any())
                {*/
                    var bottomBrackets1 = bottomBrackets.Where(bb => bb.bBType.Contains("Threaded")).ToList();
                    bicycles = new List<Bicycle> {
                        new Bicycle { Make = "Specialized",Model = "Tarmac", Version = "SL7", BottomBrackets = bottomBrackets.Where(bb => bb.bBType.Contains("Threaded")).ToList() },
                        new Bicycle { Make = "Specialized", Model = "Tarmac", Version = "SL8", BottomBrackets = bottomBrackets.Where(bb => bb.bBType.Contains("Threaded")).ToList() },
                        new Bicycle { Make = "Trek", Model = "Madone", Version = "Gen 8", BottomBrackets = bottomBrackets.Where(bb => bb.bBType.Contains("Threaded")).ToList() },
                        new Bicycle { Make = "Trek", Model = "Émonda", Version = "SLR 9", BottomBrackets = bottomBrackets.Where(bb => bb.bBType.Contains("Threaded")).ToList() },
                        new Bicycle { Make = "Canyon", Model = "Aeroad", Version = "CF SLX 7", BottomBrackets = bottomBrackets.Where(bb => bb.bBType.Contains("Threaded")).ToList() },
                        new Bicycle { Make = "Canyon", Model = "Endurance", Version = "CF SLX 8", BottomBrackets = bottomBrackets.Where(bb => bb.bBType.Contains("Threaded")).ToList() },
                        new Bicycle { Make = "Canyon", Model = "Aeroad", Version = "CF SLX 8", BottomBrackets = bottomBrackets.Where(bb => bb.bBType.Contains("Threaded")).ToList() }
                    };
               /* }
                else
                {
                    bicycles = context.Bicycle.ToList();
                }*/

                for (int i = 0; i < bottomBrackets.Count; i++)
                {
                    bottomBrackets[i].Bicycles = bicycles.Where(bicycle => bicycle.BottomBrackets.Where(bb => bb.Id == bottomBrackets[i].Id) != null).ToList();
                }

                context.Bicycle.AddRange(bicycles);
                context.BottomBracket.AddRange(bottomBrackets);

                context.SaveChanges();
            }
        }
    }
}
