﻿namespace Kemet.ERP.Contracts.Response
{
    public static class ApiMessage
    {
        // CURD Successful
        public readonly static string SuccessfulCreate = "The entity has been created successfully.";
        public readonly static string SuccessfulUpdate = "The entity has been updated successfully.";
        public readonly static string SuccessfulDelete = "The entity has been deleted successfully.";

        // CURD Failure
        public readonly static string FailedCreate = "Failed to create the entity. Please check your input and try again later.";
        public readonly static string FailedUpdate = "Failed to update the entity. Please check your input and try again later.";
        public readonly static string FailedDelete = "Failed to delete the entity. Please check your input and try again later.";

        // Common
        public readonly static string EntityIdMismatch = "The entity ID provided in the URL does not match the entity ID in the request body.";
    }
}
