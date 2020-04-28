using System;
using GraphQL.Types;
using lab.Data.Entities;

namespace lab.Graph
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {

            Name = "Employee";
            Field(x => x.Age);
            Field(x => x.BirthDate);
            Field(x => x.Id, type:typeof(IdGraphType));
            Field(x => x.LastName);
            Field(x => x.Name);

        }
    }
}
