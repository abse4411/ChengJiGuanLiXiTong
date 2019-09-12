using System;
using static System.Console;

namespace ChengJiGuanLiXiTong.Helpers
{
    public static class InputHelper
    {
        public static bool TryReadInt32(out Int32 result)
        {
            var str =ReadLine();

            return Int32.TryParse(str, out result);
        }

        public static bool TryReadInt32(Func<Int32,Boolean> predicate, out int result)
        {
            result = -1;

            if (predicate == null)
                return false;

            var isSuccessful = TryReadInt32(out result);

            if (isSuccessful)
                return predicate(result);
            return false;
        }

        public static bool TryReadString(Func<String, Boolean> predicate, out String result)
        {
            result=String.Empty;

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            result = ReadLine();

            return predicate(result);
        }

        public static Boolean ReadString(String prompt, String errorMessage, Func<String, Boolean> predicate, out String result)
        {
            if(predicate==null)
                throw new ArgumentNullException(nameof(predicate));

            Write(prompt);
            var isSuccessful = TryReadString(predicate,out result);
            if(!isSuccessful)
                Write(errorMessage);

            return isSuccessful;
        }

        public static Boolean ReadInt32(String prompt, String errorMessage, Func<Int32, Boolean> predicate, out Int32 result)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            Write(prompt);
            var isSuccessful = TryReadInt32(predicate, out result);
            if (!isSuccessful)
                Write(errorMessage);

            return isSuccessful;
        }
    }
}
