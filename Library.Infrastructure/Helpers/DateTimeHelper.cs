
namespace Library.Infrastructure.Helpers
{
    public static class DateTimeHelper
    {
        public static int CalculateAge(DateTime dob)
        {
            var today = DateTime.Today;
            int age = today.Year - dob.Year;

            if (dob.Date > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
