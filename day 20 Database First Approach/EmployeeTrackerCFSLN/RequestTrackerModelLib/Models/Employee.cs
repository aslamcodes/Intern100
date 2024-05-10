namespace RequestTrackerModelLib.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public override string ToString()
        {
            return Id + " " + Name + " " + Role;
        }
        public virtual bool PasswordCheck(string password)
        {
            return Password == password;
        }

        /*
         * No effect on the table? why? because it is not a property of the table, why it is not a part of the model, its in the employee class? 
         * because it is a navigation property, it is a collection of requests that are raised by the employee? why it is a navigation property and what is a navigation property in entity framework? 
         * it is a property that is used to navigate from one entity to another entity, it is used to define the relationship between the entities, it is used to define the foreign key relationship between the entities, 
         * it is used to define the parent child relationship between the entities, it is used to define the one to many relationship between the entities, it is used to define the many to many relationship between the entities, 
         * it is used to define the one to one relationship between the entities, it is used to define the inheritance relationship between the entities, it is used to define the association relationship between the entities, 
         * it is used to define the composition relationship between the entities, it is used to define the aggregation
         * How to identify a navigation property in entity framework? we can identify a navigation property in entity framework by looking at the property that is used to navigate from one entity to another entity, 
         * what to look on the property? we can look at the property that is used to navigate from one entity to another entity, we can look at the property that is used to define the relationship between the entities,
         * 
         */
        public ICollection<Request> RequestsRaised { get; set; }

        /*
         * No effect on the table
         */
        public ICollection<Request> RequestsClosed { get; set; }

    }
}
