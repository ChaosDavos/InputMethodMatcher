using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApptstingClasses004.TestObjects
{
    class InputDecisionHandler
    {
        private readonly Type type;
        private IEnumerable<MethodInfo> typeMethods;
        private IEnumerable<MethodInfo> call;
        public List<string> sensibles;

        public InputDecisionHandler(Type type)
        {
            this.type = type;
            this.Initialize();
        }

        private void Initialize()
        {
            typeMethods  =  from i in Assembly.GetExecutingAssembly().GetType(type.FullName).GetMethods()
                            select i;
            sensibles = new List<string> {"File", "Testing" , "Https"};
        }

        public bool Handle(string input, params object?[]? parameters)
        {
            call = from i in typeMethods
                   where ((i.Name.ToString().ToLower().Replace(type.Name.ToLower(), "")) == input.ToLower()) && this.ContainsSensible(input.ToLower(), type.Name.ToLower())
                   select i;

            if (!call.Any())
            {
                return false;
            }
            else
            {
                foreach (MethodInfo i in call)
                {
                    if (i.GetParameters().Length == 0)
                    {
                        if(parameters == null || parameters.Length == 0)
                        {
                            i.Invoke(null, null);
                        }
                        else
                        {
                            continue;
                            throw new ArgumentOutOfRangeException("Parameters do not Match"); //take what you want either you work with Exceptions or returns or do not want anything to happen at all
                            return false;
                        }
                    }
                    else if (i.GetParameters().Length >= 1)
                    {
                        if (i.GetParameters().Length != parameters.Length)
                        {
                            continue;
                            throw new ArgumentOutOfRangeException("Parameters do not Match");
                            return false;
                        }
                        i.Invoke(null, parameters);
                    }
                    else
                    {
                        continue;
                        return false;
                    }
                }
                return true;
            }
        }

        private bool ContainsSensible(string name, string className)
        {
            foreach (string t in sensibles)
            {
                if (name.Contains(t.ToLower()) && !name.Contains(className))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
