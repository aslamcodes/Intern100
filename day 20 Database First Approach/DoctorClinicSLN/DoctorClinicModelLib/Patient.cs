namespace DoctorClinicModelLib
{
    public class Patient(string name, string bloodGroup, int age, string sex, int weight, int height)
    {
        public int Id { get; set; }

        public string Name { get; set; } = name;

        public string BloodGroup { get; set; } = bloodGroup;

        public int Age { get; set; } = age;

        public string Sex { get; set; } = sex;

        public int Weight { get; set; } = weight;

        public int Height { get; set; } = height;

        public override bool Equals(object? obj)
        {
            return Id == (obj as Patient).Id;
        }

    }
}
