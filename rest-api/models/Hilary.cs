using System;
namespace rest_api.models
{
    public class Hilary
    { 

        public Hilary(String name, String surname)
        {
            this.Name = name;
            this.Surnsmae = surname;
        }


        public String Name { get; set; }

        public String Surnsmae { get; set; }
    }
}
