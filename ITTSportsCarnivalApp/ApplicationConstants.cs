using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITTSportsCarnivalApp
{
    public static class ApplicationConstants
    {
        public static readonly int[] gameTypes = { 1, 2, 3 };
        public const string SerializeJsonIntoObjectsFailureMessage = "Error in serializing json into file.";
        public const string DeserializeJsonIntoObjectsFailureMessage = "Error in deserializing json into object.";
    }
}
