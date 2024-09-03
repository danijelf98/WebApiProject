using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProject.Shared.Models
{
    public static class ErrorCodes
    {
        public const string MissingVlue = "1";
        public const string NotFound = "2";
        public const string AlreadyExist = "3";
        public const string InvalidFormat = "4";
        public const string AccessDenied = "5";
        public const string InvalidVat = "6";
        public const string InvalidFreshToken = "7";
        public const string InvalidRole = "8";
        public const string OutOfRange = "9";
    }
}
