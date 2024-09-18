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
                context.BottomBracket.AddRange(
                    new BottomBracket
                    {
                        Brand = "SRAM",
                        Name = "BSA & Italian Threaded DUB",
                        bBType = "Threaded"
                    },
                    new BottomBracket
                    {
                        Brand = "SRAM",
                        Name = "T47 DUB",
                        bBType = "Threaded"
                    },
                    new BottomBracket
                    {
                        Brand = "Shimano",
                        Name = "Dura-Ace & XTR Outboard",
                        bBType = "Threaded"
                    },
                    new BottomBracket
                    {
                        Brand = "Shimano",
                        Name = "Ultegra BBR60 & Deore XT MT800 Outboard",
                        bBType = "Threaded"
                    }
                );
                context.Bicycle.AddRange(
                    new Bicycle
                    {
                        Make = "Specialized",
                        Model = "Tarmac",
                        Version = "SL7",
                        BottomBracket =
                            context.BottomBracket.Where(bb => bb.bBType == "Threaded" && (bb.Name == "SRAM" || bb.Name == "Shimano")).ToList(),
                    },
                    new Bicycle
                    {
                        Make = "Specialized",
                        Model = "Tarmac",
                        Version = "SL8",
                        BottomBracket =
                            context.BottomBracket.Where(bb => bb.bBType == "Threaded" && (bb.Name == "SRAM" || bb.Name == "Shimano")).ToList(),
                    },
                    new Bicycle
                    {
                        Make = "Trek",
                        Model = "Madone",
                        Version = "Gen 8",
                        BottomBracket =
                            context.BottomBracket.Where(bb => bb.bBType == "Threaded" && (bb.Name == "SRAM" || bb.Name == "Shimano")).ToList(),
                    },
                    new Bicycle
                    {
                        Make = "Trek",
                        Model = "Émonda",
                        Version = "SLR 9",
                        BottomBracket =
                            context.BottomBracket.Where(bb => bb.bBType == "Threaded" && (bb.Name == "SRAM" || bb.Name == "Shimano")).ToList(),
                    },
                    new Bicycle
                    {
                        Make = "Canyon",
                        Model = "Aeroad",
                        Version = "CF SLX 7",
                        BottomBracket =
                            context.BottomBracket.Where(bb => bb.bBType == "Threaded" && (bb.Name == "SRAM" || bb.Name == "Shimano")).ToList(),
                    },
                    new Bicycle
                    {
                        Make = "Canyon",
                        Model = "Endurance",
                        Version = "CF SLX 8",
                        BottomBracket =
                            context.BottomBracket.Where(bb => bb.bBType == "Threaded" && (bb.Name == "SRAM" || bb.Name == "Shimano")).ToList(),
                    },
                    new Bicycle
                    {
                        Make = "Canyon",
                        Model = "Aeroad",
                        Version = "CF SLX 8",
                        BottomBracket =
                            context.BottomBracket.Where(bb => bb.bBType == "Threaded" && (bb.Name == "SRAM" || bb.Name == "Shimano")).ToList(),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
