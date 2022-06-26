using InnovateQ.Assignment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Core.Extensions
{
    public static class UserExtensions
    {
        public static string FullAddress<T>(this T value) where T : User
        {
            string[] all = { value.Country, value.State, value.Street, value.PinCode };
            string result = string.Join(" | ", all.Where(str => !string.IsNullOrEmpty(str)));
            return result;
        }

    }
}
