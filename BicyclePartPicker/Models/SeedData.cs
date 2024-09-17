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
                if (context.Bicycle.Any())
                {
                    foreach (var entity in context.Bicycle)
                    {
                        context.Bicycle.Remove(entity);
                    }
                }
                context.Bicycle.AddRange(
                    new Bicycle
                    {
                        Make = "Specialized",
                        Model = "Tarmac",
                        Version = "SL7"
                    },
                    new Bicycle
                    {
                        Make = "Specialized",
                        Model = "Tarmac",
                        Version = "SL8"
                    },
                    new Bicycle
                    {
                        Make = "Trek",
                        Model = "Madone",
                        Version = "Gen 8"
                    },
                    new Bicycle
                    {
                        Make = "Trek",
                        Model = "Émonda",
                        Version = "SLR 9"
                    },
                    new Bicycle
                    {
                        Make = "Canyon",
                        Model = "Aeroad",
                        Version = "CF SLX 7"
                    },
                    new Bicycle
                    {
                        Make = "Canyon",
                        Model = "Endurance",
                        Version = "CF SLX 8"
                    },
                    new Bicycle
                    {
                        Make = "Canyon",
                        Model = "Aeroad",
                        Version = "CF SLX 8"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
