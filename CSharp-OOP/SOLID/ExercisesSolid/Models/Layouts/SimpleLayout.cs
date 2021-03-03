
using ExercisesSolid.Models.Contracts;

namespace ExercisesSolid.Models
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
