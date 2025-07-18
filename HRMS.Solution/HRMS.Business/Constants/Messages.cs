using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Business.Constants
{
    public static class Messages
    {
        public static string NotFoundMessage(string notFoundObject)
        {
            return $"{notFoundObject} is not found";
        }

        public static string ListedMessage(string listedObject)
        {
            return $"{listedObject} listed.";
        }

        public static string UpdatedMessage(string updatedObject)
        {
            return $"{updatedObject} updated.";
        }

        public static string DeletedMessage(string deletedObject)
        {
            return $"{deletedObject} deleted.";
        }

        public static string WasBroughtMessage(string broughtObject)
        {
            return $"{broughtObject} was brought.";
        }

        public static string AddedMessage(string addedObject)
        {
            return $"{addedObject} added.";
        }

        public static string IncludesMessage(string includedObject)
        {
            return $"{includedObject} already exists.";
        }

        public static string WithDetailsMessage(string withDetailsObject)
        {
            return $"{withDetailsObject} was brought with details";
        }
    }
}
