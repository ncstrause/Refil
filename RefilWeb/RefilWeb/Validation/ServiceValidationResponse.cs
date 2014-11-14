using System;
using System.Collections.Generic;
using System.Linq;

namespace RefilWeb.Validation
{
    public class ServiceValidationResponse<T> : IServiceValidationResponse<T>
    {
        private readonly List<KeyValuePair<String, String>> errors;
        public T ServiceResultEntity { get; set; }

        public ServiceValidationResponse()
        {
            errors = new List<KeyValuePair<string, string>>();
        }

        public IEnumerable<KeyValuePair<string, string>> GetErrors()
        {
            return errors;
        }

        public void AddError(string key, string errorMessage)
        {
            errors.Add(new KeyValuePair<string, string>(key, errorMessage));
        }

        public bool IsValid
        {
            get { return !errors.Any(); }
        }
    }

    public class ServiceValidationResponse : IServiceValidationResponse
    {
        private readonly List<KeyValuePair<String, String>> errors;

        public ServiceValidationResponse()
        {
            errors = new List<KeyValuePair<string, string>>();
        }

        public IEnumerable<KeyValuePair<string, string>> GetErrors()
        {
            return errors;
        }

        public void AddError(string key, string errorMessage)
        {
            errors.Add(new KeyValuePair<string, string>(key, errorMessage));
        }

        public bool IsValid
        {
            get { return !errors.Any(); }
        }
    }
}