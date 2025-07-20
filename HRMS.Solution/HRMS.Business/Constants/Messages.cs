using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Business.Constants
{
    public static class Messages
    {
        public static string AlreadyExistsMessage(string input) => $"{input} already exists.";
        public static string AddedMessage(string input) => $"{input} added successfully.";
        public static string UpdatedMessage(string input) => $"{input} updated successfully.";
        public static string DeletedMessage(string input) => $"{input} deleted successfully.";
        public static string NotFoundMessage(string input) => $"{input} not found.";
        public static string WasBroughtMessage(string input) => $"{input} was retrieved.";
        public static string ListedMessage(string input) => $"{input} listed.";
    }
}
