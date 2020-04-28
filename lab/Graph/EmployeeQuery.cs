using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using lab.Data.Interfaces;

namespace lab.Graph
{
    public class EmployeeQuery: ObjectGraphType
    {
        public EmployeeQuery(IEmployeeRepository  employeeRepository)
        {
            Field<ListGraphType<EmployeeType>>("employees",
                arguments: new QueryArguments(new List<QueryArgument> {
                    new QueryArgument<StringGraphType>{ Name="name" } 
                }),
                resolve: x =>
                {
                    var list = employeeRepository.GetEmployees();

                    var name = x.GetArgument<string>("name");
                    if (!string.IsNullOrEmpty(name))
                    {
                        list = list.Where(x => x.Name == name).ToList();
                    }
                    return list;
                });
        }
    }
}
