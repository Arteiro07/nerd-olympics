using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdOlympics.Data.Models.ErrorHandling
{
    public static class ErrorMessage
    {
        // Competitions
        public const string COMPETITION_CREATE_ERROR = "Error creating competiton";
        public const string COMPETITION_UPDATE_ERROR = "Error updating competiton";
        public const string COMPETITION_DELETE_ERROR = "Error deleting competiton";
        public const string COMPETITION_NOT_FOUND = "Competition does not exist";
        public const string COMPETITION_NAME_EXISTS = "Competition name already exists";

        // Users 
        public const string USER_CREATE_ERROR = "Error creating user";
        public const string USER_UPDATE_ERROR = "Error updating user";
        public const string USER_DELETE_ERROR = "Error deleting user";
        public const string USER_EMAIL_EXISTS = "Email already in use";
        public const string USER_NOT_FOUND = "User does not exist";
        public const string USER_INVALID_CREDENTIALS = "Invalid user credentials";
        public const string USER_DOES_NOT_OWN_COMPETITION = "User doesn't have permissions to edit competition";

        // Records
        public const string RECORD_CREATE_ERROR = "Error creating record";
        public const string RECORD_UPDATE_ERROR = "Error updating record";
        public const string RECORD_DELETE_ERROR = "Error deleting record";
        public const string RECORD_NOT_FOUND = "Record does not exist";

        public const string GENERIC_DB_ERROR = "There is a problem with our servers, hang in there and call Arteiro";
    }
}
